using Microsoft.AspNetCore.Mvc;
using Prestamos.Models.DTO;
using Prestamos.Services.Repositories;

namespace Prestamos.Api.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController:ControllerBase
    {
        private readonly IUsuarioRepository _usuarioService;

        public UsuarioController(IUsuarioRepository usuarioService)
        {
            _usuarioService = usuarioService;
        }
        [HttpGet("GetUsuarios")]
        public async Task<List<UsuarioDTO>> GetUsuarios(int dni)
        {
            return await Task.Run(() => _usuarioService.GetUsuarios(dni));
        }
        [HttpPut("EditUsuario")]
        public async Task<bool> EditUsuario(UsuarioEditDTO usuario)
        {
            return await Task.Run(()=>_usuarioService.EditUsuario(usuario));
        }
        [HttpDelete("DeleteUsuario")]
        public async Task<bool> DeleteUsuario(int dni)
        {
            return await Task.Run(()=>_usuarioService.DeleteUsuario(dni));
        }
    }
}
