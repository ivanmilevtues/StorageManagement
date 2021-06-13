using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManagement.Models
{
    public class Report: NotifiableModel
    {
        private int _freeSpace;
        public int FreeSpace 
        { 
            get => _freeSpace; 
            set
            {
                _freeSpace = value;
                OnPropertyChanged("FreeSpace");
            }
        }

        private int _takenSpace;
        public int TakenSpace
        {
            get => _takenSpace;
            set
            {
                _takenSpace = value;
                OnPropertyChanged("TakenSpace");
                FreeSpace = AllSpace - _takenSpace;
            }
        }

        private int _allSpace;
        public int AllSpace
        {
            get => _allSpace;
            set
            {
                _allSpace = value;
                OnPropertyChanged("AllSpace");
            }
        }

        private int _numberOfDeliveries;
        public int NumberOfDeliveries
        {
            get => _numberOfDeliveries;
            set
            {
                _numberOfDeliveries = value;
                OnPropertyChanged("NumberOfDeliveries");
            }
        }
    }
}
