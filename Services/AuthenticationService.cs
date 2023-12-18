using System.Security.Principal;
using Nutrition.Entities;
using Nutrition.Helpers;

namespace Nutrition.Services;

public class AuthenticationService : IAuthenticationService
{
    public void Invoke()
    {
        // Authenticate using Windows Identity
        var windowsIdentity = WindowsIdentity.GetCurrent();
        var windowsPrincipal = new WindowsPrincipal(windowsIdentity);

        // Check if the Windows user is authenticated
        if (windowsPrincipal.Identity.IsAuthenticated)
        {
            // Use the authenticated user's username
            var username = ExtractUserName(windowsPrincipal.Identity);

            ConsoleHelper.WriteLineWithColor($"** Welcome to the Console App ** ", ConsoleColor.White);

            // Validate the user against a list of users (this could be replaced with a database query)
            var users = GetUsers();
            var user = users.FirstOrDefault(u => u.Username == username);

            if (user != null)
            {
                ConsoleHelper.WriteLineWithColor("Login successful. Welcome, " + user.Username + "!", ConsoleColor.DarkGreen);
            }
            else
            {
                ConsoleHelper.WriteLineWithColor($"User {username} authenticated but not authorized. Please login.", ConsoleColor.DarkRed);
                UserLogin();
            }
        }
        else
        {
            ConsoleHelper.WriteLineWithColor("Unable to authenticate.  Please login.", ConsoleColor.DarkYellow);
            UserLogin();
        }
    }

    private void UserLogin()
    {
        Console.Write("Enter your username: ");
        string username = Console.ReadLine();

        var user = GetUsers().FirstOrDefault(x => x.Username == username);

        if (user != null)
        {
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            if (user.Password != password)
            {
                ConsoleHelper.WriteLineWithColor($"Invalid password. Access denied.", ConsoleColor.DarkRed);
                Environment.Exit(1);
            }
        }
        else
        {
            ConsoleHelper.WriteLineWithColor($"User {username} not found. Access denied.", ConsoleColor.DarkRed);
            Environment.Exit(1);
        }

        ConsoleHelper.WriteLineWithColor("Login successful. Welcome, " + user.Username + "!", ConsoleColor.DarkGreen);

    }

    private string ExtractUserName(IIdentity windowsIdentity)
    {
        if (windowsIdentity != null)
        {
            var nameParts = windowsIdentity.Name.Split('\\');

            // The user name should be in the second part of the array.
            if (nameParts.Length == 2)
            {
                var userName = nameParts[1];
                return userName;
            }

            Console.WriteLine("Unable to extract user name.");
        }
        else
        {
            Console.WriteLine("Windows identity is not available.");
        }

        return string.Empty;
    }

    // Dummy method to get a list of users (replace with your data access logic)
    private List<User> GetUsers()
    {
        return new List<User>
        {
            new()
                {Username = "user1", Password = "password1"},
            new()
                {Username = "user2", Password = "password2"},
            new()
                {Username = "mcart", Password = "password3"}
            // Add more users as needed
        };
    }
}
