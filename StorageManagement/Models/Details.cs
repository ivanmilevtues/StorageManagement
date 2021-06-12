using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManagement.Models
{
    public class Details: NotifiableModel
    {
        private DateTime _deliveryDate;
        public DateTime DeliveryDate
        {
            get => _deliveryDate;
            set
            {
                _deliveryDate = value;
                OnPropertyChanged("DeliveryDate");
            }
        }

        private DateTime _productionDate;
        public DateTime ProductionDate
        {
            get => _productionDate;
            set
            {
                _productionDate = value;
                OnPropertyChanged("ProductionDate");
            }
        }

        private DateTime? _expirationDate;
        public DateTime? ExpirationDate
        {
            get => _expirationDate;
            set
            {
                _expirationDate = value;
                OnPropertyChanged("ExpirationDate");
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
