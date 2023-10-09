using System;
using System.Collections.Generic;
class Phonebook
{
    static void Main(string[] args)
    {
        var contacts = new Dictionary<string, int>();
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("add, search, delete, print, exit");
            string command = Console.ReadLine().ToLower();
            switch (command)
            {
                case "add":
                    AddContact(contacts);
                    break;
                case "delete":
                    DeleteContact(contacts);
                    break;
                case "search":
                    SearchContact(contacts);
                    break;
                case "print":
                    PrintContacts(contacts);
                    break;
                case "exit":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("unrecognized command.");
                    break;
            }
        }
    }
    static void AddContact(Dictionary<string, int> contacts)
    {
        Console.WriteLine("enter the name:");
        string name = Console.ReadLine();
        if (contacts.ContainsKey(name))
        {
            Console.WriteLine("contact already exists");
            return;
        }
        Console.WriteLine("enter the number:");
        if (int.TryParse(Console.ReadLine(), out int number))
        {
            contacts[name] = number;
            Console.WriteLine("contact added");
        }
        else
        {
            Console.WriteLine("please enter a number");
        }
    }
    static void DeleteContact(Dictionary<string, int> contacts)
    {
        Console.WriteLine("enter the name or number to delete:");
        string input = Console.ReadLine();
        if (contacts.ContainsKey(input))
        {
            contacts.Remove(input);
            Console.WriteLine("contact deleted");
        }
        else
        {
            Console.WriteLine("contact not found");
        }
    }
    static void SearchContact(Dictionary<string, int> contacts)
    {
        Console.WriteLine("enter the name or number of contact to search");
        string input = Console.ReadLine();
        bool found = false;
        foreach (var contact in contacts)
        {
            if (contact.Key.Contains(input) || contact.Value.ToString().Contains(input))
            {
                Console.WriteLine($"name: {contact.Key}; number: {contact.Value}");
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("no contacts found.");
        }
    }
    static void PrintContacts(Dictionary<string, int> contacts)
    {
        Console.WriteLine("contact list:");
        foreach (var contact in contacts)
        {
            Console.WriteLine($"name: {contact.Key}; number: {contact.Value}");
        }
    }
}