namespace Lab3;
class Program
{
    static void Main(string[] args)
    {
        int[,] M1 = {
            { 1, 0, 0, 0, 4, 9 },
            { 0, 2, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0 },
            { 5, 0, 0, 0, 7, 0 },
            { 0, 0, 3, 0, 0, 0 },
            { 7, 0, 0, 0, 5, 6 },
        };

        File.WriteAllText("test", SparseGenerator.GenerateMatrix(1, 1, 1));
        //CRS crs = SparseGenerator.CRSFromFile("test2.txt");
        //CRS crs = new CRS();
        //crs.FromMatrix(M1);
        //MatrixPrinter.Print(crs);
        //Console.WriteLine("Value [" + string.Join(" ", crs.Values) + "]");
        //Console.WriteLine("Rows [" + string.Join(" ", crs.RowsPointer) + "]");
        //Console.WriteLine("ColumnIndexes [" + string.Join(" ", crs.ColumnIndices) + "]");

        //CCS ccs = SumCRSToCCS(crs, crs);

        //Console.WriteLine();
        //Console.WriteLine("SUM OF TWO CRS MATRIX IN CCS");
        //Console.WriteLine();

        //MatrixPrinter.Print(ccs);

        //Console.WriteLine("Value [" + string.Join(" ", ccs.Values) + "]");
        //Console.WriteLine("Rows [" + string.Join(" ", ccs.RowsStarts) + "]");
        //Console.WriteLine("ColumnIndexes [" + string.Join(" ", ccs.ColumnIndexes) + "]");

        static CCS SumCRSToCCS(CRS first, CRS second) => CCS.FromCRS(CRS.Sum(first, second));
    }
}