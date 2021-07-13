using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class MateriaCalificacion
    {
        [Key]
        public int Id { get; set; }
        public string Materia { get; set; }
        public string Calificacion { get; set; }
    }
}
