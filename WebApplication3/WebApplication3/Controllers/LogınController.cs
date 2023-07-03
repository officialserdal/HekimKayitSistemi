using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;


namespace WebApplication3.Controllers
{
    public class LogınController : Controller
    {
        

        doctorEntities db = new doctorEntities();

        // GET: Logın
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(user objchk)
        {
            if (ModelState.IsValid)
            {
                using (doctorEntities db = new doctorEntities()) 

                {
                    var obj = db.users.Where(a => a.username.Equals(objchk.username) && a.password.Equals(objchk.password)).FirstOrDefault();

                    if (obj is null)
                    {
                        ModelState.AddModelError("", "The UserName or Password Incorrect");
                    }
                    else
                    {
                        Session["UserID"] = objchk.id.ToString();
                        Session["UserName"] = objchk.username.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                }
                

            }




            return View(objchk);
           


        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }



    }
   
}