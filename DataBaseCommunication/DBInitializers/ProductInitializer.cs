﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using DataBaseCommunication.Models;

namespace DataBaseCommunication.DBInitializers
{
    class ProductInitializer: ISeed
    {
        public void AddToSeed(ref StorageManagementDBContext context)
        {
            IList<ProductCategory> productCategories = new List<ProductCategory>
            {
                new ProductCategory() {CategoryName = "МПС", Products = new List<Product>()},
                new ProductCategory() {CategoryName = "Храни", Products = new List<Product>()},
                new ProductCategory() {CategoryName = "Дрехи", Products = new List<Product>()},
            };

            IList<Product> products = new List<Product>
            {
                new Product()
                {
                    ProductName = "Масло за коли",
                    Amount = 5,
                    Description = "Моторно масло за автомболи 42W10",
                    ProductCategories = new List<ProductCategory>(),
                    ProductDetails = new List<ProductDetails>()
                },
                new Product()
                {
                    ProductName = "Зимнги гуми Пирелин",
                    Amount = 10,
                    Description = "245/35R18",
                    ProductCategories = new List<ProductCategory>(),
                    ProductDetails = new List<ProductDetails>()
                },
                new Product()
                {
                    ProductName = "Kожено яке",
                    Amount = 10,
                    Description = "Кожено яко от естествена кожа за мотор, размер M",
                    ProductCategories = new List<ProductCategory>(),
                    ProductDetails = new List<ProductDetails>()
                },
                new Product() 
                {
                    ProductName = "Данонино",
                    Description = "Йогурт",
                    Amount = 25,
                    ProductCategories = new List<ProductCategory>(),
                    ProductDetails = new List<ProductDetails>()
                },
                new Product() 
                {
                    ProductName = "Активиа мъже",
                    Description = "Ако си истинска батка, вземи киселото мляко за мъже",
                    Amount = 50,
                    ProductCategories = new List<ProductCategory>(),
                    ProductDetails = new List<ProductDetails>()
                },
                new Product()
                {
                    ProductName = "Нацепин",
                    Description = "Нацепин с бахур, за да бухаш здраво.",
                    Amount = 50,
                    ProductCategories = new List<ProductCategory>(),
                    ProductDetails = new List<ProductDetails>()
                },
            };

            IList<ProductDetails> productDetails = new List<ProductDetails>
            {
                new ProductDetails
                {
                    DeliveryDate = new DateTime(2020, 10, 10),
                    ProductionDate = new DateTime(2020, 2, 10),
                    Amount = 2,
                    Product = products[0]
                },
                new ProductDetails
                {
                    DeliveryDate = new DateTime(2020, 11, 10),
                    ProductionDate = new DateTime(2020, 3, 10),
                    Amount = 3,
                    Product = products[0]
                },
                new ProductDetails
                {
                    DeliveryDate = new DateTime(2019, 10, 10),
                    ProductionDate = new DateTime(2018, 2, 10),
                    ExpirationDate = new DateTime(2022, 2, 10),
                    Amount = 10,
                    Product = products[1]
                },
                new ProductDetails
                {
                    DeliveryDate = new DateTime(2021, 6, 8),
                    ProductionDate = new DateTime(2021, 6, 5),
                    Amount = 10,
                    Product = products[2]
                },
                new ProductDetails
                {
                    DeliveryDate = new DateTime(2021, 6, 15),
                    ProductionDate = new DateTime(2021, 6, 12),
                    ExpirationDate = new DateTime(2021, 6, 29),
                    Amount = 25,
                    Product = products[3]
                },
                new ProductDetails
                {
                    DeliveryDate = new DateTime(2021, 6, 15),
                    ProductionDate = new DateTime(2021, 6, 12),
                    ExpirationDate = new DateTime(2021, 6, 29),
                    Amount = 50,
                    Product = products[4]
                },
                new ProductDetails
                {
                    DeliveryDate = new DateTime(2021, 6, 15),
                    ProductionDate = new DateTime(2021, 6, 12),
                    ExpirationDate = new DateTime(2021, 6, 29),
                    Amount = 50,
                    Product = products[5]
                },
            };

            productCategories[0].Products.Add(products[0]);
            productCategories[0].Products.Add(products[1]);
            productCategories[0].Products.Add(products[2]);

            productCategories[2].Products.Add(products[2]);

            productCategories[1].Products.Add(products[3]);
            productCategories[1].Products.Add(products[4]);
            productCategories[1].Products.Add(products[5]);

            context.ProductDetails.AddRange(productDetails);
            context.Products.AddRange(products);
            context.ProductCategories.AddRange(productCategories);
        }
    }
}
