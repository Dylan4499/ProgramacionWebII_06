using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace agenciaDeViajesV2.Models
{
    [Table("tbhotels")]
    public class HotelClass
    {
        [Key]
        public int PK_hotel { get; set; }

        [Required]
        [StringLength(100)]
        public string? hotelName { get; set; }

        [Required]
        [StringLength(100)]
        public string? addressAt { get; set; }

        [Range(1, 5)] 
        public int? stars { get; set; }

        [StringLength(255)]
        public string? imageHotel { get; set; }

        [Required]
        public DateTime? createdAt { get; set; }

        public DateTime? updatedAt { get; set; }

        [Required]
        public int? states { get; set; } // 1 = 'Active', 0 = 'Inactive'

        public ICollection<RoomClass>? Room { get; set; } // Relación con los cuartos
    }
}
