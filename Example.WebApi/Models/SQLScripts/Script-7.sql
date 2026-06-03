create table "InvoiceProduct" (
	"Id" int primary key not null,
	"ProductId" int,
	"InvoiceId" int,
	"Quantity" int,
	"Discount" int, 
	"Price" int,
	
	foreign key("ProductId") references "Product"("Id"),
	foreign key("InvoiceId") references "Invoice"("Id")
	
);