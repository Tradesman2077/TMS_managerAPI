using System.ComponentModel.DataAnnotations;

namespace SharedData.Models
{
    public class Driver
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LicenseNumber { get; set; }
    }
}
