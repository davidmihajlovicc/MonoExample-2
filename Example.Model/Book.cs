namespace Example.Model
{
    public class Book
    {
        
        public int Id { get; set; } 

        public string? Title { get; set; } 

        public DateOnly? ReleaseDate { get; set; }

        public int? PageCount { get; set; }

        public string? ISBN { get; set; }

        public List<BookAuthor> BookAuthors { get; set; } = [];

        public List<Author> Authors {get; set; } = [];


    }
}
