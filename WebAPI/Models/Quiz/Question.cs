using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Quiz
{   
    [Table("Question")]
    public class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
            
        }

        public int Id { get; set; }
        public string Content { get; set; }
        public int? ActividadesId { get; set; }

        public virtual Actividades ActividadesQuiz { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
       
    }
}
