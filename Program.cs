using EF__CRUDDAPP.Data;
using EF__CRUDDAPP.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

static void PomiarCzasu(Action operation)
{
    var zegar = Stopwatch.StartNew();
    operation();
    zegar.Stop();
    Console.WriteLine($"Czas wynosi: {zegar.ElapsedMilliseconds}ms");
}

var zegar = Stopwatch.StartNew();
var db = new NorthwindContext();
zegar.Stop();
Console.WriteLine($"Czas wlaczenia wynosi: {zegar.ElapsedMilliseconds}ms");

//create
var addEmployee = () =>
{
    var employee = db.Employees.Add(new Employee()
    {
        FirstName = "Karol",
        LastName = "Kowalski"
    });
    db.SaveChanges();
};
PomiarCzasu(addEmployee);

//read
var employeeIdToRead = 900;
var readEmployeeByID = () =>
{
    var employee = db.Employees.Find(employeeIdToRead);

    if (employee == null)
    {
        Console.WriteLine("Nie istnieje");
    }
    else
    {
        Console.WriteLine($"Imie: {employee.FirstName} Nazwisko: {employee.LastName}");
    }
};
Console.WriteLine("getEmployeeByID");
PomiarCzasu(readEmployeeByID);

//edit
var employeeIdToUpdate = 300;
var UpdateEmployee = () =>
{
    var employee = db.Employees.Find(employeeIdToUpdate);
    {
        employee.Country = "Polska";
    }
    db.Employees.Update(employee);
    db.SaveChanges();
};
PomiarCzasu(UpdateEmployee);


//delete
var DeleteEmployee = () =>
{
    var employee = db.Employees.Find(996);
    {
        if (employee == null)
        {
            Console.WriteLine("Nie istnieje");

        }
        else
        {
            db.Employees.Remove(employee);
            db.SaveChanges();
        }
    }
};
Console.WriteLine("DeletedEmployee");
PomiarCzasu(DeleteEmployee);


/*static void MeasureMultipleEmployeeAdditions(Action operation, int numberOfEmployees)
{
    var stopwatch = Stopwatch.StartNew();
    var employeeTimes = new List<long>();

    for (int i = 0; i < numberOfEmployees; i++)
    {
        operation();
        employeeTimes.Add(stopwatch.ElapsedMilliseconds);
    }

    stopwatch.Stop();

    // Wypisz średnią arytmetyczną czasów dodawania pracowników
    var averageTime = employeeTimes.Any() ? employeeTimes.Average() : 0;
    Console.WriteLine($"Średni czas dodania pracownika: {averageTime} ms");
}

static string GenerateRandomName()
{
    string[] FirstName = { "John", "Jane", "Mike", "Emily", "David", "Sophia", "Daniel", "Olivia" };
    return FirstName[new Random().Next(FirstName.Length)];
}

static string GenerateRandomLastName()
{
    string[] LastName = { "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson" };
    return LastName[new Random().Next(LastName.Length)];
}

var addEmployeeOperation = () =>
{
    var employee = db.Employees.Add(new Employee()
    {
        FirstName = GenerateRandomName(),
        LastName = GenerateRandomLastName()
    });
    db.SaveChanges();
};

var numberOfEmployeesToAdd = 500;
Console.WriteLine($"Dodawanie {numberOfEmployeesToAdd} pracowników:");
MeasureMultipleEmployeeAdditions(addEmployeeOperation, numberOfEmployeesToAdd);*/


/*Console.WriteLine("addEmployeeByID");
PomiarCzasu(addEmployeeByID);
PomiarCzasu(addEmployeeByID);
PomiarCzasu(addEmployeeByID);
PomiarCzasu(addEmployeeByID);
Console.WriteLine("\n\n\n");*/


/*var getEmployeeByID2 = () =>
{
    var employee = db.Employees.Find(2);

    if (employee == null)
    {
        Console.WriteLine("Nie istnieje");
    }
    else
    {
        Console.WriteLine($"Imie: {employee.FirstName} Nazwisko: {employee.LastName}");
    }
};
Console.WriteLine("addEmployeeByID2");
PomiarCzasu(getEmployeeByID2);
Console.WriteLine("\n\n\n");*/

/*
var getAllEmployees = () =>
{
    var employees = db.Employees.ToList();
};
Console.WriteLine("getAllEmployees");
PomiarCzasu(getAllEmployees);
PomiarCzasu(getAllEmployees);
Console.WriteLine("\n\n\n");
*/

