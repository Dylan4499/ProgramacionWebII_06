using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace agenciaDeViajesV2.Models
{
    [Table("tbrooms")]
    public class RoomClass
    {
        [Key]
        public int PK_room { get; set; }

        [ForeignKey("Hotel")]
        public int? FK_hotel { get; set; }

        [Required]
        public decimal? pricePerNight { get; set; }

        [Required]
        public int? capacity { get; set; }

        [Required]
        public DateTime? createdAt { get; set; }

        public DateTime? updatedAt { get; set; }

        [Required]
        public int? states { get; set; } // 1 = 'Active', 0 = 'Inactive'

        public virtual HotelClass? Hotel { get; set; }
    }
}
