using AutoMapper;
using Core;
using Core.Dtos;
using Core.Repositories;
using Core.Services;
using DataAccess;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Data;
using Services.FluentValidasion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Mapping;

namespace WebProject
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
            services.AddControllersWithViews();

            #region DbConnection
            services.AddEntityFrameworkSqlServer().AddDbContext<DataContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("ConnectionDb"), x => x.MigrationsAssembly("DataAccess")).UseLazyLoadingProxies());
            #endregion

            #region AutoMapper
            services.AddAutoMapper(typeof(Startup));

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            #endregion

            #region Services Binding
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ILoanService, LoanService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IInvoiceService, InvoiceService>();

            #endregion

            #region FuentValidasion

            services.AddTransient<IValidator<CalculateDto>, CalculateDtoValidator>();

            #endregion

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext dataContext)
        {
            dataContext.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Loan}/{action=Index}/{id?}");
            });
        }
    }
}
