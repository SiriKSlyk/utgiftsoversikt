<<<<<<< HEAD
using Azure.ResourceManager.CosmosDB.Models;
=======

>>>>>>> 6adc23507ea9aeabd4e85b10a1e9c111d6d5a6fa

var builder = DistributedApplication.CreateBuilder(args);

var db = builder.ExecutionContext.IsRunMode ?
        builder.AddConnectionString("cosmos"):
        builder.AddAzureCosmosDB("cosmos").AddDatabase("db");//.RunAsEmulator();
//var db = builder.AddAzureCosmosDB("cosmos").AddDatabase("db");
<<<<<<< HEAD

builder.AddProject<Projects.utgiftsoversikt>("utgiftsoversikt")
    .WithReference(db)
    .WithExternalHttpEndpoints();
=======

var backend = builder.AddProject<Projects.utgiftsoversikt>("utgiftsoversikt")
    .WithReference(db)
    .WithExternalHttpEndpoints();

/*builder.AddNpmApp("frontend", "../frontend").WithReference(backend)
    .WithEnvironment("BROWSER", "none") // Disable opening browser on npm start
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints();*/

>>>>>>> 6adc23507ea9aeabd4e85b10a1e9c111d6d5a6fa

builder.Build().Run();
