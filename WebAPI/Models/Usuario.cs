using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Usuario
    {
        [Key]
        public int id { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        public string rol { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        public string nombre { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string apellido { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string email { get; set; }

        public int edad { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string direccion { get; set; }
    }
}
