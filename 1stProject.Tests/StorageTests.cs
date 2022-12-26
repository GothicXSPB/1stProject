using _1stProject;
using _1stProject.Tests.TestCaseSources;
using NUnit.Framework;
using System.Text.Json;

namespace _1stProject.Tests
{
    public class StorageTests
    {
        [TestCaseSource(typeof(LoadAllCompanyTestsCaseSources))]

        public void LoadAllCompanyTests(Dictionary<int, string> AllCompany)
        {
            string _pathTests = @"../AllTests/AllWorkerTests.txt";
            using (StreamReader sr = new StreamReader(_pathTests))
            {
                string jsn = sr.ReadLine()!;
                AllCompany = JsonSerializer.Deserialize<Dictionary<int, string>>(jsn)!;
            }

            Storage storage = new Storage();
            storage._pathAllCompany = _pathTests;
            storage.LoadAllCompany();

            Dictionary<int, string> expecredAllCompany = AllCompany;
            Dictionary<int, string> actualAllCompany = storage.AllCompany;

            CollectionAssert.AreEqual(expecredAllCompany, actualAllCompany);
        }
    }
}
