INSERT INTO "Author" ("FirstName", "LastName", "BirthDate")
VALUES
('George', 'Orwell', '1903-06-25'),
('J.K.', 'Rowling', '1965-07-31'),
('J.R.R.', 'Tolkien', '1892-01-03'),
('Agatha', 'Christie', '1890-09-15');

INSERT INTO "Book" ("Title", "ReleaseDate", "PageCount", "ISBN")
VALUES
('1984', '1949-06-08', 328, '9780451524935'),
('Animal Farm', '1945-08-17', 112, '9780451526342'),
('Harry Potter and the Philosopher''s Stone', '1997-06-26', 223, '9780747532699'),
('The Hobbit', '1937-09-21', 310, '9780547928227'),
('Murder on the Orient Express', '1934-01-01', 256, '9780062693662');

INSERT INTO "BookAuthor" ("AuthorId", "BookId")
VALUES
(1, 1),
(1, 2),
(2, 3),
(3, 4),
(4, 5);