namespace Demo;

internal class Motorcycle : Vehicle
{
    internal int weight { get; }

    internal Motorcycle(string brand, string color, int yearOfConstruction, int weight)
    : base(brand, color, yearOfConstruction)
    {
        this.weight = weight;
    }

    internal void Honk()
    {
        Console.WriteLine("The motorcycle is honking");
    }

    internal override void PrintInfo()
    {
        Console.WriteLine($"Brand: {Brand}, Color: {Color}, yearOfConstruction: {YearOfConstruction}, Weight: {weight}");
    }

    internal override void Move()
    {
        Console.WriteLine("The motorcycle is moving");
    }
}