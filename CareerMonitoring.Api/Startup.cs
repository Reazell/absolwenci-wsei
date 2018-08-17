using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CareerMonitoring.Api.ActionFilters;
using CareerMonitoring.Infrastructure.Commands.User;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services;
using CareerMonitoring.Infrastructure.Services.Interfaces;
using CareerMonitoring.Infrastructure.Validators.User;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CareerMonitoring.Api {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddMvc (opt => {
                    opt.Filters.Add (typeof (ValidatorActionFilter));
                }).AddFluentValidation ()
                .AddJsonOptions (options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            #region DbContextAndSettings

            services.AddCors ();
            services.AddDbContext<CareerMonitoringContext> (options =>
                options.UseSqlServer (Configuration.GetConnectionString ("CareerMonitoringDatabase"),
                    b => b.MigrationsAssembly ("CareerMonitoring.Api")));

            #endregion
            #region Repositories

            services.AddScoped<IUserRepository, UserRepository> ();

            #endregion
            #region Services 

            services.AddScoped<IAuthService, AuthService> ();
            services.AddScoped<IUserService, UserService> ();

            #endregion
            #region Validations

            services.AddTransient<IValidator<RegisterUser>, RegisterUserValidator> ();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            // else {
            //     app.UseExceptionHandler (builder => {
            //         builder.Run (async context => {
            //             context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            //             var error = context.Features.Get<IExceptionHandlerFeature> ();
            //             if (error != null) {
            //                 context.Response.AddApplicationError (error.Error.Message);
            //                 await context.Response.WriteAsync (error.Error.Message);
            //             }
            //         });
            //     });
            // }

            // using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory> ().CreateScope ()) {
            //     if (!serviceScope.ServiceProvider.GetService<CareerMonitoringContext> ().AllMigrationsApplied ()) {
            //         serviceScope.ServiceProvider.GetService<CareerMonitoringContext> ().Database.Migrate ();
            //     }
            // }

            app.UseCors (x => x.AllowAnyHeader ().AllowAnyMethod ().AllowAnyOrigin ().AllowCredentials ());
            app.UseAuthentication ();
            app.UseMvc ();
        }
    }
}