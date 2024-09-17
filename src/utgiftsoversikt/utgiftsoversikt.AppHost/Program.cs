var builder = DistributedApplication.CreateBuilder(args);

var db = builder.ExecutionContext.IsRunMode ?
    builder.AddConnectionString("cosmos"):
    builder.AddAzureCosmosDB("cosmos").AddDatabase("db");//.RunAsEmulator();

builder.AddProject<Projects.utgiftsoversikt>("utgiftsoversikt").WithReference(db);

builder.Build().Run();
