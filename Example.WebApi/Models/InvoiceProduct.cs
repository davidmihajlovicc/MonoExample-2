namespace Example.WebApi.Models
{
    public class InvoiceProduct
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int Discount { get; set; }

        public int Price { get; set; }

        public Product Product { get; set; }

        public Invoice Invoice { get; set; }
    }
}
