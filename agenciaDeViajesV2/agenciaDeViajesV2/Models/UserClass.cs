using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace agenciaDeViajesV2.Models
{
    [Table("tbusers")]
    public class UserClass
    {
        [Key]
        public int PK_user { get; set; }

        [ForeignKey("Role")]
        public int? FK_rol { get; set; }

        [Required]
        [StringLength(100)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string? LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(15)]
        public string? PhoneNumber { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [Required]
        public int? states { get; set; } // 1 = 'Active', 0 = 'Inactive'

        // Relación con Roles
        public RoleClass? Role { get; set; }
    }
}
