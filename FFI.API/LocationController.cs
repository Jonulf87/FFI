using FFI.BLL;
using FFI.BLL.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFI.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly LocationService _locationService;

        public LocationController(LocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<VehicleLocationDTO>>> GetAllVehicleLocationsAsync()
        {
            return Ok(await _locationService.GetAllVehicleLocationsAsync());
        }

        [HttpPut]
        public async Task<ActionResult> SetVehicleLocationAsync([FromBody] SetVehicleLocationDTO locationData)
        {
            await _locationService.SetVehicleLocationAsync(locationData);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<int>> RegisterVehicleAsync([FromBody] RegisterVehicleDTO vehicleData)
        {
            return Ok(await _locationService.RegisterVehicleAsync(vehicleData));
        }
    }
}
