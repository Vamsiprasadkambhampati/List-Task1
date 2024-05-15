using System;
using System.Collections.Generic;

public class Class2
{
    public string Title { get; set; }
    public string Description { get; set; }

    public Class2(string title, string description)
    {
        Title = title;
        Description = description;
    }
}

public class TaskManager
{
    private List<Class2> tasks = new List<Class2>(); // Changed Task to Class2

    public void CreateTask(string title, string description)
    {
        tasks.Add(new Class2(title, description)); // Changed Task to Class2
        Console.WriteLine("Task created successfully.");
    }

    public void ReadTasks()
    {
        Console.WriteLine("\nTask List:");
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
        }
        else
        {
            foreach (var task in tasks)
            {
                Console.WriteLine($"Title: {task.Title}, Description: {task.Description}");
            }
        }
    }

    public void UpdateTask(string title, string newTitle, string newDescription)
    {
        Class2 taskToUpdate = tasks.Find(t => t.Title == title); // Changed Task to Class2
        if (taskToUpdate != null)
        {
            taskToUpdate.Title = newTitle;
            taskToUpdate.Description = newDescription;
            Console.WriteLine("Task updated successfully.");
        }
        else
        {
            Console.WriteLine("Task not found.");
        }
    }

    public void DeleteTask(string title)
    {
        Class2 taskToDelete = tasks.Find(t => t.Title == title); // Changed Task to Class2
        if (taskToDelete != null)
        {
            tasks.Remove(taskToDelete);
            Console.WriteLine("Task deleted successfully.");
        }
        else
        {
            Console.WriteLine("Task not found.");
        }
    }
}

public class Program
{
    static TaskManager taskManager = new TaskManager();

    static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nTask List Application\n");
            Console.WriteLine("1. Create a task");
            Console.WriteLine("2. Read tasks");
            Console.WriteLine("3. Update a task");
            Console.WriteLine("4. Delete a task");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter task title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter task description: ");
                        string description = Console.ReadLine();
                        taskManager.CreateTask(title, description);
                        break;
                    case 2:
                        taskManager.ReadTasks();
                        break;
                    case 3:
                        Console.Write("Enter the title of the task to update: ");
                        string oldTitle = Console.ReadLine();
                        Console.Write("Enter new title (leave empty to keep the same): ");
                        string newTitle = Console.ReadLine();
                        Console.Write("Enter new description (leave empty to keep the same): ");
                        string newDescription = Console.ReadLine();
                        taskManager.UpdateTask(oldTitle, newTitle, newDescription);
                        break;
                    case 4:
                        Console.Write("Enter the title of the task to delete: ");
                        string deleteTitle = Console.ReadLine();
                        taskManager.DeleteTask(deleteTitle);
                        break;
                    case 5:
                        exit = true;
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please select a valid option.");
            }
        }
    }
}
