// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RouteConvention.cs" company="Retail inMotion Corp">
//    Copyright (c) Retail inMotion Corp. All rights reserved.
// </copyright>
//  <summary>
//    Defines the route convention manager.
//  </summary>
//  <Created>
//    <Author>Ahmad Gad (ahmad.gad@retailinmotion.com)</Author>
//    <DateTime>23/04/2021 12:41 PM</DateTime>
//  </Created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.WebApi.Configuration
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc.ApplicationModels;
    using Microsoft.AspNetCore.Mvc.Routing;

    /// <summary>
    ///    The route convention manager class.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@retailinmotion.com)</Author>
    ///    <DateTime>22/04/2021 04:24 PM</DateTime>
    /// </Created>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelConvention" />
    public class RouteConvention : IApplicationModelConvention
    {
        #region Private Fields

        /// <summary>
        ///    The route prefix.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@retailinmotion.com)</Author>
        ///    <DateTime>22/04/2021 04:23 PM</DateTime>
        /// </Created>
        private readonly AttributeRouteModel routePrefix;
        #endregion Private Fields

        #region Constructors

        /// <summary>
        ///    Initializes a new instance of the <see cref="RouteConvention"/> class.
        /// </summary>
        /// <param name="route">The route.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@retailinmotion.com)</Author>
        ///    <DateTime>22/04/2021 04:23 PM</DateTime>
        /// </Created>
        public RouteConvention(IRouteTemplateProvider route)
        {
            this.routePrefix = new AttributeRouteModel(route);
        }
        #endregion Constructors

        #region Public Methods

        /// <summary>
        ///    Called to apply the convention to the <see cref="T:Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel" />.
        /// </summary>
        /// <param name="application">The <see cref="T:Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel" />.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@retailinmotion.com)</Author>
        ///    <DateTime>22/04/2021 04:24 PM</DateTime>
        /// </Created>
        public void Apply(ApplicationModel application)
        {
            foreach (var selector in application.Controllers.SelectMany(c => c.Selectors))
            {
                if (selector.AttributeRouteModel != null)
                {
                    selector.AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(this.routePrefix, selector.AttributeRouteModel);
                }
                else
                {
                    selector.AttributeRouteModel = this.routePrefix;
                }
            }
        }
        #endregion Public Methods
    }
}
