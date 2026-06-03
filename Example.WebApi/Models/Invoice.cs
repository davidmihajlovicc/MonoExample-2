namespace Example.WebApi.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        
        public string InvoiceNumber { get; set; }

        public DateTime CreatedAt { get; set; }

        public int TotalAmount { get; set; }

        public string PaymentMethod { get; set; }

        public bool IsPaid { get; set; }

        public Customer Customer { get; set; }

        public Employee Employee { get; set; }

        public List<InvoiceProduct> InvoiceProducts { get; set; }
    }
}
