using DependencyInjection_Demo.Data;
using DependencyInjection_Demo.Infrastructure;
using DependencyInjection_Demo.Models;

namespace DependencyInjection_Demo.Repository
{
    public class StudentRepo : IStudentRepo
    {
        private List<Student> _context;
       
        public StudentRepo()
        {
            _context = new List<Student>()
            {
                 new Student { Id = 1, Name = "Kanchan", Email = "abc@xyz.com" },
                new Student { Id = 2, Name = "Era", Email = "xyz@abc.com" }
            };
        }

        public Student Add(Student student)
        {
            student.Id = _context.Max(s => s.Id)+1;
            _context.Add(student);
            return student;
        }

        public Student Delete(int Id)
        {
            Student student = _context.FirstOrDefault(s => s.Id == Id);
            if(student != null)
            {
                _context.Remove(student);
            }
            return student;
        }

        public IEnumerable<Student> GetAll()
        {
            return _context;
        }

        public Student GetById(int Id)
        {
            return _context.FirstOrDefault(x => x.Id == Id);
        }

        public Student Update(Student studentchanges)
        {
            Student student = _context.FirstOrDefault(s => s.Id == studentchanges.Id);
            if (student != null)
            {
                student.Name = studentchanges.Name;
                student.Email = studentchanges.Email;
            }
            return student;
        }
    }
}
