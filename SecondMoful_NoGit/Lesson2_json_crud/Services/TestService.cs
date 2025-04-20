using Lesson2_json_crud.Models;
using System.Text.Json;

namespace Lesson2_json_crud.Services
{
    public class TestService : ITestService
    {
        private string testFilePath;
        private List<Test> _tests;
        public TestService()
        {
            testFilePath = "../../../Data/Test.json";

            if (File.Exists(testFilePath) is false)
            {
                File.WriteAllText(testFilePath, "[]");
            }

            _tests = new List<Test>();
            _tests = GetAllTests();
        }
        public bool ChekLogin (string login, string password)
        {
            var passChek = "student1";
            var passLog = "student1";
            if(login == passLog && password == passChek)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Test AddTest(Test newTest)
        {
            newTest.Id = Guid.NewGuid();

            _tests.Add(newTest);
            SaveData();
            return newTest;
        }
        public bool UpdateTest(Guid id)
        {
            var updateTest = GetById(id);

            if (updateTest is null)
            {
                return false;
            }
            var index = _tests.IndexOf(updateTest);
            _tests[index] = updateTest;
            SaveData();
            return true;
        }
        public bool DeleteTest(Guid id)
        {

            var deleteTest = GetById(id);
            if (deleteTest is null)
            {
                return false;
            }
            _tests.Remove(deleteTest);
            SaveData();
            return true;

        }
        public Test GetById(Guid id)
        {

            foreach (var test in _tests)
            {
                if (test.Id == id)
                {
                    return test;
                }
            }
            return null;
        }
        public List<Test> GetRandomTests(int count)
        {
            if (count >= _tests.Count)
            {
                return _tests;
            }

            var randomTests = new List<Test>();
            var rand = new Random();
            for (var i = 0; i < count;)
            {
                var option = rand.Next(0, _tests.Count);
                if (randomTests.Contains(_tests[option]) is false)
                {
                    randomTests.Add(_tests[option]);
                    i++;
                }
            }

            return randomTests;
        }

        private void SaveData()
        {
            var testJson = JsonSerializer.Serialize(_tests);
            File.WriteAllText(testFilePath, testJson);
        }
        public List<Test> GetAllTests()
        {
            return GetTests();
        }
        private List<Test> GetTests()
        {
            var testsJson = File.ReadAllText(testFilePath);
            var testsList = JsonSerializer.Deserialize<List<Test>>(testsJson);
            return testsList;
        }
    }
}
