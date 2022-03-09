using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Persistence;
using Xunit;

namespace ToDoList.Api.IntegrationTest.Base
{
    public class CustomWebApplicationFactory<TStartup> : Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory<TStartup> where TStartup: class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddDbContext<AppDbContext>(options =>
                {
                    options.UseInMemoryDatabase("TestDb");
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var context = scopedServices.GetRequiredService<AppDbContext>();
                    var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                    context.Database.EnsureCreated();

                    try
                    {
                        Utilities.InitializeDb(context);

                    }
                    catch(Exception ex)
                    {
                        logger.LogError(ex, $"An error occured while seeding the database with test data - {ex.Message}");
                    }

                };

            });

            
            base.ConfigureWebHost(builder);
        }

        public HttpClient GetAnonymoustClient()
        {
            return CreateClient();
        }
    }
}
