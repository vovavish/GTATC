using static Lab1.BinaryTree;

namespace Lab1;

public static class BinaryTreePrinter
{
    private static bool _isPrintedMode = true;

    public static List<Node>? LongestOddPath { get; set; } = default!;

    internal class NodeInfo // класс, представляющий всю информацию о узле с информацией для его отоброжения в консоли
    {
        public Node Node { get; set; } = default!;
        public string Text { get; set; } = default!;
        public int StartPos { get; set; } = default!;

        public NodeInfo Parent { get; set; } = default!;
        public NodeInfo Left { get; set; } = default!;
        public NodeInfo Right { get; set; } = default!;

        public int Size
        {
            get
            {
                return Text.Length;
            }
        }

        public int EndPos
        {
            get
            {
                return StartPos + Size;
            }
            set
            {
                StartPos = value - Size;
            }
        }
    }

    public static bool CanPrint(BinaryTree? tree)
    {
        _isPrintedMode = false;

        (int x, int y) = Console.GetCursorPosition();

        try // пробуем нарисовать дерево, если возникает исключение, то возвращаем false
        {
            Print(tree);
        }
        catch
        {
            return false;
        }
        finally
        {
            ResetAll(x, y);
        }

        return true;
    }

    public static void Print(BinaryTree? tree)
    {
        if (tree is null)
        {
            return;
        }

        LongestOddPath = tree.LongestOddPath(); // сохраняем самый длинный путь для подсветки его при выводе

        int rootTop = Console.CursorTop;
        
        List<NodeInfo> last = new();
        
        Node? next = tree.Root;

        for (int level = 0; next is not null; level++)
        {
            NodeInfo item = new()
            {
                Node = next,
                Text = " " + next.Value.ToString() + " "
            };

            if (level < last.Count)
            {
                item.StartPos = last[level].EndPos + 1;
                last[level] = item;
            }
            else
            {
                item.StartPos = 0;
                last.Add(item);
            }

            if (level > 0)
            {
                item.Parent = last[level - 1];

                if (next == item.Parent.Node.LeftNode)
                {
                    item.Parent.Left = item;
                    item.EndPos = Math.Max(item.EndPos, item.Parent.StartPos);
                }
                else
                {
                    item.Parent.Right = item;
                    item.StartPos = Math.Max(item.StartPos, item.Parent.EndPos);
                }
            }

            next = next.LeftNode ?? next.RightNode;

            for (; next is null; item = item.Parent) // если нашли лист, то начинаем рисовать
            {
                Print(item, rootTop + 2 * level);

                if (--level < 0) // нарисовав поднимаемся на уровень вверх
                {
                    break;
                }
                if (item == item.Parent.Left)
                {
                    item.Parent.StartPos = item.EndPos;
                    next = item.Parent.Node.RightNode;
                }
                else
                {
                    if (item.Parent.Left is null)
                    {
                        item.Parent.EndPos = item.StartPos;
                    }
                    else
                    {
                        item.Parent.StartPos += (item.StartPos - item.Parent.EndPos) / 2;
                    }
                }
            }
        }

        Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1); // после вывода дерева устанавливаем курсор слева снизу
    }

    private static void Print(NodeInfo item, int top)
    {
        SwapColors();
        PrintNode(item.Node, top, item.StartPos);

        Console.ResetColor();

        if (item.Left is not null)
        {
            PrintLink(top + 1, "┌", "┘", item.Left.StartPos + item.Left.Size / 2, item.StartPos);
        }
        if (item.Right is not null)
        {
            PrintLink(top + 1, "└", "┐", item.EndPos - 1, item.Right.StartPos + item.Right.Size / 2);
        }
    }

    private static void PrintLink(int top, string start, string end, int startPos, int endPos)
    {
        Print(start, top, startPos);
        Print("─", top, startPos + 1, endPos);
        Print(end, top, endPos);
    }

    private static void Print(string s, int top, int left, int right = -1)
    {
        Console.SetCursorPosition(left, top);

        if (_isPrintedMode)
        {
            if (right < 0)
            {
                right = left + s.Length;
            }

            while (Console.CursorLeft < right) // рисуем линк, пока курсор не зашёл за границу экрана
            {
                Console.Write(s);
            }
        }
    }

    private static void PrintNode(Node node, int top, int left)
    {
        Console.SetCursorPosition(left, top);

        if (_isPrintedMode)
        {
            SetBGcolorIfInPath(node, ConsoleColor.Cyan);

            Console.Write(" " + node.Value + " ");
        }
    }

    private static void SetBGcolorIfInPath(Node node, ConsoleColor color)
    {
        if (LongestOddPath?.Contains(node) ?? false)
        {
            Console.BackgroundColor = color;
        }
    }

    private static void SwapColors() => (Console.BackgroundColor, Console.ForegroundColor) = (Console.ForegroundColor, Console.BackgroundColor);

    private static void ResetAll(int xConsolePos, int yConsolePos)
    {
        _isPrintedMode = true;
        Console.SetCursorPosition(xConsolePos, yConsolePos);
        Console.ResetColor();
    }
}