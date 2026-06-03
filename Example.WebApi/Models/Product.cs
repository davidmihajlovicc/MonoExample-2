using System.ComponentModel;

namespace Example.WebApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public int StockQuantity { get; set; }

        public int Price { get; set; }

        public DateTime CreatedAt { get; set; }

        public Category Category { get; set; }

        public List<InvoiceProduct> InvoiceProducts { get; set; }

      
    }
}
