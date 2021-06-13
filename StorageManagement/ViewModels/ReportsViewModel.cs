using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using DataBaseCommunication.DTO;
using StorageManagement.Commands;
using StorageManagement.Models;
using StorageManagement.Security.Attributes;
using StorageManagement.Services;

namespace StorageManagement.ViewModels
{
    public class ReportsViewModel: AbstractViewModel
    {
        private readonly ReportService reportService;

        public UserDTO LoggedUser { get; set; }


        private Report _report;
        public Report Report 
        { 
            get => _report; 
            set
            {
                _report = value;
                OnPropertyChanged("Report");
            }
        }

        public ReportForm Form { get; set; }

        private int _selected;
        public int SelectedIndex { 
            get => _selected; 
            set
            {
                _selected = value;
                if(value > 0)
                {
                    Form.CategoryName = CategoryNames[value];
                }
                else
                {
                    Form.CategoryName = string.Empty;
                }
                ProductsView.Refresh();
            }
        }

        public List<string> CategoryNames { get; set; }

        private ObservableCollection<ProductDTO> _products;

        public ICollectionView ProductsView { get; set; }

        public ReportsViewModel(ProductService productService, StateService state, ReportService reportService)
        {
            this.reportService = reportService;
            LoggedUser = state.User;

            Form = new ReportForm();

            CategoryNames = productService.GetCategories().Select(c => c.Name).ToList();
            CategoryNames.Insert(0, "Всички категории");

            _products = new ObservableCollection<ProductDTO>(productService.GetProductDTOs());

            ProductsView = new ListCollectionView(_products)
            {
                Filter = FilterProducts
            };
        }

        private bool FilterProducts(object obj)
        {
            if(obj is ProductDTO)
            {
                var product = obj as ProductDTO;
                return string.IsNullOrEmpty(Form.CategoryName) || product.ProductCategories.Where(pc => pc.Name == Form.CategoryName).Any();
            }

            return false;
        }

        public ICommand CreateReportCommand { get => new PermissionRequiredCommand(CreateReport, LoggedUser.Role); }

        [PermissionRequired(RoleDTO.Admin)]
        private  void CreateReport()
        {
            Report = reportService.GenerateReport(Form);
        }
    }
}
