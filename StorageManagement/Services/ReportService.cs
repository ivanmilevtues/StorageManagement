using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseCommunication.DTO;
using StorageManagement.ExtensionMethods;
using StorageManagement.Models;

namespace StorageManagement.Services
{
    public class ReportService
    {
        private readonly ProductService productService;

        public ReportService(ProductService productService)
        {
            this.productService = productService;
        }

        public Report GenerateReport(ReportForm form)
        {
            var report = new Report()
            {
                Name = string.Format("Извадка за категория '{0}' и продукт '{1}' от {2} до {3}", form.CategoryName, form.ProductName, form.StartDate, form.EndDate),
            };
            if (form.ProductName != ReportForm.NotSetValue)
            {
                var product = productService.GetProductWithDetails(form.ProductName);
                AddToReportInformation(product, form, ref report);
                return report;
            }

            IList<ProductDTO> products;

            if(form.CategoryName != ReportForm.NotSetValue)
            {
                products = productService.GetProductDTOs(form.CategoryName);
            } 
            else 
            {
                products = productService.GetProductDTOs();
            }

            foreach(var product in products)
            {
                AddToReportInformation(product, form, ref report);
            }

            return report;
        }

        private void AddToReportInformation(ProductDTO product, ReportForm form, ref Report report)
        {
            int numberOfDeliveryIns = 0;
            int numberOfDeliveryOuts = 0;
            int addedItems = 0;
            int removedItems = 0;
            foreach (var detail in product.ProductDetails) 
            {
                if(detail.DeliveryDate.IsDateBetween(form.StartDate, form.EndDate))
                {
                    if(detail.IsInDelivery)
                    {
                        numberOfDeliveryIns++;
                        addedItems += detail.Amount;
                    }
                    else
                    {
                        numberOfDeliveryOuts++;
                        removedItems += detail.Amount;
                    }
                }
            }

            report.NumberOfDeliveries += numberOfDeliveryIns + numberOfDeliveryOuts;
            report.NumberOfDeliveryIns += numberOfDeliveryIns;
            report.NumberOfDeliveryOuts += numberOfDeliveryOuts;
            report.AddedItems += addedItems;
            report.RemovedItems += removedItems;
        }

    }
}
