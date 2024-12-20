using DeliveryOrders.Core.Domain.Model.PickupPointAggregate;
using DeliveryOrders.Core.Domain.SharedKernel;
using DeliveryOrders.Infrastructure.Adapters.Postgres;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using Testcontainers.PostgreSql;
using Xunit;

namespace DeliveryOrders.IntegrationTests.Repositories
{
    public class PickupPointRepositoryShould: IAsyncLifetime
    {
        private readonly PostgreSqlContainer _postgreSqlContainer = new PostgreSqlBuilder()
            .WithImage("postgres:14.7")
            .WithDatabase("good")
            .WithUsername("username")
            .WithPassword("secret")
            .WithCleanUp(true)
            .Build();

        private ApplicationDbContext _context;

        public async Task InitializeAsync()
        {
            await _postgreSqlContainer.StartAsync();

            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>().UseNpgsql(
                _postgreSqlContainer.GetConnectionString(),
                sqlOptions => { sqlOptions.MigrationsAssembly("DeliveryOrders.Infrastructure"); }).Options;

            _context = new ApplicationDbContext(contextOptions);
            _context.Database.Migrate();
        }

        [Fact]
        public async void AddNewPickupPoints()
        {
            var repository = new PickupPointRepository(_context);
            var unitOfWork = new UnitOfWork(_context);

            var pickPoint = PickupPoint.Create("Основной", Address.Create(
                "Кировская область",
                "Киров",
                "Московская",
                "12").Value).Value;

            await repository.AddAsync(pickPoint, new CancellationToken());
            await unitOfWork.CommitAsync();

            var savedPoint = await repository.GetByIdAsync(pickPoint.Id, new CancellationToken());

            savedPoint.Should().NotBeNull();
            savedPoint.Should().BeEquivalentTo(pickPoint);            

        }

        public async Task DisposeAsync()
        {
            await _postgreSqlContainer?.DisposeAsync().AsTask();
        }
    }
}
