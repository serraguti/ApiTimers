using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTimers.Models
{
    [Table("CATEGORIAS_TIMER")]
    public class CategoriaTimer
    {
        [Key]
        [Column("IDCATEGORIA")]
        public int IdCategoria { get; set; }
        [Column("CATEGORIA")]
        public string Categoria { get; set; }
        [Column("DURACION")]
        public int Duracion { get; set; }

    }
}
