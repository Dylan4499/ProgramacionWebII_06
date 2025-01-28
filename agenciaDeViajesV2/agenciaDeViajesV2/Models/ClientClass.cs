using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace agenciaDeViajesV2.Models
{

    [Table("tbclients")]
    public class ClientClass
    {
        [Key]
        public int PK_client { get; set; }

        [Required]
        [StringLength(100)]
        public string? firstName { get; set; }

        [Required]
        [StringLength(100)]
        public string? lastName { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string? email { get; set; }

        [StringLength(15)]
        public string? phoneNumber { get; set; }

        [StringLength(50)]
        public string? preferences { get; set; }

        [Required]
        public DateTime? createdAt { get; set; }

        public DateTime? updatedAt { get; set; }

        [Required]
        public int states { get; set; } // 1 = 'Active', 0 = 'Inactive'

        public ICollection<OfferClass>? Offer { get; set; }
    }
}
