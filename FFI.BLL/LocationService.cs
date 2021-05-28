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

        public async Task<List<VehicleLocationDTO>> GetAllVehicleLocations()
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

        public async Task SetVehicleLocation(SetVehicleLocationDTO location)
        {
            var storedVehicle = await _ffiContext.Vehicles
                .FindAsync(location.Id);

            if (storedVehicle == null)
            {
                return; //Eller en exception
            }

            storedVehicle.Location = new Location
            {
                Latitude = location.Latitude,
                Longitude = location.Longitude
            };

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

            await _ffiContext.Vehicles.AddAsync(Vehicle);
            await _ffiContext.SaveChangesAsync();
            return Vehicle.Id;
        }
    }
}
