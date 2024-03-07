using MVC_D03.Models;

namespace MVC_D03.Services
{
    public interface IDepartmentRepo
    {

        public List<Department> GetAll();
        public Department GetById(int id);
        public Department GetByName(string name);
        public void Add(Department department);
        public void Update(Department department);
        public void Delete(int id);
        
    }
}
