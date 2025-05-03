using CURD_Demo.Models;

namespace CURD_Demo.Repositories
{
    public interface IStudentRepo
    {
        IEnumerable<Student> GetAll();
        Student? GetById(int id);
        void Add(Student student);
        void Update(Student student);
        void Delete(int id);
    }
}
