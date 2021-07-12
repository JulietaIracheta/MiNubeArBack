using System.Collections.Generic;
using WebAPI.Models;
using WebAPI.Models.Quiz;

namespace WebAPI.Dto
{
    public class CrearActividadDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int? ActividadesId { get; set; }

        public  Actividades ActividadesQuiz { get; set; }

        public  ICollection<Answer> Answers { get; set; }
        public int CursoId { get; set; }
    }
}
