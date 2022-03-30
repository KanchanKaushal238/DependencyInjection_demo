using DependencyInjection_Demo.Data;
using DependencyInjection_Demo.Infrastructure;
using DependencyInjection_Demo.Models;

namespace DependencyInjection_Demo.Repository
{
    public class StudentRepo : IStudentRepo
    {
        private readonly ApplicationUser _context;
        private StudentRepo(ApplicationUser context)
        {
            _context = context;
        }
        public List<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student GetById(int Id)
        {
            return _context.Students.FirstOrDefault(x => x.Id == Id);
        }
    }
}
