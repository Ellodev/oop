using System.Linq.Expressions;

namespace tamagotchi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool falseInput = true;
            Pet currentPet = null;
            
            while (falseInput)
            {
                Console.WriteLine("Welcome to your Tamagotchi! Please choose one of the following pets (cat has a special play mode):");
                Console.WriteLine("1. Dog");
                Console.WriteLine("2. Cat");
                Console.WriteLine("3. Snake");
                Console.WriteLine("4. Bird");
                Console.WriteLine("5. Frog");
                Console.WriteLine("6. T-rex");
                Console.Write("Enter your choice (1-6): ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Dog dog = new Dog(getName());
                        falseInput = false;
                        currentPet = dog;
                        break;
                    case "2":
                        Cat cat = new Cat(getName());
                        falseInput = false;
                        currentPet = cat;
                        break;
                    case "3":
                        Snake snake = new Snake(getName());
                        falseInput = false;
                        currentPet = snake;
                        break;
                    case "4":
                        Bird bird = new Bird(getName());
                        falseInput = false;
                        currentPet = bird;
                        break;
                    case "5":
                        Frog frog = new Frog(getName());
                        falseInput = false;
                        currentPet = frog;
                        break;
                    case "6":
                        Trex trex = new Trex(getName());
                        falseInput = false;
                        currentPet = trex;
                        break;
                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }
                
                Console.Clear();
                CancellationTokenSource cts = new CancellationTokenSource();
                Task backgroundTask = TimePassing(async () =>
                {
                    currentPet.TimePass();
                }, TimeSpan.FromMinutes(5), cts.Token);
                
                string currentMessage = "";
                
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine(currentMessage);
                    currentPet.PrintInfo();
                    Console.WriteLine("\nChoose an option:");
                    Console.WriteLine("1. Feed");
                    Console.WriteLine("2. Play");
                    Console.WriteLine("3. Sleep");
                    Console.WriteLine("4. Exit");
                    Console.Write("Enter your choice: ");
                    char choice2 = Console.ReadKey().KeyChar;
                    switch (choice2)
                    {
                        case '1':
                            currentMessage = currentPet.Feed();
                            break;
                        case '2':
                            currentMessage = currentPet.Play();
                            break;
                        case '3':
                            currentMessage =  currentPet.Sleep();
                            break;
                        case '4':
                            Console.WriteLine("Exiting...");
                            cts.Cancel();
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            break;
                    }
                }
            }
        } 

        static string getName()
        {
            Console.Write("Enter the name of your pet: ");
            string name = Console.ReadLine();
            return name;
        }
        
        static async Task TimePassing(Func<Task> task, TimeSpan interval, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    await task(); // Run the provided task
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Error in background task]: {ex.Message}");
                }
                await Task.Delay(interval, token); // Wait for the interval or until cancellation
            }
        }
        
    }

}    