using System.Diagnostics.Contracts;
using System.Globalization;
using System.Runtime.InteropServices;
//Array Movie name declaration
Movie[] movies = new Movie[5]
{
    new Movie("Kabaddi 4: The Final Match", "2 hrs 11 mins", 450),
    new Movie("Avatar: The Way of Water", "3h 12m", 600),
    new Movie("Purna Bahadur Ko Sarangi", "2 hrs 25 mins", 200),
    new Movie("Jawan", "2h 49m", 500),
    new Movie("12 Gaun", "2 hrs 52 mins", 300)
};

// Customer info input 
Console.WriteLine("\n__________________________________________");
Console.WriteLine("          Welcome to the Booking App        ");
Console.WriteLine("\n__________________________________________");
Console.Write("Enter Your Name:");
string coustomerName=Console.ReadLine()??"";

Console.Write("Enter your Contact Number:");
string contact = Console.ReadLine()??"";

// Movie availablity and selection
Console.WriteLine("\n___Available Movies___");
for(int i =0 ;i <movies.Length;i++)
{
    Console.WriteLine($"{i + 1}. {movies[i].Name} | Duration: {movies[i].Duration} | Price: ${movies[i].Price}");
}

int choice = 0;
while (choice < 1 || choice > movies.Length)
{
    Console.Write($"\nSelect a movie (1-{movies.Length}): ");
    if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > movies.Length)
    {
        Console.WriteLine("Invalid choice. Please select a valid movie number.");
    }
}

Movie chosenMovie = movies[choice - 1];

DateTime showDate;
while (true)
{
    Console.Write("Enter Show Date (YYYY-MM-DD): ");
    string input = Console.ReadLine() ?? "";
    if (!DateTime.TryParseExact(input, "yyyy-MM-dd",
            CultureInfo.InvariantCulture, DateTimeStyles.None, out showDate))
    {
        Console.WriteLine("Invalid format. Use YYYY-MM-DD, e.g. 2026-11-05.");
        continue;
    }
    if (showDate.Date < DateTime.Today)
    {
        Console.WriteLine("The date can't be in the past.");
        continue;
    }
    break;
}
DateTime showTime;
while (true)
{
    Console.Write("Enter Show Time (e.g., 06:30 PM): ");
    string timeInput = Console.ReadLine() ?? "";
    if (!DateTime.TryParseExact(timeInput.Trim(), "h:mm tt",
            CultureInfo.InvariantCulture, DateTimeStyles.None, out showTime))
    {
        Console.WriteLine("Invalid format. Use hh:mm AM/PM, e.g. 06:30 PM.");
        continue;
    }
    break;
}
Customer customer = new Customer(
    coustomerName, contact, chosenMovie, 
    showDate.ToString("yyyy-MM-dd"),
    showTime.ToString("hh:mm tt", CultureInfo.InvariantCulture));
customer.PrintTicket();
class Movie
{
    public string Name;
    public string Duration;
    public double Price;

    public Movie(string name,string duration, double price)
    {
        Name=name;
        Duration = duration;
        Price = price;
    }
}
class Customer
{
    public string Name;
    public string Contact;
    public Movie SelectedMovie;
    public string ShowDate;
    public string ShowTime;
    public Customer(string name, string contact, Movie selectedMovie, string showDate, string showTime)
    {
        Name = name;
        Contact = contact;
        SelectedMovie = selectedMovie;
        ShowDate = showDate;
        ShowTime = showTime;
    }
    public void PrintTicket()
    {
        Console.WriteLine("\n____________________________________");
        Console.WriteLine("          Booking Confirmation        ");
        Console.WriteLine("____________________________________");
        Console.WriteLine($"Customer Name : {Name}");               
        Console.WriteLine($"Contact Number: {Contact}");            
        Console.WriteLine($"Movie Selected: {SelectedMovie.Name}");
        Console.WriteLine($"Movie Duration: {SelectedMovie.Duration}");
        Console.WriteLine($"Ticket Price  : Rs. {SelectedMovie.Price:F2}");
        Console.WriteLine($"Show Date     : {ShowDate}");
        Console.WriteLine($"Show Time     : {ShowTime}");
        Console.WriteLine("____________________________________");
        Console.WriteLine("          Thank You for Booking       ");
        Console.WriteLine("____________________________________");
    }
}