using System;
using System.Collections.Generic;

class Task
{
    public string Title { get; set; }
    public string Description { get; set; }
}

class TaskManager
{
    private List<Task> tasks = new List<Task>();

    public void AddTask(string title, string description)
    {
        Task task = new Task { Title = title, Description = description };
        tasks.Add(task);
        Console.WriteLine("Task added successfully.");
    }

    public void ReadTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
        }
        else
        {
            Console.WriteLine("Tasks:");
            foreach (var task in tasks)
            {
                Console.WriteLine($"Title: {task.Title}, Description: {task.Description}");
            }
        }
    }

    public void UpdateTask(string title, string newTitle, string newDescription)
    {
        Task task = tasks.Find(t => t.Title == title);
        if (task != null)
        {
            task.Title = newTitle;
            task.Description = newDescription;
            Console.WriteLine("Task updated successfully.");
        }
        else
        {
            Console.WriteLine("Task not found.");
        }
    }

    public void DeleteTask(string title)
    {
        Task task = tasks.Find(t => t.Title == title);
        if (task != null)
        {
            tasks.Remove(task);
            Console.WriteLine("Task deleted successfully.");
        }
        else
        {
            Console.WriteLine("Task not found.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        TaskManager taskManager = new TaskManager();

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add a task");
            Console.WriteLine("2. Read tasks");
            Console.WriteLine("3. Update a task");
            Console.WriteLine("4. Delete a task");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                Console.Write("Enter your choice: ");
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter task title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter task description: ");
                    string description = Console.ReadLine();
                    taskManager.AddTask(title, description);
                    break;
                case 2:
                    taskManager.ReadTasks();
                    break;
                case 3:
                    Console.Write("Enter title of the task to update: ");
                    string oldTitle = Console.ReadLine();
                    Console.Write("Enter new title: ");
                    string newTitle = Console.ReadLine();
                    Console.Write("Enter new description: ");
                    string newDescription = Console.ReadLine();
                    taskManager.UpdateTask(oldTitle, newTitle, newDescription);
                    break;
                case 4:
                    Console.Write("Enter title of the task to delete: ");
                    string taskToDelete = Console.ReadLine();
                    taskManager.DeleteTask(taskToDelete);
                    break;
                case 5:
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }
}
