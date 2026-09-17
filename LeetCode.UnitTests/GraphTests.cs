using LeetCode.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.UnitTests
{
    [TestClass]
    public class GraphTests
    {
        private Graphs graphs;

        [TestInitialize]
        public void Setup()
        {
            graphs = new Graphs();
        }

        [TestMethod]
        public void FindLadders_ReturnsAllShortestPaths()
        {
            var actual = graphs.FindLadders("hit", "cog", new[] { "hot", "dot", "dog", "lot", "log", "cog" });
            var normalized = actual.Select(path => string.Join(",", path)).OrderBy(path => path).ToList();

            CollectionAssert.AreEqual(
                new List<string>
                {
                    "hit,hot,dot,dog,cog",
                    "hit,hot,lot,log,cog"
                },
                normalized);
        }

        [TestMethod]
        public void FindLadders_ReturnsEmptyWhenEndWordMissing()
        {
            var actual = graphs.FindLadders("hit", "cog", new[] { "hot", "dot", "dog", "lot", "log" });
            Assert.AreEqual(0, actual.Count);
        }

        [TestMethod]
        public void LadderLength_ReturnsShortestPathLength()
        {
            Assert.AreEqual(5, graphs.LadderLength("hit", "cog", new[] { "hot", "dot", "dog", "lot", "log", "cog" }));
        }

        [TestMethod]
        public void LadderLength_ReturnsZeroWhenNoPathExists()
        {
            Assert.AreEqual(0, graphs.LadderLength("hit", "cog", new[] { "hot", "dot", "dog", "lot", "log" }));
        }

        [TestMethod]
        public void Solve_CapturesSurroundedRegionsOnly()
        {
            char[][] board = CreateBoard(new[] { "XXXX", "XOOX", "XXOX", "XOXX" });
            graphs.Solve(board);

            CollectionAssert.AreEqual(new[] { "XXXX", "XXXX", "XXXX", "XOXX" }, ToRows(board));
        }

        [TestMethod]
        public void Solve_PreservesBorderConnectedRegion()
        {
            char[][] board = CreateBoard(new[] { "OO", "OO" });
            graphs.Solve(board);

            CollectionAssert.AreEqual(new[] { "OO", "OO" }, ToRows(board));
        }

        [TestMethod]
        public void CloneGraph_DeepCopiesConnectedGraph()
        {
            var one = new Node(1);
            var two = new Node(2);
            var three = new Node(3);
            var four = new Node(4);
            one.neighbors.Add(two);
            one.neighbors.Add(four);
            two.neighbors.Add(one);
            two.neighbors.Add(three);
            three.neighbors.Add(two);
            three.neighbors.Add(four);
            four.neighbors.Add(one);
            four.neighbors.Add(three);

            Node clone = graphs.CloneGraph(one);

            Assert.AreNotSame(one, clone);
            Assert.AreEqual(1, clone.val);
            CollectionAssert.AreEqual(new[] { 2, 4 }, clone.neighbors.Select(n => n.val).ToArray());
            Assert.AreNotSame(two, clone.neighbors[0]);
            Assert.AreSame(clone, clone.neighbors[0].neighbors[0]);
        }

        [TestMethod]
        public void CloneGraph_ReturnsNullForNullInput()
        {
            Assert.IsNull(graphs.CloneGraph(null));
        }

        [TestMethod]
        public void LRUCache_EvictsLeastRecentlyUsedKey()
        {
            var cache = new LRUCache(2);
            cache.Put(1, 1);
            cache.Put(2, 2);
            Assert.AreEqual(1, cache.Get(1));
            cache.Put(3, 3);
            Assert.AreEqual(-1, cache.Get(2));
            cache.Put(4, 4);
            Assert.AreEqual(-1, cache.Get(1));
            Assert.AreEqual(3, cache.Get(3));
            Assert.AreEqual(4, cache.Get(4));
        }

        [TestMethod]
        public void LRUCache_UpdatesExistingKey()
        {
            var cache = new LRUCache(2);
            cache.Put(2, 1);
            cache.Put(2, 2);
            Assert.AreEqual(2, cache.Get(2));
            cache.Put(1, 1);
            cache.Put(4, 1);
            Assert.AreEqual(-1, cache.Get(2));
        }

        [TestMethod]
        public void EvalRPN_EvaluatesExamplesAndTruncatesTowardZero()
        {
            Assert.AreEqual(9, graphs.EvalRPN(new[] { "2", "1", "+", "3", "*" }));
            Assert.AreEqual(6, graphs.EvalRPN(new[] { "4", "13", "5", "/", "+" }));
            Assert.AreEqual(22, graphs.EvalRPN(new[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" }));
        }

        [TestMethod]
        public void MinStack_TracksMinimumAcrossDuplicates()
        {
            var stack = new MinStack();
            stack.Push(-2);
            stack.Push(0);
            stack.Push(-3);
            Assert.AreEqual(-3, stack.GetMin());
            stack.Pop();
            Assert.AreEqual(0, stack.Top());
            Assert.AreEqual(-2, stack.GetMin());
            stack.Push(-2);
            Assert.AreEqual(-2, stack.GetMin());
            stack.Pop();
            Assert.AreEqual(-2, stack.GetMin());
        }

        [TestMethod]
        public void NumIslands_CountsSeparateIslands()
        {
            char[][] grid = CreateBoard(new[] { "11110", "11010", "11000", "00000" });
            Assert.AreEqual(1, graphs.NumIslands(grid));
        }

        [TestMethod]
        public void NumIslands_ReturnsZeroForAllWater()
        {
            char[][] grid = CreateBoard(new[] { "000", "000" });
            Assert.AreEqual(0, graphs.NumIslands(grid));
        }

        [TestMethod]
        public void NumIslands_CountsDiagonalLandSeparately()
        {
            char[][] grid = CreateBoard(new[] { "11000", "11000", "00100", "00011" });
            Assert.AreEqual(3, graphs.NumIslands(grid));
        }

        [TestMethod]
        public void CanFinish_DetectsAcyclicAndCyclicPrerequisites()
        {
            Assert.IsTrue(graphs.CanFinish(2, new[] { new[] { 1, 0 } }));
            Assert.IsFalse(graphs.CanFinish(2, new[] { new[] { 1, 0 }, new[] { 0, 1 } }));
        }

        [TestMethod]
        public void FindOrder_ReturnsTopologicalOrderOrEmptyForCycle()
        {
            int[] order = graphs.FindOrder(4, new[] { new[] { 1, 0 }, new[] { 2, 0 }, new[] { 3, 1 }, new[] { 3, 2 } });
            Assert.AreEqual(4, order.Length);
            Assert.IsTrue(System.Array.IndexOf(order, 0) < System.Array.IndexOf(order, 1));
            Assert.IsTrue(System.Array.IndexOf(order, 0) < System.Array.IndexOf(order, 2));
            Assert.IsTrue(System.Array.IndexOf(order, 1) < System.Array.IndexOf(order, 3));
            Assert.IsTrue(System.Array.IndexOf(order, 2) < System.Array.IndexOf(order, 3));
            CollectionAssert.AreEqual(System.Array.Empty<int>(), graphs.FindOrder(2, new[] { new[] { 1, 0 }, new[] { 0, 1 } }));
        }

        [TestMethod]
        public void Trie_SearchesWordsAndPrefixes()
        {
            var trie = new Trie();
            trie.Insert("apple");
            Assert.IsTrue(trie.Search("apple"));
            Assert.IsFalse(trie.Search("app"));
            Assert.IsTrue(trie.StartsWith("app"));
            trie.Insert("app");
            Assert.IsTrue(trie.Search("app"));
            Assert.IsFalse(trie.StartsWith("bat"));
        }

        [TestMethod]
        public void WordDictionary_SearchesWithWildcard()
        {
            var dictionary = new WordDictionary();
            dictionary.AddWord("bad");
            dictionary.AddWord("dad");
            dictionary.AddWord("mad");
            Assert.IsFalse(dictionary.Search("pad"));
            Assert.IsTrue(dictionary.Search("bad"));
            Assert.IsTrue(dictionary.Search(".ad"));
            Assert.IsTrue(dictionary.Search("b.."));
            Assert.IsFalse(dictionary.Search(".."));
        }

        [TestMethod]
        public void MedianFinder_ReturnsMedianForOddAndEvenCounts()
        {
            var finder = new MedianFinder();
            finder.AddNum(1);
            finder.AddNum(2);
            Assert.AreEqual(1.5, finder.FindMedian());
            finder.AddNum(3);
            Assert.AreEqual(2.0, finder.FindMedian());
            finder.AddNum(-10);
            Assert.AreEqual(1.5, finder.FindMedian());
        }

        [TestMethod]
        public void FindMinHeightTrees_ReturnsTreeCenters()
        {
            CollectionAssert.AreEquivalent(new[] { 1 }, graphs.FindMinHeightTrees(4, new[] { new[] { 1, 0 }, new[] { 1, 2 }, new[] { 1, 3 } }).ToArray());
            CollectionAssert.AreEquivalent(new[] { 3, 4 }, graphs.FindMinHeightTrees(6, new[] { new[] { 3, 0 }, new[] { 3, 1 }, new[] { 3, 2 }, new[] { 3, 4 }, new[] { 5, 4 } }).ToArray());
            CollectionAssert.AreEqual(new[] { 0 }, graphs.FindMinHeightTrees(1, System.Array.Empty<int[]>()).ToArray());
        }

        [TestMethod]
        public void FindItinerary_UsesAllTicketsInLexicalOrder()
        {
            var tickets = new List<IList<string>>
            {
                new List<string> { "MUC", "LHR" },
                new List<string> { "JFK", "MUC" },
                new List<string> { "SFO", "SJC" },
                new List<string> { "LHR", "SFO" }
            };

            CollectionAssert.AreEqual(new[] { "JFK", "MUC", "LHR", "SFO", "SJC" }, graphs.FindItinerary(tickets).ToArray());

            tickets = new List<IList<string>>
            {
                new List<string> { "JFK", "SFO" },
                new List<string> { "JFK", "ATL" },
                new List<string> { "SFO", "ATL" },
                new List<string> { "ATL", "JFK" },
                new List<string> { "ATL", "SFO" }
            };

            CollectionAssert.AreEqual(new[] { "JFK", "ATL", "JFK", "SFO", "ATL", "SFO" }, graphs.FindItinerary(tickets).ToArray());
        }

        [TestMethod]
        public void Twitter_ReturnsRecentTweetsAndHonorsUnfollow()
        {
            var twitter = new Twitter();
            twitter.PostTweet(1, 5);
            CollectionAssert.AreEqual(new[] { 5 }, twitter.GetNewsFeed(1).ToArray());
            twitter.Follow(1, 2);
            twitter.PostTweet(2, 6);
            CollectionAssert.AreEqual(new[] { 6, 5 }, twitter.GetNewsFeed(1).ToArray());
            twitter.Unfollow(1, 2);
            CollectionAssert.AreEqual(new[] { 5 }, twitter.GetNewsFeed(1).ToArray());
        }

        [TestMethod]
        public void RandomizedSet_InsertsRemovesAndReturnsRemainingValue()
        {
            var set = new RandomizedSet();
            Assert.IsTrue(set.Insert(1));
            Assert.IsFalse(set.Insert(1));
            Assert.IsTrue(set.Insert(2));
            Assert.IsTrue(set.Remove(1));
            Assert.IsFalse(set.Remove(3));
            Assert.AreEqual(2, set.GetRandom());
        }

        [TestMethod]
        public void CalcEquation_EvaluatesConnectedAndMissingQueries()
        {
            var equations = new List<IList<string>>
            {
                new List<string> { "a", "b" },
                new List<string> { "b", "c" }
            };
            var queries = new List<IList<string>>
            {
                new List<string> { "a", "c" },
                new List<string> { "b", "a" },
                new List<string> { "a", "e" },
                new List<string> { "a", "a" },
                new List<string> { "x", "x" }
            };

            CollectionAssert.AreEqual(new[] { 6.0, 0.5, -1.0, 1.0, -1.0 }, graphs.CalcEquation(equations, new[] { 2.0, 3.0 }, queries));
        }

        [TestMethod]
        public void PacificAtlantic_ReturnsCellsReachingBothOceans()
        {
            int[][] heights =
            {
                new[] { 1, 2, 2, 3, 5 },
                new[] { 3, 2, 3, 4, 4 },
                new[] { 2, 4, 5, 3, 1 },
                new[] { 6, 7, 1, 4, 5 },
                new[] { 5, 1, 1, 2, 4 }
            };

            var actual = graphs.PacificAtlantic(heights).Select(cell => $"{cell[0]},{cell[1]}").OrderBy(cell => cell).ToArray();
            CollectionAssert.AreEqual(new[] { "0,4", "1,3", "1,4", "2,2", "3,0", "3,1", "4,0" }, actual);
            CollectionAssert.AreEqual(new[] { "0,0" }, graphs.PacificAtlantic(new[] { new[] { 1 } }).Select(cell => $"{cell[0]},{cell[1]}").ToArray());
        }

        [TestMethod]
        public void MinMutation_ReturnsMinimumMutationsOrNegativeOne()
        {
            Assert.AreEqual(1, graphs.MinMutation("AACCGGTT", "AACCGGTA", new[] { "AACCGGTA" }));
            Assert.AreEqual(2, graphs.MinMutation("AACCGGTT", "AAACGGTA", new[] { "AACCGGTA", "AACCGCTA", "AAACGGTA" }));
            Assert.AreEqual(-1, graphs.MinMutation("AAAAACCC", "AACCCCCC", new[] { "AAAACCCC", "AAACCCCC" }));
        }

        [TestMethod]
        public void UpdateMatrix_ReturnsNearestZeroDistances()
        {
            int[][] result = graphs.UpdateMatrix(new[]
            {
                new[] { 0, 0, 0 },
                new[] { 0, 1, 0 },
                new[] { 1, 1, 1 }
            });

            CollectionAssert.AreEqual(new[] { "000", "010", "121" }, ToRows(result));
        }

        [TestMethod]
        public void FindCircleNum_CountsConnectedComponents()
        {
            Assert.AreEqual(2, graphs.FindCircleNum(new[] { new[] { 1, 1, 0 }, new[] { 1, 1, 0 }, new[] { 0, 0, 1 } }));
            Assert.AreEqual(3, graphs.FindCircleNum(new[] { new[] { 1, 0, 0 }, new[] { 0, 1, 0 }, new[] { 0, 0, 1 } }));
        }

        [TestMethod]
        public void MyCircularDeque_HandlesFrontRearAndCapacity()
        {
            var deque = new MyCircularDeque(3);
            Assert.IsTrue(deque.InsertLast(1));
            Assert.IsTrue(deque.InsertLast(2));
            Assert.IsTrue(deque.InsertFront(3));
            Assert.IsFalse(deque.InsertFront(4));
            Assert.AreEqual(2, deque.GetRear());
            Assert.IsTrue(deque.IsFull());
            Assert.IsTrue(deque.DeleteLast());
            Assert.IsTrue(deque.InsertFront(4));
            Assert.AreEqual(4, deque.GetFront());
            Assert.IsTrue(deque.DeleteFront());
            Assert.IsTrue(deque.DeleteFront());
            Assert.IsTrue(deque.DeleteFront());
            Assert.IsFalse(deque.DeleteFront());
            Assert.AreEqual(-1, deque.GetRear());
        }

        [TestMethod]
        public void FindRedundantConnection_ReturnsCycleClosingEdge()
        {
            CollectionAssert.AreEqual(new[] { 2, 3 }, graphs.FindRedundantConnection(new[] { new[] { 1, 2 }, new[] { 1, 3 }, new[] { 2, 3 } }));
            CollectionAssert.AreEqual(new[] { 1, 4 }, graphs.FindRedundantConnection(new[] { new[] { 1, 2 }, new[] { 2, 3 }, new[] { 3, 4 }, new[] { 1, 4 }, new[] { 1, 5 } }));
        }

        [TestMethod]
        public void GetImportance_SumsNestedSubordinates()
        {
            var employees = new List<Employee>
            {
                new Employee { id = 1, importance = 5, subordinates = new List<int> { 2, 3 } },
                new Employee { id = 2, importance = 3, subordinates = new List<int>() },
                new Employee { id = 3, importance = 3, subordinates = new List<int>() }
            };

            Assert.AreEqual(11, graphs.GetImportance(employees, 1));
            Assert.AreEqual(3, graphs.GetImportance(employees, 2));
        }

        [TestMethod]
        public void MaxAreaOfIsland_ReturnsLargestIslandArea()
        {
            int[][] grid =
            {
                new[] { 0, 0, 1, 0, 0 },
                new[] { 1, 1, 1, 0, 0 },
                new[] { 0, 0, 0, 0, 1 }
            };

            Assert.AreEqual(4, graphs.MaxAreaOfIsland(grid));
            Assert.AreEqual(0, graphs.MaxAreaOfIsland(new[] { new[] { 0, 0 }, new[] { 0, 0 } }));
        }

        [TestMethod]
        public void KthLargest_TracksStreamRank()
        {
            var kth = new KthLargest(3, new[] { 4, 5, 8, 2 });

            Assert.AreEqual(4, kth.Add(3));
            Assert.AreEqual(5, kth.Add(5));
            Assert.AreEqual(5, kth.Add(10));
            Assert.AreEqual(8, kth.Add(9));
            Assert.AreEqual(8, kth.Add(4));
        }

        [TestMethod]
        public void MyHashSet_AddsRemovesAndChecksBoundaryKeys()
        {
            var set = new MyHashSet();
            set.Add(1);
            set.Add(1_000_000);
            set.Remove(1);

            Assert.IsFalse(set.Contains(1));
            Assert.IsTrue(set.Contains(1_000_000));
            Assert.IsFalse(set.Contains(2));
        }

        [TestMethod]
        public void MyHashMap_PutsUpdatesGetsAndRemoves()
        {
            var map = new MyHashMap();
            map.Put(1, 1);
            map.Put(2, 2);
            Assert.AreEqual(1, map.Get(1));
            Assert.AreEqual(-1, map.Get(3));
            map.Put(2, 1);
            Assert.AreEqual(1, map.Get(2));
            map.Remove(2);
            Assert.AreEqual(-1, map.Get(2));
        }

        [TestMethod]
        public void AccountsMerge_MergesBySharedEmailsAndSorts()
        {
            var accounts = new List<IList<string>>
            {
                new List<string> { "John", "johnsmith@mail.com", "john_newyork@mail.com" },
                new List<string> { "John", "johnsmith@mail.com", "john00@mail.com" },
                new List<string> { "Mary", "mary@mail.com" },
                new List<string> { "John", "johnnybravo@mail.com" }
            };

            var actual = graphs.AccountsMerge(accounts).Select(account => string.Join(",", account)).OrderBy(account => account, System.StringComparer.Ordinal).ToArray();
            CollectionAssert.AreEqual(new[]
            {
                "John,john00@mail.com,john_newyork@mail.com,johnsmith@mail.com",
                "John,johnnybravo@mail.com",
                "Mary,mary@mail.com"
            }, actual);
        }

        [TestMethod]
        public void FloodFill_RecolorsConnectedComponentOnly()
        {
            int[][] image = { new[] { 1, 1, 1 }, new[] { 1, 1, 0 }, new[] { 1, 0, 1 } };

            CollectionAssert.AreEqual(new[] { "222", "220", "201" }, ToRows(graphs.FloodFill(image, 1, 1, 2)));
            CollectionAssert.AreEqual(new[] { "00" }, ToRows(graphs.FloodFill(new[] { new[] { 0, 0 } }, 0, 0, 0)));
        }

        [TestMethod]
        public void NetworkDelayTime_ReturnsDelayOrNegativeOne()
        {
            Assert.AreEqual(2, graphs.NetworkDelayTime(new[] { new[] { 2, 1, 1 }, new[] { 2, 3, 1 }, new[] { 3, 4, 1 } }, 4, 2));
            Assert.AreEqual(-1, graphs.NetworkDelayTime(new[] { new[] { 1, 2, 1 } }, 2, 2));
        }

        [TestMethod]
        public void OpenLock_ReturnsShortestTurnsOrNegativeOne()
        {
            Assert.AreEqual(6, graphs.OpenLock(new[] { "0201", "0101", "0102", "1212", "2002" }, "0202"));
            Assert.AreEqual(-1, graphs.OpenLock(new[] { "0000" }, "8888"));
            Assert.AreEqual(0, graphs.OpenLock(System.Array.Empty<string>(), "0000"));
        }

        [TestMethod]
        public void FindCheapestPrice_RespectsStopLimit()
        {
            int[][] flights = { new[] { 0, 1, 100 }, new[] { 1, 2, 100 }, new[] { 0, 2, 500 } };

            Assert.AreEqual(200, graphs.FindCheapestPrice(3, flights, 0, 2, 1));
            Assert.AreEqual(500, graphs.FindCheapestPrice(3, flights, 0, 2, 0));
            Assert.AreEqual(-1, graphs.FindCheapestPrice(3, flights, 2, 0, 1));
        }

        [TestMethod]
        public void AllPathsSourceTarget_ReturnsEveryDagPath()
        {
            var actual = graphs.AllPathsSourceTarget(new[] { new[] { 1, 2 }, new[] { 3 }, new[] { 3 }, System.Array.Empty<int>() })
                .Select(path => string.Join(",", path))
                .OrderBy(path => path)
                .ToArray();

            CollectionAssert.AreEqual(new[] { "0,1,3", "0,2,3" }, actual);
        }

        [TestMethod]
        public void EventualSafeNodes_ReturnsSortedSafeNodes()
        {
            int[][] graph =
            {
                new[] { 1, 2 },
                new[] { 2, 3 },
                new[] { 5 },
                new[] { 0 },
                new[] { 5 },
                System.Array.Empty<int>(),
                System.Array.Empty<int>()
            };

            CollectionAssert.AreEqual(new[] { 2, 4, 5, 6 }, graphs.EventualSafeNodes(graph).ToArray());
            CollectionAssert.AreEqual(System.Array.Empty<int>(), graphs.EventualSafeNodes(new[] { new[] { 0 } }).ToArray());
        }

        [TestMethod]
        public void CanVisitAllRooms_DetectsReachability()
        {
            Assert.IsTrue(graphs.CanVisitAllRooms(new List<IList<int>> { new List<int> { 1 }, new List<int> { 2 }, new List<int> { 3 }, new List<int>() }));
            Assert.IsFalse(graphs.CanVisitAllRooms(new List<IList<int>> { new List<int> { 1, 3 }, new List<int> { 3, 0, 1 }, new List<int> { 2 }, new List<int> { 0 } }));
        }

        [TestMethod]
        public void OrangesRotting_ReturnsMinutesOrNegativeOne()
        {
            Assert.AreEqual(4, graphs.OrangesRotting(new[] { new[] { 2, 1, 1 }, new[] { 1, 1, 0 }, new[] { 0, 1, 1 } }));
            Assert.AreEqual(-1, graphs.OrangesRotting(new[] { new[] { 2, 1, 1 }, new[] { 0, 1, 1 }, new[] { 1, 0, 1 } }));
            Assert.AreEqual(0, graphs.OrangesRotting(new[] { new[] { 0, 2 } }));
        }

        [TestMethod]
        public void FindJudge_ReturnsJudgeOrNegativeOne()
        {
            Assert.AreEqual(2, graphs.FindJudge(2, new[] { new[] { 1, 2 } }));
            Assert.AreEqual(-1, graphs.FindJudge(3, new[] { new[] { 1, 3 }, new[] { 2, 3 }, new[] { 3, 1 } }));
            Assert.AreEqual(1, graphs.FindJudge(1, System.Array.Empty<int[]>()));
        }

        [TestMethod]
        public void ShortestPathBinaryMatrix_ReturnsShortestEightDirectionPath()
        {
            Assert.AreEqual(2, graphs.ShortestPathBinaryMatrix(new[] { new[] { 0, 1 }, new[] { 1, 0 } }));
            Assert.AreEqual(4, graphs.ShortestPathBinaryMatrix(new[] { new[] { 0, 0, 0 }, new[] { 1, 1, 0 }, new[] { 1, 1, 0 } }));
            Assert.AreEqual(-1, graphs.ShortestPathBinaryMatrix(new[] { new[] { 1, 0 }, new[] { 0, 0 } }));
        }

        [TestMethod]
        public void MakeConnected_ReturnsCableMovesOrNegativeOne()
        {
            Assert.AreEqual(1, graphs.MakeConnected(4, new[] { new[] { 0, 1 }, new[] { 0, 2 }, new[] { 1, 2 } }));
            Assert.AreEqual(-1, graphs.MakeConnected(6, new[] { new[] { 0, 1 }, new[] { 0, 2 }, new[] { 0, 3 }, new[] { 1, 2 } }));
        }

        [TestMethod]
        public void MinCostConnectPoints_ReturnsMstCost()
        {
            Assert.AreEqual(20, graphs.MinCostConnectPoints(new[] { new[] { 0, 0 }, new[] { 2, 2 }, new[] { 3, 10 }, new[] { 5, 2 }, new[] { 7, 0 } }));
            Assert.AreEqual(0, graphs.MinCostConnectPoints(new[] { new[] { 3, 12 } }));
        }

        [TestMethod]
        public void MinimumEffortPath_ReturnsMinimaxPathCost()
        {
            Assert.AreEqual(2, graphs.MinimumEffortPath(new[] { new[] { 1, 2, 2 }, new[] { 3, 8, 2 }, new[] { 5, 3, 5 } }));
            Assert.AreEqual(0, graphs.MinimumEffortPath(new[] { new[] { 7 } }));
        }


        [TestMethod]
        public void HighestPeak_AssignsDistanceFromWater()
        {
            CollectionAssert.AreEqual(new[] { "10", "21" }, ToRows(graphs.HighestPeak(new[] { new[] { 0, 1 }, new[] { 0, 0 } })));
            CollectionAssert.AreEqual(new[] { "0" }, ToRows(graphs.HighestPeak(new[] { new[] { 1 } })));
        }

        [TestMethod]
        public void FindCenter_ReturnsSharedStarEndpoint()
        {
            Assert.AreEqual(2, graphs.FindCenter(new[] { new[] { 1, 2 }, new[] { 2, 3 }, new[] { 4, 2 } }));
            Assert.AreEqual(1, graphs.FindCenter(new[] { new[] { 1, 2 }, new[] { 5, 1 } }));
        }

        [TestMethod]
        public void CountSubIslands_CountsOnlyContainedIslands()
        {
            int[][] grid1 = { new[] { 1, 1, 1, 0, 0 }, new[] { 0, 1, 1, 1, 1 }, new[] { 0, 0, 0, 0, 0 }, new[] { 1, 0, 0, 0, 0 }, new[] { 1, 1, 0, 1, 1 } };
            int[][] grid2 = { new[] { 1, 1, 1, 0, 0 }, new[] { 0, 0, 1, 1, 1 }, new[] { 0, 1, 0, 0, 0 }, new[] { 1, 0, 1, 1, 0 }, new[] { 0, 1, 0, 1, 0 } };

            Assert.AreEqual(3, graphs.CountSubIslands(grid1, grid2));
            Assert.AreEqual(0, graphs.CountSubIslands(new[] { new[] { 0 } }, new[] { new[] { 1 } }));
        }

        [TestMethod]
        public void NearestExit_ReturnsClosestExitSteps()
        {
            Assert.AreEqual(1, graphs.NearestExit(CreateBoard(new[] { "++.+", "...+", "+++." }), new[] { 1, 2 }));
            Assert.AreEqual(-1, graphs.NearestExit(CreateBoard(new[] { ".+" }), new[] { 0, 0 }));
        }

        [TestMethod]
        public void ValidPath_DetectsUndirectedConnectivity()
        {
            Assert.IsTrue(graphs.ValidPath(3, new[] { new[] { 0, 1 }, new[] { 1, 2 }, new[] { 2, 0 } }, 0, 2));
            Assert.IsFalse(graphs.ValidPath(6, new[] { new[] { 0, 1 }, new[] { 0, 2 }, new[] { 3, 5 }, new[] { 5, 4 }, new[] { 4, 3 } }, 0, 5));
        }

        [TestMethod]
        public void FindFarmland_ReturnsRectangularGroups()
        {
            var actual = graphs.FindFarmland(new[] { new[] { 1, 0, 0 }, new[] { 0, 1, 1 }, new[] { 0, 1, 1 } }).Select(group => string.Join(",", group)).ToArray();
            CollectionAssert.AreEqual(new[] { "0,0,0,0", "1,1,2,2" }, actual);
            Assert.AreEqual(0, graphs.FindFarmland(new[] { new[] { 0, 0 } }).Length);
        }

        [TestMethod]
        public void NetworkBecomesIdle_ComputesFinalReplyTime()
        {
            Assert.AreEqual(8, graphs.NetworkBecomesIdle(new[] { new[] { 0, 1 }, new[] { 1, 2 } }, new[] { 0, 2, 1 }));
            Assert.AreEqual(3, graphs.NetworkBecomesIdle(new[] { new[] { 0, 1 } }, new[] { 0, 10 }));
        }

        [TestMethod]
        public void FriendRequests_RejectsRequestsThatBreakRestrictions()
        {
            CollectionAssert.AreEqual(new[] { true, false }, graphs.FriendRequests(3, new[] { new[] { 0, 1 } }, new[] { new[] { 0, 2 }, new[] { 2, 1 } }));
            CollectionAssert.AreEqual(new[] { true, false, true, false }, graphs.FriendRequests(5, new[] { new[] { 0, 1 }, new[] { 1, 2 }, new[] { 2, 3 } }, new[] { new[] { 0, 4 }, new[] { 1, 2 }, new[] { 3, 1 }, new[] { 3, 4 } }));
        }

        [TestMethod]
        public void FindAllPeople_SpreadsSecretWithinSameTimeComponents()
        {
            CollectionAssert.AreEqual(new[] { 0, 1, 2, 3, 5 }, graphs.FindAllPeople(6, new[] { new[] { 1, 2, 5 }, new[] { 2, 3, 8 }, new[] { 1, 5, 10 } }, 1).ToArray());
            CollectionAssert.AreEqual(new[] { 0, 1, 2, 3 }, graphs.FindAllPeople(4, new[] { new[] { 1, 2, 1 }, new[] { 2, 3, 1 } }, 1).ToArray());
        }

        [TestMethod]
        public void MaximumDetonation_ReturnsLargestChainReaction()
        {
            Assert.AreEqual(2, graphs.MaximumDetonation(new[] { new[] { 2, 1, 3 }, new[] { 6, 1, 4 } }));
            Assert.AreEqual(1, graphs.MaximumDetonation(new[] { new[] { 1, 1, 1 }, new[] { 10, 10, 1 } }));
        }

        [TestMethod]
        public void HighestRankedKItems_OrdersReachableItemsByRank()
        {
            var actual = graphs.HighestRankedKItems(new[] { new[] { 1, 2, 0, 1 }, new[] { 1, 3, 0, 1 }, new[] { 0, 2, 5, 1 } }, new[] { 2, 5 }, new[] { 0, 0 }, 3)
                .Select(item => string.Join(",", item))
                .ToArray();
            CollectionAssert.AreEqual(new[] { "0,1", "1,1", "2,1" }, actual);
            Assert.AreEqual(0, graphs.HighestRankedKItems(new[] { new[] { 1 } }, new[] { 2, 5 }, new[] { 0, 0 }, 1).Count);
        }

        [TestMethod]
        public void GetAncestors_ReturnsSortedDagAncestors()
        {
            var actual = graphs.GetAncestors(8, new[] { new[] { 0, 3 }, new[] { 0, 4 }, new[] { 1, 3 }, new[] { 2, 4 }, new[] { 2, 7 }, new[] { 3, 5 }, new[] { 3, 6 }, new[] { 3, 7 }, new[] { 4, 6 } })
                .Select(ancestors => string.Join(",", ancestors))
                .ToArray();
            CollectionAssert.AreEqual(new[] { "", "", "", "0,1", "0,2", "0,1,3", "0,1,2,3,4", "0,1,2,3" }, actual);
            CollectionAssert.AreEqual(new[] { "", "" }, graphs.GetAncestors(2, System.Array.Empty<int[]>()).Select(ancestors => string.Join(",", ancestors)).ToArray());
        }

        [TestMethod]
        public void CountPairs_CountsUnreachableNodePairs()
        {
            Assert.AreEqual(14L, graphs.CountPairs(7, new[] { new[] { 0, 2 }, new[] { 0, 5 }, new[] { 2, 4 }, new[] { 1, 6 }, new[] { 5, 4 } }));
            Assert.AreEqual(3L, graphs.CountPairs(3, System.Array.Empty<int[]>()));
        }

        [TestMethod]
        public void ClosestMeetingNode_MinimizesMaximumDistance()
        {
            Assert.AreEqual(2, graphs.ClosestMeetingNode(new[] { 2, 2, 3, -1 }, 0, 1));
            Assert.AreEqual(-1, graphs.ClosestMeetingNode(new[] { 1, -1, -1 }, 0, 2));
        }

        [TestMethod]
        public void LongestCycle_ReturnsLongestFunctionalGraphCycle()
        {
            Assert.AreEqual(3, graphs.LongestCycle(new[] { 3, 3, 4, 2, 3 }));
            Assert.AreEqual(-1, graphs.LongestCycle(new[] { 2, -1, 3, 1 }));
        }

        [TestMethod]
        public void BuildMatrix_PlacesValuesSatisfyingRowAndColumnConditions()
        {
            var actual = graphs.BuildMatrix(3, new[] { new[] { 1, 2 }, new[] { 3, 2 } }, new[] { new[] { 2, 1 }, new[] { 3, 2 } });
            CollectionAssert.AreEqual(new[] { "001", "300", "020" }, ToRows(actual));
            Assert.AreEqual(0, graphs.BuildMatrix(2, new[] { new[] { 1, 2 }, new[] { 2, 1 } }, System.Array.Empty<int[]>()).Length);
        }

        [TestMethod]
        public void MinScore_ReturnsSmallestEdgeInCityOneComponent()
        {
            Assert.AreEqual(5, graphs.MinScore(4, new[] { new[] { 1, 2, 9 }, new[] { 2, 3, 6 }, new[] { 2, 4, 5 }, new[] { 1, 4, 7 } }));
            Assert.AreEqual(2, graphs.MinScore(3, new[] { new[] { 1, 2, 2 }, new[] { 2, 3, 4 } }));
        }

        [TestMethod]
        public void MinimumTime_ReturnsEarliestReachableGridTime()
        {
            Assert.AreEqual(7, graphs.MinimumTime(new[] { new[] { 0, 1, 3, 2 }, new[] { 5, 1, 2, 5 }, new[] { 4, 3, 8, 6 } }));
            Assert.AreEqual(-1, graphs.MinimumTime(new[] { new[] { 0, 2, 4 }, new[] { 3, 2, 1 }, new[] { 1, 0, 4 } }));
            Assert.AreEqual(0, graphs.MinimumTime(new[] { new[] { 0 } }));
        }

        [TestMethod]
        public void FindShortestCycle_ReturnsShortestUndirectedCycleLength()
        {
            Assert.AreEqual(3, graphs.FindShortestCycle(7, new[] { new[] { 0, 1 }, new[] { 1, 2 }, new[] { 2, 0 }, new[] { 3, 4 }, new[] { 4, 5 }, new[] { 5, 6 }, new[] { 6, 3 } }));
            Assert.AreEqual(-1, graphs.FindShortestCycle(4, new[] { new[] { 0, 1 }, new[] { 1, 2 }, new[] { 2, 3 } }));
        }

        [TestMethod]
        public void DesignGraph_ComputesShortestPathsAfterAddingEdges()
        {
            var graph = new Graph(4, new[] { new[] { 0, 2, 5 }, new[] { 0, 1, 2 }, new[] { 1, 2, 1 }, new[] { 3, 0, 3 } });
            Assert.AreEqual(6, graph.ShortestPath(3, 2));
            Assert.AreEqual(-1, graph.ShortestPath(0, 3));
            graph.AddEdge(new[] { 1, 3, 4 });
            Assert.AreEqual(6, graph.ShortestPath(0, 3));
        }

        [TestMethod]
        public void CountCompleteComponents_CountsOnlyCliques()
        {
            Assert.AreEqual(3, graphs.CountCompleteComponents(6, new[] { new[] { 0, 1 }, new[] { 0, 2 }, new[] { 1, 2 }, new[] { 3, 4 } }));
            Assert.AreEqual(0, graphs.CountCompleteComponents(3, new[] { new[] { 0, 1 }, new[] { 1, 2 } }));
        }


        [TestMethod]
        public void CanTraverseAllPairs_ConnectsBySharedPrimeFactors()
        {
            Assert.IsTrue(graphs.CanTraverseAllPairs(new[] { 2, 3, 6 }));
            Assert.IsFalse(graphs.CanTraverseAllPairs(new[] { 3, 9, 5 }));
            Assert.IsTrue(graphs.CanTraverseAllPairs(new[] { 1 }));
            Assert.IsFalse(graphs.CanTraverseAllPairs(new[] { 1, 1 }));
        }

        [TestMethod]
        public void MaximumSafenessFactor_MaximizesDistanceFromThieves()
        {
            Assert.AreEqual(0, graphs.MaximumSafenessFactor(new List<IList<int>> { new List<int> { 1, 0, 0 }, new List<int> { 0, 0, 0 }, new List<int> { 0, 0, 1 } }));
            Assert.AreEqual(2, graphs.MaximumSafenessFactor(new List<IList<int>> { new List<int> { 0, 0, 1 }, new List<int> { 0, 0, 0 }, new List<int> { 0, 0, 0 } }));
        }

        [TestMethod]
        public void MinEdgeReversals_RerootsDirectedTree()
        {
            CollectionAssert.AreEqual(new[] { 1, 2, 1 }, graphs.MinEdgeReversals(3, new[] { new[] { 0, 1 }, new[] { 2, 1 } }));
            CollectionAssert.AreEqual(new[] { 0 }, graphs.MinEdgeReversals(1, System.Array.Empty<int[]>()));
        }

        [TestMethod]
        public void CountVisitedNodes_HandlesCyclesAndTails()
        {
            CollectionAssert.AreEqual(new[] { 3, 3, 3, 4 }, graphs.CountVisitedNodes(new[] { 1, 2, 0, 0 }));
            CollectionAssert.AreEqual(new[] { 5, 5, 5, 5, 5 }, graphs.CountVisitedNodes(new[] { 1, 2, 3, 4, 0 }));
        }

        [TestMethod]
        public void FindChampion_ReturnsUniqueZeroIndegreeNode()
        {
            Assert.AreEqual(0, graphs.FindChampion(3, new[] { new[] { 0, 1 }, new[] { 1, 2 } }));
            Assert.AreEqual(-1, graphs.FindChampion(4, new[] { new[] { 0, 2 }, new[] { 1, 3 } }));
        }

        [TestMethod]
        public void MinimumOperationsToMakeEqual_UsesDivisionAndUnitMoves()
        {
            Assert.AreEqual(3, graphs.MinimumOperationsToMakeEqual(26, 1));
            Assert.AreEqual(0, graphs.MinimumOperationsToMakeEqual(10, 10));
            Assert.AreEqual(3, graphs.MinimumOperationsToMakeEqual(2, 5));
        }

        [TestMethod]
        public void CountOfPairs_CountsOrderedPairsByShortestDistance()
        {
            CollectionAssert.AreEqual(new[] { 6, 0, 0 }, graphs.CountOfPairs(3, 1, 3));
            CollectionAssert.AreEqual(new[] { 6, 4, 2, 0 }, graphs.CountOfPairs(4, 2, 2));
        }

        [TestMethod]
        public void MinimumCost_AnswersBitwiseWalkCostQueries()
        {
            int[][] edges = { new[] { 0, 1, 7 }, new[] { 1, 3, 7 }, new[] { 1, 2, 1 } };
            CollectionAssert.AreEqual(new[] { 1, -1, 0 }, graphs.MinimumCost(5, edges, new[] { new[] { 0, 3 }, new[] { 3, 4 }, new[] { 2, 2 } }));
        }

        [TestMethod]
        public void MinimumTime_DisallowsArrivalsAtDisappearedNodes()
        {
            int[][] edges = { new[] { 0, 1, 2 }, new[] { 1, 2, 1 }, new[] { 0, 2, 4 } };
            CollectionAssert.AreEqual(new[] { 0, 2, 3 }, graphs.MinimumTime(3, edges, new[] { 1, 3, 5 }));
            CollectionAssert.AreEqual(new[] { 0, -1, 4 }, graphs.MinimumTime(3, edges, new[] { 1, 2, 5 }));
        }

        [TestMethod]
        public void NeighborSum_ReturnsAdjacentAndDiagonalSums()
        {
            var service = new NeighborSum(new[] { new[] { 0, 1, 2 }, new[] { 3, 4, 5 }, new[] { 6, 7, 8 } });
            Assert.AreEqual(16, service.AdjacentSum(4));
            Assert.AreEqual(16, service.DiagonalSum(4));
            Assert.AreEqual(4, service.AdjacentSum(0));
            Assert.AreEqual(4, service.DiagonalSum(0));
        }

        [TestMethod]
        public void ShortestDistanceAfterQueries_RecomputesAfterEachRoad()
        {
            CollectionAssert.AreEqual(new[] { 3, 2, 1 }, graphs.ShortestDistanceAfterQueries(5, new[] { new[] { 2, 4 }, new[] { 0, 2 }, new[] { 0, 4 } }));
        }

        [TestMethod]
        public void FindSafeWalk_ChecksMinimumHealthCostPath()
        {
            Assert.IsTrue(graphs.FindSafeWalk(new List<IList<int>> { new List<int> { 0, 1, 0 }, new List<int> { 0, 1, 0 }, new List<int> { 0, 0, 0 } }, 1));
            Assert.IsFalse(graphs.FindSafeWalk(new List<IList<int>> { new List<int> { 1, 1, 1 } }, 3));
        }

        [TestMethod]
        public void RemainingMethods_RemovesSuspiciousComponentWhenIsolated()
        {
            CollectionAssert.AreEqual(new[] { 0, 1, 2, 3 }, graphs.RemainingMethods(4, 1, new[] { new[] { 1, 2 }, new[] { 0, 1 }, new[] { 3, 2 } }).ToArray());
            CollectionAssert.AreEqual(System.Array.Empty<int>(), graphs.RemainingMethods(3, 0, new[] { new[] { 0, 1 }, new[] { 1, 2 } }).ToArray());
        }

        [TestMethod]
        public void MinTimeToReach_RespectsRoomAvailabilityTimes()
        {
            Assert.AreEqual(2, graphs.MinTimeToReach(new[] { new[] { 0, 0 }, new[] { 0, 0 } }));
            Assert.AreEqual(6, graphs.MinTimeToReach(new[] { new[] { 0, 4 }, new[] { 4, 4 } }));
        }

        [TestMethod]
        public void MinTimeToReachII_UsesAlternatingMoveCosts()
        {
            Assert.AreEqual(3, graphs.MinTimeToReachII(new[] { new[] { 0, 0 }, new[] { 0, 0 } }));
            Assert.AreEqual(7, graphs.MinTimeToReachII(new[] { new[] { 0, 4 }, new[] { 4, 4 } }));
        }

        [TestMethod]
        public void TaskManager_ExecutesHighestPriorityTask()
        {
            var manager = new TaskManager(new List<IList<int>> { new List<int> { 1, 101, 10 }, new List<int> { 2, 102, 20 }, new List<int> { 3, 103, 15 } });
            Assert.AreEqual(2, manager.ExecTop());
            manager.Add(4, 104, 20);
            manager.Edit(101, 30);
            Assert.AreEqual(1, manager.ExecTop());
            manager.Rmv(103);
            Assert.AreEqual(4, manager.ExecTop());
            Assert.AreEqual(-1, manager.ExecTop());
        }

        [TestMethod]
        public void MinMaxWeight_FindsSmallestCapReachingZero()
        {
            Assert.AreEqual(5, graphs.MinMaxWeight(3, new[] { new[] { 1, 0, 5 }, new[] { 2, 0, 3 }, new[] { 2, 1, 2 } }, 1));
            Assert.AreEqual(-1, graphs.MinMaxWeight(2, new[] { new[] { 0, 1, 1 } }, 1));
        }

        [TestMethod]
        public void NumberOfComponents_ConnectsRowsBySharedProperties()
        {
            Assert.AreEqual(2, graphs.NumberOfComponents(new[] { new[] { 1, 2 }, new[] { 1, 1 }, new[] { 3, 4 } }, 1));
            Assert.AreEqual(2, graphs.NumberOfComponents(new[] { new[] { 1, 2, 3 }, new[] { 2, 3, 4 }, new[] { 4, 5, 6 } }, 2));
        }

        [TestMethod]
        public void Router_ForwardsOldestPacketsAndCountsStoredRanges()
        {
            var router = new Router(2);
            Assert.IsTrue(router.AddPacket(1, 2, 10));
            Assert.IsFalse(router.AddPacket(1, 2, 10));
            Assert.IsTrue(router.AddPacket(2, 2, 20));
            Assert.AreEqual(2, router.GetCount(2, 10, 20));
            Assert.IsTrue(router.AddPacket(3, 2, 30));
            Assert.AreEqual(2, router.GetCount(2, 10, 30));
            CollectionAssert.AreEqual(new[] { 2, 2, 20 }, router.ForwardPacket());
            Assert.AreEqual(1, router.GetCount(2, 10, 30));
            CollectionAssert.AreEqual(new[] { 3, 2, 30 }, router.ForwardPacket());
            CollectionAssert.AreEqual(System.Array.Empty<int>(), router.ForwardPacket());
        }

        [TestMethod]
        public void MaxSubgraphScore_RerootsBestConnectedSubtrees()
        {
            CollectionAssert.AreEqual(
                new[] { 2, 3, 2, 3, 3 },
                graphs.MaxSubgraphScore(5, new[] { new[] { 1, 0 }, new[] { 1, 2 }, new[] { 1, 3 }, new[] { 3, 4 } }, new[] { 0, 1, 0, 1, 1 }));
            CollectionAssert.AreEqual(new[] { -1, -1 }, graphs.MaxSubgraphScore(2, new[] { new[] { 0, 1 } }, new[] { 0, 0 }));
        }

        [TestMethod]
        public void InteractionCosts_SumsSameGroupTreeDistances()
        {
            Assert.AreEqual(4L, graphs.InteractionCosts(3, new[] { new[] { 0, 1 }, new[] { 1, 2 } }, new[] { 1, 1, 1 }));
            Assert.AreEqual(0L, graphs.InteractionCosts(2, new[] { new[] { 0, 1 } }, new[] { 9, 8 }));
        }

        [TestMethod]
        public void MinimumFlips_ReturnsSortedMinimumEdgesOrImpossible()
        {
            CollectionAssert.AreEqual(new[] { 0 }, graphs.MinimumFlips(3, new[] { new[] { 0, 1 }, new[] { 1, 2 } }, "010", "100").ToArray());
            CollectionAssert.AreEqual(new[] { -1 }, graphs.MinimumFlips(2, new[] { new[] { 0, 1 } }, "00", "01").ToArray());
        }

        [TestMethod]
        public void SpecialNodes_CountsPythagoreanDistances()
        {
            Assert.AreEqual(3, graphs.SpecialNodes(4, new[] { new[] { 0, 1 }, new[] { 0, 2 }, new[] { 0, 3 } }, 1, 2, 3));
            Assert.AreEqual(0, graphs.SpecialNodes(4, new[] { new[] { 0, 1 }, new[] { 1, 2 }, new[] { 2, 3 } }, 0, 3, 2));
        }

        [TestMethod]
        public void PalindromePath_HandlesQueriesAndUpdates()
        {
            CollectionAssert.AreEqual(
                new[] { true, false },
                graphs.PalindromePath(3, new[] { new[] { 0, 1 }, new[] { 1, 2 } }, "aac", new[] { "query 0 2", "update 1 b", "query 0 2" }).ToArray());
        }

        [TestMethod]
        public void NumberOfEdgesAdded_RejectsOddCycles()
        {
            Assert.AreEqual(2, graphs.NumberOfEdgesAdded(3, new[] { new[] { 0, 1, 1 }, new[] { 1, 2, 1 }, new[] { 0, 2, 1 } }));
            Assert.AreEqual(3, graphs.NumberOfEdgesAdded(3, new[] { new[] { 0, 1, 1 }, new[] { 1, 2, 1 }, new[] { 0, 2, 0 } }));
        }

        [TestMethod]
        public void FindDegrees_CountsEdgesAndIsolatedVertices()
        {
            CollectionAssert.AreEqual(new[] { 1, 1, 0 }, graphs.FindDegrees(new[] { new[] { 0, 1, 0 }, new[] { 1, 0, 0 }, new[] { 0, 0, 0 } }));
        }

        [TestMethod]
        public void ColorGrid_ResolvesEqualDistanceTiesByLargestColor()
        {
            int[][] actual = graphs.ColorGrid(3, 3, new[] { new[] { 0, 0, 1 }, new[] { 2, 2, 2 } });
            CollectionAssert.AreEqual(new[] { "112", "122", "222" }, ToRows(actual));
            CollectionAssert.AreEqual(new[] { "55", "55" }, ToRows(graphs.ColorGrid(2, 2, new[] { new[] { 1, 1, 5 } })));
        }

        [TestMethod]
        public void EvenSumSubgraphs_CountsOnlyConnectedEvenSubsets()
        {
            Assert.AreEqual(2, graphs.EvenSumSubgraphs(new[] { 1, 0, 1 }, new[] { new[] { 0, 1 }, new[] { 1, 2 } }));
            Assert.AreEqual(1, graphs.EvenSumSubgraphs(new[] { 0 }, System.Array.Empty<int[]>()));
        }

        [TestMethod]
        public void MinimumThreshold_FindsThresholdOrReportsNoPath()
        {
            Assert.AreEqual(4, graphs.MinimumThreshold(6, new[] { new[] { 0, 1, 5 }, new[] { 1, 2, 3 }, new[] { 3, 4, 4 }, new[] { 4, 5, 1 }, new[] { 1, 4, 2 } }, 0, 3, 1));
            Assert.AreEqual(-1, graphs.MinimumThreshold(2, System.Array.Empty<int[]>(), 0, 1, 0));
        }

        [TestMethod]
        public void ShortestPath_EnforcesConsecutiveLabelLimit()
        {
            int[][] edges = { new[] { 0, 1, 1 }, new[] { 1, 2, 1 }, new[] { 0, 2, 3 } };
            Assert.AreEqual(3, graphs.ShortestPath(3, edges, "aab", 1));
            Assert.AreEqual(2, graphs.ShortestPath(3, edges, "aab", 2));
            Assert.AreEqual(-1, graphs.ShortestPath(3, new[] { new[] { 0, 1, 1 }, new[] { 1, 2, 1 } }, "aaa", 2));
        }

        [TestMethod]
        public void MinTimeMaxPower_OptimizesTimeThenRemainingPower()
        {
            CollectionAssert.AreEqual(new long[] { 3, 0 }, graphs.MinTimeMaxPower(5, new[] { new[] { 0, 1, 1 }, new[] { 1, 4, 1 }, new[] { 0, 2, 1 }, new[] { 2, 3, 1 }, new[] { 3, 4, 1 } }, 4, new[] { 2, 3, 1, 1, 1 }, 0, 4));
            CollectionAssert.AreEqual(new long[] { 0, 3 }, graphs.MinTimeMaxPower(1, System.Array.Empty<int[]>(), 3, new[] { 1 }, 0, 0));
            CollectionAssert.AreEqual(new long[] { -1, -1 }, graphs.MinTimeMaxPower(2, System.Array.Empty<int[]>(), 1, new[] { 1, 1 }, 0, 1));
        }

        [TestMethod]
        public void MaxPartitionFactor_SplitsIncompatibleClosePairs()
        {
            Assert.AreEqual(4, graphs.MaxPartitionFactor(new[] { new[] { 0, 0 }, new[] { 0, 2 }, new[] { 2, 0 }, new[] { 2, 2 } }));
            Assert.AreEqual(0, graphs.MaxPartitionFactor(new[] { new[] { 0, 0 }, new[] { 1, 1 } }));
        }

        [TestMethod]
        public void SumOfAncestors_MatchesSquareFreeKernels()
        {
            Assert.AreEqual(3L, graphs.SumOfAncestors(3, new[] { new[] { 0, 1 }, new[] { 1, 2 } }, new[] { 2, 8, 2 }));
            Assert.AreEqual(1L, graphs.SumOfAncestors(3, new[] { new[] { 0, 1 }, new[] { 0, 2 } }, new[] { 1, 2, 4 }));
        }

        [TestMethod]
        public void MaxActivated_ConnectsCoordinateComponents()
        {
            Assert.AreEqual(4, graphs.MaxActivated(new[] { new[] { 1, 1 }, new[] { 1, 2 }, new[] { 2, 2 } }));
            Assert.AreEqual(3, graphs.MaxActivated(new[] { new[] { 2, 2 }, new[] { 1, 1 }, new[] { 3, 3 } }));
        }

        [TestMethod]
        public void MinCost_BuysLocallyOrUsesCheaperShop()
        {
            CollectionAssert.AreEqual(new[] { 6, 3 }, graphs.MinCost(2, new[] { 8, 3 }, new[] { new[] { 0, 1, 1, 2 } }));
            CollectionAssert.AreEqual(new[] { 5, 11, 1 }, graphs.MinCost(3, new[] { 10, 11, 1 }, new[] { new[] { 0, 2, 1, 3 }, new[] { 1, 2, 3, 4 }, new[] { 0, 1, 5, 2 } }));
        }

        [TestMethod]
        public void CountValidSubsets_ExcludesAdjacentAndEmptySubsets()
        {
            Assert.AreEqual(1, graphs.CountValidSubsets(new[] { -1, 0, 1 }, new[] { 1, 2, 3 }, 3));
            Assert.AreEqual(2, graphs.CountValidSubsets(new[] { -1, 0, 0, 0 }, new[] { 2, 1, 2, 1 }, 3));
        }

        [TestMethod]
        public void FinishTime_EvaluatesLeafAndBranchingTasks()
        {
            Assert.AreEqual(17L, graphs.FinishTime(3, new[] { new[] { 0, 1 }, new[] { 1, 2 } }, new[] { 9, 5, 3 }));
            Assert.AreEqual(12L, graphs.FinishTime(3, new[] { new[] { 0, 1 }, new[] { 0, 2 } }, new[] { 4, 7, 6 }));
        }

        [TestMethod]
        public void MinCost_AlternatesDirectionsAndCanWait()
        {
            Assert.AreEqual(8L, graphs.MinCost(2, 2, new[] { new[] { 5, 3 }, new[] { 1, 4 } }));
            Assert.AreEqual(7L, graphs.MinCost(2, 2, new[] { new[] { 0, 7 }, new[] { 3, 2 } }));
        }

        [TestMethod]
        public void WeightedSum_WeightsNodesByHeightAndDepth()
        {
            Assert.AreEqual(37L, graphs.WeightedSum(new[] { -1, 0, 0, 0, 2, 2 }, new[] { 5, 2, 3, 1, 4, 6 }));
            Assert.AreEqual(20L, graphs.WeightedSum(new[] { -1, 0, 1, 2 }, new[] { 1, 2, 3, 4 }));
        }

        private static char[][] CreateBoard(string[] rows)
        {
            return rows.Select(row => row.ToCharArray()).ToArray();
        }

        private static string[] ToRows(int[][] matrix)
        {
            return matrix.Select(row => string.Concat(row)).ToArray();
        }

        private static string[] ToRows(char[][] board)
        {
            return board.Select(row => new string(row)).ToArray();
        }
    }
}
