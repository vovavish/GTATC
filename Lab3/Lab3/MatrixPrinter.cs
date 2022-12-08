namespace Lab3;

internal static class MatrixPrinter
{
    public static void Print(SparseMatrix matrix)
    {
        for (int i = 0; i < matrix.Rows; i++)
        {
            Console.Write("|");

            for (int j = 0; j < matrix.Cols; j++)
            {
                Console.Write(matrix.GetByIJ(i, j).ToString().PadLeft(5));
            }

            Console.WriteLine("|");
        }
    }
}
