using CURD_Demo.Models;
using CURD_Demo.DBContext;
using Dapper;


namespace CURD_Demo.Repositories
{
    public class StudentRepo : IStudentRepo
    {
        private readonly DapperContext _context;
        public StudentRepo(DapperContext context)
        {
            _context = context;
        }
        public IEnumerable<Student> GetAll()
        {
            using (var connection = _context.CreateConnection())
            {
                var sql = "SELECT * FROM Student";
                return connection.Query<Student>(sql);
            }
        }
        public Student? GetById(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                var sql = "SELECT * FROM Student WHERE Id = @Id";
                return connection.QuerySingleOrDefault<Student>(sql, new { Id = id });
            }
        }
        public void Add(Student student)
        {
            using (var connection = _context.CreateConnection())
            {
                var sql = "INSERT INTO Student (Name, Age, Email) VALUES (@Name, @Age, @Email)";
                connection.Execute(sql, student);
            }
        }
        public void Update(Student student)
        {
            using (var connection = _context.CreateConnection())
            {
                var sql = "UPDATE Student SET Name = @Name, Age = @Age, Email = @Email WHERE Id = @Id";
                connection.Execute(sql, student);
            }
        }
        public void Delete(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                var sql = "DELETE FROM Student WHERE Id = @Id";
                connection.Execute(sql, new { Id = id });
            }
        }

    }
}
