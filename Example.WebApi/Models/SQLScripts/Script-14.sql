
alter table "Invoice"
drop constraint "Invoice_CustomerId_fkey";

alter table "Invoice"
add constraint "Invoice_CustomerId_fkey"
foreign key ("CustomerId")
references "Customer"("Id")
on delete cascade;


alter table "InvoiceProduct"
drop constraint "InvoiceProduct_InvoiceId_fkey";

alter table "InvoiceProduct"
add constraint "InvoiceProduct_InvoiceId_fkey"
foreign key ("InvoiceId")
references "Invoice"("Id")
on delete cascade;


delete from "Customer"
where "FirstName"= 'Mia';

select * from "Customer"