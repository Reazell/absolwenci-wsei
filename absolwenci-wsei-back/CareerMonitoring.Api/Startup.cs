﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CareerMonitoring.Api.ActionFilters;
using CareerMonitoring.Core.Domains.ImportFile;
using CareerMonitoring.Infrastructure.Commands.Account;
using CareerMonitoring.Infrastructure.Commands.CareerOffice;
using CareerMonitoring.Infrastructure.Commands.Email;
using CareerMonitoring.Infrastructure.Commands.ImportFile;
using CareerMonitoring.Infrastructure.Commands.User;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Extension.JWT;
using CareerMonitoring.Infrastructure.Extension.JWT.Interfaces;
using CareerMonitoring.Infrastructure.Extensions.AutoMapper;
using CareerMonitoring.Infrastructure.Extensions.Email;
using CareerMonitoring.Infrastructure.Extensions.Email.Interfaces;
using CareerMonitoring.Infrastructure.Extensions.Factories;
using CareerMonitoring.Infrastructure.Extensions.Factories.Interfaces;
using CareerMonitoring.Infrastructure.Extensions.URL;
using CareerMonitoring.Infrastructure.Repositories;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services;
using CareerMonitoring.Infrastructure.Services.Interfaces;
using CareerMonitoring.Infrastructure.Validators.Account;
using CareerMonitoring.Infrastructure.Validators.CareerOffice;
using CareerMonitoring.Infrastructure.Validators.Email;
using CareerMonitoring.Infrastructure.Validators.ImportFile;
using CareerMonitoring.Infrastructure.Validators.User;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using static CareerMonitoring.Infrastructure.Extension.Exception.ExceptionsHelper;
using CareerMonitoring.Infrastructure.Extensions.JWT;
using NLog.Extensions.Logging;
using NLog.Web;
using CareerMonitoring.Infrastructure.Extensions.Aggregate.Interfaces;
using CareerMonitoring.Infrastructure.Extensions.Aggregate;

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
                .AddJsonOptions (options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            #region DbContextAndSettings

            services.AddCors ();
            services.AddDbContext<CareerMonitoringContext> (options =>
                options.UseSqlServer (Configuration.GetConnectionString ("CareerMonitoringDatabase"),
                    b => b.MigrationsAssembly ("CareerMonitoring.Api")));
            var key = Encoding.ASCII.GetBytes (Configuration.GetSection ("JWTSettings:Key").Value);
            services.AddAuthentication (JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer (options => {
                    options.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey (key),
                    ValidateIssuer = false,
                    ValidateAudience = false

                    };
                });
            services.AddSingleton<IJWTSettings> (Configuration.GetSection ("JWTSettings").Get<JWTSettings> ());
            services.AddSingleton<IEmailConfiguration> (Configuration.GetSection ("EmailConfiguration")
                .Get<EmailConfiguration> ());
            services.AddSingleton<IURLSettings> (Configuration.GetSection ("Url").Get<URLSettings> ());
            services.AddSingleton (AutoMapperConfig.Initialize ());
            services.AddAuthorization (options =>
                options.AddPolicy ("careerOffice", policy => policy.RequireRole ("careerOffice")));
            services.AddAuthorization (options =>
                options.AddPolicy ("master", policy => policy.RequireRole ("master")));
            services.AddAuthorization (options =>
                options.AddPolicy ("unregisteredUser", policy => policy.RequireRole ("unregisteredUser")));

            #endregion
            #region Repositories

            services.AddScoped<IAccountRepository, AccountRepository> ();
            services.AddScoped<ICareerOfficeRepository, CareerOfficeRepository> ();
            services.AddScoped<IMasterRepository, MasterRepository> ();
            services.AddScoped<ISurveyRepository, SurveyRepository> ();
            services.AddScoped<IQuestionRepository, QuestionRepository> ();
            services.AddScoped<IFieldDataRepository, FieldDataRepository> ();
            services.AddScoped<IChoiceOptionRepository, ChoiceOptionRepository> ();
            services.AddScoped<IRowRepository, RowRepository> ();
            services.AddScoped<ISurveyTemplateRepository, SurveyTemplateRepository> ();
            services.AddScoped<IQuestionTemplateRepository, QuestionTemplateRepository> ();
            services.AddScoped<IFieldDataTemplateRepository, FieldDataTemplateRepository> ();
            services.AddScoped<IChoiceOptionTemplateRepository, ChoiceOptionTemplateRepository> ();
            services.AddScoped<IRowTemplateRepository, RowTemplateRepository> ();
            services.AddScoped<ISurveyAnswerRepository, SurveyAnswerRepository> ();
            services.AddScoped<IQuestionAnswerRepository, QuestionAnswerRepository> ();
            services.AddScoped<IFieldDataAnswerRepository, FieldDataAnswerRepository> ();
            services.AddScoped<IChoiceOptionAnswerRepository, ChoiceOptionAnswerRepository> ();
            services.AddScoped<IRowAnswerRepository, RowAnswerRepository> ();
            services.AddScoped<IRowChoiceOptionAnswerRepository, RowChoiceOptionAnswerRepository> ();
            services.AddScoped<ISurveyReportRepository, SurveyReportRepository> ();
            services.AddScoped<IQuestionReportRepository, QuestionReportRepository> ();
            services.AddScoped<IDataSetRepository, DataSetRepository> ();
            services.AddScoped<ISurveyUserIdentifierRepository, SurveyUserIdentifierRepository>();
            services.AddScoped<IUnregisteredUserRepository, UnregisteredUserRepository> ();

            #endregion
            #region Services

            services.AddScoped<IAccountService, AccountService> ();
            services.AddScoped<IAuthService, AuthService> ();
            services.AddScoped<ICareerOfficeService, CareerOfficeService> ();
            services.AddScoped<IMasterService, MasterService> ();
            services.AddScoped<ISurveyService, SurveyService> ();
            services.AddScoped<ISurveyTemplateService, SurveyTemplateService> ();
            services.AddScoped<ISurveyAnswerService, SurveyAnswerService> ();
            services.AddScoped<ISurveyReportService, SurveyReportService> ();
            services.AddScoped<ISurveyUserIdentifierService, SurveyUserIdentifierService> ();
            services.AddScoped<IUnregisteredUserService, UnregisteredUserService> ();

            #endregion
            #region Validations

            services.AddTransient<IValidator<SignIn>, SignInValidator> ();
            services.AddTransient<IValidator<RegisterCareerOffice>, RegisterCareerOfficeValidator> ();
            services.AddTransient<IValidator<ChangePassword>, ChangePasswordValidator> ();
            services.AddTransient<IValidator<RestorePassword>, RestorePasswordValidator> ();
            services.AddTransient<IValidator<ChangePasswordByRestoringPassword>, ChangePasswordByRestoringPasswordValidator> ();
            services.AddTransient<IValidator<EmailToSend>, EmailToSendValidator> ();
            services.AddTransient<IValidator<AddUnregisteredUser>, AddUnregisteredUserValidator> ();
            services.AddTransient<IValidator<UpdateUnregisteredUser>, UpdateUnregisteredUserValidator> ();

            #endregion
            #region Factories

            services.AddScoped<IEmailFactory, EmailFactory> ();
            services.AddScoped<IAccountEmailFactory, AccountEmailFactory> ();
            services.AddScoped<ISurveyEmailFactory, SurveyEmailFactory> ();
            services.AddScoped<IImportFileAggregate, ImportFileAggregate> ();
            services.AddScoped<IEmailContent, EmailContent> ();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseExceptionHandler (builder => {
                    builder.Run (async context => {
                        context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                        var error = context.Features.Get<IExceptionHandlerFeature> ();
                        if (error != null) {
                            context.Response.AddApplicationError (error.Error.Message);
                            await context.Response.WriteAsync (error.Error.Message);
                        }
                    });
                });
            }

            app.UseCors (x => x.AllowAnyHeader ().AllowAnyMethod ().AllowAnyOrigin ().AllowCredentials ());
            app.UseAuthentication ();
            app.UseMvc ();
        }
    }
}