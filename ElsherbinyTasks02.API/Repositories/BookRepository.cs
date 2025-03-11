
using ElsherbinyTasks02.API.Data;
using ElsherbinyTasks02.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ElsherbinyTasks02.API.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Book> _dbSet;

        public BookRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Books;
        }

        public async Task AddAsync(Book book)
        {
            _dbSet.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var book = await _dbSet.FindAsync(id);
            if (book != null)
            {
                _dbSet.Remove(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(Book book)
        {
            _dbSet.Update(book);
            await _context.SaveChangesAsync();
        }
    }
}