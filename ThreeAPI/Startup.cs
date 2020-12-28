using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeAPI.Repositories;
using ThreeAPI.Services;

namespace ThreeAPI
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddSingleton<IClock, UtcClock>();
			services.AddSingleton<IDepartmentRepository, DepartmentRepository>();
			services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
			services.AddSingleton<ISummaryRepository, SummaryRepository>();
		}


		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();//指的是controllers的route特性
			});
		}
	}
}
