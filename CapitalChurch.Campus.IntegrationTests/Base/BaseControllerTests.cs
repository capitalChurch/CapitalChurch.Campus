using System.Net.Http;
using NUnit.Framework;

namespace CapitalChurch.Campus.IntegrationTests.Base
{
    [TestFixture]
    public class BaseControllerTests
    {

        private CampusFixture _factory;
        protected HttpClient _client;
        
        [OneTimeSetUp]
        public void SetupTests()
        {
            _factory = new CampusFixture();
            _client = _factory.CreateClient();
        }
    }
}