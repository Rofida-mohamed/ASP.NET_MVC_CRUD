using MVC_D03.Models;

namespace MVC_D03.Services
{
    public class DepartmentRepo : IDepartmentRepo
    {
        ITIContext db = new ITIContext();

        public List<Department> GetAll()
        {
            return db.Departments.Where(d => d.Status == true).ToList();
        }

        public Department GetById(int id)
        {
            return db.Departments.SingleOrDefault(a => a.DeptId == id);
        }

        public Department GetByName(string name)
        {
            return db.Departments.SingleOrDefault(a => a.DeptName == name);
        }

        public void Add(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();
        }
        public void Update(Department department)
        {
            db.Departments.Update(department);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var m = GetById(id);
            m.Status = false;
            db.Departments.Update(m);
            db.SaveChanges();
        }
    }
}
