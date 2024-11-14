namespace ContagionControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter number of citizens:");
            int total = int.Parse(Console.ReadLine());

            int[] visitors = new int[total];

            Console.Write("_______Id"+" ");
            for (int i = 0; i < total; i++)
            {
                visitors[i] = i;
                Console.Write(i+" ");
            }
            Console.WriteLine();

            //洗牌
            Random rng = new Random();
            for (int i = 0;i < visitors.Length; i++)
            {
                int j = rng.Next(i, visitors.Length);
                int tmp = visitors[i];
                visitors[i] = visitors[j];
                visitors[j] = tmp;
            }

            Console.Write("contactee"+" ");
            for (int i = 0; i < total; i++)
            {
                Console.Write(visitors[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine("---------------");

            Console.WriteLine("enter id of infected citizen:");
            int infected = int.Parse(Console.ReadLine());

            //存受感染的人
            int[] infectedCitizens = new int[total];
            bool[] visited = new bool[total];
            int index = 0;

            int current = infected;
            
            while (!visited[current])
            {
                infectedCitizens[index++] = current; // 將市民 ID 存入感染鏈
                visited[current] = true;          // 標記為已訪問

                // 防止無效的接觸索引
                if (current < 0 || current >= total)
                {
                    Console.WriteLine("Invalid contact detected. Aborting...");
                    break;
                }

                current = visitors[current];      // 追蹤下一位接觸者
            }

            Console.WriteLine("These citizen are to be isolated in next 14 days:");
            for (int i = 0; i < infectedCitizens.Length; i++)
            {
                Console.Write(infectedCitizens[i] + " ");
            }
        }
    }
}
