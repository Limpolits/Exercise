using System;
using System.Collections.Generic;
using System.Linq;
class Employee
{
    public string Name {set; get;}
    public string Surname {set; get;}
    public string Type {set; get;}

    private static List<Employee> employees = new();
    
    public static void AddEmployee()
    {   
        Employee employee = new Employee();

        Console.WriteLine("Insert employee's name: ");
        employee.Name = Console.ReadLine();
        Console.WriteLine("Insert employee's surname: ");
        employee.Surname = Console.ReadLine();
        Console.WriteLine("Insert employee's type: ");
        employee.Type = Console.ReadLine();
        
        employees.Add(employee);
    }
    
    public static void DeleteEmployee()
    {
        Console.WriteLine("Insert employee's surname: ");
        string srnm = Console.ReadLine();

        var employee = employees.FirstOrDefault(e => e.Surname == srnm);

        if (employee != null)
        {
            employees.Remove(employee);
            Console.WriteLine("Employee deleted succesfully");
        }

        else
        {
            Console.WriteLine("Didn't found an employee with this surname");
        }
    }

    public static void DisplayEmployees()
    {
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees found");
        }

        foreach (var empl in employees)
        {
            Console.WriteLine($"Name: {empl.Name}, Surname: {empl.Surname}, Type: {empl.Type}");
        }
    }

    public static void FindEmployee()
    {
        Console.WriteLine("Insert employee's surname: ");
        string srnm = Console.ReadLine();

        foreach (var empl in employees)
        {
            if (empl.Surname == srnm)
            {
                Console.WriteLine($"Name: {empl.Name}, Surname: {empl.Surname}, Type: {empl.Type}");
            }
        }
    }
}

class Program
{    
    static void Main()
    {
        bool moveOn = true;
        while (moveOn)
        {
            Console.WriteLine("Enter your type:");
            Console.WriteLine("a) Manager");
            Console.WriteLine("b) Employee");
            string role = Console.ReadLine();

            if (role == "a")
            {
                Console.WriteLine("Select your action:");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Delete Employee");
                Console.WriteLine("3. Display Employees");
                Console.WriteLine("4. Find Employee");
                string number = Console.ReadLine();

                switch (number)
                {
                    case "1": 
                        Employee.AddEmployee();
                        break;
                    case "2": 
                        Employee.DeleteEmployee();
                        break;
                    case "3": 
                        Employee.DisplayEmployees();
                        break;
                    case "4": 
                        Employee.FindEmployee();
                        break;
                    default: 
                        Console.WriteLine("Please pick a valid choice");
                        break;
                }
            }

            else if (role == "b")
            {
                Console.WriteLine("1. Display Employees");
                Console.WriteLine("2. Find Employee");
                string number = Console.ReadLine();

                switch (number)
                {
                    case "1": 
                        Employee.DisplayEmployees();
                        break;
                    case "2": 
                        Employee.FindEmployee();
                        break;
                    default: 
                        Console.WriteLine("Please pick a valid choice");
                        break;
                }
            }

            else
            {
                Console.WriteLine("Please pick a valid choice");
                moveOn = false;
            }
        }
    }
}