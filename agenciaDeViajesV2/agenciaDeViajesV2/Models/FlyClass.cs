using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace agenciaDeViajesV2.Models
{

    [Table("tbflies")]
    public class FlyClass
    {
        [Key]
        public int PK_fly { get; set; }

        [Required]
        [StringLength(100)]
        public string? airline { get; set; }

        [Required]
        [StringLength(100)]
        public string? sailsIn { get; set; }

        [Required]
        [StringLength(100)]
        public string? arrivesIn { get; set; }

        [Required]
        public DateTime? sailsAt { get; set; }

        [Required]
        public DateTime? arrivesExpected { get; set; }

        [Required]
        public decimal? pricePerSeat { get; set; }

        [Required]
        public DateTime createdAt { get; set; }

        public DateTime? updatedAt { get; set; }

        [Required]
        public int states { get; set; } // 1 = 'Active', 0 = 'Inactive'

        public ICollection<SeatClass>? Seat { get; set; }
    }
}
