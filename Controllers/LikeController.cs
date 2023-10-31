using ExamenORM.Data;
using ExamenORM.Filters;
using ExamenORM.Migrations;
using ExamenORM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamenORM.Controllers
{
    [SessionCheck]
    public class LikeController : Controller
    {
                private LoginContext _context;

        public LikeController(LoginContext loginContext)
        {
            _context = loginContext;
        }

        [HttpPost("likes/create/{habitid}")]
        public IActionResult Create(int habitid){
            int? id = HttpContext.Session.GetInt32("UserId");
            Habit? habit = _context.Habits.FirstOrDefault(a=>a.Id == habitid);
            User? user = _context.Users.FirstOrDefault(a=>a.Id == id);
            if(habit != null && user != null){
                Console.WriteLine("okkk..");
                Like like = new Like(){
                    CreatorId = user.Id,
                    Creator = user,
                    HabitId = habit.Id,
                    Habit = habit,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                _context.Likes.Add(like);
                _context.SaveChanges();
                return RedirectToAction("Index","Habit");
            }
                return RedirectToAction("Index","Habit");
        }
    }
}