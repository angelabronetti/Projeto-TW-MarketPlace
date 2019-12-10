using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_End_Completo.Models
{
    public partial class Interesse
    {
        [Key]
        [Column("twmp_IdInteresse")]
        public int TwmpIdInteresse { get; set; }
        [Column("twmp_IdUsuario")]
        public int? TwmpIdUsuario { get; set; }
        [Column("twmp_IdProduto")]
        public int? TwmpIdProduto { get; set; }
        [Required]
        [Column("twmp_InteresseCompra")]
        public bool? TwmpInteresseCompra { get; set; }
        [Column("twmp_StatusCompra")]
        public bool TwmpStatusCompra { get; set; }

        [ForeignKey(nameof(TwmpIdProduto))]
        [InverseProperty(nameof(Produto.Interesse))]
        public virtual Produto TwmpIdProdutoNavigation { get; set; }
        [ForeignKey(nameof(TwmpIdUsuario))]
        [InverseProperty(nameof(Usuario.Interesse))]
        public virtual Usuario TwmpIdUsuarioNavigation { get; set; }
    }
}
