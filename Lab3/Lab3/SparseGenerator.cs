using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab3;

public static class SparseGenerator
{
    public static int[,] MatrixFromFile(string path)
    {
        string data = File.ReadAllText(path);

        int rows = int.Parse(Regex.Match(data, @"#rows:(\d*)").Groups[1].Value);
        int cols = int.Parse(Regex.Match(data, @"#cols:(\d*)").Groups[1].Value);

        data = Regex.Replace(data, @"#rows:\d*#cols:\d*\r?\n", "");
        data = Regex.Replace(data, @"\r?\n", " ");
        data = Regex.Replace(data, @" \r?\n", "\r\n");

        data = Regex.Replace(data, @" $", "");

        int[] arr = data.Split(' ').Select(n => int.Parse(n)).ToArray();

        int[,] matrix = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = arr[j + i * cols];
            }
        }

        return matrix;
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
}
