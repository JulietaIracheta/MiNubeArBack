
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebAPI.Data;

namespace WebAPI.Helpers
{
    public static class FileHelper
    {        

        public static string GuardarVideo(string contentRootPath, IFormFile file)
        {
            var path = Path.Combine(contentRootPath, "videos\\");

            var nombreConHoras = string.Format("{0} {1}", DateTime.Now.ToString("_MMddyyyy_HHmmss"), file.FileName);

            var fileName = Path.GetFileName(nombreConHoras);

            var stream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
            try
            {
                file.CopyTo(stream);
            }
            catch (Exception ex)
            {
                LogRepository log = new LogRepository();
                log.Crear(ex.Message);
            }
            

            return fileName;
        }
        public static string GuardarAvatar(string contentRootPath, IFormFile file)
        {
            var path = Path.Combine(contentRootPath, "Avatares\\");

            var nombreConHoras = string.Format("{0} {1}", DateTime.Now.ToString("_MMddyyyy_HHmmss"), file.FileName);

            var fileName = Path.GetFileName(nombreConHoras);

            var stream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
            file.CopyTo(stream);

            return fileName;
        }
        public static string GuardarInforme(string contentRootPath, IFormFile file)
        {
            var path = Path.Combine(contentRootPath, "informes\\");

            var fileName = Path.GetFileName(file.FileName);

            var stream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
            file.CopyTo(stream);

            return fileName;
        }
    }
}