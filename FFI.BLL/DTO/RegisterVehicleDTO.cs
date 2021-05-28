using FFI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFI.BLL.DTO
{
    public class RegisterVehicleDTO
    {
        public string Description { get; set; }
        public VehicleType Type { get; set; }
        public double InitialLatitude { get; set; }
        public double InitialLongitude { get; set; }
    }
}
