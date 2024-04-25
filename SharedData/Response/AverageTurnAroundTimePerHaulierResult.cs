using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedData.Response
{
    public class AverageTurnAroundTimePerHaulierResult
    {
        public int HaulierId { get; set; }
        public TimeSpan AverageTurnAroundTime { get; set; }
    }
}
