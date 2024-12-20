
using DeliveryOrders.Infrastructure.Adapters.Postgres;
using Microsoft.EntityFrameworkCore;


namespace DeliveryOrders.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.ConfigureOptions<SettingsSetup>();
        var connectionString = builder.Configuration["CONNECTION_STRING"];

        // Add services to the container.
        builder.Services.AddDbContext<ApplicationDbContext>((_, optionsBuilder) =>
        {
            optionsBuilder.UseNpgsql(connectionString, sqlOptions => { sqlOptions.MigrationsAssembly("DeliveryOrders.Infrastructure"); });
            optionsBuilder.EnableSensitiveDataLogging();
        });


        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
