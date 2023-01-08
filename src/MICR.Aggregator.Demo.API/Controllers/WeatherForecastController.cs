using MICR.Services.User.API;
using Microsoft.AspNetCore.Mvc;

namespace MICR.Aggregator.Demo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly UserService.UserServiceClient _userServiceClient;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, UserService.UserServiceClient userServiceClient)
        {
            _logger = logger;
            _userServiceClient = userServiceClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetName([FromQuery] string name)
        {
            _logger.LogInformation("Name -> {name}", name);
            var response = await _userServiceClient.SayHelloAsync(new HelloRequest()
            {
                Name = name
            });
            _logger.LogInformation("Message-> {message}", response.Message);

            Response.StatusCode = 200;
            return new ObjectResult(new { Name = response.Message });
        }
    }
}