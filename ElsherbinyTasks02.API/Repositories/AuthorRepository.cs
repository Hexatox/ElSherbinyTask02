using System.Collections.Generic;
using System.Threading.Tasks;
using ElsherbinyTasks02.API.Data;
using ElsherbinyTasks02.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ElsherbinyTasks02.API.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;

        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid id) // Changed from int to Guid
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return false;
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author?> GetByIdAsync(Guid id) // Changed from int to Guid
        {
            return await _context.Authors.AsNoTracking().SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<bool> UpdateAsync(Author author)
        {
            if (!await ExistsAsync(author.Id))
            {
                return false;
            }

            _context.Entry(author).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(Guid id) // Changed from int to Guid

        {
            return await _context.Authors.AnyAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Book>> GetAuthorBooksAsync(Guid authorId)
        {
            return await _context.Books
       .Where(b => b.AuthorId == authorId)
       .AsNoTracking()
       .ToListAsync();
        }
    }
}
