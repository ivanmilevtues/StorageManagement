using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManagement.Models
{
    public class Report: NotifiableModel
    {
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("ReportName");
            }
        }

        private int _addedItems = 0;
        public int AddedItems 
        { 
            get => _addedItems; 
            set
            {
                _addedItems = value;
                OnPropertyChanged("AddedItems");
            }
        }

        private int _removedItems = 0;
        public int RemovedItems
        {
            get => _removedItems;
            set
            {
                _removedItems = value;
                OnPropertyChanged("RemovedItems");
            }
        }

        private int _numberOfDeliveries = 0;
        public int NumberOfDeliveries
        {
            get => _numberOfDeliveries;
            set
            {
                _numberOfDeliveries = value;
                OnPropertyChanged("NumberOfDeliveries");
            }
        }


        private int _numberOfDeliveryIns = 0;
        public int NumberOfDeliveryIns
        {
            get => _numberOfDeliveryIns;
            set
            {
                _numberOfDeliveryIns = value;
                OnPropertyChanged("NumberOfDeliveries");
            }
        }


        private int _numberOfDeliveryOuts = 0;
        public int NumberOfDeliveryOuts
        {
            get => _numberOfDeliveryOuts;
            set
            {
                _numberOfDeliveryOuts = value;
                OnPropertyChanged("NumberOfDeliveries");
            }
        }
    }
}
