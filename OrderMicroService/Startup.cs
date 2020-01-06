using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OrderMicroService.Data.Configuration;
using OrderMicroService.Data.Interface;
using OrderMicroService.Data.Repo;
using OrderMicroService.Data.Services;
using OrderMicroService;

namespace OrderMicroServiceAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddTransient<IConfiguration>((sp) => Configuration);
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddSingleton<IConnectionStringProvider, DefaultConnectionStringProvider>();
            services.AddTransient<IDatabaseConnectionProvider, DefaultDatabaseConnectionProvider>();
            services.AddSingleton<IExternalConnectionProvider,ExternalConnectionProvider>();
            services.AddScoped<IProductMicroService, ProductMicroService>();
            services.AddScoped<ICustomerMicroService, CustomerMicroService>();
            services.AddScoped<IOrderTrackerRepository, TrackerRepository>();
;            //.AddTransient<ExternalUrl>((sp) => sp.GetService<IConfiguration>().Get<ExternalUrl>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
