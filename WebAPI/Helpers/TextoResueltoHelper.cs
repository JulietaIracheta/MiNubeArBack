using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Helpers
{
    public class TextoResueltoHelper
    {
        public static string ObtenerTextoDeResultado(int res)
        {
            var texto = "";
            if (res == 100)
                texto = "Al dia";
            else if (res < 50 && res > 0)
                texto = "Ponerse al dia";
            else if (res >= 50 && res < 100)
                texto = "Al dia pero falta";
            else
                texto = "Sin ver";
            return texto;
        }
        public static string ObtenerTextoDeResultadoActividades(int res)
        {
            var texto = "";
            if (res == 100)
                texto = "Sobresaliente";
            else if (res < 50 && res > 0)
                texto = "Bueno";
            else if (res >= 50 && res < 100)
                texto = "Regular";
            else
                texto = "Insuficiente";
            return texto;
        }
    }
}
