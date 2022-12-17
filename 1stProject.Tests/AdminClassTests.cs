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

        [Test]
        public void DeleteEmployeeTest()
        {
            List<Employee> employees2 = new List<Employee>()
            {
                new Employee(1, "Andrey", "88005553535", TimeTable.Shift5x2),
            };

            Database.Employees = new List<Employee>()
            {
              new Employee(1, "Andrey", "88005553535", TimeTable.Shift5x2),
              new Employee(2, "Stepan", "88005553535", TimeTable.Shift2x2),
            };

            AdminClass admin = new AdminClass(4, "Darya", "89301654545", TimeTable.Shift1x3);

            admin.DeleteEmployee(2);

            List<Employee> expectedEmployees = employees2;
            List<Employee> actualEmployees = Database.Employees;
            CollectionAssert.AreEqual(expectedEmployees, actualEmployees);
        }

        //[Test]
        //public void AddAdminTest()
        //{
        //    List<Employee> employees3 = new List<Employee>()
        //    {
        //        new Employee(2, "Andrey", "88005553535", TimeTable.Shift5x2),
        //    };

        //    Database.Employees = new List<Employee>()
        //    {
        //      new Employee(1, "Andrey", "88005553535", TimeTable.Shift5x2),
        //      new Employee(2, "Stepan", "88005553535", TimeTable.Shift2x2),
        //      new Employee(3, "Irina", "88005553535", TimeTable.Shift1x3)
        //    };

        //    AdminClass admin = new AdminClass(4, "Darya", "89301654545", TimeTable.Shift1x3);

        //    admin.AddAdmin(1);
        //    admin.AddAdmin(3);

        //    List<Employee> expectedEmployees = employees3;
        //    List<Employee> actualEmployees = Database.Employees;
        //    CollectionAssert.AreEqual(expectedEmployees, actualEmployees);
        //}
    }
}