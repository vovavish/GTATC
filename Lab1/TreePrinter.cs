using System;
using System.Linq;
using static Lab1.BinaryTree;

public static class TreePrinter
{
    public static List<int>? LongestOddPath { get; set; } = null;

    class NodeInfo
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

    public static void Print(this Node? root, int topMargin = 0, int leftMargin = 0)
    {
        if (root is null)
        {
            return;
        }

        int rootTop = Console.CursorTop + topMargin;
        
        List<NodeInfo> last = new();
        
        Node? next = root;

        for (int level = 0; next != null; level++)
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
                item.StartPos = leftMargin;
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

            for (; next == null; item = item.Parent)
            {
                Print(item, rootTop + 2 * level);
                if (--level < 0)
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

        Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
    }

    private static void Print(NodeInfo item, int top)
    {
        SwapColors();
        Print(item.Text, top, item.StartPos);
        SwapColors();

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

        if (right < 0)
        {
            right = left + s.Length;
        }

        SetBGcolorIfInPath(s, ConsoleColor.Cyan);

        while (Console.CursorLeft < right)
        {
            Console.Write(s);
        }
    }

    private static void SetBGcolorIfInPath(string strNumber, ConsoleColor color)
    {
        int res;
        if (int.TryParse(strNumber, out res))
        {
            if (LongestOddPath.Contains(res))
            {
                Console.BackgroundColor = color;
            }
        }
    }

    private static void SwapColors() => (Console.BackgroundColor, Console.ForegroundColor) = (Console.ForegroundColor, Console.BackgroundColor);
}