// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Extensions.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
//  </copyright>
//  <summary>
//    Defines the public extension methods which can be consumed by the consumer libraries, APIs or applications to wrap around the library with a smoother and quicker way.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <datetime>03/07/2019 07:44 PM</datetime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.DependencyInjection
{
    using System;
    using Cache;
    using Interfaces;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    ///    A public static class which holds all the public extension methods which can be consumed by the consumer libraries, APIs or applications to wrap around the library with a smoother and quicker way.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>11/02/2020 12:41 PM</DateTime>
    /// </Created>
    public static class Extensions
    {
        #region Public Methods

        /// <summary>
        ///    Register the <c>SQL</c> <c>DAL</c> service into the dependency injection <c>(DI)</c> container with the scoped life cycle.
        /// </summary>
        /// <param name="services">The contract for a collection of service descriptors.</param>
        /// <param name="settings">The data access settings of the type "<see cref="IDataAccessSettings"/>"</param>
        /// <typeparam name="T">The implementation type of the "<see cref="ICommand"/>".</typeparam>
        /// <returns>The contract for a collection of service descriptors which is used in the WebApis DI.</returns>
        /// <remarks>The {T} type must be of the type "<see cref="ICommand"/>".</remarks>
        /// <exception cref="ArgumentNullException">The "settings" argument of the type "<see cref="IDataAccessSettings"/>" cannot be null.</exception>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>01/02/2022 09:45 PM</DateTime>
        /// </Created>
        public static IServiceCollection RegisterDevHorizonsDal<T>(this IServiceCollection services, IDataAccessSettings settings)
            where T : ICommand
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings), $"The '{nameof(RegisterDevHorizonsDal)}' failed because it doesn't expect null argument.");
            }

            if (!settings.CacheSettings.Disabled)
            {
                var memoryCache = new MemoryCache();
                services.AddSingleton<IMemoryCache, MemoryCache>();
            }

            services.AddSingleton((s) => { return settings; });
            services.AddScoped(typeof(ICommand), typeof(T));

            return services;
        }

        /// <summary>
        ///    Get the bound/typed application configuration of the type "<see cref="IApplicationConfiguration"/>".
        /// </summary>
        /// <param name="services">The contract for a collection of service descriptors.</param>
        /// <param name="configuration">The App Configuration instance of the type "<see cref="IConfiguration"/>" which represents a set of key/value application configuration properties.</param>
        /// <typeparam name="T">Type of "<see cref="IApplicationConfiguration"/>".</typeparam>
        /// <remarks>
        ///    <para>The implementation {T} class must be type of "<see cref="IApplicationConfiguration"/>" and must have a default parameterless constructor.</para>
        ///    This method is essential for the WebAPI project because it will perform the following operations before returning the strongly typed appsettings as an instance of "<see cref="ApplicationConfiguration"/>":
        ///    <para>1. Convert the appsettings file into the strong typed class of the type "<see cref="IApplicationConfiguration"/>".</para>
        ///    <para>2. Grab all the matching system environment variables to override what match from the appsettings.</para>
        ///    <para>3. Register the strong typed app settings (application configuration) into the DI container for the type "<see cref="IApplicationConfiguration"/>" with singleton life cycle.</para>
        /// </remarks>
        /// <returns>
        ///    The application configuration of the type "<see cref="IApplicationConfiguration"/>".
        /// </returns>
        /// <exception cref="MissingMethodException">Exception will be raised if the implementation {T} class does not have a default parameterless constructor.</exception>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@retailinmotion.com)</Author>
        ///   <DateTime>27/04/2021 01:04 PM</DateTime>
        /// </Created>
        public static IApplicationConfiguration GetDalAppConfig<T>(this IServiceCollection services, IConfiguration configuration)
            where T : IApplicationConfiguration
        {
            var applicationConfiguration = Activator.CreateInstance<T>();
            if (applicationConfiguration is null)
            {
                throw new InvalidOperationException($"'{nameof(GetDalAppConfig)}' failed to create an instance of the {typeof(T)}");
            }

            var typedAppConfig = applicationConfiguration;
            configuration.Bind(typedAppConfig);
            services.AddSingleton<IApplicationConfiguration>((s) => { return typedAppConfig; });
            return typedAppConfig;

        }
        #endregion Public Methods
    }
}
