using Prestamos.Models.DTO;
using Prestamos.Services.Repositories;
using Stock.Services.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Services
{
    public class SolicitudService : ISolicitudRepository
    {
        public async Task<bool> CreateSolicitud(SolicitudDTO solicitud)
        {
            string query = $"INSERT INTO solicitudes(id,usuario_dni,usuario_edad,ingresos,tipo_empleo,monto,cuotas,motivo,fecha_alta,fecha_mod,estado,riesgo,motivo_rechazo) " +
                $"VALUES (null,{solicitud.Dni},'{solicitud.Edad}','{solicitud.Ingresos}','{solicitud.Tipo_empleo}','{solicitud.Monto}'," +
                $"{solicitud.Cuotas},'{solicitud.Motivo}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}',null,'PENDIENTE',null,null)";
            //TO DO: Validar ingresos
            return SqliteHandler.Exec(query);
        }
    }
}
