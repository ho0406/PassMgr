using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PassMgr.Models;

namespace PassMgr.Controllers
{
    public class PasswordController : Controller
    {
        PasswdContext db = new PasswdContext();
        public IActionResult Index()
        {
            return View("Index",db.Passwords.OrderBy(p=>p.Ip).ThenBy(p=>p.Service).ThenBy(p=>p.Domain).ToList());
        }

        [HttpPost]
        public IActionResult Create(Password pwd){
            if (ModelState.IsValid)
            {
                db.Passwords.Add(pwd);
                db.SaveChanges();
                return RedirectToAction("Index");
            } else
            {
                return Index();
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
