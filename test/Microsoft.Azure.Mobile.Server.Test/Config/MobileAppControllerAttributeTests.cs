// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Microsoft.Azure.Mobile.Server.Cache;
using Microsoft.Azure.Mobile.Server.Serialization;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TestUtilities;
using Xunit;

namespace Microsoft.Azure.Mobile.Server.Config
{
    public class MobileAppControllerAttributeTests
    {
        [Fact]
        public void Initialize_CallsRegisteredConfigProvider()
        {
            // Arrange
            var config = new HttpConfiguration();
            var mockConfigProvider = new Mock<IMobileAppControllerConfigProvider>();
            config.SetMobileAppControllerConfigProvider(mockConfigProvider.Object);
            var attr = new MobileAppControllerAttribute();
            var settings = new HttpControllerSettings(config);
            var descriptor = new HttpControllerDescriptor()
            {
                Configuration = config
            };

            // Act
            attr.Initialize(settings, descriptor);

            // Assert
            mockConfigProvider.Verify(m => m.Configure(settings, descriptor), Times.Once);
        }
    }
}