SELECT b."Title", b."ReleaseDate", b."PageCount", b."ISBN", a."FirstName", a."LastName" 
FROM "Book" b  
LEFT JOIN  "BookAuthor" ab on b."Id" = ab."BookId"
LEFT JOIN "Author" a on a."Id" = ab."AuthorId" 
WHERE 1=1