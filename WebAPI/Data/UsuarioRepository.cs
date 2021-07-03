using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebAPI.Dto;
using WebAPI.Models;

namespace WebAPI.Data
{
    public interface IUsuarioRepository
    {
        Usuarios GetByEmail(string email);
        List<PersonaDto> GetEstudiantes();
    }
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly minubeDBContext _context;

        public UsuarioRepository(minubeDBContext context)
        {
            _context = context;
        }

        public Usuarios GetByEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(u =>
                !u.FechaEliminacionLogico.HasValue && u.UsuarioNombre == email);
        }

        public List<UsuarioDto> GetAll()
        {
            var persona = _context.Usuarios.Where(u => !u.FechaEliminacionLogico.HasValue).ToList();

            var list = persona.Select(p => new UsuarioDto
            {
                IdUsuario = p.IdUsuario,
                UsuarioNombre = p.UsuarioNombre,
            });
            return list.ToList();
        }

        public Usuarios GetById(int id)
        {
            return _context.Usuarios.Include(u => u.IdPersonaNavigation).First(u => u.IdUsuario == id);
        }
        public List<EstudianteMateriasDto> GetMaterias(string email)
        {

            IQueryable<EstudianteMateriasDto> materias = from u in _context.Usuarios
                                                         join me in _context.MateriaEstudiante on u.IdUsuario equals me.IdUsuario
                                                         join m in _context.Materias on me.IdMateria equals m.IdMateria
                                                         where u.UsuarioNombre == email
                                                         select new EstudianteMateriasDto
                                                         {
                                                             IdMateria = m.IdMateria,
                                                             Nombre = m.Nombre,
                                                             Icon = m.Icon
                                                         };

            return materias.ToList();
        }

        public string ObtenerUsuarioChat(int userId)
        {
            if (!_context.EstudianteCurso.Any(e => e.IdUsuario == userId))
                return string.Empty;
            var curso = _context.EstudianteCurso.Include(e => e.IdCursoNavigation).First(e => e.IdUsuario == userId);
            var nombreSala = curso.IdCursoNavigation.Nombre + curso.IdCurso;
            var sala = nombreSala.Replace(" ", "");
            return sala;
        }

        public List<string> ObtenerChatsDocente(int userId)
        {
            var curso = _context.CursoDocente.Include(e => e.IdCursoNavigation).Where(e => e.IdDocente == userId);
            var listaCursos = new List<string>();

            foreach (var c in curso)
            {
                var sala = c.IdCursoNavigation.Nombre + c.IdCurso;
                sala = sala.Replace(" ", "");
                listaCursos.Add(sala);
            }

            return listaCursos;
        }

        public List<PersonaDto> GetEstudiantes()
        {

            IQueryable<PersonaDto> usuarios = from u in _context.Usuarios
                                              join ur in _context.UsuarioRol on u.IdUsuario equals ur.IdUsuario
                                              where ur.IdRol == 1
                                              select new PersonaDto
                                              {
                                                  IdUsuario = u.IdUsuario,
                                                  Nombre = u.IdPersonaNavigation.Nombre,
                                                  Apellido = u.IdPersonaNavigation.Apellido
                                              };

            return usuarios.ToList();
        }

        public async void UpdateDocente(int id, UsuarioUpdateDto usuario) {
            // obtengo la persona actual y actualizo sus valores
            var personaAModificar = _context.Personas.FirstOrDefault(item => item.IdPersona == usuario.IdUsuario);
            personaAModificar.Nombre = usuario.Nombre;
            personaAModificar.Apellido = usuario.Apellido;
            personaAModificar.Email = usuario.Email;
            personaAModificar.Telefono = int.Parse(usuario.Telefono);

            // obtengo las instituciones del docente 
            var institucionesDelDocente = _context.InstitucionDocente.Where(row => row.IdDocente == usuario.IdUsuario);

            int[] institucionDocenteList = new int[institucionesDelDocente.Count()];

            int contador = 0;
            foreach (var row in institucionesDelDocente)
            {
                institucionDocenteList[contador] = row.IdInstitucion;
                contador++;
            }

            // primero pregunto si tienen la misma cantidad de elementos comparo el tamaño de los arrays
            // verifico si las que vienen por parametro son las mismas que las que se encuentran actualmente en la tabla
            if (institucionDocenteList.Length == usuario.IdInstitucion.Length) {

                int coincidencias = institucionDocenteList.Intersect(usuario.IdInstitucion).Count();

                // si los dos arrays tienen los mismo valores no hago nada
                if (!(coincidencias == usuario.IdInstitucion.Length)) {
                    // Si hay 0 coincidencias entonces modifico todo
                    int index = 0;
                    foreach (var row in institucionesDelDocente)
                    {
                        row.IdInstitucion = usuario.IdInstitucion[index];
                        index++;
                    }
                }
                // si las instituciones ingresadas superan a las actuales agrego la/s nueva/s
            } else if (institucionDocenteList.Length < usuario.IdInstitucion.Length) {
                // verifico si las que ya estan registradas forman parte de las ingresadas
                if (institucionDocenteList.Intersect(usuario.IdInstitucion).Count() == institucionDocenteList.Length) {
                    // identifico los id de instituciones ingresadas no registradas
                    var idNoRegistradas = usuario.IdInstitucion.Except(institucionDocenteList);
                    // agrego las restantes
                    foreach (var idInstitucion in idNoRegistradas)
                    {
                        var institucionDocente = new InstitucionDocente { IdInstitucion = idInstitucion, IdDocente = usuario.IdPersona };
                        _context.InstitucionDocente.Add(institucionDocente);
                    }
                }

            } else {
                // si las instituciones ingresadas es es menor a la existente entonces elimino las que ya no se encuentran
                // obtengo las que tienen que ser eliminadas
                var idAeliminar = institucionDocenteList.Except(usuario.IdInstitucion);

                foreach (var idInstitucion in idAeliminar)
                {
                    var institucionDocente = _context.InstitucionDocente.FirstOrDefault(item => item.IdInstitucion == idInstitucion && item.IdDocente == usuario.IdPersona);
                    _context.InstitucionDocente.Remove(institucionDocente);
                }

                // identifico los id de instituciones ingresadas no registradas y las registro
                var idNoRegistradas = usuario.IdInstitucion.Except(institucionDocenteList);

                foreach (var idInstitucion in idNoRegistradas)
                {
                    var institucionDocente = new InstitucionDocente { IdInstitucion = idInstitucion, IdDocente = usuario.IdPersona };
                    _context.InstitucionDocente.Add(institucionDocente);
                }
            }

            _context.SaveChanges();
        }

        public async void UpdateEstudiante(int id, UsuarioUpdateDto usuario) {
            // obtengo la persona actual y actualizo sus valores
            var personaAModificar = _context.Personas.FirstOrDefault(item => item.IdPersona == usuario.IdUsuario);
            personaAModificar.Nombre = usuario.Nombre;
            personaAModificar.Apellido = usuario.Apellido;
            personaAModificar.Email = usuario.Email;
            personaAModificar.Telefono = int.Parse(usuario.Telefono);

            // obtengo las instituciones del estudiante 
            var institucionesDelEstudiante = _context.InstitucionEstudiante.Where(row => row.IdUsuario == usuario.IdUsuario);

            int[] institucionEstudianteList = new int[institucionesDelEstudiante.Count()];

            int contador = 0;
            foreach (var row in institucionesDelEstudiante)
            {
                institucionEstudianteList[contador] = row.IdInstitucion;
                contador++;
            }

            // primero pregunto si tienen la misma cantidad de elementos comparo el tamaño de los arrays
            // verifico si las que vienen por parametro son las mismas que las que se encuentran actualmente en la tabla
            if (institucionEstudianteList.Length == usuario.IdInstitucion.Length) {

                int coincidencias = institucionEstudianteList.Intersect(usuario.IdInstitucion).Count();

                // si los dos arrays tienen los mismo valores no hago nada
                if (!(coincidencias == usuario.IdInstitucion.Length)) {
                    // Si hay 0 coincidencias entonces modifico todo
                    int index = 0;
                    foreach (var row in institucionesDelEstudiante)
                    {
                        row.IdInstitucion = usuario.IdInstitucion[index];
                        index++;
                    }
                }
                // si las instituciones ingresadas superan a las actuales agrego la/s nueva/s
            } else if (institucionEstudianteList.Length < usuario.IdInstitucion.Length) {
                // verifico si las que ya estan registradas forman parte de las ingresadas
                if (institucionEstudianteList.Intersect(usuario.IdInstitucion).Count() == institucionEstudianteList.Length) {
                    // identifico los id de instituciones ingresadas no registradas
                    var idNoRegistradas = usuario.IdInstitucion.Except(institucionEstudianteList);
                    // agrego las restantes
                    foreach (var idInstitucion in idNoRegistradas)
                    {
                        var institucionEstudiante = new InstitucionEstudiante { IdInstitucion = idInstitucion, IdUsuario = usuario.IdPersona };
                        _context.InstitucionEstudiante.Add(institucionEstudiante);
                    }
                }

            } else {
                // si las instituciones ingresadas es es menor a la existente entonces elimino las que ya no se encuentran
                // obtengo las que tienen que ser eliminadas
                var idAeliminar = institucionEstudianteList.Except(usuario.IdInstitucion);

                foreach (var idInstitucion in idAeliminar)
                {
                    var institucionEstudiante = _context.InstitucionEstudiante.FirstOrDefault(item => item.IdInstitucion == idInstitucion && item.IdUsuario == usuario.IdPersona);
                    _context.InstitucionEstudiante.Remove(institucionEstudiante);
                }

                // identifico los id de instituciones ingresadas no registradas y las registro
                var idNoRegistradas = usuario.IdInstitucion.Except(institucionEstudianteList);

                foreach (var idInstitucion in idNoRegistradas)
                {
                    var institucionEstudiante = new InstitucionEstudiante { IdInstitucion = idInstitucion, IdUsuario = usuario.IdPersona };
                    _context.InstitucionEstudiante.Add(institucionEstudiante);
                }
            }

            _context.SaveChanges();
        }

        public async void UpdateTutor(int id, UsuarioUpdateDto usuario) {
            // obtengo la persona actual y actualizo sus valores
            var personaAModificar = _context.Personas.FirstOrDefault(item => item.IdPersona == usuario.IdUsuario);
            personaAModificar.Nombre = usuario.Nombre;
            personaAModificar.Apellido = usuario.Apellido;
            personaAModificar.Email = usuario.Email;
            personaAModificar.Telefono = int.Parse(usuario.Telefono);

            // obtengo los estudiantes del tutor
            var estudiantesDelDocente = _context.TutorEstudiante.Where(row => row.IdUsuarioTutor == usuario.IdUsuario);

            int[] estudianteTutorList = new int[estudiantesDelDocente.Count()];

            int contador = 0;
            foreach (var row in estudiantesDelDocente)
            {
                estudianteTutorList[contador] = row.IdUsuarioEstudiante;
                contador++;
            }

            // primero pregunto si tienen la misma cantidad de elementos comparo el tamaño de los arrays
            // verifico si las que vienen por parametro son las mismas que las que se encuentran actualmente en la tabla
            if (estudianteTutorList.Length == usuario.IdEstudiantes.Length) {

                int coincidencias = estudianteTutorList.Intersect(usuario.IdEstudiantes).Count();

                // si los dos arrays tienen los mismo valores no hago nada
                if (!(coincidencias == usuario.IdEstudiantes.Length)) {
                    // Si hay 0 coincidencias entonces modifico todo
                    int index = 0;
                    foreach (var row in estudiantesDelDocente)
                    {
                        row.IdUsuarioEstudiante = usuario.IdEstudiantes[index];
                        index++;
                    }
                }
                // si los estudiantes asignados superan a las actuales agrego la/s nueva/s
            } else if (estudianteTutorList.Length < usuario.IdEstudiantes.Length) {
                // verifico si las que ya estan registradas forman parte de las ingresadas
                if (estudianteTutorList.Intersect(usuario.IdEstudiantes).Count() == estudianteTutorList.Length) {
                    // identifico los id de estudiantes asignados no registradas
                    var idNoRegistradas = usuario.IdEstudiantes.Except(estudianteTutorList);
                    // agrego las restantes
                    foreach (var idEstudiante in idNoRegistradas)
                    {
                        var estudianteTutor = new TutorEstudiante { IdUsuarioEstudiante = idEstudiante, IdUsuarioTutor = usuario.IdPersona };
                        _context.TutorEstudiante.Add(estudianteTutor);
                    }
                } else {
                    // si las que ya estan registradas no forman parte de las ingresadas entonces elimino lo que esta y agrego lo nuevo
                    for (int i = 0; i < estudianteTutorList.Length; i++)
                    {
                        var estudianteTutor = _context.TutorEstudiante.FirstOrDefault(item => item.IdUsuarioEstudiante == estudianteTutorList[i] && item.IdUsuarioTutor == usuario.IdPersona);
                        _context.TutorEstudiante.Remove(estudianteTutor);
                    }
                    for (int i = 0; i < usuario.IdEstudiantes.Length; i++)
                    {
                        var estudianteTutor = new TutorEstudiante { IdUsuarioEstudiante = usuario.IdEstudiantes[i], IdUsuarioTutor = usuario.IdPersona };
                        _context.TutorEstudiante.Add(estudianteTutor);
                    }
                }

            } else {
                // si los estudiantes asignados es es menor a la existente entonces elimino las que ya no se encuentran
                // obtengo las que tienen que ser eliminadas
                var idAeliminar = estudianteTutorList.Except(usuario.IdEstudiantes);

                foreach (var idEstudiante in idAeliminar)
                {
                    var estudianteTutor = _context.TutorEstudiante.FirstOrDefault(item => item.IdUsuarioEstudiante == idEstudiante && item.IdUsuarioTutor == usuario.IdPersona);
                    _context.TutorEstudiante.Remove(estudianteTutor);
                }

                // identifico los id de los estudiantes ingresados no registradas y las registro
                var idNoRegistradas = usuario.IdEstudiantes.Except(estudianteTutorList);

                foreach (var idEstudiante in idNoRegistradas)
                {
                    var estudianteTutor = new TutorEstudiante { IdUsuarioEstudiante = idEstudiante, IdUsuarioTutor = usuario.IdPersona };
                    _context.TutorEstudiante.Add(estudianteTutor);
                }
            }

            _context.SaveChanges();
        }
    }
}

