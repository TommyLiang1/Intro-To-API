// Tommy Liang
// Intro to API
// Activity 4

interface IJob
{
    string Name { get; set; }
    string Profession { get; set; }
    string Role { get; set; }
    int Salary { get; set; }
    void Sustainable(int num);
}
public class Person : IJob
{
    public string Name { get; set; } = String.Empty;
    public string Profession { get; set; } = String.Empty;
    public string Role { get; set; } = String.Empty; 
    public int Salary { get; set; }

    public void Sustainable(int num)
    {
        string result = "";
        if (Salary < num)
            result = "not sustainable!";
        else
            result = "sustainable!";
        Console.WriteLine("This current lifestyle as a(n) " + Role + " with an net income of " + (Salary-num) + " is " + result);
    }

    public void OnPersonEmployed(object source, EventArgs args)
    {
        Console.WriteLine("Checking if person is employed");
        var text = "Person";
        if (Name != null)
            text = Name;
        if (Role.ToLower() == "student")
            Console.WriteLine(text + " is a student!");
        else if (Profession == "" || Role == "")
            Console.WriteLine(text + " is unemployed!");
        else
            Console.WriteLine(text + " is employed!");
    }
}

public class PersonEmployed
{
    public delegate void PersonEmployedEventHandler(object source, EventArgs args);

    public event PersonEmployedEventHandler? PersonEmploy;
    public void IsEmployed(Person p1)
    {
        Console.WriteLine("Running Employed Checker Event...");
        Thread.Sleep(3000);

        OnPersonEmployed();
    }

    protected virtual void OnPersonEmployed()
    {
        if (PersonEmploy != null)
            PersonEmploy(this, EventArgs.Empty);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var me = new Person();
        var status = new PersonEmployed();
        status.PersonEmploy += me.OnPersonEmployed;
        
        me.Salary = 105;
        me.Name = "Tommy";
        me.Profession = "Computer Science";
        me.Role = "Student";

        Console.WriteLine("Salary(USD): " + me.Salary);

        me.Sustainable(100);
        status.IsEmployed(me);
    }
}