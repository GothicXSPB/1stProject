using _1stProject;
using _1stProject.Options;
using static _1stProject.Company;

Employee employee1 = new Employee(1, "Andrey Kokorin", "89032346789", TimeTable.Shift2x2);
Employee employee2 = new Employee(2, "Maxim Ivanov", "88001039456", TimeTable.Shift5x2);
Employee employee3 = new Employee(3, "Irina Popova", "89152745869", TimeTable.Shift2x2);
Employee employee4 = new Employee(4, "Katerina Apo", "84959238456", TimeTable.Shift1x3);
Employee employee5 = new Employee(5, "Artem Titov", "89024569432", TimeTable.Shift1x3);
Company company = new Company("Meow", 1);

AdminClass admin = new AdminClass(6, "Ivan Bobrov", "89301654545", TimeTable.Shift5x2, "Meow", 1);


company.SaveAllAdmins();
company.SaveAllCalendar();
company.SaveAllAdmins();
admin.AddEmployee(employee5);
admin.CreateNullTimeTable(2023);
admin.ApproveTimeTableForEmployeeAndSave(12, 03, 2023, employee5, 3);
admin.ShowScheduleForThePeriod2(DateTime.Parse("12.03.2023"), DateTime.Parse("12.04.2023"));

//admin.AddEmployee(employee1);

//company.SaveAllEmployees();

//admin.AddEmployee(employee2);
//admin.AddEmployee(employee3);


//admin.DeleteEmployee(2);

//TelegramBotManager telegramBot = new TelegramBotManager();

//Console.ReadLine();