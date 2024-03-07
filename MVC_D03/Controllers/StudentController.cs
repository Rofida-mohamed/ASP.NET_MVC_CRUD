using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_D03.Models;
using MVC_D03.Models.ViewModel;
using MVC_D03.Services;

namespace MVC_D03.Controllers
{
    [Authorize(Roles = "admin,instructor") ]
    public class StudentController : Controller
    {
        IStudentRepo studentRepo;
        IDepartmentRepo departmentRepo;

        public StudentController(IDepartmentRepo _departmentRepo, IStudentRepo _studentRepo)
        {
            departmentRepo = _departmentRepo;
            studentRepo = _studentRepo;
        }
        
        public IActionResult Index()
        {
            var model = studentRepo.GetAll();
           
            return View(model);
        }

        public IActionResult Create()
        {
            IEnumerable<Department> deptlist = departmentRepo.GetAll();
            StudentDepertment m = new StudentDepertment();
            m.dept = deptlist;
            return View(m);
        }

        [HttpPost]
        public IActionResult Create(Student std)
        {
            
            if ( ModelState.IsValid)
            {
               
                studentRepo.Add(std);
                return RedirectToAction("Index");

            }
            else
            {
                var deptlist = departmentRepo.GetAll();
                StudentDepertment m = new StudentDepertment();
                m.dept = deptlist;
                m.std = std;
                return View(m);
            }


        }

        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return BadRequest("You must Provide data for id ");
            }
            var std = studentRepo.GetById(id);
            if (std == null)
            {
                return NotFound();
            }
            StudentDepertment m = new StudentDepertment();
            m.std = std;
            m.dept = departmentRepo.GetAll();
            return View(m);
        }

        [HttpPost]
        public IActionResult Edit(int id,Student std)
        {


            var existingstd = studentRepo.GetById(id);

            existingstd.Name = std.Name;
            existingstd.Age = std.Age;
            existingstd.DeptNo = std.DeptNo;
            studentRepo.Update(existingstd);

            return RedirectToAction("index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("You must Provide data for id ");
            }
            var model = studentRepo.GetById(id.Value);
            if (model == null)
            {
                return NotFound();
            }
            studentRepo.Delete(id.Value);
            return RedirectToAction("Index");

        }


    }
}
