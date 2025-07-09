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
            if (string.IsNullOrWhiteSpace(solicitud.Tipo_empleo)||string.IsNullOrWhiteSpace(solicitud.Motivo)||
                string.IsNullOrWhiteSpace(solicitud.Ingresos)||string.IsNullOrWhiteSpace(solicitud.Monto))
            {
                return false;
            }
            if (solicitud.Cuotas < 1 || solicitud.Dni < 1 || solicitud.Edad < 18)
            {
                return false;
            }
            return await Task.Run(()=>_solicitudService.CreateSolicitud(solicitud));
        }
        [HttpGet("GetSolicitudes")]
        public async Task<List<Solicitud>> GetSolicitudes(int? dni,string? estado)
        {
            return await Task.Run(()=>_solicitudService.GetSolicitudes(dni,estado));
        }
        [HttpPut("EditSolicitud")]
        public async Task<bool> EditSolicitud(SolicitudDTO solicitud)
        {
            return await Task.Run(() => _solicitudService.EditSolicitud(solicitud));
        }
        [HttpDelete("DeleteSolicitud")]
        public async Task<bool> DeleteSolicitud(int id)
        {
            return await Task.Run(() => _solicitudService.DeleteSolicitud(id));
        }
    }
}
