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
        /// <a href="https://leetcode.com/problems/binary-tree-inorder-traversal/">94. Binary Tree Inorder Traversal (easy)</a>
        /// Given the root of a binary tree, return the inorder traversal of its nodes' values from left subtree to root to right subtree.
        /// </summary>
        /// <param name="root">The root of the binary tree to traverse.</param>
        /// <returns>The inorder sequence of node values.</returns>
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
        /// <a href="https://leetcode.com/problems/same-tree/">100. Same Tree (easy)</a>
        /// Given the roots of two binary trees, determine whether they are structurally identical and contain the same value at each corresponding node.
        /// </summary>
        /// <param name="p">The root of the first binary tree.</param>
        /// <param name="q">The root of the second binary tree.</param>
        /// <returns><c>true</c> if both trees have the same structure and node values.</returns>
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
        /// <a href="https://leetcode.com/problems/validate-binary-search-tree/">98. Validate Binary Search Tree (medium)</a>
        /// Determine whether a binary tree is a valid binary search tree. Every value in the left subtree
        /// must be smaller than the node value, and every value in the right subtree must be larger.
        /// Example: [2,1,3] is valid; [5,1,4,null,null,3,6] is not.
        /// Runs in O(n) time and O(h) space, where h is the tree height.
        /// </summary>
        /// <param name="root">The root of the binary tree.</param>
        /// <returns><c>true</c> when the tree satisfies binary search tree ordering.</returns>
        public bool IsValidBST(TreeNode root)
        {
            var stack = new Stack<TreeNode>();
            TreeNode previous = null;
            TreeNode current = root;

            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }

                current = stack.Pop();
                if (previous != null && current.val <= previous.val)
                    return false;

                previous = current;
                current = current.right;
            }

            return true;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/recover-binary-search-tree/">99. Recover Binary Search Tree (hard)</a>
        /// Recover a binary search tree whose two node values were swapped by mistake without changing
        /// its structure. For example, [1,3,null,null,2] is recovered by swapping 1 and 3.
        /// Runs in O(n) time and O(h) space, where h is the tree height.
        /// </summary>
        /// <param name="root">The root of the corrupted binary search tree.</param>
        public void RecoverTree(TreeNode root)
        {
            var stack = new Stack<TreeNode>();
            TreeNode current = root;
            TreeNode previous = null;
            TreeNode first = null;
            TreeNode second = null;

            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }

                current = stack.Pop();
                if (previous != null && current.val < previous.val)
                {
                    if (first == null)
                        first = previous;
                    second = current;
                }

                previous = current;
                current = current.right;
            }

            if (first != null && second != null)
            {
                int value = first.val;
                first.val = second.val;
                second.val = value;
            }
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/symmetric-tree/">101. Symmetric Tree (easy)</a>
        /// Given the root of a binary tree, determine whether it is a mirror of itself around its center.
        /// </summary>
        /// <param name="root">The root of the binary tree to check for symmetry.</param>
        /// <returns><c>true</c> if the tree is symmetric around its center.</returns>
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
        /// <a href="https://leetcode.com/problems/maximum-depth-of-binary-tree/">104. Maximum Depth of Binary Tree (easy)</a>
        /// Given the root of a binary tree, return the number of nodes along the longest path from the root down to the farthest leaf node.
        /// </summary>
        /// <param name="root">The root of the binary tree to measure.</param>
        /// <returns>The maximum depth of the binary tree.</returns>
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
        /// <a href="https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/">108. Convert Sorted Array to Binary Search Tree (easy)</a>
        /// Given an integer array sorted in ascending order, convert it into a height-balanced binary search tree.
        /// </summary>
        /// <param name="nums">The ascending sorted values used to build the binary search tree.</param>
        /// <returns>The root of the height-balanced binary search tree.</returns>
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
        /// <a href="https://leetcode.com/problems/balanced-binary-tree/">110. Balanced Binary Tree (easy)</a>
        /// Given a binary tree, determine whether it is height-balanced so the depths of every node's two subtrees differ by no more than one.
        /// </summary>
        /// <param name="root">The root of the binary tree to validate.</param>
        /// <returns><c>true</c> if the binary tree is height-balanced.</returns>
        public bool IsBalanced(TreeNode root)
        {
            return root != null ? IsBalanced(root.left) && IsBalanced(root.right) && Math.Abs(TreeHeight(root.left) - TreeHeight(root.right)) < 2 : true;
        }

        private int TreeHeight(TreeNode node)
        {
            return (node != null) ? 1 + Math.Max(TreeHeight(node.left), TreeHeight(node.right)) : 0;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-depth-of-binary-tree/">111. Minimum Depth of Binary Tree (easy)</a>
        /// Given the root of a binary tree, return the number of nodes along the shortest path from the root down to the nearest leaf node.
        /// </summary>
        /// <param name="root">The root of the binary tree to measure.</param>
        /// <returns>The minimum depth of the binary tree.</returns>
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
        /// <a href="https://leetcode.com/problems/path-sum/">112. Path Sum (easy)</a>
        /// Given the root of a binary tree and a target sum, determine whether any root-to-leaf path adds up to that value.
        /// </summary>
        /// <param name="root">The root of the binary tree to search.</param>
        /// <param name="targetSum">The required sum of the values along a root-to-leaf path.</param>
        /// <returns><c>true</c> if at least one root-to-leaf path sums to <paramref name="targetSum"/>.</returns>
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

        /// <summary>
        /// <a href="https://leetcode.com/problems/binary-tree-preorder-traversal/">144. Binary Tree Preorder Traversal (easy)</a>
        /// Given the root of a binary tree, return the preorder traversal of its nodes' values in root-left-right order.
        /// </summary>
        /// <param name="root">The root of the binary tree to traverse.</param>
        /// <returns>The preorder sequence of node values.</returns>
        public IList<int> PreorderTraversal(TreeNode root)
        {
            List<int> res = new List<int>();
            if (root == null) return res;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                TreeNode node = stack.Pop();
                res.Add(node.val);
                if (node.right != null) stack.Push(node.right);
                if (node.left != null) stack.Push(node.left);
            }
            return res;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/binary-tree-postorder-traversal/">145. Binary Tree Postorder Traversal (easy)</a>
        /// Given the root of a binary tree, return the postorder traversal of its nodes' values in left-right-root order.
        /// </summary>
        /// <param name="root">The root of the binary tree to traverse.</param>
        /// <returns>The postorder sequence of node values.</returns>
        public IList<int> PostorderTraversal(TreeNode root)
        {
            List<int> res = new List<int>();
            if (root == null) return res;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode node = stack.Pop();

                res.Insert(0,node.val);
                if (node.left != null) stack.Push(node.left);
                if (node.right != null) stack.Push(node.right);

            }
            return res;
        }
    }
}
