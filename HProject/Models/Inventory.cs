using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HProject.Models
{
    using System;
    using System.Collections.Generic;
    public class Inventory
    {
        public string Group { get; set; }
        public int Count { get; set; }
        public double Sum { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double Avg { get; set; }
    }
}