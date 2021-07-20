using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class LogRepository
    {
        private readonly minubeDBContext _context;

        public void Crear(string mensaje)
        {
            Log log = new Log();

            log.MensajeError = mensaje;
            _context.Add(log);
            _context.SaveChanges();
        }
    }
}
