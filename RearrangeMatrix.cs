namespace RearrangeMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of rows:");
            int rows = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the number of columns:");
            int cols = int.Parse(Console.ReadLine());

            // 初始化矩陣
            int[,] matrix = new int[rows, cols];

            // 生成隨機數並填充矩陣
            FillMatrixWithRandomValues(matrix, rows, cols);

            // 打印初始矩陣
            Console.WriteLine("\nMatrix after filling with random values:");
            PrintMatrix(matrix, rows, cols);

            // 按第一列排序矩陣
            SortMatrixByFirstColumn(matrix, rows, cols);

            // 打印排序後的矩陣
            Console.WriteLine("\nMatrix after performing row exchanges based on the first column:");
            PrintMatrix(matrix, rows, cols);
        }

        // 填充矩陣隨機值
        static void FillMatrixWithRandomValues(int[,] matrix, int rows, int cols)
        {
            int totalElements = rows * cols;
            int[] numbers = new int[totalElements];

            // 初始化數字 0 到 rows * cols - 1
            for (int i = 0; i < totalElements; i++)
            {
                numbers[i] = i;
            }

            // 隨機打亂數字
            Random rng = new Random();
            for (int i = totalElements - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                int temp = numbers[i];
                numbers[i] = numbers[j];
                numbers[j] = temp;
            }

            // 將隨機數填入矩陣
            int index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = numbers[index++];
                }
            }
        }

        // 打印矩陣
        static void PrintMatrix(int[,] matrix, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{matrix[i, j],4}"); // 格式化輸出對齊
                }
                Console.WriteLine();
            }
        }

        // 根據第一列的數值排序矩陣
        static void SortMatrixByFirstColumn(int[,] matrix, int rows, int cols)
        {
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = i + 1; j < rows; j++)
                {
                    // 如果第一列的值需要交換
                    if (matrix[i, 0] > matrix[j, 0])
                    {
                        SwapRows(matrix, i, j, cols);
                    }
                }
            }
        }

        // 交換兩行數據
        static void SwapRows(int[,] matrix, int row1, int row2, int cols)
        {
            for (int i = 0; i < cols; i++)
            {
                int temp = matrix[row1, i];
                matrix[row1, i] = matrix[row2, i];
                matrix[row2, i] = temp;
            }
        }
    }
}
