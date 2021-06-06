using System.Linq;
using WebAPI.Dto;
using WebAPI.Models;

namespace WebAPI.Data
{
    public interface IComunicadoRepository
    {
        Comunicados GetById(int id);
    }
    public class ComunicadoRepository : IComunicadoRepository
    {
        private readonly minubeDBContext _context;

        public ComunicadoRepository(minubeDBContext context)
        {
            _context = context;
        }
        public Comunicados GetById(int id)
        {
            return _context.Comunicados.FirstOrDefault(x => x.IdComunicado == id);
        }
        public Comunicados Crear(ComunicadoDto comunicado)
        {
            var comunicados = new Comunicados
            {
                IdUsuario = comunicado.IdUsuario, Descripcion = comunicado.Descripcion,
                IdComunicado = comunicado.IdComunicado
            };
            _context.Comunicados.Add(comunicados);
            _context.SaveChanges();
            return comunicados;
        }
    }
}
