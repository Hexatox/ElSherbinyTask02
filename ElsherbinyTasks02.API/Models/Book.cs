
namespace ElsherbinyTasks02.API.Models
{
    public class Book
    {
        public Guid Id { get; init; }
        public string title { get; set; } = string.Empty;
        public DateOnly publishedDate { get; set; }



        //Navigation Properties
        public Author Author { get; set; }



        // Foreign Key
        public Guid AuthorId { get; set; }

    }
}