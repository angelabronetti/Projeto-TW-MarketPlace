using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class ImgProdutos
    {
        [Key]
        [Column("id_imgproduto")]
        public int Id { get; set; }
        [Column("nome")]
        [StringLength(50)]
        public string Nome { get; set; }
        [Column("caminho_img")]
        [StringLength(500)]
        public string Caminho_img { get; set; }
        [Column("id_produto")]
        public int? IdProduto { get; set; }

        [ForeignKey(nameof(IdProduto))]
        [InverseProperty(nameof(Produtos.ImgProdutos))]
        public virtual Produtos IdProdutoNavigation { get; set; }
    }
}