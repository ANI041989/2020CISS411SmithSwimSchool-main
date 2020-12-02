using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project1.Models;

namespace Project1.Controllers
{
    //[Authorize(Roles="Swimmer")]
    public class SwimmerController : Controller
    {
        private readonly ApplicationDbContext db;
        public SwimmerController(ApplicationDbContext db)
        {
            this.db = db;
        }
        [HttpPost]
        public async Task<IActionResult> AddProfile
            (Swimmer swimmer)
        {
            var currentUserId = this.User.FindFirst
                (ClaimTypes.NameIdentifier).Value;
            if (db.Swimmers.Any(i => i.UserId ==
                currentUserId))
            {
                var swimmerToUpdate = db.Swimmers.FirstOrDefault(i =>
                    i.UserId == currentUserId);
                swimmerToUpdate.SwimmerName = swimmer.SwimmerName;
                db.Update(swimmerToUpdate);
            }
            else
            {
                db.Add(swimmer);
            }
            await db.SaveChangesAsync();
            return View(swimmer);
        }
        public IActionResult Index()
        {
            return View();
        }


    }
}
