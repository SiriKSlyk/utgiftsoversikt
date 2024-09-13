var builder = DistributedApplication.CreateBuilder(args);



//var db = builder.AddSqlServer("sql").AddDatabase("db");
var db = builder.AddSqlServer("sql").PublishAsAzureSqlDatabase().AddDatabase("db");

builder.AddProject<Projects.utgiftsoversikt>("utgiftsoversikt").WithReference(db);

builder.Build().Run();
