// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExtensionMethods.cs" company="Retail inMotion Corp">
//    Copyright (c) Retail inMotion Corp. All rights reserved.
// </copyright>
//  <summary>
//    Defines all the required members to have the application configuration implementation in a typed format.
//  </summary>
//  <Created>
//    <Author>Ahmad Gad (ahmad.gad@retailinmotion.com)</Author>
//    <DateTime>23/04/2021 12:41 PM</DateTime>
//  </Created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.WebApi.Configuration
{
    using System;
    using System.IO;
    using System.Reflection;

    using Configuration;
    using Interfaces;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Routing;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
 

    /// <summary>
    ///    Defines all the helper extension methods required for the project.
    /// </summary>
    /// <Created>
    ///   <Author>Ahmad Gad (ahmad.gad@retailinmotion.com)</Author>
    ///   <DateTime>27/04/2021 01:04 PM</DateTime>
    /// </Created>
    public static class ExtensionMethods
    {
        #region Application Configuration

        /// <summary>
        ///    Get the bound/typed application configuration of the type "<see cref="IApplicationConfiguration"/>" as an instance of "<see cref="ApplicationConfiguration"/>".
        /// </summary>
        /// <param name="builder">The builder for web applications and services.</param>
        /// <remarks>
        ///    This method is essential for the WebAPI project because it will perform the following operations before returning the strongly typed appsettings as an instance of "<see cref="ApplicationConfiguration"/>":
        ///    <para>1. Register the "builder.Configuration" into the DI container for the type "<see cref="IConfiguration"/>" with singleton life cycle.</para>
        ///    <para>2. Convert the appsettings file into the strong typed class "<see cref="ApplicationConfiguration"/>".</para>
        ///    <para>3. Grab all the matching system environment variables to override what match from the appsettings.</para>
        ///    <para>4. Register the "<see cref="ApplicationConfiguration"/>" into the DI container for the type "<see cref="IApplicationConfiguration"/>" with singleton life cycle.</para>
        /// </remarks>
        /// <returns>
        ///    The application configuration of the type "<see cref="IApplicationConfiguration"/>" as an instance of "<see cref="ApplicationConfiguration"/>".
        /// </returns>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@retailinmotion.com)</Author>
        ///   <DateTime>27/04/2021 01:04 PM</DateTime>
        /// </Created>
        public static IApplicationConfiguration GetApplicationConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

            var applicationConfiguration = new ApplicationConfiguration(builder.Configuration)
            {
                HostEnvironment = new HostEnvironment
                {
                    EnvironmentName = Enum.Parse<EnvironmentName>(builder.Configuration.GetValue<string>("ASPNETCORE_ENVIRONMENT")),
                    ContentRootPath = builder.Configuration.GetValue<string>(WebHostDefaults.ContentRootKey)
                }
            };

            builder.Configuration.Bind(applicationConfiguration);
            builder.Services.AddSingleton<IApplicationConfiguration>(applicationConfiguration);
            return applicationConfiguration;
        }

        /// <summary>
        ///    Get the bound/typed application configuration of the type "<see cref="IApplicationConfiguration"/>".
        /// </summary>
        /// <param name="builder">The builder for web applications and services.</param>
        /// <typeparam name="T">Type of "<see cref="IApplicationConfiguration"/>".</typeparam>
        /// <remarks>
        ///    This method is essential for the WebAPI project because it will perform the following operations before returning the strongly typed appsettings as an instance of "<see cref="ApplicationConfiguration"/>":
        ///    <para>1. Register the "builder.Configuration" into the DI container for the type "<see cref="IConfiguration"/>" with singleton life cycle.</para>
        ///    <para>2. Convert the appsettings file into the strong typed class "<see cref="ApplicationConfiguration"/>".</para>
        ///    <para>3. Grab all the matching system environment variables to override what match from the appsettings.</para>
        ///    <para>4. Register the strong typed app settings (application configuration) into the DI container for the type "<see cref="IApplicationConfiguration"/>" with singleton life cycle.</para>
        /// </remarks>
        /// <returns>
        ///    The application configuration of the type "<see cref="IApplicationConfiguration"/>".
        /// </returns>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@retailinmotion.com)</Author>
        ///   <DateTime>27/04/2021 01:04 PM</DateTime>
        /// </Created>
        public static IApplicationConfiguration GetApplicationConfiguration<T>(this WebApplicationBuilder builder) where T : IApplicationConfiguration
        {
            var hostEnvironment = new HostEnvironment
            {
                EnvironmentName = Enum.Parse<EnvironmentName>(builder.Configuration.GetValue<string>("ASPNETCORE_ENVIRONMENT")),
                ContentRootPath = builder.Configuration.GetValue<string>(WebHostDefaults.ContentRootKey)
            };

            var applicationConfiguration = (T)Activator.CreateInstance(typeof(T), new object[] { builder.Configuration, hostEnvironment });

            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

            builder.Configuration.Bind(applicationConfiguration);
            builder.Services.AddSingleton<IApplicationConfiguration>((s) => { return applicationConfiguration; });
            return applicationConfiguration;
        }

        /// <summary>
        ///    Gets the the value with the specified key and converts it to type <c>T</c>.
        /// </summary>
        /// <typeparam name="T">The specified returned type.</typeparam>
        /// <param name="configuration">The configuration.</param>
        /// <param name="section">The section/container name where it host the specified key.</param>
        /// <param name="key">The key name.</param>
        /// <param name="defaultValue">The failover value to return if no value is found.</param>
        /// <returns>
        ///    The the value with the specified key and converts it to type <c>T</c>.
        /// </returns>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@retailinmotion.com)</Author>
        ///   <DateTime>27/04/2021 01:04 PM</DateTime>
        /// </Created>
        public static T GetValue<T>(this IConfiguration configuration, string section, string key, T defaultValue = default)
        {
            var sectionObject = configuration.GetSection(section);
            if (sectionObject.Exists() && sectionObject.GetSection(key).Exists())
            {
                return sectionObject.GetValue<T>(key, defaultValue);
            }

            return configuration.GetValue<T>(key, defaultValue);
        }
        #endregion Application Configuration

        #region Application Route

        /// <summary>
        ///    Uses the general route prefix.
        /// </summary>
        /// <param name="options">The MVC options.</param>
        /// <param name="routeAttribute">The route attribute.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@retailinmotion.com)</Author>
        ///    <DateTime>28/04/2021 02:10 PM</DateTime>
        /// </Created>
        public static void UseGeneralRoutePrefix(this MvcOptions options, IRouteTemplateProvider routeAttribute)
        {
            options.Conventions.Add(new RouteConvention(routeAttribute));
        }

        /// <summary>
        ///    Uses the general route prefix.
        /// </summary>
        /// <param name="options">The MVC Options.</param>
        /// <param name="prefix">The route prefix string.</param>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@retailinmotion.com)</Author>
        ///   <DateTime>27/04/2021 01:04 PM</DateTime>
        /// </Created>
        public static void UseGeneralRoutePrefix(this MvcOptions options, string prefix)
        {
            options.UseGeneralRoutePrefix(new RouteAttribute(prefix));
        }
        #endregion Application Route

        #region Swagger

        /// <summary>
        ///    Configures the swagger UI with the desired settings.
        /// </summary>
        /// <param name="app">The application builder.</param>
        /// <param name="hostEnvironment">The web host enviornment.</param>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@retailinmotion.com)</Author>
        ///   <DateTime>27/04/2021 01:04 PM</DateTime>
        /// </Created>
        public static void ConfigureSwaggerUI(this IApplicationBuilder app, IWebHostEnvironment hostEnvironment)
        {
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./v1/swagger.json", hostEnvironment.ApplicationName);
                c.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Example);
                c.DisplayRequestDuration();
                c.ShowCommonExtensions();
                c.ShowExtensions();
                c.DefaultModelExpandDepth(0);
                c.DefaultModelsExpandDepth(0);
            });

            app.UseSwagger();
        }

        /// <summary>
        ///    Configures the swagger.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="hostingEnvironment">The hosting environment.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@retailinmotion.com)</Author>
        ///    <DateTime>15/04/2021 04:01 PM</DateTime>
        /// </Created>
        public static void ConfigureSwagger(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            //services.AddSwaggerGenNewtonsoftSupport();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = $"{configuration["ApplicationName"]} (env. {hostingEnvironment.EnvironmentName})",
                    Version = $"{Assembly.GetExecutingAssembly().GetName().Version}"
                });

                var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
                var docFileName = Path.Combine(AppContext.BaseDirectory, $"{assemblyName}.xml");
                if (File.Exists(docFileName))
                {
                    c.IncludeXmlComments(docFileName);
                }

                c.DescribeAllParametersInCamelCase();
            });
        }
        #endregion Swagger
    }
}
