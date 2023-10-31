using ExamenORM.Data;
using ExamenORM.Filters;
using ExamenORM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamenORM.Controllers
{
    [SessionCheck]
    public class UserController : Controller
    {
        private LoginContext _context;

        public UserController(LoginContext loginContext)
        {
            _context = loginContext;
        }
        [HttpGet("users/{id}")]
        public IActionResult Show(int id)
        {
            UserHabits userHabits = new UserHabits();
            User? user = _context.Users.FirstOrDefault(a => a.Id == id);
            if (user == null)
            {
                return RedirectToAction("Index", "Habit");
            }

            userHabits.creatorName = user.Name;
            userHabits.Habits = _context.Habits
                .Include(a => a.Category)
                .Include(a => a.Likes).ThenInclude(a=>a.Creator)
                .Include(a => a.Creator)
                .Where(a => a.Creator.Id == id)
                .ToList();
            return View(userHabits);
        }
    }
}