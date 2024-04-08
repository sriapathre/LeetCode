using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace LeetCode.Library
{
    /// <summary>
    /// Definition for a binary tree node.
    /// https://www.geeksforgeeks.org/tree-traversals-inorder-preorder-and-postorder/
    /// Inorder: Root in middle
    /// Preorder: Root first
    /// Postorder: Root last
    /// </summary>
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class Trees
    {
        /// <summary>
        /// 94. Binary Tree Inorder Traversal (easy)
        /// Given the root of a binary tree, return the inorder traversal of its nodes' values.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> InorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            InorderTraversal(root, ref result);
            return result;
        }

        private void InorderTraversal(TreeNode current, ref List<int> result)
        {
            if (current != null)
            {
                InorderTraversal(current.left, ref result);
                result.Add(current.val);
                InorderTraversal(current.right, ref result);
            }
        }

        /// <summary>
        /// 100. Same Tree (easy)
        /// Given the roots of two binary trees p and q, write a function to check if they are the same or not.
        /// Two binary trees are considered the same if they are structurally identical, and the nodes have the same value.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;
            else if (p == null || q == null)
                return false;
            if (p.val == q.val)
                return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
            return false;
        }

        /// <summary>
        /// 101. Symmetric Tree
        /// Given the root of a binary tree, check whether it is a mirror of itself (i.e., symmetric around its center).
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null)
                return true;
            return IsSymmetric(root.left, root.right);
        }
        private bool IsSymmetric(TreeNode left, TreeNode right)
        {
            if (left == null && right == null)
                return true;
            else if (left == null || right == null)
                return false;
            if (left.val == right.val)
                return IsSymmetric(left.left, right.right) && IsSymmetric(left.right, right.left);
            return false;
        }

        /// <summary>
        /// 104. Maximum Depth of Binary Tree (easy)
        /// Given the root of a binary tree, return its maximum depth.
        /// A binary tree's maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            int maxDepth = 1;
            MaxDepth(root, 1, ref maxDepth);
            return maxDepth;
        }

        private void MaxDepth(TreeNode root, int v, ref int maxDepth)
        {
            if (root == null)
                return;
            if (root.left == null && root.right == null)
            {
                maxDepth = Math.Max(maxDepth, v);
                return;
            }
            MaxDepth(root.left, v + 1, ref maxDepth);
            MaxDepth(root.right, v + 1, ref maxDepth);
        }

        /// <summary>
        /// 108. Convert Sorted Array to Binary Search Tree (easy)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public TreeNode SortedArrayToBST(int[] nums)
        {
            return SortedArrayToBST(nums, 0, nums.Length - 1);
        }

        private TreeNode SortedArrayToBST(int[] nums, int v1, int v2)
        {
            if (v1 > v2)
                return null;
            int mid = (v1 + v2) / 2;
            TreeNode root = new TreeNode(nums[mid]);
            root.left = SortedArrayToBST(nums, v1, mid - 1);
            root.right = SortedArrayToBST(nums, mid + 1, v2);
            return root;
        }

        /// <summary>
        /// 110. Balanced Binary Tree (easy)
        /// Given a binary tree, determine if it is height-balanced.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsBalanced(TreeNode root)
        {
            return root != null ? IsBalanced(root.left) && IsBalanced(root.right) && Math.Abs(TreeHeight(root.left) - TreeHeight(root.right)) < 2 : true;
        }

        private int TreeHeight(TreeNode node)
        {
            return (node != null) ? 1 + Math.Max(TreeHeight(node.left), TreeHeight(node.right)) : 0;
        }

        /// <summary>
        /// 111. Minimum Depth of Binary Tree (easy)
        /// Given a binary tree, find its minimum depth.
        /// The minimum depth is the number of nodes along the shortest path from the root node down to the nearest leaf node.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MinDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            int minDepth = int.MaxValue;
            MinDepth(root, 1, ref minDepth);
            return minDepth;
        }
        private void MinDepth(TreeNode root, int v, ref int minDepth)
        {
            if (root == null)
                return;
            if (root.left == null && root.right == null)
            {
                minDepth = Math.Min(minDepth, v);
                return;
            }
            MinDepth(root.left, v + 1, ref minDepth);
            MinDepth(root.right, v + 1, ref minDepth);
        }
        /// <summary>
        /// 112. Path Sum (easy)
        /// Given the root of a binary tree and an integer targetSum, return true if the tree has a root-to-leaf path such that adding up all the values along the path equals targetSum.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        public bool HasPathSum(TreeNode root, int targetSum)
        {
            if (root == null)
                return false;
            else if (root.left == null && root.right == null && targetSum == root.val)
                return true;
            else if (root != null)
            {
                targetSum = targetSum - root.val;
                return HasPathSum(root.left, targetSum) || HasPathSum(root.right, targetSum);
            }
            return false;
        }
    }
}
