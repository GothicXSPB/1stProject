using _1stProject;
using _1stProject.Tests.TestCaseSources;
using NUnit.Framework;
using System.Text.Json;

namespace _1stProject.Tests
{
    public class StorageTests
    {
        private string _pathTests;
        private Storage _storage;

        [SetUp]
        public void SetUp()
        {
            _pathTests = @"../AllTests.test";
            _storage = new Storage();
            _storage._pathAllCompany = _pathTests;
            _storage._pathAllWorker = _pathTests;
        }

        [TestCaseSource(typeof(StorageCompanyTestsCaseSources))]
        public void LoadAllCompanyTests(Dictionary<int, string> AllCompany)
        {
            using (StreamWriter sw = new StreamWriter(_pathTests))
            {
                string jsn = JsonSerializer.Serialize(AllCompany);
                sw.WriteLine(jsn);
            }

            _storage.LoadAllCompany();

            Dictionary<int, string> expecredAllCompany = AllCompany;
            Dictionary<int, string> actualAllCompany = _storage.AllCompany;

            CollectionAssert.AreEqual(expecredAllCompany, actualAllCompany);
        }

        [TestCaseSource(typeof(StorageCompanyTestsCaseSources))]
        public void SaveAllCompanyTests(Dictionary<int, string> AllCompany)
        {
            _storage.AllCompany = AllCompany;
            _storage.SaveAllCompany();

            Dictionary<int, string> expecredAllCompany = _storage.AllCompany;
            Dictionary<int, string> actualAllCompany;

            using (StreamReader sr = new StreamReader(_pathTests))
            {
                string jsn = sr.ReadLine()!;
                actualAllCompany = JsonSerializer.Deserialize<Dictionary<int, string>>(jsn)!;
            }

            CollectionAssert.AreEqual(expecredAllCompany, actualAllCompany);
        }

        [Test]
        public void LoadAllCompany_IfFileDifferent_ShouldThrowDirectoryNotFoundException()
        {
            _pathTests = "whereNOfile.test";
            Assert.Throws<DirectoryNotFoundException>(() => _storage.LoadAllCompany());
        }

        [TestCaseSource(typeof(StorageWorkerTestsCaseSources))]
        public void LoadAllWorkerTests(Dictionary<long, List<int>> AllWorker)
        {
            using (StreamWriter sw = new StreamWriter(_pathTests))
            {
                string jsn = JsonSerializer.Serialize(AllWorker);
                sw.WriteLine(jsn);
            }

            _storage.LoadAllWorker();

            Dictionary<long, List<int>> expecredAllWorker = AllWorker;
            Dictionary<long, List<int>> actualAllWorker = _storage.AllWorker;

            CollectionAssert.AreEqual(expecredAllWorker, actualAllWorker);
        }

        [TestCaseSource(typeof(StorageWorkerTestsCaseSources))]
        public void SaveAllWorkerTests(Dictionary<long, List<int>> AllWorker)
        {
            using (StreamWriter sw = new StreamWriter(_pathTests))
            {
                string jsn = JsonSerializer.Serialize(AllWorker);
                sw.WriteLine(jsn);
            }

            _storage.LoadAllWorker();

            Dictionary<long, List<int>> expecredAllWorker = AllWorker;
            Dictionary<long, List<int>> actualAllWorker = _storage.AllWorker;

            CollectionAssert.AreEqual(expecredAllWorker, actualAllWorker);
        }

        [Test]
        public void LoadAllWorker_IfFileDifferent_ShouldThrowDirectoryNotFoundException()
        {
            _pathTests = "whereNOfile.test";
            Assert.Throws<DirectoryNotFoundException>(() => _storage.LoadAllWorker());
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(_pathTests);
        }
    }
}
