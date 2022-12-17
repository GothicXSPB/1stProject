using System.Xml;
using _1stProject;
using _1stProject.Options;
using _1stProject.Tests.TestCaseSourse;
using NUnit.Framework;

namespace _1stProject.Tests
{
    public class AdminClassTests
    {
        [TestCaseSource(typeof(AddEmployeeTestsCaseSources))]
        public void AddEmployeeTest(List<Employee> expectedEmployees, Employee employee, AdminClass admin)
        {
            admin.AddEmployee(employee);

            List<Employee> actualEmployees = Database.Employees;
            CollectionAssert.AreEqual(expectedEmployees, actualEmployees);
        }

        [TestCaseSource(typeof(DeleteEmployeeTestsCaseSources))]
        public void DeleteEmployeeTest(List<Employee> expectedEmployees, List<Employee> employees, AdminClass admin)
        {
            Database.Employees = employees;
            admin.DeleteEmployee(2);
            
            List<Employee> actualEmployees = Database.Employees;
            CollectionAssert.AreEqual(expectedEmployees, actualEmployees);
        }

        [TestCaseSource(typeof(AddAdminTestsCaseSources))]
        public void AddAdminTest(List<Employee> expectedEmployees, List<Employee> employees, List<Employee> expectedAdmins, AdminClass admin)
        {
            Database.Employees = employees;
            admin.AddAdmin(1);
            admin.AddAdmin(3);

            List<Employee> actualEmployees = Database.Employees;
            List<AdminClass> actualAdmins = Database.Admins;
            CollectionAssert.AreEqual(expectedEmployees, actualEmployees);

            CollectionAssert.AreEqual(expectedAdmins, actualAdmins);
        }
    }
}