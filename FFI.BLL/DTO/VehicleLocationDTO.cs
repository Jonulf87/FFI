using FFI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFI.BLL.DTO
{
    public class VehicleLocationDTO
    {
        public int Id { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public VehicleType Type { get; set; }
        public string Description { get; set; }
    }
}
