using PatientInfo.Api.Extensions;
using PatientInfo.Api.Middlewares;
using PatientInfo.Application.Configurations;
using PatientInfo.Application.Interfaces;
using PatientInfo.Application.Mappings;
using PatientInfo.Application.Services;
using PatientInfo.Infrastructure.Authenticators;
using PatientInfo.Infrastructure.Data;
using PatientInfo.Infrastructure.Interfaces;
using PatientInfo.Infrastructure.Repositories;

namespace PatientInfo.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
                        
            builder.Services.Configure<ApiKeySettings>(builder.Configuration.GetSection("ApiKeySettings"));
            builder.Services.AddScoped<IPatientAuthenticator, ApiKeyAuthenticator>();

            builder.Services.AddScoped<IPatientRepository, PatientRepository>();
            builder.Services.AddScoped<IPatientMapper, PatientMapper>();
            builder.Services.AddScoped<IPatientService, PatientService>();
            builder.Services.AddScoped<IDataSeeder<Domain.Entities.Patient>, PatientSeedData>();
            builder.Services.AddScoped<IPatientAuthenticator, ApiKeyAuthenticator>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerDocumentation();
            
            var app = builder.Build();
            app.UseSwaggerDocumentation();
            app.UseMiddleware<SecurityMiddleware>();
            app.MapControllers();

            app.Run();
        }
    }
}
