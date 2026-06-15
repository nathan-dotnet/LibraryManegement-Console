namespace LibraryManagement.Models;

public class Student : User
{
    public int BorrowLimit { get; set; } = 3;
    public override void DisplayRole()
    {
        Console.WriteLine("Student.");
    }
}