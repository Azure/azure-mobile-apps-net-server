// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System.Web.Http;
using System.Web.Http.Controllers;
using Xunit;

namespace Microsoft.Azure.Mobile.Server.Config
{
    public class MobileAppConfigurationTests
    {
        [Fact]
        public void WithMobileAppControllerConfigProvider_Default_IsCorrect()
        {
            var config = new HttpConfiguration();
            new MobileAppConfiguration()
                .ApplyTo(config);

            var provider = config.GetMobileAppControllerConfigProvider();
            Assert.NotNull(provider);
            Assert.IsType<MobileAppControllerConfigProvider>(provider);
        }

        [Fact]
        public void WithMobileAppControllerConfigProvider_CanBeOverridden()
        {
            var config = new HttpConfiguration();
            var myProvider = new MyProvider();
            new MobileAppConfiguration()
                .WithMobileAppControllerConfigProvider(myProvider)
                .ApplyTo(config);

            var provider = config.GetMobileAppControllerConfigProvider();
            Assert.NotNull(provider);
            Assert.Same(myProvider, provider);
            Assert.IsType<MyProvider>(provider);
        }

        [Fact]
        public void MapApiControllers_IsFalse_ByDefault()
        {
            // Arrange
            var config = new HttpConfiguration();

            // Act
            new MobileAppConfiguration()
                .ApplyTo(config);

            // Assert
            Assert.Empty(config.Routes);
        }

        [Fact]
        public void MapApiControllers_AddsApiRoute_WithConstraint()
        {
            // Arrange
            var config = new HttpConfiguration();

            // Act
            new MobileAppConfiguration()
                .MapApiControllers()
                .ApplyTo(config);

            // Assert
            Assert.Equal(1, config.Routes.Count);

            var route = config.Routes[0];
            Assert.Equal("api/{controller}/{id}", route.RouteTemplate);
            Assert.Equal(1, route.Constraints.Count);
            var constraint = route.Constraints["controller"] as SetRouteConstraint<string>;
            Assert.NotNull(constraint);
            Assert.Equal(false, constraint.Excluded);
            Assert.Equal(config.GetMobileAppControllerNames(), constraint.Set);
        }

        private class MyProvider : IMobileAppControllerConfigProvider
        {
            public void Configure(HttpControllerSettings controllerSettings, HttpControllerDescriptor controllerDescriptor)
            {
            }
        }
    }
}