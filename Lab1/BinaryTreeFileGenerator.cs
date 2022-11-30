namespace Lab1;

internal static class BinaryTreeFileGenerator
{
    public static void GenFile(string path, int nNodes, bool onlyOdd)
    {
        Random rand = new Random(Environment.TickCount);

        int[] arr = new int[nNodes];

        for (int i = 0; i < nNodes; i++)
        {
            int rnumb = rand.Next(-1000, 999);

            if (onlyOdd && rnumb % 2 == 0) // если установлен флаг, то генерируем только нечётные числа
            {
                rnumb++;
            }

            arr[i] = rnumb;
        }

        File.WriteAllText(path, string.Join(" ", arr));
    }
}
