using _1stProject;
using _1stProject.Options;
using static _1stProject.Database;

<<<<<<< HEAD
Employee employee1 = new Employee(1, "Andrey1", "88005553535", TimeTable.Shift5x2);
=======
Employee employee1 = new Employee(1, "Andrey1", "88005553535", "5/2");
Employee employee2 = new Employee(2, "Andrey2", "88005553535", "4/2");
Employee employee3 = new Employee(3, "Andrey3", "88005553535", "3/2");

>>>>>>> master

AdminClass admin = new AdminClass(2, "Andrey2", "89301654545", TimeTable.Shift1x3);

admin.AddEmployee(employee1);
<<<<<<< HEAD
Database.SaveAllEmployees();
=======
admin.AddEmployee(employee2);
admin.AddEmployee(employee3);
>>>>>>> master

admin.DeleteEmployee(2);
