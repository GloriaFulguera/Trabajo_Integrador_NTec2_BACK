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
            if (solicitud.Cuotas < 1 || solicitud.Dni < 1 || solicitud.Edad < 18 || Convert.ToDecimal(solicitud.Monto)<100000)
            {
                return false;
            }
            return await Task.Run(()=>_solicitudService.CreateSolicitud(solicitud));
        }
        [HttpGet("GetSolicitudes")]
        public async Task<List<Solicitud>> GetSolicitudes(int? dni,string? estado,int? id)
        {
            return await Task.Run(()=>_solicitudService.GetSolicitudes(dni,estado,id));
        }
        [HttpGet("GetSolicitudesAdmin")]
        public async Task<List<Solicitud>> GetSolicitudesAdmin(int dni, string? estado)
        {
            return await Task.Run(() => _solicitudService.GetSolicitudesAdmin(dni, estado));
        }
        [HttpPut("EditSolicitud")]
        public async Task<bool> EditSolicitud(SolicitudEditDTO solicitud)
        {
            return await Task.Run(() => _solicitudService.EditSolicitud(solicitud));
        }

    }
}
