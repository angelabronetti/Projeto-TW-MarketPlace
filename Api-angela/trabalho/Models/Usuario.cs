using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace trabalho.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Interesse = new HashSet<Interesse>();
        }

        [Key]
        [Column("id_usuario")]
        public int IdUsuario { get; set; }
        [Column("nome")]
        [StringLength(50)]
        public string Nome { get; set; }
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Column("senha")]
        [StringLength(10)]
        public string Senha { get; set; }
        [Column("id_permissao")]
        public int? IdPermissao { get; set; }

        [ForeignKey(nameof(IdPermissao))]
        [InverseProperty(nameof(Permissao.Usuario))]
        public virtual Permissao IdPermissaoNavigation { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Interesse> Interesse { get; set; }
    }
}
