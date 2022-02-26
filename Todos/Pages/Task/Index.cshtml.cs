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
    public class IndexModel : PageModel
    {
        private readonly Todos.Data.TodosContext _context;

        public IndexModel(Todos.Data.TodosContext context)
        {
            _context = context;
        }

        public IList<Todo_list> Todo_list { get;set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Todo_list = await _context.Todo_list.ToListAsync();
            return Page();
        }
    }
}
