using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElsherbinyTasks02.API.Models;
using ElsherbinyTasks02.API.Repositories;

namespace ElsherbinyTasks02.API.Services;

public class BookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }


    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await _bookRepository.GetAllAsync();
    }




    public async Task AddAsync(Book book)
    {

        await _bookRepository.AddAsync(book);
    }


    public async Task UpdateAsync(Book book)
    {
        await _bookRepository.UpdateAsync(book);
    }




    public async Task<Book?> GetByIdAsync(Guid id) // Change int to Guid
    {
        return await _bookRepository.GetByIdAsync(id);
    }

    public async Task DeleteAsync(Guid id) // Change int to Guid
    {
        await _bookRepository.DeleteAsync(id);
    }


}
