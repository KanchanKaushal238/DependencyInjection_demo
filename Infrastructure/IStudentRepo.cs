using DependencyInjection_Demo.Models;

namespace DependencyInjection_Demo.Infrastructure
{
    public interface IStudentRepo
    {
        IEnumerable<Student> GetAll();
        Student GetById(int Id);
        Student Add(Student student);
        Student Update(Student studentchanges);
        Student Delete(int Id);

    }
}
