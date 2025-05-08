using DevExpress.Xpo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ISServiceDeskApi.Configuration;



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
        services.AddDatabase(); // ----->
        services.AddApiConfiguration(_configuration);
        services.AddSwagger();
        
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSwaggerConfig();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

        app.ApplicationServices
            .GetRequiredService<ILogger<Startup>>()
            .LogInformation("✅ API started at http://localhost:5000");
    }

}
