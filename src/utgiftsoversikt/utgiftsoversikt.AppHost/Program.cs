var builder = DistributedApplication.CreateBuilder(args);



builder.AddProject<Projects.utgiftsoversikt>("utgiftsoversikt");

builder.Build().Run();
