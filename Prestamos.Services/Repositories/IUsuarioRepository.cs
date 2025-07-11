using Prestamos.Models;
using Prestamos.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Services.Repositories
{
    public interface IUsuarioRepository
    {
        public Task<List<UsuarioDTO>> GetUsuarios(int dni);
        public Task<bool> EditUsuario(Usuario usuario);
        public Task<bool> DeleteUsuario(int dni);
    }
}
