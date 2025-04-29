using System;
using System.Collections.Generic;

public class BinaryTree
{
    private TreeNode root;

    public void Insert(Student student)
    {
        root = InsertRec(root, student);
    }

    private TreeNode InsertRec(TreeNode node, Student student)
    {
        if (node == null)
            return new TreeNode(student);

        if (student.StudentID < node.Data.StudentID)
            node.Left = InsertRec(node.Left, student);
        else if (student.StudentID > node.Data.StudentID)
            node.Right = InsertRec(node.Right, student);

        return node;
    }

    public void PrintBreadthFirst()
    {
        Console.WriteLine($"\n{"Last Name",-15} {"Course",-6} {"Student ID",-12} {"Avg Grade",-10} {"Citizenship",-10}");
        Console.WriteLine(new string('-', 60));

        if (root == null) return;

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            Console.WriteLine(node.Data);

            if (node.Left != null) queue.Enqueue(node.Left);
            if (node.Right != null) queue.Enqueue(node.Right);
        }
    }

    public List<Student> Search(Func<Student, bool> predicate)
    {
        List<Student> result = new List<Student>();
        SearchRec(root, predicate, result);
        return result;
    }

    private void SearchRec(TreeNode node, Func<Student, bool> predicate, List<Student> result)
    {
        if (node == null) return;

        if (predicate(node.Data))
            result.Add(node.Data);

        SearchRec(node.Left, predicate, result);
        SearchRec(node.Right, predicate, result);
    }

    public void Remove(Func<Student, bool> predicate)
    {
        root = RemoveRec(root, predicate);
    }

    private TreeNode RemoveRec(TreeNode node, Func<Student, bool> predicate)
    {
        if (node == null) return null;

        node.Left = RemoveRec(node.Left, predicate);
        node.Right = RemoveRec(node.Right, predicate);

        if (predicate(node.Data))
        {
            if (node.Left == null) return node.Right;
            if (node.Right == null) return node.Left;

            // Node with 2 children
            TreeNode minNode = FindMin(node.Right);
            node.Data = minNode.Data;
            node.Right = DeleteMin(node.Right);
        }

        return node;
    }

    private TreeNode FindMin(TreeNode node)
    {
        while (node.Left != null)
            node = node.Left;
        return node;
    }

    private TreeNode DeleteMin(TreeNode node)
    {
        if (node.Left == null)
            return node.Right;
        node.Left = DeleteMin(node.Left);
        return node;
    }
}
