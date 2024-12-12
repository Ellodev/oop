namespace tamagotchi;

public class Dog : Pet
{
    public Dog(string name) : base(name, 10)
    {
    }

    public void Bark()
    {
        Console.WriteLine($"{Name} is barking!");
    }
    
}