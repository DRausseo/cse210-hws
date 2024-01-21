using System;

class Program
{
    static void Main()
    {
        // Solicitar el primer nombre
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        // Solicitar el apellido
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // Mostrar el resultado
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}
