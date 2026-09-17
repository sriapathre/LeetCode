using LeetCode.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;


namespace LeetCode.UnitTests
{
    [TestClass]
    public class TreesTests
    {
        Trees trees;
        [TestInitialize]
        public void Setup()
        {
            this.trees = new Trees();
        }

        private TreeNode CreateTree(int?[] list)
        {
            if (list == null || list.Length == 0 || !list[0].HasValue)
                return null;

            TreeNode root = new TreeNode(list[0].Value);
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int index = 1;

            while (queue.Count > 0 && index < list.Length)
            {
                TreeNode current = queue.Dequeue();

                if (index < list.Length && list[index].HasValue)
                {
                    current.left = new TreeNode(list[index].Value);
                    queue.Enqueue(current.left);
                }
                index++;

                if (index < list.Length && list[index].HasValue)
                {
                    current.right = new TreeNode(list[index].Value);
                    queue.Enqueue(current.right);
                }
                index++;
            }

            return root;
        }

        private void AssertNestedSequence(IList<IList<int>> expected, IList<IList<int>> actual)
        {
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
                Assert.IsTrue(expected[i].SequenceEqual(actual[i]));
        }

        private void AssertFlattened(TreeNode root, params int[] expected)
        {
            int index = 0;
            while (root != null)
            {
                Assert.IsNull(root.left);
                Assert.AreEqual(expected[index++], root.val);
                root = root.right;
            }

            Assert.AreEqual(expected.Length, index);
        }

        [TestMethod]
        public void InorderTraversal_Test1()
        {
            TreeNode root = new TreeNode(1, null, new TreeNode(2, new TreeNode(3)));
            var expectedResult = new List<int> { 1, 3, 2 };
            var actual = trees.InorderTraversal(root);
            Assert.IsTrue(expectedResult.SequenceEqual(actual));
        }

        [TestMethod]
        public void InorderTraversal_Test2()
        {
            TreeNode root = null;
            var expectedResult = new List<int>();
            var actual = trees.InorderTraversal(root);
            Assert.IsTrue(expectedResult.SequenceEqual(actual));
        }

        [TestMethod]
        public void InorderTraversal_Test3()
        {
            TreeNode root = new TreeNode(1);
            var expectedResult = new List<int> { 1 };
            var actual = trees.InorderTraversal(root);
            Assert.IsTrue(expectedResult.SequenceEqual(actual));
        }

        [TestMethod]
        public void InorderTraversal_Test4()
        {
            TreeNode root = new TreeNode(1, new TreeNode(2), new TreeNode(3));
            var expectedResult = new List<int> { 2, 1, 3 };
            var actual = trees.InorderTraversal(root);
            Assert.IsTrue(expectedResult.SequenceEqual(actual));
        }
        [TestMethod]
        public void IsSameTree_Test1()
        {
            TreeNode p = new TreeNode(1, new TreeNode(2), new TreeNode(3));
            TreeNode q = new TreeNode(1, new TreeNode(2), new TreeNode(3));
            Assert.IsTrue(trees.IsSameTree(p, q));
        }

        [TestMethod]
        public void IsSameTree_Test2()
        {
            TreeNode p = new TreeNode(1, new TreeNode(2), null);
            TreeNode q = new TreeNode(1, null, new TreeNode(2));
            Assert.IsFalse(trees.IsSameTree(p, q));
        }

        [TestMethod]
        public void IsSameTree_Test3()
        {
            TreeNode p = new TreeNode(1, new TreeNode(2), new TreeNode(1));
            TreeNode q = new TreeNode(1, new TreeNode(1), new TreeNode(2));
            Assert.IsFalse(trees.IsSameTree(p, q));
        }

        [TestMethod]
        public void IsValidBST_Test1()
        {
            var root = new TreeNode(2, new TreeNode(1), new TreeNode(3));
            Assert.IsTrue(trees.IsValidBST(root));
        }

        [TestMethod]
        public void IsValidBST_Test2()
        {
            var root = new TreeNode(5, new TreeNode(1), new TreeNode(4, new TreeNode(3), new TreeNode(6)));
            Assert.IsFalse(trees.IsValidBST(root));
        }

        [TestMethod]
        public void IsValidBST_Test3()
        {
            var root = new TreeNode(int.MaxValue, new TreeNode(int.MinValue));
            Assert.IsTrue(trees.IsValidBST(root));
            Assert.IsTrue(trees.IsValidBST(null));
        }

        [TestMethod]
        public void RecoverTree_Test1()
        {
            var root = new TreeNode(1, new TreeNode(3, null, new TreeNode(2)));
            trees.RecoverTree(root);
            Assert.IsTrue(trees.IsSameTree(new TreeNode(3, new TreeNode(1, null, new TreeNode(2))), root));
        }

        [TestMethod]
        public void RecoverTree_Test2()
        {
            var root = new TreeNode(3, new TreeNode(1), new TreeNode(4, new TreeNode(2)));
            trees.RecoverTree(root);
            Assert.IsTrue(trees.IsSameTree(new TreeNode(2, new TreeNode(1), new TreeNode(4, new TreeNode(3))), root));
        }

        [TestMethod]
        public void RecoverTree_Test3()
        {
            trees.RecoverTree(null);
            Assert.IsTrue(trees.IsValidBST(null));
        }

        [TestMethod]
        public void IsSymmetric_Test1()
        {
            TreeNode root = new TreeNode(1, new TreeNode(2, new TreeNode(3), new TreeNode(4)), new TreeNode(2, new TreeNode(4), new TreeNode(3)));
            Assert.IsTrue(trees.IsSymmetric(root));
        }

        [TestMethod]
        public void IsSymmetric_Test2()
        {
            TreeNode root = new TreeNode(1, new TreeNode(2, null, new TreeNode(3)), new TreeNode(2, null, new TreeNode(3)));
            Assert.IsFalse(trees.IsSymmetric(root));
        }

        [TestMethod]
        public void IsSymmetric_Test3()
        {
            TreeNode root = new TreeNode(1, new TreeNode(2, null, new TreeNode(3)), new TreeNode(2, new TreeNode(3), null));
            Assert.IsTrue(trees.IsSymmetric(root));
        }

        [TestMethod]
        public void MaxDepth_Test1()
        {
            TreeNode root = new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));
            Assert.AreEqual(3, trees.MaxDepth(root));
        }

        [TestMethod]
        public void MaxDepth_Test2()
        {
            TreeNode root = new TreeNode(1, null, new TreeNode(2));
            Assert.AreEqual(2, trees.MaxDepth(root));
        }

        [TestMethod]
        public void MaxDepth_Test3()
        {
            TreeNode root = null;
            Assert.AreEqual(0, trees.MaxDepth(root));
        }

        [TestMethod]
        public void SortedArrayToBST_Test1()
        {
            int[] nums = new int[] { -10, -3, 0, 5, 9 };
            TreeNode expected = new TreeNode(0, new TreeNode(-10,null, new TreeNode(-3)), new TreeNode(5, null, new TreeNode(9)));
            var actual = trees.SortedArrayToBST(nums);
            Assert.IsTrue(trees.IsSameTree(expected, actual));
        }

        [TestMethod]
        public void SortedArrayToBST_Test2()
        {
            int[] nums = new int[] { 1, 3 };
            TreeNode expected = new TreeNode(1,null, new TreeNode(3));
            var actual = trees.SortedArrayToBST(nums);
            Assert.IsTrue(trees.IsSameTree(expected, actual));
        }

        [TestMethod]
        public void SortedArrayToBST_Test3()
        {
            int[] nums = new int[] { 1, 2, 3, 4, 5 };
            TreeNode expected = new TreeNode(3, new TreeNode(1,null, new TreeNode(2)), new TreeNode(4, null,new TreeNode(5)));
            var actual = trees.SortedArrayToBST(nums);
            Assert.IsTrue(trees.IsSameTree(expected, actual));
        }

        [TestMethod]
        public void IsBalanced_Test1()
        {
            TreeNode root = new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));
            Assert.IsTrue(trees.IsBalanced(root));
        }

        [TestMethod]
        public void IsBalanced_Test2()
        {
            TreeNode root = new TreeNode(1, new TreeNode(2, new TreeNode(3, new TreeNode(4), new TreeNode(4)), new TreeNode(3)), new TreeNode(2));
            Assert.IsFalse(trees.IsBalanced(root));
        }

        [TestMethod]
        public void IsBalanced_Test3()
        {
            TreeNode root = new TreeNode(1, new TreeNode(2, new TreeNode(3, new TreeNode(4), new TreeNode(4)), null), new TreeNode(2));
            Assert.IsFalse(trees.IsBalanced(root));
        }

        [TestMethod]
        public void MinDepth_Test1()
        {
            TreeNode root = new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));
            Assert.AreEqual(2, trees.MinDepth(root));
        }

        [TestMethod]
        public void MinDepth_Test2()
        {
            TreeNode root = new TreeNode(2, null, new TreeNode(3, null, new TreeNode(4, null, new TreeNode(5, null, new TreeNode(6)))));
            Assert.AreEqual(5, trees.MinDepth(root));
        }

        [TestMethod]
        public void MinDepth_Test3()
        {
            TreeNode root = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3));
            Assert.AreEqual(2, trees.MinDepth(root));
        }

        [TestMethod]
        public void HasPathSum_Test1()
        {
            TreeNode root = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3));
            Assert.IsTrue(trees.HasPathSum(root, 7));
        }

        [TestMethod]
        public void HasPathSum_Test2()
        {
            TreeNode root = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3));
            Assert.IsFalse(trees.HasPathSum(root, 1));
        }

        [TestMethod]
        public void HasPathSum_Test3()
        {
            TreeNode root = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3));
            Assert.IsTrue(trees.HasPathSum(root, 8));
        }
        
       
        [TestMethod]
        public void PreorderTraversal_Test1()
        {
            // Arrange
            var root = new TreeNode(1);

            // Act
            var result = trees.PreorderTraversal(root);

            // Assert
            Assert.IsTrue(result.SequenceEqual(new List<int> { 1 }));
        }

        [TestMethod]
        public void PreorderTraversal_Test2()
        {
            // Arrange
            var root = new TreeNode(1,
                new TreeNode(2,
                    new TreeNode(4),
                    new TreeNode(5)),
                new TreeNode(3));

            // Act
            var result = trees.PreorderTraversal(root);

            // Assert
            Assert.IsTrue(result.SequenceEqual(new List<int> { 1, 2, 4, 5, 3 }));
        }        

        [TestMethod]
        public void PreorderTraversal_Test3()
        {
            // Arrange
            var root = new TreeNode(1,
                null,
                new TreeNode(2,
                    null,
                    new TreeNode(3,
                        null,
                        new TreeNode(4))));

            // Act
            var result = trees.PreorderTraversal(root);

            // Assert
            Assert.IsTrue(result.SequenceEqual(new List<int> { 1, 2, 3, 4 }));
        }

        [TestMethod]
        public void PostorderTraversal_Test1()
        {
            // Arrange
            var root = new TreeNode(1);

            // Act
            var result = trees.PostorderTraversal(root);

            // Assert
            Assert.IsTrue(result.SequenceEqual(new List<int> { 1 }));
        }

        [TestMethod]
        public void PostorderTraversal_Test2()
        {
            // Arrange
            var root = new TreeNode(1,
                new TreeNode(2,
                    new TreeNode(4),
                    new TreeNode(5)),
                new TreeNode(3));

            // Act
            var result = trees.PostorderTraversal(root);

            // Assert
            Assert.IsTrue(result.SequenceEqual(new List<int> { 4, 5, 2, 3, 1 }));
        }

        [TestMethod]
        public void PostorderTraversal_Test3()
        {
            // Arrange
            var root = new TreeNode(1,
                new TreeNode(2,
                    new TreeNode(3,
                        new TreeNode(4))));

            // Act
            var result = trees.PostorderTraversal(root);

            // Assert
            Assert.IsTrue(result.SequenceEqual(new List<int> { 4, 3, 2, 1 }));
        }

        [TestMethod]
        public void LevelOrder_Test1()
        {
            TreeNode root = CreateTree(new int?[] { 3, 9, 20, null, null, 15, 7 });
            var expected = new List<IList<int>>
            {
                new List<int> { 3 },
                new List<int> { 9, 20 },
                new List<int> { 15, 7 }
            };

            AssertNestedSequence(expected, trees.LevelOrder(root));
        }

        [TestMethod]
        public void LevelOrder_Test2()
        {
            Assert.AreEqual(0, trees.LevelOrder((TreeNode)null).Count);
            AssertNestedSequence(new List<IList<int>> { new List<int> { 1 } }, trees.LevelOrder(new TreeNode(1)));
        }

        [TestMethod]
        public void ZigzagLevelOrder_Test1()
        {
            TreeNode root = CreateTree(new int?[] { 3, 9, 20, null, null, 15, 7 });
            var expected = new List<IList<int>>
            {
                new List<int> { 3 },
                new List<int> { 20, 9 },
                new List<int> { 15, 7 }
            };

            AssertNestedSequence(expected, trees.ZigzagLevelOrder(root));
        }

        [TestMethod]
        public void ZigzagLevelOrder_Test2()
        {
            TreeNode root = CreateTree(new int?[] { 1, 2, 3, 4, null, null, 5 });
            var expected = new List<IList<int>>
            {
                new List<int> { 1 },
                new List<int> { 3, 2 },
                new List<int> { 4, 5 }
            };

            AssertNestedSequence(expected, trees.ZigzagLevelOrder(root));
            Assert.AreEqual(0, trees.ZigzagLevelOrder(null).Count);
        }

        [TestMethod]
        public void BuildTreeFromPreorderAndInorder_Test1()
        {
            TreeNode expected = CreateTree(new int?[] { 3, 9, 20, null, null, 15, 7 });
            TreeNode actual = trees.BuildTree(new[] { 3, 9, 20, 15, 7 }, new[] { 9, 3, 15, 20, 7 });

            Assert.IsTrue(trees.IsSameTree(expected, actual));
        }

        [TestMethod]
        public void BuildTreeFromPreorderAndInorder_Test2()
        {
            Assert.IsNull(trees.BuildTree(new int[0], new int[0]));
            Assert.IsTrue(trees.IsSameTree(new TreeNode(-1), trees.BuildTree(new[] { -1 }, new[] { -1 })));
        }

        [TestMethod]
        public void BuildTreeFromInorderAndPostorder_Test1()
        {
            TreeNode expected = CreateTree(new int?[] { 3, 9, 20, null, null, 15, 7 });
            TreeNode actual = trees.BuildTreeFromInorderAndPostorder(new[] { 9, 3, 15, 20, 7 }, new[] { 9, 15, 7, 20, 3 });

            Assert.IsTrue(trees.IsSameTree(expected, actual));
        }

        [TestMethod]
        public void BuildTreeFromInorderAndPostorder_Test2()
        {
            Assert.IsNull(trees.BuildTreeFromInorderAndPostorder(new int[0], new int[0]));
            Assert.IsTrue(trees.IsSameTree(new TreeNode(-1), trees.BuildTreeFromInorderAndPostorder(new[] { -1 }, new[] { -1 })));
        }

        [TestMethod]
        public void LevelOrderBottom_Test1()
        {
            TreeNode root = CreateTree(new int?[] { 3, 9, 20, null, null, 15, 7 });
            var expected = new List<IList<int>>
            {
                new List<int> { 15, 7 },
                new List<int> { 9, 20 },
                new List<int> { 3 }
            };

            AssertNestedSequence(expected, trees.LevelOrderBottom(root));
        }

        [TestMethod]
        public void LevelOrderBottom_Test2()
        {
            Assert.AreEqual(0, trees.LevelOrderBottom(null).Count);
            AssertNestedSequence(new List<IList<int>> { new List<int> { 1 } }, trees.LevelOrderBottom(new TreeNode(1)));
        }

        [TestMethod]
        public void PathSum_Test1()
        {
            TreeNode root = CreateTree(new int?[] { 5, 4, 8, 11, null, 13, 4, 7, 2, null, null, 5, 1 });
            var expected = new List<IList<int>>
            {
                new List<int> { 5, 4, 11, 2 },
                new List<int> { 5, 8, 4, 5 }
            };

            AssertNestedSequence(expected, trees.PathSum(root, 22));
        }

        [TestMethod]
        public void PathSum_Test2()
        {
            TreeNode root = new TreeNode(-2, null, new TreeNode(-3));

            AssertNestedSequence(new List<IList<int>> { new List<int> { -2, -3 } }, trees.PathSum(root, -5));
            Assert.AreEqual(0, trees.PathSum(null, 0).Count);
        }

        [TestMethod]
        public void Flatten_Test1()
        {
            TreeNode root = CreateTree(new int?[] { 1, 2, 5, 3, 4, null, 6 });

            trees.Flatten(root);

            AssertFlattened(root, 1, 2, 3, 4, 5, 6);
        }

        [TestMethod]
        public void Flatten_Test2()
        {
            TreeNode root = new TreeNode(1, new TreeNode(2));

            trees.Flatten(null);
            trees.Flatten(root);

            AssertFlattened(root, 1, 2);
        }

        [TestMethod]
        public void Connect_Test1()
        {
            Node root = new Node(1,
                new Node(2, new Node(4), new Node(5)),
                new Node(3, new Node(6), new Node(7)));

            Node actual = trees.Connect(root);

            Assert.AreSame(root, actual);
            Assert.IsNull(root.next);
            Assert.AreSame(root.right, root.left.next);
            Assert.IsNull(root.right.next);
            Assert.AreSame(root.left.right, root.left.left.next);
            Assert.AreSame(root.right.left, root.left.right.next);
            Assert.AreSame(root.right.right, root.right.left.next);
            Assert.IsNull(root.right.right.next);
        }

        [TestMethod]
        public void Connect_Test2()
        {
            Node root = new Node(1,
                new Node(2, null, new Node(5)),
                new Node(3, null, new Node(7)));

            Assert.IsNull(trees.Connect(null));
            trees.Connect(root);

            Assert.AreSame(root.right, root.left.next);
            Assert.AreSame(root.right.right, root.left.right.next);
            Assert.IsNull(root.right.right.next);
        }

        [TestMethod]
        public void MaxPathSum_Test1()
        {
            TreeNode root = new TreeNode(-10, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));

            Assert.AreEqual(42, trees.MaxPathSum(root));
        }

        [TestMethod]
        public void MaxPathSum_Test2()
        {
            TreeNode root = new TreeNode(-3);

            Assert.AreEqual(-3, trees.MaxPathSum(root));
        }

        [TestMethod]
        public void SumNumbers_Test1()
        {
            TreeNode root = new TreeNode(1, new TreeNode(2), new TreeNode(3));

            Assert.AreEqual(25, trees.SumNumbers(root));
        }

        [TestMethod]
        public void SumNumbers_Test2()
        {
            TreeNode root = CreateTree(new int?[] { 4, 9, 0, 5, 1 });

            Assert.AreEqual(1026, trees.SumNumbers(root));
            Assert.AreEqual(0, trees.SumNumbers(null));
        }

        [TestMethod]
        public void BSTIterator_Test1()
        {
            TreeNode root = new TreeNode(7, new TreeNode(3), new TreeNode(15, new TreeNode(9), new TreeNode(20)));
            var iterator = new BSTIterator(root);

            Assert.AreEqual(3, iterator.Next());
            Assert.AreEqual(7, iterator.Next());
            Assert.IsTrue(iterator.HasNext());
            Assert.AreEqual(9, iterator.Next());
            Assert.IsTrue(iterator.HasNext());
            Assert.AreEqual(15, iterator.Next());
            Assert.IsTrue(iterator.HasNext());
            Assert.AreEqual(20, iterator.Next());
            Assert.IsFalse(iterator.HasNext());
        }

        [TestMethod]
        public void BSTIterator_Test2()
        {
            var iterator = new BSTIterator(null);

            Assert.IsFalse(iterator.HasNext());
        }

        [TestMethod]
        public void RightSideView_Test1()
        {
            TreeNode root = CreateTree(new int?[] { 1, 2, 3, null, 5, null, 4 });

            Assert.IsTrue(new List<int> { 1, 3, 4 }.SequenceEqual(trees.RightSideView(root)));
        }

        [TestMethod]
        public void RightSideView_Test2()
        {
            TreeNode root = new TreeNode(1, new TreeNode(2, new TreeNode(3)));

            Assert.IsTrue(new List<int> { 1, 2, 3 }.SequenceEqual(trees.RightSideView(root)));
            Assert.AreEqual(0, trees.RightSideView(null).Count);
        }

        [TestMethod]
        public void CountNodes_Test1()
        {
            Assert.AreEqual(6, trees.CountNodes(CreateTree(new int?[] { 1, 2, 3, 4, 5, 6 })));
            Assert.AreEqual(0, trees.CountNodes(null));
            Assert.AreEqual(1, trees.CountNodes(new TreeNode(1)));
        }

        [TestMethod]
        public void InvertTree_Test1()
        {
            TreeNode root = CreateTree(new int?[] { 4, 2, 7, 1, 3, 6, 9 });
            TreeNode expected = CreateTree(new int?[] { 4, 7, 2, 9, 6, 3, 1 });

            Assert.IsTrue(trees.IsSameTree(expected, trees.InvertTree(root)));
            Assert.IsNull(trees.InvertTree(null));
        }

        [TestMethod]
        public void KthSmallest_Test1()
        {
            Assert.AreEqual(1, trees.KthSmallest(CreateTree(new int?[] { 3, 1, 4, null, 2 }), 1));
            Assert.AreEqual(3, trees.KthSmallest(CreateTree(new int?[] { 5, 3, 6, 2, 4, null, null, 1 }), 3));
        }

        [TestMethod]
        public void LowestCommonAncestorBST_Test1()
        {
            TreeNode p = new TreeNode(2, new TreeNode(0), new TreeNode(4, new TreeNode(3), new TreeNode(5)));
            TreeNode q = new TreeNode(8, new TreeNode(7), new TreeNode(9));
            TreeNode root = new TreeNode(6, p, q);

            Assert.AreSame(root, trees.LowestCommonAncestorBST(root, p, q));
            Assert.AreSame(p, trees.LowestCommonAncestorBST(root, p, p.right));
        }

        [TestMethod]
        public void LowestCommonAncestor_Test1()
        {
            TreeNode node7 = new TreeNode(7);
            TreeNode node4 = new TreeNode(4);
            TreeNode node2 = new TreeNode(2, node7, node4);
            TreeNode node5 = new TreeNode(5, new TreeNode(6), node2);
            TreeNode node1 = new TreeNode(1, new TreeNode(0), new TreeNode(8));
            TreeNode root = new TreeNode(3, node5, node1);

            Assert.AreSame(root, trees.LowestCommonAncestor(root, node5, node1));
            Assert.AreSame(node5, trees.LowestCommonAncestor(root, node5, node4));
        }

        [TestMethod]
        public void BinaryTreePaths_Test1()
        {
            CollectionAssert.AreEquivalent(new List<string> { "1->2->5", "1->3" }, trees.BinaryTreePaths(CreateTree(new int?[] { 1, 2, 3, null, 5 })).ToList());
            CollectionAssert.AreEqual(new List<string>(), trees.BinaryTreePaths(null).ToList());
        }

        [TestMethod]
        public void IsValidSerialization_Test1()
        {
            Assert.IsTrue(trees.IsValidSerialization("9,3,4,#,#,1,#,#,2,#,6,#,#"));
            Assert.IsFalse(trees.IsValidSerialization("1,#"));
            Assert.IsTrue(trees.IsValidSerialization("#"));
        }

        [TestMethod]
        public void Rob_Test1()
        {
            Assert.AreEqual(7, trees.Rob(CreateTree(new int?[] { 3, 2, 3, null, 3, null, 1 })));
            Assert.AreEqual(0, trees.Rob(null));
        }

        [TestMethod]
        public void SumOfLeftLeaves_Test1()
        {
            Assert.AreEqual(24, trees.SumOfLeftLeaves(CreateTree(new int?[] { 3, 9, 20, null, null, 15, 7 })));
            Assert.AreEqual(0, trees.SumOfLeftLeaves(new TreeNode(1)));
        }

        [TestMethod]
        public void LevelOrder_NaryTree_Test1()
        {
            Node root = new Node(1, new List<Node>
            {
                new Node(3, new List<Node> { new Node(5), new Node(6) }),
                new Node(2),
                new Node(4)
            });
            var expected = new List<IList<int>>
            {
                new List<int> { 1 },
                new List<int> { 3, 2, 4 },
                new List<int> { 5, 6 }
            };

            AssertNestedSequence(expected, trees.LevelOrder(root));
            Assert.AreEqual(0, trees.LevelOrder((Node)null).Count);
        }

        [TestMethod]
        public void PathSumIII_Test1()
        {
            Assert.AreEqual(3, trees.PathSumIII(CreateTree(new int?[] { 10, 5, -3, 3, 2, null, 11, 3, -2, null, 1 }), 8));
            Assert.AreEqual(0, trees.PathSumIII(null, 0));
        }

        [TestMethod]
        public void DeleteNode_Test1()
        {
            TreeNode root = trees.DeleteNode(CreateTree(new int?[] { 5, 3, 6, 2, 4, null, 7 }), 3);
            Assert.IsTrue(trees.IsValidBST(root));
            Assert.IsFalse(trees.InorderTraversal(root).Contains(3));
            Assert.IsTrue(trees.IsSameTree(new TreeNode(1), trees.DeleteNode(new TreeNode(1, null, new TreeNode(2)), 2)));
        }

        [TestMethod]
        public void FindMode_Test1()
        {
            CollectionAssert.AreEqual(new[] { 2 }, trees.FindMode(new TreeNode(1, null, new TreeNode(2, new TreeNode(2)))));
            CollectionAssert.AreEquivalent(new[] { 1, 2 }, trees.FindMode(CreateTree(new int?[] { 1, null, 2 })));
        }

        [TestMethod]
        public void FindBottomLeftValue_Test1()
        {
            Assert.AreEqual(1, trees.FindBottomLeftValue(CreateTree(new int?[] { 2, 1, 3 })));
            Assert.AreEqual(7, trees.FindBottomLeftValue(CreateTree(new int?[] { 1, 2, 3, 4, null, 5, 6, null, null, 7 })));
        }

        [TestMethod]
        public void LargestValues_Test1()
        {
            Assert.IsTrue(new List<int> { 1, 3, 9 }.SequenceEqual(trees.LargestValues(CreateTree(new int?[] { 1, 3, 2, 5, 3, null, 9 }))));
            Assert.AreEqual(0, trees.LargestValues(null).Count);
        }

        [TestMethod]
        public void GetMinimumDifference_Test1()
        {
            Assert.AreEqual(1, trees.GetMinimumDifference(CreateTree(new int?[] { 4, 2, 6, 1, 3 })));
            Assert.AreEqual(1, trees.GetMinimumDifference(new TreeNode(1, null, new TreeNode(3, new TreeNode(2)))));
        }

        [TestMethod]
        public void ConvertBST_Test1()
        {
            TreeNode root = trees.ConvertBST(CreateTree(new int?[] { 4, 1, 6, 0, 2, 5, 7, null, null, null, 3, null, null, null, 8 }));
            Assert.IsTrue(trees.IsSameTree(CreateTree(new int?[] { 30, 36, 21, 36, 35, 26, 15, null, null, null, 33, null, null, null, 8 }), root));
            Assert.IsNull(trees.ConvertBST(null));
        }

        [TestMethod]
        public void DiameterOfBinaryTree_Test1()
        {
            Assert.AreEqual(3, trees.DiameterOfBinaryTree(CreateTree(new int?[] { 1, 2, 3, 4, 5 })));
            Assert.AreEqual(0, trees.DiameterOfBinaryTree(new TreeNode(1)));
        }

        [TestMethod]
        public void MaxDepth_NaryTree_Test1()
        {
            Node root = new Node(1, new List<Node>
            {
                new Node(3, new List<Node> { new Node(5), new Node(6) }),
                new Node(2),
                new Node(4)
            });

            Assert.AreEqual(3, trees.MaxDepth(root));
            Assert.AreEqual(0, trees.MaxDepth((Node)null));
        }

        [TestMethod]
        public void FindTilt_Test1()
        {
            Assert.AreEqual(1, trees.FindTilt(CreateTree(new int?[] { 1, 2, 3 })));
            Assert.AreEqual(15, trees.FindTilt(CreateTree(new int?[] { 4, 2, 9, 3, 5, null, 7 })));
        }

        [TestMethod]
        public void IsSubtree_Test1()
        {
            Assert.IsTrue(trees.IsSubtree(CreateTree(new int?[] { 3, 4, 5, 1, 2 }), CreateTree(new int?[] { 4, 1, 2 })));
            Assert.IsFalse(trees.IsSubtree(CreateTree(new int?[] { 3, 4, 5, 1, 2, null, null, null, null, 0 }), CreateTree(new int?[] { 4, 1, 2 })));
        }

        [TestMethod]
        public void NaryPreorder_Test1()
        {
            Node root = new Node(1, new List<Node>
            {
                new Node(3, new List<Node> { new Node(5), new Node(6) }),
                new Node(2),
                new Node(4)
            });

            Assert.IsTrue(new List<int> { 1, 3, 5, 6, 2, 4 }.SequenceEqual(trees.Preorder(root)));
            Assert.AreEqual(0, trees.Preorder((Node)null).Count);
        }

        [TestMethod]
        public void NaryPostorder_Test1()
        {
            Node root = new Node(1, new List<Node>
            {
                new Node(3, new List<Node> { new Node(5), new Node(6) }),
                new Node(2),
                new Node(4)
            });

            Assert.IsTrue(new List<int> { 5, 6, 3, 2, 4, 1 }.SequenceEqual(trees.Postorder(root)));
            Assert.AreEqual(0, trees.Postorder((Node)null).Count);
        }

        [TestMethod]
        public void Tree2str_Test1()
        {
            Assert.AreEqual("1(2(4))(3)", trees.Tree2str(CreateTree(new int?[] { 1, 2, 3, 4 })));
            Assert.AreEqual("1()(2)", trees.Tree2str(new TreeNode(1, null, new TreeNode(2))));
            Assert.AreEqual(string.Empty, trees.Tree2str(null));
        }

        [TestMethod]
        public void MergeTrees_Test1()
        {
            TreeNode merged = trees.MergeTrees(CreateTree(new int?[] { 1, 3, 2, 5 }), CreateTree(new int?[] { 2, 1, 3, null, 4, null, 7 }));
            Assert.IsTrue(trees.IsSameTree(CreateTree(new int?[] { 3, 4, 5, 5, 4, null, 7 }), merged));
            Assert.IsTrue(trees.IsSameTree(new TreeNode(1), trees.MergeTrees(null, new TreeNode(1))));
        }

        [TestMethod]
        public void AverageOfLevels_Test1()
        {
            CollectionAssert.AreEqual(new List<double> { 3, 14.5, 11 }, trees.AverageOfLevels(CreateTree(new int?[] { 3, 9, 20, null, null, 15, 7 })).ToList());
            Assert.AreEqual(0, trees.AverageOfLevels(null).Count);
        }

        [TestMethod]
        public void FindTarget_Test1()
        {
            Assert.IsTrue(trees.FindTarget(CreateTree(new int?[] { 5, 3, 6, 2, 4, null, 7 }), 9));
            Assert.IsFalse(trees.FindTarget(CreateTree(new int?[] { 5, 3, 6, 2, 4, null, 7 }), 28));
        }

        [TestMethod]
        public void TrimBST_Test1()
        {
            TreeNode trimmed = trees.TrimBST(CreateTree(new int?[] { 1, 0, 2 }), 1, 2);
            Assert.IsTrue(trees.IsSameTree(CreateTree(new int?[] { 1, null, 2 }), trimmed));
            Assert.IsNull(trees.TrimBST(new TreeNode(1), 2, 3));
        }

        [TestMethod]
        public void FindSecondMinimumValue_Test1()
        {
            Assert.AreEqual(5, trees.FindSecondMinimumValue(CreateTree(new int?[] { 2, 2, 5, null, null, 5, 7 })));
            Assert.AreEqual(-1, trees.FindSecondMinimumValue(CreateTree(new int?[] { 2, 2, 2 })));
        }

        [TestMethod]
        public void LongestUnivaluePath_Test1()
        {
            Assert.AreEqual(2, trees.LongestUnivaluePath(CreateTree(new int?[] { 5, 4, 5, 1, 1, null, 5 })));
            Assert.AreEqual(0, trees.LongestUnivaluePath(null));
        }

        [TestMethod]
        public void InsertIntoBST_Test1()
        {
            TreeNode root = trees.InsertIntoBST(CreateTree(new int?[] { 4, 2, 7, 1, 3 }), 5);
            Assert.IsTrue(trees.IsValidBST(root));
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 7 }, trees.InorderTraversal(root).ToList());
            Assert.AreEqual(8, trees.InsertIntoBST(null, 8).val);
        }

        [TestMethod]
        public void MinDiffInBST_Test1()
        {
            Assert.AreEqual(1, trees.MinDiffInBST(CreateTree(new int?[] { 4, 2, 6, 1, 3 })));
            Assert.AreEqual(5, trees.MinDiffInBST(CreateTree(new int?[] { 10, 5, 15 })));
        }

        [TestMethod]
        public void PruneTree_Test1()
        {
            Assert.IsTrue(trees.IsSameTree(CreateTree(new int?[] { 1, null, 0, null, 1 }), trees.PruneTree(CreateTree(new int?[] { 1, null, 0, 0, 1 }))));
            Assert.IsNull(trees.PruneTree(CreateTree(new int?[] { 0, 0, 0 })));
        }

        [TestMethod]
        public void DistanceK_Test1()
        {
            TreeNode root = CreateTree(new int?[] { 3, 5, 1, 6, 2, 0, 8, null, null, 7, 4 });
            CollectionAssert.AreEquivalent(new List<int> { 7, 4, 1 }, trees.DistanceK(root, root.left, 2).ToList());
            CollectionAssert.AreEqual(new List<int> { 5 }, trees.DistanceK(root, root.left, 0).ToList());
        }

        [TestMethod]
        public void LeafSimilar_Test1()
        {
            Assert.IsTrue(trees.LeafSimilar(CreateTree(new int?[] { 3, 5, 1, 6, 2, 9, 8, null, null, 7, 4 }), CreateTree(new int?[] { 3, 5, 1, 6, 7, 4, 2, null, null, null, null, null, null, 9, 8 })));
            Assert.IsFalse(trees.LeafSimilar(new TreeNode(1), new TreeNode(2)));
        }

        [TestMethod]
        public void ConstructFromPrePost_Test1()
        {
            TreeNode root = trees.ConstructFromPrePost(new[] { 1, 2, 4, 5, 3, 6, 7 }, new[] { 4, 5, 2, 6, 7, 3, 1 });
            CollectionAssert.AreEqual(new List<int> { 1, 2, 4, 5, 3, 6, 7 }, trees.PreorderTraversal(root).ToList());
            Assert.IsTrue(trees.IsSameTree(new TreeNode(1), trees.ConstructFromPrePost(new[] { 1 }, new[] { 1 })));
        }

        [TestMethod]
        public void IncreasingBST_Test1()
        {
            AssertFlattened(trees.IncreasingBST(CreateTree(new int?[] { 5, 3, 6, 2, 4, null, 8, 1, null, null, null, 7, 9 })), 1, 2, 3, 4, 5, 6, 7, 8, 9);
            Assert.IsNull(trees.IncreasingBST(null));
        }

        [TestMethod]
        public void CBTInserter_Test1()
        {
            var inserter = new CBTInserter(CreateTree(new int?[] { 1, 2 }));
            Assert.AreEqual(1, inserter.Insert(3));
            Assert.AreEqual(2, inserter.Insert(4));
            Assert.IsTrue(trees.IsSameTree(CreateTree(new int?[] { 1, 2, 3, 4 }), inserter.Get_root()));
        }

        [TestMethod]
        public void RangeSumBST_Test1()
        {
            Assert.AreEqual(32, trees.RangeSumBST(CreateTree(new int?[] { 10, 5, 15, 3, 7, null, 18 }), 7, 15));
            Assert.AreEqual(0, trees.RangeSumBST(null, 1, 2));
        }

        [TestMethod]
        public void FlipEquiv_Test1()
        {
            Assert.IsTrue(trees.FlipEquiv(CreateTree(new int?[] { 1, 2, 3, 4, 5, 6, null, null, null, 7, 8 }), CreateTree(new int?[] { 1, 3, 2, null, 6, 4, 5, null, null, null, null, 8, 7 })));
            Assert.IsFalse(trees.FlipEquiv(new TreeNode(1), new TreeNode(2)));
        }

        [TestMethod]
        public void IsCompleteTree_Test1()
        {
            Assert.IsTrue(trees.IsCompleteTree(CreateTree(new int?[] { 1, 2, 3, 4, 5, 6 })));
            Assert.IsFalse(trees.IsCompleteTree(CreateTree(new int?[] { 1, 2, 3, 4, 5, null, 7 })));
        }

        [TestMethod]
        public void IsUnivalTree_Test1()
        {
            Assert.IsTrue(trees.IsUnivalTree(CreateTree(new int?[] { 1, 1, 1, 1, 1, null, 1 })));
            Assert.IsFalse(trees.IsUnivalTree(CreateTree(new int?[] { 2, 2, 2, 5, 2 })));
        }

        [TestMethod]
        public void MinCameraCover_Test1()
        {
            Assert.AreEqual(1, trees.MinCameraCover(CreateTree(new int?[] { 0, 0, null, 0, 0 })));
            Assert.AreEqual(1, trees.MinCameraCover(new TreeNode(0)));
        }

        [TestMethod]
        public void FlipMatchVoyage_Test1()
        {
            CollectionAssert.AreEqual(new List<int> { 1 }, trees.FlipMatchVoyage(CreateTree(new int?[] { 1, 2, 3 }), new[] { 1, 3, 2 }).ToList());
            CollectionAssert.AreEqual(new List<int> { -1 }, trees.FlipMatchVoyage(CreateTree(new int?[] { 1, 2 }), new[] { 2, 1 }).ToList());
        }

        [TestMethod]
        public void DistributeCoins_Test1()
        {
            Assert.AreEqual(2, trees.DistributeCoins(CreateTree(new int?[] { 3, 0, 0 })));
            Assert.AreEqual(0, trees.DistributeCoins(new TreeNode(1)));
        }

        [TestMethod]
        public void VerticalTraversal_Test1()
        {
            AssertNestedSequence(new List<IList<int>> { new List<int> { 9 }, new List<int> { 3, 15 }, new List<int> { 20 }, new List<int> { 7 } }, trees.VerticalTraversal(CreateTree(new int?[] { 3, 9, 20, null, null, 15, 7 })));
            AssertNestedSequence(new List<IList<int>> { new List<int> { 4 }, new List<int> { 2 }, new List<int> { 1, 5, 6 }, new List<int> { 3 }, new List<int> { 7 } }, trees.VerticalTraversal(CreateTree(new int?[] { 1, 2, 3, 4, 6, 5, 7 })));
        }

        [TestMethod]
        public void SmallestFromLeaf_Test1()
        {
            Assert.AreEqual("dba", trees.SmallestFromLeaf(CreateTree(new int?[] { 0, 1, 2, 3, 4, 3, 4 })));
            Assert.AreEqual("z", trees.SmallestFromLeaf(new TreeNode(25)));
        }

        [TestMethod]
        public void IsCousins_Test1()
        {
            Assert.IsTrue(trees.IsCousins(CreateTree(new int?[] { 1, 2, 3, null, 4, null, 5 }), 5, 4));
            Assert.IsFalse(trees.IsCousins(CreateTree(new int?[] { 1, 2, 3, 4 }), 4, 3));
        }

        [TestMethod]
        public void InsertIntoMaxTree_Test1()
        {
            TreeNode promoted = trees.InsertIntoMaxTree(CreateTree(new int?[] { 4, 1, 3, null, null, 2 }), 5);
            Assert.AreEqual(5, promoted.val);
            Assert.IsTrue(trees.IsSameTree(CreateTree(new int?[] { 4, 1, 3, null, null, 2 }), promoted.left));
            Assert.IsTrue(trees.IsSameTree(CreateTree(new int?[] { 5, 2, 4, null, 1, 3 }), trees.InsertIntoMaxTree(CreateTree(new int?[] { 5, 2, 3, null, 1 }), 4)));
        }

        [TestMethod]
        public void SumRootToLeaf_Test1()
        {
            Assert.AreEqual(22, trees.SumRootToLeaf(CreateTree(new int?[] { 1, 0, 1, 0, 1, 0, 1 })));
            Assert.AreEqual(0, trees.SumRootToLeaf(null));
        }

        [TestMethod]
        public void MaxAncestorDiff_Test1()
        {
            Assert.AreEqual(7, trees.MaxAncestorDiff(CreateTree(new int?[] { 8, 3, 10, 1, 6, null, 14, null, null, 4, 7, 13 })));
            Assert.AreEqual(0, trees.MaxAncestorDiff(new TreeNode(1)));
        }

        [TestMethod]
        public void SufficientSubset_Test1()
        {
            Assert.IsTrue(trees.IsSameTree(CreateTree(new int?[] { 1, null, -3, 4 }), trees.SufficientSubset(CreateTree(new int?[] { 1, 2, -3, -5, null, 4, null }), -1)));
            Assert.IsNull(trees.SufficientSubset(new TreeNode(1), 2));
        }

        [TestMethod]
        public void PathInZigZagTree_Test1()
        {
            CollectionAssert.AreEqual(new List<int> { 1, 3, 4, 14 }, trees.PathInZigZagTree(14).ToList());
            CollectionAssert.AreEqual(new List<int> { 1 }, trees.PathInZigZagTree(1).ToList());
        }

        [TestMethod]
        public void DelNodes_Test1()
        {
            IList<TreeNode> forest = trees.DelNodes(CreateTree(new int?[] { 1, 2, 3, 4, 5, 6, 7 }), new[] { 3, 5 });
            CollectionAssert.AreEquivalent(new List<int> { 1, 6, 7 }, forest.Select(node => node.val).ToList());
            CollectionAssert.AreEquivalent(new List<int> { 2, 3 }, trees.DelNodes(CreateTree(new int?[] { 1, 2, 3 }), new[] { 1 }).Select(node => node.val).ToList());
        }

        [TestMethod]
        public void LcaDeepestLeaves_Test1()
        {
            Assert.AreEqual(2, trees.LcaDeepestLeaves(CreateTree(new int?[] { 3, 5, 1, 6, 2, 0, 8, null, null, 7, 4 })).val);
            Assert.AreEqual(1, trees.LcaDeepestLeaves(new TreeNode(1)).val);
        }

        [TestMethod]
        public void SubtreeWithAllDeepest_Test1()
        {
            Assert.AreEqual(2, trees.SubtreeWithAllDeepest(CreateTree(new int?[] { 3, 5, 1, 6, 2, 0, 8, null, null, 7, 4 })).val);
            Assert.AreEqual(1, trees.SubtreeWithAllDeepest(new TreeNode(1)).val);
        }

        [TestMethod]
        public void AllPossibleFBT_Test1()
        {
            Assert.AreEqual(5, trees.AllPossibleFBT(7).Count);
            Assert.AreEqual(0, trees.AllPossibleFBT(2).Count);
        }

        [TestMethod]
        public void BstFromPreorder_Test1()
        {
            TreeNode root = trees.BstFromPreorder(new[] { 8, 5, 1, 7, 10, 12 });
            CollectionAssert.AreEqual(new List<int> { 1, 5, 7, 8, 10, 12 }, trees.InorderTraversal(root).ToList());
            Assert.IsNull(trees.BstFromPreorder(new int[0]));
        }

        [TestMethod]
        public void RecoverFromPreorder_Test1()
        {
            Assert.IsTrue(trees.IsSameTree(CreateTree(new int?[] { 1, 2, 5, 3, 4, 6, 7 }), trees.RecoverFromPreorder("1-2--3--4-5--6--7")));
            Assert.IsTrue(trees.IsSameTree(new TreeNode(10), trees.RecoverFromPreorder("10")));
        }

        [TestMethod]
        public void BstToGst_Test1()
        {
            Assert.IsTrue(trees.IsSameTree(CreateTree(new int?[] { 30, 36, 21, 36, 35, 26, 15, null, null, null, 33, null, null, null, 8 }), trees.BstToGst(CreateTree(new int?[] { 4, 1, 6, 0, 2, 5, 7, null, null, null, 3, null, null, null, 8 }))));
            Assert.IsNull(trees.BstToGst(null));
        }

        [TestMethod]
        public void MaxProduct_Test1()
        {
            Assert.AreEqual(110, trees.MaxProduct(CreateTree(new int?[] { 1, 2, 3, 4, 5, 6 })));
            Assert.AreEqual(0, trees.MaxProduct(new TreeNode(1)));
        }

        [TestMethod]
        public void ValidateBinaryTreeNodes_Test1()
        {
            Assert.IsTrue(trees.ValidateBinaryTreeNodes(4, new[] { 1, -1, 3, -1 }, new[] { 2, -1, -1, -1 }));
            Assert.IsFalse(trees.ValidateBinaryTreeNodes(4, new[] { 1, -1, 3, -1 }, new[] { 2, 3, -1, -1 }));
        }

        [TestMethod]
        public void FindRoot_Test1()
        {
            Node child = new Node(2);
            Node root = new Node(1, new List<Node> { child, new Node(3) });
            Assert.AreSame(root, trees.FindRoot(new List<Node> { child, root, root.children[1] }));
            Assert.IsNull(trees.FindRoot(new List<Node>()));
        }

        [TestMethod]
        public void BtreeGameWinningMove_Test1()
        {
            Assert.IsTrue(trees.BtreeGameWinningMove(CreateTree(new int?[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }), 11, 3));
            Assert.IsFalse(trees.BtreeGameWinningMove(new TreeNode(1), 1, 1));
        }

        [TestMethod]
        public void MaxLevelSum_Test1()
        {
            Assert.AreEqual(3, trees.MaxLevelSum(CreateTree(new int?[] { -100, -200, -300, -20, -5, -10, null })));
            Assert.AreEqual(1, trees.MaxLevelSum(new TreeNode(7)));
        }

        [TestMethod]
        public void FindElements_Test1()
        {
            var finder = new FindElements(CreateTree(new int?[] { -1, null, -1 }));
            Assert.IsTrue(finder.Find(2));
            Assert.IsFalse(finder.Find(1));
        }

        [TestMethod]
        public void DeepestLeavesSum_Test1()
        {
            Assert.AreEqual(15, trees.DeepestLeavesSum(CreateTree(new int?[] { 1, 2, 3, 4, 5, null, 6, 7, null, null, null, null, 8 })));
            Assert.AreEqual(0, trees.DeepestLeavesSum(null));
        }

        [TestMethod]
        public void GetAllElements_Test1()
        {
            CollectionAssert.AreEqual(new List<int> { 0, 1, 1, 2, 3, 4 }, trees.GetAllElements(CreateTree(new int?[] { 2, 1, 4 }), CreateTree(new int?[] { 1, 0, 3 })).ToList());
            CollectionAssert.AreEqual(new List<int> { 1, 5, 8 }, trees.GetAllElements(null, CreateTree(new int?[] { 5, 1, 8 })).ToList());
        }

        [TestMethod]
        public void SumEvenGrandparent_Test1()
        {
            Assert.AreEqual(18, trees.SumEvenGrandparent(CreateTree(new int?[] { 6, 7, 8, 2, 7, 1, 3, 9, null, 1, 4, null, null, null, 5 })));
            Assert.AreEqual(0, trees.SumEvenGrandparent(new TreeNode(2)));
        }

        [TestMethod]
        public void RemoveLeafNodes_Test1()
        {
            Assert.IsTrue(trees.IsSameTree(CreateTree(new int?[] { 1, null, 3, null, 4 }), trees.RemoveLeafNodes(CreateTree(new int?[] { 1, 2, 3, 2, null, 2, 4 }), 2)));
            Assert.IsNull(trees.RemoveLeafNodes(CreateTree(new int?[] { 1, 1, 1 }), 1));
        }

        [TestMethod]
        public void IsSubPath_Test1()
        {
            ListNode head = new ListNode(4, new ListNode(2, new ListNode(8)));
            Assert.IsTrue(trees.IsSubPath(head, CreateTree(new int?[] { 1, 4, 4, null, 2, 2, null, 1, null, 6, 8, null, null, null, null, 1, 3 })));
            Assert.IsFalse(trees.IsSubPath(new ListNode(1, new ListNode(4, new ListNode(2, new ListNode(9)))), CreateTree(new int?[] { 1, 4, 4, null, 2, 2, null, 1, null, 6, 8 })));
        }

        [TestMethod]
        public void LongestZigZag_Test1()
        {
            Assert.AreEqual(3, trees.LongestZigZag(new TreeNode(1, null, new TreeNode(1, new TreeNode(1, null, new TreeNode(1))))));
            Assert.AreEqual(0, trees.LongestZigZag(null));
        }

        [TestMethod]
        public void MaxSumBST_Test1()
        {
            Assert.AreEqual(20, trees.MaxSumBST(CreateTree(new int?[] { 1, 4, 3, 2, 4, 2, 5, null, null, null, null, null, null, 4, 6 })));
            Assert.AreEqual(0, trees.MaxSumBST(new TreeNode(-4, new TreeNode(-2), new TreeNode(-5))));
        }

        [TestMethod]
        public void GetTargetCopy_Test1()
        {
            TreeNode original = CreateTree(new int?[] { 7, 4, 3, null, null, 6, 19 });
            TreeNode cloned = CreateTree(new int?[] { 7, 4, 3, null, null, 6, 19 });
            TreeNode found = trees.GetTargetCopy(original, cloned, original.right);
            Assert.AreEqual(3, found.val);
            Assert.AreNotSame(original.right, found);
        }

        [TestMethod]
        public void BalanceBST_Test1()
        {
            TreeNode balanced = trees.BalanceBST(CreateTree(new int?[] { 1, null, 2, null, 3, null, 4 }));
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4 }, trees.InorderTraversal(balanced).ToList());
            Assert.IsTrue(trees.IsBalanced(balanced));
        }

        [TestMethod]
        public void GoodNodes_Test1()
        {
            Assert.AreEqual(4, trees.GoodNodes(CreateTree(new int?[] { 3, 1, 4, 3, null, 1, 5 })));
            Assert.AreEqual(0, trees.GoodNodes(null));
        }

        [TestMethod]
        public void PseudoPalindromicPaths_Test1()
        {
            Assert.AreEqual(2, trees.PseudoPalindromicPaths(CreateTree(new int?[] { 2, 3, 1, 3, 1, null, 1 })));
            Assert.AreEqual(1, trees.PseudoPalindromicPaths(new TreeNode(9)));
        }

        [TestMethod]
        public void TreeAncestor_Test1()
        {
            var treeAncestor = new TreeAncestor(7, new[] { -1, 0, 0, 1, 1, 2, 2 });
            Assert.AreEqual(1, treeAncestor.GetKthAncestor(3, 1));
            Assert.AreEqual(-1, treeAncestor.GetKthAncestor(6, 3));
        }

        [TestMethod]
        public void CountPairs_Test1()
        {
            Assert.AreEqual(1, trees.CountPairs(CreateTree(new int?[] { 1, 2, 3, null, 4 }), 3));
            Assert.AreEqual(0, trees.CountPairs(new TreeNode(1), 2));
        }

        [TestMethod]
        public void IsEvenOddTree_Test1()
        {
            Assert.IsTrue(trees.IsEvenOddTree(CreateTree(new int?[] { 1, 10, 4, 3, null, 7, 9, 12, 8, 6, null, null, 2 })));
            Assert.IsFalse(trees.IsEvenOddTree(CreateTree(new int?[] { 5, 4, 2, 3, 3, 7 })));
        }

        [TestMethod]
        public void CanMerge_Test1()
        {
            TreeNode merged = trees.CanMerge(new List<TreeNode>
            {
                new TreeNode(2, new TreeNode(1)),
                new TreeNode(3, new TreeNode(2), new TreeNode(5)),
                new TreeNode(5, new TreeNode(4))
            });
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5 }, trees.InorderTraversal(merged).ToList());
            Assert.IsNull(trees.CanMerge(new List<TreeNode> { new TreeNode(5, new TreeNode(3), new TreeNode(8)), new TreeNode(3, new TreeNode(2), new TreeNode(6)) }));
        }

        [TestMethod]
        public void CountHighestScoreNodes_Test1()
        {
            Assert.AreEqual(3, trees.CountHighestScoreNodes(new[] { -1, 2, 0, 2, 0 }));
            Assert.AreEqual(1, trees.CountHighestScoreNodes(new[] { -1 }));
        }

        [TestMethod]
        public void GetDirections_Test1()
        {
            Assert.AreEqual("UURL", trees.GetDirections(CreateTree(new int?[] { 5, 1, 2, 3, null, 6, 4 }), 3, 6));
            Assert.AreEqual(string.Empty, trees.GetDirections(new TreeNode(1), 1, 1));
        }

        [TestMethod]
        public void LongestPath_Test1()
        {
            Assert.AreEqual(3, trees.LongestPath(new[] { -1, 0, 0, 1, 1, 2 }, "abacbe"));
            Assert.AreEqual(1, trees.LongestPath(new[] { -1 }, "a"));
        }

        [TestMethod]
        public void CreateBinaryTree_Test1()
        {
            TreeNode root = trees.CreateBinaryTree(new[] { new[] { 20, 15, 1 }, new[] { 20, 17, 0 }, new[] { 50, 20, 1 }, new[] { 50, 80, 0 }, new[] { 80, 19, 1 } });
            Assert.IsTrue(trees.IsSameTree(CreateTree(new int?[] { 50, 20, 80, 15, 17, 19 }), root));
            Assert.IsTrue(trees.IsSameTree(CreateTree(new int?[] { 1, 2 }), trees.CreateBinaryTree(new[] { new[] { 1, 2, 1 } })));
        }

        [TestMethod]
        public void CheckTree_Test1()
        {
            Assert.IsTrue(trees.CheckTree(new TreeNode(10, new TreeNode(4), new TreeNode(6))));
            Assert.IsFalse(trees.CheckTree(new TreeNode(5, new TreeNode(3), new TreeNode(1))));
        }

        [TestMethod]
        public void AverageOfSubtree_Test1()
        {
            Assert.AreEqual(5, trees.AverageOfSubtree(CreateTree(new int?[] { 4, 8, 5, 0, 1, null, 6 })));
            Assert.AreEqual(1, trees.AverageOfSubtree(new TreeNode(1)));
        }

        [TestMethod]
        public void EvaluateTree_Test1()
        {
            Assert.IsTrue(trees.EvaluateTree(CreateTree(new int?[] { 2, 1, 3, null, null, 0, 1 })));
            Assert.IsFalse(trees.EvaluateTree(new TreeNode(0)));
        }

        [TestMethod]
        public void AmountOfTime_Test1()
        {
            Assert.AreEqual(4, trees.AmountOfTime(CreateTree(new int?[] { 1, 5, 3, null, 4, 10, 6, 9, 2 }), 3));
            Assert.AreEqual(0, trees.AmountOfTime(new TreeNode(1), 1));
        }

        [TestMethod]
        public void ReverseOddLevels_Test1()
        {
            Assert.IsTrue(trees.IsSameTree(CreateTree(new int?[] { 2, 5, 3, 8, 13, 21, 34 }), trees.ReverseOddLevels(CreateTree(new int?[] { 2, 3, 5, 8, 13, 21, 34 }))));
            Assert.IsTrue(trees.IsSameTree(new TreeNode(7), trees.ReverseOddLevels(new TreeNode(7))));
        }

        [TestMethod]
        public void TreeQueries_Test1()
        {
            CollectionAssert.AreEqual(new[] { 2 }, trees.TreeQueries(CreateTree(new int?[] { 1, 3, 4, 2, null, 6, 5, null, null, null, null, null, 7 }), new[] { 4 }));
            CollectionAssert.AreEqual(new[] { 3, 2, 3, 2 }, trees.TreeQueries(CreateTree(new int?[] { 5, 8, 9, 2, 1, 3, 7, 4, 6 }), new[] { 3, 2, 4, 8 }));
        }

        [TestMethod]
        public void MinimumOperations_Test1()
        {
            Assert.AreEqual(3, trees.MinimumOperations(CreateTree(new int?[] { 1, 4, 3, 7, 6, 8, 5, null, null, null, null, 9, null, 10 })));
            Assert.AreEqual(0, trees.MinimumOperations(new TreeNode(1)));
        }

        [TestMethod]
        public void ClosestNodes_Test1()
        {
            AssertNestedSequence(new List<IList<int>> { new List<int> { 2, 2 }, new List<int> { 4, 6 }, new List<int> { 15, -1 } }, trees.ClosestNodes(CreateTree(new int?[] { 6, 2, 13, 1, 4, 9, 15, null, null, null, null, null, null, 14 }), new List<int> { 2, 5, 16 }));
            AssertNestedSequence(new List<IList<int>> { new List<int> { -1, 1 }, new List<int> { 1, -1 } }, trees.ClosestNodes(new TreeNode(1), new List<int> { 0, 2 }));
        }

        [TestMethod]
        public void CycleLengthQueries_Test1()
        {
            CollectionAssert.AreEqual(new[] { 4, 5, 3 }, trees.CycleLengthQueries(3, new[] { new[] { 5, 3 }, new[] { 4, 7 }, new[] { 2, 3 } }));
            CollectionAssert.AreEqual(new[] { 1 }, trees.CycleLengthQueries(1, new[] { new[] { 1, 1 } }));
        }

        [TestMethod]
        public void KthLargestLevelSum_Test1()
        {
            Assert.AreEqual(13L, trees.KthLargestLevelSum(CreateTree(new int?[] { 5, 8, 9, 2, 1, 3, 7, 4, 6 }), 2));
            Assert.AreEqual(-1L, trees.KthLargestLevelSum(new TreeNode(1), 2));
        }

        [TestMethod]
        public void ReplaceValueInTree_Test1()
        {
            Assert.IsTrue(trees.IsSameTree(CreateTree(new int?[] { 0, 0, 0, 7, 7, null, 11 }), trees.ReplaceValueInTree(CreateTree(new int?[] { 5, 4, 9, 1, 10, null, 7 }))));
            Assert.IsTrue(trees.IsSameTree(new TreeNode(0), trees.ReplaceValueInTree(new TreeNode(42))));
        }

        [TestMethod]
        public void MinIncrements_Test1()
        {
            Assert.AreEqual(6, trees.MinIncrements(7, new[] { 1, 5, 2, 2, 3, 3, 1 }));
            Assert.AreEqual(0, trees.MinIncrements(3, new[] { 5, 3, 3 }));
        }

        [TestMethod]
        public void CountPalindromePaths_Test1()
        {
            Assert.AreEqual(8L, trees.CountPalindromePaths(new List<int> { -1, 0, 0, 1, 1, 2 }, "acaabc"));
            Assert.AreEqual(10L, trees.CountPalindromePaths(new List<int> { -1, 0, 0, 0, 0 }, "aaaaa"));
        }

        [TestMethod]
        public void MinOperationsQueries_Test1()
        {
            int[][] edges =
            {
                new[] { 0, 1, 1 },
                new[] { 1, 2, 1 },
                new[] { 2, 3, 1 },
                new[] { 3, 4, 2 },
                new[] { 4, 5, 2 },
                new[] { 5, 6, 2 }
            };

            CollectionAssert.AreEqual(new[] { 0, 0, 1, 3 }, trees.MinOperationsQueries(7, edges, new[] { new[] { 0, 3 }, new[] { 3, 6 }, new[] { 2, 6 }, new[] { 0, 6 } }));
            CollectionAssert.AreEqual(new[] { 0 }, trees.MinOperationsQueries(1, new int[0][], new[] { new[] { 0, 0 } }));
        }

        [TestMethod]
        public void CountPaths_Test1()
        {
            Assert.AreEqual(4L, trees.CountPaths(5, new[] { new[] { 1, 2 }, new[] { 1, 3 }, new[] { 2, 4 }, new[] { 2, 5 } }));
            Assert.AreEqual(1L, trees.CountPaths(2, new[] { new[] { 1, 2 } }));
        }

        [TestMethod]
        public void MaxKDivisibleComponents_Test1()
        {
            Assert.AreEqual(2, trees.MaxKDivisibleComponents(5, new[] { new[] { 0, 2 }, new[] { 1, 2 }, new[] { 1, 3 }, new[] { 2, 4 } }, new[] { 1, 8, 1, 4, 4 }, 6));
            Assert.AreEqual(1, trees.MaxKDivisibleComponents(1, new int[0][], new[] { 6 }, 3));
        }

        [TestMethod]
        public void MaximumScoreAfterOperations_Test1()
        {
            Assert.AreEqual(11L, trees.MaximumScoreAfterOperations(new[] { new[] { 0, 1 }, new[] { 0, 2 }, new[] { 0, 3 }, new[] { 2, 4 }, new[] { 4, 5 } }, new[] { 5, 2, 5, 2, 1, 1 }));
            Assert.AreEqual(0L, trees.MaximumScoreAfterOperations(new int[0][], new[] { 7 }));
        }

        [TestMethod]
        public void MaximumPoints_Test1()
        {
            Assert.AreEqual(11, trees.MaximumPoints(new[] { new[] { 0, 1 }, new[] { 1, 2 }, new[] { 2, 3 } }, new[] { 10, 10, 3, 3 }, 5));
            Assert.AreEqual(16, trees.MaximumPoints(new[] { new[] { 0, 1 }, new[] { 0, 2 } }, new[] { 8, 4, 4 }, 0));
        }

        [TestMethod]
        public void CountPairsOfConnectableServers_Test1()
        {
            CollectionAssert.AreEqual(new[] { 0, 4, 6, 6, 4, 0 }, trees.CountPairsOfConnectableServers(new[] { new[] { 0, 1, 1 }, new[] { 1, 2, 5 }, new[] { 2, 3, 13 }, new[] { 3, 4, 9 }, new[] { 4, 5, 2 } }, 1));
            CollectionAssert.AreEqual(new[] { 0 }, trees.CountPairsOfConnectableServers(new int[0][], 3));
        }

        [TestMethod]
        public void MinimumDiameterAfterMerge_Test1()
        {
            Assert.AreEqual(3, trees.MinimumDiameterAfterMerge(new[] { new[] { 0, 1 }, new[] { 0, 2 }, new[] { 0, 3 } }, new[] { new[] { 0, 1 } }));
            Assert.AreEqual(1, trees.MinimumDiameterAfterMerge(new int[0][], new int[0][]));
        }

        [TestMethod]
        public void TimeTaken_Test1()
        {
            CollectionAssert.AreEqual(new[] { 2, 4, 3 }, trees.TimeTaken(new[] { new[] { 0, 1 }, new[] { 0, 2 } }));
            CollectionAssert.AreEqual(new[] { 0 }, trees.TimeTaken(new int[0][]));
        }

        [TestMethod]
        public void KthLargestPerfectSubtree_Test1()
        {
            TreeNode root = CreateTree(new int?[] { 1, 2, 3, 4, 5, null, 7 });
            Assert.AreEqual(1, trees.KthLargestPerfectSubtree(root, 2));
            Assert.AreEqual(-1, trees.KthLargestPerfectSubtree(root, 5));
        }

        [TestMethod]
        public void FindSubtreeSizes_Test1()
        {
            CollectionAssert.AreEqual(new[] { 6, 3, 1, 1, 1, 1 }, trees.FindSubtreeSizes(new[] { -1, 0, 0, 1, 1, 1 }, "abaabc"));
            CollectionAssert.AreEqual(new[] { 4, 3, 2, 1 }, trees.FindSubtreeSizes(new[] { -1, 0, 1, 2 }, "aaaa"));
        }

        [TestMethod]
        public void MaximizeSumOfWeights_Test1()
        {
            Assert.AreEqual(5L, trees.MaximizeSumOfWeights(new[] { new[] { 0, 1, 4 }, new[] { 1, 2, 2 }, new[] { 1, 3, 5 } }, 1));
            Assert.AreEqual(9L, trees.MaximizeSumOfWeights(new[] { new[] { 0, 1, 4 }, new[] { 1, 2, 2 }, new[] { 1, 3, 5 } }, 2));
        }

        [TestMethod]
        public void MaxTargetNodesWithDistance_Test1()
        {
            CollectionAssert.AreEqual(new[] { 3, 4, 3 }, trees.MaxTargetNodes(new[] { new[] { 0, 1 }, new[] { 1, 2 } }, new[] { new[] { 0, 1 } }, 1));
            CollectionAssert.AreEqual(new[] { 1, 1, 1 }, trees.MaxTargetNodes(new[] { new[] { 0, 1 }, new[] { 1, 2 } }, new[] { new[] { 0, 1 } }, 0));
        }

        [TestMethod]
        public void MaxTargetNodesByParity_Test1()
        {
            CollectionAssert.AreEqual(new[] { 3, 2, 3 }, trees.MaxTargetNodes(new[] { new[] { 0, 1 }, new[] { 1, 2 } }, new[] { new[] { 0, 1 } }));
            CollectionAssert.AreEqual(new[] { 2 }, trees.MaxTargetNodes(new int[0][], new[] { new[] { 0, 1 } }));
        }

        [TestMethod]
        public void AssignEdgeWeights_Test1()
        {
            Assert.AreEqual(2, trees.AssignEdgeWeights(new[] { new[] { 1, 2 }, new[] { 1, 3 }, new[] { 3, 4 }, new[] { 3, 5 } }));
            Assert.AreEqual(1, trees.AssignEdgeWeights(new[] { new[] { 1, 2 } }));
        }

        [TestMethod]
        public void MaxSubgraphScore_Test1()
        {
            CollectionAssert.AreEqual(new[] { 2, 3, 2, 3, 3 }, trees.MaxSubgraphScore(5, new[] { new[] { 1, 0 }, new[] { 1, 2 }, new[] { 1, 3 }, new[] { 3, 4 } }, new[] { 0, 1, 0, 1, 1 }));
            CollectionAssert.AreEqual(new[] { -1, -1 }, trees.MaxSubgraphScore(2, new[] { new[] { 0, 1 } }, new[] { 0, 0 }));
        }

        [TestMethod]
        public void InteractionCosts_Test1()
        {
            Assert.AreEqual(4L, trees.InteractionCosts(3, new[] { new[] { 0, 1 }, new[] { 1, 2 } }, new[] { 1, 1, 1 }));
            Assert.AreEqual(0L, trees.InteractionCosts(2, new[] { new[] { 0, 1 } }, new[] { 9, 8 }));
        }

        [TestMethod]
        public void MinimumFlips_Test1()
        {
            CollectionAssert.AreEqual(new[] { 0 }, trees.MinimumFlips(3, new[] { new[] { 0, 1 }, new[] { 1, 2 } }, "010", "100").ToArray());
            CollectionAssert.AreEqual(new[] { -1 }, trees.MinimumFlips(2, new[] { new[] { 0, 1 } }, "00", "01").ToArray());
        }

        [TestMethod]
        public void SpecialNodes_Test1()
        {
            Assert.AreEqual(3, trees.SpecialNodes(4, new[] { new[] { 0, 1 }, new[] { 0, 2 }, new[] { 0, 3 } }, 1, 2, 3));
            Assert.AreEqual(0, trees.SpecialNodes(4, new[] { new[] { 0, 1 }, new[] { 1, 2 }, new[] { 2, 3 } }, 0, 3, 2));
        }

        [TestMethod]
        public void SumOfAncestors_Test1()
        {
            Assert.AreEqual(3L, trees.SumOfAncestors(3, new[] { new[] { 0, 1 }, new[] { 1, 2 } }, new[] { 2, 8, 2 }));
            Assert.AreEqual(0L, trees.SumOfAncestors(1, new int[0][], new[] { 1 }));
        }

        [TestMethod]
        public void PalindromePath_Test1()
        {
            CollectionAssert.AreEqual(new[] { true, false }, trees.PalindromePath(3, new[] { new[] { 0, 1 }, new[] { 1, 2 } }, "aac", new[] { "query 0 2", "update 1 b", "query 0 2" }).ToArray());
            CollectionAssert.AreEqual(new[] { true }, trees.PalindromePath(1, new int[0][], "a", new[] { "update 0 z", "query 0 0" }).ToArray());
        }

        [TestMethod]
        public void CountValidSubsets_Test1()
        {
            Assert.AreEqual(1, trees.CountValidSubsets(new[] { -1, 0, 1 }, new[] { 1, 2, 3 }, 3));
            Assert.AreEqual(1, trees.CountValidSubsets(new[] { -1 }, new[] { 3 }, 3));
        }

        [TestMethod]
        public void CountDominantNodes_Test1()
        {
            Assert.AreEqual(5, trees.CountDominantNodes(CreateTree(new int?[] { 5, 3, 8, 2, 4, 7, 1 })));
            Assert.AreEqual(1, trees.CountDominantNodes(new TreeNode(1)));
        }

        [TestMethod]
        public void FinishTime_Test1()
        {
            Assert.AreEqual(17L, trees.FinishTime(3, new[] { new[] { 0, 1 }, new[] { 1, 2 } }, new[] { 9, 5, 3 }));
            Assert.AreEqual(5L, trees.FinishTime(1, new int[0][], new[] { 5 }));
        }

        [TestMethod]
        public void WeightedSum_Test1()
        {
            Assert.AreEqual(37L, trees.WeightedSum(new[] { -1, 0, 0, 0, 2, 2 }, new[] { 5, 2, 3, 1, 4, 6 }));
            Assert.AreEqual(7L, trees.WeightedSum(new[] { -1 }, new[] { 7 }));
        }

    }
}
