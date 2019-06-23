using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskList.Models
{
    public class ApiResponse
    {
        public bool Status { get; set; }
        public TaskItem TaskItem { get; set; }
        public ModelStateDictionary ModelState { get; set; }
    }
}
