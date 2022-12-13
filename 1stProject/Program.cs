using _1stProject;
using _1stProject.Options;

Employee employee1 = new Employee(1, "Andrey1", "88005553535", "5/2");
Employee employee2 = new Employee(2, "Andrey2", "88005553535", "4/2");
Employee employee3 = new Employee(3, "Andrey3", "88005553535", "3/2");


AdminClass admin = new AdminClass(2, "Andrey2", "89301654545", "3/2");

admin.AddEmployee(employee1);
admin.AddEmployee(employee2);
admin.AddEmployee(employee3);

admin.DeleteEmployee(2);
