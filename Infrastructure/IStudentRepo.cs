using DependencyInjection_Demo.Models;

namespace DependencyInjection_Demo.Infrastructure
{
    public interface IStudentRepo
    {
        List<Student> GetAll();
        Student GetById(int Id);

    }
}
