select *
from "Book" as b 
left join "BookAuthor" ba on b."Id" = ba."BookId" 
left join "Author" a on ba."AuthorId" = a."Id" 