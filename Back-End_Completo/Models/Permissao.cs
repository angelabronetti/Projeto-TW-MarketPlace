using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_End_Completo.Models
{
    public partial class Permissao
    {
        public Permissao()
        {
            Usuario = new HashSet<Usuario>();
        }

        [Key]
        [Column("twmp_IdPermissao")]
        public int TwmpIdPermissao { get; set; }
        [Column("twmp_TipoUsuario")]
        [StringLength(50)]
        public string TwmpTipoUsuario { get; set; }

        [InverseProperty("TwmpIdPermissaoNavigation")]
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
