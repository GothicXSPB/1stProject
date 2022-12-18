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
        private Company _company;

        [TestCaseSource(typeof(AddEmployeeTestsCaseSources))]
        public void AddEmployeeTest(List<Employee> expectedEmployees, Employee employee, AdminClass admin)
        {
            admin.AddEmployee(employee);

            List<Employee> actualEmployees = _company.Employees;
            CollectionAssert.AreEqual(expectedEmployees, actualEmployees);
        }

        [TestCaseSource(typeof(DeleteEmployeeTestsCaseSources))]
        public void DeleteEmployeeTest(List<Employee> expectedEmployees, List<Employee> employees, AdminClass admin)
        {
            _company.Employees = employees;
            admin.DeleteEmployee(2);
            
            List<Employee> actualEmployees = _company.Employees;
            CollectionAssert.AreEqual(expectedEmployees, actualEmployees);
        }

        [TestCaseSource(typeof(AddAdminTestsCaseSources))]
        public void AddAdminTest(List<Employee> expectedEmployees, List<Employee> employees, List<Employee> expectedAdmins, AdminClass admin)
        {
            _company.Employees = employees;
            admin.AddAdmin(1);
            admin.AddAdmin(3);

            List<Employee> actualEmployees = _company.Employees;
            List<AdminClass> actualAdmins = _company.Admins;
            CollectionAssert.AreEqual(expectedEmployees, actualEmployees);

            CollectionAssert.AreEqual(expectedAdmins, actualAdmins);
        }
    }
}