using InterviewTask.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTask
{
	public class Program
	{
		public static void Main(string[] args)
		{

			//CreateHostBuilder(args).Build().Run();

			var host = CreateHostBuilder(args).Build();
            //RunSeeding(host);
            //host.Run();

            if (args.Length == 1 && args[0].ToLower() == "/seed")
            {
                RunSeeding(host);
            }
            else
            {

                host.Run();
            }
        }

		private static void RunSeeding(IHost host)
        {
			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				var scopeFactory = services.GetRequiredService<IServiceScopeFactory>();

				using (var scopeFac = scopeFactory.CreateScope())
				{
					var seeder = scopeFac.ServiceProvider.GetService<ProductSeeder>();
					seeder.seed();
				}

			}
		}


		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();

				});
	}
}
