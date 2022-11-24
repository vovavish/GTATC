using Lab1;

BinaryTree tree = new BinaryTree();

tree.Add(171);
tree.Add(997);
tree.Add(133);
tree.Add(121);
tree.Add(123);
tree.Add(199);
tree.Add(189);
tree.Add(179);
tree.Add(169);
tree.Add(159);
tree.Add(149);
tree.Add(139);
tree.Add(129);
tree.Add(25);
tree.Add(23);
tree.Add(29);
tree.Add(21);
tree.Add(11);
tree.Add(18);
tree.Add(17);
tree.Add(151);
tree.Add(149);
tree.Add(137);
tree.Add(119);
tree.Add(134);
tree.Add(123);
//int[] nums = { 804, 804, 538, 906, 945, 708, 804, 805, 596, 835, 305, 476, 985, 612, 368, 928, 147, 773, 422, 905 };

//tree.SortedArrayToBST(nums);

tree.Print();

List<int> longestPath = tree.LongestOddPath();

Console.WriteLine(string.Join(", ", longestPath));
Console.WriteLine(string.Join(", ", tree.PrefixOrder()));
//if (longestPath is null)
//{
//    Console.WriteLine("two longest paths");
//}
//else
//{
//    Console.WriteLine("Longest Odd path:");
//    Console.WriteLine(string.Join(", ", longestPath));
//}