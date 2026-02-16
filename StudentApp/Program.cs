// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementApp
{
    // Class definition representing StudentDetails
    class StudentDetails
    {
        public int student_id { get; set; }
        public string name { get; set; }
        public string department { get; set; }
        public int marks { get; set; }

        public override string ToString()
        {
            return $"ID: {student_id}, Name: {name}, Dept: {department}, Marks: {marks}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<StudentDetails> students = new List<StudentDetails>();
            string command;

            Console.WriteLine("--- Student Management System ---");
            Console.WriteLine("Enter student details (type 'exit' to finish input):");

            // 1. Accept student details from user
            while (true)
            {
                Console.Write("Enter ID (or 'exit'): ");
                command = Console.ReadLine();
                if (command.ToLower() == "exit") break;

                StudentDetails student = new StudentDetails();
                student.student_id = int.Parse(command);
                
                Console.Write("Enter Name: ");
                student.name = Console.ReadLine();
                
                Console.Write("Enter Department: ");
                student.department = Console.ReadLine();
                
                Console.Write("Enter Marks: ");
                student.marks = int.Parse(Console.ReadLine());

                students.Add(student);
                Console.WriteLine("Student added!\n");
            }

            // 2. Display all student records
            Console.WriteLine("\n--- All Student Records ---");
            students.ForEach(s => Console.WriteLine(s.ToString()));

            // 3. Display only name and department
            Console.WriteLine("\n--- Names and Departments ---");
            students.ForEach(s => Console.WriteLine($"Name: {s.name}, Dept: {s.department}"));

            // 4. Find students with marks greater than 75
            Console.WriteLine("\n--- Students with Marks > 75 ---");
            var highScorers = students.Where(s => s.marks > 75);
            foreach (var s in highScorers) Console.WriteLine(s.ToString());

            // 5. Display students from specific department (e.g., "CS")
            Console.Write("\n--- Enter Department to Filter: ");
            string deptFilter = Console.ReadLine();
            var deptStudents = students.Where(s => s.department.Equals(deptFilter, StringComparison.OrdinalIgnoreCase));
            foreach (var s in deptStudents) Console.WriteLine(s.ToString());

            // 6. Sort students by marks (descending order)
            Console.WriteLine("\n--- Students Sorted by Marks (Desc) ---");
            var sortedStudents = students.OrderByDescending(s => s.marks);
            foreach (var s in sortedStudents) Console.WriteLine(s.ToString());

            // 7. Display top scorer
            Console.WriteLine("\n--- Top Scorer ---");
            var topScorer = students.OrderByDescending(s => s.marks).FirstOrDefault();
            if (topScorer != null)
                Console.WriteLine(topScorer.ToString());
        }
    }
}

