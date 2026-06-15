namespace LibraryManagement.Models;

public abstract class User
{
    public string Name { get; set; } = "";
    public abstract void DisplayRole();

}