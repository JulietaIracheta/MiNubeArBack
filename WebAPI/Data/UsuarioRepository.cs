using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data

{
    public interface IUsuarioRepository
    {
        Usuario GetByEmail(string email);
    }
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioDBContext _context;

        public UsuarioRepository(UsuarioDBContext context)
        {
            _context = context;
        }
        
        public Usuario GetByEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(x => x.email == email);
        }
    }
}
