using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedData.Models
{
    public class Assignment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Driver")]
        public int DriverId { get; set; }

        [ForeignKey("Haulier")]
        public int HaulierId { get; set; }

        [ForeignKey("Truck")]
        public int TruckId { get; set; }

        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public decimal TareWeight { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NettWeight { get; set; }
        public Truck Truck { get; set; }
        public Haulier Haulier { get; set; }
        public Driver Driver { get; set; }

    }
}
