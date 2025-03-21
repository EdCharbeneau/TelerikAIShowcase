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
var embed = ollama.AddModel(
	name: "local-embedding", // 🏷️ Name referenced by your application
	modelName: "nomic-embed-text"
	);

// 🤖 Add a model
var llama = ollama.AddModel(
	name: "llama32", // 🏷️ Name referenced by your application
	modelName: "llama3.2"
	);


var aiShowcase = builder.AddProject<AIShowcase_WebApp>("aiShowcase")
	.WithReference(llama)
	.WaitFor(llama)
	.WithReference(embed)
	.WaitFor(embed);

builder.Build().Run();
