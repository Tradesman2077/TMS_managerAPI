namespace TMS_managerAPI.Models
{
    public class Haulier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Truck> TruckList { get; set; }
    }
}
