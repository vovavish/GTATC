namespace Lab3;

public class CCS : SparseMatrix
{
    public List<int> Values { get; set; }
    public List<int> ColumnPointer { get; set; }
    public List<int> ColumnsStart { get; set; }

    public CCS(int rows, int cols)
    {
        Rows = rows;
        Cols = cols;
    }

    public CCS() { }

    public void FromMatrix(int[,] matrix)
    {
        Rows = matrix.GetLength(0);
        Cols = matrix.GetLength(1);
        Values = new();
        ColumnPointer = new() { 0 };
        ColumnsStart = new();

        int nNonzero = 0;

        for (int i = 0; i < Cols; i++)
        {
            for (int j = 0; j < Rows; j++)
            {
                if (matrix[j, i] != 0)
                {
                    Values.Add(matrix[j, i]);
                    ColumnsStart.Add(j);
                    nNonzero++;
                }
            }

            ColumnPointer.Add(nNonzero);
        }
    }

    public override int GetByIJ(int row, int col) // доступ по индексу как у обычной матрицы
    {
        if (row > Rows || row < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(row));
        }

        if (col > Cols || col < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(col));
        }

        for (int i = ColumnPointer[col]; i < ColumnPointer[col + 1]; i++)
        {
            if (ColumnsStart[i] == row)
            {
                return Values[i];
            }
        }

        return 0;
    }

    public static CCS FromCRS(CRS crs) // преобразование из CRS В ССS
    {
        int nnz = crs.Values.Count;

        int[] Bx = new int[nnz];
        int[] Bi = new int[nnz];
        int[] Bp = new int[crs.Rows];

        int[] cnt = new int[crs.Cols];
        for (int k = 0; k < nnz; k++)
        {
            int col = crs.RowIndexes[k];
            cnt[col] += 1;
        }

        for (int i = 1; i < crs.Cols; i++)
        {
            Bp[i] = Bp[i - 1] + cnt[i - 1];
        }

        for (int i = 0; i < crs.Rows; i++)
        {
            for (int j = crs.RowsPointer[i]; j < crs.RowsPointer[i + 1]; j++)
            {
                int col = crs.RowIndexes[j];
                int dest = Bp[col];

                Bi[dest] = i;
                Bx[dest] = crs.Values[j];
                Bp[col] += 1;
            }
        }

        int[] temp = new int[Bp.Length + 1];
        
        for (int i = 1; i < temp.Length; i++)
        {
            temp[i] = Bp[i - 1];
        }

        Bp = temp;

        return new CCS()
        {
            Rows = crs.Rows,
            Cols = crs.Cols,
            Values = Bx.ToList(),
            ColumnPointer = Bp.ToList(),
            ColumnsStart = Bi.ToList()
        };
    }
}
