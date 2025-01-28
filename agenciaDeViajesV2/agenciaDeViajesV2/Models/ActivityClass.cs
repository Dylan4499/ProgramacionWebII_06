using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace agenciaDeViajesV2.Models
{
    [Table("tbactivities")]
    public class ActivityClass
    {
        [Key]
        public int PK_activity { get; set; }

        [Required]
        [StringLength(100)]
        public string? actName { get; set; }

        [Required]
        public decimal? price { get; set; }

        [StringLength(100)]
        public string? details { get; set; }

        [Required]
        public DateTime? createdAt { get; set; }

        public DateTime? updatedAt { get; set; }

        [Required]
        public int states { get; set; } // 1 = 'Active', 0 = 'Inactive'

        public ICollection<OfferClass>? Offer { get; set; }
    }
}
