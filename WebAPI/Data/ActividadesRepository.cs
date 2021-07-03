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

      
            var items = _context.PuntajeActividades.Where(p=>p.IdMateria == id).ToList();
           
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
            var items = _context.PuntajeActividades.Where(p=>p.IdEstudiante == idEstudiante && p.IdMateria == idMateria).ToList();
            double countActividades = items.Count();
            double countActividadesCompletas = items.Where(x=>x.Puntaje != null).Count();
            double avance = (countActividadesCompletas / countActividades)*100;
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
    }
}
