using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseCommunication.Models
{
    class Product
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(40)]
        [Index(IsUnique = true)]
        public string ProductName { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public int Amount { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }

        public ICollection<ProductDetails> ProductDetails {get;set;}

    }
}
