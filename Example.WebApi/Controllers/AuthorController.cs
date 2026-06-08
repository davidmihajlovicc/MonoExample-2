using Example.Common;
using Example.Model;
using Example.Repository;
using Example.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using static System.Net.WebRequestMethods;



namespace Example.WebApi.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class AuthorController: ControllerBase
    {


        [HttpGet(Name = "GetAuthors")]
        public IActionResult Get([FromQuery] AuthorFilter filter)
        {
            AuthorRepository authorRepository = new AuthorRepository();
            IList<Author>? authors = authorRepository.Get(filter);
            if (authors != null)
            {
                return Ok(authors);
            }
            return BadRequest();

        }


        [HttpGet("{id}", Name = "GetAuthor")]
        public IActionResult Get(int id)
        {

            AuthorRepository authorRepository = new AuthorRepository();
            Author? author = authorRepository.GetAuthor(id);
            if (author != null)
            {
                return Ok(author);
            }
            return BadRequest();

        }



        [HttpPost(Name = "AddAuthor")]
        public IActionResult Post([FromBody] Author author)
        {

            AuthorRepository authorRepository = new AuthorRepository();
            if (authorRepository.PostAuthor(author) != false)
            {
                return Ok();
            }
            return BadRequest();
        }

        

        [HttpPut("{id}", Name = "UpdateAuthor")]
        public IActionResult Put(int id, Author author) {

            AuthorRepository authorRepository = new AuthorRepository();
            if (authorRepository.Put(id, author) != false)
            {
                return Ok();
            }
            return BadRequest();

        }


        [HttpDelete("{id}", Name = "DeleteAuthor")]
        public IActionResult Delete(int id)
        {

            AuthorRepository authorRepository = new AuthorRepository();
            if (authorRepository.Delete(id) != false)
            {
                return Ok();
            }
            return BadRequest();

        }

        [HttpPost("AddAuthorFromQuery")]
        public IActionResult PostFromQuery([FromQuery] Author author)
        {

            AuthorRepository authorRepository = new AuthorRepository();
            if (authorRepository.PostAuthor(author) != false)
            {
                return Ok();
            }
            return BadRequest();

        }

        [HttpGet("GetFromQuery")]
        public IActionResult GetFromQuery([FromQuery] int id)
        {

            AuthorRepository authorRepository = new AuthorRepository();
            Author? author = authorRepository.GetAuthor(id);
            if (author != null)
            {
                return Ok(author);
            }
            return BadRequest();
        }

        [HttpGet("GetFromBody")]
        public IActionResult GetFromBody([FromBody] int id)
        {

            AuthorRepository authorRepository = new AuthorRepository();
            Author? author = authorRepository.GetAuthor(id);
            if (author != null)
            {
                return Ok(author);
            }
            return BadRequest();
        }


        [HttpPost("AddBookToAuthor")]
        public IActionResult AddBookToAuthor([FromBody] BookAuthor bookAuthor)
        {

            AuthorRepository authorRepository = new AuthorRepository();
            if (authorRepository.AddBookToAuthor(bookAuthor) != false)
            {
                return Ok();
            }
            return BadRequest();

        }

    }
}
