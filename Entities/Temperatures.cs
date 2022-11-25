using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rd_station_api.Entities
{
    public partial class Temperatures
    {
        public long Total { get; set; }
        public bool HasMore { get; set; }
        public List<Organization> Organizations { get; set; }
    }

}