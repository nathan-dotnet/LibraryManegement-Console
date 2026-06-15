using LibraryManagement.Models;   

List<User> users =
[
  new Student { Name = "Nathaniel"},
  new Librarian { Name = "Admin" }
];

foreach (var user in users)
{
    Console.Write($"{user.Name}: ");
    user.DisplayRole();
}