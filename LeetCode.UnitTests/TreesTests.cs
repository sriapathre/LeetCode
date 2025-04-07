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
            TreeNode root = null;
            TreeNode current = null;
            foreach (var e in list)
            {
                // need to implement
            }
            return root;
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
    }
}
