using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_End_Completo.Models
{
    public partial class ImgProduto
    {
        [Key]
        [Column("twmp_IdImgProduto")]
        public int TwmpIdImgProduto { get; set; }
        [Column("Twmp_Nome")]
        [StringLength(50)]
        public string TwmpNome { get; set; }
        [Column("twmp_CaminhoImg")]
        [StringLength(500)]
        public string TwmpCaminhoImg { get; set; }
        [Column("twmp_IdProduto")]
        public int? TwmpIdProduto { get; set; }

        [ForeignKey(nameof(TwmpIdProduto))]
        [InverseProperty(nameof(Produto.ImgProduto))]
        public virtual Produto TwmpIdProdutoNavigation { get; set; }
    }
}
