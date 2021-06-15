using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseCommunication.Models
{
    class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        [Index(nameof(Username), IsUnique = true)]
        public string Username { get; set; }

        [Required]
        [StringLength(40)]
        public string Password { get; set; }

        public Role Role { get; set; } 
    }

    enum Role
    {
        Admin,
        Cashier,
        Supplier
    }
}
