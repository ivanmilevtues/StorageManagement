using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseCommunication.Models
{
    class ProductDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime DeliveryDate { get; set; }

        public DateTime ProductionDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public bool IsInDelivery { get; set; }

        public int Amount { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
