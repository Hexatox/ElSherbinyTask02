using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElsherbinyTasks02.API.Models;

namespace ElsherbinyTasks02.API.Repositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author?> GetByIdAsync(Guid id); // Fixed Primary Key Type
        Task AddAsync(Author author);
        Task<bool> UpdateAsync(Author author); // Return success status
        Task<bool> DeleteAsync(Guid id); // Fixed Primary Key Type & Return success status





        public Task<IEnumerable<Book>> GetAuthorBooksAsync(Guid authorId);
    }

}