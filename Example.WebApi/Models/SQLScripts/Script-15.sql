insert into "Category"
values
(5, 'Furniture', 'Home and office furniture'),
(6, 'Sports', 'Sport equipment and accessories');


insert into "Customer"
values
(5, 'Ana', 'Kovac', 'ana@gmail.com', '0933333333', NOW()),
(6, 'Petar', 'Novak', 'petar@gmail.com', '0944444444', NOW());


insert into "Product"
values
(5, 5, 'Chair', 'Office chair', 20, 60, NOW()),
(6, 6, 'Football', 'Standard size football ball', 50, 25, NOW());


insert into "Employee"
values
(5, 'Josip', 'Grgic', 'josip.grgic@shop.com', '0977777777', 'Sales', NOW()),
(6, 'Lea', 'Vuk', 'lea.vuk@shop.com', '0988888888', 'Cashier', NOW());


insert into "Invoice"
values
(5, 5, 5, 'INV-005', NOW(), 85, 'Card', true),
(6, 6, 6, 'INV-006', NOW(), 45, 'Cash', false);


insert into "InvoiceProduct"
values
(5, 5, 5, 1, 0, 60),
(6, 6, 6, 1, 0, 25);