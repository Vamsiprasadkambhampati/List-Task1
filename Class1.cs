using System;
using System.Collections.Generic;

public class Class1
{
    private List<Task> tasks = new List<Task>();

    public void CreateTask(string title, string description)
    {
        tasks.Add(new Task(title, description));
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
        Task taskToUpdate = tasks.Find(t => t.Title == title);
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
        Task taskToDelete = tasks.Find(t => t.Title == title);
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