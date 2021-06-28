using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Dto;
using WebAPI.Models;

namespace WebAPI.Data
{
    public interface IQuestionRepository
    {
        List<QuestionDto> GeActividadestByCurso(int curso, int unidad);
    }
    public class QuestionRepository : IQuestionRepository
    {
        private readonly minubeDBContext _context;

        public QuestionRepository(minubeDBContext context)
        {
            _context = context;
        }
        public List<QuestionDto> GeActividadestByCurso(int curso, int unidad)
        {
            IQueryable<QuestionDto> questions = from a in _context.Answers
                                                         join q in _context.Questions on a.QuestionId equals q.Id
                                                         join act in _context.Actividades on q.ActividadesId equals act.IdActividad
                                                         join ac in _context.ActividadCurso on act.IdActividad equals ac.IdActividad
                                                         join ec in _context.EstudianteCurso on ac.IdCurso equals ec.IdCurso
                                                         where ec.IdCurso == curso && act.Unidad == unidad
                                                         select new QuestionDto
                                                         {
                                                             Content = q.Content,
                                                             Answers = q.Answers,
                                                             
                                                         };

            return questions.ToList();
        }
        }
    }
