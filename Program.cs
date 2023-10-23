using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>();

builder.Services.AddPooledDbContextFactory<TeamsDbContext>(o => o.UseSqlite("Server=localhost,1433;Database=GraphQLDemo;Integrated Security=true;TrustServerCertificate=true"));

var app = builder.Build();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.MapGet("/", () => "Hello World!");

app.Run();
