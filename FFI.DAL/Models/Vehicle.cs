using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFI.DAL.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual Location Location { get; set; }
        public VehicleType Type { get; set; }
    }

    public enum VehicleType
    {
        Ambulance = 0,
        MBT = 1,
        APC = 2,
        Sedan = 3
    }
}
