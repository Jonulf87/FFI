using FFI.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFI.BLL.DTO
{
    public class VehicleLocationDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public VehicleType Type { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
