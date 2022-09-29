using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using GroseryStoreProjectMVC.Models;


namespace GroseryStoreProjectMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Gallery()
        {
            return View();
        }
        public ActionResult Product()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registraion(TblRegitrtation tblRegitrtation)
        {
            using (GrosaryDataEntities entities = new GrosaryDataEntities())
            {
                if (ModelState.IsValid)
                {
                    entities.TblRegitrtations.Add(tblRegitrtation);
                    entities.SaveChanges();


                    ViewBag.Success = "Inserted";


                    ModelState.Clear();
                }
            }
                return View(tblRegitrtation);

            
        }
            [HttpPost]
            public ActionResult Contact(TblContact tblContact)
            {
            using (GrosaryDataEntities entities = new GrosaryDataEntities())
            {
                if (ModelState.IsValid)
                {
                    entities.TblContacts.Add(tblContact);
                    entities.SaveChanges();


                    ViewBag.Success = "Feedback Send Successfully";


                    ModelState.Clear();
                }
            }
                    return View(tblContact);

                
            }
        [HttpPost]
        public ActionResult Login(TblRegitrtation objUser)
        {
            if (ModelState.IsValid)
            {
                using (GrosaryDataEntities db = new GrosaryDataEntities())
                {
                    var obj = db.TblRegitrtations.Where(a => a.email.Equals(objUser.email) && a.pass.Equals(objUser.pass)).FirstOrDefault();
                    if (obj != null)
                    {
                        //Session["UserID"] = obj.UserId.ToString();
                        //Session["UserName"] = obj.email.ToString();
                        return RedirectToAction("Home/Product");
                    }
                }
            }
            return View(objUser);
        }


    }
    }
