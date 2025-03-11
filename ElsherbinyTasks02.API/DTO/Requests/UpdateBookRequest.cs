using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElsherbinyTasks02.API.DTO.Requests
{
    public class UpdateBookRequest
    {
        [Required]
        public string title { get; set; } = string.Empty;

        [Required]

        public DateOnly publishedDate { get; set; }


        
    }
}