using System.ComponentModel.DataAnnotations;

namespace SharedData.Models
{
    public class Haulier
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
