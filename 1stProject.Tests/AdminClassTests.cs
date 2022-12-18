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
        public Company _company;
        
        [SetUp]
        public void SetUp()
        {
            _company = new Company();
        }

        [TestCaseSource(typeof(AddEmployeeTestsCaseSources))]
        public void AddEmployeeTest(List<Employee> expectedEmployees, Employee employee, AdminClass admin)
        {
            admin.AddEmployee(employee);
            List<Employee> actualEmployees = _company.Employees;
            //List<Employee> actualEmployees = admin.AddEmployee(employee);

            CollectionAssert.AreEqual(expectedEmployees, actualEmployees);
        }

        [TestCaseSource(typeof(DeleteEmployeeTestsCaseSources))]
        public void DeleteEmployeeTest(List<Employee> expectedEmployees, List<Employee> employees, AdminClass admin, int id)
        {
            admin.AddEmployee(employees[0]);                                    //гдеяэ бнопня!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            admin.AddEmployee(employees[1]);
            //_company.Employees=employees;

            List<Employee> actualEmployees = admin.DeleteEmployee(id);

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