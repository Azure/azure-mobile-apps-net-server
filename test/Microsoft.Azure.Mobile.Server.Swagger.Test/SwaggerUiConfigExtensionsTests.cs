// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin.Testing;
using Swashbuckle.Application;
using Xunit;

namespace Microsoft.Azure.Mobile.Server.Swagger.Test
{
    public class SwaggerUiConfigExtensionsTests
    {
        [Fact]
        public async Task SwaggerUiDocs()
        {
            // Arrange
            HttpConfiguration config = new HttpConfiguration();
            TestServer server = SwashbuckleHelper.CreateSwaggerServer(config, null, c =>
            {
                c.MobileAppUi(config);
            });

            string o2cExpected = GetResourceString("Microsoft.Azure.Mobile.Server.Swagger.o2c.html");
            // string oauthExpected = GetResourceString("Microsoft.Azure.Mobile.Server.Swagger.swagger-oauth.js");

            // Act
            var o2cResponse = await server.HttpClient.GetAsync("http://localhost/swagger/ui/o2c-html");
            // var oauthResponse = await server.HttpClient.GetAsync("http://localhost/swagger/ui/lib/swagger-oauth-js");

            string o2c = await o2cResponse.Content.ReadAsStringAsync();
            // string oauth = await oauthResponse.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(o2cExpected, o2c);
            // Assert.Equal(oauthExpected, oauth);
            Assert.Contains(typeof(SwaggerUiSecurityFilter), config.MessageHandlers.Select(h => h.GetType()));
        }

        [SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times", Justification = "This code is resilient to this scenario")]
        private static string GetResourceString(string resourceName)
        {
            string resourceText;

            using (Stream stream = typeof(SwaggerUiConfigExtensions).Assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    resourceText = reader.ReadToEnd();
                }
            }

            return resourceText;
        }
    }
}