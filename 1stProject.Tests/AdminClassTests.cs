using System.Xml;
using _1stProject;
using _1stProject.Options;
using NUnit.Framework;

namespace _1stProject.Tests
{
    public class AdminClassTests
    {
        [Test]
        public void AddEmployeeTest()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee(1, "Andrey", "88005553535", TimeTable.Shift5x2),
            };

            Employee employee1 = new Employee(1, "Andrey", "88005553535", TimeTable.Shift5x2);
            
            AdminClass admin = new AdminClass(4, "Darya", "89301654545", TimeTable.Shift1x3);

            admin.AddEmployee(employee1);

            List<Employee> expectedEmployees = employees;
            List<Employee> actualEmployees = Company.IdEmployees;
            CollectionAssert.AreEqual(expectedEmployees, actualEmployees);
        }
        [Test]
        public void DeleteEmployeeTest()
        {
            List<Employee> employees1 = new List<Employee>()
            {
                new Employee(1, "Andrey", "88005553535", TimeTable.Shift5x2),
            };

            Company.IdEmployees = new List<Employee>()
            {
              new Employee(1, "Andrey", "88005553535", TimeTable.Shift5x2),
              new Employee(2, "Stepan", "88005553535", TimeTable.Shift2x2),
            };

            AdminClass admin = new AdminClass(4, "Darya", "89301654545", TimeTable.Shift1x3);

            admin.DeleteEmployee(2);

            List<Employee> expectedEmployees = employees1;
            List<Employee> actualEmployees = Company.IdEmployees;
            CollectionAssert.AreEqual(expectedEmployees, actualEmployees);
        }
    }
}