using Microsoft.EntityFrameworkCore;
using MVC_D03.Models;

namespace MVC_D03.Services
{
    //CRUD Student
    public class StudentRepo : IStudentRepo
    {
        ITIContext db ;

        public StudentRepo (ITIContext db)
        {
            this.db = db;
        }

        public List<Student> GetAll()
        {
            return db.Students.Include(a=> a.Department).Where(a => a.Department.Status == true).ToList();
        }

        public Student GetById(int id) 
        {
            return db.Students.SingleOrDefault(a=> a.Id == id);
        }

        public void Add (Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }
        public void Update (Student student)
        {
            db.Students.Update(student);
            db.SaveChanges();
        }

        public void Delete (int id)
        {
            db.Students.Remove(GetById(id));
            db.SaveChanges();
        }
    }
}
