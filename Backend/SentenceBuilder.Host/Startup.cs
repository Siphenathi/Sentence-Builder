using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SentenceBuilder.Service;
using SentenceBuilder.Service.Interface;

namespace SentenceBuilder.Host
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy("default",
					builder => builder.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader());
			});
			services.AddControllers(options => options.EnableEndpointRouting = false);

			var connectionString = Configuration.GetConnectionString("SentenceBuilderConnection");
			services.AddScoped<IWordTypeRepository>(serviceProvider => new WordTypeRepository(connectionString));
			services.AddScoped<IWordRepository>(serviceProvider => new WordRepository(connectionString));
			services.AddScoped<ISentenceRepository>(serviceProvider => new SentenceRepository(connectionString));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			//app.UseAuthorization();
			app.UseCors("default");

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
			});
		}
	}
}
