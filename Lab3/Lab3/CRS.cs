namespace Lab3;

public class CRS : SparseMatrix
{
    public List<int> Values { get; set; }
    public List<int> RowsPointer { get; set; }
    public List<int> RowIndexes { get; set; }

    public CRS(int rows, int cols)
    {
        Rows = rows;
        Cols = cols;
    }

    public CRS() { }

    public void FromMatrix(int[,] matrix)
    {
        Rows = matrix.GetLength(0);
        Cols = matrix.GetLength(1);
        Values = new();
        RowsPointer = new() { 0 };
        RowIndexes = new();
        int NNZ = 0;

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                if (matrix[i, j] != 0)
                {
                    Values.Add(matrix[i, j]);
                    RowIndexes.Add(j);
                    NNZ++;
                }
            }

            RowsPointer.Add(NNZ);
        }
    }

    public override int GetByIJ(int row, int col) // доступ по индексу как у обычной матрицы
    {
        if (row > Rows || col > Cols || row < 0 || col < 0)
        {
            throw new ArgumentOutOfRangeException("Invalid arguments");
        }

        for (int i = RowsPointer[row]; i < RowsPointer[row + 1]; i++)
        {
            if (RowIndexes[i] == col)
            {
                return Values[i];
            }
        }

        return 0;
    }

    public static CRS Sum(CRS first, CRS second)
    {
        if (first.Rows != second.Rows || first.Cols != second.Cols)
        {
            throw new ArgumentException("Matrices must be the same dimension.");
        }

        int[,] matrix = new int[first.Rows, first.Cols];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i,j] = first.GetByIJ(i, j) + second.GetByIJ(i, j);
            }
        }

        CRS result = new CRS();
        result.FromMatrix(matrix);
        return result;
    }
}
