using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFI.DAL.Models
{
    public class Location
    {
        [ForeignKey(nameof(Vehicle))]
        public int Id { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
