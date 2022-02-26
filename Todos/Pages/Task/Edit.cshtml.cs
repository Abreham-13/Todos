#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Todos.Data;
using Todos.models;

namespace Todos.Pages.Task
{
    public class EditModel : PageModel
    {
        private readonly Todos.Data.TodosContext _context;

        public EditModel(Todos.Data.TodosContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Todo_list).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Todo_listExists(Todo_list.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool Todo_listExists(int id)
        {
            return _context.Todo_list.Any(e => e.id == id);
        }
    }
}
