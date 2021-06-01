using FFI.BLL.DTO;
using FFI.DAL;
using FFI.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFI.BLL
{
    public class LocationService
    {
        private readonly FFIContext _ffiContext;

        public LocationService(FFIContext ffiContext)
        {
            _ffiContext = ffiContext;
        }

        public async Task<List<VehicleLocationDTO>> GetAllVehicleLocationsAsync()
        {
            return await _ffiContext.Vehicles
                .Select(a => new VehicleLocationDTO
                {
                    Id = a.Id,
                    Description = a.Description,
                    Latitude = a.Location.Latitude,
                    Longitude = a.Location.Longitude,
                    Type = a.Type
                }).ToListAsync();
        }

        public async Task SetVehicleLocationAsync(SetVehicleLocationDTO location)
        {
            var storedVehicle = await _ffiContext.Vehicles
                .Include(a => a.Location)
                .FirstOrDefaultAsync(a => a.Id == location.Id);

            if (storedVehicle == null)
            {
                return; //Eller en exception
            }

            if (storedVehicle.Location == null)
            {
                storedVehicle.Location = new Location
                {
                    Latitude = location.Latitude,
                    Longitude = location.Longitude
                };

            }
            else
            {
                storedVehicle.Location.Latitude = location.Latitude;
                storedVehicle.Location.Longitude = location.Longitude;
            }



            await _ffiContext.SaveChangesAsync(); //Tracking sørger for vehicle blir oppdatert
        }

        public async Task<int> RegisterVehicleAsync(RegisterVehicleDTO vehicle)
        {

            var Vehicle = new Vehicle
            {
                Description = vehicle.Description,
                Type = vehicle.Type,
                Location = new Location
                {
                    Latitude = vehicle.InitialLatitude,
                    Longitude = vehicle.InitialLongitude
                }
            };

            _ffiContext.Vehicles.Add(Vehicle);
            await _ffiContext.SaveChangesAsync();
            return Vehicle.Id;
        }
    }
}
