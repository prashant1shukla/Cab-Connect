using System;

class Person
{
    private string name;
    private int age;

    // Parameterized constructor that accepts values for name and age
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    // Default constructor that sets name to unknown and age to 0
    public Person()
    {
        name = "Unknown";
        age = 0;
    }

    // Destructor which also displays message
    ~Person()
    {
        Console.WriteLine("The object is being destroyed.");
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {name}, Age: {age}");
    }
}

class Program
{
    static void Main()
    {
        Person person1 = new Person("Prashant", 22);
        person1.DisplayInfo();

        Person person2 = new Person();
        person2.DisplayInfo(); 
    }
}
