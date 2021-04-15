using crud_core_m_table_ent.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_core_m_table_ent.Controllers
{
    public class StudentController : Controller
    {

        private readonly StudentContext _Db;

        public StudentController(StudentContext Db)
        {
            _Db = Db;
        }
        public IActionResult StudentList()
        { 

            try
            {
                //var stdlist = _Db.tblStudent.ToList();
                var stdlist = from a in _Db.tblStudent
                              join b in _Db.tblDepartment
                              on a.Department_Name equals b.ID
                              into Dep
                              from b in Dep.DefaultIfEmpty()

                              select new Student
                              {
                                  ID = a.ID,
                                  Name = a.Name,
                                  Gender = a.Gender,
                                  Age = a.Age,
                                  Department_Name = a.Department_Name,

                                  Department=b==null?"":b.DepartmentName
                              };

                return View(stdlist);
            }
            catch(Exception ex)
            {
                return View();
            }

            
        }


        public IActionResult Create(Student obj)
        {
            loadDDL();
            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(Student obj)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if (obj.ID == 0)
                    {
                        _Db.tblStudent.Add(obj);
                        await _Db.SaveChangesAsync();

                    }
                    else
                    {
                        _Db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _Db.SaveChangesAsync();
                    }
                   

                    return RedirectToAction("StudentList");
                }

                return View();
            }
            catch (Exception ex)
            {

                return RedirectToAction("StudentList");
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var std =await _Db.tblStudent.FindAsync(id);
                if (std != null)
                {
                    _Db.tblStudent.Remove(std);
                    await _Db.SaveChangesAsync();
                }

                return RedirectToAction("StudentList");
            }
            catch(Exception ex)
            {
                return RedirectToAction("StudentList");
            }
        }


        private void loadDDL()
        {
            try
            {
                List<Departments> depList = new List<Departments>();
                depList = _Db.tblDepartment.ToList();

                depList.Insert(0, new Departments { ID = 0, DepartmentName = "Please Select" });

                ViewBag.DepList = depList;
            }
            catch(Exception ex)
            {

            }
        }
    }
}
