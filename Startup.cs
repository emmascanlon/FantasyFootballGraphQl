using System.Data.SqlClient;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
public class Startup
{
   public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        });

    services.AddScoped<Mutation>();
    services.AddScoped<Query>();
    services.AddScoped<LeagueDbContext>();

     services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

         services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
        });

    services.AddDbContext<LeagueDbContext>(options => options.UseSqlServer("Server=localhost,1433;Database=GraphQLDemo;Integrated Security=true;TrustServerCertificate=true").LogTo(Console.WriteLine));

    }

     public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
     {
        app.UseCors();
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGraphQL();
        });
     }

}