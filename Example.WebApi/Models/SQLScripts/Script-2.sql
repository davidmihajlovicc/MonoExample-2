create table "Product"(
	"Id" int primary key not null,
	"CategoryId" int,
	"Name" varchar(255),
	"Description" varchar(255),
	"StockQuantity" int,
	"Price" int,
	"CreatedAt" timestamp,
	foreign key ("CategoryId") references "Category"("Id")

);