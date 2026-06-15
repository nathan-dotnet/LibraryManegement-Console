namespace LibraryManagement.Models;

public class Student : User
{
    public override void DisplayRole()
    {
        Console.WriteLine("Student.");
    }
}