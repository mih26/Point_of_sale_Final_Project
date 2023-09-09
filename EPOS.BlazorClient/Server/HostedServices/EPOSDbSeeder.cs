using Microsoft.Extensions.DependencyInjection;

namespace EPOS.BlazorClient.Server.HostedServices
{
    public class EPOSDbSeeder : IHostedService
    {
        private readonly IServiceProvider serviceProvider;
        public EPOSDbSeeder(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = serviceProvider.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<EPOSDbInitializer>();
            await seeder.SeedAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
