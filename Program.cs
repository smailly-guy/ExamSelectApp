using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

class User
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public override string ToString()
    {
        return $"ID: {Id}, Name: {FullName}, Email: {Email}, Phone: {Phone}";
    }
}

class Program
{
    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Список користувачів
        var users = new List<User>
        {
            new User{ Id = 1, FullName="Іван Петренко", Email="ivan@gmail.com", Phone="380501112233"},
            new User{ Id = 2, FullName="Марія Коваль", Email="maria@yahoo.com", Phone="380631234567"},
            new User{ Id = 3, FullName="Олег Сидоренко", Email="oleg@ukr.net", Phone="380971234567"},
            new User{ Id = 4, FullName="Анна Іваненко", Email="anna@gmail.com", Phone="380991234567"}
        };

        Console.WriteLine("Всі користувачі:");
        users.ForEach(u => Console.WriteLine(u));

        Console.WriteLine("\nВведіть параметр пошуку (ім'я/email/телефон): ");
        string search = Console.ReadLine()?.Trim().ToLower();

        Stopwatch sw = Stopwatch.StartNew();

        var found = users
            .Where(u => u.FullName.ToLower().Contains(search)
                     || u.Email.ToLower().Contains(search)
                     || u.Phone.Contains(search))
            .Select(u => new { u.Id, u.FullName, u.Email }) // граємося з Select
            .ToList();

        sw.Stop();

        Console.WriteLine("\nРезультати пошуку:");
        if (found.Any())
        {
            foreach (var u in found)
                Console.WriteLine($"{u.Id}: {u.FullName}, {u.Email}");
        }
        else
        {
            Console.WriteLine("Нічого не знайдено.");
        }

        Console.WriteLine($"\nЧас пошуку: {sw.ElapsedMilliseconds} мс");
    }
}
