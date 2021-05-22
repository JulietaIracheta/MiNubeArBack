using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data

{
    public interface IInstitucionRepository
    {
        Institucion GetById(int id);
    }
    public class InstitucionRepository : IInstitucionRepository
    {
        private readonly ApplicationDBContext _context;

        public InstitucionRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        
        public Institucion GetById(int id)
        {
            return _context.Instituciones.FirstOrDefault(x => x.id == id);
        }
    }
}
