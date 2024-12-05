namespace Demo;

public abstract class Vehicle
{
    internal string Brand { get; }
    internal string Color { get; set; }
    internal int YearOfConstruction { get; }

    internal Vehicle(string brand, string color, int yearOfConstruction)
    {
        Brand = brand;
        Color = color;
        YearOfConstruction = yearOfConstruction;
    }

    internal abstract void Move();

    internal virtual void PrintInfo()
    {
        Console.WriteLine($"Brand: {Brand}, Color: {Color}, Year of Construction: {YearOfConstruction}");
    }

}