// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    // Encapsulation using Properties
    public int StudentId { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public int Year { get; set; }
    public int Marks { get; set; }

    // Constructor
    public Student(int studentId, string name, string department, int year, int marks)
    {
        StudentId = studentId;
        Name = name;
        Department = department;
        Year = year;
        Marks = marks;
    }

    // Method to display student details
    public void Display()
    {
        Console.WriteLine($"ID: {StudentId}, Name: {Name}, Dept: {Department}, Year: {Year}, Marks: {Marks}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Student> students = new List<Student>();

        // Creating multiple student objects
        students.Add(new Student(1, "Jeet", "Computer", 2, 85));
        students.Add(new Student(2, "Jay", "Mechanical", 3, 72));
        students.Add(new Student(3, "Saanvi", "Computer", 1, 90));
        students.Add(new Student(4, "Vrunda", "Civil", 4, 65));
        students.Add(new Student(5, "Deep", "IT", 2, 78));

        Console.WriteLine("===== All Student Records =====");
        foreach (var student in students)
        {
            student.Display();
        }

        // Students with marks > 75
        Console.WriteLine("\n===== Students with Marks > 75 =====");
        var highScorers = students.Where(s => s.Marks > 75);
        foreach (var student in highScorers)
        {
            student.Display();
        }

        // Sorting students by marks (Descending)
        Console.WriteLine("\n===== Students Sorted by Marks (Descending) =====");
        var sortedStudents = students.OrderByDescending(s => s.Marks);
        foreach (var student in sortedStudents)
        {
            student.Display();
        }

        // Top 3 Scorers
        Console.WriteLine("\n===== Top 3 Scorers =====");
        var top3 = students.OrderByDescending(s => s.Marks).Take(3);
        foreach (var student in top3)
        {
            student.Display();
        }
    }
}
