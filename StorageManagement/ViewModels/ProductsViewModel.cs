using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using DataBaseCommunication.DTO;
using StorageManagement.Models;
using StorageManagement.Services;

namespace StorageManagement.ViewModels
{
    public class ProductsViewModel: INotifyPropertyChanged
    {
        private readonly ProductService productService;

        private readonly ObservableCollection<Category> _categories;

        public ICollectionView Categories { get; }

        private readonly ObservableCollection<Product> _productsForCategory;

        public ICollectionView ProductsForCategory { get; }

        private readonly ObservableCollection<Details> _detailsForProduct;

        public ICollectionView DetailsForProduct { get; }

        public Category Category { get; set; }
        public Product Product { get; set; }
        public Details Details { get; set; }

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

        private Details _selectedDetails;
        public Details SelectedDetails
        {
            get => _selectedDetails;
            set
            {
                _selectedDetails = value;
                OnPropertyChanged("SelectedDetails");
            }
        }

        private string _categoryFilter = string.Empty;
        public string CategoryFilter 
        { 
            get => _categoryFilter; 
            set
            {
                _categoryFilter = value;
                OnPropertyChanged("CategoryFilter");
                Categories.Refresh();
            }
        }

        private string _productFilter = string.Empty;
        public string ProductFilter
        {
            get => _productFilter;
            set
            {
                _productFilter = value;
                OnPropertyChanged("ProductFilter");
                ProductsForCategory.Refresh();
            }
        }

        private DateTime? _startDate = null;
        private DateTime? _endDate = null;
        public DateTime? StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged("StartDate");
                DetailsForProduct.Refresh();
            }
        }

        public DateTime? EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged("EndDate");
                DetailsForProduct.Refresh();
            }
        }

        public ProductsViewModel(ProductService productService)
        {
            this.productService = productService;
            _categories = new ObservableCollection<Category>(productService.GetCategories());
            Categories = CollectionViewSource.GetDefaultView(_categories);
            Categories.Filter = FilterCategories;

            _productsForCategory = new ObservableCollection<Product>();
            ProductsForCategory = CollectionViewSource.GetDefaultView(_productsForCategory);
            ProductsForCategory.Filter = FilterProducts;

            _detailsForProduct = new ObservableCollection<Details>();
            DetailsForProduct = CollectionViewSource.GetDefaultView(_detailsForProduct);
            DetailsForProduct.Filter = FilterDetails;
        }

        private bool FilterCategories(object obj)
        {
            if(obj is Category category)
            {
                return category.Name.ToLower().Contains(CategoryFilter.ToLower());
            }
            return false;
        }

        private bool FilterProducts(object obj)
        {
            if (obj is Product product)
            {
                return product.Name.ToLower().Contains(ProductFilter.ToLower()) || product.Description.ToLower().Contains(ProductFilter.ToLower());
            }
            return false;
        }

        private bool FilterDetails(object obj)
        {
            if (obj is Details details)
            {
                if(StartDate != null && EndDate != null)
                {
                    return details.DeliveryDate >= StartDate && details.DeliveryDate <= EndDate;
                } 
                else if (StartDate != null)
                {
                    return details.DeliveryDate >= StartDate;
                } 
                else if(EndDate != null)
                {
                    return details.DeliveryDate <= EndDate;
                }
                return true;
            }
            return false;
        }

        private void LoadProducts()
        {
            _productsForCategory.Clear();
            productService.GetProducts(_selectedCategory.Name).ForEach(_productsForCategory.Add);
        }

        private void LoadProductDetails()
        {
            _detailsForProduct.Clear();
            if(_selectedProduct != null)
            {
                productService.GetDetails(_selectedProduct.Name).ForEach(_detailsForProduct.Add);
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
