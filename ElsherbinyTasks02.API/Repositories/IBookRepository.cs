using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElsherbinyTasks02.API.Models;

namespace ElsherbinyTasks02.API.Repositories;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllAsync();
    Task<Book?> GetByIdAsync(Guid id);
    Task AddAsync(Book book);
    Task UpdateAsync(Book book);
    Task DeleteAsync(Guid id);
}
