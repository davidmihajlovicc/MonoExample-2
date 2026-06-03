namespace Example.WebApi
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; } 

        public List<BookAuthor> BookAuthors { get; set; }

    }
}
