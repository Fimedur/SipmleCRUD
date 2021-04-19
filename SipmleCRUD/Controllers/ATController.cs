using SipmleCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SipmleCRUD.Controllers
{
    public class ATController : Controller
    {
        TestEntities6 db = new TestEntities6();
        // GET: AT
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ShowATData()
        {
            var item = db.tblAttendances.ToList();
            return View(item);
        }
    }
}