insert into "Category"
values
(3, 'Clothing', 'All wearable items'),
(4, 'Books', 'All kinds of books');

insert into "Customer"
values
(3, 'Mia', 'Horvat', 'mia@gmail.com', '0911111111', NOW()),
(4, 'Ivan', 'Peric', 'ivan@gmail.com', '0922222222', NOW());

insert into "Product"
values
(3, 3, 'Jeans', 'Blue denim jeans', 30, 40, NOW()),
(4, 4, 'Novel', 'Fiction book', 25, 15, NOW());

insert into "Employee"
values
(3, 'Marko', 'Maric', 'marko.maric@shop.com', '0955555555', 'Cashier', NOW()),
(4, 'Ivana', 'Barić', 'ivana.baric@shop.com', '0966666666', 'Manager', NOW());

insert into "Invoice"
values
(3, 3, 3, 'INV-003', NOW(), 55, 'Cash', true),
(4, 4, 4, 'INV-004', NOW(), 80, 'Card', false);

insert into "InvoiceProduct"
values
(3, 3, 3, 3, 0, 40),
(4, 4, 4, 4, 0, 15);

