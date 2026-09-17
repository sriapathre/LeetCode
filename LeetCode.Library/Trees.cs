using System;
using System.Collections.Generic;
using System.Text;
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

    /// <summary>
    /// Definition for a binary tree node with a next pointer used by LeetCode 116 and 117.
    /// </summary>
    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;
        public IList<Node> neighbors;
        public IList<Node> children;

        public Node()
        {
            neighbors = new List<Node>();
            children = new List<Node>();
        }

        public Node(int val, Node left = null, Node right = null, Node next = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
            this.next = next;
            neighbors = new List<Node>();
            children = new List<Node>();
        }

        public Node(int val, IList<Node> neighbors)
        {
            this.val = val;
            this.neighbors = neighbors;
            this.children = neighbors;
        }
    }

    /// <summary>
    /// <a href="https://leetcode.com/problems/binary-search-tree-iterator/">173. Binary Search Tree Iterator (medium)</a>
    /// Implements an in-order iterator over a binary search tree so values are returned in ascending order.
    /// </summary>
    public class BSTIterator
    {
        private readonly Stack<TreeNode> stack = new Stack<TreeNode>();

        /// <summary>
        /// Initializes the iterator at the smallest value in the tree.
        /// </summary>
        /// <param name="root">The root of the binary search tree.</param>
        public BSTIterator(TreeNode root)
        {
            PushLeft(root);
        }

        /// <summary>
        /// Returns the next smallest value and advances the iterator.
        /// </summary>
        /// <returns>The next value in ascending order.</returns>
        public int Next()
        {
            TreeNode node = stack.Pop();
            PushLeft(node.right);
            return node.val;
        }

        /// <summary>
        /// Reports whether the iterator has another value to return.
        /// </summary>
        /// <returns><c>true</c> when another value is available.</returns>
        public bool HasNext()
        {
            return stack.Count > 0;
        }

        private void PushLeft(TreeNode node)
        {
            while (node != null)
            {
                stack.Push(node);
                node = node.left;
            }
        }
    }

    /// <summary>
    /// <a href="https://leetcode.com/problems/complete-binary-tree-inserter/">919. Complete Binary Tree Inserter (medium)</a>
    /// Maintains insertion into a complete binary tree by tracking nodes with an available child; each insert runs in O(1) amortized time and O(n) space.
    /// </summary>
    public class CBTInserter
    {
        private readonly TreeNode root;
        private readonly Queue<TreeNode> candidates = new Queue<TreeNode>();

        /// <summary>
        /// Initializes the inserter with the current complete binary tree.
        /// </summary>
        /// <param name="root">The root of the complete binary tree.</param>
        public CBTInserter(TreeNode root)
        {
            this.root = root;
            var queue = new Queue<TreeNode>();
            if (root != null)
                queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                if (node.left == null || node.right == null)
                    candidates.Enqueue(node);
                if (node.left != null)
                    queue.Enqueue(node.left);
                if (node.right != null)
                    queue.Enqueue(node.right);
            }
        }

        /// <summary>
        /// Inserts a new node in level order and returns its parent's value.
        /// </summary>
        /// <param name="val">The value to insert.</param>
        /// <returns>The value of the parent that receives the new child.</returns>
        public int Insert(int val)
        {
            TreeNode parent = candidates.Peek();
            TreeNode child = new TreeNode(val);
            if (parent.left == null)
                parent.left = child;
            else
            {
                parent.right = child;
                candidates.Dequeue();
            }

            candidates.Enqueue(child);
            return parent.val;
        }

        /// <summary>
        /// Returns the root of the maintained complete binary tree.
        /// </summary>
        /// <returns>The original root with all inserted nodes attached.</returns>
        public TreeNode Get_root()
        {
            return root;
        }
    }

    /// <summary>
    /// <a href="https://leetcode.com/problems/find-elements-in-a-contaminated-binary-tree/">1261. Find Elements in a Contaminated Binary Tree (medium)</a>
    /// Recovers values in a contaminated binary tree and answers membership queries in O(1) time after O(n) preprocessing.
    /// </summary>
    public class FindElements
    {
        private readonly HashSet<int> values = new HashSet<int>();

        /// <summary>
        /// Recovers the tree values using root = 0, left = 2*x + 1, and right = 2*x + 2.
        /// </summary>
        /// <param name="root">The contaminated tree root.</param>
        public FindElements(TreeNode root)
        {
            Recover(root, 0);
        }

        /// <summary>
        /// Reports whether the recovered tree contains a target value.
        /// </summary>
        /// <param name="target">The value to search for.</param>
        /// <returns><c>true</c> when the target exists in the recovered tree.</returns>
        public bool Find(int target)
        {
            return values.Contains(target);
        }

        private void Recover(TreeNode node, int value)
        {
            if (node == null)
                return;

            node.val = value;
            values.Add(value);
            Recover(node.left, value * 2 + 1);
            Recover(node.right, value * 2 + 2);
        }
    }

    /// <summary>
    /// <a href="https://leetcode.com/problems/kth-ancestor-of-a-tree-node/">1483. Kth Ancestor of a Tree Node (hard)</a>
    /// Precomputes binary lifting ancestors so each query runs in O(log n) time using O(n log n) space.
    /// </summary>
    public class TreeAncestor
    {
        private readonly int[,] up;
        private readonly int levels;

        /// <summary>
        /// Initializes ancestor jump pointers from a parent array.
        /// </summary>
        /// <param name="n">The number of nodes labeled from 0 to n - 1.</param>
        /// <param name="parent">The parent of every node, with -1 for the root.</param>
        public TreeAncestor(int n, int[] parent)
        {
            levels = 1;
            while ((1 << levels) <= n)
                levels++;

            up = new int[n, levels];
            for (int node = 0; node < n; node++)
                up[node, 0] = parent[node];

            for (int level = 1; level < levels; level++)
            {
                for (int node = 0; node < n; node++)
                {
                    int previous = up[node, level - 1];
                    up[node, level] = previous == -1 ? -1 : up[previous, level - 1];
                }
            }
        }

        /// <summary>
        /// Returns the k-th ancestor of a node.
        /// </summary>
        /// <param name="node">The node to climb from.</param>
        /// <param name="k">The number of parent links to climb.</param>
        /// <returns>The k-th ancestor label, or -1 when it does not exist.</returns>
        public int GetKthAncestor(int node, int k)
        {
            for (int level = 0; level < levels && node != -1; level++)
            {
                if (((k >> level) & 1) == 1)
                    node = up[node, level];
            }

            return node;
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
        /// <a href="https://leetcode.com/problems/binary-tree-level-order-traversal/">102. Binary Tree Level Order Traversal (medium)</a>
        /// Given the root of a binary tree, returns its values level by level from left to right.
        /// </summary>
        /// <param name="root">The root of the binary tree to traverse.</param>
        /// <returns>The node values grouped by depth from top to bottom.</returns>
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var result = new List<IList<int>>();
            if (root == null)
                return result;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int levelCount = queue.Count;
                var level = new List<int>(levelCount);

                for (int i = 0; i < levelCount; i++)
                {
                    TreeNode node = queue.Dequeue();
                    level.Add(node.val);

                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }

                result.Add(level);
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/">103. Binary Tree Zigzag Level Order Traversal (medium)</a>
        /// Given the root of a binary tree, returns level order traversal alternating left-to-right and right-to-left each level.
        /// </summary>
        /// <param name="root">The root of the binary tree to traverse.</param>
        /// <returns>The node values grouped by depth in zigzag order.</returns>
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            var result = new List<IList<int>>();
            if (root == null)
                return result;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            bool leftToRight = true;

            while (queue.Count > 0)
            {
                int levelCount = queue.Count;
                var level = new int[levelCount];

                for (int i = 0; i < levelCount; i++)
                {
                    TreeNode node = queue.Dequeue();
                    int index = leftToRight ? i : levelCount - 1 - i;
                    level[index] = node.val;

                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }

                result.Add(new List<int>(level));
                leftToRight = !leftToRight;
            }

            return result;
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
        /// <a href="https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/">105. Construct Binary Tree from Preorder and Inorder Traversal (medium)</a>
        /// Given preorder and inorder traversal arrays with unique values, reconstructs the original binary tree.
        /// </summary>
        /// <param name="preorder">The preorder traversal values in root-left-right order.</param>
        /// <param name="inorder">The inorder traversal values in left-root-right order.</param>
        /// <returns>The root of the reconstructed binary tree.</returns>
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            var inorderIndexByValue = new Dictionary<int, int>();
            for (int i = 0; i < inorder.Length; i++)
                inorderIndexByValue[inorder[i]] = i;

            int preorderIndex = 0;
            return BuildTreeFromPreorder(preorder, 0, inorder.Length - 1, ref preorderIndex, inorderIndexByValue);
        }

        private TreeNode BuildTreeFromPreorder(int[] preorder, int inorderLeft, int inorderRight, ref int preorderIndex, Dictionary<int, int> inorderIndexByValue)
        {
            if (inorderLeft > inorderRight)
                return null;

            int value = preorder[preorderIndex++];
            TreeNode root = new TreeNode(value);
            int inorderIndex = inorderIndexByValue[value];

            root.left = BuildTreeFromPreorder(preorder, inorderLeft, inorderIndex - 1, ref preorderIndex, inorderIndexByValue);
            root.right = BuildTreeFromPreorder(preorder, inorderIndex + 1, inorderRight, ref preorderIndex, inorderIndexByValue);
            return root;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/construct-binary-tree-from-inorder-and-postorder-traversal/">106. Construct Binary Tree from Inorder and Postorder Traversal (medium)</a>
        /// Given inorder and postorder traversal arrays with unique values, reconstructs the original binary tree.
        /// </summary>
        /// <param name="inorder">The inorder traversal values in left-root-right order.</param>
        /// <param name="postorder">The postorder traversal values in left-right-root order.</param>
        /// <returns>The root of the reconstructed binary tree.</returns>
        public TreeNode BuildTreeFromInorderAndPostorder(int[] inorder, int[] postorder)
        {
            var inorderIndexByValue = new Dictionary<int, int>();
            for (int i = 0; i < inorder.Length; i++)
                inorderIndexByValue[inorder[i]] = i;

            int postorderIndex = postorder.Length - 1;
            return BuildTreeFromPostorder(postorder, 0, inorder.Length - 1, ref postorderIndex, inorderIndexByValue);
        }

        private TreeNode BuildTreeFromPostorder(int[] postorder, int inorderLeft, int inorderRight, ref int postorderIndex, Dictionary<int, int> inorderIndexByValue)
        {
            if (inorderLeft > inorderRight)
                return null;

            int value = postorder[postorderIndex--];
            TreeNode root = new TreeNode(value);
            int inorderIndex = inorderIndexByValue[value];

            root.right = BuildTreeFromPostorder(postorder, inorderIndex + 1, inorderRight, ref postorderIndex, inorderIndexByValue);
            root.left = BuildTreeFromPostorder(postorder, inorderLeft, inorderIndex - 1, ref postorderIndex, inorderIndexByValue);
            return root;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/binary-tree-level-order-traversal-ii/">107. Binary Tree Level Order Traversal II (medium)</a>
        /// Given the root of a binary tree, returns its level order traversal from leaves to root.
        /// </summary>
        /// <param name="root">The root of the binary tree to traverse.</param>
        /// <returns>The node values grouped by depth from bottom to top.</returns>
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            var result = (List<IList<int>>)LevelOrder(root);
            result.Reverse();
            return result;
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
        /// <a href="https://leetcode.com/problems/path-sum-ii/">113. Path Sum II (medium)</a>
        /// Given a binary tree and target sum, returns every root-to-leaf path whose node values add to the target.
        /// </summary>
        /// <param name="root">The root of the binary tree to search.</param>
        /// <param name="targetSum">The required sum of each root-to-leaf path.</param>
        /// <returns>All matching root-to-leaf paths.</returns>
        public IList<IList<int>> PathSum(TreeNode root, int targetSum)
        {
            var result = new List<IList<int>>();
            var path = new List<int>();
            PathSum(root, targetSum, path, result);
            return result;
        }

        private void PathSum(TreeNode root, int remainingSum, List<int> path, List<IList<int>> result)
        {
            if (root == null)
                return;

            path.Add(root.val);
            remainingSum -= root.val;

            if (root.left == null && root.right == null && remainingSum == 0)
                result.Add(new List<int>(path));
            else
            {
                PathSum(root.left, remainingSum, path, result);
                PathSum(root.right, remainingSum, path, result);
            }

            path.RemoveAt(path.Count - 1);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/flatten-binary-tree-to-linked-list/">114. Flatten Binary Tree to Linked List (medium)</a>
        /// Given the root of a binary tree, flattens it in-place into a preorder right-child-only linked list.
        /// </summary>
        /// <param name="root">The root of the binary tree to flatten.</param>
        public void Flatten(TreeNode root)
        {
            TreeNode previous = null;
            Flatten(root, ref previous);
        }

        private void Flatten(TreeNode root, ref TreeNode previous)
        {
            if (root == null)
                return;

            Flatten(root.right, ref previous);
            Flatten(root.left, ref previous);
            root.right = previous;
            root.left = null;
            previous = root;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/populating-next-right-pointers-in-each-node/">116. Populating Next Right Pointers in Each Node (medium)</a>
        /// <a href="https://leetcode.com/problems/populating-next-right-pointers-in-each-node-ii/">117. Populating Next Right Pointers in Each Node II (medium)</a>
        /// Given a binary tree node with next pointers, connects each node to its right neighbor on the same level.
        /// </summary>
        /// <param name="root">The root of the binary tree whose next pointers should be populated.</param>
        /// <returns>The original root after next pointers are connected.</returns>
        public Node Connect(Node root)
        {
            Node levelStart = root;

            while (levelStart != null)
            {
                Node dummy = new Node(0);
                Node tail = dummy;

                for (Node current = levelStart; current != null; current = current.next)
                {
                    if (current.left != null)
                    {
                        tail.next = current.left;
                        tail = tail.next;
                    }

                    if (current.right != null)
                    {
                        tail.next = current.right;
                        tail = tail.next;
                    }
                }

                levelStart = dummy.next;
            }

            return root;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/binary-tree-maximum-path-sum/">124. Binary Tree Maximum Path Sum (hard)</a>
        /// Given a non-empty binary tree, returns the maximum sum of any path where each node appears at most once.
        /// </summary>
        /// <param name="root">The root of the binary tree to evaluate.</param>
        /// <returns>The maximum path sum in the tree.</returns>
        public int MaxPathSum(TreeNode root)
        {
            int best = int.MinValue;
            MaxGain(root, ref best);
            return best;
        }

        private int MaxGain(TreeNode root, ref int best)
        {
            if (root == null)
                return 0;

            int leftGain = Math.Max(0, MaxGain(root.left, ref best));
            int rightGain = Math.Max(0, MaxGain(root.right, ref best));
            best = Math.Max(best, root.val + leftGain + rightGain);

            return root.val + Math.Max(leftGain, rightGain);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/sum-root-to-leaf-numbers/">129. Sum Root to Leaf Numbers (medium)</a>
        /// Given a binary tree whose values are digits, sums every number formed by a root-to-leaf path.
        /// </summary>
        /// <param name="root">The root of the digit tree.</param>
        /// <returns>The sum of all root-to-leaf numbers.</returns>
        public int SumNumbers(TreeNode root)
        {
            return SumNumbers(root, 0);
        }

        private int SumNumbers(TreeNode root, int current)
        {
            if (root == null)
                return 0;

            current = current * 10 + root.val;
            if (root.left == null && root.right == null)
                return current;

            return SumNumbers(root.left, current) + SumNumbers(root.right, current);
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

        /// <summary>
        /// <a href="https://leetcode.com/problems/binary-tree-right-side-view/">199. Binary Tree Right Side View (medium)</a>
        /// Given the root of a binary tree, returns the values visible when viewing the tree from its right side.
        /// </summary>
        /// <param name="root">The root of the binary tree to view.</param>
        /// <returns>The rightmost value at each depth from top to bottom.</returns>
        public IList<int> RightSideView(TreeNode root)
        {
            var result = new List<int>();
            if (root == null)
                return result;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int levelCount = queue.Count;
                for (int i = 0; i < levelCount; i++)
                {
                    TreeNode node = queue.Dequeue();
                    if (i == levelCount - 1)
                        result.Add(node.val);

                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-complete-tree-nodes/">222. Count Complete Tree Nodes (medium)</a>
        /// Counts nodes in a complete binary tree by comparing subtree edge heights and skipping perfect subtrees; runs in O(log² n) time and O(log n) space.
        /// </summary>
        /// <param name="root">The root of the complete binary tree.</param>
        /// <returns>The number of nodes in the tree.</returns>
        public int CountNodes(TreeNode root)
        {
            if (root == null)
                return 0;

            int leftHeight = CompleteTreeLeftHeight(root);
            int rightHeight = CompleteTreeRightHeight(root);
            if (leftHeight == rightHeight)
                return (1 << leftHeight) - 1;

            return 1 + CountNodes(root.left) + CountNodes(root.right);
        }

        private int CompleteTreeLeftHeight(TreeNode node)
        {
            int height = 0;
            while (node != null)
            {
                height++;
                node = node.left;
            }

            return height;
        }

        private int CompleteTreeRightHeight(TreeNode node)
        {
            int height = 0;
            while (node != null)
            {
                height++;
                node = node.right;
            }

            return height;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/invert-binary-tree/">226. Invert Binary Tree (easy)</a>
        /// Mirrors a binary tree in-place by swapping every node's children; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The root of the binary tree to invert.</param>
        /// <returns>The root of the inverted binary tree.</returns>
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
                return null;

            TreeNode left = InvertTree(root.left);
            root.left = InvertTree(root.right);
            root.right = left;
            return root;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/kth-smallest-element-in-a-bst/">230. Kth Smallest Element in a BST (medium)</a>
        /// Finds the kth value in sorted order using iterative inorder traversal; runs in O(h + k) time and O(h) space.
        /// </summary>
        /// <param name="root">The root of the binary search tree.</param>
        /// <param name="k">The one-based rank to return.</param>
        /// <returns>The kth smallest value in the BST.</returns>
        public int KthSmallest(TreeNode root, int k)
        {
            var stack = new Stack<TreeNode>();
            TreeNode current = root;

            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }

                current = stack.Pop();
                k--;
                if (k == 0)
                    return current.val;

                current = current.right;
            }

            return -1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/">235. Lowest Common Ancestor of a Binary Search Tree (medium)</a>
        /// Uses BST ordering to find the split point between two nodes; runs in O(h) time and O(1) space.
        /// </summary>
        /// <param name="root">The root of the binary search tree.</param>
        /// <param name="p">The first node.</param>
        /// <param name="q">The second node.</param>
        /// <returns>The lowest common ancestor of <paramref name="p"/> and <paramref name="q"/>.</returns>
        public TreeNode LowestCommonAncestorBST(TreeNode root, TreeNode p, TreeNode q)
        {
            while (root != null)
            {
                if (p.val < root.val && q.val < root.val)
                    root = root.left;
                else if (p.val > root.val && q.val > root.val)
                    root = root.right;
                else
                    return root;
            }

            return null;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/">236. Lowest Common Ancestor of a Binary Tree (medium)</a>
        /// Recursively returns the node where target nodes meet in a binary tree; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The root of the binary tree.</param>
        /// <param name="p">The first node.</param>
        /// <param name="q">The second node.</param>
        /// <returns>The lowest common ancestor of <paramref name="p"/> and <paramref name="q"/>.</returns>
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root == p || root == q)
                return root;

            TreeNode left = LowestCommonAncestor(root.left, p, q);
            TreeNode right = LowestCommonAncestor(root.right, p, q);
            if (left != null && right != null)
                return root;

            return left ?? right;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/binary-tree-paths/">257. Binary Tree Paths (easy)</a>
        /// Lists every root-to-leaf path as an arrow-delimited string; runs in O(nh) time for string materialization and O(h) space.
        /// </summary>
        /// <param name="root">The root of the binary tree.</param>
        /// <returns>All root-to-leaf paths in the tree.</returns>
        public IList<string> BinaryTreePaths(TreeNode root)
        {
            var result = new List<string>();
            BinaryTreePaths(root, new List<int>(), result);
            return result;
        }

        private void BinaryTreePaths(TreeNode node, List<int> path, List<string> result)
        {
            if (node == null)
                return;

            path.Add(node.val);
            if (node.left == null && node.right == null)
                result.Add(string.Join("->", path));
            else
            {
                BinaryTreePaths(node.left, path, result);
                BinaryTreePaths(node.right, path, result);
            }

            path.RemoveAt(path.Count - 1);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/verify-preorder-serialization-of-a-binary-tree/">331. Verify Preorder Serialization of a Binary Tree (medium)</a>
        /// Validates preorder null-marker serialization with slot counting; runs in O(n) time and O(1) space.
        /// </summary>
        /// <param name="preorder">The comma-separated preorder serialization.</param>
        /// <returns><c>true</c> when the serialization describes exactly one valid binary tree.</returns>
        public bool IsValidSerialization(string preorder)
        {
            int slots = 1;
            string[] tokens = preorder.Split(',');

            foreach (string token in tokens)
            {
                if (slots == 0)
                    return false;

                if (token == "#")
                    slots--;
                else
                    slots++;
            }

            return slots == 0;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/house-robber-iii/">337. House Robber III (medium)</a>
        /// Computes the best robbed and skipped value for every tree node; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The root of the binary tree of house values.</param>
        /// <returns>The maximum money that can be robbed without robbing adjacent tree nodes.</returns>
        public int Rob(TreeNode root)
        {
            int[] values = RobSubtree(root);
            return Math.Max(values[0], values[1]);
        }

        private int[] RobSubtree(TreeNode node)
        {
            if (node == null)
                return new[] { 0, 0 };

            int[] left = RobSubtree(node.left);
            int[] right = RobSubtree(node.right);
            int rob = node.val + left[1] + right[1];
            int skip = Math.Max(left[0], left[1]) + Math.Max(right[0], right[1]);
            return new[] { rob, skip };
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/sum-of-left-leaves/">404. Sum of Left Leaves (easy)</a>
        /// Sums values of leaves that are left children of their parent; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The root of the binary tree.</param>
        /// <returns>The sum of all left leaf values.</returns>
        public int SumOfLeftLeaves(TreeNode root)
        {
            if (root == null)
                return 0;

            int sum = 0;
            if (root.left != null && root.left.left == null && root.left.right == null)
                sum += root.left.val;

            return sum + SumOfLeftLeaves(root.left) + SumOfLeftLeaves(root.right);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/n-ary-tree-level-order-traversal/">429. N-ary Tree Level Order Traversal (medium)</a>
        /// Traverses an N-ary tree breadth-first and groups values by depth; runs in O(n) time and O(w) space.
        /// </summary>
        /// <param name="root">The root of the N-ary tree.</param>
        /// <returns>The node values grouped by tree level.</returns>
        public IList<IList<int>> LevelOrder(Node root)
        {
            var result = new List<IList<int>>();
            if (root == null)
                return result;

            var queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int count = queue.Count;
                var level = new List<int>(count);
                for (int i = 0; i < count; i++)
                {
                    Node node = queue.Dequeue();
                    level.Add(node.val);
                    if (node.children == null)
                        continue;

                    foreach (Node child in node.children)
                    {
                        if (child != null)
                            queue.Enqueue(child);
                    }
                }

                result.Add(level);
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/path-sum-iii/">437. Path Sum III (medium)</a>
        /// Counts downward paths whose values sum to a target using prefix sums; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The root of the binary tree.</param>
        /// <param name="targetSum">The target path sum.</param>
        /// <returns>The number of downward paths that sum to <paramref name="targetSum"/>.</returns>
        public int PathSumIII(TreeNode root, int targetSum)
        {
            var prefixCounts = new Dictionary<long, int>();
            prefixCounts[0] = 1;
            return PathSumIII(root, 0, targetSum, prefixCounts);
        }

        private int PathSumIII(TreeNode node, long runningSum, int targetSum, Dictionary<long, int> prefixCounts)
        {
            if (node == null)
                return 0;

            runningSum += node.val;
            int count = prefixCounts.TryGetValue(runningSum - targetSum, out int paths) ? paths : 0;
            prefixCounts.TryGetValue(runningSum, out int existing);
            prefixCounts[runningSum] = existing + 1;

            count += PathSumIII(node.left, runningSum, targetSum, prefixCounts);
            count += PathSumIII(node.right, runningSum, targetSum, prefixCounts);

            prefixCounts[runningSum]--;
            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/delete-node-in-a-bst/">450. Delete Node in a BST (medium)</a>
        /// Deletes a key from a BST by replacing two-child nodes with their inorder successor; runs in O(h) time and O(h) space.
        /// </summary>
        /// <param name="root">The root of the binary search tree.</param>
        /// <param name="key">The value to delete.</param>
        /// <returns>The root of the BST after deletion.</returns>
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null)
                return null;

            if (key < root.val)
                root.left = DeleteNode(root.left, key);
            else if (key > root.val)
                root.right = DeleteNode(root.right, key);
            else
            {
                if (root.left == null)
                    return root.right;
                if (root.right == null)
                    return root.left;

                TreeNode successor = root.right;
                while (successor.left != null)
                    successor = successor.left;

                root.val = successor.val;
                root.right = DeleteNode(root.right, successor.val);
            }

            return root;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-mode-in-binary-search-tree/">501. Find Mode in Binary Search Tree (easy)</a>
        /// Finds the most frequent value or values in a BST using inorder traversal; runs in O(n) time and O(h + m) space.
        /// </summary>
        /// <param name="root">The root of the binary search tree.</param>
        /// <returns>All values tied for highest frequency.</returns>
        public int[] FindMode(TreeNode root)
        {
            var modes = new List<int>();
            int currentValue = 0;
            int currentCount = 0;
            int bestCount = 0;
            bool hasValue = false;
            FindMode(root, ref currentValue, ref currentCount, ref bestCount, ref hasValue, modes);
            return modes.ToArray();
        }

        private void FindMode(TreeNode node, ref int currentValue, ref int currentCount, ref int bestCount, ref bool hasValue, List<int> modes)
        {
            if (node == null)
                return;

            FindMode(node.left, ref currentValue, ref currentCount, ref bestCount, ref hasValue, modes);

            if (!hasValue || node.val != currentValue)
            {
                currentValue = node.val;
                currentCount = 0;
                hasValue = true;
            }

            currentCount++;
            if (currentCount > bestCount)
            {
                bestCount = currentCount;
                modes.Clear();
                modes.Add(node.val);
            }
            else if (currentCount == bestCount)
                modes.Add(node.val);

            FindMode(node.right, ref currentValue, ref currentCount, ref bestCount, ref hasValue, modes);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-bottom-left-tree-value/">513. Find Bottom Left Tree Value (medium)</a>
        /// Returns the first node encountered on the deepest level using BFS; runs in O(n) time and O(w) space.
        /// </summary>
        /// <param name="root">The non-null root of the binary tree.</param>
        /// <returns>The leftmost value in the last row.</returns>
        public int FindBottomLeftValue(TreeNode root)
        {
            int answer = root.val;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int count = queue.Count;
                answer = queue.Peek().val;
                for (int i = 0; i < count; i++)
                {
                    TreeNode node = queue.Dequeue();
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }
            }

            return answer;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-largest-value-in-each-tree-row/">515. Find Largest Value in Each Tree Row (medium)</a>
        /// Finds the maximum value on each tree level using BFS; runs in O(n) time and O(w) space.
        /// </summary>
        /// <param name="root">The root of the binary tree.</param>
        /// <returns>The largest value from every tree row, top to bottom.</returns>
        public IList<int> LargestValues(TreeNode root)
        {
            var result = new List<int>();
            if (root == null)
                return result;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int count = queue.Count;
                int largest = int.MinValue;
                for (int i = 0; i < count; i++)
                {
                    TreeNode node = queue.Dequeue();
                    largest = Math.Max(largest, node.val);
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }

                result.Add(largest);
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-absolute-difference-in-bst/">530. Minimum Absolute Difference in BST (easy)</a>
        /// Computes adjacent differences in sorted inorder order; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The root of the binary search tree.</param>
        /// <returns>The minimum absolute difference between any two node values.</returns>
        public int GetMinimumDifference(TreeNode root)
        {
            int previous = 0;
            int best = int.MaxValue;
            bool hasPrevious = false;
            GetMinimumDifference(root, ref previous, ref best, ref hasPrevious);
            return best;
        }

        private void GetMinimumDifference(TreeNode node, ref int previous, ref int best, ref bool hasPrevious)
        {
            if (node == null)
                return;

            GetMinimumDifference(node.left, ref previous, ref best, ref hasPrevious);
            if (hasPrevious)
                best = Math.Min(best, node.val - previous);
            previous = node.val;
            hasPrevious = true;
            GetMinimumDifference(node.right, ref previous, ref best, ref hasPrevious);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/convert-bst-to-greater-tree/">538. Convert BST to Greater Tree (medium)</a>
        /// Rewrites each BST node as its value plus all greater values by reverse inorder traversal; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The root of the binary search tree.</param>
        /// <returns>The root after conversion to a greater tree.</returns>
        public TreeNode ConvertBST(TreeNode root)
        {
            int sum = 0;
            ConvertBST(root, ref sum);
            return root;
        }

        private void ConvertBST(TreeNode node, ref int sum)
        {
            if (node == null)
                return;

            ConvertBST(node.right, ref sum);
            sum += node.val;
            node.val = sum;
            ConvertBST(node.left, ref sum);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/diameter-of-binary-tree/">543. Diameter of Binary Tree (easy)</a>
        /// Calculates the longest path between any two nodes measured in edges; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The root of the binary tree.</param>
        /// <returns>The diameter of the tree in edges.</returns>
        public int DiameterOfBinaryTree(TreeNode root)
        {
            int best = 0;
            DiameterHeight(root, ref best);
            return best;
        }

        private int DiameterHeight(TreeNode node, ref int best)
        {
            if (node == null)
                return 0;

            int left = DiameterHeight(node.left, ref best);
            int right = DiameterHeight(node.right, ref best);
            best = Math.Max(best, left + right);
            return 1 + Math.Max(left, right);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-depth-of-n-ary-tree/">559. Maximum Depth of N-ary Tree (easy)</a>
        /// Returns the number of nodes on the longest root-to-leaf N-ary path; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The root of the N-ary tree.</param>
        /// <returns>The maximum depth of the N-ary tree.</returns>
        public int MaxDepth(Node root)
        {
            if (root == null)
                return 0;

            int depth = 1;
            if (root.children != null)
            {
                foreach (Node child in root.children)
                    depth = Math.Max(depth, 1 + MaxDepth(child));
            }

            return depth;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/binary-tree-tilt/">563. Binary Tree Tilt (easy)</a>
        /// Sums each node's absolute left-subtree/right-subtree sum difference; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The root of the binary tree.</param>
        /// <returns>The total tilt of all nodes.</returns>
        public int FindTilt(TreeNode root)
        {
            int tilt = 0;
            SubtreeSumForTilt(root, ref tilt);
            return tilt;
        }

        private int SubtreeSumForTilt(TreeNode node, ref int tilt)
        {
            if (node == null)
                return 0;

            int left = SubtreeSumForTilt(node.left, ref tilt);
            int right = SubtreeSumForTilt(node.right, ref tilt);
            tilt += Math.Abs(left - right);
            return node.val + left + right;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/subtree-of-another-tree/">572. Subtree of Another Tree (easy)</a>
        /// Checks whether one binary tree occurs as an identical subtree of another; runs in O(mn) time and O(h) space.
        /// </summary>
        /// <param name="root">The candidate containing tree.</param>
        /// <param name="subRoot">The candidate subtree.</param>
        /// <returns><c>true</c> if <paramref name="subRoot"/> is a subtree of <paramref name="root"/>.</returns>
        public bool IsSubtree(TreeNode root, TreeNode subRoot)
        {
            if (subRoot == null)
                return true;
            if (root == null)
                return false;

            return IsSameTree(root, subRoot) || IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/n-ary-tree-preorder-traversal/">589. N-ary Tree Preorder Traversal (easy)</a>
        /// Returns root-then-children preorder traversal for an N-ary tree; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The root of the N-ary tree.</param>
        /// <returns>The preorder sequence of node values.</returns>
        public IList<int> Preorder(Node root)
        {
            var result = new List<int>();
            PreorderNary(root, result);
            return result;
        }

        private void PreorderNary(Node node, List<int> result)
        {
            if (node == null)
                return;

            result.Add(node.val);
            if (node.children == null)
                return;

            foreach (Node child in node.children)
                PreorderNary(child, result);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/n-ary-tree-postorder-traversal/">590. N-ary Tree Postorder Traversal (easy)</a>
        /// Returns children-then-root postorder traversal for an N-ary tree; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The root of the N-ary tree.</param>
        /// <returns>The postorder sequence of node values.</returns>
        public IList<int> Postorder(Node root)
        {
            var result = new List<int>();
            PostorderNary(root, result);
            return result;
        }

        private void PostorderNary(Node node, List<int> result)
        {
            if (node == null)
                return;

            if (node.children != null)
            {
                foreach (Node child in node.children)
                    PostorderNary(child, result);
            }

            result.Add(node.val);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/construct-string-from-binary-tree/">606. Construct String from Binary Tree (easy)</a>
        /// Builds the preorder parenthesized representation while preserving required empty left children; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The root of the binary tree.</param>
        /// <returns>The compact parenthesized string representation.</returns>
        public string Tree2str(TreeNode root)
        {
            if (root == null)
                return string.Empty;

            var builder = new StringBuilder();
            Tree2str(root, builder);
            return builder.ToString();
        }

        private void Tree2str(TreeNode node, StringBuilder builder)
        {
            if (node == null)
                return;

            builder.Append(node.val);
            if (node.left == null && node.right == null)
                return;

            builder.Append('(');
            Tree2str(node.left, builder);
            builder.Append(')');
            if (node.right != null)
            {
                builder.Append('(');
                Tree2str(node.right, builder);
                builder.Append(')');
            }
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/merge-two-binary-trees/">617. Merge Two Binary Trees (easy)</a>
        /// Merges two trees by summing overlapping nodes and reusing non-overlapping subtrees; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root1">The root of the first binary tree.</param>
        /// <param name="root2">The root of the second binary tree.</param>
        /// <returns>The merged binary tree root.</returns>
        public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
        {
            if (root1 == null)
                return root2;
            if (root2 == null)
                return root1;

            root1.val += root2.val;
            root1.left = MergeTrees(root1.left, root2.left);
            root1.right = MergeTrees(root1.right, root2.right);
            return root1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/average-of-levels-in-binary-tree/">637. Average of Levels in Binary Tree (easy)</a>
        /// Computes each binary-tree level average with breadth-first traversal; runs in O(n) time and O(w) space.
        /// </summary>
        /// <param name="root">The root of the binary tree.</param>
        /// <returns>The average value of every level from top to bottom.</returns>
        public IList<double> AverageOfLevels(TreeNode root)
        {
            var result = new List<double>();
            if (root == null)
                return result;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int count = queue.Count;
                long sum = 0;
                for (int i = 0; i < count; i++)
                {
                    TreeNode node = queue.Dequeue();
                    sum += node.val;
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }

                result.Add((double)sum / count);
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/two-sum-iv-input-is-a-bst/">653. Two Sum IV - Input is a BST (easy)</a>
        /// Determines whether any two BST values sum to the target using a visited set; runs in O(n) time and O(n) space.
        /// </summary>
        /// <param name="root">The root of the binary search tree.</param>
        /// <param name="k">The target sum.</param>
        /// <returns><c>true</c> if two distinct nodes sum to <paramref name="k"/>.</returns>
        public bool FindTarget(TreeNode root, int k)
        {
            var seen = new HashSet<int>();
            return FindTarget(root, k, seen);
        }

        private bool FindTarget(TreeNode node, int k, HashSet<int> seen)
        {
            if (node == null)
                return false;

            if (seen.Contains(k - node.val))
                return true;

            seen.Add(node.val);
            return FindTarget(node.left, k, seen) || FindTarget(node.right, k, seen);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/trim-a-binary-search-tree/">669. Trim a Binary Search Tree (medium)</a>
        /// Removes BST nodes outside an inclusive range while preserving valid descendants; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The root of the binary search tree.</param>
        /// <param name="low">The inclusive lower bound.</param>
        /// <param name="high">The inclusive upper bound.</param>
        /// <returns>The root of the trimmed BST.</returns>
        public TreeNode TrimBST(TreeNode root, int low, int high)
        {
            if (root == null)
                return null;
            if (root.val < low)
                return TrimBST(root.right, low, high);
            if (root.val > high)
                return TrimBST(root.left, low, high);

            root.left = TrimBST(root.left, low, high);
            root.right = TrimBST(root.right, low, high);
            return root;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/second-minimum-node-in-a-binary-tree/">671. Second Minimum Node In a Binary Tree (easy)</a>
        /// Finds the smallest value greater than the root in the special min-root tree; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The root of the special binary tree.</param>
        /// <returns>The second minimum value, or -1 when it does not exist.</returns>
        public int FindSecondMinimumValue(TreeNode root)
        {
            long second = long.MaxValue;
            int minimum = root.val;
            FindSecondMinimumValue(root, minimum, ref second);
            return second == long.MaxValue ? -1 : (int)second;
        }

        private void FindSecondMinimumValue(TreeNode node, int minimum, ref long second)
        {
            if (node == null)
                return;
            if (node.val > minimum && node.val < second)
                second = node.val;

            FindSecondMinimumValue(node.left, minimum, ref second);
            FindSecondMinimumValue(node.right, minimum, ref second);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/longest-univalue-path/">687. Longest Univalue Path (medium)</a>
        /// Finds the longest same-value path measured in edges; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The root of the binary tree.</param>
        /// <returns>The length in edges of the longest path whose nodes all share one value.</returns>
        public int LongestUnivaluePath(TreeNode root)
        {
            int best = 0;
            LongestUnivaluePath(root, ref best);
            return best;
        }

        private int LongestUnivaluePath(TreeNode node, ref int best)
        {
            if (node == null)
                return 0;

            int left = LongestUnivaluePath(node.left, ref best);
            int right = LongestUnivaluePath(node.right, ref best);
            int leftPath = node.left != null && node.left.val == node.val ? left + 1 : 0;
            int rightPath = node.right != null && node.right.val == node.val ? right + 1 : 0;
            best = Math.Max(best, leftPath + rightPath);
            return Math.Max(leftPath, rightPath);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/insert-into-a-binary-search-tree/">701. Insert into a Binary Search Tree (medium)</a>
        /// Inserts a value into a BST while preserving ordering; runs in O(h) time and O(h) recursion space.
        /// </summary>
        /// <param name="root">The root of the binary search tree.</param>
        /// <param name="val">The value to insert.</param>
        /// <returns>The root of the BST after insertion.</returns>
        public TreeNode InsertIntoBST(TreeNode root, int val)
        {
            if (root == null)
                return new TreeNode(val);
            if (val < root.val)
                root.left = InsertIntoBST(root.left, val);
            else
                root.right = InsertIntoBST(root.right, val);
            return root;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-distance-between-bst-nodes/">783. Minimum Distance Between BST Nodes (easy)</a>
        /// Finds the smallest difference between any two BST values via inorder traversal; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The root of the binary search tree.</param>
        /// <returns>The minimum absolute difference between two node values.</returns>
        public int MinDiffInBST(TreeNode root)
        {
            int previous = 0;
            bool hasPrevious = false;
            int best = int.MaxValue;
            MinDiffInBST(root, ref previous, ref hasPrevious, ref best);
            return best;
        }

        private void MinDiffInBST(TreeNode node, ref int previous, ref bool hasPrevious, ref int best)
        {
            if (node == null)
                return;
            MinDiffInBST(node.left, ref previous, ref hasPrevious, ref best);
            if (hasPrevious)
                best = Math.Min(best, node.val - previous);
            previous = node.val;
            hasPrevious = true;
            MinDiffInBST(node.right, ref previous, ref hasPrevious, ref best);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/binary-tree-pruning/">814. Binary Tree Pruning (medium)</a>
        /// Removes every subtree that does not contain a 1; runs in O(n) time and O(h) recursion space.
        /// </summary>
        /// <param name="root">The binary tree root whose values are 0 or 1.</param>
        /// <returns>The pruned tree root, or null when the entire tree is removed.</returns>
        public TreeNode PruneTree(TreeNode root)
        {
            if (root == null)
                return null;
            root.left = PruneTree(root.left);
            root.right = PruneTree(root.right);
            return root.val == 0 && root.left == null && root.right == null ? null : root;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/all-nodes-distance-k-in-binary-tree/">863. All Nodes Distance K in Binary Tree (medium)</a>
        /// Builds parent links and performs breadth-first search from the target; runs in O(n) time and O(n) space.
        /// </summary>
        /// <param name="root">The binary tree root.</param>
        /// <param name="target">The node to start from.</param>
        /// <param name="k">The exact distance in edges.</param>
        /// <returns>Values of all nodes exactly distance <paramref name="k"/> from the target.</returns>
        public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
        {
            var result = new List<int>();
            if (root == null || target == null)
                return result;

            var parents = new Dictionary<TreeNode, TreeNode>();
            BuildParents(root, null, parents);
            var visited = new HashSet<TreeNode> { target };
            var queue = new Queue<TreeNode>();
            queue.Enqueue(target);
            int distance = 0;

            while (queue.Count > 0)
            {
                int count = queue.Count;
                if (distance == k)
                {
                    while (queue.Count > 0)
                        result.Add(queue.Dequeue().val);
                    return result;
                }

                for (int i = 0; i < count; i++)
                {
                    TreeNode node = queue.Dequeue();
                    EnqueueDistanceNeighbor(node.left, visited, queue);
                    EnqueueDistanceNeighbor(node.right, visited, queue);
                    EnqueueDistanceNeighbor(parents[node], visited, queue);
                }

                distance++;
            }

            return result;
        }

        private void BuildParents(TreeNode node, TreeNode parent, Dictionary<TreeNode, TreeNode> parents)
        {
            if (node == null)
                return;
            parents[node] = parent;
            BuildParents(node.left, node, parents);
            BuildParents(node.right, node, parents);
        }

        private void EnqueueDistanceNeighbor(TreeNode node, HashSet<TreeNode> visited, Queue<TreeNode> queue)
        {
            if (node != null && visited.Add(node))
                queue.Enqueue(node);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/leaf-similar-trees/">872. Leaf-Similar Trees (easy)</a>
        /// Compares the leaf-value sequences of two binary trees; runs in O(n + m) time and O(l) space.
        /// </summary>
        /// <param name="root1">The first binary tree root.</param>
        /// <param name="root2">The second binary tree root.</param>
        /// <returns><c>true</c> when both trees have identical leaf sequences.</returns>
        public bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            var first = new List<int>();
            var second = new List<int>();
            CollectLeaves(root1, first);
            CollectLeaves(root2, second);
            if (first.Count != second.Count)
                return false;
            for (int i = 0; i < first.Count; i++)
            {
                if (first[i] != second[i])
                    return false;
            }

            return true;
        }

        private void CollectLeaves(TreeNode node, IList<int> leaves)
        {
            if (node == null)
                return;
            if (node.left == null && node.right == null)
            {
                leaves.Add(node.val);
                return;
            }

            CollectLeaves(node.left, leaves);
            CollectLeaves(node.right, leaves);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/construct-binary-tree-from-preorder-and-postorder-traversal/">889. Construct Binary Tree from Preorder and Postorder Traversal (medium)</a>
        /// Reconstructs one valid binary tree from preorder and postorder traversals; runs in O(n) time and O(n) space.
        /// </summary>
        /// <param name="preorder">The preorder traversal values.</param>
        /// <param name="postorder">The postorder traversal values.</param>
        /// <returns>A binary tree matching both traversals.</returns>
        public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder)
        {
            var postIndex = new Dictionary<int, int>();
            for (int i = 0; i < postorder.Length; i++)
                postIndex[postorder[i]] = i;
            return ConstructFromPrePost(preorder, 0, preorder.Length - 1, 0, postIndex);
        }

        private TreeNode ConstructFromPrePost(int[] preorder, int preLeft, int preRight, int postLeft, Dictionary<int, int> postIndex)
        {
            if (preLeft > preRight)
                return null;
            TreeNode root = new TreeNode(preorder[preLeft]);
            if (preLeft == preRight)
                return root;
            int leftSize = postIndex[preorder[preLeft + 1]] - postLeft + 1;
            root.left = ConstructFromPrePost(preorder, preLeft + 1, preLeft + leftSize, postLeft, postIndex);
            root.right = ConstructFromPrePost(preorder, preLeft + leftSize + 1, preRight, postLeft + leftSize, postIndex);
            return root;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/increasing-order-search-tree/">897. Increasing Order Search Tree (easy)</a>
        /// Rewires a BST into an inorder-only right-skewed tree; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The binary search tree root.</param>
        /// <returns>The smallest node as the root of the increasing-order tree.</returns>
        public TreeNode IncreasingBST(TreeNode root)
        {
            TreeNode dummy = new TreeNode();
            TreeNode current = dummy;
            IncreasingBST(root, ref current);
            return dummy.right;
        }

        private void IncreasingBST(TreeNode node, ref TreeNode current)
        {
            if (node == null)
                return;
            IncreasingBST(node.left, ref current);
            node.left = null;
            current.right = node;
            current = node;
            IncreasingBST(node.right, ref current);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/range-sum-of-bst/">938. Range Sum of BST (easy)</a>
        /// Sums BST values within an inclusive range while pruning impossible branches; runs in O(n) worst-case time and O(h) space.
        /// </summary>
        /// <param name="root">The binary search tree root.</param>
        /// <param name="low">The inclusive lower bound.</param>
        /// <param name="high">The inclusive upper bound.</param>
        /// <returns>The sum of values between <paramref name="low"/> and <paramref name="high"/>.</returns>
        public int RangeSumBST(TreeNode root, int low, int high)
        {
            if (root == null)
                return 0;
            if (root.val < low)
                return RangeSumBST(root.right, low, high);
            if (root.val > high)
                return RangeSumBST(root.left, low, high);
            return root.val + RangeSumBST(root.left, low, high) + RangeSumBST(root.right, low, high);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/flip-equivalent-binary-trees/">951. Flip Equivalent Binary Trees (medium)</a>
        /// Checks whether two trees can match by swapping children at any nodes; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root1">The first binary tree root.</param>
        /// <param name="root2">The second binary tree root.</param>
        /// <returns><c>true</c> when the trees are flip equivalent.</returns>
        public bool FlipEquiv(TreeNode root1, TreeNode root2)
        {
            if (root1 == null || root2 == null)
                return root1 == root2;
            if (root1.val != root2.val)
                return false;
            return FlipEquiv(root1.left, root2.left) && FlipEquiv(root1.right, root2.right)
                || FlipEquiv(root1.left, root2.right) && FlipEquiv(root1.right, root2.left);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/check-completeness-of-a-binary-tree/">958. Check Completeness of a Binary Tree (medium)</a>
        /// Verifies level-order completeness by rejecting any node found after a missing child; runs in O(n) time and O(w) space.
        /// </summary>
        /// <param name="root">The binary tree root.</param>
        /// <returns><c>true</c> when the tree is complete.</returns>
        public bool IsCompleteTree(TreeNode root)
        {
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            bool seenNull = false;
            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                if (node == null)
                {
                    seenNull = true;
                    continue;
                }

                if (seenNull)
                    return false;
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }

            return true;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/univalued-binary-tree/">965. Univalued Binary Tree (easy)</a>
        /// Determines whether all nodes contain the root value; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The binary tree root.</param>
        /// <returns><c>true</c> when every node has the same value.</returns>
        public bool IsUnivalTree(TreeNode root)
        {
            return root == null || IsUnivalTree(root, root.val);
        }

        private bool IsUnivalTree(TreeNode node, int value)
        {
            if (node == null)
                return true;
            return node.val == value && IsUnivalTree(node.left, value) && IsUnivalTree(node.right, value);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/binary-tree-cameras/">968. Binary Tree Cameras (hard)</a>
        /// Greedily places cameras from leaves upward so every node is monitored; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The binary tree root.</param>
        /// <returns>The minimum number of cameras needed to monitor every node.</returns>
        public int MinCameraCover(TreeNode root)
        {
            int cameras = 0;
            return CameraState(root, ref cameras) == 0 ? cameras + 1 : cameras;
        }

        private int CameraState(TreeNode node, ref int cameras)
        {
            if (node == null)
                return 2;
            int left = CameraState(node.left, ref cameras);
            int right = CameraState(node.right, ref cameras);
            if (left == 0 || right == 0)
            {
                cameras++;
                return 1;
            }

            return left == 1 || right == 1 ? 2 : 0;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/flip-binary-tree-to-match-preorder-traversal/">971. Flip Binary Tree To Match Preorder Traversal (medium)</a>
        /// Returns node values that must be flipped to match a voyage preorder, or -1 if impossible; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The binary tree root.</param>
        /// <param name="voyage">The desired preorder traversal.</param>
        /// <returns>Flip node values, or a single -1 when no sequence can match the voyage.</returns>
        public IList<int> FlipMatchVoyage(TreeNode root, int[] voyage)
        {
            var result = new List<int>();
            int index = 0;
            if (!FlipMatchVoyage(root, voyage, ref index, result))
                return new List<int> { -1 };
            return result;
        }

        private bool FlipMatchVoyage(TreeNode node, int[] voyage, ref int index, IList<int> result)
        {
            if (node == null)
                return true;
            if (index >= voyage.Length || node.val != voyage[index++])
                return false;
            if (node.left != null && index < voyage.Length && node.left.val != voyage[index])
            {
                result.Add(node.val);
                return FlipMatchVoyage(node.right, voyage, ref index, result) && FlipMatchVoyage(node.left, voyage, ref index, result);
            }

            return FlipMatchVoyage(node.left, voyage, ref index, result) && FlipMatchVoyage(node.right, voyage, ref index, result);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/distribute-coins-in-binary-tree/">979. Distribute Coins in Binary Tree (medium)</a>
        /// Accumulates subtree coin surplus and deficits to count edge moves; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The binary tree root with total coins equal to total nodes.</param>
        /// <returns>The minimum number of moves required so every node has one coin.</returns>
        public int DistributeCoins(TreeNode root)
        {
            int moves = 0;
            CoinBalance(root, ref moves);
            return moves;
        }

        private int CoinBalance(TreeNode node, ref int moves)
        {
            if (node == null)
                return 0;
            int left = CoinBalance(node.left, ref moves);
            int right = CoinBalance(node.right, ref moves);
            moves += Math.Abs(left) + Math.Abs(right);
            return node.val + left + right - 1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/vertical-order-traversal-of-a-binary-tree/">987. Vertical Order Traversal of a Binary Tree (hard)</a>
        /// Sorts nodes by column, row, then value to produce vertical traversal; runs in O(n log n) time and O(n) space.
        /// </summary>
        /// <param name="root">The binary tree root.</param>
        /// <returns>Node values grouped from leftmost column to rightmost column.</returns>
        public IList<IList<int>> VerticalTraversal(TreeNode root)
        {
            var nodes = new List<Tuple<int, int, int>>();
            CollectVertical(root, 0, 0, nodes);
            nodes.Sort((a, b) => a.Item1 != b.Item1 ? a.Item1.CompareTo(b.Item1) : a.Item2 != b.Item2 ? a.Item2.CompareTo(b.Item2) : a.Item3.CompareTo(b.Item3));
            var result = new List<IList<int>>();
            int? currentColumn = null;
            foreach (Tuple<int, int, int> item in nodes)
            {
                if (currentColumn == null || item.Item1 != currentColumn.Value)
                {
                    result.Add(new List<int>());
                    currentColumn = item.Item1;
                }

                result[result.Count - 1].Add(item.Item3);
            }

            return result;
        }

        private void CollectVertical(TreeNode node, int row, int column, IList<Tuple<int, int, int>> nodes)
        {
            if (node == null)
                return;
            nodes.Add(Tuple.Create(column, row, node.val));
            CollectVertical(node.left, row + 1, column - 1, nodes);
            CollectVertical(node.right, row + 1, column + 1, nodes);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/smallest-string-starting-from-leaf/">988. Smallest String Starting From Leaf (medium)</a>
        /// Searches every root-to-leaf path and compares leaf-to-root strings; runs in O(nh) time and O(h) space.
        /// </summary>
        /// <param name="root">The binary tree root with values 0 through 25.</param>
        /// <returns>The lexicographically smallest string from any leaf to the root.</returns>
        public string SmallestFromLeaf(TreeNode root)
        {
            string best = null;
            SmallestFromLeaf(root, string.Empty, ref best);
            return best ?? string.Empty;
        }

        private void SmallestFromLeaf(TreeNode node, string suffix, ref string best)
        {
            if (node == null)
                return;
            string current = (char)('a' + node.val) + suffix;
            if (node.left == null && node.right == null)
            {
                if (best == null || string.CompareOrdinal(current, best) < 0)
                    best = current;
                return;
            }

            SmallestFromLeaf(node.left, current, ref best);
            SmallestFromLeaf(node.right, current, ref best);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/cousins-in-binary-tree/">993. Cousins in Binary Tree (easy)</a>
        /// Finds depths and parents of two values to determine cousin status; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The binary tree root with unique values.</param>
        /// <param name="x">The first value.</param>
        /// <param name="y">The second value.</param>
        /// <returns><c>true</c> when both values have the same depth and different parents.</returns>
        public bool IsCousins(TreeNode root, int x, int y)
        {
            TreeNode parentX = null;
            TreeNode parentY = null;
            int depthX = -1;
            int depthY = -1;
            FindParentDepth(root, null, 0, x, ref parentX, ref depthX);
            FindParentDepth(root, null, 0, y, ref parentY, ref depthY);
            return depthX == depthY && parentX != parentY;
        }

        private void FindParentDepth(TreeNode node, TreeNode parent, int depth, int value, ref TreeNode foundParent, ref int foundDepth)
        {
            if (node == null || foundDepth != -1)
                return;
            if (node.val == value)
            {
                foundParent = parent;
                foundDepth = depth;
                return;
            }

            FindParentDepth(node.left, node, depth + 1, value, ref foundParent, ref foundDepth);
            FindParentDepth(node.right, node, depth + 1, value, ref foundParent, ref foundDepth);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-binary-tree-ii/">998. Maximum Binary Tree II (medium)</a>
        /// Inserts a value as if appended to the original array used for a maximum binary tree; runs in O(h) time and O(h) space.
        /// </summary>
        /// <param name="root">The current maximum binary tree root.</param>
        /// <param name="val">The appended value.</param>
        /// <returns>The updated maximum binary tree root.</returns>
        public TreeNode InsertIntoMaxTree(TreeNode root, int val)
        {
            if (root == null || val > root.val)
                return new TreeNode(val, root);
            root.right = InsertIntoMaxTree(root.right, val);
            return root;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/sum-of-root-to-leaf-binary-numbers/">1022. Sum of Root To Leaf Binary Numbers (easy)</a>
        /// Interprets every root-to-leaf path as a binary number and sums them; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The binary tree root with values 0 or 1.</param>
        /// <returns>The sum of all root-to-leaf binary values.</returns>
        public int SumRootToLeaf(TreeNode root)
        {
            return SumRootToLeaf(root, 0);
        }

        private int SumRootToLeaf(TreeNode node, int value)
        {
            if (node == null)
                return 0;
            value = (value << 1) | node.val;
            if (node.left == null && node.right == null)
                return value;
            return SumRootToLeaf(node.left, value) + SumRootToLeaf(node.right, value);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-difference-between-node-and-ancestor/">1026. Maximum Difference Between Node and Ancestor (medium)</a>
        /// Tracks minimum and maximum ancestor values along each path; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The binary tree root.</param>
        /// <returns>The maximum absolute difference between a node and one of its ancestors.</returns>
        public int MaxAncestorDiff(TreeNode root)
        {
            return root == null ? 0 : MaxAncestorDiff(root, root.val, root.val);
        }

        private int MaxAncestorDiff(TreeNode node, int minimum, int maximum)
        {
            if (node == null)
                return maximum - minimum;
            minimum = Math.Min(minimum, node.val);
            maximum = Math.Max(maximum, node.val);
            return Math.Max(MaxAncestorDiff(node.left, minimum, maximum), MaxAncestorDiff(node.right, minimum, maximum));
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/insufficient-nodes-in-root-to-leaf-paths/">1080. Insufficient Nodes in Root to Leaf Paths (medium)</a>
        /// Deletes nodes that are not part of any root-to-leaf path meeting a sum limit; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The binary tree root.</param>
        /// <param name="limit">The minimum allowed root-to-leaf path sum.</param>
        /// <returns>The root after removing insufficient nodes.</returns>
        public TreeNode SufficientSubset(TreeNode root, int limit)
        {
            return SufficientSubset(root, 0, limit);
        }

        private TreeNode SufficientSubset(TreeNode node, int sum, int limit)
        {
            if (node == null)
                return null;
            sum += node.val;
            if (node.left == null && node.right == null)
                return sum < limit ? null : node;
            node.left = SufficientSubset(node.left, sum, limit);
            node.right = SufficientSubset(node.right, sum, limit);
            return node.left == null && node.right == null ? null : node;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/path-in-zigzag-labelled-binary-tree/">1104. Path In Zigzag Labelled Binary Tree (medium)</a>
        /// Converts labels between normal and zigzag level numbering while climbing to the root; runs in O(log label) time and space.
        /// </summary>
        /// <param name="label">The target node label in the zigzag-labelled perfect binary tree.</param>
        /// <returns>The path labels from root to <paramref name="label"/>.</returns>
        public IList<int> PathInZigZagTree(int label)
        {
            var path = new List<int>();
            while (label >= 1)
            {
                path.Add(label);
                int level = 0;
                int value = label;
                while (value > 1)
                {
                    value >>= 1;
                    level++;
                }

                int start = 1 << level;
                int end = (1 << (level + 1)) - 1;
                label = (start + end - label) / 2;
            }

            path.Reverse();
            return path;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/delete-nodes-and-return-forest/">1110. Delete Nodes And Return Forest (medium)</a>
        /// Deletes requested values and returns the roots of the remaining forest; runs in O(n) time and O(n) space.
        /// </summary>
        /// <param name="root">The binary tree root.</param>
        /// <param name="to_delete">Values to delete.</param>
        /// <returns>The roots of all trees remaining after deletion.</returns>
        public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete)
        {
            var delete = new HashSet<int>(to_delete);
            var forest = new List<TreeNode>();
            DeleteNodes(root, true, delete, forest);
            return forest;
        }

        private TreeNode DeleteNodes(TreeNode node, bool isRoot, HashSet<int> delete, IList<TreeNode> forest)
        {
            if (node == null)
                return null;
            bool removed = delete.Contains(node.val);
            if (isRoot && !removed)
                forest.Add(node);
            node.left = DeleteNodes(node.left, removed, delete, forest);
            node.right = DeleteNodes(node.right, removed, delete, forest);
            return removed ? null : node;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/lowest-common-ancestor-of-deepest-leaves/">1123. Lowest Common Ancestor of Deepest Leaves (medium)</a>
        /// Returns the node whose subtree contains all deepest leaves; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The binary tree root.</param>
        /// <returns>The lowest common ancestor of the deepest leaves.</returns>
        public TreeNode LcaDeepestLeaves(TreeNode root)
        {
            return DeepestLeaves(root).Item2;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/smallest-subtree-with-all-the-deepest-nodes/">865. Smallest Subtree with all the Deepest Nodes (medium)</a>
        /// Finds the root of the smallest subtree containing every deepest node; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The binary tree root.</param>
        /// <returns>The root of the smallest subtree containing all deepest nodes.</returns>
        public TreeNode SubtreeWithAllDeepest(TreeNode root)
        {
            return DeepestLeaves(root).Item2;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/all-possible-full-binary-trees/">894. All Possible Full Binary Trees (medium)</a>
        /// Builds every full binary tree with n nodes using memoized recursion; runs in Catalan-sized output time and space.
        /// </summary>
        /// <param name="n">The odd number of nodes to use.</param>
        /// <returns>All structurally unique full binary tree roots with <paramref name="n"/> nodes.</returns>
        public IList<TreeNode> AllPossibleFBT(int n)
        {
            var memo = new Dictionary<int, IList<TreeNode>>();
            return AllPossibleFBT(n, memo);
        }

        private IList<TreeNode> AllPossibleFBT(int n, Dictionary<int, IList<TreeNode>> memo)
        {
            if (memo.ContainsKey(n))
                return memo[n];
            var result = new List<TreeNode>();
            if (n == 1)
                result.Add(new TreeNode(0));
            else if (n % 2 == 1)
            {
                for (int leftCount = 1; leftCount < n; leftCount += 2)
                {
                    int rightCount = n - 1 - leftCount;
                    foreach (TreeNode left in AllPossibleFBT(leftCount, memo))
                    {
                        foreach (TreeNode right in AllPossibleFBT(rightCount, memo))
                            result.Add(new TreeNode(0, left, right));
                    }
                }
            }

            memo[n] = result;
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/construct-binary-search-tree-from-preorder-traversal/">1008. Construct Binary Search Tree from Preorder Traversal (medium)</a>
        /// Consumes preorder values with an upper bound to build the BST in one pass; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="preorder">The preorder traversal of a BST.</param>
        /// <returns>The constructed binary search tree root.</returns>
        public TreeNode BstFromPreorder(int[] preorder)
        {
            int index = 0;
            return BstFromPreorder(preorder, ref index, long.MaxValue);
        }

        private TreeNode BstFromPreorder(int[] preorder, ref int index, long upperBound)
        {
            if (index == preorder.Length || preorder[index] > upperBound)
                return null;
            int value = preorder[index++];
            TreeNode root = new TreeNode(value);
            root.left = BstFromPreorder(preorder, ref index, value);
            root.right = BstFromPreorder(preorder, ref index, upperBound);
            return root;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/recover-a-tree-from-preorder-traversal/">1028. Recover a Tree From Preorder Traversal (hard)</a>
        /// Parses dash-prefixed depths and attaches each node to the current path stack; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="traversal">The preorder string with depth represented by dashes.</param>
        /// <returns>The recovered binary tree root.</returns>
        public TreeNode RecoverFromPreorder(string traversal)
        {
            var path = new List<TreeNode>();
            int index = 0;
            while (index < traversal.Length)
            {
                int depth = 0;
                while (index < traversal.Length && traversal[index] == '-')
                {
                    depth++;
                    index++;
                }

                int value = 0;
                while (index < traversal.Length && char.IsDigit(traversal[index]))
                    value = value * 10 + traversal[index++] - '0';

                TreeNode node = new TreeNode(value);
                if (depth == path.Count)
                    path.Add(node);
                else
                    path[depth] = node;

                if (depth > 0)
                {
                    TreeNode parent = path[depth - 1];
                    if (parent.left == null)
                        parent.left = node;
                    else
                        parent.right = node;
                }
            }

            return path.Count == 0 ? null : path[0];
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/binary-search-tree-to-greater-sum-tree/">1038. Binary Search Tree to Greater Sum Tree (medium)</a>
        /// Converts a BST so every node stores its value plus all greater values; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The binary search tree root.</param>
        /// <returns>The greater-sum tree root.</returns>
        public TreeNode BstToGst(TreeNode root)
        {
            return ConvertBST(root);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-product-of-splitted-binary-tree/">1339. Maximum Product of Splitted Binary Tree (medium)</a>
        /// Computes subtree sums and tests every split against the total sum; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The binary tree root.</param>
        /// <returns>The maximum split product modulo 1,000,000,007.</returns>
        public int MaxProduct(TreeNode root)
        {
            long total = TreeSum(root);
            long best = 0;
            MaxProduct(root, total, ref best);
            return (int)(best % 1000000007);
        }

        private long TreeSum(TreeNode node)
        {
            return node == null ? 0 : node.val + TreeSum(node.left) + TreeSum(node.right);
        }

        private long MaxProduct(TreeNode node, long total, ref long best)
        {
            if (node == null)
                return 0;
            long sum = node.val + MaxProduct(node.left, total, ref best) + MaxProduct(node.right, total, ref best);
            best = Math.Max(best, sum * (total - sum));
            return sum;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/validate-binary-tree-nodes/">1361. Validate Binary Tree Nodes (medium)</a>
        /// Validates that child arrays form exactly one rooted binary tree with no cycle; runs in O(n) time and O(n) space.
        /// </summary>
        /// <param name="n">The number of nodes labeled from 0 to n - 1.</param>
        /// <param name="leftChild">The left child index for every node, or -1.</param>
        /// <param name="rightChild">The right child index for every node, or -1.</param>
        /// <returns><c>true</c> when the arrays describe one valid binary tree.</returns>
        public bool ValidateBinaryTreeNodes(int n, int[] leftChild, int[] rightChild)
        {
            var indegree = new int[n];
            for (int i = 0; i < n; i++)
            {
                if (leftChild[i] != -1 && ++indegree[leftChild[i]] > 1)
                    return false;
                if (rightChild[i] != -1 && ++indegree[rightChild[i]] > 1)
                    return false;
            }

            int root = -1;
            for (int i = 0; i < n; i++)
            {
                if (indegree[i] == 0)
                {
                    if (root != -1)
                        return false;
                    root = i;
                }
            }

            if (root == -1)
                return false;

            var seen = new HashSet<int>();
            var queue = new Queue<int>();
            queue.Enqueue(root);
            seen.Add(root);
            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                if (!VisitChild(leftChild[node], seen, queue) || !VisitChild(rightChild[node], seen, queue))
                    return false;
            }

            return seen.Count == n;
        }

        private bool VisitChild(int child, HashSet<int> seen, Queue<int> queue)
        {
            if (child == -1)
                return true;
            if (!seen.Add(child))
                return false;
            queue.Enqueue(child);
            return true;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-root-of-n-ary-tree/">1506. Find Root of N-Ary Tree (medium)</a>
        /// Uses the difference between all node values and child values to identify the root; runs in O(n) time and O(1) extra space.
        /// </summary>
        /// <param name="tree">All nodes in the N-ary tree.</param>
        /// <returns>The root node of the N-ary tree.</returns>
        public Node FindRoot(IList<Node> tree)
        {
            int sum = 0;
            foreach (Node node in tree)
            {
                sum += node.val;
                foreach (Node child in node.children)
                    sum -= child.val;
            }

            foreach (Node node in tree)
            {
                if (node.val == sum)
                    return node;
            }

            return null;
        }

        private Tuple<int, TreeNode> DeepestLeaves(TreeNode node)
        {
            if (node == null)
                return Tuple.Create(0, (TreeNode)null);
            Tuple<int, TreeNode> left = DeepestLeaves(node.left);
            Tuple<int, TreeNode> right = DeepestLeaves(node.right);
            if (left.Item1 == right.Item1)
                return Tuple.Create(left.Item1 + 1, node);
            return left.Item1 > right.Item1 ? Tuple.Create(left.Item1 + 1, left.Item2) : Tuple.Create(right.Item1 + 1, right.Item2);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/binary-tree-coloring-game/">1145. Binary Tree Coloring Game (medium)</a>
        /// Computes the three regions around the first player's node to see if any contains a majority; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The binary tree root.</param>
        /// <param name="n">The total number of nodes.</param>
        /// <param name="x">The value selected by the first player.</param>
        /// <returns><c>true</c> if the second player can choose a winning node.</returns>
        public bool BtreeGameWinningMove(TreeNode root, int n, int x)
        {
            int left = 0;
            int right = 0;
            CountForColoring(root, x, ref left, ref right);
            int parentSide = n - left - right - 1;
            int half = n / 2;
            return left > half || right > half || parentSide > half;
        }

        private int CountForColoring(TreeNode node, int x, ref int leftOfX, ref int rightOfX)
        {
            if (node == null)
                return 0;
            int left = CountForColoring(node.left, x, ref leftOfX, ref rightOfX);
            int right = CountForColoring(node.right, x, ref leftOfX, ref rightOfX);
            if (node.val == x)
            {
                leftOfX = left;
                rightOfX = right;
            }

            return left + right + 1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-level-sum-of-a-binary-tree/">1161. Maximum Level Sum of a Binary Tree (medium)</a>
        /// Performs breadth-first search and returns the smallest level with the largest sum; runs in O(n) time and O(w) space.
        /// </summary>
        /// <param name="root">The binary tree root.</param>
        /// <returns>The one-based level number with the maximum sum.</returns>
        public int MaxLevelSum(TreeNode root)
        {
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int level = 1;
            int bestLevel = 1;
            int bestSum = int.MinValue;
            while (queue.Count > 0)
            {
                int count = queue.Count;
                int sum = 0;
                for (int i = 0; i < count; i++)
                {
                    TreeNode node = queue.Dequeue();
                    sum += node.val;
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }

                if (sum > bestSum)
                {
                    bestSum = sum;
                    bestLevel = level;
                }

                level++;
            }

            return bestLevel;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/deepest-leaves-sum/">1302. Deepest Leaves Sum (medium)</a>
        /// Sums the final breadth-first level of a binary tree; runs in O(n) time and O(w) space.
        /// </summary>
        /// <param name="root">The binary tree root.</param>
        /// <returns>The sum of all deepest leaf values.</returns>
        public int DeepestLeavesSum(TreeNode root)
        {
            var queue = new Queue<TreeNode>();
            if (root != null)
                queue.Enqueue(root);
            int sum = 0;
            while (queue.Count > 0)
            {
                int count = queue.Count;
                sum = 0;
                for (int i = 0; i < count; i++)
                {
                    TreeNode node = queue.Dequeue();
                    sum += node.val;
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }
            }

            return sum;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/all-elements-in-two-binary-search-trees/">1305. All Elements in Two Binary Search Trees (medium)</a>
        /// Merges the inorder traversals of two BSTs; runs in O(n + m) time and O(n + m) space.
        /// </summary>
        /// <param name="root1">The first binary search tree root.</param>
        /// <param name="root2">The second binary search tree root.</param>
        /// <returns>All values from both trees in sorted order.</returns>
        public IList<int> GetAllElements(TreeNode root1, TreeNode root2)
        {
            var first = new List<int>();
            var second = new List<int>();
            InorderTraversal(root1, ref first);
            InorderTraversal(root2, ref second);
            var result = new List<int>(first.Count + second.Count);
            int i = 0;
            int j = 0;
            while (i < first.Count || j < second.Count)
            {
                if (j == second.Count || i < first.Count && first[i] <= second[j])
                    result.Add(first[i++]);
                else
                    result.Add(second[j++]);
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/sum-of-nodes-with-even-valued-grandparent/">1315. Sum of Nodes with Even-Valued Grandparent (medium)</a>
        /// Carries parent and grandparent values through DFS and sums qualifying nodes; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The binary tree root.</param>
        /// <returns>The sum of values whose grandparent has an even value.</returns>
        public int SumEvenGrandparent(TreeNode root)
        {
            return SumEvenGrandparent(root, null, null);
        }

        private int SumEvenGrandparent(TreeNode node, TreeNode parent, TreeNode grandparent)
        {
            if (node == null)
                return 0;
            int sum = grandparent != null && grandparent.val % 2 == 0 ? node.val : 0;
            return sum + SumEvenGrandparent(node.left, node, parent) + SumEvenGrandparent(node.right, node, parent);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/delete-leaves-with-a-given-value/">1325. Delete Leaves With a Given Value (medium)</a>
        /// Repeatedly removes target-valued leaves using postorder traversal; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The binary tree root.</param>
        /// <param name="target">The leaf value to remove.</param>
        /// <returns>The root after all possible target leaves are deleted.</returns>
        public TreeNode RemoveLeafNodes(TreeNode root, int target)
        {
            if (root == null)
                return null;
            root.left = RemoveLeafNodes(root.left, target);
            root.right = RemoveLeafNodes(root.right, target);
            return root.val == target && root.left == null && root.right == null ? null : root;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/linked-list-in-binary-tree/">1367. Linked List in Binary Tree (medium)</a>
        /// Checks whether a linked list appears as a downward path from any tree node; runs in O(nm) time and O(h + m) space.
        /// </summary>
        /// <param name="head">The linked-list head.</param>
        /// <param name="root">The binary tree root.</param>
        /// <returns><c>true</c> when the list is a downward path in the tree.</returns>
        public bool IsSubPath(ListNode head, TreeNode root)
        {
            if (head == null)
                return true;
            if (root == null)
                return false;
            return MatchesSubPath(head, root) || IsSubPath(head, root.left) || IsSubPath(head, root.right);
        }

        private bool MatchesSubPath(ListNode head, TreeNode node)
        {
            if (head == null)
                return true;
            if (node == null || node.val != head.val)
                return false;
            return MatchesSubPath(head.next, node.left) || MatchesSubPath(head.next, node.right);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/longest-zigzag-path-in-a-binary-tree/">1372. Longest ZigZag Path in a Binary Tree (medium)</a>
        /// Tracks alternating left/right edge lengths from every node; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The binary tree root.</param>
        /// <returns>The maximum ZigZag path length in edges.</returns>
        public int LongestZigZag(TreeNode root)
        {
            int best = 0;
            LongestZigZag(root, 0, 0, ref best);
            return best;
        }

        private void LongestZigZag(TreeNode node, int leftLength, int rightLength, ref int best)
        {
            if (node == null)
                return;
            best = Math.Max(best, Math.Max(leftLength, rightLength));
            LongestZigZag(node.left, rightLength + 1, 0, ref best);
            LongestZigZag(node.right, 0, leftLength + 1, ref best);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-sum-bst-in-binary-tree/">1373. Maximum Sum BST in Binary Tree (hard)</a>
        /// Computes BST validity, bounds, and sums for every subtree in one postorder pass; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The binary tree root.</param>
        /// <returns>The maximum sum among all BST subtrees, or 0 when all sums are negative.</returns>
        public int MaxSumBST(TreeNode root)
        {
            int best = 0;
            MaxSumBSTInfo(root, ref best);
            return best;
        }

        private Tuple<bool, int, int, int> MaxSumBSTInfo(TreeNode node, ref int best)
        {
            if (node == null)
                return Tuple.Create(true, int.MaxValue, int.MinValue, 0);
            Tuple<bool, int, int, int> left = MaxSumBSTInfo(node.left, ref best);
            Tuple<bool, int, int, int> right = MaxSumBSTInfo(node.right, ref best);
            if (left.Item1 && right.Item1 && node.val > left.Item3 && node.val < right.Item2)
            {
                int sum = node.val + left.Item4 + right.Item4;
                best = Math.Max(best, sum);
                return Tuple.Create(true, Math.Min(node.val, left.Item2), Math.Max(node.val, right.Item3), sum);
            }

            return Tuple.Create(false, int.MinValue, int.MaxValue, 0);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-a-corresponding-node-of-a-binary-tree-in-a-clone-of-that-tree/">1379. Find a Corresponding Node of a Binary Tree in a Clone of That Tree (easy)</a>
        /// Traverses original and cloned trees together to locate the cloned counterpart of a target; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="original">The original binary tree root.</param>
        /// <param name="cloned">The cloned binary tree root.</param>
        /// <param name="target">A node reference from the original tree.</param>
        /// <returns>The corresponding node reference in the cloned tree.</returns>
        public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target)
        {
            if (original == null)
                return null;
            if (original == target)
                return cloned;
            TreeNode left = GetTargetCopy(original.left, cloned.left, target);
            return left ?? GetTargetCopy(original.right, cloned.right, target);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/balance-a-binary-search-tree/">1382. Balance a Binary Search Tree (medium)</a>
        /// Rebuilds a height-balanced BST from its inorder values; runs in O(n) time and O(n) space.
        /// </summary>
        /// <param name="root">The binary search tree root.</param>
        /// <returns>A balanced BST containing the same values.</returns>
        public TreeNode BalanceBST(TreeNode root)
        {
            var values = new List<int>();
            InorderTraversal(root, ref values);
            return BuildBalancedBST(values, 0, values.Count - 1);
        }

        private TreeNode BuildBalancedBST(IList<int> values, int left, int right)
        {
            if (left > right)
                return null;
            int middle = left + (right - left) / 2;
            return new TreeNode(values[middle], BuildBalancedBST(values, left, middle - 1), BuildBalancedBST(values, middle + 1, right));
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-good-nodes-in-binary-tree/">1448. Count Good Nodes in Binary Tree (medium)</a>
        /// Counts nodes that are not smaller than any previous value on their root path; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The binary tree root.</param>
        /// <returns>The number of good nodes.</returns>
        public int GoodNodes(TreeNode root)
        {
            return GoodNodes(root, int.MinValue);
        }

        private int GoodNodes(TreeNode node, int maximum)
        {
            if (node == null)
                return 0;
            int count = node.val >= maximum ? 1 : 0;
            maximum = Math.Max(maximum, node.val);
            return count + GoodNodes(node.left, maximum) + GoodNodes(node.right, maximum);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/pseudo-palindromic-paths-in-a-binary-tree/">1457. Pseudo-Palindromic Paths in a Binary Tree (medium)</a>
        /// Toggles digit parity along root-to-leaf paths and accepts paths with at most one odd count; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The binary tree root with values 1 through 9.</param>
        /// <returns>The number of pseudo-palindromic root-to-leaf paths.</returns>
        public int PseudoPalindromicPaths(TreeNode root)
        {
            return PseudoPalindromicPaths(root, 0);
        }

        private int PseudoPalindromicPaths(TreeNode node, int mask)
        {
            if (node == null)
                return 0;
            mask ^= 1 << node.val;
            if (node.left == null && node.right == null)
                return (mask & (mask - 1)) == 0 ? 1 : 0;
            return PseudoPalindromicPaths(node.left, mask) + PseudoPalindromicPaths(node.right, mask);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/number-of-good-leaf-nodes-pairs/">1530. Number of Good Leaf Nodes Pairs (medium)</a>
        /// Counts leaf pairs whose connecting path length is within the limit using subtree distance counts; runs in O(n*d²) time and O(h*d) space.
        /// </summary>
        /// <param name="root">The binary tree root.</param>
        /// <param name="distance">The maximum allowed distance between two leaves.</param>
        /// <returns>The number of good leaf-node pairs.</returns>
        public int CountPairs(TreeNode root, int distance)
        {
            int pairs = 0;
            CountPairsDistances(root, distance, ref pairs);
            return pairs;
        }

        private int[] CountPairsDistances(TreeNode node, int distance, ref int pairs)
        {
            var counts = new int[distance + 1];
            if (node == null)
                return counts;
            if (node.left == null && node.right == null)
            {
                counts[1] = 1;
                return counts;
            }

            int[] left = CountPairsDistances(node.left, distance, ref pairs);
            int[] right = CountPairsDistances(node.right, distance, ref pairs);
            for (int i = 1; i <= distance; i++)
            {
                for (int j = 1; j <= distance; j++)
                {
                    if (i + j <= distance)
                        pairs += left[i] * right[j];
                }
            }

            for (int i = 1; i < distance; i++)
                counts[i + 1] = left[i] + right[i];
            return counts;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/even-odd-tree/">1609. Even Odd Tree (medium)</a>
        /// Checks each level for required value parity and strict monotonic ordering; runs in O(n) time and O(w) space.
        /// </summary>
        /// <param name="root">The binary tree root.</param>
        /// <returns><c>true</c> when every level satisfies the even-odd tree rules.</returns>
        public bool IsEvenOddTree(TreeNode root)
        {
            var queue = new Queue<TreeNode>();
            if (root != null)
                queue.Enqueue(root);
            int level = 0;
            while (queue.Count > 0)
            {
                int count = queue.Count;
                int previous = level % 2 == 0 ? int.MinValue : int.MaxValue;
                for (int i = 0; i < count; i++)
                {
                    TreeNode node = queue.Dequeue();
                    if (level % 2 == 0)
                    {
                        if (node.val % 2 == 0 || node.val <= previous)
                            return false;
                    }
                    else if (node.val % 2 != 0 || node.val >= previous)
                        return false;

                    previous = node.val;
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }

                level++;
            }

            return true;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/merge-bsts-to-create-single-bst/">1932. Merge BSTs to Create Single BST (hard)</a>
        /// Merges leaf-matching BST roots into one valid BST using root lookup and min/max validation; runs in O(n) time and O(n) space.
        /// </summary>
        /// <param name="trees">The candidate BST roots whose root values may replace matching leaves.</param>
        /// <returns>The merged BST root, or <c>null</c> when no valid single BST can be formed.</returns>
        public TreeNode CanMerge(IList<TreeNode> trees)
        {
            var roots = new Dictionary<int, TreeNode>();
            var leafValues = new HashSet<int>();
            foreach (TreeNode tree in trees)
            {
                roots[tree.val] = tree;
                if (tree.left != null)
                    leafValues.Add(tree.left.val);
                if (tree.right != null)
                    leafValues.Add(tree.right.val);
            }

            TreeNode root = null;
            foreach (TreeNode tree in trees)
            {
                if (!leafValues.Contains(tree.val))
                {
                    if (root != null)
                        return null;
                    root = tree;
                }
            }

            if (root == null)
                return null;

            roots.Remove(root.val);
            return CanMergeValidate(root, long.MinValue, long.MaxValue, roots) && roots.Count == 0 ? root : null;
        }

        private bool CanMergeValidate(TreeNode node, long min, long max, Dictionary<int, TreeNode> roots)
        {
            if (node == null)
                return true;
            if (node.val <= min || node.val >= max)
                return false;

            if (node.left == null && node.right == null && roots.TryGetValue(node.val, out TreeNode graft))
            {
                node.left = graft.left;
                node.right = graft.right;
                roots.Remove(node.val);
            }

            return CanMergeValidate(node.left, min, node.val, roots) && CanMergeValidate(node.right, node.val, max, roots);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-nodes-with-the-highest-score/">2049. Count Nodes With the Highest Score (medium)</a>
        /// Computes each removal score from subtree sizes in one DFS over the parent-defined tree; runs in O(n) time and O(n) space.
        /// </summary>
        /// <param name="parents">The parent of each node, with node 0 as the root.</param>
        /// <returns>The number of nodes whose score is the maximum score.</returns>
        public int CountHighestScoreNodes(int[] parents)
        {
            int n = parents.Length;
            var children = new List<int>[n];
            for (int i = 0; i < n; i++)
                children[i] = new List<int>();
            for (int i = 1; i < n; i++)
                children[parents[i]].Add(i);

            long best = 0;
            int count = 0;
            CountHighestScoreDfs(0, n, children, ref best, ref count);
            return count;
        }

        private int CountHighestScoreDfs(int node, int n, List<int>[] children, ref long best, ref int count)
        {
            long score = 1;
            int size = 1;
            foreach (int child in children[node])
            {
                int childSize = CountHighestScoreDfs(child, n, children, ref best, ref count);
                size += childSize;
                score *= childSize;
            }

            int remaining = n - size;
            if (remaining > 0)
                score *= remaining;
            if (score > best)
            {
                best = score;
                count = 1;
            }
            else if (score == best)
                count++;
            return size;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/step-by-step-directions-from-a-binary-tree-node-to-another/">2096. Step-By-Step Directions From a Binary Tree Node to Another (medium)</a>
        /// Builds root-to-node paths, removes their common prefix, then combines upward and downward directions; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The binary tree root with unique values.</param>
        /// <param name="startValue">The value of the starting node.</param>
        /// <param name="destValue">The value of the destination node.</param>
        /// <returns>A string of <c>U</c>, <c>L</c>, and <c>R</c> moves from start to destination.</returns>
        public string GetDirections(TreeNode root, int startValue, int destValue)
        {
            var start = new StringBuilder();
            var dest = new StringBuilder();
            GetDirectionsPath(root, startValue, start);
            GetDirectionsPath(root, destValue, dest);

            int common = 0;
            while (common < start.Length && common < dest.Length && start[common] == dest[common])
                common++;

            var result = new StringBuilder();
            for (int i = common; i < start.Length; i++)
                result.Append('U');
            for (int i = common; i < dest.Length; i++)
                result.Append(dest[i]);
            return result.ToString();
        }

        private bool GetDirectionsPath(TreeNode node, int value, StringBuilder path)
        {
            if (node == null)
                return false;
            if (node.val == value)
                return true;

            path.Append('L');
            if (GetDirectionsPath(node.left, value, path))
                return true;
            path[path.Length - 1] = 'R';
            if (GetDirectionsPath(node.right, value, path))
                return true;
            path.Length--;
            return false;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/longest-path-with-different-adjacent-characters/">2246. Longest Path With Different Adjacent Characters (hard)</a>
        /// Finds the two best extendable child chains with characters different from each parent; runs in O(n) time and O(n) space.
        /// </summary>
        /// <param name="parent">The parent array for a rooted tree.</param>
        /// <param name="s">The node labels.</param>
        /// <returns>The maximum number of nodes on a path whose adjacent labels differ.</returns>
        public int LongestPath(int[] parent, string s)
        {
            int n = parent.Length;
            var children = new List<int>[n];
            for (int i = 0; i < n; i++)
                children[i] = new List<int>();
            for (int i = 1; i < n; i++)
                children[parent[i]].Add(i);

            int best = 1;
            LongestPathDfs(0, children, s, ref best);
            return best;
        }

        private int LongestPathDfs(int node, List<int>[] children, string s, ref int best)
        {
            int first = 0;
            int second = 0;
            foreach (int child in children[node])
            {
                int length = LongestPathDfs(child, children, s, ref best);
                if (s[child] == s[node])
                    continue;
                if (length > first)
                {
                    second = first;
                    first = length;
                }
                else if (length > second)
                    second = length;
            }

            best = Math.Max(best, first + second + 1);
            return first + 1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/create-binary-tree-from-descriptions/">2196. Create Binary Tree From Descriptions (medium)</a>
        /// Links described parent-child relationships and chooses the node never seen as a child as root; runs in O(n) time and O(n) space.
        /// </summary>
        /// <param name="descriptions">Rows of parent value, child value, and 1 for left child or 0 for right child.</param>
        /// <returns>The root of the created binary tree.</returns>
        public TreeNode CreateBinaryTree(int[][] descriptions)
        {
            var nodes = new Dictionary<int, TreeNode>();
            var children = new HashSet<int>();
            foreach (int[] description in descriptions)
            {
                int parentValue = description[0];
                int childValue = description[1];
                if (!nodes.TryGetValue(parentValue, out TreeNode parent))
                {
                    parent = new TreeNode(parentValue);
                    nodes[parentValue] = parent;
                }
                if (!nodes.TryGetValue(childValue, out TreeNode child))
                {
                    child = new TreeNode(childValue);
                    nodes[childValue] = child;
                }

                if (description[2] == 1)
                    parent.left = child;
                else
                    parent.right = child;
                children.Add(childValue);
            }

            foreach (int value in nodes.Keys)
            {
                if (!children.Contains(value))
                    return nodes[value];
            }

            return null;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/root-equals-sum-of-children/">2236. Root Equals Sum of Children (easy)</a>
        /// Checks the fixed three-node tree condition directly in O(1) time and space.
        /// </summary>
        /// <param name="root">The root whose two children are present.</param>
        /// <returns><c>true</c> if the root value equals the sum of its children.</returns>
        public bool CheckTree(TreeNode root)
        {
            return root.val == root.left.val + root.right.val;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-nodes-equal-to-average-of-subtree/">2265. Count Nodes Equal to Average of Subtree (medium)</a>
        /// Computes subtree sums and sizes with postorder traversal; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The binary tree root.</param>
        /// <returns>The number of nodes equal to the integer average of their subtree.</returns>
        public int AverageOfSubtree(TreeNode root)
        {
            int count = 0;
            AverageOfSubtreeDfs(root, ref count);
            return count;
        }

        private (int Sum, int Size) AverageOfSubtreeDfs(TreeNode node, ref int count)
        {
            if (node == null)
                return (0, 0);

            (int leftSum, int leftSize) = AverageOfSubtreeDfs(node.left, ref count);
            (int rightSum, int rightSize) = AverageOfSubtreeDfs(node.right, ref count);
            int sum = node.val + leftSum + rightSum;
            int size = 1 + leftSize + rightSize;
            if (node.val == sum / size)
                count++;
            return (sum, size);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/evaluate-boolean-binary-tree/">2331. Evaluate Boolean Binary Tree (easy)</a>
        /// Recursively evaluates leaves 0/1 and internal OR/AND operators 2/3; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The boolean expression tree root.</param>
        /// <returns>The evaluated boolean value.</returns>
        public bool EvaluateTree(TreeNode root)
        {
            if (root.left == null && root.right == null)
                return root.val == 1;
            return root.val == 2 ? EvaluateTree(root.left) || EvaluateTree(root.right) : EvaluateTree(root.left) && EvaluateTree(root.right);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/amount-of-time-for-binary-tree-to-be-infected/">2385. Amount of Time for Binary Tree to Be Infected (medium)</a>
        /// Treats the tree as an undirected graph and breadth-first spreads infection from the start value; runs in O(n) time and O(n) space.
        /// </summary>
        /// <param name="root">The binary tree root with unique values.</param>
        /// <param name="start">The initially infected node value.</param>
        /// <returns>The number of minutes needed to infect every node.</returns>
        public int AmountOfTime(TreeNode root, int start)
        {
            var graph = new Dictionary<int, List<int>>();
            AmountOfTimeBuildGraph(root, null, graph);
            var seen = new HashSet<int> { start };
            var queue = new Queue<int>();
            queue.Enqueue(start);
            int minutes = -1;
            while (queue.Count > 0)
            {
                int count = queue.Count;
                minutes++;
                for (int i = 0; i < count; i++)
                {
                    int node = queue.Dequeue();
                    foreach (int next in graph[node])
                    {
                        if (seen.Add(next))
                            queue.Enqueue(next);
                    }
                }
            }

            return Math.Max(0, minutes);
        }

        private void AmountOfTimeBuildGraph(TreeNode node, TreeNode parent, Dictionary<int, List<int>> graph)
        {
            if (node == null)
                return;
            if (!graph.ContainsKey(node.val))
                graph[node.val] = new List<int>();
            if (parent != null)
            {
                graph[node.val].Add(parent.val);
                graph[parent.val].Add(node.val);
            }

            AmountOfTimeBuildGraph(node.left, node, graph);
            AmountOfTimeBuildGraph(node.right, node, graph);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/reverse-odd-levels-of-binary-tree/">2415. Reverse Odd Levels of Binary Tree (medium)</a>
        /// Swaps mirrored node values on odd depths in the perfect binary tree; runs in O(n) time and O(h) space.
        /// </summary>
        /// <param name="root">The perfect binary tree root.</param>
        /// <returns>The same root after odd levels are reversed.</returns>
        public TreeNode ReverseOddLevels(TreeNode root)
        {
            ReverseOddLevels(root.left, root.right, 1);
            return root;
        }

        private void ReverseOddLevels(TreeNode left, TreeNode right, int level)
        {
            if (left == null || right == null)
                return;
            if (level % 2 == 1)
            {
                int value = left.val;
                left.val = right.val;
                right.val = value;
            }

            ReverseOddLevels(left.left, right.right, level + 1);
            ReverseOddLevels(left.right, right.left, level + 1);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/height-of-binary-tree-after-subtree-removal-queries/">2458. Height of Binary Tree After Subtree Removal Queries (hard)</a>
        /// Reroots subtree heights to answer each removal query in O(1) after O(n) preprocessing time and O(n) space.
        /// </summary>
        /// <param name="root">The binary tree root with unique values from 1 to n.</param>
        /// <param name="queries">Root values of subtrees to remove independently.</param>
        /// <returns>The remaining tree height in edges for each query.</returns>
        public int[] TreeQueries(TreeNode root, int[] queries)
        {
            var heights = new Dictionary<int, int>();
            TreeQueriesHeight(root, heights);
            var answers = new Dictionary<int, int>();
            TreeQueriesAnswers(root, 0, 0, heights, answers);

            var result = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
                result[i] = answers[queries[i]];
            return result;
        }

        private int TreeQueriesHeight(TreeNode node, Dictionary<int, int> heights)
        {
            if (node == null)
                return -1;
            int height = 1 + Math.Max(TreeQueriesHeight(node.left, heights), TreeQueriesHeight(node.right, heights));
            heights[node.val] = height;
            return height;
        }

        private void TreeQueriesAnswers(TreeNode node, int depth, int bestWithoutSubtree, Dictionary<int, int> heights, Dictionary<int, int> answers)
        {
            if (node == null)
                return;

            answers[node.val] = bestWithoutSubtree;
            int leftAlternative = Math.Max(bestWithoutSubtree, depth + 1 + (node.right == null ? -1 : heights[node.right.val]));
            int rightAlternative = Math.Max(bestWithoutSubtree, depth + 1 + (node.left == null ? -1 : heights[node.left.val]));
            TreeQueriesAnswers(node.left, depth + 1, leftAlternative, heights, answers);
            TreeQueriesAnswers(node.right, depth + 1, rightAlternative, heights, answers);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-number-of-operations-to-sort-a-binary-tree-by-level/">2471. Minimum Number of Operations to Sort a Binary Tree by Level (medium)</a>
        /// Sums cycle-swap counts needed to sort each level independently; runs in O(n log w) time and O(w) space.
        /// </summary>
        /// <param name="root">The binary tree root with distinct values.</param>
        /// <returns>The minimum number of value swaps between same-level nodes.</returns>
        public int MinimumOperations(TreeNode root)
        {
            int operations = 0;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int count = queue.Count;
                var values = new int[count];
                for (int i = 0; i < count; i++)
                {
                    TreeNode node = queue.Dequeue();
                    values[i] = node.val;
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }

                operations += MinimumOperationsToSort(values);
            }

            return operations;
        }

        private int MinimumOperationsToSort(int[] values)
        {
            int n = values.Length;
            var pairs = new (int Value, int Index)[n];
            for (int i = 0; i < n; i++)
                pairs[i] = (values[i], i);
            Array.Sort(pairs, (a, b) => a.Value.CompareTo(b.Value));

            var visited = new bool[n];
            int swaps = 0;
            for (int i = 0; i < n; i++)
            {
                if (visited[i] || pairs[i].Index == i)
                    continue;
                int cycle = 0;
                int current = i;
                while (!visited[current])
                {
                    visited[current] = true;
                    current = pairs[current].Index;
                    cycle++;
                }

                swaps += cycle - 1;
            }

            return swaps;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/closest-nodes-queries-in-a-binary-search-tree/">2476. Closest Nodes Queries in a Binary Search Tree (medium)</a>
        /// Uses inorder BST values plus binary search per query; runs in O(n + q log n) time and O(n) space.
        /// </summary>
        /// <param name="root">The binary search tree root.</param>
        /// <param name="queries">The queried target values.</param>
        /// <returns>For each query, the greatest value not larger and smallest value not smaller, or -1 when absent.</returns>
        public IList<IList<int>> ClosestNodes(TreeNode root, IList<int> queries)
        {
            var values = new List<int>();
            ClosestNodesInorder(root, values);
            var result = new List<IList<int>>();
            foreach (int query in queries)
            {
                int index = ClosestNodesLowerBound(values, query);
                int lower = index < values.Count && values[index] == query ? values[index] : (index > 0 ? values[index - 1] : -1);
                int upper = index < values.Count ? values[index] : -1;
                result.Add(new List<int> { lower, upper });
            }

            return result;
        }

        private void ClosestNodesInorder(TreeNode node, List<int> values)
        {
            if (node == null)
                return;
            ClosestNodesInorder(node.left, values);
            values.Add(node.val);
            ClosestNodesInorder(node.right, values);
        }

        private int ClosestNodesLowerBound(List<int> values, int target)
        {
            int left = 0;
            int right = values.Count;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (values[mid] < target)
                    left = mid + 1;
                else
                    right = mid;
            }

            return left;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/cycle-length-queries-in-a-tree/">2509. Cycle Length Queries in a Tree (hard)</a>
        /// Climbs labels in the infinite complete binary tree until both endpoints meet; runs in O(q log n) time and O(1) extra space.
        /// </summary>
        /// <param name="n">The conceptual tree height parameter from LeetCode; labels in queries determine the work.</param>
        /// <param name="queries">Pairs of labels whose added edge forms a cycle.</param>
        /// <returns>The cycle length for each query.</returns>
        public int[] CycleLengthQueries(int n, int[][] queries)
        {
            var result = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                int a = queries[i][0];
                int b = queries[i][1];
                int length = 1;
                while (a != b)
                {
                    if (a > b)
                        a /= 2;
                    else
                        b /= 2;
                    length++;
                }

                result[i] = length;
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/kth-largest-sum-in-a-binary-tree/">2583. Kth Largest Sum in a Binary Tree (medium)</a>
        /// Collects each level sum by BFS and sorts sums descending; runs in O(n + l log l) time and O(w + l) space.
        /// </summary>
        /// <param name="root">The binary tree root.</param>
        /// <param name="k">The 1-based rank of the desired level sum.</param>
        /// <returns>The k-th largest level sum, or -1 when fewer than k levels exist.</returns>
        public long KthLargestLevelSum(TreeNode root, int k)
        {
            var sums = new List<long>();
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int count = queue.Count;
                long sum = 0;
                for (int i = 0; i < count; i++)
                {
                    TreeNode node = queue.Dequeue();
                    sum += node.val;
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }

                sums.Add(sum);
            }

            if (sums.Count < k)
                return -1;
            sums.Sort((a, b) => b.CompareTo(a));
            return sums[k - 1];
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/cousins-in-binary-tree-ii/">2641. Cousins in Binary Tree II (medium)</a>
        /// Replaces each child value with the next level total minus its sibling group sum; runs in O(n) time and O(w) space.
        /// </summary>
        /// <param name="root">The binary tree root.</param>
        /// <returns>The same root after values are replaced by cousin sums.</returns>
        public TreeNode ReplaceValueInTree(TreeNode root)
        {
            root.val = 0;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int count = queue.Count;
                int nextLevelSum = 0;
                var parents = new TreeNode[count];
                for (int i = 0; i < count; i++)
                {
                    TreeNode node = queue.Dequeue();
                    parents[i] = node;
                    if (node.left != null)
                        nextLevelSum += node.left.val;
                    if (node.right != null)
                        nextLevelSum += node.right.val;
                }

                for (int i = 0; i < count; i++)
                {
                    int siblingSum = 0;
                    if (parents[i].left != null)
                        siblingSum += parents[i].left.val;
                    if (parents[i].right != null)
                        siblingSum += parents[i].right.val;
                    if (parents[i].left != null)
                    {
                        parents[i].left.val = nextLevelSum - siblingSum;
                        queue.Enqueue(parents[i].left);
                    }
                    if (parents[i].right != null)
                    {
                        parents[i].right.val = nextLevelSum - siblingSum;
                        queue.Enqueue(parents[i].right);
                    }
                }
            }

            return root;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/make-costs-of-paths-equal-in-a-binary-tree/">2673. Make Costs of Paths Equal in a Binary Tree (medium)</a>
        /// Balances sibling subtree path costs bottom-up in the complete binary tree array; runs in O(n) time and O(1) extra space.
        /// </summary>
        /// <param name="n">The number of nodes in the complete binary tree.</param>
        /// <param name="cost">The 0-indexed node costs by heap order; updated internally with accumulated path costs.</param>
        /// <returns>The minimum total increments needed to make all root-to-leaf path costs equal.</returns>
        public int MinIncrements(int n, int[] cost)
        {
            int increments = 0;
            for (int i = n / 2; i >= 1; i--)
            {
                int left = cost[(2 * i) - 1];
                int right = cost[2 * i];
                increments += Math.Abs(left - right);
                cost[i - 1] += Math.Max(left, right);
            }

            return increments;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-paths-that-can-form-a-palindrome-in-a-tree/">2791. Count Paths That Can Form a Palindrome in a Tree (hard)</a>
        /// Counts unordered node pairs whose path letters can be permuted into a palindrome by tracking parity masks from the root; runs in O(n * 26) time and O(n) space.
        /// </summary>
        /// <param name="parent">The parent array of the rooted tree, with parent[0] = -1.</param>
        /// <param name="s">The character assigned to each node; edge (parent[i], i) uses s[i].</param>
        /// <returns>The number of valid paths.</returns>
        public long CountPalindromePaths(IList<int> parent, string s)
        {
            int n = parent.Count;
            var children = new List<int>[n];
            for (int i = 0; i < n; i++)
                children[i] = new List<int>();
            for (int i = 1; i < n; i++)
                children[parent[i]].Add(i);

            long paths = 0;
            var counts = new Dictionary<int, long> { [0] = 1 };
            var stack = new Stack<(int Node, int Mask)>();
            stack.Push((0, 0));
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                foreach (int child in children[current.Node])
                {
                    int mask = current.Mask ^ (1 << (s[child] - 'a'));
                    if (counts.TryGetValue(mask, out long sameMask))
                        paths += sameMask;
                    for (int bit = 0; bit < 26; bit++)
                    {
                        if (counts.TryGetValue(mask ^ (1 << bit), out long oneDifferent))
                            paths += oneDifferent;
                    }

                    counts.TryGetValue(mask, out long count);
                    counts[mask] = count + 1;
                    stack.Push((child, mask));
                }
            }

            return paths;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-edge-weight-equilibrium-queries-in-a-tree/">2846. Minimum Edge Weight Equilibrium Queries in a Tree (hard)</a>
        /// Uses binary lifting and root-to-node edge-weight frequencies so each query returns path length minus the most frequent edge weight in O(log n + 26) time after O(n log n) preprocessing.
        /// </summary>
        /// <param name="n">The number of tree nodes labeled 0 through n - 1.</param>
        /// <param name="edges">Undirected weighted edges [u, v, w] where 1 &lt;= w &lt;= 26.</param>
        /// <param name="queries">Node pairs whose path should be balanced to one edge weight.</param>
        /// <returns>The minimum operations required for every query.</returns>
        public int[] MinOperationsQueries(int n, int[][] edges, int[][] queries)
        {
            var graph = new List<(int To, int Weight)>[n];
            for (int i = 0; i < n; i++)
                graph[i] = new List<(int To, int Weight)>();
            foreach (int[] edge in edges)
            {
                graph[edge[0]].Add((edge[1], edge[2]));
                graph[edge[1]].Add((edge[0], edge[2]));
            }

            int levels = 1;
            while ((1 << levels) <= n)
                levels++;
            var up = new int[n, levels];
            var depth = new int[n];
            var frequencies = new int[n, 27];
            for (int i = 0; i < n; i++)
                for (int level = 0; level < levels; level++)
                    up[i, level] = -1;

            var stack = new Stack<int>();
            stack.Push(0);
            up[0, 0] = -1;
            while (stack.Count > 0)
            {
                int node = stack.Pop();
                for (int level = 1; level < levels; level++)
                {
                    int middle = up[node, level - 1];
                    up[node, level] = middle == -1 ? -1 : up[middle, level - 1];
                }

                foreach (var edge in graph[node])
                {
                    if (edge.To == up[node, 0])
                        continue;
                    up[edge.To, 0] = node;
                    depth[edge.To] = depth[node] + 1;
                    for (int weight = 1; weight <= 26; weight++)
                        frequencies[edge.To, weight] = frequencies[node, weight];
                    frequencies[edge.To, edge.Weight]++;
                    stack.Push(edge.To);
                }
            }

            var answer = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                int u = queries[i][0];
                int v = queries[i][1];
                int lca = GetLca(u, v, depth, up, levels);
                int pathLength = depth[u] + depth[v] - (2 * depth[lca]);
                int maxFrequency = 0;
                for (int weight = 1; weight <= 26; weight++)
                    maxFrequency = Math.Max(maxFrequency, frequencies[u, weight] + frequencies[v, weight] - (2 * frequencies[lca, weight]));
                answer[i] = pathLength - maxFrequency;
            }

            return answer;
        }

        private int GetLca(int u, int v, int[] depth, int[,] up, int levels)
        {
            if (depth[u] < depth[v])
            {
                int temp = u;
                u = v;
                v = temp;
            }

            int difference = depth[u] - depth[v];
            for (int level = 0; level < levels; level++)
                if (((difference >> level) & 1) == 1)
                    u = up[u, level];

            if (u == v)
                return u;

            for (int level = levels - 1; level >= 0; level--)
            {
                if (up[u, level] != up[v, level])
                {
                    u = up[u, level];
                    v = up[v, level];
                }
            }

            return up[u, 0];
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-valid-paths-in-a-tree/">2867. Count Valid Paths in a Tree (hard)</a>
        /// Counts paths containing exactly one prime node by grouping composite components adjacent to each prime; runs in O(n log log n) time and O(n) space.
        /// </summary>
        /// <param name="n">The number of nodes labeled 1 through n.</param>
        /// <param name="edges">The undirected tree edges.</param>
        /// <returns>The number of valid paths.</returns>
        public long CountPaths(int n, int[][] edges)
        {
            bool[] isPrime = BuildPrimeTable(n);
            var graph = new List<int>[n + 1];
            for (int i = 1; i <= n; i++)
                graph[i] = new List<int>();
            foreach (int[] edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            int[] componentSize = new int[n + 1];
            int[] componentId = new int[n + 1];
            int nextComponentId = 1;
            for (int node = 1; node <= n; node++)
            {
                if (isPrime[node] || componentId[node] != 0)
                    continue;

                int size = 0;
                var stack = new Stack<int>();
                stack.Push(node);
                componentId[node] = nextComponentId;
                while (stack.Count > 0)
                {
                    int current = stack.Pop();
                    size++;
                    foreach (int neighbor in graph[current])
                    {
                        if (!isPrime[neighbor] && componentId[neighbor] == 0)
                        {
                            componentId[neighbor] = nextComponentId;
                            stack.Push(neighbor);
                        }
                    }
                }

                componentSize[nextComponentId] = size;
                nextComponentId++;
            }

            long paths = 0;
            for (int prime = 1; prime <= n; prime++)
            {
                if (!isPrime[prime])
                    continue;

                long previous = 0;
                foreach (int neighbor in graph[prime])
                {
                    if (isPrime[neighbor])
                        continue;
                    long size = componentSize[componentId[neighbor]];
                    paths += size;
                    paths += previous * size;
                    previous += size;
                }
            }

            return paths;
        }

        private bool[] BuildPrimeTable(int n)
        {
            var isPrime = new bool[n + 1];
            for (int i = 2; i <= n; i++)
                isPrime[i] = true;
            for (int factor = 2; factor * factor <= n; factor++)
            {
                if (!isPrime[factor])
                    continue;
                for (int multiple = factor * factor; multiple <= n; multiple += factor)
                    isPrime[multiple] = false;
            }

            return isPrime;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-number-of-k-divisible-components/">2872. Maximum Number of K-Divisible Components (hard)</a>
        /// Removes every subtree whose sum is divisible by k while propagating remainders upward; runs in O(n) time and space.
        /// </summary>
        /// <param name="n">The number of nodes labeled 0 through n - 1.</param>
        /// <param name="edges">The undirected tree edges.</param>
        /// <param name="values">The node values.</param>
        /// <param name="k">The divisibility target.</param>
        /// <returns>The maximum number of connected components whose sums are divisible by k.</returns>
        public int MaxKDivisibleComponents(int n, int[][] edges, int[] values, int k)
        {
            var graph = BuildUndirectedGraph(n, edges);
            int components = 0;
            MaxKDivisibleComponentsDfs(0, -1, graph, values, k, ref components);
            return components;
        }

        private long MaxKDivisibleComponentsDfs(int node, int parent, List<int>[] graph, int[] values, int k, ref int components)
        {
            long sum = values[node];
            foreach (int neighbor in graph[node])
                if (neighbor != parent)
                    sum += MaxKDivisibleComponentsDfs(neighbor, node, graph, values, k, ref components);
            if (sum % k == 0)
            {
                components++;
                return 0;
            }

            return sum % k;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-score-after-applying-operations-on-a-tree/">2925. Maximum Score After Applying Operations on a Tree (medium)</a>
        /// Maximizes collected score by subtracting the minimum value that must remain in each subtree to keep every root-to-leaf path non-zero; runs in O(n) time and space.
        /// </summary>
        /// <param name="edges">The undirected tree edges.</param>
        /// <param name="values">The node values.</param>
        /// <returns>The maximum obtainable score.</returns>
        public long MaximumScoreAfterOperations(int[][] edges, int[] values)
        {
            int n = values.Length;
            var graph = BuildUndirectedGraph(n, edges);
            long total = 0;
            foreach (int value in values)
                total += value;
            return total - MinimumHealthyRemainder(0, -1, graph, values);
        }

        private long MinimumHealthyRemainder(int node, int parent, List<int>[] graph, int[] values)
        {
            bool hasChild = false;
            foreach (int neighbor in graph[node])
                if (neighbor != parent)
                    hasChild = true;
            bool leaf = !hasChild;
            if (leaf)
                return values[node];

            long childRemainder = 0;
            foreach (int neighbor in graph[node])
                if (neighbor != parent)
                    childRemainder += MinimumHealthyRemainder(neighbor, node, graph, values);
            return Math.Min(values[node], childRemainder);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-points-after-collecting-coins-from-all-nodes/">2920. Maximum Points After Collecting Coins From All Nodes (hard)</a>
        /// Performs tree dynamic programming over possible halving counts at each node; runs in O(n log C) time and O(n log C) space.
        /// </summary>
        /// <param name="edges">The undirected tree edges.</param>
        /// <param name="coins">Coins available at each node.</param>
        /// <param name="k">The fixed penalty for taking the current halved coin value.</param>
        /// <returns>The maximum points collectable from the full tree.</returns>
        public int MaximumPoints(int[][] edges, int[] coins, int k)
        {
            int n = coins.Length;
            var graph = BuildUndirectedGraph(n, edges);
            var memo = new int[n, 15];
            for (int node = 0; node < n; node++)
                for (int shift = 0; shift < 15; shift++)
                    memo[node, shift] = int.MinValue;
            return MaximumPointsDfs(0, -1, 0, graph, coins, k, memo);
        }

        private int MaximumPointsDfs(int node, int parent, int shift, List<int>[] graph, int[] coins, int k, int[,] memo)
        {
            if (shift >= 14)
                shift = 14;
            if (memo[node, shift] != int.MinValue)
                return memo[node, shift];

            int takeWithPenalty = (coins[node] >> shift) - k;
            int takeHalved = coins[node] >> (shift + 1);
            foreach (int neighbor in graph[node])
            {
                if (neighbor == parent)
                    continue;
                takeWithPenalty += MaximumPointsDfs(neighbor, node, shift, graph, coins, k, memo);
                takeHalved += MaximumPointsDfs(neighbor, node, shift + 1, graph, coins, k, memo);
            }

            memo[node, shift] = Math.Max(takeWithPenalty, takeHalved);
            return memo[node, shift];
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-pairs-of-connectable-servers-in-a-weighted-tree-network/">3067. Count Pairs of Connectable Servers in a Weighted Tree Network (medium)</a>
        /// For each server, counts divisible-distance nodes in each adjacent branch and combines previous branches; runs in O(n^2) time and O(n) space.
        /// </summary>
        /// <param name="edges">Weighted tree edges [u, v, weight].</param>
        /// <param name="signalSpeed">The speed that must divide both path distances from the center.</param>
        /// <returns>The number of connectable server pairs for every center node.</returns>
        public int[] CountPairsOfConnectableServers(int[][] edges, int signalSpeed)
        {
            int n = edges.Length + 1;
            var graph = new List<(int To, int Weight)>[n];
            for (int i = 0; i < n; i++)
                graph[i] = new List<(int To, int Weight)>();
            foreach (int[] edge in edges)
            {
                graph[edge[0]].Add((edge[1], edge[2]));
                graph[edge[1]].Add((edge[0], edge[2]));
            }

            var answer = new int[n];
            for (int center = 0; center < n; center++)
            {
                int previousBranches = 0;
                foreach (var edge in graph[center])
                {
                    int count = CountDivisibleDistances(edge.To, center, edge.Weight, signalSpeed, graph);
                    answer[center] += previousBranches * count;
                    previousBranches += count;
                }
            }

            return answer;
        }

        private int CountDivisibleDistances(int node, int parent, int distance, int signalSpeed, List<(int To, int Weight)>[] graph)
        {
            int count = distance % signalSpeed == 0 ? 1 : 0;
            foreach (var edge in graph[node])
                if (edge.To != parent)
                    count += CountDivisibleDistances(edge.To, node, distance + edge.Weight, signalSpeed, graph);
            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-minimum-diameter-after-merging-two-trees/">3203. Find Minimum Diameter After Merging Two Trees (hard)</a>
        /// Computes each tree diameter and radius, then connects centers so the merged diameter is minimized; runs in O(n + m) time and space.
        /// </summary>
        /// <param name="edges1">The edges of the first tree.</param>
        /// <param name="edges2">The edges of the second tree.</param>
        /// <returns>The minimum possible diameter after adding one edge between the trees.</returns>
        public int MinimumDiameterAfterMerge(int[][] edges1, int[][] edges2)
        {
            int diameter1 = TreeDiameter(edges1);
            int diameter2 = TreeDiameter(edges2);
            int radius1 = (diameter1 + 1) / 2;
            int radius2 = (diameter2 + 1) / 2;
            return Math.Max(Math.Max(diameter1, diameter2), radius1 + radius2 + 1);
        }

        private int TreeDiameter(int[][] edges)
        {
            int n = edges.Length + 1;
            var graph = BuildUndirectedGraph(n, edges);
            var first = FarthestNode(0, graph);
            var second = FarthestNode(first.Node, graph);
            return second.Distance;
        }

        private (int Node, int Distance) FarthestNode(int start, List<int>[] graph)
        {
            int farthest = start;
            int maxDistance = 0;
            var distances = new int[graph.Length];
            for (int i = 0; i < distances.Length; i++)
                distances[i] = -1;
            var queue = new Queue<int>();
            queue.Enqueue(start);
            distances[start] = 0;
            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                if (distances[node] > maxDistance)
                {
                    maxDistance = distances[node];
                    farthest = node;
                }

                foreach (int neighbor in graph[node])
                {
                    if (distances[neighbor] != -1)
                        continue;
                    distances[neighbor] = distances[node] + 1;
                    queue.Enqueue(neighbor);
                }
            }

            return (farthest, maxDistance);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/time-taken-to-mark-all-nodes/">3241. Time Taken to Mark All Nodes (hard)</a>
        /// Reroots longest weighted distances where entering an even node costs 2 seconds and entering an odd node costs 1 second; runs in O(n) time and space.
        /// </summary>
        /// <param name="edges">The undirected tree edges.</param>
        /// <returns>The time needed to mark all nodes for every possible starting node.</returns>
        public int[] TimeTaken(int[][] edges)
        {
            int n = edges.Length + 1;
            var graph = BuildUndirectedGraph(n, edges);
            var down = new int[n];
            TimeTakenDown(0, -1, graph, down);
            var answer = new int[n];
            TimeTakenReroot(0, -1, 0, graph, down, answer);
            return answer;
        }

        private void TimeTakenDown(int node, int parent, List<int>[] graph, int[] down)
        {
            foreach (int neighbor in graph[node])
            {
                if (neighbor == parent)
                    continue;
                TimeTakenDown(neighbor, node, graph, down);
                down[node] = Math.Max(down[node], MarkCost(neighbor) + down[neighbor]);
            }
        }

        private void TimeTakenReroot(int node, int parent, int upValue, List<int>[] graph, int[] down, int[] answer)
        {
            int best1 = -1;
            int best2 = -1;
            foreach (int neighbor in graph[node])
            {
                if (neighbor == parent)
                    continue;
                int candidate = MarkCost(neighbor) + down[neighbor];
                if (candidate > best1)
                {
                    best2 = best1;
                    best1 = candidate;
                }
                else if (candidate > best2)
                    best2 = candidate;
            }

            answer[node] = Math.Max(down[node], upValue);
            foreach (int neighbor in graph[node])
            {
                if (neighbor == parent)
                    continue;
                int childContribution = MarkCost(neighbor) + down[neighbor];
                int siblingBest = childContribution == best1 ? best2 : best1;
                int bestOutsideChild = Math.Max(upValue, siblingBest);
                TimeTakenReroot(neighbor, node, MarkCost(node) + Math.Max(0, bestOutsideChild), graph, down, answer);
            }
        }

        private int MarkCost(int node)
        {
            return node % 2 == 0 ? 2 : 1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/k-th-largest-perfect-subtree-size-in-binary-tree/">3319. K-th Largest Perfect Subtree Size in Binary Tree (medium)</a>
        /// Collects sizes of perfect binary subtrees during one postorder traversal, then returns the k-th largest; runs in O(n log n) time and O(n) space.
        /// </summary>
        /// <param name="root">The binary tree root.</param>
        /// <param name="k">The 1-based rank among perfect subtree sizes in descending order.</param>
        /// <returns>The k-th largest perfect subtree size, or -1 if fewer than k exist.</returns>
        public int KthLargestPerfectSubtree(TreeNode root, int k)
        {
            var sizes = new List<int>();
            KthLargestPerfectSubtreeDfs(root, sizes);
            sizes.Sort((a, b) => b.CompareTo(a));
            return sizes.Count >= k ? sizes[k - 1] : -1;
        }

        private (bool Perfect, int Height, int Size) KthLargestPerfectSubtreeDfs(TreeNode node, List<int> sizes)
        {
            if (node == null)
                return (true, 0, 0);
            var left = KthLargestPerfectSubtreeDfs(node.left, sizes);
            var right = KthLargestPerfectSubtreeDfs(node.right, sizes);
            bool perfect = left.Perfect && right.Perfect && left.Height == right.Height;
            int size = left.Size + right.Size + 1;
            int height = Math.Max(left.Height, right.Height) + 1;
            if (perfect)
                sizes.Add(size);
            return (perfect, height, size);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-subtree-sizes-after-changes/">3331. Find Subtree Sizes After Changes (medium)</a>
        /// Simultaneously reparents each node to its nearest same-character ancestor, then computes subtree sizes in the changed tree; runs in O(n) time and space.
        /// </summary>
        /// <param name="parent">The original rooted tree parent array.</param>
        /// <param name="s">The character assigned to each node.</param>
        /// <returns>The subtree size of every node after all parent changes.</returns>
        public int[] FindSubtreeSizes(int[] parent, string s)
        {
            int n = parent.Length;
            var originalChildren = new List<int>[n];
            for (int i = 0; i < n; i++)
                originalChildren[i] = new List<int>();
            for (int i = 1; i < n; i++)
                originalChildren[parent[i]].Add(i);

            var changedParent = new int[n];
            Array.Copy(parent, changedParent, n);
            var stacks = new Stack<int>[26];
            for (int i = 0; i < 26; i++)
                stacks[i] = new Stack<int>();
            FindSubtreeSizesParents(0, originalChildren, s, stacks, changedParent);

            var changedChildren = new List<int>[n];
            for (int i = 0; i < n; i++)
                changedChildren[i] = new List<int>();
            for (int i = 1; i < n; i++)
                changedChildren[changedParent[i]].Add(i);

            var sizes = new int[n];
            FindSubtreeSizesDfs(0, changedChildren, sizes);
            return sizes;
        }

        private void FindSubtreeSizesParents(int node, List<int>[] children, string s, Stack<int>[] stacks, int[] changedParent)
        {
            int letter = s[node] - 'a';
            if (stacks[letter].Count > 0)
                changedParent[node] = stacks[letter].Peek();
            stacks[letter].Push(node);
            foreach (int child in children[node])
                FindSubtreeSizesParents(child, children, s, stacks, changedParent);
            stacks[letter].Pop();
        }

        private int FindSubtreeSizesDfs(int node, List<int>[] children, int[] sizes)
        {
            int size = 1;
            foreach (int child in children[node])
                size += FindSubtreeSizesDfs(child, children, sizes);
            sizes[node] = size;
            return size;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximize-sum-of-weights-after-edge-removals/">3367. Maximize Sum of Weights after Edge Removals (hard)</a>
        /// Tree DP chooses profitable child edges while keeping at most k incident selected edges at every node; runs in O(n d log d) total time and O(n) space.
        /// </summary>
        /// <param name="edges">Weighted tree edges [u, v, weight].</param>
        /// <param name="k">The maximum selected degree allowed for each node.</param>
        /// <returns>The maximum possible sum of kept edge weights.</returns>
        public long MaximizeSumOfWeights(int[][] edges, int k)
        {
            int n = edges.Length + 1;
            var graph = new List<(int To, int Weight)>[n];
            for (int i = 0; i < n; i++)
                graph[i] = new List<(int To, int Weight)>();
            foreach (int[] edge in edges)
            {
                graph[edge[0]].Add((edge[1], edge[2]));
                graph[edge[1]].Add((edge[0], edge[2]));
            }

            var result = MaximizeSumOfWeightsDfs(0, -1, graph, k);
            return result.NotConnected;
        }

        private (long NotConnected, long ConnectedToParent) MaximizeSumOfWeightsDfs(int node, int parent, List<(int To, int Weight)>[] graph, int k)
        {
            long baseSum = 0;
            var gains = new List<long>();
            foreach (var edge in graph[node])
            {
                if (edge.To == parent)
                    continue;
                var child = MaximizeSumOfWeightsDfs(edge.To, node, graph, k);
                baseSum += child.NotConnected;
                long gain = child.ConnectedToParent + edge.Weight - child.NotConnected;
                if (gain > 0)
                    gains.Add(gain);
            }

            gains.Sort((a, b) => b.CompareTo(a));
            long notConnected = baseSum;
            for (int i = 0; i < Math.Min(k, gains.Count); i++)
                notConnected += gains[i];

            long connected = baseSum;
            for (int i = 0; i < Math.Min(k - 1, gains.Count); i++)
                connected += gains[i];

            return (notConnected, connected);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximize-the-number-of-target-nodes-after-connecting-trees-i/">3372. Maximize the Number of Target Nodes After Connecting Trees I (medium)</a>
        /// Counts nodes within distance k in the first tree plus the best count within distance k - 1 in the second tree; runs in O((n + m)^2) time and O(n + m) space.
        /// </summary>
        /// <param name="edges1">The first tree edges.</param>
        /// <param name="edges2">The second tree edges.</param>
        /// <param name="k">The maximum allowed distance after adding one connecting edge.</param>
        /// <returns>The maximum target-node count for each node in the first tree.</returns>
        public int[] MaxTargetNodes(int[][] edges1, int[][] edges2, int k)
        {
            int n = edges1.Length + 1;
            int m = edges2.Length + 1;
            var graph1 = BuildUndirectedGraph(n, edges1);
            var graph2 = BuildUndirectedGraph(m, edges2);
            int bestSecond = 0;
            for (int node = 0; node < m; node++)
                bestSecond = Math.Max(bestSecond, CountWithinDistance(node, k - 1, graph2));

            var answer = new int[n];
            for (int node = 0; node < n; node++)
                answer[node] = CountWithinDistance(node, k, graph1) + bestSecond;
            return answer;
        }

        private int CountWithinDistance(int start, int maxDistance, List<int>[] graph)
        {
            if (maxDistance < 0)
                return 0;
            int count = 0;
            var queue = new Queue<int>();
            var distances = new int[graph.Length];
            for (int i = 0; i < distances.Length; i++)
                distances[i] = -1;
            queue.Enqueue(start);
            distances[start] = 0;
            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                count++;
                if (distances[node] == maxDistance)
                    continue;
                foreach (int neighbor in graph[node])
                {
                    if (distances[neighbor] != -1)
                        continue;
                    distances[neighbor] = distances[node] + 1;
                    queue.Enqueue(neighbor);
                }
            }

            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximize-the-number-of-target-nodes-after-connecting-trees-ii/">3373. Maximize the Number of Target Nodes After Connecting Trees II (hard)</a>
        /// Uses tree bipartitions because even-distance targets are exactly nodes with the same color; runs in O(n + m) time and space.
        /// </summary>
        /// <param name="edges1">The first tree edges.</param>
        /// <param name="edges2">The second tree edges.</param>
        /// <returns>The maximum target-node count for each node in the first tree.</returns>
        public int[] MaxTargetNodes(int[][] edges1, int[][] edges2)
        {
            int n = edges1.Length + 1;
            int m = edges2.Length + 1;
            int[] colors1 = ColorTree(BuildUndirectedGraph(n, edges1));
            int[] colors2 = ColorTree(BuildUndirectedGraph(m, edges2));
            int[] counts1 = CountColors(colors1);
            int[] counts2 = CountColors(colors2);
            int bestSecond = Math.Max(counts2[0], counts2[1]);
            var answer = new int[n];
            for (int node = 0; node < n; node++)
                answer[node] = counts1[colors1[node]] + bestSecond;
            return answer;
        }

        private int[] ColorTree(List<int>[] graph)
        {
            var colors = new int[graph.Length];
            for (int i = 0; i < colors.Length; i++)
                colors[i] = -1;
            var queue = new Queue<int>();
            queue.Enqueue(0);
            colors[0] = 0;
            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                foreach (int neighbor in graph[node])
                {
                    if (colors[neighbor] != -1)
                        continue;
                    colors[neighbor] = colors[node] ^ 1;
                    queue.Enqueue(neighbor);
                }
            }

            return colors;
        }

        private int[] CountColors(int[] colors)
        {
            var counts = new int[2];
            foreach (int color in colors)
                counts[color]++;
            return counts;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/number-of-ways-to-assign-edge-weights-i/">3558. Number of Ways to Assign Edge Weights I (medium)</a>
        /// Finds the maximum depth from node 1, then counts parity assignments with an odd path sum as 2^(depth - 1) modulo 1e9+7; runs in O(n) time and space.
        /// </summary>
        /// <param name="edges">The undirected tree edges using 1-based labels.</param>
        /// <returns>The number of valid edge-weight assignments.</returns>
        public int AssignEdgeWeights(int[][] edges)
        {
            const int Mod = 1_000_000_007;
            int n = edges.Length + 1;
            var graph = new List<int>[n + 1];
            for (int i = 1; i <= n; i++)
                graph[i] = new List<int>();
            foreach (int[] edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            int maxDepth = 0;
            var queue = new Queue<(int Node, int Parent, int Depth)>();
            queue.Enqueue((1, 0, 0));
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                maxDepth = Math.Max(maxDepth, current.Depth);
                foreach (int neighbor in graph[current.Node])
                    if (neighbor != current.Parent)
                        queue.Enqueue((neighbor, current.Node, current.Depth + 1));
            }

            if (maxDepth == 0)
                return 0;

            long ways = 1;
            for (int i = 1; i < maxDepth; i++)
                ways = (ways * 2) % Mod;
            return (int)ways;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-subgraph-score-in-a-tree/">3772. Maximum Subgraph Score in a Tree (hard)</a>
        /// Finds, for each node, the best score of a connected subgraph containing it using rerooting dynamic programming.
        /// </summary>
        /// <param name="n">The number of tree nodes.</param>
        /// <param name="edges">The zero-indexed undirected tree edges.</param>
        /// <param name="good">Whether each node contributes one instead of negative one to a score.</param>
        /// <returns>The maximum connected-subgraph score containing each node.</returns>
        public int[] MaxSubgraphScore(int n, int[][] edges, int[] good)
        {
            List<int>[] graph = BuildUndirectedGraph(n, edges);
            var parent = new int[n];
            var order = new int[n];
            Array.Fill(parent, -2);
            parent[0] = -1;
            int count = 0;
            var stack = new Stack<int>();
            stack.Push(0);
            while (stack.Count > 0)
            {
                int node = stack.Pop();
                order[count++] = node;
                foreach (int neighbor in graph[node])
                    if (neighbor != parent[node])
                    {
                        parent[neighbor] = node;
                        stack.Push(neighbor);
                    }
            }

            var down = new int[n];
            for (int i = n - 1; i >= 0; i--)
            {
                int node = order[i];
                int score = good[node] == 1 ? 1 : -1;
                foreach (int neighbor in graph[node])
                    if (parent[neighbor] == node)
                        score += Math.Max(0, down[neighbor]);
                down[node] = score;
            }

            var answer = new int[n];
            var outside = new int[n];
            for (int i = 0; i < n; i++)
            {
                int node = order[i];
                answer[node] = down[node] + Math.Max(0, outside[node]);
                foreach (int neighbor in graph[node])
                    if (parent[neighbor] == node)
                        outside[neighbor] = answer[node] - Math.Max(0, down[neighbor]);
            }

            return answer;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/total-sum-of-interaction-cost-in-tree-groups/">3786. Total Sum of Interaction Cost in Tree Groups (hard)</a>
        /// Sums same-group pair distances by counting how each edge separates every group.
        /// </summary>
        /// <param name="n">The number of tree nodes.</param>
        /// <param name="edges">The zero-indexed undirected tree edges.</param>
        /// <param name="group">The group assigned to each node, from one through twenty.</param>
        /// <returns>The total interaction cost.</returns>
        public long InteractionCosts(int n, int[][] edges, int[] group)
        {
            List<int>[] graph = BuildUndirectedGraph(n, edges);
            var totals = new int[21];
            foreach (int value in group)
                totals[value]++;
            var parent = new int[n];
            var order = new int[n];
            Array.Fill(parent, -2);
            parent[0] = -1;
            int length = 0;
            var stack = new Stack<int>();
            stack.Push(0);
            while (stack.Count > 0)
            {
                int node = stack.Pop();
                order[length++] = node;
                foreach (int neighbor in graph[node])
                    if (neighbor != parent[node])
                    {
                        parent[neighbor] = node;
                        stack.Push(neighbor);
                    }
            }

            var subtreeCounts = new int[n, 21];
            long result = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                int node = order[i];
                subtreeCounts[node, group[node]]++;
                if (parent[node] != -1)
                {
                    for (int value = 1; value <= 20; value++)
                    {
                        long inSubtree = subtreeCounts[node, value];
                        result += inSubtree * (totals[value] - inSubtree);
                        subtreeCounts[parent[node], value] += subtreeCounts[node, value];
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-edge-toggles-on-a-tree/">3812. Minimum Edge Toggles on a Tree (hard)</a>
        /// Selects the unique feasible edge set that corrects endpoint-bit mismatches, or reports impossibility.
        /// </summary>
        /// <param name="n">The number of tree nodes.</param>
        /// <param name="edges">The zero-indexed undirected tree edges in their selectable order.</param>
        /// <param name="start">The initial bit at every node.</param>
        /// <param name="target">The required bit at every node.</param>
        /// <returns>Increasing selected edge indices, or a list containing negative one when impossible.</returns>
        public IList<int> MinimumFlips(int n, int[][] edges, string start, string target)
        {
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++)
                graph[i] = new List<int>();
            for (int i = 0; i < edges.Length; i++)
            {
                graph[edges[i][0]].Add(i);
                graph[edges[i][1]].Add(i);
            }

            var parent = new int[n];
            var parentEdge = new int[n];
            var order = new int[n];
            Array.Fill(parent, -2);
            parent[0] = -1;
            int length = 0;
            var stack = new Stack<int>();
            stack.Push(0);
            while (stack.Count > 0)
            {
                int node = stack.Pop();
                order[length++] = node;
                foreach (int edgeIndex in graph[node])
                {
                    int neighbor = edges[edgeIndex][0] == node ? edges[edgeIndex][1] : edges[edgeIndex][0];
                    if (neighbor == parent[node])
                        continue;
                    parent[neighbor] = node;
                    parentEdge[neighbor] = edgeIndex;
                    stack.Push(neighbor);
                }
            }

            var selected = new List<int>();
            var needsParent = new bool[n];
            for (int i = n - 1; i >= 0; i--)
            {
                int node = order[i];
                bool needed = start[node] != target[node];
                foreach (int edgeIndex in graph[node])
                {
                    int neighbor = edges[edgeIndex][0] == node ? edges[edgeIndex][1] : edges[edgeIndex][0];
                    if (parent[neighbor] == node && needsParent[neighbor])
                    {
                        selected.Add(edgeIndex);
                        needed = !needed;
                    }
                }
                needsParent[node] = needed;
            }

            if (needsParent[0])
                return new List<int> { -1 };
            selected.Sort();
            return selected;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/pythagorean-distance-nodes-in-a-tree/">3820. Pythagorean Distance Nodes in a Tree (medium)</a>
        /// Counts nodes whose distances to three specified nodes form a Pythagorean triple.
        /// </summary>
        /// <param name="n">The number of tree nodes.</param>
        /// <param name="edges">The zero-indexed undirected tree edges.</param>
        /// <param name="x">The first specified node.</param>
        /// <param name="y">The second specified node.</param>
        /// <param name="z">The third specified node.</param>
        /// <returns>The number of special nodes.</returns>
        public int SpecialNodes(int n, int[][] edges, int x, int y, int z)
        {
            List<int>[] graph = BuildUndirectedGraph(n, edges);
            int[] first = TreeDistances(graph, x);
            int[] second = TreeDistances(graph, y);
            int[] third = TreeDistances(graph, z);
            int result = 0;
            for (int node = 0; node < n; node++)
            {
                int a = first[node];
                int b = second[node];
                int c = third[node];
                if (a > b) (a, b) = (b, a);
                if (b > c) (b, c) = (c, b);
                if (a > b) (a, b) = (b, a);
                if ((long)a * a + (long)b * b == (long)c * c)
                    result++;
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/palindromic-path-queries-in-a-tree/">3841. Palindromic Path Queries in a Tree (hard)</a>
        /// Supports character updates and path-palindrome-permutation queries with heavy-light decomposition.
        /// </summary>
        /// <param name="n">The number of tree nodes.</param>
        /// <param name="edges">The zero-indexed undirected tree edges.</param>
        /// <param name="s">The initial lowercase character at every node.</param>
        /// <param name="queries">Update or path-query instructions.</param>
        /// <returns>The answers for query instructions in their original order.</returns>
        public IList<bool> PalindromePath(int n, int[][] edges, string s, string[] queries)
        {
            List<int>[] graph = BuildUndirectedGraph(n, edges);
            var parent = new int[n];
            var depth = new int[n];
            var size = new int[n];
            var heavy = new int[n];
            var order = new int[n];
            Array.Fill(parent, -2);
            Array.Fill(heavy, -1);
            parent[0] = -1;
            int orderLength = 0;
            var stack = new Stack<int>();
            stack.Push(0);
            while (stack.Count > 0)
            {
                int node = stack.Pop();
                order[orderLength++] = node;
                foreach (int neighbor in graph[node])
                    if (neighbor != parent[node])
                    {
                        parent[neighbor] = node;
                        depth[neighbor] = depth[node] + 1;
                        stack.Push(neighbor);
                    }
            }
            for (int i = n - 1; i >= 0; i--)
            {
                int node = order[i];
                size[node] = 1;
                int largest = 0;
                foreach (int neighbor in graph[node])
                    if (parent[neighbor] == node)
                    {
                        size[node] += size[neighbor];
                        if (size[neighbor] > largest)
                        {
                            largest = size[neighbor];
                            heavy[node] = neighbor;
                        }
                    }
            }

            var head = new int[n];
            var position = new int[n];
            int currentPosition = 0;
            var chains = new Stack<(int Node, int Head)>();
            chains.Push((0, 0));
            while (chains.Count > 0)
            {
                (int node, int chainHead) = chains.Pop();
                for (int current = node; current != -1; current = heavy[current])
                {
                    head[current] = chainHead;
                    position[current] = currentPosition++;
                    foreach (int neighbor in graph[current])
                        if (parent[neighbor] == current && neighbor != heavy[current])
                            chains.Push((neighbor, neighbor));
                }
            }

            var values = new int[n];
            for (int node = 0; node < n; node++)
                values[position[node]] = 1 << (s[node] - 'a');
            var segmentTree = new XorSegmentTree(values);
            var answers = new List<bool>();
            foreach (string query in queries)
            {
                string[] parts = query.Split(' ');
                int first = int.Parse(parts[1]);
                if (parts[0] == "update")
                    segmentTree.Update(position[first], 1 << (parts[2][0] - 'a'));
                else
                {
                    int second = int.Parse(parts[2]);
                    int mask = 0;
                    while (head[first] != head[second])
                    {
                        if (depth[head[first]] < depth[head[second]])
                            (first, second) = (second, first);
                        mask ^= segmentTree.Query(position[head[first]], position[first]);
                        first = parent[head[first]];
                    }
                    if (depth[first] > depth[second])
                        (first, second) = (second, first);
                    mask ^= segmentTree.Query(position[first], position[second]);
                    answers.Add((mask & (mask - 1)) == 0);
                }
            }
            return answers;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-non-adjacent-subsets-in-a-rooted-tree/">3939. Count Non Adjacent Subsets in a Rooted Tree (hard)</a>
        /// Counts independent node subsets whose value sum is divisible by <paramref name="k"/>.
        /// </summary>
        /// <param name="parent">The parent of each node, with negative one for the root.</param>
        /// <param name="nums">The value assigned to each node.</param>
        /// <param name="k">The required sum divisor.</param>
        /// <returns>The number of nonempty valid subsets modulo 1,000,000,007.</returns>
        public int CountValidSubsets(int[] parent, int[] nums, int k)
        {
            const int Mod = 1_000_000_007;
            int n = parent.Length;
            var children = new List<int>[n];
            int root = 0;
            for (int i = 0; i < n; i++)
            {
                children[i] = new List<int>();
                if (parent[i] == -1)
                    root = i;
            }
            for (int i = 0; i < n; i++)
                if (parent[i] != -1)
                    children[parent[i]].Add(i);
            var order = new List<int>();
            var stack = new Stack<int>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                int node = stack.Pop();
                order.Add(node);
                foreach (int child in children[node])
                    stack.Push(child);
            }
            var unselected = new long[n][];
            var selected = new long[n][];
            for (int index = order.Count - 1; index >= 0; index--)
            {
                int node = order[index];
                long[] without = new long[k];
                long[] with = new long[k];
                without[0] = 1;
                with[nums[node] % k] = 1;
                foreach (int child in children[node])
                {
                    var nextWithout = new long[k];
                    var nextWith = new long[k];
                    for (int left = 0; left < k; left++)
                    {
                        if (without[left] != 0)
                            for (int right = 0; right < k; right++)
                                nextWithout[(left + right) % k] = (nextWithout[(left + right) % k] + without[left] * ((unselected[child][right] + selected[child][right]) % Mod)) % Mod;
                        if (with[left] != 0)
                            for (int right = 0; right < k; right++)
                                nextWith[(left + right) % k] = (nextWith[(left + right) % k] + with[left] * unselected[child][right]) % Mod;
                    }
                    without = nextWithout;
                    with = nextWith;
                }
                unselected[node] = without;
                selected[node] = with;
            }
            return (int)((unselected[root][0] + selected[root][0] - 1 + Mod) % Mod);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/sum-of-perfect-square-ancestors/">3715. Sum of Perfect Square Ancestors (hard)</a>
        /// Counts ancestor-descendant pairs whose node values have equal square-free kernels.
        /// </summary>
        /// <param name="n">The number of tree nodes.</param>
        /// <param name="edges">The zero-indexed undirected tree edges rooted at node zero.</param>
        /// <param name="nums">The positive value assigned to each node.</param>
        /// <returns>The sum of qualifying ancestor counts for all nodes.</returns>
        public long SumOfAncestors(int n, int[][] edges, int[] nums)
        {
            int maximum = 0;
            foreach (int value in nums)
                maximum = Math.Max(maximum, value);
            var smallestPrime = new int[maximum + 1];
            for (int factor = 2; factor <= maximum; factor++)
            {
                if (smallestPrime[factor] != 0)
                    continue;
                for (int multiple = factor; multiple <= maximum; multiple += factor)
                    if (smallestPrime[multiple] == 0)
                        smallestPrime[multiple] = factor;
            }

            var kernels = new int[n];
            for (int i = 0; i < n; i++)
            {
                int value = nums[i];
                int kernel = 1;
                while (value > 1)
                {
                    int prime = smallestPrime[value];
                    int exponent = 0;
                    do
                    {
                        value /= prime;
                        exponent++;
                    } while (value > 1 && smallestPrime[value] == prime);
                    if ((exponent & 1) == 1)
                        kernel *= prime;
                }
                kernels[i] = kernel;
            }

            List<int>[] graph = BuildUndirectedGraph(n, edges);
            var frequencies = new Dictionary<int, int>();
            long result = 0;
            var stack = new Stack<(int Node, int Parent, bool Leaving)>();
            stack.Push((0, -1, false));
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                int kernel = kernels[current.Node];
                if (current.Leaving)
                {
                    frequencies[kernel]--;
                    continue;
                }

                if (frequencies.TryGetValue(kernel, out int count))
                    result += count;
                frequencies[kernel] = count + 1;
                stack.Push((current.Node, current.Parent, true));
                foreach (int neighbor in graph[current.Node])
                    if (neighbor != current.Parent)
                        stack.Push((neighbor, current.Node, false));
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/finish-time-of-tasks-i/">3965. Finish Time of Tasks I (medium)</a>
        /// Computes each task's finish time bottom-up from the earliest and latest finishing child tasks.
        /// </summary>
        /// <param name="n">The number of tasks.</param>
        /// <param name="edges">The directed parent-to-child task edges.</param>
        /// <param name="baseTime">The base duration of each task.</param>
        /// <returns>The finish time of root task zero.</returns>
        public long FinishTime(int n, int[][] edges, int[] baseTime)
        {
            var children = new List<int>[n];
            for (int i = 0; i < n; i++)
                children[i] = new List<int>();
            foreach (int[] edge in edges)
                children[edge[0]].Add(edge[1]);

            var order = new List<int>();
            var stack = new Stack<int>();
            stack.Push(0);
            while (stack.Count > 0)
            {
                int node = stack.Pop();
                order.Add(node);
                foreach (int child in children[node])
                    stack.Push(child);
            }

            var finishTimes = new long[n];
            for (int i = order.Count - 1; i >= 0; i--)
            {
                int node = order[i];
                if (children[node].Count == 0)
                {
                    finishTimes[node] = baseTime[node];
                    continue;
                }
                long earliest = long.MaxValue;
                long latest = long.MinValue;
                foreach (int child in children[node])
                {
                    earliest = Math.Min(earliest, finishTimes[child]);
                    latest = Math.Max(latest, finishTimes[child]);
                }
                finishTimes[node] = latest + (latest - earliest) + baseTime[node];
            }
            return finishTimes[0];
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-dominant-nodes-in-a-binary-tree/">3997. Count Dominant Nodes in a Binary Tree (medium)</a>
        /// Counts nodes whose value is the maximum value in their complete subtree.
        /// </summary>
        /// <param name="root">The root of the binary tree.</param>
        /// <returns>The number of dominant nodes.</returns>
        public int CountDominantNodes(TreeNode root)
        {
            int count = 0;
            CountDominantNodes(root, ref count);
            return count;
        }

        private long CountDominantNodes(TreeNode node, ref int count)
        {
            if (node == null)
                return long.MinValue;
            long maximum = Math.Max(node.val, Math.Max(CountDominantNodes(node.left, ref count), CountDominantNodes(node.right, ref count)));
            if (maximum == node.val)
                count++;
            return maximum;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/weighted-sum-of-a-tree/">4015. Weighted Sum of a Tree (medium)</a>
        /// Computes the depth-weighted value total after finding the rooted tree height.
        /// </summary>
        /// <param name="parent">The parent of each node, with negative one for the root.</param>
        /// <param name="nums">The value assigned to each node.</param>
        /// <returns>The weighted sum of all node values.</returns>
        public long WeightedSum(int[] parent, int[] nums)
        {
            int n = parent.Length;
            var children = new List<int>[n];
            int root = 0;
            for (int i = 0; i < n; i++)
            {
                children[i] = new List<int>();
                if (parent[i] == -1)
                    root = i;
            }
            for (int i = 0; i < n; i++)
                if (parent[i] != -1)
                    children[parent[i]].Add(i);
            var depths = new int[n];
            int height = 1;
            var queue = new Queue<int>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                height = Math.Max(height, depths[node] + 1);
                foreach (int child in children[node])
                {
                    depths[child] = depths[node] + 1;
                    queue.Enqueue(child);
                }
            }
            long total = 0;
            for (int i = 0; i < n; i++)
                total += (long)nums[i] * (height - depths[i]);
            return total;
        }

        private int[] TreeDistances(List<int>[] graph, int source)
        {
            var distances = new int[graph.Length];
            Array.Fill(distances, -1);
            distances[source] = 0;
            var queue = new Queue<int>();
            queue.Enqueue(source);
            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                foreach (int neighbor in graph[node])
                    if (distances[neighbor] == -1)
                    {
                        distances[neighbor] = distances[node] + 1;
                        queue.Enqueue(neighbor);
                    }
            }
            return distances;
        }

        private sealed class XorSegmentTree
        {
            private readonly int size;
            private readonly int[] values;

            public XorSegmentTree(int[] source)
            {
                size = 1;
                while (size < source.Length)
                    size <<= 1;
                values = new int[size * 2];
                Array.Copy(source, 0, values, size, source.Length);
                for (int i = size - 1; i > 0; i--)
                    values[i] = values[i * 2] ^ values[i * 2 + 1];
            }

            public void Update(int index, int value)
            {
                index += size;
                values[index] = value;
                for (index >>= 1; index > 0; index >>= 1)
                    values[index] = values[index * 2] ^ values[index * 2 + 1];
            }

            public int Query(int left, int right)
            {
                int result = 0;
                for (left += size, right += size; left <= right; left >>= 1, right >>= 1)
                {
                    if ((left & 1) == 1)
                        result ^= values[left++];
                    if ((right & 1) == 0)
                        result ^= values[right--];
                }
                return result;
            }
        }

        private List<int>[] BuildUndirectedGraph(int n, int[][] edges)
        {
            var graph = new List<int>[n];
            for (int i = 0; i < n; i++)
                graph[i] = new List<int>();
            foreach (int[] edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            return graph;
        }

    }
}
