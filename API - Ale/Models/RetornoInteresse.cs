using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("Retorno_Interesse")]
    public partial class RetornoInteresse
    {
        [Key]
        [Column("id_retorno")]
        public int IdRetorno { get; set; }
        [Column("id_interesse")]
        public int? IdInteresse { get; set; }
        [Column("status_Interesse")]
        [StringLength(50)]
        public string StatusInteresse { get; set; }

        [ForeignKey(nameof(IdInteresse))]
        [InverseProperty(nameof(Interesse.RetornoInteresse))]
        public virtual Interesse IdInteresseNavigation { get; set; }
    }
}
