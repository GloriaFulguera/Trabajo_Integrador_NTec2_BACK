using Microsoft.AspNetCore.Mvc;
using Prestamos.Models;
using Prestamos.Models.DTO;
using Prestamos.Services.Repositories;

namespace Prestamos.Api.Controllers
{
    [Route("/api/solicitud")]
    [ApiController]
    public class SolicitudController:ControllerBase
    {
        private readonly ISolicitudRepository _solicitudService;

        public SolicitudController(ISolicitudRepository solicitudService)
        {
            _solicitudService = solicitudService;
        }

        [HttpPost("CreateSolicitud")]
        public async Task<bool> CreateSolicitud(SolicitudDTO solicitud)
        {
            return await Task.Run(()=>_solicitudService.CreateSolicitud(solicitud));
        }
        [HttpGet("GetSolicitudes")]
        public async Task<List<Solicitud>> GetSolicitudes(int? dni,string? estado)
        {
            return await Task.Run(()=>_solicitudService.GetSolicitudes(dni,estado));
        }
    }
}
