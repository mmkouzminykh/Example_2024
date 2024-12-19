using DeliveryOrders.Infrastructure;
using Microsoft.Extensions.Options;

namespace DeliveryOrders.Api;

public class SettingsSetup : IConfigureOptions<Settings>
{
    private readonly IConfiguration _configuration;

    public SettingsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(Settings options)
    {
        options.ConnectionString = _configuration["CONNECTION_STRING"];

    }
}