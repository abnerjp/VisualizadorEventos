using System;
using System.Collections.Generic;
using System.Text;

namespace ConsumidorEventos.Domain.Model
{
    public class Event
    {
        public DateTime DateTime { get; set; }
        public string EventName { get; set; }
        public string Local { get; set; }
        public string Organization { get; set; }
        public string Contact { get; set; }
        public string Link { get; set; }
    }
}
