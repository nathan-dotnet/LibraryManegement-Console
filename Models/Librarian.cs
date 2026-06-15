namespace LibraryManagement.Models;

public class Librarian : User
{
    public override void DisplayRole()
    {
        Console.WriteLine("Librarian.");
    }
}