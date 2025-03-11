using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElsherbinyTasks02.API.Models;
using ElsherbinyTasks02.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElsherbinyTasks02.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly BookService _bookService;

    public BooksController(BookService bookService)
    {
        _bookService = bookService;
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var books = await _bookService.GetAllAsync();
        return Ok(books);
    }


}
