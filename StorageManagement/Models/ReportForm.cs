using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseCommunication.DTO;

namespace StorageManagement.Models
{
    public class ReportForm
    {
        private string _categoryName;
        public string CategoryName 
        {
            get => _categoryName ?? NotSetValue;
            set => _categoryName = value;
        }

        private ProductDTO _product;

        public ProductDTO Product
        {
            get => _product;
            set
           {
                _product = value;
                _productName = value.Name;
            }
        }

        private string _productName;
        public string ProductName 
        {
            get => _productName ?? NotSetValue;
            set => _productName = value;
        }

        private DateTime? _startDate;
        public DateTime StartDate 
        {
            get => _startDate ?? DateTime.MinValue;
            set => _startDate = value; 
        }

        private DateTime? _endDate;
        public DateTime EndDate
        {
            get => _endDate ?? DateTime.MaxValue;
            set => _endDate = value;
        }

        public static string NotSetValue { get => "Всички"; }
    }
}
