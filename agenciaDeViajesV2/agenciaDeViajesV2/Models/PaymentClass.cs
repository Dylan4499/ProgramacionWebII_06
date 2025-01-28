using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace agenciaDeViajesV2.Models
{
    [Table("tbpayments")]
    public class PaymentClass
    {
        [Key]
        public int PK_payment { get; set; }

        [ForeignKey("Reserva")]
        public int? FK_offer { get; set; }

        public decimal? totalPrice { get; set; }

        [StringLength(20)]
        public string? paymentMethod { get; set; }

        [Required]
        public DateTime? createdAt { get; set; }

        public DateTime? updatedAt { get; set; }

        [Required]
        public int? states { get; set; } // 1 = 'Active', 0 = 'Inactive'

        public virtual OfferClass? Offer { get; set; }
    }
}
