create index "IndexFirstName"
on "Customer" ("FirstName");

select * 
from "Customer"
where "FirstName" = 'Mia';