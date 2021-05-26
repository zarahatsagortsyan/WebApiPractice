using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPractice.Models;
using WebApiPractice.Repositories;

namespace WebApiPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _repo;
        public BooksController(IBookRepository repository)
        {
            _repo = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Books>> GetBooks()
        {
            return await _repo.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Books>> GetBook(int id)
        {
            return await _repo.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Books>> PostBook([FromBody] Books books) 
        {
            var newbook = await _repo.Create(books);
            return CreatedAtAction(nameof(GetBooks), new { id = newbook.id },newbook);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateBooks(int id, [FromBody] Books books)
        {

            if (id!=books.id)
            {
                return BadRequest();
            }
             await _repo.Update(books);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var book = _repo.Get(id);
            if (book==null)
            {
                return BadRequest();
            }
            await _repo.Delete(book.Id);
            return NoContent();
        }
    }
}
