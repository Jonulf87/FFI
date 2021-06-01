using FFI.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFI.BLL.DTO
{
    public class RegisterVehicleDTO
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public VehicleType Type { get; set; }
        [Required]
        public double InitialLatitude { get; set; }
        [Required]
        public double InitialLongitude { get; set; }
    }
}
