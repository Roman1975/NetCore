using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GaugeCommand.Commands;
using GaugeCommand.Models;
using Marten;
using Microsoft.AspNetCore.Mvc;

namespace GaugeCommand.Controllers
{
    /// <summary>
    /// this controller needs only for tests, it could be another microservice for pattern CQRS
    /// </summary>
    [Route("api")]
    public class GaugesController : Controller
    {
        IDocumentStore _store;
        public GaugesController(IDocumentStore store)
        {
            _store = store;
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            Gauge gauge = null;
            using (var session = _store.QuerySession())
            {
                gauge = session.Query<Gauge>()
                    .Where(x => x.Id == id)
                    .FirstOrDefault();

            }
            return Ok(gauge);
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Gauge> gauges = null;
            using (var session = _store.QuerySession())
            {
                gauges = session.Query<Gauge>().ToList();
            }
            return Ok(gauges);
        }
    }
}
