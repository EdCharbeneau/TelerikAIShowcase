using AIShowcase.WebApp.Components.Pages;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.AI;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Schema;
using Telerik.Blazor.Components;

namespace AIShowcase.WebApp.Components.Pages.Assistants;

public partial class Home
{
    private IChatClient ai;// Provided by the DI container
	private RefundProcessForm refundProcessForm = new RefundProcessForm();
    private EditContext? editContext;
    private TelerikNotification? notification; // reference for notification component

    // The complete chat history 
    private List<ChatMessage> messages = [];
    private AIFunction[]? tools = [];

    // Chat history that is visible to the user
    private List<UIChatMessage> uiChatHistory { get; set; } = new List<UIChatMessage>();

    public Home(IChatClient client)
    {
        ai = client;
        editContext = new EditContext(refundProcessForm);
        tools = [AIFunctionFactory.Create(UpdateForm),
                AIFunctionFactory.Create(ClearFormField),
                AIFunctionFactory.Create(OnSubmitHandler)
        ];

        const string modelDescription = "An RMA return materials form";
        string jsonSchema = JsonSerializer.Serialize(
       JsonSerializerOptions.Default.GetJsonSchemaAsNode(typeof(RefundProcessForm), new() { TreatNullObliviousAsNonNullable = true }));
        string systemPrompt = @$"**Current date**: {DateTime.Today.ToString("D", CultureInfo.InvariantCulture)} 
			- You are helping a customer edit a JSON object that represents a {modelDescription}.
            - This JSON object conforms to the following schema: {jsonSchema}
			- You are assisting a customer in filling out a form.
			- Each time they provide information that can be added to the JSON object, add it to the existing object,
                and then call the tool {nameof(UpdateForm)} to save the updated object. Don't stop updating the JSON object. Ensure the previous object is provided to the
			- For each key, infer a value from USER_DATA: {JsonSerializer.Serialize(refundProcessForm, JsonSerializerOptions.Web)}
			- Convert any dates given by the user to: yyyy-MM-dd format.
            - If the user provides a value that is not valid for the field, ask them to clarify or provide a valid value.
			- Summarize the previous actions taken in plain text.
			- Help guide the user by asking questions about missing data without revealing they are filling out a form.
			- Only ask about one item.
            - If you need to clear a field use the tool {nameof(ClearFormField)} instead of saving the JSON data.
            - When the all fields are filled, use the tool {nameof(OnSubmitHandler)} to submit the form. If the submission fails, ask the user if they would like assistance fixing the errors. If the submission was successful summarize the task for the user in 1-2 sentences.";
        messages = new List<ChatMessage>
        {
            new ChatMessage(ChatRole.System, systemPrompt),
            new ChatMessage(ChatRole.System, "Greet the user then ask about the first item required. Notify them they can paste text from documents like emails to quicken the process.")
        };
    }

    protected override async Task OnInitializedAsync()
    {
        var response = await ai.GetResponseAsync(messages);
        messages.Add(new ChatMessage(ChatRole.Assistant, response.Text));
        uiChatHistory.Add(UIChatMessage.AssistantMessage(response.Text));
	}

	private async Task HandlePromptRequest(ChatSendMessageEventArgs args)
    {
        messages.Add(new ChatMessage(ChatRole.User, args.Message));
		uiChatHistory.Add(UIChatMessage.UserMessage(args.Message));

		var userData = $"USER_DATA: {JsonSerializer.Serialize(refundProcessForm, JsonSerializerOptions.Web)}" +
            $"USER_REQUEST: {args.Message}";
        var response = await ai.GetResponseAsync([.. messages, new ChatMessage(ChatRole.User, userData)], new ChatOptions { Tools = tools });
        
        messages.AddMessages(response);
		uiChatHistory.Add(UIChatMessage.AssistantMessage(response.Text));

	}

    private void HumanSubmit()
    {
		notification?.Show(new NotificationModel
		{
			CloseAfter = 0,
			Text = "RMA form submitted successfully.",
			ThemeColor = "success"
		});
	}

	#region AI Tools

	[Description("Updates the form you are assisting the customer with. " +
        "Please provide all fields in JSON format with the provided schema, even if they are not changed. " +
        "If you want to clear a field, use the tool ClearFormField with the field name as the parameter.")]
    public string UpdateForm(RefundProcessForm updatedForm)
    {
        if (updatedForm is null)
        {
            return "Incorrect data provided, please provide all fields in JSON format.";
		}
		InvokeAsync(() =>
        {
            if (UpdateModelProperties(refundProcessForm, updatedForm))
            {
                StateHasChanged();
            }
        });
        return "Form updated successfully.";
    }

    [Description("Submits the form you are assisting the customer with.")]
	private string OnSubmitHandler()
	{
		bool isFormValid = editContext!.Validate();
        StateHasChanged();
		if (isFormValid)
		{
            notification?.Show(new NotificationModel
            {
                CloseAfter = 0,
				Text = "RMA form submitted successfully.",
                ThemeColor = "success"
            });
			return "Your form has been submitted successfully.";
		}
		else
		{
			return "The form could not be submitted ask the user if they would like assistance fixing the errors. Validation failed for " + string.Join(", ", editContext.GetValidationMessages());
		}
	}

	[Description("Clears a field in the form you are assisting the customer with.")]
    public void ClearFormField(string fieldName)
    {
        InvokeAsync(() =>
        {
            if (ClearModelProperty(fieldName))
            {
                StateHasChanged();
            }
        });
    }


    private bool UpdateModelProperties(object oldModel, object newModel)
    {
        var foundChange = false;
        foreach (var prop in oldModel.GetType().GetProperties())
        {
            var oldValue = prop.GetValue(oldModel);
            var newValue = prop.GetValue(newModel);
            if (newValue == default)
                continue;
            if (prop.PropertyType.GetCustomAttributes<ValidateComplexTypeAttribute>().Any())
            {
                foundChange |= UpdateModelProperties(oldValue!, newValue!);
            }
            else if (oldValue != newValue)
            {
                prop.SetValue(oldModel, newValue);
                editContext!.NotifyFieldChanged(new FieldIdentifier(oldModel, prop.Name));
                foundChange = true;
            }
        }

        return foundChange;
    }

    private bool ClearModelProperty(string fieldName)
    {
        // Try to find the property by case-insensitive match
        var prop = editContext!.Model.GetType()
            .GetProperties()
            .FirstOrDefault(p => 
                string.Equals(p.Name, fieldName, StringComparison.OrdinalIgnoreCase) ||
                string.Equals(JsonNamingPolicy.CamelCase.ConvertName(p.Name), fieldName, StringComparison.Ordinal)
            );

        if (prop is not null)
        {
            prop.SetValue(editContext.Model, default);
            editContext.NotifyFieldChanged(new FieldIdentifier(editContext.Model, prop.Name));
            return true;
        }
        return false;
    }
	#endregion

}