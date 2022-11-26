using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTimers.Models
{
    [Table("USUARIOS")]

    public class Usuario
    {
        [Key]
        [Column("IDUSUARIO")]
        public int IdUsuario { get; set; }
        [Column("USERNAME")]
        public string UserName { get; set; }
        [Column("PASS")]
        public string Password { get; set; }
    }
}
