using System;
using System.Collections.Generic;
using System.Text;

namespace HazırlaLogViewer
{
    public class LoggedEvent
    {
        public string Id { get; set; }
        public string EventDatetime { get; set; }
        public string Level { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
    }
}
