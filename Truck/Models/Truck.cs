using System;
using System.Collections.Generic;

namespace TruckAPI.Models
{
    public partial class Truck
    {
        public Truck()
        {
            Telemetries = new HashSet<Telemetry>();
        }

        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public DateTime PurchaseDate { get; set; }

        public virtual ICollection<Telemetry> Telemetries { get; set; }
    }
}
