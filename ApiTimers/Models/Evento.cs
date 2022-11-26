using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiTimers.Models
{
    [Table("EVENTOS")]
    public class Evento
    {
        [Key]
        [Column("IDEVENTO")]
        public int IdEvento { get; set; }
        [Column("EVENTO")]
        public string NombreEvento { get; set; }
        [Column("INICIOEVENTO")]
        public DateTime InicioEvento { get; set; }
        [Column("FINEVENTO")]
        public DateTime FinEvento { get; set; }
    }
}
