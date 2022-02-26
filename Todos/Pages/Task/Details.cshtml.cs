#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Todos.Data;
using Todos.models;

namespace Todos.Pages.Task
{
    public class DetailsModel : PageModel
    {
        private readonly Todos.Data.TodosContext _context;

        public DetailsModel(Todos.Data.TodosContext context)
        {
            _context = context;
        }

        public Todo_list Todo_list { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Todo_list = await _context.Todo_list.FirstOrDefaultAsync(m => m.id == id);

            if (Todo_list == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
