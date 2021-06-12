using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManagement.Models
{
    public class Category : NotifiableModel
    {
        private string _name;
        public string Name 
        { 
            get => _name; 
            set 
            {
                _name = value;
                OnPropertyChanged("Name");
            } 
        }
    }
}
