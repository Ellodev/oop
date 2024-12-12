namespace tamagotchi;

public class Pet
{
    public string Name { get; }
    public int Hunger { get; set; }
    public int Happiness { get; set; }
    public int Energy { get; set; }
    public int Age { get; set; }
    public int Weight { get; }
    public int Health { get; set;  }
    public bool IsAlive { get; set; }
    
    public Pet(string name, int weight) {
        this.Name = name;
        this.Hunger = 40;
        this.Happiness = 30;
        this.Energy = 30;
        this.Age = 1;
        this.Weight = weight;
        this.Health = 100;
        IsAlive = true;
    }

    public string Feed()
    {
        if (Hunger > 60)
        {
            Hunger = 100;
            return $"{Name} has been fed!";
        }
        else
        {
            return $"{Name} is not hungry! `(*>﹏<*)′";
        }
    }
    
    public virtual string Play()
    {
        if (Energy > 10)
        {
            this.Happiness = Happiness + 10;
            this.Energy = Energy - 10;
            this.Health = Health + 5;
            return $"{Name} is playing and having fun! (❁´◡`❁)";
        }
        else
        {
            return $"{Name} is too tired to play. (´。＿。｀)";
        }
    }
    
    public string Sleep()
    {
        if (Energy < 20)
        {
            this.Energy = 100;
            updateHunger(5);
            updateHealth(5);
            Console.Clear();
            Console.WriteLine($"{Name} is sleeping!");
            Thread.Sleep(3000);
            return $"{Name} has slept (✿◠‿◠)";
        }
        else
        {
            return $"{Name} isnt tired. (⊙_⊙;)";
        }
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
        updateHealth(5);
        updateHunger(5);
        updateHealth(-5);
        Age++;
    }

    public void updateHealth(int amount)
    {
        this.Health += amount;
        if (this.Health > 100)
        {
            this.Health = 100;
        }
        if (Health <= 0)
        {
            IsAlive = false;
        }
    }

    public void updateHunger(int amount)
    {
        this.Hunger += amount;
        if (this.Hunger >= 100)
        {
            updateHealth(-5);
            this.Hunger = 100;
        }
    }

    public void updateEnergy(int amount)
    {
        this.Energy += amount;
        if (this.Energy > 100)
        {
            this.Energy = 100;
        }
    }
}