
using Microsoft.EntityFrameworkCore;

IConfigurationRoot Configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();


var build = CreateHostBuilder(args).Build();
build.Run();

IHostBuilder CreateHostBuilder(string[] args)
{
    var builder = Host.CreateDefaultBuilder(args);

    return builder
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
            webBuilder.UseConfiguration(Configuration);
            // Leaving the web root directory unspecified defaults to this same value ("wwwroot").
            // However, just letting it default means that if the directory doesn't exist
            // _at startup time_,  the Static Files middleware won't serve any files at all! By
            // specifying it, the directory will be created on startup if necessary and files
            // that appear in it later will be served. This is useful during local development
            // because webpack can be putting new files in there.
            webBuilder.UseWebRoot("wwwroot");
        });
}
