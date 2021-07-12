using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Dto;
using WebAPI.Models;

namespace WebAPI.Data
{
    public interface IActividadesRepository
    {
        double calcularAvanceActividadesMateria(int idEstudiante, int idMateria);
        public double calcularAvanceActividadesMateriaUnidad(int idEstudiante, int idMateria, int idUnidad);
        double calcularAvance(int id);
    }

    public class ActividadesRepository : IActividadesRepository
    {
        private readonly minubeDBContext _context;

        public ActividadesRepository(minubeDBContext context)
        {
            _context = context;
        }

        public double calcularAvance(int id)
        {


            var items = _context.PuntajeActividades.Where(p => p.IdMateria == id).ToList();

            double countActividades = items.Count();
            double countActividadesCompletas = items.Where(x => x.Puntaje != null).Count();
            double avance = (countActividadesCompletas / countActividades) * 100;
            if (countActividades != 0)
            {
                return avance;
            }
            else
            {
                return 0.0;
            }

        }

        public double calcularAvanceActividadesMateria(int idEstudiante, int idMateria)
        {
            var items = _context.PuntajeActividades.Where(p => p.IdEstudiante == idEstudiante && p.IdMateria == idMateria).ToList();
            double countActividades = items.Count();
            double countActividadesCompletas = items.Where(x => x.Puntaje != null).Count();
            double avance = (countActividadesCompletas / countActividades) * 100;
            return avance;
        }

        public double calcularAvanceActividadesMateriaUnidad(int idEstudiante, int idMateria, int idUnidad)
        {
            var items = _context.PuntajeActividades.Where(p => p.IdEstudiante == idEstudiante && p.IdMateria == idMateria && p.IdActividadPuntajeNavigation.Unidad == idUnidad).ToList();
            double countActividades = items.Count();
            double countActividadesCompletas = items.Where(x => x.Puntaje != null).Count();
            double avance = (countActividadesCompletas / countActividades) * 100;
            return avance;
        }

        public List<ActividadDto> getActividades(int idUsuario, int unidad, int materia)
        {

            List<ActividadDto> actividades = (from a in _context.Actividades
                                              join ac in _context.ActividadCurso on a.IdActividad equals ac.IdActividad
                                              join ec in _context.EstudianteCurso on ac.IdCurso equals ec.IdCurso
                                              join amu in _context.ActividadMateriaUnidad on ac.IdActividad equals amu.IdActividad
                                              where ec.IdUsuario == idUsuario
                                              && amu.Unidad == unidad
                                              && amu.IdMateria == materia
                                              select new ActividadDto
                                              (
                                                a.IdActividad,
                                                a.Titulo
                                              )).ToList();

            return actividades;
        }

        public List<ActividadMateriaDto> getActividadMateria(int idUsuario, int materia)
        {
            List<ActividadMateriaDto> actividades = (from a in _context.Actividades
                                            join ac in _context.ActividadCurso on a.IdActividad equals ac.IdActividad
                                            join ec in _context.EstudianteCurso on ac.IdCurso equals ec.IdCurso
                                            join amu in _context.ActividadMateriaUnidad on ac.IdActividad equals amu.IdActividad
                                            where ec.IdUsuario == idUsuario
                                            && amu.IdMateria == materia
                                            select new ActividadMateriaDto
                                            (
                                            amu.IdActividad,
                                            amu.Unidad,
                                            amu.Titulo
                                            )).ToList();

            return actividades;
        }
    }
}
