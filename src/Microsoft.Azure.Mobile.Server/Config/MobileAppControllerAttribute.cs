// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Diagnostics.CodeAnalysis;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Microsoft.Azure.Mobile.Server.Config
{
    /// <summary>
    /// Specifies that this controller is for use by an Azure Mobile App client. Specific settings
    /// are applied to ensure the controller interacts correctly with the client. To customize these settings,
    /// register an <see cref="IMobileAppControllerConfigProvider"/> with the current <see cref="HttpConfiguration"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    [SuppressMessage("Microsoft.Performance", "CA1813:AvoidUnsealedAttributes", Justification = "We want to derive from this.")]
    public class MobileAppControllerAttribute : MobileAppActionFilterAttribute, IControllerConfiguration
    {
        /// <inheritdoc />
        public virtual void Initialize(HttpControllerSettings controllerSettings, HttpControllerDescriptor controllerDescriptor)
        {
            if (controllerDescriptor == null)
            {
                throw new ArgumentNullException("controllerDescriptor");
            }

            IMobileAppControllerConfigProvider configurationProvider = controllerDescriptor.Configuration.GetMobileAppControllerConfigProvider();
            configurationProvider.Configure(controllerSettings, controllerDescriptor);
        }
    }
}