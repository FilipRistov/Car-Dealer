using CarDealer.Domain.CarManufacturer;
using CarDealer.Exceptions;
using CarDealer.Models;
using CarDealer.Service.Abstraction;
using CarDealer.Service.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CarDealer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "User")]
    public class CarManufacturerController : Controller
    {
        private readonly ICarManufacturerService _carManufacturerService;
        private readonly ILogger<CarController> _logger;
        public CarManufacturerController(ICarManufacturerService carManufacturerService, ILogger<CarController> logger)
        {
            _carManufacturerService = carManufacturerService;
            _logger = logger;
        }

        [HttpGet("GetAllMake")]
        public IActionResult GetAllCarManufacturers()
        {
            try
            {
                return Ok(_carManufacturerService.GetAllCarManufacturers());
            }
            catch(Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return BadRequest("Something went wrong. Please try again.");
            }
        }
        [HttpGet("GetAllMakeById")]
        public IActionResult GetAllCarManufacturersById(int id)
        {
            try
            {
                return Ok(_carManufacturerService.GetCarManufacturerId(id));
            }
            catch (CarException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return BadRequest("Something went wrong.");
            }

        }
        [HttpPost, Authorize(Policy = "Admin")]
        public IActionResult AddCarManufacturer(AddCarManufacturer carManufacturer)
        {
            return Ok(_carManufacturerService.AddCarManufacturer(carManufacturer));
        }
        [HttpDelete, Authorize(Policy = "Admin")]
        public IActionResult DeleteCar(int id)
        {
            try
            {
                return Ok(_carManufacturerService.DeleteCarManufacturer(id));
            }
            catch (CarException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return BadRequest("Something went wrong. Please try again.");
            }
        }
    }
}
