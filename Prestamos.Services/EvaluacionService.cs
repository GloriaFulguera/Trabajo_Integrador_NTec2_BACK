using Newtonsoft.Json;
using Prestamos.Models;
using Prestamos.Services.Repositories;
using Stock.Services.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Services
{
    public class EvaluacionService : IEvaluacionRepository
    {
        public async Task<bool> EvaluarSolicitud(int dni)
        {
            string query = $"SELECT * FROM solicitudes WHERE usuario_dni = {dni} ORDER BY id DESC LIMIT 1";//podria cambiarlo por el id que se genera?
            string json=SqliteHandler.GetJson(query);

            Solicitud response=JsonConvert.DeserializeObject<List<Solicitud>>(json).FirstOrDefault();
            //La evaluacion de reisgo considera:
            // ingresos-edad-cuotas-empleo
            query = "SELECT * FROM evaluacion_riesgo";
            json=SqliteHandler.GetJson(query);
            List<Evaluacion> reglas = JsonConvert.DeserializeObject<List<Evaluacion>>(json);

            List<string>riesgos=new List<string>();

            foreach(var r in reglas)
            {
                switch(r.Regla.ToLower())
                {
                    case "ingresos":
                        decimal min = Convert.ToDecimal(r.Valor1);
                        decimal max = Convert.ToDecimal(r.Valor2);

                        if (Convert.ToDecimal(response.Ingresos) < min && Convert.ToDecimal(response.Monto) > max)
                            riesgos.Add(r.Tipo_riesgo);
                        break;

                    case "edad":
                        int minEdad=Convert.ToInt32(r.Valor1);
                        int maxEdad=Convert.ToInt32(r.Valor2);

                        if(Convert.ToInt32(response.Usuario_edad)<minEdad||Convert.ToInt32(response.Usuario_edad)>maxEdad)
                            riesgos.Add(r.Tipo_riesgo);
                        break;

                    case "cuotas":
                        decimal cuotaMensual=Convert.ToDecimal(response.Monto)/response.Cuotas;
                        decimal porcentaje = (cuotaMensual * 100) / (Convert.ToDecimal(response.Ingresos));

                        if(porcentaje>Convert.ToDecimal(r.Valor1))
                            riesgos.Add(r.Tipo_riesgo);
                        break;
                    case "empleo":
                        if(response.Tipo_empleo.ToLower()==r.Valor1.ToLower())
                            riesgos.Add(r.Tipo_riesgo);
                        break;
                }
            }

            string estado = "aprobado";
            string riesgo = "bajo";
            string motivoRechazo = "RESPUESTA AUTOMATICA: No se identificó riesgo.";

            if (riesgos.Contains("ALTO"))
            {
                estado = "rechazado";
                riesgo = "alto";
                motivoRechazo = "RESPUESTA AUTOMATICA: Riesgo alto detectado";
            }
            else if (riesgos.Contains("MEDIO"))
            {
                estado = "pendiente";
                riesgo = "medio";
                motivoRechazo = "null";
            }

            query = $"UPDATE solicitudes " +
                $"SET estado='{estado}', riesgo='{riesgo}', motivo_rechazo_aprobacion='{motivoRechazo}' " +
                $"WHERE id={response.Id}";

            return SqliteHandler.Exec(query);
        }
    }
}
