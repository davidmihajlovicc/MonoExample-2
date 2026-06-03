select "Product"."Id", "Product"."Name", "Category"."Name"
from "Product"
inner join "Category" on "Product"."CategoryId" = "Category"."Id";