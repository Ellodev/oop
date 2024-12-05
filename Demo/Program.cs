namespace Demo;

class Program
{
    static void Main(string[] args)
    {
        Car car1 = new Car("BMW", "Schwarz", 2000, 200, 4);
        Motorcycle motorcycle1 = new Motorcycle("yamaha", "black", 2007, 500);
        Mountainbike mountainbike1 = new Mountainbike("Canyon", "brown", 2024, 7, 20);
        
        
        car1.PrintInfo();
        motorcycle1.PrintInfo();
        mountainbike1.PrintInfo();
        
        car1.Move();
        motorcycle1.Move();
        mountainbike1.Move();
        
        car1.Honk();
        motorcycle1.Honk();
    }
}