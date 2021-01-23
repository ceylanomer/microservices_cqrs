using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Customer.Core.Repositories;
using Customer.Core.Repositories.Base;
using Customer.Infrastructure.Data;
using Customer.Infrastructure.Repositories;
using Customer.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Customer.Application.Handlers;
using MediatR;
using Microsoft.OpenApi.Models;

namespace Customer.API
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

            services.AddDbContext<CustomerContext>(c =>

                c.UseNpgsql(Configuration.GetConnectionString("CustomerConnection")));

            //services.AddEntityFrameworkNpgsql().AddDbContext<DbContext>(options =>
            //    options.UseNpgsql(Configuration.GetConnectionString("CustomerConnection")));

            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
            services.AddScoped(typeof(ICustomerRepository), typeof(CustomerRepository));
            //services.AddTransient<ICustomerRepository, CustomerRepository>();

            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(typeof(CreateCustomerHandler).GetTypeInfo().Assembly);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Customer API", Version = "v1" });
            });

            //services.AddSingleton<IRabbitMQConnection>(
            //    sp =>
            //    {
            //        var factory = new ConnectionFactory()
            //        {
            //            HostName = Configuration["EventBus:HostName"]
            //        };

            //        if (!string.IsNullOrEmpty(Configuration["EventBus:UserName"]))
            //        {
            //            factory.UserName = Configuration["EventBus:UserName"];
            //        }

            //        if (!string.IsNullOrEmpty(Configuration["EventBus:Password"]))
            //        {
            //            factory.Password = Configuration["EventBus:Password"];
            //        }

            //        return new RabbitMQConnection(factory);
            //    }
            //);

            //services.AddSingleton<EventBusRabbitMQConsumer>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CustomerContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            context.Database.EnsureCreated();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseRabbitListener();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer API V1");
            });
        }
    }
}
