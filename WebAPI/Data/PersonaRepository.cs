using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Dto;
using WebAPI.Models;

namespace WebAPI.Data
{
    public interface IPersonaRepository
    {
        List<PersonaDto> GetAll();
    }
    public class PersonaRepository : IPersonaRepository
    {
        private readonly minubeDBContext _context;

        public PersonaRepository(minubeDBContext context)
        {
            _context = context;
        }

        public List<PersonaDto> GetAll()
        {
            var persona = _context.Personas.Include(p => p.Usuarios).ThenInclude(p => p.UsuarioRol)
                .ThenInclude(p => p.IdRolNavigation)
                .Where(p => p.Usuarios.All(u => !u.FechaEliminacionLogico.HasValue));
            var list = persona.Select(p => new PersonaDto
            {
                Apellido = p.Apellido,
                Email = p.Email,
                IdPersona = p.IdPersona,
                IdUsuario = p.Usuarios.First().IdUsuario,
                Nombre = p.Nombre,
                UsuarioNombre = p.Usuarios.First().UsuarioNombre,
                Telefono = p.Telefono,
                Rol = p.Usuarios.First().UsuarioRol.First().IdRolNavigation.Descripcion,
            });

            return list.ToList();
            
        }
        public PersonaDto GetPersona(int id)
        {
            var persona= _context.Personas.FirstOrDefault(p =>p.IdPersona==id);
            if (persona == null)
                throw new Exception("Usuario no encontrado");
            return new PersonaDto
            {
                Apellido = persona.Apellido, IdPersona = persona.IdPersona, IdUsuario = persona.IdPersona,
                Nombre = persona.Nombre
            };
        }

        public List<PersonaDto> GetEstudiantesAsignados(int id)
        {
            var persona = _context.Personas.Where(p => p.Usuarios.First().UsuarioRol.Any(ur => ur.IdRol == 1))
                .Select(p => new PersonaDto {Apellido = p.Apellido, Nombre = p.Nombre, IdPersona = p.IdPersona})
                .ToList();

            return persona;
        }

        public List<PersonaDto> GetEstudiantesCurso(int id)
        {
            var persona = _context.Personas.Where(p => p.Usuarios.First().EstudianteCurso.Any(ur => ur.IdCurso == id))
                .Select(p => new PersonaDto {Apellido = p.Apellido, Nombre = p.Nombre, IdPersona = p.IdPersona})
                .ToList();

            return persona;
        }
    }
}
