namespace NumberGuessingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. 讓程式產生一個介於0-99的數字
            Random rng = new Random();
            int x = rng.Next(100);

            Console.WriteLine(x);

            //2. 讓使用者輸入數字
            int n = int.Parse(Console.ReadLine());

            //3. 比大比小
            int min = 0;
            int max = 99;
            while(n!=x)
            {
                if(!(n > min && n<max))
                {
                    Console.WriteLine("Out of range! Try again");
                    Console.WriteLine("({0},{1})? ", min, max);
                    n = int.Parse(Console.ReadLine());
                }

                if(n>x)
                {
                    max = n - 1;
                    Console.WriteLine("({0},{1})? ", min, n-1);
                }
                else
                {
                    min = n + 1;
                    Console.WriteLine("({0},{1})? ", n+1, max);
                }

                if(max == min)
                {
                    Console.WriteLine("GG.");
                }
                n = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("BINGO");
        }
    }
}
