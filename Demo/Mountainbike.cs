namespace Demo
{
    internal class Mountainbike : Vehicle
    {
        internal int gears { get; }
        internal int wheelDiameter { get; }

        internal Mountainbike(string brand, string color, int yearOfConstruction, int gears, int wheelDiameter)
        : base(brand, color, yearOfConstruction)
        {
            this.gears = gears;
            this.wheelDiameter = wheelDiameter;
        }

        internal override void PrintInfo()
        {
            Console.WriteLine($"Brand: {Brand}, Color: {Color}, year of construction: {YearOfConstruction}, gears: {gears}, Wheel diameter: {wheelDiameter}");
        }

        internal override void Move()
        {
            Console.WriteLine("Mountainbike moving.");
        }
    }
}