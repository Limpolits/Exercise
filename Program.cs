using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Employee
{
    public string Name {set; get;}
    public string Surname {set; get;}
    public string Type {set; get;}
}

class Program
{    
    static List<Employee> employees = new List<Employee>();
    
    static void AddEmployee()
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
    
    static void DeleteEmployee()
    {
        Console.WriteLine("Insert employee's surname: ");
        string srnm = Console.ReadLine();

        for (int i = 0; i < employees.Count; i++)
        {
            if (srnm == employees[i].Surname)
            {
                employees.RemoveAt(i);
                Console.WriteLine("Employee deleted");
                break;
            }
        }
    }

    static void DisplayEmployees()
    {
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees found");
        }

        foreach (var empl in employees)
        {
            Console.WriteLine("Name: " + empl.Name + "Surname: " + empl.Surname + "Type: " + empl.Type);
        }
    }

    static void FindEmployee()
    {
        Console.WriteLine("Insert employee's surname: ");
        string srnm = Console.ReadLine();

        foreach (var empl in employees)
        {
            if (empl.Surname == srnm)
            {
                Console.WriteLine("Name:" + empl.Name  + " Surname:" + empl.Surname + "  " + " Type: " + empl.Type);
            }
        }
    }

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
                        AddEmployee();
                        break;
                    case "2": 
                        DeleteEmployee();
                        break;
                    case "3": 
                        DisplayEmployees();
                        break;
                    case "4": 
                        FindEmployee();
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
                        DisplayEmployees();
                        break;
                    case "2": 
                        FindEmployee();
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