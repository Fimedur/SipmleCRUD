using SipmleCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SipmleCRUD.Controllers
{
    public class AddEemployeeController : Controller
    {     //Employee db = new Employee
          // GET: AddEemployee
        TestEntities2 db = new TestEntities2();
        public ActionResult AddEmployeeInfo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployeeInfo(Employee model)
        {
            Employee emp = new Employee();
            emp.EmployeeID = model.EmployeeID;
            emp.Name = model.Name;
            emp.Father_Name = model.Father_Name;
            emp.Mother_Name = model.Mother_Name;
            emp.NID = model.NID;
            emp.Present_Address = model.Present_Address;
            emp.Permanent_Address = model.Permanent_Address;
            emp.Join_Date = model.Join_Date;
            emp.Designation = model.Designation;
            emp.Basic = model.Basic;
            emp.Bank_A_C_No = model.Bank_A_C_No;
            db.Employees.Add(emp);
            db.SaveChanges();  
            return View("AllEmployeeDetails");
        }

        public ActionResult AllEmployeeDetails()
        {
            var item = db.Employees.ToList();
            return View(item);
        }
        public ActionResult Delete(int id)
        {
            var item = db.Employees.Where(x => x.ID == id).First();
            db.Employees.Remove(item);
            db.SaveChanges();
            var item2 = db.Employees.ToList();
            return View("AllEmployeeDetails", item2);
        }
        public ActionResult EditEmployee(int id)
        {
            var item = db.Employees.Where(x => x.ID == id).First();
            return View(item);
        }

        [HttpPost]
        public ActionResult EditEmployee(Employee model)
        {
            var item = db.Employees.Where(x => x.ID == model.ID).First();
            item.EmployeeID = model.EmployeeID;
            item.Name = model.Name;
            item.Father_Name = model.Father_Name;
            item.Mother_Name = model.Mother_Name;
            item.NID = model.NID;
            item.Present_Address = model.Present_Address;
            item.Permanent_Address = model.Permanent_Address;
            item.Join_Date = model.Join_Date;
            item.Designation = model.Designation;
            item.Basic = model.Basic;
            item.Bank_A_C_No = model.Bank_A_C_No;
            db.SaveChanges();
            var item2 = db.Employees.ToList();
            return View("AllEmployeeDetails", item2);
        }
    }
}