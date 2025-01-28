using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace agenciaDeViajesV2.Models
{
    [Table("tbseats")]
    public class SeatClass
    {
        [Key]
        public int PK_seat { get; set; }

        [Required]
        public int FK_fly { get; set; } // Relación con FlyClass

        [Required]
        public int FK_offer { get; set; } // Relación con FlyClass

        [Required]
        [StringLength(10)]
        public string? seatNumber { get; set; } // Número del asiento

        [Required]
        public bool? reserState { get; set; } // Indica si el asiento está disponible

        [Required]
        public DateTime? createdAt { get; set; }

        public DateTime? updatedAt { get; set; }

        [Required]
        public int states { get; set; } // 1 = 'Active', 0 = 'Inactive'

        [ForeignKey("FK_fly")]
        public FlyClass? Fly { get; set; } // Relación con FlyClass

        [ForeignKey("FK_offer")]
        public OfferClass? Offer { get; set; } // Relación con FlyClass
    }
}
