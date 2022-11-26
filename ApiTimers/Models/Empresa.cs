using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiTimers.Models
{
    [Table("EMPRESAS")]
    public class Empresa
    {
        [Key]
        [Column("IDEMPRESA")]
        public int IdEmpresa { get; set; }
        [Column("EMPRESA")]
        public string NombreEmpresa { get; set; }
        [Column("IMAGEN")]
        public string Imagen { get; set; }
    }
}
