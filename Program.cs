public class Program
{
  public class Node
  {
    public Node LeftNode { get; set; }
    public Node RightNode { get; set; }
    public int Data { get; set; }
  }
  public class BinarySearchTree
  {
    public Node Root { get; set; }
    public bool Insert(int value)
    {
      Node before = null, after = this.Root;
      while (after != null)
      {
        before = after;
        if (value < after.Data)//<=
          after = after.LeftNode;
        else if (value > after.Data)//not if
          after = after.RightNode;
        else//remove
          return false;
      }
      Node newNode = new Node();
      newNode.Data = value;
      if (this.Root == null)
        this.Root = newNode;
      else
      {
        if (value < before.Data)//<=
          before.LeftNode = newNode;
        else
          before.RightNode = newNode;
      }
      return true;
    }
    public void TraverseInOrder(Node parent)
    {
      if (parent != null)
      {
        TraverseInOrder(parent.LeftNode);
        Console.Write(parent.Data + " ");
        TraverseInOrder(parent.RightNode);
      }
    }
    public void TraversePreOrder(Node parent)
    {
      if (parent != null)
      {
        Console.Write(parent.Data + " ");
        TraversePreOrder(parent.LeftNode);
        TraversePreOrder(parent.RightNode);
      }
    }
    public void TraversePostOrder(Node parent)
    {
      if (parent != null)
      {
        TraversePostOrder(parent.LeftNode);
        TraversePostOrder(parent.RightNode);
        Console.Write(parent.Data + " ");
      }
    }
    private int MinValueOfNode(Node node)
    {
      int minv = node.Data;
      while (node.LeftNode != null)
      {
        minv = node.LeftNode.Data;
        node = node.LeftNode;
      }
      return minv;
    }
    public int FindMin()
    {
      return MinValueOfNode(this.Root);
    }
    public int FindMin2()
    {
      Node current = Root;
      while (current.LeftNode != null)
        current = current.LeftNode;
      return current.Data;
    }
    private int MaxValueOfNode(Node node)
    {
      int maxv = node.Data;
      while (node.RightNode != null)
      {
        maxv = node.RightNode.Data;
        node = node.RightNode;
      }
      return maxv;
    }
    public int FindMax()
    {
      return MaxValueOfNode(this.Root);
    }
    public int FindMax2()
    {
      Node current = Root;
      while (current.RightNode != null)
        current = current.RightNode;
      return current.Data;
    }
    public int GetTreeDepth()
    {
      return this.GetTreeDepth(this.Root);
    }
    private int GetTreeDepth(Node parent)
    {
      return parent == null ? 0 : Math.Max(GetTreeDepth(parent.LeftNode), GetTreeDepth(parent.RightNode)) + 1;
    }
    public Node Find(int value)
    { return this.Find(value, this.Root); }
    private Node Find(int value, Node parent)
    {
      if (parent != null)
      {
        if (value == parent.Data) return parent;
        if (value < parent.Data)
          return Find(value, parent.LeftNode);
        else
          return Find(value, parent.RightNode);
      }
      return null;
    }
    public void Remove(int value)
    { this.Root = Remove(this.Root, value); }
    private Node Remove(Node parent, int key)
    {
      if (parent == null) return parent;
      if (key < parent.Data) parent.LeftNode = Remove(parent.LeftNode, key);
      else if (key > parent.Data) parent.RightNode = Remove(parent.RightNode, key);
      else
      {
        if (parent.LeftNode == null) return parent.RightNode;
        else if (parent.RightNode == null) return parent.LeftNode;
        parent.Data = MinValueOfNode(parent.RightNode);
        parent.RightNode = Remove(parent.RightNode, parent.Data);
      }
      return parent;
    }
    public int Count(Node parent){
      if (parent == null)
        return 0;
      else
        return 1+Count(parent.LeftNode)+Count(parent.RightNode);
    }
    public int Count(){
      return Count(Root);
    }
    public int Sum(Node parent){
      if (parent == null)
        return 0;
      else 
        return parent.Data+ Sum(parent.LeftNode)+ Sum(parent.RightNode);
    }
    public int Sum()
    {
      return Sum(Root);
    }
    public int Product(Node parent){
      if (parent == null)
        return 1;
      else 
        return parent.Data*Product(parent.LeftNode)*Product(parent.RightNode);
    }
    public int Product()
    {
      if(Root == null)
        return 0;
      return Product(Root);
    }
    public void ConvertBST2List(Node parent, List<int> list){
      if (parent != null)
      {
        ConvertBST2List(parent.LeftNode, list);
        list.Add(parent.Data);
        ConvertBST2List(parent.RightNode, list);
      }
    }
    public void ConvertBST2List(List<int> list){
      ConvertBST2List(this.Root, list);
    }
    public void PrintPythagoreanTriplets(){
      List<int> list = new List<int>();
      ConvertBST2List(list);
      for(int i = 0; i < list.Count-2; i++)
        for(int j = i+1; j < list.Count-1; j++)
          for(int k = j+1; k < list.Count; k++)
            if(CheckPythagoreanTriplet(list[i], list[j], list[k]))
              Console.WriteLine($"({list[i]}, {list[j]}, {list[k]})");
    }
    public bool CheckPythagoreanTriplet(int a, int b, int c){
      int max = Math.Max(a, Math.Max(b, c));
      int min = Math.Min(a, Math.Min(b, c));
      int cl = a+b+c - max - min;
      return Math.Pow(max, 2) == Math.Pow(min, 2) + Math.Pow(cl, 2);
    }
  }
  static void Main()
  {
    Console.Clear();

    BinarySearchTree binaryTree = new BinarySearchTree();
    binaryTree.Insert(23); binaryTree.Insert(16); 
    binaryTree.Insert(45); 
    binaryTree.Insert(3); binaryTree.Insert(22); 
    binaryTree.Insert(37); 
    binaryTree.Insert(99);
    binaryTree.Insert(39); binaryTree.Insert(38); binaryTree.Insert(40);
    binaryTree.Insert(4); binaryTree.Insert(5);

    /*List<int> list = new List<int>();
    binaryTree.ConvertBST2List(list);
    foreach (int item in list)
      Console.WriteLine(item + ", ");*/
    binaryTree.PrintPythagoreanTriplets();
    /*
    Console.WriteLine(">> Max:" + binaryTree.FindMax());  //hoặc dùng binaryTree.FindMax2()   
    Console.WriteLine(">> Min:" + binaryTree.FindMin());  //hoặc dùng binaryTree.FindMin2()
    Node node = binaryTree.Find(5);
    int depth = binaryTree.GetTreeDepth();
    Console.WriteLine("\n>> InOrder Traversal:"); 
    binaryTree.TraverseInOrder(binaryTree.Root);
    Console.WriteLine("\n>> PreOrder Traversal:"); 
    binaryTree.TraversePreOrder(binaryTree.Root);
    Console.WriteLine("\n>> PostOrder Traversal:"); 
    binaryTree.TraversePostOrder(binaryTree.Root);
    System.Console.WriteLine("\n\nAfter removing Nodes 37:");
    binaryTree.Remove(37); //binaryTree.Remove(22);
    Console.WriteLine("\n>> PreOrder After Removing Operation:");
    binaryTree.TraversePreOrder(binaryTree.Root);*/
    /*System.Console.WriteLine("\nSo Node la");
    System.Console.WriteLine(binaryTree.Count());
    System.Console.WriteLine("\nTong:");
    System.Console.WriteLine(binaryTree.Sum());*/
    Console.ReadLine();
  }
}