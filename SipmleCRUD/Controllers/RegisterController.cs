using SipmleCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SipmleCRUD.Controllers
{
    public class RegisterController : Controller
    {
        TestEntities1 db = new TestEntities1();
        // GET: Register
        public ActionResult SetDataInDataBase()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SetDataInDataBase(tblUser model)
        {
            tblUser tbl = new tblUser();
            tbl.Name = model.Name;
            tbl.Email = model.Email;
            tbl.Password = model.Password;
            db.tblUsers.Add(tbl);
            db.SaveChanges();

            return View();
        }

        public ActionResult ShowDataBaseForUser()
        {
            var item = db.tblUsers.ToList();
            return View(item);
        }

        public ActionResult Delete(int id)
        {
            var item = db.tblUsers.Where(x => x.ID == id).First();
            db.tblUsers.Remove(item);
            db.SaveChanges();
            var item2 = db.tblUsers.ToList();
            return View("ShowDataBaseForUser", item2);
        }

        
        public ActionResult Edit(int id)
        {
            if(id != 0)
            {
                var item = db.tblUsers.Where(x => x.ID == id).First();
                return View(item);
            }
            else
            {
                var item2 = db.tblUsers.ToList();
                return View("ShowDataBaseForUser", item2);
            }
           


        }

        [HttpPost]
        public ActionResult Edit(tblUser model)
        {
            var item = db.tblUsers.Where(x => x.ID == model.ID).First();
            item.Name = model.Name;
            item.Email = model.Email;
            item.Password = model.Password;
            db.SaveChanges();
            return View();
        }
    }
}