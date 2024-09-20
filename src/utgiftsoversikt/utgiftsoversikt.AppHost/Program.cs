using Azure.ResourceManager.CosmosDB.Models;

var builder = DistributedApplication.CreateBuilder(args);

var db = builder.ExecutionContext.IsRunMode ?
        builder.AddConnectionString("cosmos"):
        builder.AddAzureCosmosDB("cosmos").AddDatabase("db");//.RunAsEmulator();
//var db = builder.AddAzureCosmosDB("cosmos").AddDatabase("db");

builder.AddProject<Projects.utgiftsoversikt>("utgiftsoversikt")
    .WithReference(db)
    .WithExternalHttpEndpoints();

builder.Build().Run();
