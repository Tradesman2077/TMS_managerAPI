using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedData.Response
{
    public class TonnagePerTruckPerDayResult
    {
        public int TruckId { get; set; }
        public DateTime Date { get; set; }
        public decimal NettTonnage { get; set; }
        public decimal GrossTonnage { get; set; }
    }
}
