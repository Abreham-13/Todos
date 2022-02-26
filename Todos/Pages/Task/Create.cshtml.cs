#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Todos.Data;
using Todos.models;

namespace Todos.Pages.Task
{
    public class CreateModel : PageModel
    {
        private readonly Todos.Data.TodosContext _context;

        public CreateModel(Todos.Data.TodosContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Todo_list Todo_list { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Todo_list.Add(Todo_list);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
