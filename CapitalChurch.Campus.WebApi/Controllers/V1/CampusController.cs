using System;
using System.Collections.Generic;
using CapitalChurch.Campus.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace CapitalChurch.Campus.WebApi.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class CampusController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Campi> ListAllCampis() =>
            new List<Campi>
            {
                new Campi()
                {
                    Id = 1,
                    Name = "Sul",
                    Minister = "Gilberto Wegermann"
                },
                new Campi()
                {
                    Id = 2,
                    Name = "Norte",
                    Minister = "Thuka Wegermann"
                },
                new Campi()
                {
                    Id = 3,
                    Name = "EPNB",
                    Minister = $"Gustavo Alves"
                }
            };
    }
}