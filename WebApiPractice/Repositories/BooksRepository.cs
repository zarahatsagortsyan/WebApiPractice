using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPractice.Models;

namespace WebApiPractice.Repositories
{
    public class BooksRepository : IBookRepository
    {
        private readonly BooksContext _context;
        public BooksRepository(BooksContext context)
        {
            _context = context;
        }

        public async Task<Books> Create(Books book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public  async Task Delete(int id)
        {
           var bookToDelete = await _context.Books.FindAsync(id);
            _context.Books.Remove(bookToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Books>> Get()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Books> Get(int id)
        {
            var BookToShow = await _context.Books.FindAsync(id);
            return BookToShow;
        }

        public async Task Update(Books book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
    }
}
