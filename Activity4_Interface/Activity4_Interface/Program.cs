// Tommy Liang
// Intro to API
// Activity 4

interface Job
{
    void profession();
    void role();
    bool sustainable(int num);
}
public class Person : Job
{
    private string field = "Computer Science";
    private string position = "student";
    private int earnings = 0;

    public void profession()
    {
        if (field == "")
            Console.WriteLine("This person's \"field\" is currently empty.");
        else
            Console.WriteLine("This person works in the " + field + " field.");
    }

    public void role()
    {
        if (position == "")
            Console.WriteLine("This person doesn't have a role.");
        else
            Console.WriteLine("This person is a(n) " + position + ".");
    }

    public bool sustainable(int num)
    {
        if (earnings < num)
            return false;
        else
            return true;
    }

    public int Salary
    {
        get { return earnings; }
        set { earnings = value; }
    }

    public void OnPersonEmployed(object source, EventArgs args)
    {
        Console.WriteLine("Checking if person is employed");
        if((position == "" && field == "") || position.ToLower() == "student")
            Console.WriteLine("Person is unemployed!");
        else
            Console.WriteLine("Person is employed!");
    }
}

public class PersonEmployed
{
    public delegate void PersonEmployedEventHandler(object source, EventArgs args);

    public event PersonEmployedEventHandler? PersonEmploy;
    public void isEmployed(Person p1)
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
        
        me.Salary = 10;
        me.profession();
        me.role();
        Console.WriteLine("Salary(USD): " + me.Salary);
        if (me.sustainable(100))
            Console.WriteLine("Sustainable. Congrats!");
        else
            Console.WriteLine("Not Sustainable!");


        status.isEmployed(me);
    }
}