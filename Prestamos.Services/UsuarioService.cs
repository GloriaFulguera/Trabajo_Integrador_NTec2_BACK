using Newtonsoft.Json;
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
    public class UsuarioService : IUsuarioRepository
    {
        public async Task<List<UsuarioDTO>> GetUsuarios(int dni)
        {
            string query = $"SELECT dni,nombre,apellido,rol,fecha_alta,estado FROM usuarios" +
                $" WHERE dni !=" + dni;
            string json=SqliteHandler.GetJson(query);

            List<UsuarioDTO> usuarios=JsonConvert.DeserializeObject<List<UsuarioDTO>>(json);

            return usuarios;
        }

        public async Task<bool> EditUsuario(UsuarioEditDTO usuario)
        {
            string query = $"UPDATE usuarios SET nombre='{usuario.Nombre}',apellido='{usuario.Apellido}'," +
                $"rol='{usuario.Rol}',estado='{usuario.Estado}' WHERE dni={usuario.Dni}";
            return SqliteHandler.Exec(query);
        }

        public async Task<bool> DeleteUsuario(int dni)
        {
            string query = "DELETE from usuarios WHERE dni=" + dni;
            return SqliteHandler.Exec(query);
        }
    }
}
