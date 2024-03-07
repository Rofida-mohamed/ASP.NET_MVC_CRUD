using MVC_D03.Models;
using MVC_D03.Services;

namespace MVC_D03.TestRepos
{
    public class StudentTestRepo :IStudentRepo
    {
        static List<Student> studentList = [
            new Student() { Id = 5 , Name = "Rofida", Age = 21, Email= "tod@gls.com", DeptNo = 20}
        ];

        public List<Student> GetAll()
        {
            //throw new NotImplementedException();
            return studentList;
        }

        public Student GetById(int id)
        {
            return studentList.SingleOrDefault(a => a.Id == id);
        }

        public void Add(Student student)
        {
            studentList.Add(student);
           
        }
        public void Update(Student student)
        {
            var s = GetById(student.Id);
            s.Name = student.Name;
            s.Age = student.Age;
            s.Email = student.Email;
            s.DeptNo = student.DeptNo;
            
        }

        public void Delete(int id)
        {
            
            studentList.Remove(GetById(id));
            
        }
    }
}
