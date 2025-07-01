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
    public class LoginService : ILoginRepository
    {
        public async Task<List<Usuario>> GetUsuarios()
        {
            string query = "SELECT * FROM usuarios";
            string json = SqliteHandler.GetJson(query);

            List<Usuario> usuarios=JsonConvert.DeserializeObject<List<Usuario>>(json);
            return usuarios;
        }
        public async Task<bool> CreateUsuario(RegisterDTO usuario)
        {
            string query = $"INSERT INTO usuarios(dni,nombre,apellido,clave,rol,fecha_alta,fecha_ultLogin,estado)" +
                $"VALUES ({usuario.Dni},'{usuario.Nombre}','{usuario.Apellido}','{usuario.Clave}','2','{DateTime.Now.ToString()}',null,A)";
            return SqliteHandler.Exec(query);
        }
    }
}
