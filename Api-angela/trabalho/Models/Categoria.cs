using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace trabalho.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Produtos = new HashSet<Produtos>();
        }

        [Key]
        [Column("id_categoria")]
        public int IdCategoria { get; set; }
        [Column("categoria_Produto")]
        [StringLength(50)]
        public string CategoriaProduto { get; set; }

        [InverseProperty("IdCategoriaNavigation")]
        public virtual ICollection<Produtos> Produtos { get; set; }
    }
}
