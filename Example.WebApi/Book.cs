namespace Example.WebApi
{
    public class Book
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public DateOnly ReleaseDate { get; set; }

        public int PageCount { get; set; }

        public string ISBN { get; set; }

        public IList<Author> Authors { get; set; }

    }
}
