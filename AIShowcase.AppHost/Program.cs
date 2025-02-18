using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var aiShowcase = builder.AddProject<AIShowcase_WebApp>("aiShowcase");

builder.Build().Run();
