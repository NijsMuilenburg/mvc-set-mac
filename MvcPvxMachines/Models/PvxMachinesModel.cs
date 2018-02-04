using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPvxMachines.Models
{
    public class PvxMachinesModel
    {
        public int PvxID { get; set; }
        public string Name { get; set; }
        public string GeoLocation { get; set; }
        public string MacAddress { get; set; }

    }
}