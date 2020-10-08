using System.Collections.Generic;

namespace ECommerceApp.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public int TotalProducts { get; set; }
        public int ProductsPerPage { get; set; }
        public int PageNumber { get; set; }

        public int NumberOfPages => (TotalProducts + ProductsPerPage - 1) / ProductsPerPage;
    }
}