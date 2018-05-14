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
    [Route("api")]
    public class CommandController : Controller
    {
        IDocumentStore _store;
        public CommandController(IDocumentStore store)
        {
            _store = store;
        }
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]CreateGaugeCommand cmd)
        {
            var gauge = new Gauge{
                Id = Guid.NewGuid(),
                MeterId = cmd.MeterId,
                Author = "chatbot",
                When = DateTimeOffset.Now,
                Scales = cmd.Scales.Select(s=> new GaugeScaleValue{
                    Scale = s.Scale,
                    Value = s.Value
                }).ToArray()
            };

            using (var session = _store.LightweightSession())
            {
                session.Store(gauge);
                session.SaveChanges();
            }

            return Created($"/api/{gauge.Id}", gauge);
        }

        [HttpPost("bulk")]
        public IActionResult Bulk([FromBody]CreateGaugeCommand[] cmds)
        {
            var now = DateTimeOffset.Now;
            var gauges = cmds.Select(s =>  new Gauge{
                Id = Guid.NewGuid(),
                MeterId = s.MeterId,
                Author = "chatbot",
                When = now,
                Scales = s.Scales.Select(ss=> new GaugeScaleValue{
                    Scale = ss.Scale,
                    Value = ss.Value
                }).ToArray()
            });

            _store.BulkInsertDocuments("xxx", gauges, BulkInsertMode.OverwriteExisting, 500);

            return Created("/api", gauges.Count());
        }
    }
}