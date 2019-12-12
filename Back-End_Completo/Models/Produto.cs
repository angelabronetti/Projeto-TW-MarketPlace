using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_End_Completo.Models
{
    public partial class Produto
    {
        public Produto()
        {
            ImgProduto = new HashSet<ImgProduto>();
            Interesse = new HashSet<Interesse>();
        }

        [Key]
        [Column("twmp_IdProduto")]
        public int TwmpIdProduto { get; set; }
        [Column("twmp_Nome")]
        [StringLength(50)]
        public string TwmpNome { get; set; }
        [Column("twmp_Descricao")]
        [StringLength(250)]
        public string TwmpDescricao { get; set; }
        [Column("twmp_Preco", TypeName = "money")]
        public decimal? TwmpPreco { get; set; }
        [Column("twmp_IdCategoria")]
        public int? TwmpIdCategoria { get; set; }
        [Column("twmp_StatusCompra")]
        public bool TwmpStatusCompra { get; set; }

        [ForeignKey(nameof(TwmpIdCategoria))]
        [InverseProperty(nameof(Categoria.Produto))]
        public virtual Categoria TwmpIdCategoriaNavigation { get; set; }
        [InverseProperty("TwmpIdProdutoNavigation")]
        public virtual ICollection<ImgProduto> ImgProduto { get; set; }
        [InverseProperty("TwmpIdProdutoNavigation")]
        public virtual ICollection<Interesse> Interesse { get; set; }
    }
}
