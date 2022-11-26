using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTimers.Models
{
    [Table("TEMPORIZADORES")]
    public class Temporizador
    {
        [Key]
        [Column("IDTIMER")]
        public int IdTemporizador { get; set; }
        [Column("INICIO")]
        public DateTime Inicio { get; set; }
        [Column("IDCATEGORIA")]
        public int IdCategoria { get; set; }
        [Column("PAUSA")]
        public bool Pausa { get; set; }
    }
}
