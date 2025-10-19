// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;

namespace TaskManager
{
    // Represents a single task
    public class Task
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public Task(int id, string description)
        {
            Id = id;
            Description = description;
            IsCompleted = false;
        }

        public override string ToString()
        {
            string status = IsCompleted ? "[Completed]" : "[Pending]";
            return $"Task {Id}: {Description} {status}";
        }
    }

    // Main program class
    class Program
    {
        private static List<Task> tasks = new List<Task>();
        private static int nextId = 1;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Simple Task Manager!");
            Console.WriteLine("Commands: add <description>, view, complete <id>, remove <id>, quit");

            while (true)
            {
                Console.Write("> ");
                string input = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(input))
                    continue;

                string[] parts = input.Split(' ', 2);
                string command = parts[0].ToLower();

                switch (command)
                {
                    case "add":
                        if (parts.Length < 2)
                        {
                            Console.WriteLine("Error: Provide a description after 'add'.");
                            break;
                        }
                        AddTask(parts[1]);
                        break;
                    case "view":
                        ViewTasks();
                        break;
                    case "complete":
                        if (parts.Length < 2 || !int.TryParse(parts[1], out int completeId))
                        {
                            Console.WriteLine("Error: Provide a valid ID after 'complete'.");
                            break;
                        }
                        CompleteTask(completeId);
                        break;
                    case "remove":
                        if (parts.Length < 2 || !int.TryParse(parts[1], out int removeId))
                        {
                            Console.WriteLine("Error: Provide a valid ID after 'remove'.");
                            break;
                        }
                        RemoveTask(removeId);
                        break;
                    case "quit":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine($"Unknown command: {command}. Try 'add', 'view', 'complete <id>', 'remove <id>', or 'quit'.");
                        break;
                }
            }
        }

        private static void AddTask(string description)
        {
            var task = new Task(nextId++, description);
            tasks.Add(task);
            Console.WriteLine($"Added: {task}");
        }

        private static void ViewTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks yet. Add one with 'add <description>'.");
                return;
            }

            Console.WriteLine("\n--- Your Tasks ---");
            foreach (var task in tasks)
            {
                Console.WriteLine(task);
            }
            Console.WriteLine("------------------\n");
        }

        private static void CompleteTask(int id)
        {
            var task = tasks.Find(t => t.Id == id);
            if (task == null)
            {
                Console.WriteLine($"Task with ID {id} not found.");
                return;
            }
            task.IsCompleted = true;
            Console.WriteLine($"Marked as complete: {task}");
        }

        private static void RemoveTask(int id)
        {
            var task = tasks.Find(t => t.Id == id);
            if (task == null)
            {
                Console.WriteLine($"Task with ID {id} not found.");
                return;
            }
            tasks.Remove(task);
            Console.WriteLine($"Removed: {task}");
        }
    }
}