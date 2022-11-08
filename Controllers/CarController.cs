using CarDealer.Exceptions;
using CarDealer.Service.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog.Events;
using Serilog;
using System.Data;
using CarDealer.Domain.Car;

namespace CarDealer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "User")]
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly ILogger<CarController> _logger;
        public CarController(ICarService carService, ILogger<CarController> logger)
        {
            _carService = carService;
            _logger = logger;
        }
        [HttpGet, Authorize]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_carService.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return BadRequest("Something went wrong");
            }
        }
        [HttpPost,Authorize(Policy = "Admin")]
        public IActionResult AddCar(AddCarDto car)
        {
            try
            {
                return Ok(_carService.AddCar(car));
            }
            catch (CarException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return BadRequest("Something went wrong");
            }
        }
        [HttpGet("Id")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_carService.GetCarById(id));
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
        [HttpDelete, Authorize(Policy = "Admin")]
        public IActionResult DeleteCar(int id)
        {
            try
            {
                return Ok(_carService.DeleteCar(id));
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
        [HttpPut, Authorize(Policy = "Admin")]
        public IActionResult UpdateCar( GetCarDto updatedCar)
        {
            try
            {
                return Ok(_carService.UpdateCar(updatedCar));
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
