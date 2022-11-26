using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTimers.Models
{
    [Table("TIEMPOS_EVENTOS")]
    public class TimerEvento
    {
        [Key]
        [Column("UNIQUEID")]
        public int UniqueId { get; set; }
        [Column("IDEMPRESA")]
        public int IdEmpresa { get; set; }

        [Column("IDTIMER")]
        public int IdTimer { get; set; }
        [Column("IDSALA")]
        public int IdSala { get; set; }
        [Column("IDEVENTO")]
        public int IdEvento { get; set; }

        [Column("IDCATEGORIA")]
        public int IdCategoria { get; set; }
        [Column("INICIO")]
        public DateTime InicioTimer { get; set; }
        [Column("PAUSA")]
        public bool PausaTimer {get;set;}
        [Column("CATEGORIA")]
        public string Categoria { get; set; }
        [Column("DURACION")]
        public int Duracion { get; set; }
        [Column("SALA")]
        public String Sala { get; set; }
        [Column("EVENTO")]
        public string Evento { get; set; }
        [Column("INICIOEVENTO")]
        public DateTime InicioEvento { get; set; }
        [Column("FINEVENTO")]
        public DateTime FinEvento { get; set; }
        [Column("EMPRESA")]
        public string Empresa { get; set; }
        [Column("IMAGEN")]
        public string ImagenEmpresa { get; set; }

    }
}
