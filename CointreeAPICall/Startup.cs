using CointreeAPICall.ServicesAbstract;
using CointreeAPICall.ServicesConcrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CointreeAPICall
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

            AddDIServices(services);
            AddCorsPolicy(services);

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

            UseCorsPolicy(app);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// Groups all the DIs together - keeps ConfigureServices clean
        /// </summary>
        /// <param name="services"></param>
        public void AddDIServices(IServiceCollection services)
        {
            services.AddScoped<ICoinService, CoinService>();
            services.AddScoped<IAPICallService, APICallService>();
        }

        /// <summary>
        /// Groups all the CORS - keeps ConfigureServices clean
        /// </summary>
        /// <param name="services"></param>
        private void AddCorsPolicy(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("AllowEveryThing", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
        }

        /// <summary>
        /// Groups all the use CORS - keeps Configure clean
        /// </summary>
        /// <param name="services"></param>
        private void UseCorsPolicy(IApplicationBuilder app)
        {
            app.UseCors("AllowEveryThing");
        }
    }
}
