using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManagement.Models
{
    public class Product: NotifiableModel
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

        private string _decription;
        public string Description
        {
            get => _decription;
            set
            {
                _decription = value;
                OnPropertyChanged("Description");
            }
        }

        private int _amount;
        public int Amount 
        { 
            get => _amount;
            set
            {
                _amount = value;
                OnPropertyChanged("Amount");
            }
        }
    }
}
