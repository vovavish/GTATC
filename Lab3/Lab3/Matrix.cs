using System.Windows.Markup;

namespace Lab3;

public class Matrix
{
    public int Rows { get; set; }
    public int Cols { get; set; }

    public int[,] Values { get; set; }
    
    public static Matrix FromFile(string path)
    {
        int[,] values = SparseGenerator.MatrixFromFile(path);

        return new Matrix()
        { 
            Values = values,
            Rows = values.GetLength(0),
            Cols = values.GetLength(1)
        };
    }

    public static Matrix Sum(Matrix first, Matrix Second)
    {
        if (first.Cols != Second.Cols || first.Rows != Second.Rows)
        {
            throw new Exception("Matrices must be same!");
        }

        int[,] values = new int[first.Rows, first.Cols];

        for (int i = 0; i < values.GetLength(0); i++)
        {
            for (int j = 0; j < values.GetLength(1); j++)
            {
                values[i, j] = first.Values[i, j] + Second.Values[i, j];
            }
        }

        return new Matrix()
        {
            Values = values,
            Rows = values.GetLength(0),
            Cols = values.GetLength(1)
        };
    }
}
