using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTimers.Models
{
    [Table("TIEMPOS_EMPRESAS_SALAS")]
    public class TiempoEmpresaSala
    {
        [Key]
        [Column("UNIQUEID")]
        public int Id { get; set; }
        [Column("IDTIMER")]
        public int IdTimer { get; set; }
        [Column("IDEMPRESA")]
        public int IdEmpresa { get; set; }
        [Column("IDSALA")]
        public int IdSala { get; set; }
        [Column("IDEVENTO")]
        public int IdEvento { get; set; }
    }
}
