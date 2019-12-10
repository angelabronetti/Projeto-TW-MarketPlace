using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_End_Completo.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Interesse = new HashSet<Interesse>();
        }

        [Key]
        [Column("twmp_IdUsuario")]
        public int TwmpIdUsuario { get; set; }
        [Column("twmp_Nome")]
        [StringLength(50)]
        public string TwmpNome { get; set; }
        [Column("twmp_Email")]
        [StringLength(50)]
        public string TwmpEmail { get; set; }
        [Column("Twmp_Senha")]
        [StringLength(10)]
        public string TwmpSenha { get; set; }
        [Column("Twmp_ImgUsuario")]
        [StringLength(500)]
        public string TwmpImgUsuario { get; set; }
        [Column("twmp_IdPermissao")]
        public int? TwmpIdPermissao { get; set; }

        [ForeignKey(nameof(TwmpIdPermissao))]
        [InverseProperty(nameof(Permissao.Usuario))]
        public virtual Permissao TwmpIdPermissaoNavigation { get; set; }
        [InverseProperty("TwmpIdUsuarioNavigation")]
        public virtual ICollection<Interesse> Interesse { get; set; }
    }
}
