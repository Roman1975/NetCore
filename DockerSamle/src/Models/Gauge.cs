using System;
using System.Collections.Generic;
using GaugeCommand.Commands;
using Marten.Schema;

namespace GaugeCommand.Models
{
    [DocumentAlias("indicators")]
    public class Gauge
    {
        /// <summary>
        /// primary key
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// when Gauge was created
        /// </summary>
        public DateTimeOffset When { get; set; }

        /// <summary>
        /// author
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// meter identifier
        /// </summary>
        public Guid MeterId { get; set; }

        /// <summary>
        /// meter scale values
        /// </summary>
        public GaugeScaleValue[] Scales { get; set; }
    }

    [DocumentAlias("scales")]
    public class GaugeScaleValue
    {
        public byte Scale { get; set; }
        public decimal Value { get; set; }
        public bool Clean { get; set; }
    }
}