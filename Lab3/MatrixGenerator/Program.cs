using System.Text;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 6)
        {
            int L = int.Parse(args[1]);
            int rows = int.Parse(args[2]);
            int cols = int.Parse(args[3]);
            int nNoneZero = int.Parse(args[4]);

            string matrix = string.Empty;
            if (args[0].ToLower() == "matrix")
            {
                matrix = GenerateMatrix(rows, cols, nNoneZero);
            }
            else if (args[0].ToLower() == "bandmatrix")
            {
                try
                {
                    matrix = GenerateBandMatrix(L, rows, cols, nNoneZero);
                }
                catch
                {
                    Console.WriteLine("L is too low for this nNoneZero");
                    Environment.Exit(-1);
                }
            }
            else
            {
                Console.WriteLine("Unknown Type");
                Environment.Exit(-1);
            }

            File.WriteAllText(args[5], matrix);
        }
        else
        {
            Console.WriteLine("Try again.");
        }
    }

    public static string GenerateMatrix(int rows, int cols, int nNoneZero)
    {
        StringBuilder result = new StringBuilder();
        result.Append($"#rows:{rows}#cols:{cols}\r\n");

        int[,] matrix = new int[rows, cols];

        Random rand = new Random(Environment.TickCount);

        for (int i = 0; i < nNoneZero; i++)
        {
            int row = rand.Next(rows);
            int col = rand.Next(cols);

            if (matrix[row, col] != 0)
            {
                i--;
            }
            else
            {
                int randNumber = 0;

                while (randNumber == 0)
                {
                    randNumber = rand.Next(-499, 500);
                }

                matrix[row, col] = randNumber;
            }
        }

        for (int i = 0; i < rows; i++)
        {
            result.Append(matrix[i, 0]);

            for (int j = 1; j < cols; j++)
            {
                result.Append(" " + matrix[i, j]);
            }

            result.Append("\r\n");
        }

        return result.ToString();
    }

    static string GenerateBandMatrix(int L, int rows, int cols, int nNoneZero)
    {
        if (nNoneZero > rows * (2 * L + 1) - L * L - L)
        {
            throw new Exception("nNoneZero is too big for this L and rows");
        }

        StringBuilder result = new StringBuilder();
        result.Append($"#rows:{rows}#cols:{cols}\r\n");

        int[,] matrix = new int[rows, cols];

        Random rand = new Random(Environment.TickCount);

        int generateNNZ = 0;

        while (generateNNZ < nNoneZero)
        {
            int row = rand.Next(rows);

            int colMin = row - L;
            int colMax = row + L + 1;

            if (colMin < 0)
            {
                colMin = 0;
            }

            if (colMax > cols)
            {
                colMax = cols;
            }

            int col = rand.Next(colMin, colMax);

            int diff = Math.Abs(row - col);

            if (diff <= L)
            {
                if (matrix[row, col] == 0)
                {
                    matrix[row, col] = rand.Next(-499, 500);
                    generateNNZ++;
                }
            }
        }

        for (int i = 0; i < rows; i++)
        {
            result.Append(matrix[i, 0]);

            for (int j = 1; j < cols; j++)
            {
                result.Append(" " + matrix[i, j]);
            }

            result.Append("\r\n");
        }

        return result.ToString();
    }
}