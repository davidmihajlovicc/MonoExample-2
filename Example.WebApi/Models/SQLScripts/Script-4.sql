create table "Employee"(
	"Id" int primary key not null,
	"FirstName" varchar(128),
	"Lastname" varchar(128),
	"Email" varchar(128),
	"Phone" varchar(128),
	"Role"  varchar(24),
	"CreatedAt" timestamp

);