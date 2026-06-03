create table "Author"(
	"Id" int primary key not null,
	"FirstName" char(32),
	"LastName" char(32),
	"BirthDate" timestamp
)


create table "Book"(
	"Id" int primary key not null,
	"Title" varchar(255),
	"ReleaseDate" timestamp, 
	"PageCount" int,
	"ISBN" varchar(128)
);

create table BookAuthor(
	"Id" int primary key not null,
	"AuthorId" int,
	"BookId" int,
	
	foreign key ("AuthorId") references "Author"("Id"),
	foreign key ("BookId") references "Book"("Id")


);