using BookRental.Api.Data;
using BookRental.Api.IntegrationTests.DataSeeding;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookRental.Api.IntegrationTests;
public class CustomWebApplicationFactory<TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var dbContext = services.SingleOrDefault(d => d.ServiceType == typeof(BookContext))!;
            services.Remove(dbContext);

            services.AddDbContext<BookContext, BookContextWithData>(options =>
            {
                options.UseInMemoryDatabase(Guid.NewGuid().ToString());
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
        });

        builder.UseEnvironment("Development");
    }
}
