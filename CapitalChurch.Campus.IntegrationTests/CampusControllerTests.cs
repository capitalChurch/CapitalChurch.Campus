using System.Collections.Generic;
using System.Threading.Tasks;
using Capital.Shared.Extensions;
using CapitalChurch.Campus.Domain.Model;
using CapitalChurch.Campus.IntegrationTests.Base;
using NUnit.Framework;
using Shouldly;

namespace CapitalChurch.Campus.IntegrationTests
{
    public class CampusControllerTests : BaseControllerTests
    {
        [Test]
        public async Task ListAllCampisTest()
        {
            var url = "/v1/campus";
            var result = await this._client.Get<List<Campi>>(url);

            result.Count.ShouldBePositive();
            result.ForEach(x =>
            {
                x.Id.ShouldBePositive();
                x.Name.ShouldNotBeNullOrEmpty();
                x.Minister.ShouldNotBeNullOrEmpty();
            });
        }
    }
}