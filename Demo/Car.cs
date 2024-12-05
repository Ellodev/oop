namespace Demo;

internal class Car : Vehicle
{
    internal int horsepower {get; set;}
    internal int seats {get; }

    internal Car(string brand, string color, int yearOfConstruction, int horsepower, int seats)
    : base(brand, color, yearOfConstruction)
    {
        this.horsepower = horsepower;
        this.seats = seats;
    }

    internal override void Move()
    {
        Console.WriteLine("Car is moving");
    }

    internal override void PrintInfo()
    {
        Console.WriteLine($"Brand: {Brand}, Color: {Color}, Horsepower: {horsepower}, Seats: {seats}, Year of construction: {YearOfConstruction}");
    }

    internal void Honk()
    {
        Console.WriteLine("The car is honking");
    }
}