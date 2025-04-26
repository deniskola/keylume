using System;
using Keylume.Services;
using Keylume.Utils;

class Program
{
    static void Main(string[] args)
    {
        var encryptionService = new EncryptionService("masterKey", "masterIV");
        var passwordManager = new PasswordManager(encryptionService, "Data/vault.json");

        while (true)
        {
            Console.WriteLine("\nKeylume - Secure Password Manager");
            Console.WriteLine("1. Store a password");
            Console.WriteLine("2. Retrieve a password");
            Console.WriteLine("3. Delete a password");
            Console.WriteLine("4. Generate a strong password");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Identifier (App/Service/Device): ");
                    string identifier = Console.ReadLine();
                    Console.Write("Username (Optional): ");
                    string username = Console.ReadLine();
                    Console.Write("Password (Leave empty to generate one): ");
                    string password = Console.ReadLine();
                    if (string.IsNullOrEmpty(password))
                    {
                        password = PasswordGenerator.Generate();
                        Console.WriteLine($"Generated Password: {password}");
                    }
                    Console.Write("Notes (Optional): ");
                    string notes = Console.ReadLine();
                    passwordManager.StorePassword(identifier, username, password, notes);
                    Console.WriteLine("Password saved!");
                    break;

                case "2":
                    Console.Write("Enter Identifier: ");
                    identifier = Console.ReadLine();
                    Console.WriteLine($"Password: {passwordManager.RetrievePassword(identifier)}");
                    break;

                case "3":
                    Console.Write("Enter Identifier to delete: ");
                    identifier = Console.ReadLine();
                    passwordManager.DeletePassword(identifier);
                    Console.WriteLine("Password deleted!");
                    break;

                case "4":
                    Console.WriteLine($"Generated Password: {PasswordGenerator.Generate()}");
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}
