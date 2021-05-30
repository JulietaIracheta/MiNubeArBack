using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Personas
    {
        public Personas()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }

        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
