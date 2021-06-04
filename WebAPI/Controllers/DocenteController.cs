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
        public IQueryable<Instituciones> GetInstitucionesDocente(int id)
        {

            var institucion = _context.InstitucionDocente.Where(x => x.IdDocente == id).Select(x => x.IdInstitucionNavigation);
            

            return institucion;
        }


        [HttpGet("getCursos/{id}")]
        
            public IQueryable<Cursos> GetCursosDocente(int id)
            {

                var curso = _context.CursoDocente.Where(x => x.IdDocente == id).Select(x => x.IdCursoNavigation);


                return curso;
            }



        }
}
