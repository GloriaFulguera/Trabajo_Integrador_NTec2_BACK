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
        public Task<bool> EditUsuario(UsuarioEditDTO usuario);
        public Task<bool> DeleteUsuario(int dni);
    }
}
