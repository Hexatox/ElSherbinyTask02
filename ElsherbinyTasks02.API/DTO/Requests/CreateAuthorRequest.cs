using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ElsherbinyTasks02.API.DTO.Requests;
using ElsherbinyTasks02.API.Models;






    public class CreateAuthorRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]

        public DateOnly BirthDate { get; set; }
    }
