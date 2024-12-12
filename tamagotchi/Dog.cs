namespace tamagotchi;

public class Dog : Pet
{
    public Dog(string name, int weight) : base(name, weight)
    {
    }

    public void Bark()
    {
        Console.WriteLine($"{Name} is barking!");
    }
}