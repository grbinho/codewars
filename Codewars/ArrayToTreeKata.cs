using System;

public class TreeNode
{
    public TreeNode left;
    public TreeNode right;
    public int value;

    public TreeNode(int value, TreeNode left, TreeNode right)
    {
        this.value = value;
        this.left = left;
        this.right = right;
    }

    public TreeNode(int value) 
    {
        this.value = value;
    }

    //Shouls recursivelly look down
    public override bool Equals(Object other)
    {
        var otherNode = other as TreeNode;

        if(otherNode == null) return false;
        
        return 
            this.value == otherNode.value &&
            ((this.left == null && otherNode.left == null) || (this.left.Equals(otherNode.left))) && 
            ((this.right == null && otherNode.right == null) || (this.right.Equals(otherNode.right)));   
    }    
}

public class ArrayToTreeKata
{

    /*  [17, 0, -4, 3, 15]

         17
        /  \
       0   -4
      / \
     3   15
    
    */

    public static TreeNode AddToTree(int index, int[] array)
    {
        if(index >= array.Length)
            return null;

        return new TreeNode(array[index], AddToTree(index*2+1, array), AddToTree(index*2+2, array));
    }    
   
    public static TreeNode ArrayToTree(int[] array)
    {      
        return AddToTree(0, array);
    }
}

