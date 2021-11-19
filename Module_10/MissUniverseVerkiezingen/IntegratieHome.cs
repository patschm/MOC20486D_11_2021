using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MissUniverseVerkiezingen
{
    public class IntegratieHome : IClassFixture<WebApplicationFactory<ModellenBureau.Startup>>
    {
        private WebApplicationFactory<ModellenBureau.Startup> _factory;
        public IntegratieHome(WebApplicationFactory<ModellenBureau.Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Test_Index_HalloAsync()
        {
            var client = _factory.CreateClient();
            var result = await client.GetAsync("/Home/Index");

            Assert.Equal(System.Net.HttpStatusCode.OK, result.StatusCode);
            string content = await result.Content.ReadAsStringAsync();
            Assert.Contains("<title>Hallo</title>", content);
        }
    }
}
