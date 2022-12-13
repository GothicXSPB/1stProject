using _1stProject;
using _1stProject.Options;

Employee employee1 = new Employee(1, "Andrey1", "88005553535", TimeTable.Shift2x2);

AdminClass admin = new AdminClass(2, "Andrey2", "89301654545", TimeTable.Shift5x2);

admin.AddEmployee(employee1);

Console.WriteLine();