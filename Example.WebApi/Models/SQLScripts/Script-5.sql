create table "Invoice"(
	"Id" int primary key not null,
	"CustomerId" int,
	"EmployeeId" int,
	"InvoiceNumber" varchar(128),
	"CreatedAt" timestamp,
	"TotalAmount" int,
	"PaymentMethod" char(16),
	"IsPaid" bool,
	
	foreign key ("CustomerId") references "Customer"("Id"),
	foreign key ("EmployeeId") references "Employee"("Id")


);