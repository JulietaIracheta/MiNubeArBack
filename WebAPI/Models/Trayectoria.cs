using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Trayectoria
    {
        public Trayectoria()
        {
            Calificaciones = new HashSet<MateriaCalificacion>();
         }

        public int Id { get; set; }
        public int IdInforme { get; set; }
        public int Año { get; set; }
        public string Materia { get; set; }
        public string Calificacion{ get; set; }
        
        public virtual Informes IdInformeNavigation { get; set; }
        public virtual ICollection<MateriaCalificacion> Calificaciones { get; set; }
    }
}
