using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataBaseCommunication.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Username { get; set; }
        
        public string Password { get; set; }
        
        public Role Role { get; set; } 
    }

    public enum Role
    {
        Admin,
        Cashier,
        Loader,
        User
    }
}
