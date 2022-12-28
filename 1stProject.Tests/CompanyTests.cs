using _1stProject;
using _1stProject.Tests.TestCaseSources;
using NUnit.Framework;
using System.Text.Json;

namespace _1stProject.Tests
{
    public class CompanyTests
    {
        private string _pathCompanyTests;
        private Company _company;

        [SetUp]
        public void SetUp()
        {
            _pathCompanyTests = @"../AllTests.test";
            _company = new Company("MultiTax", 6);
            _company._pathAdmins = _pathCompanyTests;
            _company._pathEmployees = _pathCompanyTests;
            _company._pathCalendar = _pathCompanyTests;
        }

        [TestCaseSource(typeof(IdAdminsCompanyTestsCaseSources))]
        public void SaveAllAdminsTests(List<long> IdAdmins)
        {
            _company.IdAdmins = IdAdmins;
            _company.SaveAllAdmins();

            List<long> expecredIdAdmins = _company.IdAdmins;
            List<long> actualIdAdmins;

            using (StreamReader sr = new StreamReader(_pathCompanyTests))
            {
                string jsn = sr.ReadLine()!;
                actualIdAdmins = JsonSerializer.Deserialize<List<long>>(jsn)!;
            }

            CollectionAssert.AreEqual(expecredIdAdmins, actualIdAdmins);
        }

        [TestCaseSource(typeof(IdAdminsCompanyTestsCaseSources))]
        public void LoadAllAdminsTests(List<long> IdAdmins)
        {
            using (StreamWriter sw = new StreamWriter(_pathCompanyTests))
            {
                string jsn = JsonSerializer.Serialize(IdAdmins);
                sw.WriteLine(jsn);
            }

            _company.LoadAllAdmins();

            List<long> expecredAllAdmins = IdAdmins;
            List<long> actualAllAdmins = _company.IdAdmins;

            CollectionAssert.AreEqual(expecredAllAdmins, actualAllAdmins);
        }
    }
}