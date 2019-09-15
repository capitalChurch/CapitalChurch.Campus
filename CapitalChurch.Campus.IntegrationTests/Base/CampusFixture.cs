using CapitalChurch.Campus.WebApi;
using Microsoft.AspNetCore.Mvc.Testing;

namespace CapitalChurch.Campus.IntegrationTests.Base
{
    public class CampusFixture : WebApplicationFactory<Startup>
    {
    }
}