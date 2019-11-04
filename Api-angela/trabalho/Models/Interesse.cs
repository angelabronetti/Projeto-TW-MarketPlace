using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace trabalho.Models
{
    public partial class Interesse
    {
        [Key]
        [Column("id_interesse")]
        public int IdInteresse { get; set; }
        [Column("id_usuario")]
        public int? IdUsuario { get; set; }
        [Column("id_produto")]
        public int? IdProduto { get; set; }
        [Column("status_Compra")]
        public bool StatusCompra { get; set; }

        [ForeignKey(nameof(IdProduto))]
        [InverseProperty(nameof(Produtos.Interesse))]
        public virtual Produtos IdProdutoNavigation { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.Interesse))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
