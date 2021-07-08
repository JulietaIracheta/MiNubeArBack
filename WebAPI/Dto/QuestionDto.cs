using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Models.Quiz;

namespace WebAPI.Dto
{
    public class QuestionDto
    {
        public string Content { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual Actividades ActividadesQuiz { get; set; }
    }
}
