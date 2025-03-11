using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElsherbinyTasks02.API.Models;
using ElsherbinyTasks02.API.Repositories;

namespace ElsherbinyTasks02.API.Services;

public class AuthorService
{

    private readonly IAuthorRepository _authorRepository;
    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }



    public async Task<IEnumerable<Author>> GetAllAsync()
    {
        return await _authorRepository.GetAllAsync();
    }


    public async Task<Author?> GetByIdAsync(Guid id)
    {
        return await _authorRepository.GetByIdAsync(id);
    }



    public async Task AddAsync(Author author)
    {
        await _authorRepository.AddAsync(author);
    }

    public async Task<bool> UpdateAsync(Author author)
    {
        return await _authorRepository.UpdateAsync(author);
    }



    public async Task<bool> DeleteAsync(Guid id)
    {
        var author = await _authorRepository.GetByIdAsync(id);

        return await _authorRepository.DeleteAsync(id);
    }



    public async Task<IEnumerable<Book>> GetAuthorBooksAsync(Guid authorId)
    {
        return await _authorRepository.GetAuthorBooksAsync(authorId);
    }








}
