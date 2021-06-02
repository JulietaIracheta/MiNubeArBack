using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocenteController : ControllerBase
    {
        private readonly minubeDBContext _context;

        public DocenteController(minubeDBContext context)
        {
            _context = context;

        }

        [HttpGet("{id}")]
        public IQueryable<string>  GetInstitucionesDocente(int id)
        {
            var query = from inst in _context.Instituciones
                        join idoc in _context.InstitucionDocente on inst.IdInstitucion equals idoc.IdInstitucion
                        join usu in _context.Usuarios on idoc.IdDocente equals usu.IdUsuario
                        where usu.IdUsuario == id
                        select inst.Nombre;

            return query;
        }


        [HttpGet("getCursos/{id}")]
        public IQueryable<string> GetCursosDocente(int id)
        {
            var query = from curso in _context.Cursos
                        join cdoc in _context.CursoDocente on curso.IdCurso equals cdoc.IdCurso
                        join usu in _context.Usuarios on cdoc.IdDocente equals usu.IdUsuario
                        where usu.IdUsuario == id
                        select curso.Nombre; 
                        

            return query;
        }



    }
}
