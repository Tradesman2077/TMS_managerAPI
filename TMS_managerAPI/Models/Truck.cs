namespace TMS_managerAPI.Models
{
    public class Truck
    {
        public int Id { get; set; }
        public string Registration { get; set; }
        public decimal Capacity { get; set; }
        public int HaulierId { get; set; } 
        public Haulier Haulier { get; set; } 
    }
}
