namespace InsecureWebsite.Models;
public static class FakeEmployeeDatabase
{
    public static List<Employee> Employees = new List<Employee>
    {
        new Employee
        {
            Id = 2,
            Name = "Vincent Gar",
            Department = "HR",
            Username = "Vinnie Gar",
            Password = "DillWithANewPassword"
        },
        new Employee
        {
            Id = 3,
            Name = "Kevin Rousseau", //little kevin shout out for you
            Department = "The department of redundancy department",
            Username = "kDog",
            Password = "qwerty"
        },
        new Employee
        {
            Id = 4,
            Name = "Charlie Evans O'Connor",
            Department = "Ceoing",
            Username = "CEO",
            Password = "passwordpasswordpassword1"
        }
    };

    public static void AddEmployee(Employee employee)
    {
        Employees.Add(employee);
    }
}
    