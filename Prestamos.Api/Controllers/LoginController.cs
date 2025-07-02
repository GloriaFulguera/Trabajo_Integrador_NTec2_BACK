using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Prestamos.Models;
using Prestamos.Models.DTO;
using Prestamos.Services.Repositories;

namespace Prestamos.Api.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController:ControllerBase
    {
        private readonly ILoginRepository _loginService;

        public LoginController(ILoginRepository loginService)
        {
            _loginService = loginService;
        }
        [HttpGet("GetUsuarios")]
        public async Task<List<Usuario>> GetUsuarios()
        {
            return await Task.Run(() => _loginService.GetUsuarios());
        }
        [HttpPost("CreateUsuario")]
        public async Task<bool> CreateUsuario(RegisterDTO usuario)
        {
            return await Task.Run(() => _loginService.CreateUsuario(usuario));
        }
        [HttpPost("Login")]
        public async Task<LoginResultDTO> Login(LoginDTO usuario)
        {
            return await Task.Run(()=>_loginService.Login(usuario));
        }
    }
}
