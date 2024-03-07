using MVC_D03.Models;
using MVC_D03.Services;

namespace MVC_D03.TestRepos
{
    public class DepartmentTestRepo :IDepartmentRepo

    {
        List<Department> deptList = [
            new Department() { DeptId = 20, DeptName= "tseting"}
        ];

       

        public List<Department> GetAll()
        {
            return deptList ;
        }

        public Department GetById(int id)
        {
            return deptList.SingleOrDefault(a => a.DeptId == id);
        }

        public Department GetByName(string name)
        {
            return deptList.SingleOrDefault(a => a.DeptName == name);
        }

        public void Add(Department department)
        {
            deptList.Add(department);
            
        }
        public void Update(Department department)
        {
            var m = GetById(department.DeptId);
            m.DeptName = department.DeptName;
            m.Status = department.Status;
            
        }

        public void Delete(int id)
        {
            var m = GetById(id);
            //m.Status = false;
            deptList.Remove(m);
        }
    }

}
