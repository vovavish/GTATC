using System.Text;
using System.Text.RegularExpressions;

namespace Lab3;

public class SparseSerializer
{
    public static CRS DeserializeCRS(string path)
    {
        string text = File.ReadAllText(path);

        int rows = int.Parse(Regex.Match(text, "rows:(.*)").Groups[1].Value);
        int cols = int.Parse(Regex.Match(text, "cols:(.*)").Groups[1].Value);

        List<int> values = Regex.Match(text, @"Values: \[(.*)]").Groups[1].Value.Split(' ').Select(n => int.Parse(n)).ToList();

        List<int> rowsPointer = Regex.Match(text, @"RowsPointer: \[(.*)]").Groups[1].Value.Split(' ').Select(n => int.Parse(n)).ToList();

        List<int> rowIndexes = Regex.Match(text, @"RowIndexes: \[(.*)]").Groups[1].Value.Split(' ').Select(n => int.Parse(n)).ToList();

        return new CRS()
        {
            Cols = cols,
            Rows = rows,
            Values = values,
            RowsPointer = rowsPointer,
            RowIndexes = rowIndexes,
        };
    }

    public static CCS DeserializeCCS(string path)
    {
        string text = File.ReadAllText(path);

        int rows = int.Parse(Regex.Match(text, "rows:(.*)").Groups[1].Value);
        int cols = int.Parse(Regex.Match(text, "cols:(.*)").Groups[1].Value);

        List<int> values = Regex.Match(text, @"Values: \[(.*)\]").Groups[1].Value.Split(' ').Select(n => int.Parse(n)).ToList();

        List<int> columnPointer = Regex.Match(text, @"ColumnPointer: \[(.*)\]").Groups[1].Value.Split(' ').Select(n => int.Parse(n)).ToList();

        List<int> columnsStart = Regex.Match(text, @"ColumnsStart: \[(.*)\]").Groups[1].Value.Split(' ').Select(n => int.Parse(n)).ToList();

        return new CCS()
        {
            Cols = cols,
            Rows = rows,
            Values = values,
            ColumnPointer = columnPointer,
            ColumnsStart = columnsStart,
        };
    }

    public static string SerializeCRS(CRS crs)
    {
        StringBuilder sb = new StringBuilder();

        sb.Append($"rows:{crs.Rows}\r\n");
        sb.Append($"cols:{crs.Cols}\r\n");

        sb.Append($"Values: [{string.Join(' ', crs.Values)}]\r\n");
        sb.Append($"RowsPointer: [{string.Join(' ', crs.RowsPointer)}]\r\n");
        sb.Append($"RowIndexes: [{string.Join(' ', crs.RowIndexes)}]");

        return sb.ToString();
    }

    public static string SerializeCCS(CCS ccs)
    {
        StringBuilder sb = new StringBuilder();

        sb.Append($"rows:{ccs.Rows}\r\n");
        sb.Append($"cols:{ccs.Cols}\r\n");

        sb.Append($"Values: [{string.Join(' ', ccs.Values)}]\r\n");
        sb.Append($"ColumnPointer: [{string.Join(' ', ccs.ColumnPointer)}]\r\n");
        sb.Append($"ColumnsStart: [{string.Join(' ', ccs.ColumnsStart)}]");

        return sb.ToString();
    }
}
