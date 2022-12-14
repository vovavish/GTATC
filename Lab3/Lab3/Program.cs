namespace Lab3;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0) // как пользоваться программой
        {
            Console.WriteLine("How to sum matrix:");
            Console.WriteLine("pathToFirstMatrix pathToSecondMatrix");
            Console.WriteLine();
            Console.WriteLine("How to deserialize matrix:");
            Console.WriteLine("deserialize sparseType pathToSerialize");
            Console.WriteLine();
            Console.WriteLine("How to serialize sparse from matrix");
            Console.WriteLine("serialize sparseType pathToMatrix pathToSave");
        }
        else if (args.Length == 3 && args[0].ToLower() == "deserialize")
        {
            string sparseType = args[1].ToLower();

            SparseMatrix sparse = null;

            if (sparseType == "crs")
            {
                sparse = SparseSerializer.DeserializeCRS(args[2]);
            }
            else if (sparseType == "ccs")
            {
                sparse = SparseSerializer.DeserializeCCS(args[2]);
            }
            else
            {
                Console.WriteLine("Unknown type");
                Environment.Exit(-1);
            }

            TryPrintMatrix(sparse!);
        }
        else if (args.Length == 4 && args[0].ToLower() == "serialize")
        {
            string sparseType = args[1].ToLower();

            if (sparseType == "crs")
            {
                CRS temp = new CRS();
                temp.FromMatrix(SparseGenerator.MatrixFromFile(args[2]));
                File.WriteAllText(args[3], SparseSerializer.SerializeCRS(temp));
            }
            else if (sparseType == "ccs")
            {
                CCS temp = new CCS();
                temp.FromMatrix(SparseGenerator.MatrixFromFile(args[2]));
                File.WriteAllText(args[3], SparseSerializer.SerializeCCS(temp));
            }
            else
            {
                Console.WriteLine("Unknown type");
                Environment.Exit(-1);
            }
        }
        else if (args.Length == 2)
        {
            CRS first = new CRS();
            CRS second = new CRS();

            first.FromMatrix(SparseGenerator.MatrixFromFile(args[0]));
            second.FromMatrix(SparseGenerator.MatrixFromFile(args[1]));

            Console.WriteLine("First matrix:");
            TryPrintMatrix(first);

            Console.WriteLine("\nFirst matrix in CRS format:");
            PrintIfCanCRS(first, "firstMatrixCRS.txt");

            Console.WriteLine("\nSecond matrix:");
            TryPrintMatrix(second);

            Console.WriteLine("\nSecond matrix in CRS format:");
            PrintIfCanCRS(second, "secondMatrixCRS.txt");

            CCS result = CCS.FromCRS(CRS.Sum(first, second)); // преобразуем сумму CRS матриц в CCS

            Console.WriteLine("\nFirst + Second = result:");
            TryPrintMatrix(result); // выводим результат на экран

            Console.WriteLine("result matrix in CCS format:");
            PrintIfCanCCS(result, "resultMatrixCCS.txt");
        }
    }

    private static void PrintIfCanCRS(CRS crs, string pathToSaveIfBig)
    {
        string values = "Values [" + string.Join(" ", crs.Values) + "]";
        string rowsPointer = "RowsPointer [" + string.Join(" ", crs.RowsPointer) + "]";
        string rowIndexes = "RowIndexes [" + string.Join(" ", crs.RowIndexes) + "]";

        if (values.Length > 80 || rowsPointer.Length > 80 || rowIndexes.Length > 80)
        {
            Console.WriteLine("CRS too big. It was saved to file: " + pathToSaveIfBig);
            File.WriteAllText(pathToSaveIfBig, SparseSerializer.SerializeCRS(crs));
        }
        else
        {
            Console.WriteLine(values);
            Console.WriteLine(rowsPointer);
            Console.WriteLine(rowIndexes);
        }
    }

    private static void PrintIfCanCCS(CCS ccs, string pathToSaveIfBig)
    {
        string values = "Values [" + string.Join(" ", ccs.Values) + "]";
        string columnPointer = "ColumnPointer [" + string.Join(" ", ccs.ColumnPointer) + "]";
        string columnsStart = "ColumnsStart [" + string.Join(" ", ccs.ColumnsStart) + "]";

        if (values.Length > 80 || columnPointer.Length > 80 || columnsStart.Length > 80)
        {
            Console.WriteLine("CCS too big. It was saved to file: " + pathToSaveIfBig);
            File.WriteAllText(pathToSaveIfBig, SparseSerializer.SerializeCCS(ccs));
        }
        else
        {
            Console.WriteLine(values);
            Console.WriteLine(columnPointer);
            Console.WriteLine(columnsStart);
        }
    }

    private static void TryPrintMatrix(SparseMatrix matrix)
    {
        if (matrix.Cols <= 15 && matrix.Rows <= 15)
        {
            MatrixPrinter.Print(matrix);
        }
        else
        {
            Console.WriteLine("Matrix too large to be printed");
        }
    }
}