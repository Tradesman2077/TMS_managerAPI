using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedData.Response
{
    public class AverageTurnAroundTimePerDriverResult
    {
        public int DriverId { get; set; }
        public TimeSpan AverageTurnAroundTime { get; set; }
    }
}
