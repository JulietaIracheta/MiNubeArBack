using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebAPI.Helpers
{
    public static class FileHelper2
    {
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


