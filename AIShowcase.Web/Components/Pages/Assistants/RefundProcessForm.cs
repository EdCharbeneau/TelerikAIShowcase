using System.ComponentModel.DataAnnotations;

namespace AIShowcase.WebApp.Components.Pages;

public class RefundProcessForm
{
	[Required]
	[Display(Name = "RMA Number", Description = "A unique identifier for the return request.")]
	public string? RmaNumber { get; set; }

	[Required]
	[Display(Name = "Customer Name", Description = "Full name of the customer.")]
	public string? CustomerName { get; set; }

	[Required]
	[EmailAddress]
	[Display(Name = "Email", Description = "Customer's contact email.")]
	public string? Email { get; set; }

	[Required]
	[Display(Name = "Address", Description = "Customer's address.")]
	public string? Address { get; set; }

	[Required]
	[Display(Name = "Order Number", Description = "The original purchase order associated with the return.")]
	public string? OrderNumber { get; set; }

	[Required]
	[Display(Name = "Product Name", Description = "Name of the product being returned.")]
	public string? ProductName { get; set; }

	[Display(Name = "Model", Description = "Model of the product.")]
	public string? Model { get; set; }

	[Display(Name = "Serial Number", Description = "Serial number of the product.")]
	public string? SerialNumber { get; set; }

	[Required]
	[Display(Name = "Return Reason", Description = "Reason for the return (e.g., defective, incorrect item, damaged, etc.).")]
	public string? ReturnReason { get; set; }

	[Required]
	[DataType(DataType.Date)]
	[Display(Name = "Purchase Date", Description = "The date the purchase was made.")]
	public DateTime? PurchaseDate { get; set; }

	[Required]
	[Display(Name = "Condition of Item", Description = "Condition of the item (e.g., unopened, damaged, used).")]
	public string? ConditionOfItem { get; set; }

	[Required]
	[Display(Name = "Requested Action", Description = "The action requested by the customer regarding the return.")]
	public RequestedActionType? RequestedAction { get; set; }

	public enum RequestedActionType
	{
		Replacement,
		Repair,
		Refund,
		StoreCredit,
		Exchange
	}
}