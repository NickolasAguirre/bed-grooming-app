using bed_grooming_app.application.DTOs;
using bed_grooming_app.application.UseCases.User;
using Microsoft.AspNetCore.Mvc;

namespace bed_grooming_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserUseCase  _userService;
        public UserController(ILogger<UserController> logger, IUserUseCase userUseCase)
        {
            _logger = logger;
            _userService = userUseCase;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(UserLoginDTO userLogin)
        {
            _userService.Login(userLogin);
        }
    }
}
