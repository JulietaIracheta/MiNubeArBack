using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Dto;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaCursoController : ControllerBase
    {
        private readonly minubeDBContext _context;

        public MateriaCursoController(minubeDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<MateriaCurso>> PostMateriaCurso(MateriaCursoDto materiaCurso)
        {
            MateriaCurso[] materiaCursoList = new MateriaCurso[materiaCurso.IdMateria.Length];
            var estudiantes =
                _context.Usuarios.Where(e => e.EstudianteCurso.Any(e => e.IdCurso == materiaCurso.IdCurso)).Select(e=>e.IdUsuario);
            
            foreach (var e in estudiantes)
            {
                foreach (var materia in materiaCurso.IdMateria)
                {
                    var materiaEstudiante = new MateriaEstudiante
                    {
                        IdMateria = materia,
                        IdUsuario = e
                    };
                    _context.MateriaEstudiante.Add(materiaEstudiante);
                }
            }

            for (int i = 0; i < materiaCurso.IdMateria.Length; i++)
            {
                var IdMateria = materiaCurso.IdMateria[i];
                materiaCursoList[i] = new MateriaCurso { IdMateria = IdMateria, IdCurso = materiaCurso.IdCurso };
            }
            foreach (var item in materiaCursoList)
            {
                _context.MateriaCurso.Add(item);
            }
            
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
