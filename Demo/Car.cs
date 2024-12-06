namespace Demo;

internal class Car : Vehicle, IMotorizedVehicle
{
    internal int horsepower {get; set;}
    internal int seats {get; }

    internal bool IsStartedEngine;

    internal Car(string brand, string color, int yearOfConstruction, int horsepower, int seats,
        VehicleCondition condition)
    : base(brand, color, yearOfConstruction, condition)
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
        Console.WriteLine($"Brand: {Brand}, Color: {Color}, Horsepower: {horsepower}, Seats: {seats}, Year of construction: {YearOfConstruction}, Zustand: {VehicleCondition}");
    }

    internal void Honk()
    {
        Console.WriteLine("The car is honking");
    }
    public void StartEngine()
    {
        if (!this.IsStartedEngine)
        {
            this.IsStartedEngine = true;
            Console.WriteLine("Motor started");
        }
        else
        {
            Console.WriteLine("Motor already started");
        }
    }
    public void StopEngine()
    {
        if (this.IsStartedEngine)
        {
            this.IsStartedEngine = false;
            Console.WriteLine("Motor stopped");
        }
        else
        {
            Console.WriteLine("Motor already stopped");
        }
    }
    
}