using System.Collections;
using _1stProject.Options;
using static _1stProject.Company;

namespace _1stProject.Tests.TestCaseSourse
{
    public class AddEmployeeTestsCaseSources : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<Employee> expectedEmployees = new List<Employee>()
            {
                new Employee(1, "Andrey Kokorin", "89032346789", TimeTable.Shift2x2)
            };

            Employee employee = new Employee(1, "Andrey Kokorin", "89032346789", TimeTable.Shift2x2);

            AdminClass admin = new AdminClass(4, "Darya", "89301654545", TimeTable.Shift1x3);

            yield return new Object[] { expectedEmployees, employee, admin};
        }
    }

    public class DeleteEmployeeTestsCaseSources : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<Employee> expectedEmployees = new List<Employee>()
            {
                new Employee(1, "Andrey Kokorin", "89032346789", TimeTable.Shift2x2),
            };

            List<Employee> Employees = new List<Employee>()
            {
                new Employee(1, "Andrey Kokorin", "89032346789", TimeTable.Shift2x2),
                new Employee(2, "Maxim Ivanov", "88001039456", TimeTable.Shift5x2)
            };

            AdminClass admin = new AdminClass(4, "Darya", "89301654545", TimeTable.Shift1x3);

            int id = 2;

            yield return new Object[] { expectedEmployees, Employees, admin , id };
        }
    }

    public class AddAdminTestsCaseSources : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<Employee> expectedEmployees = new List<Employee>()
            {
                new Employee(2, "Stepan", "88005553535", TimeTable.Shift2x2),
            };

            List<Employee>  employees = new List<Employee>()
            {
              new Employee(1, "Andrey", "88005553535", TimeTable.Shift5x2),
              new Employee(2, "Stepan", "88005553535", TimeTable.Shift2x2),
              new Employee(3, "Irina", "88005553535", TimeTable.Shift1x3)
            };

            List<Employee> expectedAdmins = new List<Employee>()
            {
              new Employee(1, "Andrey", "88005553535", TimeTable.Shift5x2),
              new Employee(3, "Irina", "88005553535", TimeTable.Shift1x3)
            };


            AdminClass admin = new AdminClass(4, "Darya", "89301654545", TimeTable.Shift1x3);

            yield return new Object[] { expectedEmployees, employees, expectedAdmins, admin };
        }
    }
}
