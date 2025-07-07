using Newtonsoft.Json;
using Prestamos.Models;
using Prestamos.Services.Repositories;
using Stock.Services.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Services
{
    public class EvaluacionService : IEvaluacionRepository
    {
        public void EvaluarSolicitud(int dni)
        {
            string query = $"SELECT * FROM solicitudes WHERE usuario_dni = {dni} ORDER BY id DESC LIMIT 1";//podria cambiarlo por el id que se genere?
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
                    //case "ingresos":
                    //aca evaluo los casos y seteo la lista de reisgos
                }
            }
            //aca evaluo el contenido de la lista para determinar el ESTADO
        }
    }
}
