using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElsherbinyTasks02.API.DTO.Responses;

public class RetreiveAuthorBook
{


    public Guid Id { get; init; }

    public string title { get; set; } = string.Empty;
    public DateOnly publishedDate { get; set; }
}
