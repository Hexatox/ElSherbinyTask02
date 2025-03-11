using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElsherbinyTasks02.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ElsherbinyTasks02.API.Data;

public class AppDbContext(DbContextOptions options) :  DbContext (options)
{
   public DbSet<Author> Authors { get; set; }
    public    DbSet<Book> Books { get; set; }
}
