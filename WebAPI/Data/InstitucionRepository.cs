using System;
using System.Linq;
using WebAPI.Models;

namespace WebAPI.Data

{
    public interface IInstitucionRepository
    {
        Instituciones GetById(int id);
    }
    public class InstitucionRepository : IInstitucionRepository
    {
        private readonly minubeDBContext _context;

        public InstitucionRepository(minubeDBContext context)
        {
            _context = context;
        }
        
        public Instituciones GetById(int id)
        {
            return _context.Instituciones.FirstOrDefault(x => x.IdInstitucion == id);
        }
    }
}
