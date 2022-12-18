using System.Xml;
using _1stProject;
using _1stProject.Options;
using _1stProject.Tests.TestCaseSourse;
using NUnit.Framework;
using static _1stProject.Company;

namespace _1stProject.Tests
{
    public class AdminClassTests
    {
        private Company _companyTest;
        
        [SetUp]
        public void SetUp()
        {
            _companyTest = new Company();
        }

        [TestCaseSource(typeof(AddEmployeeTestsCaseSources))]
        public void AddEmployeeTest(List<Employee> expectedEmployees, Employee employee, AdminClass admin)
        {
            List<Employee> actualEmployees = admin.AddEmployee(employee);

            CollectionAssert.AreEqual(expectedEmployees, actualEmployees);
        }

        [TestCaseSource(typeof(DeleteEmployeeTestsCaseSources))]
        public void DeleteEmployeeTest(List<Employee> expectedEmployees, List<Employee> employees, AdminClass admin, int id)
        {
            admin.AddEmployee(employees[0]);                                    //гдеяэ бнопня!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            admin.AddEmployee(employees[1]);

            List<Employee> actualEmployees = admin.DeleteEmployee(id);

            CollectionAssert.AreEqual(expectedEmployees, actualEmployees);
        }

        [TestCaseSource(typeof(AddAdminTestsCaseSources))]
        public void AddAdminTest(List<Employee> expectedEmployees, List<Employee> employees, List<AdminClass> expectedAdmins, AdminClass admin)
        {
            admin.AddEmployee(employees[0]);                                    //гдеяэ бнопня!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            admin.AddEmployee(employees[1]);

            //List<Employee> actualEmployees = _companyTest.Employees;
            List<AdminClass> actualAdmins = admin.AddAdmin(2);
            //CollectionAssert.AreEqual(expectedEmployees, actualEmployees);

            CollectionAssert.AreEqual(expectedAdmins, actualAdmins);
        }
    }
}