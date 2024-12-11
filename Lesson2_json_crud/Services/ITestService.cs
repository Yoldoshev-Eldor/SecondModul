using Lesson2_json_crud.Models;

namespace Lesson2_json_crud.Services
{
    public interface ITestService
    {
        public bool ChekLogin(string login, string password);
        public Test AddTest(Test newTest);
        public bool UpdateTest(Guid id);
        public bool DeleteTest(Guid id);
        public Test GetById(Guid id);
        public List<Test> GetAllTests();
        public List<Test> GetRandomTests(int count);

    }
}