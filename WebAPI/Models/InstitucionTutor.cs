using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class InstitucionTutor
    {
        public int IdInstitucionTutor { get; set; }
        public int IdInstitucion { get; set; }
        public int IdTutor { get; set; }

        public virtual Instituciones IdInstitucionNavigation { get; set; }
        public virtual Usuarios IdTutorNavigation { get; set; }
    }
}
