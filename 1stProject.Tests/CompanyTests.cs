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

        [TestCaseSource(typeof(IdEmployeesCompanyTestsCaseSources))]
        public void SaveAllEmployeesTests(List<long> IdEmployees)
        {
            _company.IdEmployees = IdEmployees;
            _company.SaveAllEmployees();

            List<long> expecredIdEmployees = _company.IdEmployees;
            List<long> actualIdEmployees;

            using (StreamReader sr = new StreamReader(_pathCompanyTests))
            {
                string jsn = sr.ReadLine()!;
                actualIdEmployees = JsonSerializer.Deserialize<List<long>>(jsn)!;
            }

            CollectionAssert.AreEqual(expecredIdEmployees, actualIdEmployees);
        }

        [TestCaseSource(typeof(IdEmployeesCompanyTestsCaseSources))]
        public void LoadAllEmployeesTests(List<long> IdEmployees)
        {
            using (StreamWriter sw = new StreamWriter(_pathCompanyTests))
            {
                string jsn = JsonSerializer.Serialize(IdEmployees);
                sw.WriteLine(jsn);
            }

            _company.LoadAllEmployees();

            List<long> expecredAllEmployees = IdEmployees;
            List<long> actualAllEmployees = _company.IdEmployees;

            CollectionAssert.AreEqual(expecredAllEmployees, actualAllEmployees);
        }

        [TestCaseSource(typeof(CalendarCompanyTestsCaseSources))]
        public void SaveAllCalendarTests(Dictionary<int, List<long>> Calendar)
        {
            _company.Calendar = Calendar;
            _company.SaveAllCalendar();

            Dictionary<int, List<long>> expecredIdCalendar = _company.Calendar;
            Dictionary<int, List<long>> actualIdCalendar;

            using (StreamReader sr = new StreamReader(_pathCompanyTests))
            {
                string jsn = sr.ReadLine()!;
                actualIdCalendar = JsonSerializer.Deserialize<Dictionary<int, List<long>>>(jsn)!;
            }

            CollectionAssert.AreEqual(expecredIdCalendar, actualIdCalendar);
        }

        [TestCaseSource(typeof(CalendarCompanyTestsCaseSources))]
        public void LoadAllCalendarTests(Dictionary<int, List<long>> Calendar)
        {
            using (StreamWriter sw = new StreamWriter(_pathCompanyTests))
            {
                string jsn = JsonSerializer.Serialize(Calendar);
                sw.WriteLine(jsn);
            }

            _company.LoadAllCalendar();

            Dictionary<int, List<long>> expecredAllCalendar = Calendar;
            Dictionary<int, List<long>> actualAllCalendar = _company.Calendar;

            CollectionAssert.AreEqual(expecredAllCalendar, actualAllCalendar);
        }
    }
}