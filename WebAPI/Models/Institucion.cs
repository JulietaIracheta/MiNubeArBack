using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class Institucion
    {
        [Key]
        public int id { get; set; }


        [Column(TypeName ="nvarchar(100)")]
        public string nombre { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string email { get; set; }
    }
}
