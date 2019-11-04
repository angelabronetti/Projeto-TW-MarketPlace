using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace trabalho.Models
{
    public partial class Permissao
    {
        public Permissao()
        {
            Usuario = new HashSet<Usuario>();
        }

        [Key]
        [Column("id_permissao")]
        public int IdPermissao { get; set; }
        [Column("tipo_Usuario")]
        [StringLength(50)]
        public string TipoUsuario { get; set; }

        [InverseProperty("IdPermissaoNavigation")]
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
