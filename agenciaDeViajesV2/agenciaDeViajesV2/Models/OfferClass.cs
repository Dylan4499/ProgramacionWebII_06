using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace agenciaDeViajesV2.Models
{
    [Table("tboffers")]
    public class OfferClass
    {
        [Key]
        public int PK_offer { get; set; }

        [ForeignKey("Room")]
        public int FK_room { get; set; }

        [ForeignKey("Client")]
        public int FK_client { get; set; }

        [ForeignKey("Activity")]
        public int FK_activity { get; set; }

        [Required]
        [StringLength(100)]
        public string? Destiny { get; set; }

        [Required]
        public int DistanceDays { get; set; }

        [Required]
        public decimal totalPrice { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [Required]
        public int? states { get; set; } // 1 = 'Active', 0 = 'Inactive'

        // Relaciones
        public virtual RoomClass? Room { get; set; }
        public virtual ClientClass? Client { get; set; }
        public virtual ActivityClass? Activity { get; set; }
    }
}

