using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Quiz
{
    [Table("Answer")]
    public class Answer
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool? Correct { get; set; }
        public int? QuestionId { get; set; }

        public virtual Question Question { get; set; }
    }
}
