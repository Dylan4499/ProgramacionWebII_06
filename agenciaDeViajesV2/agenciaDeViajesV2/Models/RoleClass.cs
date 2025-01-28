using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace agenciaDeViajesV2.Models
{
    [Table("tbroles")]
    public class RoleClass
    {
        [Key]
        public int PK_rol { get; set; }

        [Required]
        [StringLength(20)]
        public string? RolName { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [Required]
        public int? states { get; set; } // 1 = 'Active', 0 = 'Inactive'

        // Relación inversa: Usuarios asociados a este rol
        public ICollection<UserClass>? User { get; set; }
    }
}
