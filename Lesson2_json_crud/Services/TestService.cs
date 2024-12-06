using Lesson2_json_crud.Models;
using System.Text.Json;

namespace Lesson2_json_crud.Services
{
    public class TestService
    {
        private string testFilePath;
        public TestService()
        {
            testFilePath = "../../../Data/Tests.json";
        }
        public Test AddTest(Test newTest)
        {
            newTest.Id = Guid.NewGuid();
            var tests = GetTests();
            tests.Add(newTest);
            SaveData(tests);
            return newTest;
        }
        public bool UpdateTest(Guid id)
        {
            var updateTest = GetById(id);
            var testsList = GetTests();
            if (testsList is null)
            {
                return false;
            }
            var index = testsList.IndexOf(updateTest);
            testsList[index] = updateTest;
            SaveData(testsList);
            return true;
        }
        public bool DeleteTest(Guid id)
        {
            var testList = GetTests();
            var deleteTest = GetById(id);
            if (deleteTest is null)
            {
                return false;
            }
            testList.Remove(deleteTest);
            SaveData(testList);
            return true;

        }
        public Test GetById(Guid id)
        {
            var testsList = GetTests();
            foreach (var test in testsList)
            {
                if (test.Id == id)
                {
                    return test;
                }
            }
            return null;
        }
            private void SaveData(List<Test> tests)
            {
                var testJson = JsonSerializer.Serialize(tests);
                File.WriteAllText(testFilePath, testJson);
            }
            private List<Test> GetTests()
            {
                var testsJson = File.ReadAllText(testFilePath);
                var testsList = JsonSerializer.Deserialize<List<Test>>(testsJson);
                return testsList;
            }
        }
    }
