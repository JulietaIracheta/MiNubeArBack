using System.Collections.Generic;
using System.Linq;
using WebAPI.Dto;
using WebAPI.Models;

namespace WebAPI.Data

{
    public interface IUsuarioRepository
    {
        Usuarios GetByEmail(string email);
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
            var persona = _context.Usuarios.Where(u=>!u.FechaEliminacionLogico.HasValue).ToList();

            var list = persona.Select(p => new UsuarioDto
            {
                IdUsuario = p.IdUsuario,               
                UsuarioNombre = p.UsuarioNombre,
                });
            return list.ToList();
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


        public async void UpdateDocente(int id, UsuarioUpdateDto usuario){
              // obtengo la persona actual y actualizo sus valores
                var personaAModificar = _context.Personas.FirstOrDefault(item => item.IdPersona == usuario.IdUsuario);
                personaAModificar.Nombre = usuario.Nombre; 
                personaAModificar.Apellido = usuario.Apellido;
                personaAModificar.Email = usuario.Email;
                personaAModificar.Telefono = int.Parse(usuario.Telefono);

                // obtengo las instituciones del docente 
                var institucionesDelDocente = _context.InstitucionDocente.Where( row => row.IdDocente == usuario.IdUsuario);

                int[] institucionDocenteList = new int[institucionesDelDocente.Count()] ;

                int contador = 0;
                foreach (var row in institucionesDelDocente)
                {
                    institucionDocenteList[contador] = row.IdInstitucion;
                    contador++;                                                                        
                }

                // primero pregunto si tienen la misma cantidad de elementos comparo el tamaño de los arrays
                // verifico si las que vienen por parametro son las mismas que las que se encuentran actualmente en la tabla
                if(institucionDocenteList.Length == usuario.IdInstitucion.Length){
                    
                    int coincidencias = institucionDocenteList.Intersect(usuario.IdInstitucion).Count();
                    
                    // si los dos arrays tienen los mismo valores no hago nada
                    if(!(coincidencias == usuario.IdInstitucion.Length)){
                        // Si hay 0 coincidencias entonces modifico todo
                        int index = 0;
                        foreach (var row in institucionesDelDocente)
                        {
                            row.IdInstitucion = usuario.IdInstitucion[index];
                            index++;
                        }
                    } 
                // si las instituciones ingresadas superan a las actuales agrego la/s nueva/s
                }else if(institucionDocenteList.Length < usuario.IdInstitucion.Length){ 
                    // verifico si las que ya estan registradas forman parte de las ingresadas
                    if(institucionDocenteList.Intersect(usuario.IdInstitucion).Count() == institucionDocenteList.Length){
                        // identifico los id de instituciones ingresadas no registradas
                        var idNoRegistradas = usuario.IdInstitucion.Except(institucionDocenteList);
                        // agrego las restantes
                        foreach (var idInstitucion in idNoRegistradas)
                        {
                            var institucionDocente = new InstitucionDocente {IdInstitucion = idInstitucion, IdDocente = usuario.IdPersona};
                            _context.InstitucionDocente.Add(institucionDocente);
                        }
                    }
                    
                }else{
                    // si las instituciones ingresadas es es menor a la existente entonces elimino las que ya no se encuentran
                    // obtengo las que tienen que ser eliminadas
                    var idAeliminar = institucionDocenteList.Except(usuario.IdInstitucion);

                    foreach (var idInstitucion in idAeliminar)
                    {
                        var institucionDocente =  _context.InstitucionDocente.FirstOrDefault(item => item.IdInstitucion == idInstitucion && item.IdDocente == usuario.IdPersona);
                        _context.InstitucionDocente.Remove(institucionDocente);
                    }
                    
                    // identifico los id de instituciones ingresadas no registradas y las registro
                    var idNoRegistradas = usuario.IdInstitucion.Except(institucionDocenteList);

                    foreach (var idInstitucion in idNoRegistradas)
                    {
                        var institucionDocente = new InstitucionDocente {IdInstitucion = idInstitucion, IdDocente = usuario.IdPersona};
                        _context.InstitucionDocente.Add(institucionDocente);
                    }
                }
  
                _context.SaveChanges();
        }


        public async void UpdateEstudiante(int id, UsuarioUpdateDto usuario){
              // obtengo la persona actual y actualizo sus valores
                var personaAModificar = _context.Personas.FirstOrDefault(item => item.IdPersona == usuario.IdUsuario);
                personaAModificar.Nombre = usuario.Nombre; 
                personaAModificar.Apellido = usuario.Apellido;
                personaAModificar.Email = usuario.Email;
                personaAModificar.Telefono = int.Parse(usuario.Telefono);

                // obtengo las instituciones del estudiante 
                var institucionesDelEstudiante = _context.InstitucionEstudiante.Where( row => row.IdUsuario == usuario.IdUsuario);

                int[] institucionEstudianteList = new int[institucionesDelEstudiante.Count()] ;

                int contador = 0;
                foreach (var row in institucionesDelEstudiante)
                {
                    institucionEstudianteList[contador] = row.IdInstitucion;
                    contador++;                                                                        
                }

                // primero pregunto si tienen la misma cantidad de elementos comparo el tamaño de los arrays
                // verifico si las que vienen por parametro son las mismas que las que se encuentran actualmente en la tabla
                if(institucionEstudianteList.Length == usuario.IdInstitucion.Length){
                    
                    int coincidencias = institucionEstudianteList.Intersect(usuario.IdInstitucion).Count();
                    
                    // si los dos arrays tienen los mismo valores no hago nada
                    if(!(coincidencias == usuario.IdInstitucion.Length)){
                        // Si hay 0 coincidencias entonces modifico todo
                        int index = 0;
                        foreach (var row in institucionesDelEstudiante)
                        {
                            row.IdInstitucion = usuario.IdInstitucion[index];
                            index++;
                        }
                    } 
                // si las instituciones ingresadas superan a las actuales agrego la/s nueva/s
                }else if(institucionEstudianteList.Length < usuario.IdInstitucion.Length){ 
                    // verifico si las que ya estan registradas forman parte de las ingresadas
                    if(institucionEstudianteList.Intersect(usuario.IdInstitucion).Count() == institucionEstudianteList.Length){
                        // identifico los id de instituciones ingresadas no registradas
                        var idNoRegistradas = usuario.IdInstitucion.Except(institucionEstudianteList);
                        // agrego las restantes
                        foreach (var idInstitucion in idNoRegistradas)
                        {
                            var institucionEstudiante = new InstitucionEstudiante {IdInstitucion = idInstitucion, IdUsuario = usuario.IdPersona};
                            _context.InstitucionEstudiante.Add(institucionEstudiante);
                        }
                    }
                    
                }else{
                    // si las instituciones ingresadas es es menor a la existente entonces elimino las que ya no se encuentran
                    // obtengo las que tienen que ser eliminadas
                    var idAeliminar = institucionEstudianteList.Except(usuario.IdInstitucion);

                    foreach (var idInstitucion in idAeliminar)
                    {
                        var institucionEstudiante =  _context.InstitucionEstudiante.FirstOrDefault(item => item.IdInstitucion == idInstitucion && item.IdUsuario == usuario.IdPersona);
                        _context.InstitucionEstudiante.Remove(institucionEstudiante);
                    }
                    
                    // identifico los id de instituciones ingresadas no registradas y las registro
                    var idNoRegistradas = usuario.IdInstitucion.Except(institucionEstudianteList);

                    foreach (var idInstitucion in idNoRegistradas)
                    {
                        var institucionEstudiante = new InstitucionEstudiante {IdInstitucion = idInstitucion, IdUsuario = usuario.IdPersona};
                        _context.InstitucionEstudiante.Add(institucionEstudiante);
                    }
                }
  
                _context.SaveChanges();
        }
    }
}
