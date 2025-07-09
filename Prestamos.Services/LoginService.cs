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
        public async Task<List<Usuario>> GetUsuarios(int? dni)
        {
            string query = "SELECT * FROM usuarios";
            if (dni.HasValue)
                query = "SELECT * FROM usuarios WHERE dni=" + dni;
            string json = SqliteHandler.GetJson(query);

            List<Usuario> usuarios=JsonConvert.DeserializeObject<List<Usuario>>(json);
            return usuarios;
        }
        public async Task<bool> CreateUsuario(RegisterDTO usuario)
        {
            string query = $"INSERT INTO usuarios(dni,nombre,apellido,clave,rol,fecha_alta,fecha_ultLogin,estado)" +
                $"VALUES ({usuario.Dni},'{usuario.Nombre}','{usuario.Apellido}','{usuario.Clave}','2','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}',null,'A')";
            return SqliteHandler.Exec(query);
        }

        public async Task<LoginResultDTO> Login(LoginDTO usuario)
        {
            string query = $"SELECT count(*) as Existe from usuarios " +
                $"WHERE dni={usuario.Dni} AND clave='{usuario.Clave}'";
            string result=SqliteHandler.GetScalar(query);

            LoginResultDTO loginResult=new LoginResultDTO();
            if (result == "0")
            {
                loginResult.Result=false;
                loginResult.Mensaje = "Credenciales incorrectas o usuario inexistente.";
            }
            else
            {
                query = $"SELECT estado from usuarios " +
                    $"WHERE dni={usuario.Dni} AND clave='{usuario.Clave}'";
                result = SqliteHandler.GetScalar(query);

                if (result != "A")
                {
                    loginResult.Result = false;
                    loginResult.Mensaje = "El usuario esta inactivo.";
                }
                else
                {
                    query = $"UPDATE usuarios SET fecha_ultLogin='{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' " +
                        $"WHERE dni={usuario.Dni}";
                    bool updateResult = SqliteHandler.Exec(query);
                    if(updateResult)
                    {
                        loginResult.Result = true;
                        loginResult.Mensaje = "Usuario validado correctamente.";
                    }
                    else
                    {
                        loginResult.Result = false;
                        loginResult.Mensaje = "Ocurrio un problema, comuniquese con el administrador.";
                    }
                }
            }
            return loginResult;
        }
    }
}
