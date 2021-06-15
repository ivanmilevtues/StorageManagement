using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseCommunication.Models
{
    class ProductCategory
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
