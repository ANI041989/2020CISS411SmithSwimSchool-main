using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project1.Models;

namespace Project1.Controllers
{
    // [Authorize(Roles="Coach")]
    public class CoachController : Controller
    {
        private readonly ApplicationDbContext db;

        public CoachController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult AddProfile()
        {
            var currentUserId = this.User.FindFirst
                (ClaimTypes.NameIdentifier).Value;
            Coach coach = new Coach();
            if (db.Coachs.Any(i => i.UserId ==
            currentUserId))
            {
                coach = db.Coachs.FirstOrDefault
                    (i => i.UserId == currentUserId);
            }
            else
            {
                coach.UserId = currentUserId;
            }

            return View(coach);

        }
        [HttpPost]
        public async Task<IActionResult> AddProfile
            (Coach coach)
        {
            var currentUserId = this.User.FindFirst
                (ClaimTypes.NameIdentifier).Value;
            if (db.Coachs.Any
                (i => i.UserId == currentUserId))
            {
                var coachToUpdate = db.Coachs.FirstOrDefault
                    (i => i.UserId == currentUserId);
                coachToUpdate.CoachName = coach.CoachName;
                coachToUpdate.Bio = coach.Bio;
                db.Update(coachToUpdate);
            }
            else
            {
                db.Add(coach);
            }
            await db.SaveChangesAsync();
            return View("Index");

        }

        //public async Task<IActionResult> AllSession()
        //{
        //    var lesson = await db.Lessons.Include
        //        (c => c.Coach).ToListAsync();
        //    return View(lesson);
        //}

        //public async Task<IActionResult> EnrollLesson(int id)
        //{
        //    var currentUserId = this.User.FindFirst
        //        (ClaimTypes.NameIdentifier).Value;
        //    var coachId = db.Coachs.FirstOrDefault
        //    (s => s.UserId == currentUserId).CoachId;
        //    Enrollment enrollment = new Enrollment
        //    {
        //        LessonId = id,
        //        CoachId = coachId
        //    };
        //    db.Add(enrollment);
        //    var lesson = await db.Lessons.FindAsync(enrollment.LessonId);
        //    await db.SaveChangesAsync();
        //    return View("Index");
        //}


        public IActionResult Index()
        {
            return View();
        }
    }
}
