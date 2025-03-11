using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElsherbinyTasks02.API.Models
{
    public class Author
    {
        public Guid Id { get; init; }
        public string Name { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }

        public ICollection<Book> books { get; } = new List<Book>();
    }
}