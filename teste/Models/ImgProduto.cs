using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace teste.Models
{
    public partial class ImgProduto
    {
        [Key]
        [Column("id_imgproduto")]
        public int IdImgproduto { get; set; }
        [Column("nome")]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required]
        [Column("caminho_img")]
        [StringLength(500)]
        public string CaminhoImg { get; set; }
        [Column("id_produto")]
        public int? IdProduto { get; set; }

        [ForeignKey(nameof(IdProduto))]
        [InverseProperty(nameof(Produtos.ImgProduto))]
        public virtual Produtos IdProdutoNavigation { get; set; }
    }
}
