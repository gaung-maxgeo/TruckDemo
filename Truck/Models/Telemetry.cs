using System;
using System.Collections.Generic;

namespace TruckAPI.Models
{
    public partial class Telemetry
    {
        public int Id { get; set; }
        public int TruckId { get; set; }
        public int OilPressure { get; set; }
        public int Speed { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public virtual Truck Truck { get; set; }
    }
}
