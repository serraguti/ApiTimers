using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiTimers.Models
{
    [Table("SALAS")]
    public class Sala
    {
        [Key]
        [Column("IDSALA")]
        public int IdSala { get; set; }
        [Column("SALA")]
        public string NombreSala { get; set; }
    }
}
