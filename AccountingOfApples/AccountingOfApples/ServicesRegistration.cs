using BLL.Services;
using DAL.Data;
using DAL.Repositories;
using DAL.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;
namespace AccountingOfApples
{
    public static class ServicesRegistration
    {
        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

        }
    }
}


