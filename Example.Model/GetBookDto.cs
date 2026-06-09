using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Model
{
    public class GetBookDto
    {
        public string? Title { get; set; }

        public DateOnly? ReleaseDate {  get; set; }

        public int? PageCount { get; set; }

        public string? ISBN { get; set; }


    }
}
