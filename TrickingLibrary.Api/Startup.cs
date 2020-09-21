using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TrickingLibrary.Api
{
	public class Startup
	{
		private const string AllCars = "All";

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			services.AddSingleton<TrickyStore>();
			
			services.AddCors(options => 
				options.AddPolicy(AllCars, build =>
					build.AllowAnyHeader()
						.AllowAnyOrigin()
						.AllowAnyMethod()));
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseCors(AllCars);

			app.UseRouting();
			
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapDefaultControllerRoute();
			});
		}
	}
}
