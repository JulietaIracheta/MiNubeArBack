using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Dto;
using WebAPI.Models;
using WebAPI.Models.Quiz;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : Controller
    {
        private readonly minubeDBContext _context;
        private readonly QuestionRepository _questionRepository;

        public QuestionController(minubeDBContext context)
        {
            _context = context;
            _questionRepository =new QuestionRepository(context);

        }

        [HttpGet]
        public List<Question> GetQuestions()
        {
            return _context.Questions.Include(p => p.Answers).ToList();
        }
        [HttpGet("{id}")]
        public List<Question> GetQuestionsById(int id)
        {
            return _context.Questions.Include(p => p.Answers).Where(a=>a.ActividadesQuiz.Unidad == id).ToList();
        }

        [HttpGet("{curso}/{unidad}")]
        public List<QuestionDto> GetQuestionsByU(int curso, int unidad)
        {
            return _questionRepository.GeActividadestByCurso(curso, unidad);
        }
        
        [HttpPost]
        public Question CreateQuestion(Question pregunta)
        {
            var act = new Actividades
            {
                Unidad = pregunta.ActividadesQuiz.Unidad,
                Titulo = pregunta.ActividadesQuiz.Titulo,
                Descripcion = pregunta.ActividadesQuiz.Descripcion,
                IdMateria = pregunta.ActividadesQuiz.IdMateria,
                IdContenido = pregunta.ActividadesQuiz.IdContenido
            };
           

            var answer = new List<Answer>();
            foreach (var i in pregunta.Answers)
            {
                answer.Add(i);
            }
            var question = new Question
            {
                Content = pregunta.Content,
                Answers = answer,
                ActividadesQuiz = act
            };

            _context.Actividades.Add(act);
            _context.Questions.Add(question);
            _context.SaveChanges();
            return question;
        }


     
    }
}
