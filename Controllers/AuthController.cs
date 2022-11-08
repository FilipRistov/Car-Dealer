using CarDealer.Domain.Auth;
using CarDealer.Exceptions;
using CarDealer.Models;
using CarDealer.Service.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ILogger<CarController> _logger;

        public AuthController(IAuthService authService, ILogger<CarController> logger)
        {
            _authService = authService;
            _logger = logger;
        }
        [HttpPost("register")]
        public IActionResult Register(RegisterDto req)
        {
            try
            {
                return Ok(_authService.Register(req));
            }
            catch(UserException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return BadRequest("Error");
            }
        }
        [HttpPost("login")]
        public IActionResult Login(LoginDto req)
        {
            try
            {
                return Ok(_authService.Login(req));
            }
            catch (UserException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return BadRequest("Error");
            }
        }
        //[HttpGet]
        //public IActionResult GetRole(string name)
        //{
        //    return Ok(_authService.GetRole(name));
        //}
        [HttpPost("Refresh")]
        public IActionResult GetRefreshToken(string token)
        {
            try
            {
                return Ok(_authService.GetRefreshToken(token));
            }
            catch(UserException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch(Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return Unauthorized(ex.Message);
            }
        }
    }
}
