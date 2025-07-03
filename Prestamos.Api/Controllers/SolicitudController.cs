using Microsoft.AspNetCore.Mvc;
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
    }
}
