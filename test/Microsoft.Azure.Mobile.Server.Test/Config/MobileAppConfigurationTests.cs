// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Moq;
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
            var typeList = new[]
            {
                typeof(Mobile1Controller),
                typeof(Mobile2Controller),
                typeof(Mobile3Controller)
            };

            HttpConfiguration config = new HttpConfiguration();
            SetupMockControllerList(config, typeList);

            // Act
            new MobileAppConfiguration()
                .MapApiControllers()
                .ApplyTo(config);

            // Assert
            Assert.Single(config.Routes);

            var route = config.Routes[0];
            Assert.Equal("api/{controller}/{id}", route.RouteTemplate);
            Assert.Equal(1, route.Constraints.Count);
            var constraint = route.Constraints["controller"] as SetRouteConstraint<string>;
            Assert.NotNull(constraint);
            Assert.False(constraint.Excluded);
            Assert.Equal(new[] { "Mobile1", "Mobile2", "Mobile3" }, constraint.Set);
        }

        [Fact]
        public void MapApiControllers_AppliesControllerExclusions()
        {
            // Arrange
            var typeList = new[]
            {
                typeof(Mobile1Controller),
                typeof(Mobile2Controller),
                typeof(Mobile3Controller)
            };

            HttpConfiguration config = new HttpConfiguration();
            SetupMockControllerList(config, typeList);

            // Act
            var mobileAppConfig = new MobileAppConfiguration()
                .MapApiControllers();

            mobileAppConfig.AddBaseRouteExclusion("Mobile2");
            // verify comparisons are case-insensitive
            mobileAppConfig.AddBaseRouteExclusion("MOBILE3");
            mobileAppConfig.ApplyTo(config);

            // Assert
            Assert.Single(config.Routes);

            var route = config.Routes[0];
            Assert.Equal("api/{controller}/{id}", route.RouteTemplate);
            Assert.Equal(1, route.Constraints.Count);
            var constraint = route.Constraints["controller"] as SetRouteConstraint<string>;
            Assert.NotNull(constraint);
            Assert.False(constraint.Excluded);
            Assert.Equal(new[] { "Mobile1" }, constraint.Set);
        }

        [Fact]
        public void AddBaseRouteExclusion_DoesNotThrow_IfDuplicateItemAdded()
        {
            // Act
            var mobileAppConfig = new MobileAppConfiguration();
            mobileAppConfig.AddBaseRouteExclusion("MobileApp");
            mobileAppConfig.AddBaseRouteExclusion("MobileApp");
            mobileAppConfig.AddBaseRouteExclusion("mobileapp");

            // Assert
            Assert.Single(mobileAppConfig.BaseRouteConstraints);

            // verify that comparisons are case-insensitive
            Assert.Contains("MobileApp", mobileAppConfig.BaseRouteConstraints);
            Assert.Contains("mobileapp", mobileAppConfig.BaseRouteConstraints);
            Assert.Contains("MOBILEAPP", mobileAppConfig.BaseRouteConstraints);
        }

        private static void SetupMockControllerList(HttpConfiguration config, ICollection<Type> controllerTypesToReturn)
        {
            IAssembliesResolver assemblyResolver = config.Services.GetAssembliesResolver();
            Mock<IHttpControllerTypeResolver> typeResolverMock = new Mock<IHttpControllerTypeResolver>();
            typeResolverMock.Setup(m => m.GetControllerTypes(assemblyResolver)).Returns(controllerTypesToReturn);

            config.Services.Replace(typeof(IHttpControllerTypeResolver), typeResolverMock.Object);
        }

        private class MyProvider : IMobileAppControllerConfigProvider
        {
            public void Configure(HttpControllerSettings controllerSettings, HttpControllerDescriptor controllerDescriptor)
            {
            }
        }

        [MobileAppController]
        private class Mobile1Controller : ApiController
        {
        }

        [MobileAppController]
        private class Mobile2Controller : ApiController
        {
        }

        [MobileAppController]
        private class Mobile3Controller : ApiController
        {
        }
    }
}