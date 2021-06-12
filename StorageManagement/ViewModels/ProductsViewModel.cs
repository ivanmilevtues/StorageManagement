using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using DataBaseCommunication.DTO;
using StorageManagement.Models;
using StorageManagement.Services;

namespace StorageManagement.ViewModels
{
    public class ProductsViewModel: INotifyPropertyChanged
    {
        private readonly ProductService productService;

        public ObservableCollection<Category> Categories { get; set; }

        public ObservableCollection<Product> ProductsForCategory { get; set; }

        public ObservableCollection<Details> DetailsForProduct { get; set; }

        private Category _selectedCategory;

        public Category SelectedCategory {
            get => _selectedCategory; 
            set 
            {
                _selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
                LoadProducts();
            }
        }

        private Product _selectedProduct;

        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
                LoadProductDetails();
            }
        }

        public ProductsViewModel(ProductService productService)
        {
            this.productService = productService;
            Categories = new ObservableCollection<Category>(productService.GetCategories());
            ProductsForCategory = new ObservableCollection<Product>();
            DetailsForProduct = new ObservableCollection<Details>();
        }

        private void LoadProducts()
        {
            ProductsForCategory.Clear();
            productService.GetProducts(_selectedCategory.Name).ForEach(ProductsForCategory.Add);
        }

        private void LoadProductDetails()
        {
            DetailsForProduct.Clear();
            if(_selectedProduct != null)
            {
                productService.GetDetails(_selectedProduct.Name).ForEach(DetailsForProduct.Add);
            }
        }


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }
}
