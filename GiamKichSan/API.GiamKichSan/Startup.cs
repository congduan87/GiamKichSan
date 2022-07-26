using API.GiamKichSan.Data;
using API.GiamKichSan.SignalR;
using API.GiamKichSan.UploadFile;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.GiamKichSan
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
			services.AddControllers();
			services.AddDbContext<GKSDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("GKSDbContext")));
			services.Configure<FTPModel>(Configuration.GetSection("FTPUpload"));
			services.AddSignalR(options => { options.KeepAliveInterval = System.TimeSpan.FromSeconds(5); }).AddMessagePackProtocol();
			services.AddCors(options =>
			{
				options.AddPolicy(name: "AllowOrigin",
					builder =>
					{
						builder.WithOrigins("http://localhost:37542", "http://localhost:4200")
											.AllowAnyHeader()
											.AllowAnyMethod();
					});
			});
			services.AddSignalR();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "API.GiamKichSan", Version = "v1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API.GiamKichSan v1"));
			}

			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseCors(builder =>
			{
				builder.WithOrigins("http://localhost:37542")
					.AllowAnyHeader()
					.WithMethods("GET")
					.AllowCredentials();
			});
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapHub<SignalrHub>("/signalr/hub");
				endpoints.MapHub<SignalRMesage>("/signalr/message");
				endpoints.MapControllers();
			});
			app.UseCors("AllowOrigin");
		}
	}
}
