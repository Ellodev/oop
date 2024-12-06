namespace Demo;

public abstract class Vehicle
{
    internal string Brand { get; }
    internal string Color { get; set; }
    internal int YearOfConstruction { get; }
    internal VehicleCondition VehicleCondition { get; }

    internal Vehicle(string brand, string color, int yearOfConstruction, VehicleCondition vehicleCondition)
    {
        Brand = brand;
        Color = color;
        YearOfConstruction = yearOfConstruction;
        this.VehicleCondition = new VehicleCondition();
    }

    internal abstract void Move();

    internal virtual void PrintInfo()
    {
        Console.WriteLine($"Brand: {Brand}, Color: {Color}, Year of Construction: {YearOfConstruction}, Zustand: {VehicleCondition}");
    }

}