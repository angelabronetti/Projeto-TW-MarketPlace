using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_End_Completo.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Produto = new HashSet<Produto>();
        }

        [Key]
        [Column("twmp_IdCategoria")]
        public int TwmpIdCategoria { get; set; }
        [Column("twmp_CategoriaProduto")]
        [StringLength(50)]
        public string TwmpCategoriaProduto { get; set; }

        [InverseProperty("TwmpIdCategoriaNavigation")]
        public virtual ICollection<Produto> Produto { get; set; }
    }
}
