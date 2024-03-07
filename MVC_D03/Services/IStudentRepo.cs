using MVC_D03.Models;

namespace MVC_D03.Services
{
    public interface IStudentRepo
    {


        public List<Student> GetAll();


        public Student GetById(int id);


        public void Add(Student student);

        public void Update(Student student);


        public void Delete(int id);
        
    }
}
