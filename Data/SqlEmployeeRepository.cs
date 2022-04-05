using DependencyInjection_Demo.Infrastructure;
using DependencyInjection_Demo.Models;

namespace DependencyInjection_Demo.Data
{
    public class SqlEmployeeRepository : IStudentRepo
    {
        private readonly ApplicationUser _user;
        public SqlEmployeeRepository(ApplicationUser user)
        {
            _user = user;
        }
        public Student Add(Student student)
        {
            _user.Student.Add(student);
            _user.SaveChanges();
            return student;
        }

        public Student Delete(int Id)
        {
           Student student = _user.Student.Find(Id);
            if(student != null)
            {
                _user.Student.Remove(student);
                _user.SaveChanges();
            }
            return student;
        }

        public IEnumerable<Student> GetAll()
        {
            return _user.Student;
        }

        public Student GetById(int Id)
        {
           return  _user.Student.Find(Id);
        }

        public Student Update(Student studentchanges)
        {
            var student = _user.Student.Attach(studentchanges);
            student.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _user.SaveChanges();
            return studentchanges;
        }
    }
}
