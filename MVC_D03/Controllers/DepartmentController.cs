using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVC_D03.Models;
using MVC_D03.Services;
using MVC_D03.TestRepos;

namespace MVC_D03.Controllers
{
    [Authorize(Roles = "admin")]
    public class DepartmentController : Controller
    {
        //DepartmentRepo departmentRepo = new DepartmentRepo();

        //DepartmentTestRepo departmentRepo = new DepartmentTestRepo();

        IDepartmentRepo departmentRepo;

        public DepartmentController(IDepartmentRepo _departmentRepo)
        {
            departmentRepo = _departmentRepo;
        }
        public IActionResult Index()
        {
            var model = departmentRepo.GetAll();

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest("You must Provide data for id ");
            }
            var model = departmentRepo.GetById(id.Value);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return BadRequest("You must Provide data for id ");
            }
            var model = departmentRepo.GetById(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, Department d)
        {

            Department Dept = new Department();

            var existingDept = departmentRepo.GetById(id);

            existingDept.DeptName = d.DeptName;
            departmentRepo.Update(existingDept);

            return RedirectToAction("index");
        }

        public IActionResult Delete(int? id) {
            if (id == null)
            {
                return BadRequest("You must Provide data for id ");
            }
            var model = departmentRepo.GetById(id.Value);
            if (model == null)
            {
                return NotFound();
            }
            departmentRepo.Delete(id.Value);
            return RedirectToAction("Index");

        }


        [HttpPost]
        public IActionResult Create(Department d)
        {
            if (ModelState.IsValid)
            {

                
                try
                {
                    departmentRepo.Add(d);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }


                return RedirectToAction("Index");

            }
            else
            {

                return View(d);
            }


        }

        public IActionResult CheckDeptId(int deptId)
        {
            var model = departmentRepo.GetById(deptId);
            if (model != null) 
            {
                //int max = db.Departments.Max(a => a.DeptId);
                //return Json($"You can't use{deptId} try use {max+1}");
                return Json(false);
            }
            else
            {
                return Json(true);
            }
        }
        
        public IActionResult CheckDeptName(string name)
        {
            var model = departmentRepo.GetByName(name);
            if (model != null)
            {
                
                return Json($"You can't use {name} ");
                //return Json(false);
            }
            else
            {
                return Json(true);
            }
        }
    }
}
