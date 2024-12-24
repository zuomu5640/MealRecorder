using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MealRecorder.Data;
using MealRecorder.Models;

namespace MealRecorder.Pages.Meals
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Meal Meal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Meal = await _context.Meals.FirstOrDefaultAsync(m => m.MealId == id);

            if (Meal == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // 編集前のデータを取得して更新日時を設定
            var mealToUpdate = await _context.Meals.FirstOrDefaultAsync(s => s.MealId == Meal.MealId);
            if (mealToUpdate == null)
            {
                return NotFound();
            }

            mealToUpdate.MealDate = Meal.MealDate;
            mealToUpdate.MealType = Meal.MealType;
            mealToUpdate.Description = Meal.Description;
            mealToUpdate.UpdatedAt = System.DateTime.Now; // 更新日時を設定


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealExists(Meal.MealId))
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

        private bool MealExists(int id)
        {
            return _context.Meals.Any(e => e.MealId == id);
        }
    }
}