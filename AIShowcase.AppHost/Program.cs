using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var ollama = builder
	// 🦙 Add an ollama container
	.AddOllama("ollama")
	// ⚡Speed up inference
	.WithGPUSupport()
	// ♻️ Save the model to the data volume
	.WithDataVolume()
	// 🌐 Enable prebuilt Web Interface
	//.WithOpenWebUI()
	;

// 🤖 Add a model
var phi4 = ollama.AddModel(
	name: "phi4", // 🏷️ Name referenced by your application
	modelName: "phi4"
	);

var aiShowcase = builder.AddProject<AIShowcase_WebApp>("aiShowcase")
	.WithReference(phi4)
	.WaitFor(phi4);

builder.Build().Run();
