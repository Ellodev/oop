namespace tamagotchi;

public class Pet
{
    public string Name { get; }
    public int Hunger { get; set; }
    public int Happiness { get; set; }
    public int Energy { get; set; }
    public int Age { get; }
    public int Weight { get; }
    public int Health { get; set;  }
    public bool IsAlive { get; set; }
    
    public Pet(string name, int weight) {
        this.Name = name;
        this.Hunger = 0;
        this.Happiness = 100;
        this.Energy = 100;
        this.Age = 0;
        this.Weight = weight;
        this.Health = 100;
        IsAlive = true;
    }

    public void Feed()
    {
        if (Hunger > 10)
        {
            this.Hunger = Hunger -10;
            this.Energy = Energy - 5;
            Console.WriteLine($"{Name} has been fed!");
        }
        else
        {
            Console.WriteLine($"{Name} is not hungry enough to need feeding.");
        }
    }
    
    public void Play()
    {
        if (Energy > 10)
        {
            this.Happiness = Happiness + 10;
            this.Energy = Energy - 10;
            this.Health = Health + 5;
            Console.WriteLine($"{Name} is playing and having fun!");
        }
        else
        {
            Console.WriteLine($"{Name} is too tired to play.");
        }
    }
    
    public void Sleep()
    {
        this.Energy = Energy + 10;
        this.Hunger = Hunger + 5;
        this.Health = Health + 5;
        Console.WriteLine($"{Name} is sleeping to regain energy.");
    }
    
    public void PrintInfo()
    {
        Console.WriteLine("Name: " + this.Name);
        Console.WriteLine("Hunger: " + this.Hunger);
        Console.WriteLine("Happiness: " + this.Happiness);
        Console.WriteLine("Energy: " + this.Energy);
        Console.WriteLine("Age: " + this.Age);
        Console.WriteLine("Weight: " + this.Weight);
        Console.WriteLine("Health: " + this.Health);
        Console.WriteLine("Is Alive: " + this.IsAlive);
    }

    public void TimePass()
    {
        this.Hunger += 5;
        this.Energy -= 5;
        this.Health -= 5;
        
        if (Hunger >= 100)
        {
            Health -= 15;
        }
        
        if (Energy <= 0)
        {
            Health -= 10;
        }
        
        if (Health <= 0)
        {
            IsAlive = false;
        }
    }
}