namespace RefactoringNumber_GuessingGame
{
    // 所有玩家共用的interface
    interface Strategy
    {
        int Next(int low, int high);
    }

    abstract class Player : Strategy
    {
        public string Name { get; private set; }

        public Player(string name)
        {
            Name = name;
        }

        // 具體玩家實做
        public abstract int Next(int low, int high);
    }

    // 普通玩家
    class HumanPlayer : Player
    {
        public HumanPlayer(string name) : base(name) { }

        public override int Next(int low, int high)
        {
            int guess;
            do
            {
                Console.WriteLine($"({low}, {high})?");
                if (int.TryParse(Console.ReadLine(), out guess) && guess >= low && guess <= high)
                {
                    return guess;
                }
                Console.WriteLine("Out of range. Try again?");
            } while (true);
        }
    }

    // Naive player
    class NaiveAI : Player
    {
        private Random random = new Random();

        public NaiveAI(string name) : base(name) { }

        public override int Next(int low, int high)
        {
            return random.Next(low, high + 1);
        }
    }

    // Binary Search AI
    class BinarySearchAI : Player
    {
        public BinarySearchAI(string name) : base(name) { }

        public override int Next(int low, int high)
        {
            return (low + high) / 2; // 返回中間值
        }
    }

    // Super AI
    //class SuperAI : Player
    //{
    //    private int secretNumber;

    //    public SuperAI(string name, int secretNumber) : base(name)
    //    {
    //        this.secretNumber = secretNumber;
    //    }

    //    public override int Next(int low, int high)
    //    {
    //        return secretNumber; // 即正確答案
    //    }
    //}

    // 遊戲類
    class Game
    {
        private int secretNumber;
        private int low = 0;
        private int high = 99;
        private Player player;
        public bool Win { get; private set; } = false;

        public Game(Player player)
        {
            this.player = player;
            Random random = new Random();
            secretNumber = random.Next(low, high + 1); // 隨機生成秘密數字
        }

        public void Run()
        {
            Console.WriteLine($"{player.Name} starts guessing...");
            while (low < high)
            {
                int guess = player.Next(low, high);
                if (guess == secretNumber)
                {
                    Console.WriteLine($"Bingo. Answer is {guess}");
                    Win = true;
                    return;
                }
                else if (guess < secretNumber)
                {
                    low = guess + 1; // 更新範圍
                }
                else
                {
                    high = guess - 1; // 更新範圍
                }
            }
            Console.WriteLine("Game over. No more numbers to guess.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose player type: 1. Human 2. NaiveAI 3. BinarySearchAI ");
            int choice = int.Parse(Console.ReadLine());
            Player player;

            switch (choice)
            {
                case 1:
                    player = new HumanPlayer("Human");
                    break;
                case 2:
                    player = new NaiveAI("Naive AI");
                    break;
                case 3:
                    player = new BinarySearchAI("Binary Search AI");
                    break;
                //case 4:
                //    Console.WriteLine("Enter secret number (for SuperAI):");
                //    int secret = int.Parse(Console.ReadLine());
                //    player = new SuperAI("Super AI", secret);
                //    break;
                default:
                    throw new ArgumentException("Invalid choice");
            }

            Game game = new Game(player);
            game.Run();
        }
    }
}
