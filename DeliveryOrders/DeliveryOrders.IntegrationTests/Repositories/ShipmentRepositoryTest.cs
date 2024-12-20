using DeliveryOrders.Infrastructure.Adapters.Postgres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testcontainers.PostgreSql;

namespace DeliveryOrders.IntegrationTests.Repositories
{
    internal class ShipmentRepositoryTest
    {
        private readonly PostgreSqlContainer _postgreSqlContainer = new PostgreSqlBuilder()
        .WithImage("postgres:14.7")
        .WithDatabase("good")
        .WithUsername("username")
        .WithPassword("secret")
        .WithCleanUp(true)
        .Build();

        private ApplicationDbContext _context;
    }
}
