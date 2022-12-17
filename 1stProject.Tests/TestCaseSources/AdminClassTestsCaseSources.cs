using System.Collections;
using _1stProject.Options;

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

}
