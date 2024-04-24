namespace TMS_managerAPI.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        public int TruckId { get; set; }
        public int DriverId { get; set; }
        public int HaulierId { get; set; }

        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public decimal TareWeight { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NettWeight { get; set; }

        public Truck Truck { get; set; }
        public Driver Driver { get; set; }
        public Haulier Haulier { get; set; }
    }
}
