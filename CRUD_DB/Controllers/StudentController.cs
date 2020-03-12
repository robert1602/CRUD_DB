using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_DB.Models;

namespace CRUD_DB.Controllers
{
    public class StudentController : Controller
    {
        // 1. *************RETRIEVE ALL STUDENT DETAILS ******************
        // GET: Student/Read
        public ActionResult Index()
        {
            StudentDBHandle dBHandle = new StudentDBHandle();
            ModelState.Clear();
            return View(dBHandle.GetStudents());
        }

        // GET: Student/Details/5
        public ActionResult Details(int Id) //Cambiar a IdStudent
        {
            return View();
        }




        // 2. *************ADD NEW STUDENT ******************
        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }
   
        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(StudentModel oStudentModel)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    StudentDBHandle oStudent = new StudentDBHandle();
                    if (oStudent.AddStudent(oStudentModel))
                    {
                        ViewBag.Message = "Estudiante agregado exitosamente";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5/update
        public ActionResult Edit(int id) //Cambiar a IdStudent
        {
            StudentDBHandle dBHandle = new StudentDBHandle();
            return View(dBHandle.GetStudents().Find(oStudentModel=>oStudentModel.IdStudent == id));            
        }

        // POST: Student/Edit/5/update
        [HttpPost]
        public ActionResult Edit(int id, StudentModel oStudentModel)
        {
            try
            {
                // TODO: Add update logic here
                StudentDBHandle dBHandle = new StudentDBHandle();
                dBHandle.UpdateDetails(oStudentModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // 4. ************* DELETE STUDENT DETAILS ******************
        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
            StudentDBHandle dBHandle = new StudentDBHandle();
                if (dBHandle.DeleteStudents(id))
                {
                    ViewBag.AlertMsg = "Estudiante eliminado exitosamente" ;
                }
                return RedirectToAction("Index");

            }
            catch 
            {

            return View();
                
            }


        }        
        
    }
}
