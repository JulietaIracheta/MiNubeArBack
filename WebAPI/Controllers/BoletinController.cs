using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Dto;
using WebAPI.Enums;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoletinController : Controller
    {
        private readonly minubeDBContext _context;
        private readonly JwtService _jwtService;

        public BoletinController(minubeDBContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Boletin>>> GetBoletines()
        {
            return await _context.Boletin.ToListAsync();
        }

        [HttpGet("estudiante")]
        public List<Boletin> GetBoletinEstudiante(string jwt)
        {
            //var jwt = Request.Cookies["jwt"];
            var token = _jwtService.Verify(jwt);
            var id = Convert.ToInt32(token.Issuer);

            IQueryable<Boletin> boletin = from b in _context.Boletin
                                    where b.IdEstudiante == id && b.Año == DateTime.Today.Year
                                    select new Boletin
                                    {
                                        IdEstudiante = id,
                                        Año = b.Año,
                                        Materia = b.Materia,
                                        T1 = b.T1,
                                        T2 = b.T2,
                                        T3 = b.T3,
                                    };

            return boletin.ToList();
        }
        [HttpGet("estudianteTutor")]
        public List<Boletin> GetBoletinEstudianteTutor(int id)
        {

            IQueryable<Boletin> boletin = from b in _context.Boletin
                                          where b.IdEstudiante == id && b.Año == DateTime.Today.Year
                                          select new Boletin
                                          {
                                              IdEstudiante = id,
                                              Año = b.Año,
                                              Materia = b.Materia,
                                              T1 = b.T1,
                                              T2 = b.T2,
                                              T3 = b.T3,
                                          };

            return boletin.ToList();
        }
        [HttpGet("getByEstudianteId/{id}")]
        public List<Boletin> GetBoletinEstudiante(int id)
        {

            var boletin = from b in _context.Boletin
                where b.IdEstudiante == id && b.Año == DateTime.Today.Year
                select new Boletin
                {
                    IdEstudiante = id,
                    Año = b.Año,
                    Materia = b.Materia,
                    T1 = b.T1,
                    T2 = b.T2,
                    T3 = b.T3,
                };

            return boletin.ToList();
        }
        [HttpGet("trayectoria/{anio}")]
        public List<Boletin> GettrayectoriaEstudiante(int anio, string jwt)
        {
            DateTime año = DateTime.Today;

            var a = año.Year;

//            var jwt = Request.Cookies["jwt"];
            var token = _jwtService.Verify(jwt);
            var id = Convert.ToInt32(token.Issuer);
           
            IQueryable<Boletin> boletin = from b in _context.Boletin
                                          where b.IdEstudiante ==id && b.Año == anio
                                          select new Boletin
                                          {
                                              IdEstudiante = id,
                                              Año = b.Año,
                                              Materia = b.Materia,
                                              T1 = b.T1,
                                              T2 = b.T2,
                                              T3 = b.T3,
                                          };

            return boletin.ToList();
        }

        [HttpGet("año")]
        public List<int> GettrayectoriaAño(string jwt)
        {
            DateTime año = DateTime.Today;

            var a = año.Year;

//            var jwt = Request.Cookies["jwt"];
            var token = _jwtService.Verify(jwt);
            var id = Convert.ToInt32(token.Issuer);

            var añoT = _context.Boletin.Where(p => p.Año != a && p.IdEstudiante == id).Select(p => p.Año).Distinct();
/*            IQueryable<Boletin> boletin = from b in _context.Boletin
                                          where b.IdEstudiante == id && b.Año != a
                                          select new Boletin
                                          {
                                              Año = b.Año,
                                          };

            return boletin.ToList();
  */
            return añoT.ToList();
            }


        [HttpGet("estudiante/{id}")]
        public List<Boletin> GetBoletinesEstudiantes(int id)
        {

            IQueryable<Boletin> boletin = from b in _context.Boletin
                                          where b.IdEstudiante == id
                                          select new Boletin
                                          {
                                              IdEstudiante = id,
                                              Año = b.Año,
                                              Materia = b.Materia,
                                              T1 = b.T1,
                                              T2 = b.T2,
                                              T3 = b.T3,
                                          };

            return boletin.ToList();
        }

        [HttpGet("tutor/{id}")]
        public List<BoletinDto> GetBoletinEstudianteTutor(string jwt)
        {
                //var jwt = Request.Cookies["jwt"];
              var token = _jwtService.Verify(jwt);
              var id = Convert.ToInt32(token.Issuer);

            IQueryable<BoletinDto> boletin = from b in _context.Boletin
                                             join u in _context.Usuarios on b.IdEstudiante equals u.IdUsuario
                                             join t in _context.TutorEstudiante on u.IdUsuario equals t.IdUsuarioEstudiante
                                             where t.IdUsuarioTutor == id
                                             
                                             select new BoletinDto
                                          {
                                            
                                              Año = b.Año,
                                              Materia = b.Materia,
                                              Nombre = u.IdPersonaNavigation.Nombre,
                                              Apellido = u.IdPersonaNavigation.Apellido,
                                              T1 = b.T1,
                                              T2 = b.T2,
                                              T3 = b.T3,
                                          };

            return boletin.ToList();
        }

        [HttpPost]
        public async Task<ActionResult<Boletin>> PostBoletin(Boletin boletin)
        {

            var bol = new Boletin
            {
                IdEstudiante = boletin.IdEstudiante,
                Materia = boletin.Materia,
                Año = boletin.Año,
                T1 = boletin.T1,
                T2 = boletin.T2,
                T3 = boletin.T3,
            };
            Notificacion notificacionTutor;
            Notificacion notificacionEstudiante;
            
            var tutor = _context.TutorEstudiante.FirstOrDefault(e => e.IdUsuarioEstudiante == boletin.IdEstudiante)?.IdUsuarioTutor;
            if (tutor.HasValue)
            {
                notificacionTutor = new Notificacion
                {
                    Descripcion = "Nueva calificación",
                    Fecha = DateTime.Now,
                    IdDestinatario = tutor.Value,
                    IdNotificacion = 0,
                    Mensaje = "Han cargado la calificación de " + boletin.Materia + $" {DateTime.Now:g}",
                    TipoNotificacion = (int)TipoNotificacion.Calificacion
                };
                _context.Notificacion.Add(notificacionTutor);
            }
            notificacionEstudiante = new Notificacion
            {
                Descripcion = "Nueva calificación",
                Fecha = DateTime.Now,
                IdDestinatario = boletin.IdEstudiante.GetValueOrDefault(),
                IdNotificacion = 0,
                Mensaje = $"Han cargado la calificación de " + boletin.Materia + $" {DateTime.Now:g}",
                TipoNotificacion = (int)TipoNotificacion.Calificacion
            };
            
            _context.Notificacion.Add(notificacionEstudiante);
            _context.Boletin.Add(bol);
            await _context.SaveChangesAsync();
            return bol;
        }

        [HttpGet("getBoletinesEstudiante/{id}")]
        public dto GetBoletinesEstudiante(int id)
        {
            var list = _context.Boletin.Include(e => e.IdEstudianteNavigation).ThenInclude(e => e.InstitucionEstudiante)
                .ThenInclude(e => e.IdInstitucionNavigation).Include(e=>e.IdEstudianteNavigation).ThenInclude(e=>e.IdPersonaNavigation);
            
            double mejorPromedio = 0;
            double peorPromedio = 0;
            double promedioAnual = 0;
            double promedioTotal = 0;
            var estudianteMejorPromedio = "";
            var institucionMejorPromedio = "";
            var institucionPeorPromedio = "";
            bool flag = true;
            
            foreach (var v in list)
            {
                if (v.Año == DateTime.Now.Year)
                {
                    double promedioAñoActual = ((Convert.ToDouble(v.T1) + Convert.ToDouble(v.T2) + Convert.ToDouble(v.T3)) / 3);
                    promedioAnual = promedioAñoActual + promedioAnual;
                }

                double promedioActual = ((Convert.ToDouble(v.T1) + Convert.ToDouble(v.T2) + Convert.ToDouble(v.T3))/3);

                if (flag)
                {
                    peorPromedio = promedioActual;
                    flag = false;
                }

                if (promedioActual > mejorPromedio)
                {
                    mejorPromedio = promedioActual;
                    estudianteMejorPromedio = v.IdEstudianteNavigation.IdPersonaNavigation.GetNombreApellido();
                    institucionMejorPromedio = v.IdEstudianteNavigation.InstitucionEstudiante.First()
                        .IdInstitucionNavigation.Nombre;
                }
                if (promedioActual < peorPromedio)
                {
                    peorPromedio = promedioActual;
                }
                promedioTotal = promedioActual + promedioTotal;
            }
          
            var totalEstudiantes = _context.InstitucionEstudiante.Select(e => e.IdUsuario).Count();
            var totalDocentes= _context.InstitucionDocente.Select(e => e.IdDocente).Distinct().Count();
            var totalInstituciones= _context.Instituciones.Select(e => e.IdInstitucion).Count();
            var totalTutores= _context.TutorEstudiante.Select(e => e.IdUsuarioTutor).Distinct().Count();


            return new dto
            {
                estudiante = estudianteMejorPromedio,
                mejorPromedio = Math.Round(mejorPromedio, 2),
                colegioMejorPromedio = institucionMejorPromedio,
                totalEstudiantes = totalEstudiantes,
                totalDocentes = totalDocentes,
                totalInstituciones = totalInstituciones,
                totalTutores = totalTutores
            };
        }
    }

    public class dto
    {
        public string colegioMejorPromedio { get; set; }
        public int totalEstudiantes { get; set; }
        public int totalDocentes { get; set; }
        public int totalTutores { get; set; }
        public int totalInstituciones { get; set; }
        public string estudiante { get; set; }
        public double mejorPromedio { get; set; }
    }
}
