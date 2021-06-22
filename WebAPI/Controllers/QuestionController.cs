using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Models.Quiz;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : Controller
    {
        private QuizDataContext db = new QuizDataContext();

        [HttpGet]
        public List<Question> GetQuestions()
        {
            return db.Questions.Include(p => p.Answers).ToList();
        }

        [HttpGet("answers/{qid}")]
        public List<Answer> GetAnswers(int qid)
        {
            var answers =  db.Answers.Where(a => a.QuestionId == qid);
            return answers.ToList();
        }

        [HttpPost]
        public Question CreateQuestion(Question pregunta)
        {
            

            var a = new List<Answer>();
            foreach (var i in pregunta.Answers)
            {
                a.Add(i);
            }
            var q = new Question
            {
                Content = pregunta.Content,
                Answers = a
            };

            
            db.Questions.Add(q);
         
            db.SaveChanges();
            return q;
        }


     
    }
}
