using ISServiceDeskApi.Configurations;

namespace ISServiceDeskApi;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        //почему так лучше
        //так как к примеру у тебя может менятся база данных, и чтобы не лазить сбда и искать или менять 
        //ты меняшь в методе выше - и оно автоматом у тбя тут сработает
        //чище остается startup класс и код
        // там в методе делаешь уже все что тебе надо
        services.AddDatabase(); // ----->
        services.AddApiConfiguration(_configuration);
        services.AddSwagger();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSwagger();

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

        app.ApplicationServices
            .GetRequiredService<ILogger<Startup>>()
            .LogInformation("✅ API started at http://localhost:5000");
    }
}