using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PassMgr.Models;
using Microsoft.EntityFrameworkCore;
using passmgr.Models;

namespace PassMgr.Controllers
{
    public class PasswordController : Controller
    {
        PasswdContext db = new PasswdContext();
        public IActionResult Index(State code)
        {
            switch (code)
            {
                case State.NotFound:
                    ModelState.AddModelError("", "Resource Not Fount");
                    break;
                default:
                    break;
            }
            return View("Index",db.Passwords.OrderBy(p=>p.Ip).ThenBy(p=>p.Service).ThenBy(p=>p.Domain).ToList());
        }

        public IActionResult Create(int id=0)
        {
            if (id > 0)
            {
                ModelState.Clear();
                Password pwd = db.Passwords.AsNoTracking().FirstOrDefault(p => p.Id == id);
                pwd.Id = 0;
                return View("Create", pwd);
            }
            return View("Create");
        }

        public IActionResult Edit(int id)
        {
            Password pwd = db.Passwords.Find(id);
            if (pwd == null)
            {
                return Index(State.NotFound);
            }
            return View("Edit",pwd);
        }

        [HttpPost]
        public IActionResult Save(Password pwd,bool isContinue){
            if (ModelState.IsValid)
            {
                db.Entry(pwd).State = (pwd.Id > 0) ? EntityState.Modified:EntityState.Added;
                db.SaveChanges();
                return RedirectToAction(isContinue?"Create":"Index");
            }
            else
            {
                return View(pwd.Id > 0?"Edit":"Create",pwd);
            }
        }
        
        public IActionResult Remove(int id)
        {

            Password pwd = db.Passwords.Find(id);
            if (pwd == null)
            {
                return Index(State.NotFound);
            }
            return View("Remove", pwd);
        }


        [HttpPost,ActionName("Remove")]
        [AutoValidateAntiforgeryToken]
        public IActionResult RemoveConfirm(int id)
        {
            Password pwd = db.Passwords.Find(id);
            if (pwd == null)
            {
                return Index(State.NotFound);
            }
            db.Passwords.Remove(pwd);
            db.SaveChanges();
            
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
