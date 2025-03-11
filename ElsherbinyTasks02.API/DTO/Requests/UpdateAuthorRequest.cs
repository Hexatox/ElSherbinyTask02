using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElsherbinyTasks02.API.DTO.Requests
{
    public class UpdateAuthorRequest
    {
        [Required]
        public string Name { get; set; }= string.Empty; 

        [Required]

        public DateOnly BirthDate { get; set; }
    }
}