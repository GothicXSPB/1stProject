using _1stProject;
using _1stProject.Options;
using static _1stProject.Database;


Employee employee1 = new Employee(1, "Andrey1", "88005553535", TimeTable.Shift5x2);

AdminClass admin = new AdminClass(2, "Andrey2", "89301654545", TimeTable.Shift1x3);

admin.AddEmployee(employee1);

Database.SaveAllEmployees();




admin.DeleteEmployee(2);
