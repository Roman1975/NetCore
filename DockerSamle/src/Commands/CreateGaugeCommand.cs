using System;
using System.Collections.Generic;

namespace GaugeCommand.Commands
{
    public class CreateGaugeCommand
    {
        public Guid MeterId { get; set; }

        /// <summary>
        /// meter scale values
        /// </summary>
        public IEnumerable<ScaleValue> Scales { get; set; }
    }

    public class ScaleValue
    {
        public byte Scale { get; set; }
        public decimal Value { get; set; }
    }
}