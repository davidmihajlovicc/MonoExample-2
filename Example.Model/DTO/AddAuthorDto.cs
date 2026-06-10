using Example.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Model.DTO
{
    public class AddAuthorDto
    {
        
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly? BirthDate { get; set; }

        public List<BookAuthor> BookAuthors { get; set; } = [];

    }
}
