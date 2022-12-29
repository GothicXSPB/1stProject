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
        private Storage _base;

        [SetUp]
        public void SetUp()
        {
            _pathCompanyTests = @"../AllTests.test";
            _base = new Storage();
            _base._pathAllCompany = @"../StorageTests.test";
            _base._pathAllWorker = @"../StorageTests.test";
            _company.PathAdmins = _pathCompanyTests;
            _company.PathEmployees = _pathCompanyTests;
            _company.PathCalendar = _pathCompanyTests;
        }

        [TestCaseSource(typeof(IdAdminsCompanyTestsCaseSources))]
        public void SaveAllAdminsTests(List<long> IdAdmins)
        {
            _company.IdAdmins = IdAdmins;
            _company.SaveAllAdmins();

            List<long> expectedIdAdmins = _company.IdAdmins;
            List<long> actualIdAdmins;

            using (StreamReader sr = new StreamReader(_pathCompanyTests))
            {
                string jsn = sr.ReadLine()!;
                actualIdAdmins = JsonSerializer.Deserialize<List<long>>(jsn)!;
            }

            CollectionAssert.AreEqual(expectedIdAdmins, actualIdAdmins);
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

            List<long> expectedAllAdmins = IdAdmins;
            List<long> actualAllAdmins = _company.IdAdmins;

            CollectionAssert.AreEqual(expectedAllAdmins, actualAllAdmins);
        }

        [TestCaseSource(typeof(IdEmployeesCompanyTestsCaseSources))]
        public void SaveAllEmployeesTests(List<long> IdEmployees)
        {
            _company.IdEmployees = IdEmployees;
            _company.SaveAllEmployees();

            List<long> expectedIdEmployees = _company.IdEmployees;
            List<long> actualIdEmployees;

            using (StreamReader sr = new StreamReader(_pathCompanyTests))
            {
                string jsn = sr.ReadLine()!;
                actualIdEmployees = JsonSerializer.Deserialize<List<long>>(jsn)!;
            }

            CollectionAssert.AreEqual(expectedIdEmployees, actualIdEmployees);
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

            List<long> expectedAllEmployees = IdEmployees;
            List<long> actualAllEmployees = _company.IdEmployees;

            CollectionAssert.AreEqual(expectedAllEmployees, actualAllEmployees);
        }

        [TestCaseSource(typeof(CalendarCompanyTestsCaseSources))]
        public void SaveAllCalendarTests(Dictionary<int, List<long>> Calendar)
        {
            _company.Calendar = Calendar;
            _company.SaveAllCalendar();

            Dictionary<int, List<long>> expectedIdCalendar = _company.Calendar;
            Dictionary<int, List<long>> actualIdCalendar;

            using (StreamReader sr = new StreamReader(_pathCompanyTests))
            {
                string jsn = sr.ReadLine()!;
                actualIdCalendar = JsonSerializer.Deserialize<Dictionary<int, List<long>>>(jsn)!;
            }

            CollectionAssert.AreEqual(expectedIdCalendar, actualIdCalendar);
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

            Dictionary<int, List<long>> expectedAllCalendar = Calendar;
            Dictionary<int, List<long>> actualAllCalendar = _company.Calendar;

            CollectionAssert.AreEqual(expectedAllCalendar, actualAllCalendar);
        }

        [TestCaseSource(typeof(DateToNumberDayTestsCaseSources))]
        public void DateToNumberDayTests(int numberperday, DateTime thisdate)
        {
            int expectedNumber = _company.DateToNumberDay(thisdate);
            int actualNumber = numberperday;

            Assert.That(actualNumber, Is.EqualTo(expectedNumber));
        }
    }
}