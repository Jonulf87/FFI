using FFI.BLL;
using FFI.BLL.DTO;
using FFI.DAL.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFI.Test
{
    public class LocationServiceTest : BaseTest
    {
        [Test]
        public async Task ShouldRegisterVehicleAsync()
        {
            var vehicle = new RegisterVehicleDTO
            {
                Description = "Big",
                InitialLatitude = 71.154,
                InitialLongitude = 15.325,
                Type = VehicleType.MBT
            };

            LocationService locationService = new LocationService(_dbContext);

            var result = await locationService.RegisterVehicleAsync(vehicle);
            Assert.AreEqual(1, result);
        }

        [Test]
        public async Task ShouldSetVehicleLoactionAsync()
        {
            var vehicle = new RegisterVehicleDTO
            {
                Description = "Big",
                InitialLatitude = 71.154,
                InitialLongitude = 15.325,
                Type = VehicleType.MBT
            };

            LocationService locationService = new LocationService(_dbContext);

            var vehicleId = await locationService.RegisterVehicleAsync(vehicle);

            var newLocation = new SetVehicleLocationDTO
            {
                Latitude = 71.555,
                Longitude = 16.035,
                Id = vehicleId
            };
            
            await locationService.SetVehicleLocationAsync(newLocation);

            var vehicleInDb = await _dbContext.Vehicles.FindAsync(vehicleId);

            Assert.AreEqual(vehicleInDb.Location.Latitude, newLocation.Latitude);
            Assert.AreEqual(vehicleInDb.Location.Longitude, newLocation.Longitude);
        }

        [Test]
        public async Task ShouldGetAllVehicleLocationsAsync()
        {
            var vehicle1 = new RegisterVehicleDTO
            {
                Description = "Small",
                InitialLatitude = 15.151,
                InitialLongitude = 14.141,
                Type = VehicleType.Sedan
            };

            var vehicle2 = new RegisterVehicleDTO
            {
                Description = "Big",
                InitialLatitude = 16.161,
                InitialLongitude = 17.171,
                Type = VehicleType.MBT
            };

            LocationService locationService = new LocationService(_dbContext);

            var vehicle1Id = await locationService.RegisterVehicleAsync(vehicle1);
            var vehicle2Id = await locationService.RegisterVehicleAsync(vehicle2);

            var vehicleList = await locationService.GetAllVehicleLocationsAsync();

            Assert.That(vehicleList.Count == 2);
        }
    }
}
