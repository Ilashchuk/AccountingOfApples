using DAL.Data;
using Microsoft.EntityFrameworkCore;
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
    }
}

