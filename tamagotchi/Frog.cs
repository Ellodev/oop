namespace tamagotchi;

public class Frog : Pet
{
    public Frog(string name) : base(name, 1)
    {
    }

    public override string Play()
    {
        Random rnd = new Random();
            int xDot = rnd.Next(0, 11); 
            int yDot = rnd.Next(0, 11); 
            int catX = 5; 
            int catY = 5; 
            bool gameRunning = true;

            while (gameRunning)
            {
                Console.Clear();
                Console.WriteLine("***********************************************************");
                Console.WriteLine("                   Catch the fly                     ");
                Console.WriteLine("************************************************************");
                Console.WriteLine($"Catch the 🪰 using the arrow keys. Successfully catching it increases happiness.");
                
                for (int i = 0; i < 11; i++)
                {
                    for (int j = 0; j < 11; j++)
                    {
                        if (xDot == j && yDot == i)
                        {
                            Console.Write("🪰");
                        }
                        else if (catX == j && catY == i)
                        {
                            Console.Write("🐸");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                }
                
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(intercept: true).Key;

                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            if (catY > 0) catY--;
                            break;
                        case ConsoleKey.DownArrow:
                            if (catY < 10) catY++;
                            break;
                        case ConsoleKey.LeftArrow:
                            if (catX > 0) catX--;
                            break;
                        case ConsoleKey.RightArrow:
                            if (catX < 10) catX++;
                            break;
                    }
                }
                
                if (catX == xDot && catY == yDot)
                {
                    Console.Clear();
                    Console.WriteLine($"Congratulations! {Name} caught the dot!");
                    Happiness += 10; 
                    gameRunning = false; 
                }
                
                System.Threading.Thread.Sleep(100);
            }
            
            Console.WriteLine($"Final Happiness: {Happiness}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return "Sucessfully played. ";
    }
}