using Prestamos.Models;
using Prestamos.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Services.Repositories
{
    public interface ILoginRepository
    {
        public Task<List<Usuario>> GetUsuarios(int? dni);
        public Task<bool> CreateUsuario(RegisterDTO usuario);
        public Task<LoginResultDTO> Login(LoginDTO usuario);
    }
}
