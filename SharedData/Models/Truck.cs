using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedData.Models
{
    public class Truck
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Registration { get; set; }

        [ForeignKey("Haulier")]
        public int HaulierId { get; set; }

        public Haulier Haulier { get; set; }
    }
}
