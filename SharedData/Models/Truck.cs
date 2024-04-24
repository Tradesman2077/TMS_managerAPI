using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedData.Models
{
    public class Truck
    {
        [Key]
        public int Id { get; set; }
        public string Registration { get; set; }
        public decimal Capacity { get; set; }

        [ForeignKey("Haulier")]
        public int HaulierId { get; set; }

        public Haulier Haulier { get; set; }
    }
}
