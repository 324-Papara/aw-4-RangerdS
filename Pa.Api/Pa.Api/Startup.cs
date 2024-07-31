using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Pa.Data.Context;
using Pa.Data.UnitOfWork;
using FluentValidation.AspNetCore;
using AutoMapper;
using Pa.Business.MapperConfig;
using System.Reflection;
using MediatR;
using Pa.Business.Cqrs;
using Pa.Api.MiddleWares;
using FluentValidation;
using Pa.Api.Services;
using Hangfire;
using Pa.Base.Mail;
using Hangfire.SqlServer;

namespace Pa.Api;

public class Startup
{
    public IConfiguration Configuration;

    public Startup(IConfiguration configuration)
    {
        this.Configuration = configuration;
    }


    public void ConfigureServices(IServiceCollection services)
    {
        #region Json
        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            options.JsonSerializerOptions.WriteIndented = true;
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
        });
        #endregion

        #region Swagger
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pa.Api", Version = "v1" });
        });
        #endregion

        #region Fluent Validation
        services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssemblyContaining<Startup>();
        #endregion

        #region DB Connection
        var msSqlConStr = Configuration.GetConnectionString("MsSqlConStr");
        services.AddDbContext<PaMsDbContext>(options => options.UseSqlServer(msSqlConStr));
        //var postgreSqlConStr = Configuration.GetConnectionString("PostgreSqlConStr");
        //services.AddDbContext<PaPostDbContext>(options => options.UseNpgsql(postgreSqlConStr));
        #endregion

        services.Configure<SmtpSettings>(Configuration.GetSection("SmtpSettings"));
        services.AddSingleton<EmailSenderService>();
        services.AddTransient<EmailQueueService>();

        services.AddHangfire(configuration => configuration
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(Configuration.GetConnectionString("HangfireConnection")));
        services.AddHangfireServer();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Para.Api v1"));
        }

        #region MiddleWares
        app.UseMiddleware<HeartBeatMiddleWare>();
        app.UseMiddleware<ErrorHandlerMiddleware>();
        app.UseMiddleware<RequestResponseLoggingMiddleware>();
        #endregion

        app.UseHangfireDashboard();
        RecurringJob.AddOrUpdate<EmailSenderService>(service => service.ProcessEmailQueue(), "*/5 * * * * *");


        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}