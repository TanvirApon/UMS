using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University_Mangement_System.EF;

namespace University_Mangement_System.Controllers
{
    public class StudentController : Controller
    {


        // GET: Student
        umsEntities dbobj = new umsEntities();
        public ActionResult Student()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddStudent(tbl_Students model)
        {

            if (ModelState.IsValid)
            {
                tbl_Students obj = new tbl_Students();
                obj.name = model.name;
                obj.fname = model.fname;
                obj.email = model.email;
                obj.mobile = model.mobile;
                obj.description = model.description;

                dbobj.tbl_Students.Add(obj);
                dbobj.SaveChanges();

            }

            ModelState.Clear();


            return View("Student");
        }



        public ActionResult StudentList(tbl_Students model)
        {

            var res = dbobj.tbl_Students.ToList();

            return View(res);
        }


        public ActionResult Delete(int id)
        {

            var res = dbobj.tbl_Students.Where(x => x.id == id).First();
            dbobj.tbl_Students.Remove(res);
            dbobj.SaveChanges();

            var list = dbobj.tbl_Students.ToList();


            return View("StudentList",list);
        }



    }
}