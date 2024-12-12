namespace tamagotchi
{
    class Program
    {
        static void Main(string[] args)
        {
            Pet Dog = new Pet("Dog", 3);
            Console.WriteLine("Welcome to your Tamagotchi!");
            Dog.PrintInfo();
            Console.WriteLine("\n");

            while (Dog.IsAlive)
            {
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1. Feed");
                Console.WriteLine("2. Play");
                Console.WriteLine("3. Sleep");
                Console.WriteLine("4. Check Status");
                Console.WriteLine("5. Exit");
                Console.Write("Enter the number of your choice: ");
                string choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        Dog.Feed();
                        break;
                    case "2":
                        Dog.Play();
                        break;
                    case "3":
                        Dog.Sleep();
                        break;
                    case "4":
                        Dog.PrintInfo();
                        break;
                    case "5":
                        Console.WriteLine("Exiting the game.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Dog.TimePass();
                Console.Write("\n");
            }

            Console.WriteLine("Your pet has passed away. yikes ＼（〇_ｏ）／");
        }
    }

}    