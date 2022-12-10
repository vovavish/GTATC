namespace Lab3;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0) // как пользоваться программой
        {
            Console.WriteLine("How to sum matrix:");
            Console.WriteLine("pathToFirstMatrix pathToSecondMatrix");
        }
        if (args.Length == 2)
        {
            CRS first = SparseGenerator.CRSFromFile(args[0]); // считываем матрицы из переданных файлов.
            CRS second = SparseGenerator.CRSFromFile(args[1]);

            Console.WriteLine("First matrix:");
            MatrixPrinter.Print(first);
            Console.WriteLine("\nFirst matrix in CRS format:");

            Console.WriteLine("Values [" + string.Join(" ", first.Values) + "]"); // CRS формат первой матрицы
            Console.WriteLine("RowsPointer [" + string.Join(" ", first.RowsPointer) + "]");
            Console.WriteLine("RowIndexes [" + string.Join(" ", first.RowIndexes) + "]");

            Console.WriteLine("\nSecond matrix:");
            MatrixPrinter.Print(second);
            Console.WriteLine("\nSecond matrix in CRS format:");

            Console.WriteLine("Values [" + string.Join(" ", second.Values) + "]"); // CRS формат второй матрицы
            Console.WriteLine("RowsPointer [" + string.Join(" ", second.RowsPointer) + "]");
            Console.WriteLine("RowIndexes [" + string.Join(" ", second.RowIndexes) + "]");

            CCS result = CCS.FromCRS(CRS.Sum(first, second)); // преобразуем сумму CRS матриц в CCS

            Console.WriteLine("\nFirst + Second = result:");

            MatrixPrinter.Print(result); // выводим результат на экран

            Console.WriteLine("result matrix in CCS format:");
            Console.WriteLine("Values [" + string.Join(" ", result.Values) + "]");
            Console.WriteLine("ColumnsStart [" + string.Join(" ", result.ColumnsStart) + "]");
            Console.WriteLine("ColumnIndexes [" + string.Join(" ", result.ColumnIndexes) + "]");
        }
    }
}