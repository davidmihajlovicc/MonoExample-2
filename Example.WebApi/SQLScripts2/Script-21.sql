create table "Author"(
	"Id" int GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	"FirstName" char(32),
	"LastName" char(32),
	"BirthDate" timestamp
);


create table "Book"(
	"Id" int GENERATED ALWAYS AS IDENTITY PRIMARY key,
	"Title" varchar(255),
	"ReleaseDate" timestamp, 
	"PageCount" int,
	"ISBN" varchar(128)
);

create table "BookAuthor"(
	"Id" int GENERATED ALWAYS AS IDENTITY PRIMARY key,
	"AuthorId" int,
	"BookId" int,
	
	foreign key ("AuthorId") references "Author"("Id"),
	foreign key ("BookId") references "Book"("Id")


);