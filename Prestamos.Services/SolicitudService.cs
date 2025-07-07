using Newtonsoft.Json;
using Prestamos.Models;
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
        EvaluacionService evaluacionService=new EvaluacionService();
        public async Task<bool> CreateSolicitud(SolicitudDTO solicitud)
        {
            string query = $"INSERT INTO solicitudes(id,usuario_dni,usuario_edad,ingresos,tipo_empleo,monto,cuotas,motivo,fecha_alta,fecha_mod,estado,riesgo,motivo_rechazo) " +
                $"VALUES (null,{solicitud.Dni},'{solicitud.Edad}','{solicitud.Ingresos}','{solicitud.Tipo_empleo}','{solicitud.Monto}'," +
                $"{solicitud.Cuotas},'{solicitud.Motivo}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}',null,'pendiente',null,null)";
            //TO DO: Validar ingresos
            if (SqliteHandler.Exec(query))
            {
                evaluacionService.EvaluarSolicitud(solicitud.Dni);
                return true;
            }
            else
                return false;
        }

        public async Task<List<Solicitud>> GetSolicitudes(int? dni, string? estado)
        {
            string query;
            if (dni.HasValue)
            {
                query = "SELECT * FROM solicitudes WHERE usuario_dni=" + dni;
            }
            else if (!string.IsNullOrEmpty(estado))
            {
                query = $"SELECT * FROM solicitudes WHERE estado='{estado}'";
            }
            else
            {
                query = "SELECT * FROM solicitudes";
            }
            
            string json=SqliteHandler.GetJson(query);

            List<Solicitud> ret=JsonConvert.DeserializeObject<List<Solicitud>>(json);
            return ret;
        }
    }
}
