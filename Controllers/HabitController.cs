using ExamenORM.Data;
using ExamenORM.Filters;
using ExamenORM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamenORM.Controllers
{
    [SessionCheck]
    public class HabitController : Controller
    {
        private LoginContext _context;

        public HabitController(LoginContext loginContext)
        {
            _context = loginContext;
        }

        [HttpGet("habits")]
        public IActionResult Index()
        {
            int? id = HttpContext.Session.GetInt32("UserId");
            HabitsList_indexView habitsList_IndexView = new HabitsList_indexView();
            List<Habit> youhabit = _context.Habits
                .Include(a => a.Category)
                .Include(a => a.Likes)
                .Include(a=>a.Creator)
                .Where(a => a.Creator.Id == id)
                .ToList();
            List<Habit> other = _context.Habits
                .Include(a => a.Category)
                .Include(a => a.Likes)
                .Include(a=>a.Creator)
                .ToList();

            habitsList_IndexView.YouHabit = youhabit;
            habitsList_IndexView.OtherHabit = other;
            return View(habitsList_IndexView);
        }

        [HttpGet("habits/new")]
        public IActionResult New()
        {
            HabitCategoryView habitCategoryView = new HabitCategoryView();
            habitCategoryView.Categories = _context.Categories.ToList();
            return View(habitCategoryView);
        }

        [HttpPost("habits/create")]
        public IActionResult Create([Bind(Prefix = "Habit")] Habit habit)
        {
            int? id = HttpContext.Session.GetInt32("UserId");
            if (id != null && id != habit.CreatorId)
            {
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            {
                habit.CreatedAt = DateTime.Now;
                habit.UpdatedAt = DateTime.Now;
                _context.Habits.Add(habit);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                HabitCategoryView habitCategoryView = new HabitCategoryView();
                habitCategoryView.Categories = _context.Categories.ToList();
                habitCategoryView.Habit = habit;
                return View("New", habitCategoryView);
            }
        }

        [HttpGet("habits/{id}/edit")]
        public IActionResult Edit(int id)
        {
            Habit? habit = _context.Habits.FirstOrDefault(a => a.Id == id);
            if (habit == null)
            {
                return RedirectToAction("Index");
            }
            HabitCategoryView habitCategoryView = new HabitCategoryView();
            habitCategoryView.Categories = _context.Categories.ToList();
            habitCategoryView.Habit = habit;
            return View(habitCategoryView);
        }

        [HttpPost("habits/{id}/update")]
        public IActionResult Update(int id, [Bind(Prefix = "Habit")] Habit habit)
        {
            int? userid = HttpContext.Session.GetInt32("UserId");
            if (userid != null && userid != habit.CreatorId)
            {
                return RedirectToAction("Index");
            }
            Habit? updatehabit = _context.Habits
                .Include(a => a.Category)
                .FirstOrDefault(a=>a.CreatorId == userid && a.Id == id);
            if (updatehabit == null)
            {
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            {
                updatehabit.CategoryId = habit.CategoryId;
                updatehabit.Title = habit.Title;
                updatehabit.Description = habit.Description;
                updatehabit.UpdatedAt = DateTime.Now;
                _context.Habits.Update(updatehabit);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                HabitCategoryView habitCategoryView = new HabitCategoryView();
                habitCategoryView.Categories = _context.Categories.ToList();
                habitCategoryView.Habit = habit;
                return View("Edit", habitCategoryView);
            }
        }

        [HttpPost("habits/{id}/destroy")]
        public IActionResult Delete(int id)
        {
            int? userid = HttpContext.Session.GetInt32("UserId");
            Habit? habit = _context.Habits.FirstOrDefault(a => a.Creator.Id == userid && a.Id == id);
            if (habit == null)
            {
                return RedirectToAction("Index");
            }
            List<Like> likes = _context.Likes.Where(a => a.Habit.Id == habit.Id).ToList();
            _context.Likes.RemoveRange(likes);
            _context.Habits.Remove(habit);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
