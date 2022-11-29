using Lab1;

BinaryTree tree = new();
int[] arr = new int[] { 29,
31, 41,
31, -1, 33, -1,
45, 16, -1, -1, 37, 40, -1,-1,
1, 11, 31, 47, -1, -1, -1, -1, 42, 10, 41, 38, -1,-1, -1,-1, };
tree.FromArray(arr);

tree = BinaryTreeGenerator.FromTextFile(@"C:\Users\vovavish\Desktop\tree.txt");

//tree.Print();

List<BinaryTree.Node> longestPath = tree.LongestOddPath();

for (int i = 0; i < longestPath.Count; i++)
{
    Console.Write(longestPath[i].Value + ", ");
}
Console.WriteLine();
Console.WriteLine(tree.HeightOfTree(tree.Root));

Console.WriteLine(string.Join(", ", tree.ToArray()));