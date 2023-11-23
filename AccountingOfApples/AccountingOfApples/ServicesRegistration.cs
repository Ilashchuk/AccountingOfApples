using BLL.Services;
using DAL.Data;
using DAL.Repositories;
using DAL.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AccountingOfApples;

public static class ServicesRegistration
{
    public static void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.AddControllers().AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.Formatting = Formatting.Indented;
            options.SerializerSettings.ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy(),
            };

            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        }); 

        builder.Services.AddDbContext<AccountOfApplesContext>(options => options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAutoMapper(typeof(Program).Assembly);

        //Repositories
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        builder.Services.AddScoped<IAppleVarietyRepository, AppleVarietyRepository>();
        builder.Services.AddScoped<IAreaAppleVarietyRepository, AreaAppleVarietyRepository>();
        builder.Services.AddScoped<IAreaRepository, AreaRepository>();
        builder.Services.AddScoped<IClientRepository, ClientRepository>();
        builder.Services.AddScoped<IForJuiceRepository, ForJuiceRepository>();
        builder.Services.AddScoped<IOrderAppleVarietyRepository, OrderAppleVarietyRepository>();
        builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();

        //Servises
        builder.Services.AddScoped<IClientControlService, ClientControlService>();
        builder.Services.AddScoped<IAreaControlService, AreaControlService>();
        builder.Services.AddScoped<IOwnerControlServoce, OwnerControlService>();
        builder.Services.AddScoped<IAppleVarietyControlService, AppleVarietyControlService>();
        builder.Services.AddScoped<IForJuiceControlService, ForJuiceControlService>();
        builder.Services.AddScoped<IOrderControlService, OrderControlService>();
        builder.Services.AddScoped<IOrderAppleVarietyControlService, OrderAppleVarietyControlService>();
        builder.Services.AddScoped<IPackagingControlService, PackagingControlService>();

    }
}


