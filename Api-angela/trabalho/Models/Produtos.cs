using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace trabalho.Models
{
    public partial class Produtos
    {
        public Produtos()
        {
            Interesse = new HashSet<Interesse>();
        }

        [Key]
        [Column("id_produto")]
        public int IdProduto { get; set; }
        [Column("nome")]
        [StringLength(50)]
        public string Nome { get; set; }
        [Column("descricao")]
        [StringLength(250)]
        public string Descricao { get; set; }
        [Column("preco", TypeName = "money")]
        public decimal? Preco { get; set; }
        [Column("id_categoria")]
        public int? IdCategoria { get; set; }
        [Column("status_Compra")]
        public bool StatusCompra { get; set; }

        [ForeignKey(nameof(IdCategoria))]
        [InverseProperty(nameof(Categoria.Produtos))]
        public virtual Categoria IdCategoriaNavigation { get; set; }
        [InverseProperty("IdProdutoNavigation")]
        public virtual ICollection<Interesse> Interesse { get; set; }
    }
}
