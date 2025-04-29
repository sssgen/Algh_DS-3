using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var tree = new BinaryTree();

        // Додавання студентів
        tree.Insert(new Student("Іваненко", 3, 1001, 5.0, "Україна"));
        tree.Insert(new Student("Петренко", 2, 1002, 4.2, "Україна"));
        tree.Insert(new Student("Сидоренко", 3, 1003, 5.0, "Україна"));
        tree.Insert(new Student("Коваленко", 1, 1004, 3.7, "Польща"));
        tree.Insert(new Student("Мельник", 3, 1005, 4.9, "Україна"));

        Console.WriteLine("--- Вміст дерева (обхід у ширину) ---");
        tree.PrintBreadthFirst();

        Console.WriteLine("\n--- Студенти 3-го курсу, з середнім балом 5.0, громадяни України ---");
        var found = tree.Search(s => s.Course == 3 && s.AverageGrade == 5.0 && s.Citizenship == "Україна");

        if (found.Count == 0)
        {
            Console.WriteLine("Студентів не знайдено.");
        }
        else
        {
            Console.WriteLine($"{"Last Name",-15} {"Course",-6} {"Student ID",-12} {"Avg Grade",-10} {"Citizenship",-10}");
            Console.WriteLine(new string('-', 60));
            foreach (var student in found)
            {
                Console.WriteLine(student);
            }
        }

        Console.WriteLine("\n--- Видалення знайдених студентів ---");
        tree.Remove(s => s.Course == 3 && s.AverageGrade == 5.0 && s.Citizenship == "Україна");

        Console.WriteLine("\n--- Вміст дерева після видалення ---");
        tree.PrintBreadthFirst();
    }
}
