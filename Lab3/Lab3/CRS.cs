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

    public static CRS Sum(CRS m1, CRS m2)
    {
        if (m1.Rows != m2.Rows || m1.Cols != m2.Cols)
        {
            throw new ArgumentException("Matrices must be same!");
        }

        CRS ans = new CRS()
        {
            Cols = m1.Cols,
            Rows = m1.Rows,
            RowIndexes = new List<int>(),
            RowsPointer = new List<int>(),
            Values = new List<int>()
        };

        int sum_length = 0;

        int cols1_done = 0;
        int cols2_done = 0;
        for (int i = 0; i < m1.RowsPointer.Count - 1; i++)
        {
            ans.RowsPointer.Add(ans.RowIndexes.Count);
            //два массива для каждой строки матрицы
            List<int> mas1 = new List<int>();
            List<int> mas2 = new List<int>();
            for (int j = m1.RowsPointer[i]; j < m1.RowsPointer[i + 1]; j++)
            {
                mas1.Add(m1.RowIndexes[j]);
            }
            for (int j = m2.RowsPointer[i]; j < m2.RowsPointer[i + 1]; j++)
            {
                mas2.Add(m2.RowIndexes[j]);
            }

            //выбираем длинный массив и записываем его в ans
            //mas1 - должен быть длиннее
            bool swap = false;
            if (mas2.Count > mas1.Count)
            {
                (mas2, mas1) = (mas1, mas2);
                swap = true;
            }

            //записываем длинный массив в ответ
            for (int j = 0; j < mas1.Count; j++)
            {
                ans.RowIndexes.Add(mas1[j]);
                if (!swap)
                {
                    ans.Values.Add(m1.Values[cols1_done + j]);
                }
                else
                {
                    ans.Values.Add(m2.Values[cols2_done + j]);
                }
            }
            //проводилось ли в строке только сложение
            bool onlySum = true;
            //добавляем в первый массив элементы второго массива, если таких нет там и складываем с существующими, если есть
            for (int j = 0; j < mas2.Count; j++)
            {
                //есть ли текущий элемент второго в ответе
                bool IS = false;
                int pos = 0;
                for (int k = sum_length; k < ans.RowIndexes.Count && !IS; k++)
                {
                    if (mas2[j] == ans.RowIndexes[k])
                    {
                        IS = true;
                        pos = k;
                    }
                }
                //если нет, вставляем его по возрастанию
                if (!IS)
                {
                    int k;
                    for (k = sum_length; k < ans.RowIndexes.Count; k++)
                    {
                        if (ans.RowIndexes[k] > mas2[j])
                        {
                            break;
                        }
                    }    
                    //вставляем индекс
                    ans.RowIndexes.Insert(k, mas2[j]);
                    //если была перестановка, вставляем из первого, иначе из второго
                    if (swap)
                    {
                        ans.Values.Insert(k, m1.Values[cols1_done + j]);
                    }
                    else
                    {
                        ans.Values.Insert(k, m2.Values[cols2_done + j]);
                    }
                    onlySum = false;
                }
                else //если да, складываем value
                {
                    if (swap)
                    {
                        ans.Values[pos] += m1.Values[cols1_done + j];
                    }
                    else
                    {
                        ans.Values[pos] += m2.Values[cols2_done + j];
                    }
                }
            }

            sum_length = (mas1.Count == mas2.Count && !onlySum) ? sum_length + 2 * mas1.Count : sum_length + mas1.Count;

            if (swap)
            {
                cols1_done += mas2.Count;
                cols2_done += mas1.Count;
            }
            else
            {
                cols1_done += mas1.Count;
                cols2_done += mas2.Count;
            }
        }

        ans.RowsPointer.Add(ans.RowIndexes.Count);

        return ans;
    }
}
