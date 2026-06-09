using Example.Common;
using Example.Model;
using Example.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Example.Service.Common;
using static System.Net.WebRequestMethods;



namespace Example.WebApi.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class AuthorController: ControllerBase
    {

        private IAuthorService authorService;


        public AuthorController(IAuthorService authorService) { 
            this.authorService = authorService;
        }


        [HttpGet(Name = "GetAuthors")]
        public async Task<IActionResult> GetAsync(string firstName = "", string lastName = "", string bookTitle= "")
        {

            AuthorFilter filter = new AuthorFilter { FirstName = firstName, LastName = lastName, BookTitle = bookTitle };
            IList<Author>? authors = await authorService.GetAsync(filter);
            if (authors != null)
            {
                return Ok(authors);
            }
            return BadRequest();

        }


        [HttpGet("{id}", Name = "GetAuthor")]
        public async Task<IActionResult> GetAsync(int id)
        {

            Author? author = await authorService.GetAuthorAsync(id);
            if (author != null)
            {
                return Ok(author);
            }
            return BadRequest();

        }



        [HttpPost(Name = "AddAuthor")]
        public async Task<IActionResult> PostAsync([FromBody] Author author)
        {

            if (await authorService.PostAuthorAsync(author) != false)
            {
                return Ok();
            }
            return BadRequest();
        }

        

        [HttpPut("{id}", Name = "UpdateAuthor")]
        public async Task<IActionResult> PutAsync(int id, Author author) {

          
            if (await authorService.PutAsync(id, author) != false)
            {
                return Ok();
            }
            return BadRequest();

        }


        [HttpDelete("{id}", Name = "DeleteAuthor")]
        public async Task<IActionResult> DeleteAsync(int id)
        {

            
            if (await authorService.DeleteAsync(id) != false)
            {
                return Ok();
            }
            return BadRequest();

        }

        [HttpPost("AddAuthorFromQuery")]
        public async Task<IActionResult> PostFromQueryAsync([FromQuery] Author author)
        {

            
            if (await authorService.PostAuthorAsync(author) != false)
            {
                return Ok();
            }
            return BadRequest();

        }

        [HttpGet("GetFromQuery")]
        public async Task<IActionResult> GetFromQueryAsync([FromQuery] int id)
        {

            
            Author? author = await authorService.GetAuthorAsync(id);
            if (author != null)
            {
                return Ok(author);
            }
            return BadRequest();
        }

        [HttpGet("GetFromBody")]
        public async Task<IActionResult> GetFromBodyAsync([FromBody] int id)
        {

            
            Author? author = await authorService.GetAuthorAsync(id);
            if (author != null)
            {
                return Ok(author);
            }
            return BadRequest();
        }


        [HttpPost("AddBookToAuthor")]
        public async Task<IActionResult> AddBookToAuthorAsync([FromBody] BookAuthor bookAuthor)
        {

            
            if (await authorService.AddBookToAuthorAsync(bookAuthor) != false)
            {
                return Ok();
            }
            return BadRequest();

        }

    }
}
