namespace Lab3;

public abstract class SparseMatrix
{
    public int Rows { get; set; }
    public int Cols { get; set; }

    public abstract int GetByIJ(int row, int col);
}
