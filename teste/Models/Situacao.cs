﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace teste.Models
{
    public partial class Situacao
    {
        [Key]
        [Column("id_Situacao")]
        public int IdSituacao { get; set; }
    }
}
