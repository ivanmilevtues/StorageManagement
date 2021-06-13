using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Windows.Input;
using DataBaseCommunication.DTO;
using StorageManagement.Commands;
using StorageManagement.Models;
using StorageManagement.Security.Attributes;
using StorageManagement.Services;

namespace StorageManagement.ViewModels
{
    public class ProductsViewModel: INotifyPropertyChanged
    {
        private readonly ProductService productService;
        private readonly StateService state;
        private readonly ObservableCollection<Category> _categories;

        public ICollectionView Categories { get; }

        private readonly ObservableCollection<Product> _productsForCategory;

        public ICollectionView ProductsForCategory { get; }

        private readonly ObservableCollection<Details> _detailsForProduct;

        public ICollectionView DetailsForProduct { get; }

        public Category Category { get; set; }
        public Product Product { get; set; }
        public Details Details { get; set; }

        public UserDTO LoggedUser { get; set; }

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

        public ProductsViewModel(ProductService productService, StateService state)
        {
            this.productService = productService;
            this.state = state;

            _categories = new ObservableCollection<Category>(productService.GetCategories());
            Categories = CollectionViewSource.GetDefaultView(_categories);
            Categories.Filter = FilterCategories;

            _productsForCategory = new ObservableCollection<Product>();
            ProductsForCategory = CollectionViewSource.GetDefaultView(_productsForCategory);
            ProductsForCategory.Filter = FilterProducts;

            _detailsForProduct = new ObservableCollection<Details>();
            DetailsForProduct = CollectionViewSource.GetDefaultView(_detailsForProduct);
            DetailsForProduct.Filter = FilterDetails;

            Category = new Category();
            Product = new Product();
            Details = new Details() { DeliveryDate = DateTime.Today, ProductionDate = DateTime.Today};

            LoggedUser = state.User;
        }

        public ICommand UpdateCategoryCommand { get => new PermissionRequiredCommand(UpdateCategory, state.User.Role); }
        public ICommand CreateCategoryCommand { get => new PermissionRequiredCommand(CreateCategory, state.User.Role); }
        public ICommand UpdateProductCommand { get => new PermissionRequiredCommand(UpdateProduct, state.User.Role); }
        public ICommand CreateProductCommand { get => new PermissionRequiredCommand(CreateProduct, state.User.Role); } 
        public ICommand DeliveryInCommand { get => new PermissionRequiredCommand(DeliveryIn, state.User.Role); }
        public ICommand DeliveryOutCommand { get => new PermissionRequiredCommand(DeliveryOut, state.User.Role); }
      
        [PermissionRequired(RoleDTO.Admin)]
        private void UpdateCategory()
        {
            productService.UpdateCategory(SelectedCategory, Category);
            SelectedCategory.Name = Category.Name;
        }

        [PermissionRequired(RoleDTO.Admin, RoleDTO.Supplier)]
        private void CreateCategory()
        {
            productService.CreateCategory(Category);
            _categories.Add(Category);
        }

        [PermissionRequired(RoleDTO.Admin)]
        private void UpdateProduct()
        {
            productService.UpdateProduct(SelectedProduct, Product);
            SelectedProduct.Name = Product.Name;
        }

        [PermissionRequired(RoleDTO.Admin, RoleDTO.Supplier)]
        private void CreateProduct()
        {
            productService.CreateProduct(SelectedCategory, Product);
            _productsForCategory.Add(Product);
        }

        [PermissionRequired(RoleDTO.Admin, RoleDTO.Supplier)]
        private void DeliveryIn()
        {
            productService.CreateDetails(SelectedProduct, Details);
            SelectedProduct.Amount += Details.Amount;
            _detailsForProduct.Add(Details);
        }

        [PermissionRequired(RoleDTO.Admin, RoleDTO.Cashier)]
        private void DeliveryOut()
        {
            productService.UpdateDetails(SelectedProduct, SelectedDetails, Details);
            SelectedProduct.Amount -= Details.Amount;
            SelectedDetails.Amount -= Details.Amount;
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
