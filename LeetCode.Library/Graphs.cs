using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace LeetCode.Library
{
    public class Graphs
    {
        /// <summary>
        /// <a href="https://leetcode.com/problems/word-ladder-ii/">126. Word Ladder II (hard)</a>
        /// Finds all shortest transformation sequences from beginWord to endWord, changing one letter at a time and using only words in wordList.
        /// </summary>
        /// <param name="beginWord">The starting word.</param>
        /// <param name="endWord">The target word.</param>
        /// <param name="wordList">The allowed intermediate and target words.</param>
        /// <returns>All shortest transformation sequences, or an empty list when no sequence exists.</returns>
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            var result = new List<IList<string>>();
            if (beginWord == endWord)
            {
                result.Add(new List<string> { beginWord });
                return result;
            }

            var words = new HashSet<string>(wordList);
            if (!words.Contains(endWord))
                return result;

            words.Remove(beginWord);
            var parents = new Dictionary<string, List<string>>();
            var currentLevel = new HashSet<string> { beginWord };
            bool found = false;

            while (currentLevel.Count > 0 && !found)
            {
                foreach (var word in currentLevel)
                    words.Remove(word);

                var nextLevel = new HashSet<string>();
                foreach (var word in currentLevel)
                {
                    foreach (var next in GetWordNeighbors(word, words))
                    {
                        if (!parents.ContainsKey(next))
                            parents[next] = new List<string>();

                        parents[next].Add(word);
                        if (next == endWord)
                            found = true;

                        nextLevel.Add(next);
                    }
                }

                currentLevel = nextLevel;
            }

            if (!found)
                return result;

            var path = new List<string> { endWord };
            BuildLadders(endWord, beginWord, parents, path, result);
            return result;
        }

        private static void BuildLadders(string word, string beginWord, Dictionary<string, List<string>> parents, List<string> path, List<IList<string>> result)
        {
            if (word == beginWord)
            {
                var ladder = new List<string>(path);
                ladder.Reverse();
                result.Add(ladder);
                return;
            }

            if (!parents.ContainsKey(word))
                return;

            foreach (var parent in parents[word])
            {
                path.Add(parent);
                BuildLadders(parent, beginWord, parents, path, result);
                path.RemoveAt(path.Count - 1);
            }
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/word-ladder/">127. Word Ladder (hard)</a>
        /// Returns the length of the shortest transformation sequence from beginWord to endWord, changing one letter at a time and using only words in wordList.
        /// </summary>
        /// <param name="beginWord">The starting word.</param>
        /// <param name="endWord">The target word.</param>
        /// <param name="wordList">The allowed intermediate and target words.</param>
        /// <returns>The number of words in the shortest sequence, or 0 when no sequence exists.</returns>
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            if (beginWord == endWord)
                return 1;

            var words = new HashSet<string>(wordList);
            if (!words.Contains(endWord))
                return 0;

            var queue = new Queue<(string Word, int Length)>();
            queue.Enqueue((beginWord, 1));
            words.Remove(beginWord);

            while (queue.Count > 0)
            {
                var (word, length) = queue.Dequeue();
                foreach (var next in GetWordNeighbors(word, words))
                {
                    if (next == endWord)
                        return length + 1;

                    words.Remove(next);
                    queue.Enqueue((next, length + 1));
                }
            }

            return 0;
        }

        private static IEnumerable<string> GetWordNeighbors(string word, HashSet<string> words)
        {
            var chars = word.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                char original = chars[i];
                for (char c = 'a'; c <= 'z'; c++)
                {
                    if (c == original)
                        continue;

                    chars[i] = c;
                    string candidate = new string(chars);
                    if (words.Contains(candidate))
                        yield return candidate;
                }

                chars[i] = original;
            }
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/surrounded-regions/">130. Surrounded Regions (medium)</a>
        /// Captures every 'O' region fully surrounded by 'X' by modifying the board in-place.
        /// </summary>
        /// <param name="board">The board to update.</param>
        public void Solve(char[][] board)
        {
            if (board == null || board.Length == 0 || board[0].Length == 0)
                return;

            int rows = board.Length;
            int cols = board[0].Length;

            for (int r = 0; r < rows; r++)
            {
                MarkBorderRegion(board, r, 0);
                MarkBorderRegion(board, r, cols - 1);
            }

            for (int c = 0; c < cols; c++)
            {
                MarkBorderRegion(board, 0, c);
                MarkBorderRegion(board, rows - 1, c);
            }

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (board[r][c] == 'O')
                        board[r][c] = 'X';
                    else if (board[r][c] == '#')
                        board[r][c] = 'O';
                }
            }
        }

        private static void MarkBorderRegion(char[][] board, int row, int col)
        {
            if (row < 0 || row >= board.Length || col < 0 || col >= board[0].Length || board[row][col] != 'O')
                return;

            var queue = new Queue<(int Row, int Col)>();
            queue.Enqueue((row, col));
            board[row][col] = '#';

            int[] directions = { 1, 0, -1, 0, 1 };
            while (queue.Count > 0)
            {
                var (r, c) = queue.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int nextRow = r + directions[i];
                    int nextCol = c + directions[i + 1];
                    if (nextRow >= 0 && nextRow < board.Length && nextCol >= 0 && nextCol < board[0].Length && board[nextRow][nextCol] == 'O')
                    {
                        board[nextRow][nextCol] = '#';
                        queue.Enqueue((nextRow, nextCol));
                    }
                }
            }
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/clone-graph/">133. Clone Graph (medium)</a>
        /// Deep-copies an undirected graph from the given node.
        /// </summary>
        /// <param name="node">A node in the graph to clone.</param>
        /// <returns>The corresponding node in the cloned graph, or null when the input is null.</returns>
        public Node CloneGraph(Node node)
        {
            if (node == null)
                return null;

            var clones = new Dictionary<Node, Node>();
            var queue = new Queue<Node>();
            clones[node] = new Node(node.val);
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                foreach (var neighbor in current.neighbors)
                {
                    if (!clones.ContainsKey(neighbor))
                    {
                        clones[neighbor] = new Node(neighbor.val);
                        queue.Enqueue(neighbor);
                    }

                    clones[current].neighbors.Add(clones[neighbor]);
                }
            }

            return clones[node];
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/evaluate-reverse-polish-notation/">150. Evaluate Reverse Polish Notation (medium)</a>
        /// Evaluates an arithmetic expression in Reverse Polish Notation using integer division truncated toward zero.
        /// </summary>
        /// <param name="tokens">The RPN tokens containing integers and +, -, *, / operators.</param>
        /// <returns>The evaluated integer result.</returns>
        public int EvalRPN(string[] tokens)
        {
            var stack = new Stack<int>();
            foreach (string token in tokens)
            {
                if (token.Length == 1 && "+-*/".Contains(token))
                {
                    int right = stack.Pop();
                    int left = stack.Pop();
                    stack.Push(token[0] switch
                    {
                        '+' => left + right,
                        '-' => left - right,
                        '*' => left * right,
                        _ => left / right
                    });
                }
                else
                {
                    stack.Push(int.Parse(token));
                }
            }

            return stack.Pop();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/number-of-islands/">200. Number of Islands (medium)</a>
        /// Counts connected groups of '1' cells in a 2D grid where connections are horizontal or vertical.
        /// </summary>
        /// <param name="grid">The land/water grid to inspect.</param>
        /// <returns>The number of islands in <paramref name="grid"/>.</returns>
        public int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0 || grid[0].Length == 0)
                return 0;

            int count = 0;
            for (int r = 0; r < grid.Length; r++)
            {
                for (int c = 0; c < grid[0].Length; c++)
                {
                    if (grid[r][c] == '1')
                    {
                        count++;
                        SinkIsland(grid, r, c);
                    }
                }
            }

            return count;
        }

        private static void SinkIsland(char[][] grid, int row, int col)
        {
            var queue = new Queue<(int Row, int Col)>();
            queue.Enqueue((row, col));
            grid[row][col] = '0';
            int[] directions = { 1, 0, -1, 0, 1 };

            while (queue.Count > 0)
            {
                var (r, c) = queue.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int nextRow = r + directions[i];
                    int nextCol = c + directions[i + 1];
                    if (nextRow >= 0 && nextRow < grid.Length && nextCol >= 0 && nextCol < grid[0].Length && grid[nextRow][nextCol] == '1')
                    {
                        grid[nextRow][nextCol] = '0';
                        queue.Enqueue((nextRow, nextCol));
                    }
                }
            }
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/course-schedule/">207. Course Schedule (medium)</a>
        /// Determines whether every course can be completed by detecting whether the prerequisite graph is acyclic.
        /// </summary>
        /// <param name="numCourses">The number of courses labeled from 0 to numCourses - 1.</param>
        /// <param name="prerequisites">Pairs where [course, prerequisite] means the prerequisite must be taken first.</param>
        /// <returns><see langword="true"/> when all courses can be completed; otherwise, <see langword="false"/>.</returns>
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            return BuildCourseOrder(numCourses, prerequisites).Count == numCourses;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/course-schedule-ii/">210. Course Schedule II (medium)</a>
        /// Returns one valid topological ordering of courses that satisfies all prerequisites.
        /// </summary>
        /// <param name="numCourses">The number of courses labeled from 0 to numCourses - 1.</param>
        /// <param name="prerequisites">Pairs where [course, prerequisite] means the prerequisite must be taken first.</param>
        /// <returns>A valid course order, or an empty array when a cycle prevents completing all courses.</returns>
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            var order = BuildCourseOrder(numCourses, prerequisites);
            return order.Count == numCourses ? order.ToArray() : Array.Empty<int>();
        }

        private static List<int> BuildCourseOrder(int numCourses, int[][] prerequisites)
        {
            var graph = new List<int>[numCourses];
            var indegree = new int[numCourses];
            for (int i = 0; i < numCourses; i++)
                graph[i] = new List<int>();

            foreach (var edge in prerequisites)
            {
                graph[edge[1]].Add(edge[0]);
                indegree[edge[0]]++;
            }

            var queue = new Queue<int>();
            for (int course = 0; course < numCourses; course++)
            {
                if (indegree[course] == 0)
                    queue.Enqueue(course);
            }

            var order = new List<int>(numCourses);
            while (queue.Count > 0)
            {
                int course = queue.Dequeue();
                order.Add(course);
                foreach (int next in graph[course])
                {
                    indegree[next]--;
                    if (indegree[next] == 0)
                        queue.Enqueue(next);
                }
            }

            return order;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-height-trees/">310. Minimum Height Trees (medium)</a>
        /// Finds all tree centers that produce a minimum possible rooted-tree height.
        /// </summary>
        /// <param name="n">The number of nodes labeled from 0 to n - 1.</param>
        /// <param name="edges">Undirected tree edges.</param>
        /// <returns>The root labels of every minimum-height tree.</returns>
        public IList<int> FindMinHeightTrees(int n, int[][] edges)
        {
            if (n == 1)
                return new List<int> { 0 };

            var neighbors = new HashSet<int>[n];
            for (int i = 0; i < n; i++)
                neighbors[i] = new HashSet<int>();

            foreach (var edge in edges)
            {
                neighbors[edge[0]].Add(edge[1]);
                neighbors[edge[1]].Add(edge[0]);
            }

            var leaves = new Queue<int>();
            for (int node = 0; node < n; node++)
            {
                if (neighbors[node].Count == 1)
                    leaves.Enqueue(node);
            }

            int remaining = n;
            while (remaining > 2)
            {
                int layerSize = leaves.Count;
                remaining -= layerSize;
                for (int i = 0; i < layerSize; i++)
                {
                    int leaf = leaves.Dequeue();
                    int parent = neighbors[leaf].First();
                    neighbors[parent].Remove(leaf);
                    if (neighbors[parent].Count == 1)
                        leaves.Enqueue(parent);
                }
            }

            return leaves.ToList();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/reconstruct-itinerary/">332. Reconstruct Itinerary (hard)</a>
        /// Reconstructs the lexicographically smallest itinerary that uses every airline ticket exactly once starting from JFK.
        /// </summary>
        /// <param name="tickets">Directed tickets represented as [from, to] airport pairs.</param>
        /// <returns>The airport sequence for the reconstructed itinerary.</returns>
        public IList<string> FindItinerary(IList<IList<string>> tickets)
        {
            var routes = new Dictionary<string, List<string>>();
            foreach (var ticket in tickets)
            {
                if (!routes.ContainsKey(ticket[0]))
                    routes[ticket[0]] = new List<string>();

                routes[ticket[0]].Add(ticket[1]);
            }

            foreach (var destinations in routes.Values)
                destinations.Sort((left, right) => string.CompareOrdinal(right, left));

            var itinerary = new List<string>();
            VisitAirport("JFK", routes, itinerary);
            itinerary.Reverse();
            return itinerary;
        }

        private static void VisitAirport(string airport, Dictionary<string, List<string>> routes, List<string> itinerary)
        {
            if (routes.TryGetValue(airport, out var destinations))
            {
                while (destinations.Count > 0)
                {
                    string next = destinations[destinations.Count - 1];
                    destinations.RemoveAt(destinations.Count - 1);
                    VisitAirport(next, routes, itinerary);
                }
            }

            itinerary.Add(airport);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/evaluate-division/">399. Evaluate Division (medium)</a>
        /// Answers division queries by traversing a weighted bidirectional graph of known equations.
        /// </summary>
        /// <param name="equations">Variable pairs representing dividends and divisors.</param>
        /// <param name="values">The quotient for each corresponding equation.</param>
        /// <param name="queries">Variable pairs to evaluate.</param>
        /// <returns>The quotient for each query, or -1.0 when no relationship is known.</returns>
        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            var graph = new Dictionary<string, List<(string Neighbor, double Weight)>>();
            for (int i = 0; i < equations.Count; i++)
            {
                string dividend = equations[i][0];
                string divisor = equations[i][1];
                if (!graph.ContainsKey(dividend))
                    graph[dividend] = new List<(string, double)>();
                if (!graph.ContainsKey(divisor))
                    graph[divisor] = new List<(string, double)>();

                graph[dividend].Add((divisor, values[i]));
                graph[divisor].Add((dividend, 1.0 / values[i]));
            }

            var answers = new double[queries.Count];
            for (int i = 0; i < queries.Count; i++)
                answers[i] = EvaluateDivisionQuery(graph, queries[i][0], queries[i][1]);

            return answers;
        }

        private static double EvaluateDivisionQuery(Dictionary<string, List<(string Neighbor, double Weight)>> graph, string start, string end)
        {
            if (!graph.ContainsKey(start) || !graph.ContainsKey(end))
                return -1.0;
            if (start == end)
                return 1.0;

            var visited = new HashSet<string> { start };
            var queue = new Queue<(string Variable, double Product)>();
            queue.Enqueue((start, 1.0));

            while (queue.Count > 0)
            {
                var (variable, product) = queue.Dequeue();
                foreach (var (neighbor, weight) in graph[variable])
                {
                    if (!visited.Add(neighbor))
                        continue;
                    double nextProduct = product * weight;
                    if (neighbor == end)
                        return nextProduct;
                    queue.Enqueue((neighbor, nextProduct));
                }
            }

            return -1.0;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/pacific-atlantic-water-flow/">417. Pacific Atlantic Water Flow (medium)</a>
        /// Finds cells from which water can flow to both oceans by reverse-searching from each ocean border.
        /// </summary>
        /// <param name="heights">The matrix of cell heights.</param>
        /// <returns>Coordinates [row, column] that can reach both the Pacific and Atlantic oceans.</returns>
        public IList<IList<int>> PacificAtlantic(int[][] heights)
        {
            int rows = heights.Length;
            int cols = heights[0].Length;
            var pacific = new bool[rows, cols];
            var atlantic = new bool[rows, cols];
            var pacificStarts = new Queue<(int Row, int Col)>();
            var atlanticStarts = new Queue<(int Row, int Col)>();

            for (int r = 0; r < rows; r++)
            {
                pacificStarts.Enqueue((r, 0));
                atlanticStarts.Enqueue((r, cols - 1));
            }

            for (int c = 0; c < cols; c++)
            {
                pacificStarts.Enqueue((0, c));
                atlanticStarts.Enqueue((rows - 1, c));
            }

            MarkOceanReachable(heights, pacificStarts, pacific);
            MarkOceanReachable(heights, atlanticStarts, atlantic);

            var result = new List<IList<int>>();
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (pacific[r, c] && atlantic[r, c])
                        result.Add(new List<int> { r, c });
                }
            }

            return result;
        }

        private static void MarkOceanReachable(int[][] heights, Queue<(int Row, int Col)> queue, bool[,] reachable)
        {
            int rows = heights.Length;
            int cols = heights[0].Length;
            int[] directions = { 1, 0, -1, 0, 1 };

            while (queue.Count > 0)
            {
                var (row, col) = queue.Dequeue();
                if (reachable[row, col])
                    continue;

                reachable[row, col] = true;
                for (int i = 0; i < 4; i++)
                {
                    int nextRow = row + directions[i];
                    int nextCol = col + directions[i + 1];
                    if (nextRow >= 0 && nextRow < rows && nextCol >= 0 && nextCol < cols &&
                        !reachable[nextRow, nextCol] && heights[nextRow][nextCol] >= heights[row][col])
                    {
                        queue.Enqueue((nextRow, nextCol));
                    }
                }
            }
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-genetic-mutation/">433. Minimum Genetic Mutation (medium)</a>
        /// Finds the minimum number of one-character gene mutations needed to reach the target gene using only bank genes.
        /// </summary>
        /// <param name="startGene">The starting gene string.</param>
        /// <param name="endGene">The target gene string.</param>
        /// <param name="bank">The allowed intermediate and target gene strings.</param>
        /// <returns>The fewest mutations needed, or -1 when the target cannot be reached.</returns>
        public int MinMutation(string startGene, string endGene, string[] bank)
        {
            if (startGene == endGene)
                return 0;

            var genes = new HashSet<string>(bank);
            if (!genes.Contains(endGene))
                return -1;

            char[] choices = { 'A', 'C', 'G', 'T' };
            var queue = new Queue<(string Gene, int Steps)>();
            queue.Enqueue((startGene, 0));
            genes.Remove(startGene);

            while (queue.Count > 0)
            {
                var (gene, steps) = queue.Dequeue();
                var chars = gene.ToCharArray();
                for (int i = 0; i < chars.Length; i++)
                {
                    char original = chars[i];
                    foreach (char choice in choices)
                    {
                        if (choice == original)
                            continue;

                        chars[i] = choice;
                        string next = new string(chars);
                        if (!genes.Contains(next))
                            continue;
                        if (next == endGene)
                            return steps + 1;

                        genes.Remove(next);
                        queue.Enqueue((next, steps + 1));
                    }

                    chars[i] = original;
                }
            }

            return -1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/01-matrix/">542. 01 Matrix (medium)</a>
        /// Computes the distance from every cell to its nearest zero using multi-source breadth-first search.
        /// </summary>
        /// <param name="mat">The binary matrix.</param>
        /// <returns>A matrix whose cells contain nearest-zero Manhattan distances.</returns>
        public int[][] UpdateMatrix(int[][] mat)
        {
            int rows = mat.Length;
            int cols = mat[0].Length;
            var distances = new int[rows][];
            var queue = new Queue<(int Row, int Col)>();

            for (int r = 0; r < rows; r++)
            {
                distances[r] = new int[cols];
                for (int c = 0; c < cols; c++)
                {
                    if (mat[r][c] == 0)
                    {
                        queue.Enqueue((r, c));
                    }
                    else
                    {
                        distances[r][c] = -1;
                    }
                }
            }

            int[] directions = { 1, 0, -1, 0, 1 };
            while (queue.Count > 0)
            {
                var (row, col) = queue.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int nextRow = row + directions[i];
                    int nextCol = col + directions[i + 1];
                    if (nextRow >= 0 && nextRow < rows && nextCol >= 0 && nextCol < cols && distances[nextRow][nextCol] == -1)
                    {
                        distances[nextRow][nextCol] = distances[row][col] + 1;
                        queue.Enqueue((nextRow, nextCol));
                    }
                }
            }

            return distances;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/number-of-provinces/">547. Number of Provinces (medium)</a>
        /// Counts connected components in an adjacency matrix of directly connected cities.
        /// </summary>
        /// <param name="isConnected">A symmetric adjacency matrix where 1 indicates a direct connection.</param>
        /// <returns>The number of provinces.</returns>
        public int FindCircleNum(int[][] isConnected)
        {
            int n = isConnected.Length;
            var visited = new bool[n];
            int provinces = 0;

            for (int city = 0; city < n; city++)
            {
                if (visited[city])
                    continue;

                provinces++;
                var queue = new Queue<int>();
                queue.Enqueue(city);
                visited[city] = true;
                while (queue.Count > 0)
                {
                    int current = queue.Dequeue();
                    for (int next = 0; next < n; next++)
                    {
                        if (isConnected[current][next] == 1 && !visited[next])
                        {
                            visited[next] = true;
                            queue.Enqueue(next);
                        }
                    }
                }
            }

            return provinces;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/redundant-connection/">684. Redundant Connection (medium)</a>
        /// Finds the first undirected edge that creates a cycle in an otherwise tree-like graph.
        /// </summary>
        /// <param name="edges">Undirected edges in input order.</param>
        /// <returns>The redundant edge that should be removed.</returns>
        public int[] FindRedundantConnection(int[][] edges)
        {
            var unionFind = new DisjointSet(edges.Length + 1);
            foreach (var edge in edges)
            {
                if (!unionFind.Union(edge[0], edge[1]))
                    return edge;
            }

            return Array.Empty<int>();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/employee-importance/">690. Employee Importance (medium)</a>
        /// Sums one employee's importance and all direct or indirect subordinate importance values.
        /// </summary>
        /// <param name="employees">All employees available for lookup by id.</param>
        /// <param name="id">The id of the employee whose organization importance should be calculated.</param>
        /// <returns>The total importance for the employee and all subordinates.</returns>
        public int GetImportance(IList<Employee> employees, int id)
        {
            var byId = employees.ToDictionary(employee => employee.id);
            var queue = new Queue<int>();
            queue.Enqueue(id);
            int total = 0;

            while (queue.Count > 0)
            {
                var employee = byId[queue.Dequeue()];
                total += employee.importance;
                foreach (int subordinate in employee.subordinates)
                    queue.Enqueue(subordinate);
            }

            return total;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/max-area-of-island/">695. Max Area of Island (medium)</a>
        /// Finds the largest four-directionally connected component of land cells in a binary grid.
        /// </summary>
        /// <param name="grid">The binary grid where 1 is land and 0 is water.</param>
        /// <returns>The maximum island area, or 0 when no land exists.</returns>
        public int MaxAreaOfIsland(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            int best = 0;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (grid[r][c] == 1)
                        best = Math.Max(best, MeasureIsland(grid, r, c));
                }
            }

            return best;
        }

        private static int MeasureIsland(int[][] grid, int row, int col)
        {
            var queue = new Queue<(int Row, int Col)>();
            queue.Enqueue((row, col));
            grid[row][col] = 0;
            int area = 0;
            int[] directions = { 1, 0, -1, 0, 1 };

            while (queue.Count > 0)
            {
                var (r, c) = queue.Dequeue();
                area++;
                for (int i = 0; i < 4; i++)
                {
                    int nextRow = r + directions[i];
                    int nextCol = c + directions[i + 1];
                    if (nextRow >= 0 && nextRow < grid.Length && nextCol >= 0 && nextCol < grid[0].Length && grid[nextRow][nextCol] == 1)
                    {
                        grid[nextRow][nextCol] = 0;
                        queue.Enqueue((nextRow, nextCol));
                    }
                }
            }

            return area;
        }


        /// <summary>
        /// <a href="https://leetcode.com/problems/accounts-merge/">721. Accounts Merge (medium)</a>
        /// Merges accounts that share at least one email address using union-find over account indexes.
        /// </summary>
        /// <param name="accounts">Accounts where the first value is the name and remaining values are emails.</param>
        /// <returns>Merged accounts with the owner name followed by sorted email addresses.</returns>
        public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
        {
            var unionFind = new DisjointSet(accounts.Count);
            var emailOwner = new Dictionary<string, int>();
            for (int i = 0; i < accounts.Count; i++)
            {
                for (int j = 1; j < accounts[i].Count; j++)
                {
                    string email = accounts[i][j];
                    if (emailOwner.TryGetValue(email, out int owner))
                        unionFind.Union(i, owner);
                    else
                        emailOwner[email] = i;
                }
            }

            var merged = new Dictionary<int, SortedSet<string>>();
            foreach (var pair in emailOwner)
            {
                int root = unionFind.Find(pair.Value);
                if (!merged.ContainsKey(root))
                    merged[root] = new SortedSet<string>(StringComparer.Ordinal);

                merged[root].Add(pair.Key);
            }

            var result = new List<IList<string>>();
            foreach (var pair in merged)
            {
                var account = new List<string> { accounts[pair.Key][0] };
                account.AddRange(pair.Value);
                result.Add(account);
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/flood-fill/">733. Flood Fill (easy)</a>
        /// Recolors the four-directionally connected component containing the starting pixel.
        /// </summary>
        /// <param name="image">The image color grid.</param>
        /// <param name="sr">The starting row.</param>
        /// <param name="sc">The starting column.</param>
        /// <param name="color">The replacement color.</param>
        /// <returns>The updated image.</returns>
        public int[][] FloodFill(int[][] image, int sr, int sc, int color)
        {
            int original = image[sr][sc];
            if (original == color)
                return image;

            var queue = new Queue<(int Row, int Col)>();
            queue.Enqueue((sr, sc));
            image[sr][sc] = color;
            int[] directions = { 1, 0, -1, 0, 1 };
            while (queue.Count > 0)
            {
                var (row, col) = queue.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int nextRow = row + directions[i];
                    int nextCol = col + directions[i + 1];
                    if (nextRow >= 0 && nextRow < image.Length && nextCol >= 0 && nextCol < image[0].Length && image[nextRow][nextCol] == original)
                    {
                        image[nextRow][nextCol] = color;
                        queue.Enqueue((nextRow, nextCol));
                    }
                }
            }

            return image;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/network-delay-time/">743. Network Delay Time (medium)</a>
        /// Computes how long a signal needs to reach every node in a directed weighted graph.
        /// </summary>
        /// <param name="times">Edges [source, target, travelTime].</param>
        /// <param name="n">The number of nodes labeled from 1 to n.</param>
        /// <param name="k">The source node.</param>
        /// <returns>The maximum shortest-path distance from k, or -1 when a node is unreachable.</returns>
        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            var graph = new List<(int Node, int Weight)>[n + 1];
            for (int i = 1; i <= n; i++)
                graph[i] = new List<(int, int)>();
            foreach (var time in times)
                graph[time[0]].Add((time[1], time[2]));

            var distances = Enumerable.Repeat(int.MaxValue, n + 1).ToArray();
            var queue = new PriorityQueue<int, int>();
            distances[k] = 0;
            queue.Enqueue(k, 0);
            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                foreach (var (next, weight) in graph[node])
                {
                    int candidate = distances[node] + weight;
                    if (candidate < distances[next])
                    {
                        distances[next] = candidate;
                        queue.Enqueue(next, candidate);
                    }
                }
            }

            int answer = 0;
            for (int node = 1; node <= n; node++)
            {
                if (distances[node] == int.MaxValue)
                    return -1;
                answer = Math.Max(answer, distances[node]);
            }

            return answer;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/open-the-lock/">752. Open the Lock (medium)</a>
        /// Finds the fewest wheel turns needed to reach the target combination while avoiding deadends.
        /// </summary>
        /// <param name="deadends">Forbidden lock combinations.</param>
        /// <param name="target">The target lock combination.</param>
        /// <returns>The minimum turn count, or -1 when unreachable.</returns>
        public int OpenLock(string[] deadends, string target)
        {
            var blocked = new HashSet<string>(deadends);
            if (blocked.Contains("0000"))
                return -1;
            if (target == "0000")
                return 0;

            var visited = new HashSet<string> { "0000" };
            var queue = new Queue<(string Code, int Steps)>();
            queue.Enqueue(("0000", 0));
            while (queue.Count > 0)
            {
                var (code, steps) = queue.Dequeue();
                foreach (string next in LockNeighbors(code))
                {
                    if (blocked.Contains(next) || !visited.Add(next))
                        continue;
                    if (next == target)
                        return steps + 1;
                    queue.Enqueue((next, steps + 1));
                }
            }

            return -1;
        }

        private static IEnumerable<string> LockNeighbors(string code)
        {
            var chars = code.ToCharArray();
            for (int i = 0; i < 4; i++)
            {
                char original = chars[i];
                chars[i] = original == '9' ? '0' : (char)(original + 1);
                yield return new string(chars);
                chars[i] = original == '0' ? '9' : (char)(original - 1);
                yield return new string(chars);
                chars[i] = original;
            }
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/cheapest-flights-within-k-stops/">787. Cheapest Flights Within K Stops (medium)</a>
        /// Finds the cheapest route price using at most k stops with bounded Bellman-Ford relaxation.
        /// </summary>
        /// <param name="n">The number of cities labeled from 0 to n - 1.</param>
        /// <param name="flights">Flights [from, to, price].</param>
        /// <param name="src">The source city.</param>
        /// <param name="dst">The destination city.</param>
        /// <param name="k">The maximum allowed intermediate stops.</param>
        /// <returns>The cheapest price, or -1 when no route satisfies the stop limit.</returns>
        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
        {
            const int Infinity = 1_000_000_000;
            var costs = Enumerable.Repeat(Infinity, n).ToArray();
            costs[src] = 0;
            for (int step = 0; step <= k; step++)
            {
                int[] next = (int[])costs.Clone();
                foreach (var flight in flights)
                    if (costs[flight[0]] != Infinity)
                        next[flight[1]] = Math.Min(next[flight[1]], costs[flight[0]] + flight[2]);
                costs = next;
            }

            return costs[dst] == Infinity ? -1 : costs[dst];
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/all-paths-from-source-to-target/">797. All Paths From Source to Target (medium)</a>
        /// Enumerates every directed acyclic graph path from node 0 to node n - 1.
        /// </summary>
        /// <param name="graph">Adjacency lists for each node.</param>
        /// <returns>All source-to-target paths.</returns>
        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            var result = new List<IList<int>>();
            var path = new List<int> { 0 };
            DfsAllPaths(graph, 0, path, result);
            return result;
        }

        private static void DfsAllPaths(int[][] graph, int node, List<int> path, List<IList<int>> result)
        {
            if (node == graph.Length - 1)
            {
                result.Add(new List<int>(path));
                return;
            }

            foreach (int next in graph[node])
            {
                path.Add(next);
                DfsAllPaths(graph, next, path, result);
                path.RemoveAt(path.Count - 1);
            }
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-eventual-safe-states/">802. Find Eventual Safe States (medium)</a>
        /// Returns nodes whose every outgoing path eventually reaches a terminal node.
        /// </summary>
        /// <param name="graph">Directed adjacency lists.</param>
        /// <returns>Safe node labels in ascending order.</returns>
        public IList<int> EventualSafeNodes(int[][] graph)
        {
            int n = graph.Length;
            var reverse = new List<int>[n];
            var outdegree = new int[n];
            for (int i = 0; i < n; i++)
                reverse[i] = new List<int>();
            for (int node = 0; node < n; node++)
            {
                outdegree[node] = graph[node].Length;
                foreach (int next in graph[node])
                    reverse[next].Add(node);
            }

            var queue = new Queue<int>();
            for (int node = 0; node < n; node++)
                if (outdegree[node] == 0)
                    queue.Enqueue(node);

            var safe = new bool[n];
            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                safe[node] = true;
                foreach (int previous in reverse[node])
                    if (--outdegree[previous] == 0)
                        queue.Enqueue(previous);
            }

            var result = new List<int>();
            for (int node = 0; node < n; node++)
                if (safe[node])
                    result.Add(node);
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/keys-and-rooms/">841. Keys and Rooms (medium)</a>
        /// Determines whether collected keys can visit every room from room 0.
        /// </summary>
        /// <param name="rooms">Room key lists where each key opens another room.</param>
        /// <returns><see langword="true"/> when every room can be visited; otherwise, <see langword="false"/>.</returns>
        public bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            var visited = new bool[rooms.Count];
            var stack = new Stack<int>();
            stack.Push(0);
            visited[0] = true;
            int count = 0;
            while (stack.Count > 0)
            {
                int room = stack.Pop();
                count++;
                foreach (int key in rooms[room])
                {
                    if (!visited[key])
                    {
                        visited[key] = true;
                        stack.Push(key);
                    }
                }
            }

            return count == rooms.Count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/rotting-oranges/">994. Rotting Oranges (medium)</a>
        /// Simulates minute-by-minute spread from rotten oranges to adjacent fresh oranges.
        /// </summary>
        /// <param name="grid">The orange grid: 0 empty, 1 fresh, 2 rotten.</param>
        /// <returns>Minutes until no fresh orange remains, or -1 when impossible.</returns>
        public int OrangesRotting(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            int fresh = 0;
            var queue = new Queue<(int Row, int Col)>();
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (grid[r][c] == 1)
                        fresh++;
                    else if (grid[r][c] == 2)
                        queue.Enqueue((r, c));
                }
            }

            int minutes = 0;
            int[] directions = { 1, 0, -1, 0, 1 };
            while (queue.Count > 0 && fresh > 0)
            {
                int size = queue.Count;
                for (int s = 0; s < size; s++)
                {
                    var (row, col) = queue.Dequeue();
                    for (int i = 0; i < 4; i++)
                    {
                        int nextRow = row + directions[i];
                        int nextCol = col + directions[i + 1];
                        if (nextRow >= 0 && nextRow < rows && nextCol >= 0 && nextCol < cols && grid[nextRow][nextCol] == 1)
                        {
                            grid[nextRow][nextCol] = 2;
                            fresh--;
                            queue.Enqueue((nextRow, nextCol));
                        }
                    }
                }

                minutes++;
            }

            return fresh == 0 ? minutes : -1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-the-town-judge/">997. Find the Town Judge (easy)</a>
        /// Finds the person trusted by everyone else who trusts nobody.
        /// </summary>
        /// <param name="n">People labeled from 1 to n.</param>
        /// <param name="trust">Trust pairs [trustingPerson, trustedPerson].</param>
        /// <returns>The judge label, or -1 when none exists.</returns>
        public int FindJudge(int n, int[][] trust)
        {
            var score = new int[n + 1];
            foreach (var relation in trust)
            {
                score[relation[0]]--;
                score[relation[1]]++;
            }

            for (int person = 1; person <= n; person++)
                if (score[person] == n - 1)
                    return person;
            return -1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/shortest-path-in-binary-matrix/">1091. Shortest Path in Binary Matrix (medium)</a>
        /// Finds the shortest eight-directional clear path from top-left to bottom-right.
        /// </summary>
        /// <param name="grid">The binary matrix where 0 is clear and 1 is blocked.</param>
        /// <returns>The number of cells in the shortest path, or -1 when none exists.</returns>
        public int ShortestPathBinaryMatrix(int[][] grid)
        {
            int n = grid.Length;
            if (grid[0][0] != 0 || grid[n - 1][n - 1] != 0)
                return -1;

            var queue = new Queue<(int Row, int Col, int Distance)>();
            queue.Enqueue((0, 0, 1));
            grid[0][0] = 1;
            int[] deltas = { -1, 0, 1 };
            while (queue.Count > 0)
            {
                var (row, col, distance) = queue.Dequeue();
                if (row == n - 1 && col == n - 1)
                    return distance;
                foreach (int dr in deltas)
                {
                    foreach (int dc in deltas)
                    {
                        if (dr == 0 && dc == 0)
                            continue;
                        int nextRow = row + dr;
                        int nextCol = col + dc;
                        if (nextRow >= 0 && nextRow < n && nextCol >= 0 && nextCol < n && grid[nextRow][nextCol] == 0)
                        {
                            grid[nextRow][nextCol] = 1;
                            queue.Enqueue((nextRow, nextCol, distance + 1));
                        }
                    }
                }
            }

            return -1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/number-of-operations-to-make-network-connected/">1319. Number of Operations to Make Network Connected (medium)</a>
        /// Counts connected components and spare cables needed to connect all computers.
        /// </summary>
        /// <param name="n">Computers labeled from 0 to n - 1.</param>
        /// <param name="connections">Existing undirected cable connections.</param>
        /// <returns>The minimum reconnections needed, or -1 when there are too few cables.</returns>
        public int MakeConnected(int n, int[][] connections)
        {
            if (connections.Length < n - 1)
                return -1;

            var unionFind = new DisjointSet(n);
            int components = n;
            foreach (var connection in connections)
                if (unionFind.Union(connection[0], connection[1]))
                    components--;
            return components - 1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/min-cost-to-connect-all-points/">1584. Min Cost to Connect All Points (medium)</a>
        /// Builds a minimum spanning tree of points weighted by Manhattan distance using Prim's algorithm.
        /// </summary>
        /// <param name="points">Point coordinates [x, y].</param>
        /// <returns>The minimum total cost to connect all points.</returns>
        public int MinCostConnectPoints(int[][] points)
        {
            int n = points.Length;
            var inTree = new bool[n];
            var minCost = Enumerable.Repeat(int.MaxValue, n).ToArray();
            minCost[0] = 0;
            int total = 0;
            for (int count = 0; count < n; count++)
            {
                int node = -1;
                for (int i = 0; i < n; i++)
                    if (!inTree[i] && (node == -1 || minCost[i] < minCost[node]))
                        node = i;

                inTree[node] = true;
                total += minCost[node];
                for (int next = 0; next < n; next++)
                {
                    if (inTree[next])
                        continue;
                    int cost = Math.Abs(points[node][0] - points[next][0]) + Math.Abs(points[node][1] - points[next][1]);
                    if (cost < minCost[next])
                        minCost[next] = cost;
                }
            }

            return total;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/path-with-minimum-effort/">1631. Path With Minimum Effort (medium)</a>
        /// Finds a top-left to bottom-right path minimizing the maximum absolute height difference between adjacent cells.
        /// </summary>
        /// <param name="heights">The height matrix.</param>
        /// <returns>The minimum possible path effort.</returns>
        public int MinimumEffortPath(int[][] heights)
        {
            int rows = heights.Length;
            int cols = heights[0].Length;
            var best = new int[rows, cols];
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    best[r, c] = int.MaxValue;

            var queue = new PriorityQueue<(int Row, int Col), int>();
            best[0, 0] = 0;
            queue.Enqueue((0, 0), 0);
            int[] directions = { 1, 0, -1, 0, 1 };
            while (queue.Count > 0)
            {
                var (row, col) = queue.Dequeue();
                if (row == rows - 1 && col == cols - 1)
                    return best[row, col];
                for (int i = 0; i < 4; i++)
                {
                    int nextRow = row + directions[i];
                    int nextCol = col + directions[i + 1];
                    if (nextRow < 0 || nextRow >= rows || nextCol < 0 || nextCol >= cols)
                        continue;
                    int candidate = Math.Max(best[row, col], Math.Abs(heights[row][col] - heights[nextRow][nextCol]));
                    if (candidate < best[nextRow, nextCol])
                    {
                        best[nextRow, nextCol] = candidate;
                        queue.Enqueue((nextRow, nextCol), candidate);
                    }
                }
            }

            return 0;
        }


        /// <summary>
        /// <a href="https://leetcode.com/problems/map-of-highest-peak/">1765. Map of Highest Peak (medium)</a>
        /// Assigns heights by expanding from all water cells so adjacent cells differ by at most one and the maximum height is as large as possible.
        /// </summary>
        /// <param name="isWater">Grid where 1 marks water and 0 marks land.</param>
        /// <returns>A height grid with water cells at height zero.</returns>
        public int[][] HighestPeak(int[][] isWater)
        {
            int rows = isWater.Length;
            int cols = isWater[0].Length;
            var heights = new int[rows][];
            var queue = new Queue<(int Row, int Col)>();
            for (int r = 0; r < rows; r++)
            {
                heights[r] = Enumerable.Repeat(-1, cols).ToArray();
                for (int c = 0; c < cols; c++)
                {
                    if (isWater[r][c] == 1)
                    {
                        heights[r][c] = 0;
                        queue.Enqueue((r, c));
                    }
                }
            }

            int[] directions = { 1, 0, -1, 0, 1 };
            while (queue.Count > 0)
            {
                var (row, col) = queue.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int nextRow = row + directions[i];
                    int nextCol = col + directions[i + 1];
                    if (nextRow >= 0 && nextRow < rows && nextCol >= 0 && nextCol < cols && heights[nextRow][nextCol] == -1)
                    {
                        heights[nextRow][nextCol] = heights[row][col] + 1;
                        queue.Enqueue((nextRow, nextCol));
                    }
                }
            }

            return heights;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-center-of-star-graph/">1791. Find Center of Star Graph (easy)</a>
        /// Identifies the shared endpoint that appears in every edge of a valid star graph.
        /// </summary>
        /// <param name="edges">Undirected star graph edges.</param>
        /// <returns>The center node label.</returns>
        public int FindCenter(int[][] edges)
        {
            return edges[0][0] == edges[1][0] || edges[0][0] == edges[1][1] ? edges[0][0] : edges[0][1];
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-sub-islands/">1905. Count Sub Islands (medium)</a>
        /// Counts islands in grid2 whose every land cell is also land in grid1.
        /// </summary>
        /// <param name="grid1">The reference land grid.</param>
        /// <param name="grid2">The candidate land grid to consume during search.</param>
        /// <returns>The number of sub-islands.</returns>
        public int CountSubIslands(int[][] grid1, int[][] grid2)
        {
            int rows = grid2.Length;
            int cols = grid2[0].Length;
            int count = 0;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (grid2[r][c] == 1 && FloodSubIsland(grid1, grid2, r, c))
                        count++;
                }
            }

            return count;
        }

        private static bool FloodSubIsland(int[][] grid1, int[][] grid2, int row, int col)
        {
            bool isSubIsland = true;
            var queue = new Queue<(int Row, int Col)>();
            queue.Enqueue((row, col));
            grid2[row][col] = 0;
            int[] directions = { 1, 0, -1, 0, 1 };
            while (queue.Count > 0)
            {
                var (r, c) = queue.Dequeue();
                if (grid1[r][c] == 0)
                    isSubIsland = false;
                for (int i = 0; i < 4; i++)
                {
                    int nextRow = r + directions[i];
                    int nextCol = c + directions[i + 1];
                    if (nextRow >= 0 && nextRow < grid2.Length && nextCol >= 0 && nextCol < grid2[0].Length && grid2[nextRow][nextCol] == 1)
                    {
                        grid2[nextRow][nextCol] = 0;
                        queue.Enqueue((nextRow, nextCol));
                    }
                }
            }

            return isSubIsland;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/nearest-exit-from-entrance-in-maze/">1926. Nearest Exit from Entrance in Maze (medium)</a>
        /// Finds the shortest path from the entrance to any boundary empty cell other than the entrance.
        /// </summary>
        /// <param name="maze">Maze cells where '.' is open and '+' is blocked.</param>
        /// <param name="entrance">Entrance coordinate [row, column].</param>
        /// <returns>The minimum number of steps to an exit, or -1 when none exists.</returns>
        public int NearestExit(char[][] maze, int[] entrance)
        {
            int rows = maze.Length;
            int cols = maze[0].Length;
            var queue = new Queue<(int Row, int Col, int Distance)>();
            queue.Enqueue((entrance[0], entrance[1], 0));
            maze[entrance[0]][entrance[1]] = '+';
            int[] directions = { 1, 0, -1, 0, 1 };
            while (queue.Count > 0)
            {
                var (row, col, distance) = queue.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int nextRow = row + directions[i];
                    int nextCol = col + directions[i + 1];
                    if (nextRow < 0 || nextRow >= rows || nextCol < 0 || nextCol >= cols || maze[nextRow][nextCol] != '.')
                        continue;
                    if (nextRow == 0 || nextRow == rows - 1 || nextCol == 0 || nextCol == cols - 1)
                        return distance + 1;
                    maze[nextRow][nextCol] = '+';
                    queue.Enqueue((nextRow, nextCol, distance + 1));
                }
            }

            return -1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-if-path-exists-in-graph/">1971. Find if Path Exists in Graph (easy)</a>
        /// Determines whether two vertices are connected in an undirected graph.
        /// </summary>
        /// <param name="n">The number of vertices labeled from 0 to n - 1.</param>
        /// <param name="edges">Undirected graph edges.</param>
        /// <param name="source">The start vertex.</param>
        /// <param name="destination">The target vertex.</param>
        /// <returns><see langword="true"/> when a path exists; otherwise, <see langword="false"/>.</returns>
        public bool ValidPath(int n, int[][] edges, int source, int destination)
        {
            var unionFind = new DisjointSet(n);
            foreach (var edge in edges)
                unionFind.Union(edge[0], edge[1]);
            return unionFind.Find(source) == unionFind.Find(destination);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-all-groups-of-farmland/">1992. Find All Groups of Farmland (medium)</a>
        /// Finds rectangular groups of farmland and returns their top-left and bottom-right corners.
        /// </summary>
        /// <param name="land">Grid where 1 is farmland and 0 is forest.</param>
        /// <returns>Each farmland rectangle as [topRow, leftCol, bottomRow, rightCol].</returns>
        public int[][] FindFarmland(int[][] land)
        {
            int rows = land.Length;
            int cols = land[0].Length;
            var groups = new List<int[]>();
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (land[r][c] == 0)
                        continue;
                    int bottom = r;
                    int right = c;
                    while (bottom + 1 < rows && land[bottom + 1][c] == 1)
                        bottom++;
                    while (right + 1 < cols && land[r][right + 1] == 1)
                        right++;
                    for (int i = r; i <= bottom; i++)
                        for (int j = c; j <= right; j++)
                            land[i][j] = 0;
                    groups.Add(new[] { r, c, bottom, right });
                }
            }

            return groups.ToArray();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/the-time-when-the-network-becomes-idle/">2039. The Time When the Network Becomes Idle (medium)</a>
        /// Computes when all repeatedly sent data-server messages have received replies.
        /// </summary>
        /// <param name="edges">Undirected network edges.</param>
        /// <param name="patience">Resend intervals for each node.</param>
        /// <returns>The first second when the network is idle.</returns>
        public int NetworkBecomesIdle(int[][] edges, int[] patience)
        {
            int n = patience.Length;
            var graph = new List<int>[n];
            for (int i = 0; i < n; i++)
                graph[i] = new List<int>();
            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            var distances = Enumerable.Repeat(-1, n).ToArray();
            distances[0] = 0;
            var queue = new Queue<int>();
            queue.Enqueue(0);
            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                foreach (int next in graph[node])
                {
                    if (distances[next] != -1)
                        continue;
                    distances[next] = distances[node] + 1;
                    queue.Enqueue(next);
                }
            }

            int idle = 0;
            for (int node = 1; node < n; node++)
            {
                int roundTrip = distances[node] * 2;
                int lastSent = (roundTrip - 1) / patience[node] * patience[node];
                idle = Math.Max(idle, lastSent + roundTrip + 1);
            }

            return idle;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/process-restricted-friend-requests/">2076. Process Restricted Friend Requests (hard)</a>
        /// Processes friendship requests while preserving every pairwise restriction between connected components.
        /// </summary>
        /// <param name="n">People labeled from 0 to n - 1.</param>
        /// <param name="restrictions">Pairs that may not become connected.</param>
        /// <param name="requests">Friendship requests to accept or reject in order.</param>
        /// <returns>Acceptance result for each request.</returns>
        public bool[] FriendRequests(int n, int[][] restrictions, int[][] requests)
        {
            var unionFind = new DisjointSet(n);
            var result = new bool[requests.Length];
            for (int i = 0; i < requests.Length; i++)
            {
                int firstRoot = unionFind.Find(requests[i][0]);
                int secondRoot = unionFind.Find(requests[i][1]);
                bool blocked = false;
                foreach (var restriction in restrictions)
                {
                    int restrictedA = unionFind.Find(restriction[0]);
                    int restrictedB = unionFind.Find(restriction[1]);
                    if ((firstRoot == restrictedA && secondRoot == restrictedB) || (firstRoot == restrictedB && secondRoot == restrictedA))
                    {
                        blocked = true;
                        break;
                    }
                }

                if (!blocked)
                {
                    unionFind.Union(firstRoot, secondRoot);
                    result[i] = true;
                }
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-all-people-with-secret/">2092. Find All People With Secret (hard)</a>
        /// Spreads a secret through same-time meeting components that contain someone who already knows it.
        /// </summary>
        /// <param name="n">People labeled from 0 to n - 1.</param>
        /// <param name="meetings">Meetings [personA, personB, time].</param>
        /// <param name="firstPerson">The person initially told by person 0 at time 0.</param>
        /// <returns>All people who know the secret after every meeting.</returns>
        public IList<int> FindAllPeople(int n, int[][] meetings, int firstPerson)
        {
            Array.Sort(meetings, (left, right) => left[2].CompareTo(right[2]));
            var knows = new bool[n];
            knows[0] = true;
            knows[firstPerson] = true;
            int index = 0;
            while (index < meetings.Length)
            {
                int time = meetings[index][2];
                var graph = new Dictionary<int, List<int>>();
                while (index < meetings.Length && meetings[index][2] == time)
                {
                    int a = meetings[index][0];
                    int b = meetings[index][1];
                    if (!graph.ContainsKey(a))
                        graph[a] = new List<int>();
                    if (!graph.ContainsKey(b))
                        graph[b] = new List<int>();
                    graph[a].Add(b);
                    graph[b].Add(a);
                    index++;
                }

                var queue = new Queue<int>();
                var visited = new HashSet<int>();
                foreach (int person in graph.Keys)
                {
                    if (knows[person])
                    {
                        queue.Enqueue(person);
                        visited.Add(person);
                    }
                }

                while (queue.Count > 0)
                {
                    int person = queue.Dequeue();
                    knows[person] = true;
                    foreach (int next in graph[person])
                    {
                        if (visited.Add(next))
                            queue.Enqueue(next);
                    }
                }
            }

            var result = new List<int>();
            for (int person = 0; person < n; person++)
                if (knows[person])
                    result.Add(person);
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/detonate-the-maximum-bombs/">2101. Detonate the Maximum Bombs (medium)</a>
        /// Builds a directed reachability graph and finds the largest chain reaction from one starting bomb.
        /// </summary>
        /// <param name="bombs">Bombs as [x, y, radius].</param>
        /// <returns>The maximum number of bombs that can be detonated.</returns>
        public int MaximumDetonation(int[][] bombs)
        {
            int n = bombs.Length;
            var graph = new List<int>[n];
            for (int i = 0; i < n; i++)
                graph[i] = new List<int>();
            for (int i = 0; i < n; i++)
            {
                long radius = bombs[i][2];
                long reach = radius * radius;
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                        continue;
                    long dx = bombs[i][0] - bombs[j][0];
                    long dy = bombs[i][1] - bombs[j][1];
                    if (dx * dx + dy * dy <= reach)
                        graph[i].Add(j);
                }
            }

            int best = 0;
            for (int start = 0; start < n; start++)
            {
                var visited = new bool[n];
                var stack = new Stack<int>();
                stack.Push(start);
                visited[start] = true;
                int count = 0;
                while (stack.Count > 0)
                {
                    int bomb = stack.Pop();
                    count++;
                    foreach (int next in graph[bomb])
                    {
                        if (!visited[next])
                        {
                            visited[next] = true;
                            stack.Push(next);
                        }
                    }
                }

                best = Math.Max(best, count);
            }

            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/k-highest-ranked-items-within-a-price-range/">2146. K Highest Ranked Items Within a Price Range (medium)</a>
        /// Breadth-first searches reachable shop cells and ranks in-range items by distance, price, row, then column.
        /// </summary>
        /// <param name="grid">Shop grid where 0 blocks movement and positive values are prices.</param>
        /// <param name="pricing">Inclusive [low, high] acceptable price range.</param>
        /// <param name="start">Starting coordinate [row, column].</param>
        /// <param name="k">Maximum number of ranked items to return.</param>
        /// <returns>Coordinates of up to k highest-ranked items.</returns>
        public IList<IList<int>> HighestRankedKItems(int[][] grid, int[] pricing, int[] start, int k)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            var visited = new bool[rows, cols];
            var queue = new Queue<(int Row, int Col, int Distance)>();
            var items = new List<(int Distance, int Price, int Row, int Col)>();
            queue.Enqueue((start[0], start[1], 0));
            visited[start[0], start[1]] = true;
            int[] directions = { 1, 0, -1, 0, 1 };
            while (queue.Count > 0)
            {
                var (row, col, distance) = queue.Dequeue();
                int price = grid[row][col];
                if (price >= pricing[0] && price <= pricing[1])
                    items.Add((distance, price, row, col));
                for (int i = 0; i < 4; i++)
                {
                    int nextRow = row + directions[i];
                    int nextCol = col + directions[i + 1];
                    if (nextRow >= 0 && nextRow < rows && nextCol >= 0 && nextCol < cols && !visited[nextRow, nextCol] && grid[nextRow][nextCol] != 0)
                    {
                        visited[nextRow, nextCol] = true;
                        queue.Enqueue((nextRow, nextCol, distance + 1));
                    }
                }
            }

            return items.OrderBy(item => item.Distance)
                .ThenBy(item => item.Price)
                .ThenBy(item => item.Row)
                .ThenBy(item => item.Col)
                .Take(k)
                .Select(item => (IList<int>)new List<int> { item.Row, item.Col })
                .ToList();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/all-ancestors-of-a-node-in-a-directed-acyclic-graph/">2192. All Ancestors of a Node in a Directed Acyclic Graph (medium)</a>
        /// Propagates sorted ancestor sets through a topological traversal of a DAG.
        /// </summary>
        /// <param name="n">The number of nodes labeled from 0 to n - 1.</param>
        /// <param name="edges">Directed edges [from, to].</param>
        /// <returns>For each node, its ancestors in ascending order.</returns>
        public IList<IList<int>> GetAncestors(int n, int[][] edges)
        {
            var graph = new List<int>[n];
            var indegree = new int[n];
            var ancestors = new SortedSet<int>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
                ancestors[i] = new SortedSet<int>();
            }

            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                indegree[edge[1]]++;
            }

            var queue = new Queue<int>();
            for (int node = 0; node < n; node++)
                if (indegree[node] == 0)
                    queue.Enqueue(node);
            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                foreach (int next in graph[node])
                {
                    ancestors[next].Add(node);
                    ancestors[next].UnionWith(ancestors[node]);
                    if (--indegree[next] == 0)
                        queue.Enqueue(next);
                }
            }

            return ancestors.Select(set => (IList<int>)set.ToList()).ToList();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-unreachable-pairs-of-nodes-in-an-undirected-graph/">2316. Count Unreachable Pairs of Nodes in an Undirected Graph (medium)</a>
        /// Counts unordered node pairs that lie in different connected components.
        /// </summary>
        /// <param name="n">The number of nodes labeled from 0 to n - 1.</param>
        /// <param name="edges">Undirected graph edges.</param>
        /// <returns>The number of unreachable pairs.</returns>
        public long CountPairs(int n, int[][] edges)
        {
            var graph = new List<int>[n];
            for (int i = 0; i < n; i++)
                graph[i] = new List<int>();
            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            var visited = new bool[n];
            long seen = 0;
            long pairs = 0;
            for (int node = 0; node < n; node++)
            {
                if (visited[node])
                    continue;
                long size = 0;
                var stack = new Stack<int>();
                stack.Push(node);
                visited[node] = true;
                while (stack.Count > 0)
                {
                    int current = stack.Pop();
                    size++;
                    foreach (int next in graph[current])
                    {
                        if (!visited[next])
                        {
                            visited[next] = true;
                            stack.Push(next);
                        }
                    }
                }

                pairs += seen * size;
                seen += size;
            }

            return pairs;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-closest-node-to-given-two-nodes/">2359. Find Closest Node to Given Two Nodes (medium)</a>
        /// Finds the node minimizing the larger distance from two starts in a directed graph with at most one outgoing edge per node.
        /// </summary>
        /// <param name="edges">Outgoing edge for each node, or -1 when absent.</param>
        /// <param name="node1">The first start node.</param>
        /// <param name="node2">The second start node.</param>
        /// <returns>The best meeting node, choosing the smallest index on ties, or -1.</returns>
        public int ClosestMeetingNode(int[] edges, int node1, int node2)
        {
            int[] first = DistancesAlongFunctionalGraph(edges, node1);
            int[] second = DistancesAlongFunctionalGraph(edges, node2);
            int bestNode = -1;
            int bestDistance = int.MaxValue;
            for (int node = 0; node < edges.Length; node++)
            {
                if (first[node] == -1 || second[node] == -1)
                    continue;
                int distance = Math.Max(first[node], second[node]);
                if (distance < bestDistance)
                {
                    bestDistance = distance;
                    bestNode = node;
                }
            }

            return bestNode;
        }

        private static int[] DistancesAlongFunctionalGraph(int[] edges, int start)
        {
            var distances = Enumerable.Repeat(-1, edges.Length).ToArray();
            int node = start;
            int distance = 0;
            while (node != -1 && distances[node] == -1)
            {
                distances[node] = distance++;
                node = edges[node];
            }

            return distances;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/longest-cycle-in-a-graph/">2360. Longest Cycle in a Graph (hard)</a>
        /// Finds the longest directed cycle in a graph where each node has at most one outgoing edge.
        /// </summary>
        /// <param name="edges">Outgoing edge for each node, or -1 when absent.</param>
        /// <returns>The length of the longest cycle, or -1 when acyclic.</returns>
        public int LongestCycle(int[] edges)
        {
            int n = edges.Length;
            var visitedAt = new int[n];
            Array.Fill(visitedAt, -1);
            int time = 0;
            int best = -1;
            for (int start = 0; start < n; start++)
            {
                if (visitedAt[start] != -1)
                    continue;
                var enteredAt = new Dictionary<int, int>();
                int node = start;
                while (node != -1 && visitedAt[node] == -1)
                {
                    enteredAt[node] = time;
                    visitedAt[node] = time++;
                    node = edges[node];
                }

                if (node != -1 && enteredAt.TryGetValue(node, out int cycleStart))
                    best = Math.Max(best, time - cycleStart);
            }

            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/build-a-matrix-with-conditions/">2392. Build a Matrix With Conditions (hard)</a>
        /// Topologically orders row and column constraints and places each value at the intersection of its two positions.
        /// </summary>
        /// <param name="k">Values from 1 to k to place in the matrix.</param>
        /// <param name="rowConditions">Ordering constraints [above, below].</param>
        /// <param name="colConditions">Ordering constraints [left, right].</param>
        /// <returns>A valid k by k matrix, or an empty matrix when constraints contain a cycle.</returns>
        public int[][] BuildMatrix(int k, int[][] rowConditions, int[][] colConditions)
        {
            int[] rowOrder = TopologicalOrderOneBased(k, rowConditions);
            int[] colOrder = TopologicalOrderOneBased(k, colConditions);
            if (rowOrder.Length == 0 || colOrder.Length == 0)
                return Array.Empty<int[]>();

            var rowPosition = new int[k + 1];
            var colPosition = new int[k + 1];
            for (int i = 0; i < k; i++)
            {
                rowPosition[rowOrder[i]] = i;
                colPosition[colOrder[i]] = i;
            }

            var matrix = new int[k][];
            for (int i = 0; i < k; i++)
                matrix[i] = new int[k];
            for (int value = 1; value <= k; value++)
                matrix[rowPosition[value]][colPosition[value]] = value;
            return matrix;
        }

        private static int[] TopologicalOrderOneBased(int k, int[][] conditions)
        {
            var graph = new List<int>[k + 1];
            var indegree = new int[k + 1];
            for (int i = 1; i <= k; i++)
                graph[i] = new List<int>();
            foreach (var condition in conditions)
            {
                graph[condition[0]].Add(condition[1]);
                indegree[condition[1]]++;
            }

            var queue = new Queue<int>();
            for (int value = 1; value <= k; value++)
                if (indegree[value] == 0)
                    queue.Enqueue(value);
            var order = new List<int>(k);
            while (queue.Count > 0)
            {
                int value = queue.Dequeue();
                order.Add(value);
                foreach (int next in graph[value])
                    if (--indegree[next] == 0)
                        queue.Enqueue(next);
            }

            return order.Count == k ? order.ToArray() : Array.Empty<int>();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-score-of-a-path-between-two-cities/">2492. Minimum Score of a Path Between Two Cities (medium)</a>
        /// Finds the smallest road distance inside the connected component containing city 1.
        /// </summary>
        /// <param name="n">Cities labeled from 1 to n.</param>
        /// <param name="roads">Undirected roads [cityA, cityB, distance].</param>
        /// <returns>The minimum score among all paths between city 1 and city n.</returns>
        public int MinScore(int n, int[][] roads)
        {
            var graph = new List<(int City, int Distance)>[n + 1];
            for (int i = 1; i <= n; i++)
                graph[i] = new List<(int, int)>();
            foreach (var road in roads)
            {
                graph[road[0]].Add((road[1], road[2]));
                graph[road[1]].Add((road[0], road[2]));
            }

            int answer = int.MaxValue;
            var visited = new bool[n + 1];
            var stack = new Stack<int>();
            stack.Push(1);
            visited[1] = true;
            while (stack.Count > 0)
            {
                int city = stack.Pop();
                foreach (var (next, distance) in graph[city])
                {
                    answer = Math.Min(answer, distance);
                    if (!visited[next])
                    {
                        visited[next] = true;
                        stack.Push(next);
                    }
                }
            }

            return answer;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-time-to-visit-a-cell-in-a-grid/">2577. Minimum Time to Visit a Cell In a Grid (hard)</a>
        /// Uses Dijkstra search with parity waiting to reach the bottom-right grid cell as early as possible.
        /// </summary>
        /// <param name="grid">Earliest entry time for each grid cell.</param>
        /// <returns>The minimum arrival time, or -1 when leaving the start is impossible.</returns>
        public int MinimumTime(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            if (rows == 1 && cols == 1)
                return 0;
            if ((rows == 1 || grid[1][0] > 1) && (cols == 1 || grid[0][1] > 1))
                return -1;

            var best = new int[rows, cols];
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    best[r, c] = int.MaxValue;
            var queue = new PriorityQueue<(int Row, int Col), int>();
            best[0, 0] = 0;
            queue.Enqueue((0, 0), 0);
            int[] directions = { 1, 0, -1, 0, 1 };
            while (queue.Count > 0)
            {
                var (row, col) = queue.Dequeue();
                int time = best[row, col];
                if (row == rows - 1 && col == cols - 1)
                    return time;
                for (int i = 0; i < 4; i++)
                {
                    int nextRow = row + directions[i];
                    int nextCol = col + directions[i + 1];
                    if (nextRow < 0 || nextRow >= rows || nextCol < 0 || nextCol >= cols)
                        continue;
                    int nextTime = time + 1;
                    if (nextTime < grid[nextRow][nextCol])
                        nextTime = grid[nextRow][nextCol] + (grid[nextRow][nextCol] - nextTime) % 2;
                    if (nextTime < best[nextRow, nextCol])
                    {
                        best[nextRow, nextCol] = nextTime;
                        queue.Enqueue((nextRow, nextCol), nextTime);
                    }
                }
            }

            return -1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/shortest-cycle-in-a-graph/">2608. Shortest Cycle in a Graph (hard)</a>
        /// Runs BFS from each node to find the minimum-length cycle in an undirected graph.
        /// </summary>
        /// <param name="n">The number of nodes labeled from 0 to n - 1.</param>
        /// <param name="edges">Undirected graph edges.</param>
        /// <returns>The shortest cycle length, or -1 when no cycle exists.</returns>
        public int FindShortestCycle(int n, int[][] edges)
        {
            var graph = new List<int>[n];
            for (int i = 0; i < n; i++)
                graph[i] = new List<int>();
            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            int best = int.MaxValue;
            for (int start = 0; start < n; start++)
            {
                var distance = Enumerable.Repeat(-1, n).ToArray();
                var parent = Enumerable.Repeat(-1, n).ToArray();
                var queue = new Queue<int>();
                queue.Enqueue(start);
                distance[start] = 0;
                while (queue.Count > 0)
                {
                    int node = queue.Dequeue();
                    foreach (int next in graph[node])
                    {
                        if (distance[next] == -1)
                        {
                            distance[next] = distance[node] + 1;
                            parent[next] = node;
                            queue.Enqueue(next);
                        }
                        else if (parent[node] != next && parent[next] != node)
                        {
                            best = Math.Min(best, distance[node] + distance[next] + 1);
                        }
                    }
                }
            }

            return best == int.MaxValue ? -1 : best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-the-number-of-complete-components/">2685. Count the Number of Complete Components (medium)</a>
        /// Counts connected components whose every pair of nodes has an edge.
        /// </summary>
        /// <param name="n">The number of nodes labeled from 0 to n - 1.</param>
        /// <param name="edges">Undirected graph edges.</param>
        /// <returns>The number of complete connected components.</returns>
        public int CountCompleteComponents(int n, int[][] edges)
        {
            var graph = new List<int>[n];
            for (int i = 0; i < n; i++)
                graph[i] = new List<int>();
            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            var visited = new bool[n];
            int complete = 0;
            for (int node = 0; node < n; node++)
            {
                if (visited[node])
                    continue;
                int nodes = 0;
                int degreeSum = 0;
                var stack = new Stack<int>();
                stack.Push(node);
                visited[node] = true;
                while (stack.Count > 0)
                {
                    int current = stack.Pop();
                    nodes++;
                    degreeSum += graph[current].Count;
                    foreach (int next in graph[current])
                    {
                        if (!visited[next])
                        {
                            visited[next] = true;
                            stack.Push(next);
                        }
                    }
                }

                if (degreeSum == nodes * (nodes - 1))
                    complete++;
            }

            return complete;
        }


        /// <summary>
        /// <a href="https://leetcode.com/problems/greatest-common-divisor-traversal/">2709. Greatest Common Divisor Traversal (hard)</a>
        /// Connects numbers that share a prime factor and checks whether every pair is reachable through such connections.
        /// </summary>
        /// <param name="nums">Positive integers to connect by common factors greater than one.</param>
        /// <returns><see langword="true"/> when all indexes belong to one factor-connected component; otherwise, <see langword="false"/>.</returns>
        public bool CanTraverseAllPairs(int[] nums)
        {
            if (nums.Length == 1)
                return true;
            if (nums.Any(num => num == 1))
                return false;

            var unionFind = new DisjointSet(nums.Length);
            var ownerByPrime = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int value = nums[i];
                for (int factor = 2; factor * factor <= value; factor++)
                {
                    if (value % factor != 0)
                        continue;
                    UnionPrimeOwner(ownerByPrime, unionFind, factor, i);
                    while (value % factor == 0)
                        value /= factor;
                }

                if (value > 1)
                    UnionPrimeOwner(ownerByPrime, unionFind, value, i);
            }

            int root = unionFind.Find(0);
            for (int i = 1; i < nums.Length; i++)
                if (unionFind.Find(i) != root)
                    return false;
            return true;
        }

        private static void UnionPrimeOwner(Dictionary<int, int> ownerByPrime, DisjointSet unionFind, int prime, int index)
        {
            if (ownerByPrime.TryGetValue(prime, out int owner))
                unionFind.Union(owner, index);
            else
                ownerByPrime[prime] = index;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-the-safest-path-in-a-grid/">2812. Find the Safest Path in a Grid (medium)</a>
        /// Maximizes the minimum Manhattan distance to any thief along a path from the top-left to bottom-right cell.
        /// </summary>
        /// <param name="grid">Square grid where 1 marks a thief and 0 marks an empty cell.</param>
        /// <returns>The largest possible path safeness factor.</returns>
        public int MaximumSafenessFactor(IList<IList<int>> grid)
        {
            int n = grid.Count;
            var distance = new int[n, n];
            for (int r = 0; r < n; r++)
                for (int c = 0; c < n; c++)
                    distance[r, c] = -1;

            var queue = new Queue<(int Row, int Col)>();
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    if (grid[r][c] == 1)
                    {
                        distance[r, c] = 0;
                        queue.Enqueue((r, c));
                    }
                }
            }

            int[] directions = { 1, 0, -1, 0, 1 };
            while (queue.Count > 0)
            {
                var (row, col) = queue.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int nextRow = row + directions[i];
                    int nextCol = col + directions[i + 1];
                    if (nextRow >= 0 && nextRow < n && nextCol >= 0 && nextCol < n && distance[nextRow, nextCol] == -1)
                    {
                        distance[nextRow, nextCol] = distance[row, col] + 1;
                        queue.Enqueue((nextRow, nextCol));
                    }
                }
            }

            var best = new int[n, n];
            var heap = new PriorityQueue<(int Row, int Col, int Safe), int>();
            best[0, 0] = distance[0, 0];
            heap.Enqueue((0, 0, best[0, 0]), -best[0, 0]);
            while (heap.Count > 0)
            {
                var (row, col, safe) = heap.Dequeue();
                if (safe < best[row, col])
                    continue;
                if (row == n - 1 && col == n - 1)
                    return safe;
                for (int i = 0; i < 4; i++)
                {
                    int nextRow = row + directions[i];
                    int nextCol = col + directions[i + 1];
                    if (nextRow < 0 || nextRow >= n || nextCol < 0 || nextCol >= n)
                        continue;
                    int candidate = Math.Min(safe, distance[nextRow, nextCol]);
                    if (candidate > best[nextRow, nextCol])
                    {
                        best[nextRow, nextCol] = candidate;
                        heap.Enqueue((nextRow, nextCol, candidate), -candidate);
                    }
                }
            }

            return 0;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-edge-reversals-so-every-node-is-reachable/">2858. Minimum Edge Reversals So Every Node Is Reachable (hard)</a>
        /// Reroots a directed tree to count the minimum reversals needed so each node can reach every other node.
        /// </summary>
        /// <param name="n">The number of nodes labeled from 0 to n - 1.</param>
        /// <param name="edges">Directed tree edges.</param>
        /// <returns>For each root, the minimum number of edge reversals required.</returns>
        public int[] MinEdgeReversals(int n, int[][] edges)
        {
            var graph = new List<(int Node, int Cost)>[n];
            for (int i = 0; i < n; i++)
                graph[i] = new List<(int, int)>();
            foreach (var edge in edges)
            {
                graph[edge[0]].Add((edge[1], 0));
                graph[edge[1]].Add((edge[0], 1));
            }

            int initial = CountReverseCosts(graph, 0, -1);
            var result = new int[n];
            result[0] = initial;
            RerootReverseCosts(graph, 0, -1, result);
            return result;
        }

        private static int CountReverseCosts(List<(int Node, int Cost)>[] graph, int node, int parent)
        {
            int total = 0;
            foreach (var (next, cost) in graph[node])
                if (next != parent)
                    total += cost + CountReverseCosts(graph, next, node);
            return total;
        }

        private static void RerootReverseCosts(List<(int Node, int Cost)>[] graph, int node, int parent, int[] result)
        {
            foreach (var (next, cost) in graph[node])
            {
                if (next == parent)
                    continue;
                result[next] = result[node] + (cost == 0 ? 1 : -1);
                RerootReverseCosts(graph, next, node, result);
            }
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-visited-nodes-in-a-directed-graph/">2876. Count Visited Nodes in a Directed Graph (hard)</a>
        /// Counts how many unique nodes are visited when repeatedly following each node's single outgoing edge.
        /// </summary>
        /// <param name="edges">The outgoing neighbor for every node.</param>
        /// <returns>The visited-node count for every starting node.</returns>
        public int[] CountVisitedNodes(IList<int> edges)
        {
            int n = edges.Count;
            var indegree = new int[n];
            var reverse = new List<int>[n];
            for (int i = 0; i < n; i++)
                reverse[i] = new List<int>();
            for (int node = 0; node < n; node++)
            {
                indegree[edges[node]]++;
                reverse[edges[node]].Add(node);
            }

            var queue = new Queue<int>();
            var removedOrder = new List<int>();
            for (int node = 0; node < n; node++)
                if (indegree[node] == 0)
                    queue.Enqueue(node);
            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                removedOrder.Add(node);
                int next = edges[node];
                if (--indegree[next] == 0)
                    queue.Enqueue(next);
            }

            var result = new int[n];
            for (int node = 0; node < n; node++)
            {
                if (indegree[node] <= 0 || result[node] != 0)
                    continue;
                var cycle = new List<int>();
                int current = node;
                do
                {
                    cycle.Add(current);
                    current = edges[current];
                } while (current != node);
                foreach (int member in cycle)
                    result[member] = cycle.Count;
            }

            for (int i = removedOrder.Count - 1; i >= 0; i--)
            {
                int node = removedOrder[i];
                result[node] = result[edges[node]] + 1;
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-champion-ii/">2924. Find Champion II (medium)</a>
        /// Finds the unique node with no incoming edge in a tournament-like directed acyclic graph.
        /// </summary>
        /// <param name="n">The number of teams labeled from 0 to n - 1.</param>
        /// <param name="edges">Directed dominance edges [stronger, weaker].</param>
        /// <returns>The champion label, or -1 when it is not unique.</returns>
        public int FindChampion(int n, int[][] edges)
        {
            var indegree = new int[n];
            foreach (var edge in edges)
                indegree[edge[1]]++;
            int champion = -1;
            for (int node = 0; node < n; node++)
            {
                if (indegree[node] != 0)
                    continue;
                if (champion != -1)
                    return -1;
                champion = node;
            }

            return champion;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-number-of-operations-to-make-x-and-y-equal/">2998. Minimum Number of Operations to Make X and Y Equal (medium)</a>
        /// Searches states created by +/-1 and exact division by 5 or 11 operations to transform x into y.
        /// </summary>
        /// <param name="x">The starting value.</param>
        /// <param name="y">The target value.</param>
        /// <returns>The minimum number of operations.</returns>
        public int MinimumOperationsToMakeEqual(int x, int y)
        {
            if (x <= y)
                return y - x;

            int limit = Math.Max(x, y) * 2 + 20;
            var visited = new bool[limit + 1];
            var queue = new Queue<(int Value, int Steps)>();
            queue.Enqueue((x, 0));
            visited[x] = true;
            while (queue.Count > 0)
            {
                var (value, steps) = queue.Dequeue();
                if (value == y)
                    return steps;
                TryEnqueueOperation(value - 1, steps + 1, limit, visited, queue);
                TryEnqueueOperation(value + 1, steps + 1, limit, visited, queue);
                if (value % 5 == 0)
                    TryEnqueueOperation(value / 5, steps + 1, limit, visited, queue);
                if (value % 11 == 0)
                    TryEnqueueOperation(value / 11, steps + 1, limit, visited, queue);
            }

            return x - y;
        }

        private static void TryEnqueueOperation(int value, int steps, int limit, bool[] visited, Queue<(int Value, int Steps)> queue)
        {
            if (value < 0 || value > limit || visited[value])
                return;
            visited[value] = true;
            queue.Enqueue((value, steps));
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-the-number-of-houses-at-a-certain-distance-i/">3015. Count the Number of Houses at a Certain Distance I (medium)</a>
        /// Counts ordered house pairs by shortest path distance in a line graph with one extra edge.
        /// </summary>
        /// <param name="n">The number of houses labeled from 1 to n.</param>
        /// <param name="x">One endpoint of the extra street.</param>
        /// <param name="y">The other endpoint of the extra street.</param>
        /// <returns>Counts for distances 1 through n.</returns>
        public int[] CountOfPairs(int n, int x, int y)
        {
            var graph = new List<int>[n];
            for (int i = 0; i < n; i++)
                graph[i] = new List<int>();
            for (int i = 0; i < n - 1; i++)
            {
                graph[i].Add(i + 1);
                graph[i + 1].Add(i);
            }

            x--;
            y--;
            if (x != y)
            {
                graph[x].Add(y);
                graph[y].Add(x);
            }

            var result = new int[n];
            for (int start = 0; start < n; start++)
            {
                var distances = Enumerable.Repeat(-1, n).ToArray();
                var queue = new Queue<int>();
                distances[start] = 0;
                queue.Enqueue(start);
                while (queue.Count > 0)
                {
                    int node = queue.Dequeue();
                    foreach (int next in graph[node])
                    {
                        if (distances[next] != -1)
                            continue;
                        distances[next] = distances[node] + 1;
                        queue.Enqueue(next);
                    }
                }

                for (int end = 0; end < n; end++)
                    if (distances[end] > 0)
                        result[distances[end] - 1]++;
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-cost-walk-in-weighted-graph/">3108. Minimum Cost Walk in Weighted Graph (hard)</a>
        /// Uses union-find and component-wide bitwise AND values to answer minimum walk-cost queries.
        /// </summary>
        /// <param name="n">The number of nodes labeled from 0 to n - 1.</param>
        /// <param name="edges">Undirected weighted edges [u, v, weight].</param>
        /// <param name="query">Queries [source, target].</param>
        /// <returns>Minimum walk costs, 0 for identical endpoints, or -1 when disconnected.</returns>
        public int[] MinimumCost(int n, int[][] edges, int[][] query)
        {
            var unionFind = new DisjointSet(n);
            foreach (var edge in edges)
                unionFind.Union(edge[0], edge[1]);

            var componentCost = Enumerable.Repeat(-1, n).ToArray();
            foreach (var edge in edges)
            {
                int root = unionFind.Find(edge[0]);
                componentCost[root] &= edge[2];
            }

            var result = new int[query.Length];
            for (int i = 0; i < query.Length; i++)
            {
                int source = query[i][0];
                int target = query[i][1];
                if (source == target)
                    result[i] = 0;
                else if (unionFind.Find(source) != unionFind.Find(target))
                    result[i] = -1;
                else
                    result[i] = componentCost[unionFind.Find(source)];
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-time-to-visit-disappearing-nodes/">3112. Minimum Time to Visit Disappearing Nodes (medium)</a>
        /// Runs Dijkstra's algorithm while rejecting arrivals at or after a node's disappearance time.
        /// </summary>
        /// <param name="n">The number of nodes labeled from 0 to n - 1.</param>
        /// <param name="edges">Undirected weighted edges [u, v, length].</param>
        /// <param name="disappear">The time each node disappears.</param>
        /// <returns>Earliest arrival times from node 0, or -1 for unreachable nodes.</returns>
        public int[] MinimumTime(int n, int[][] edges, int[] disappear)
        {
            var graph = new List<(int Node, int Weight)>[n];
            for (int i = 0; i < n; i++)
                graph[i] = new List<(int, int)>();
            foreach (var edge in edges)
            {
                graph[edge[0]].Add((edge[1], edge[2]));
                graph[edge[1]].Add((edge[0], edge[2]));
            }

            var distances = Enumerable.Repeat(int.MaxValue, n).ToArray();
            var heap = new PriorityQueue<int, int>();
            distances[0] = 0;
            heap.Enqueue(0, 0);
            while (heap.Count > 0)
            {
                int node = heap.Dequeue();
                int time = distances[node];
                foreach (var (next, weight) in graph[node])
                {
                    int candidate = time + weight;
                    if (candidate < distances[next] && candidate < disappear[next])
                    {
                        distances[next] = candidate;
                        heap.Enqueue(next, candidate);
                    }
                }
            }

            for (int i = 0; i < n; i++)
                if (distances[i] == int.MaxValue)
                    distances[i] = -1;
            return distances;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/shortest-distance-after-road-addition-queries-i/">3243. Shortest Distance After Road Addition Queries I (medium)</a>
        /// Adds directed shortcut roads one by one and recomputes the shortest path from city 0 to city n - 1.
        /// </summary>
        /// <param name="n">The number of cities labeled from 0 to n - 1.</param>
        /// <param name="queries">Directed roads [from, to] to add in order.</param>
        /// <returns>The shortest distance after each added road.</returns>
        public int[] ShortestDistanceAfterQueries(int n, int[][] queries)
        {
            var graph = new List<int>[n];
            for (int i = 0; i < n; i++)
                graph[i] = new List<int>();
            for (int i = 0; i < n - 1; i++)
                graph[i].Add(i + 1);

            var result = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                graph[queries[i][0]].Add(queries[i][1]);
                result[i] = ShortestDistanceInDirectedUnweightedGraph(graph);
            }

            return result;
        }

        private static int ShortestDistanceInDirectedUnweightedGraph(List<int>[] graph)
        {
            var distances = Enumerable.Repeat(-1, graph.Length).ToArray();
            var queue = new Queue<int>();
            distances[0] = 0;
            queue.Enqueue(0);
            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                if (node == graph.Length - 1)
                    return distances[node];
                foreach (int next in graph[node])
                {
                    if (distances[next] != -1)
                        continue;
                    distances[next] = distances[node] + 1;
                    queue.Enqueue(next);
                }
            }

            return -1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-a-safe-walk-through-a-grid/">3286. Find a Safe Walk Through a Grid (medium)</a>
        /// Finds whether a path can keep health positive after paying the cost of every visited cell.
        /// </summary>
        /// <param name="grid">Grid of cell health costs.</param>
        /// <param name="health">Initial health.</param>
        /// <returns><see langword="true"/> when some top-left to bottom-right path leaves positive health; otherwise, <see langword="false"/>.</returns>
        public bool FindSafeWalk(IList<IList<int>> grid, int health)
        {
            int rows = grid.Count;
            int cols = grid[0].Count;
            var cost = new int[rows, cols];
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    cost[r, c] = int.MaxValue;

            var heap = new PriorityQueue<(int Row, int Col), int>();
            cost[0, 0] = grid[0][0];
            heap.Enqueue((0, 0), cost[0, 0]);
            int[] directions = { 1, 0, -1, 0, 1 };
            while (heap.Count > 0)
            {
                var (row, col) = heap.Dequeue();
                if (row == rows - 1 && col == cols - 1)
                    return cost[row, col] < health;
                for (int i = 0; i < 4; i++)
                {
                    int nextRow = row + directions[i];
                    int nextCol = col + directions[i + 1];
                    if (nextRow < 0 || nextRow >= rows || nextCol < 0 || nextCol >= cols)
                        continue;
                    int candidate = cost[row, col] + grid[nextRow][nextCol];
                    if (candidate < cost[nextRow, nextCol] && candidate < health)
                    {
                        cost[nextRow, nextCol] = candidate;
                        heap.Enqueue((nextRow, nextCol), candidate);
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/remove-methods-from-project/">3310. Remove Methods From Project (medium)</a>
        /// Removes all methods reachable from a buggy method unless a remaining method invokes one of them.
        /// </summary>
        /// <param name="n">The number of methods labeled from 0 to n - 1.</param>
        /// <param name="k">The initially suspicious method.</param>
        /// <param name="invocations">Directed invocation edges [caller, callee].</param>
        /// <returns>The methods left after valid removal, or all methods when removal is invalid.</returns>
        public IList<int> RemainingMethods(int n, int k, int[][] invocations)
        {
            var graph = new List<int>[n];
            for (int i = 0; i < n; i++)
                graph[i] = new List<int>();
            foreach (var invocation in invocations)
                graph[invocation[0]].Add(invocation[1]);

            var suspicious = new bool[n];
            var stack = new Stack<int>();
            stack.Push(k);
            suspicious[k] = true;
            while (stack.Count > 0)
            {
                int method = stack.Pop();
                foreach (int next in graph[method])
                {
                    if (!suspicious[next])
                    {
                        suspicious[next] = true;
                        stack.Push(next);
                    }
                }
            }

            foreach (var invocation in invocations)
                if (!suspicious[invocation[0]] && suspicious[invocation[1]])
                    return Enumerable.Range(0, n).ToList();

            var result = new List<int>();
            for (int method = 0; method < n; method++)
                if (!suspicious[method])
                    result.Add(method);
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-minimum-time-to-reach-last-room-i/">3341. Find Minimum Time to Reach Last Room I (medium)</a>
        /// Uses Dijkstra's algorithm where entering a room may require waiting until its earliest move time.
        /// </summary>
        /// <param name="moveTime">Earliest time each room can be entered.</param>
        /// <returns>The minimum time to reach the bottom-right room.</returns>
        public int MinTimeToReach(int[][] moveTime)
        {
            return MinTimeToReachWithStepCosts(moveTime, alternatingCosts: false);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-minimum-time-to-reach-last-room-ii/">3342. Find Minimum Time to Reach Last Room II (medium)</a>
        /// Uses Dijkstra's algorithm with alternating one- and two-second moves while respecting room entry times.
        /// </summary>
        /// <param name="moveTime">Earliest time each room can be entered.</param>
        /// <returns>The minimum time to reach the bottom-right room.</returns>
        public int MinTimeToReachII(int[][] moveTime)
        {
            return MinTimeToReachWithStepCosts(moveTime, alternatingCosts: true);
        }

        private static int MinTimeToReachWithStepCosts(int[][] moveTime, bool alternatingCosts)
        {
            int rows = moveTime.Length;
            int cols = moveTime[0].Length;
            var best = new int[rows, cols, 2];
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    for (int parity = 0; parity < 2; parity++)
                        best[r, c, parity] = int.MaxValue;

            var heap = new PriorityQueue<(int Row, int Col, int Parity), int>();
            best[0, 0, 0] = 0;
            heap.Enqueue((0, 0, 0), 0);
            int[] directions = { 1, 0, -1, 0, 1 };
            while (heap.Count > 0)
            {
                var (row, col, parity) = heap.Dequeue();
                int time = best[row, col, parity];
                if (row == rows - 1 && col == cols - 1)
                    return time;
                int moveCost = alternatingCosts ? parity + 1 : 1;
                int nextParity = alternatingCosts ? 1 - parity : 0;
                for (int i = 0; i < 4; i++)
                {
                    int nextRow = row + directions[i];
                    int nextCol = col + directions[i + 1];
                    if (nextRow < 0 || nextRow >= rows || nextCol < 0 || nextCol >= cols)
                        continue;
                    int candidate = Math.Max(time, moveTime[nextRow][nextCol]) + moveCost;
                    if (candidate < best[nextRow, nextCol, nextParity])
                    {
                        best[nextRow, nextCol, nextParity] = candidate;
                        heap.Enqueue((nextRow, nextCol, nextParity), candidate);
                    }
                }
            }

            return -1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimize-the-maximum-edge-weight-of-graph/">3419. Minimize the Maximum Edge Weight of Graph (medium)</a>
        /// Binary searches the smallest edge-weight cap that lets every node reach node 0.
        /// </summary>
        /// <param name="n">The number of nodes labeled from 0 to n - 1.</param>
        /// <param name="edges">Directed weighted edges [from, to, weight].</param>
        /// <param name="threshold">The maximum allowed outgoing edge count per node; feasibility only needs one kept outgoing edge per nonzero node.</param>
        /// <returns>The minimized maximum kept edge weight, or -1 when impossible.</returns>
        public int MinMaxWeight(int n, int[][] edges, int threshold)
        {
            int low = 1;
            int high = 0;
            foreach (var edge in edges)
                high = Math.Max(high, edge[2]);
            int answer = -1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (CanReachZeroWithMaxWeight(n, edges, mid))
                {
                    answer = mid;
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return answer;
        }

        private static bool CanReachZeroWithMaxWeight(int n, int[][] edges, int maxWeight)
        {
            var reverse = new List<int>[n];
            for (int i = 0; i < n; i++)
                reverse[i] = new List<int>();
            foreach (var edge in edges)
                if (edge[2] <= maxWeight)
                    reverse[edge[1]].Add(edge[0]);

            var visited = new bool[n];
            var stack = new Stack<int>();
            stack.Push(0);
            visited[0] = true;
            int count = 0;
            while (stack.Count > 0)
            {
                int node = stack.Pop();
                count++;
                foreach (int next in reverse[node])
                {
                    if (!visited[next])
                    {
                        visited[next] = true;
                        stack.Push(next);
                    }
                }
            }

            return count == n;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/properties-graph/">3493. Properties Graph (medium)</a>
        /// Connects rows sharing at least k distinct property values and counts connected components.
        /// </summary>
        /// <param name="properties">Property values for each node.</param>
        /// <param name="k">The minimum number of shared distinct values required for an edge.</param>
        /// <returns>The number of connected components in the derived graph.</returns>
        public int NumberOfComponents(int[][] properties, int k)
        {
            int n = properties.Length;
            var sets = properties.Select(row => new HashSet<int>(row)).ToArray();
            var unionFind = new DisjointSet(n);
            int components = n;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (CountIntersectionAtLeast(sets[i], sets[j], k) && unionFind.Union(i, j))
                        components--;
                }
            }

            return components;
        }

        private static bool CountIntersectionAtLeast(HashSet<int> first, HashSet<int> second, int k)
        {
            if (first.Count > second.Count)
                return CountIntersectionAtLeast(second, first, k);
            int count = 0;
            foreach (int value in first)
                if (second.Contains(value) && ++count >= k)
                    return true;
            return false;
        }

        private sealed class DisjointSet
        {
            private readonly int[] parent;
            private readonly int[] rank;

            public DisjointSet(int size)
            {
                parent = new int[size];
                rank = new int[size];
                for (int i = 0; i < size; i++)
                    parent[i] = i;
            }

            public bool Union(int first, int second)
            {
                int firstRoot = Find(first);
                int secondRoot = Find(second);
                if (firstRoot == secondRoot)
                    return false;

                if (rank[firstRoot] < rank[secondRoot])
                {
                    parent[firstRoot] = secondRoot;
                }
                else if (rank[firstRoot] > rank[secondRoot])
                {
                    parent[secondRoot] = firstRoot;
                }
                else
                {
                    parent[secondRoot] = firstRoot;
                    rank[firstRoot]++;
                }

                return true;
            }

            public int Find(int node)
            {
                if (parent[node] != node)
                    parent[node] = Find(parent[node]);

                return parent[node];
            }
        }
        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-subgraph-score-in-a-tree/">3772. Maximum Subgraph Score in a Tree (hard)</a>
        /// Computes the best connected-subtree score containing each node.
        /// </summary>
        /// <param name="n">The number of tree nodes.</param>
        /// <param name="edges">Undirected tree edges.</param>
        /// <param name="good">Whether each node contributes positive score.</param>
        /// <returns>The maximum connected-subgraph score for every node.</returns>
        public int[] MaxSubgraphScore(int n, int[][] edges, int[] good)
        {
            var graph = BuildUndirectedGraph(n, edges);
            var parent = new int[n];
            var order = new List<int>(n) { 0 };
            Array.Fill(parent, -2);
            parent[0] = -1;
            for (int i = 0; i < order.Count; i++)
                foreach (int next in graph[order[i]])
                    if (next != parent[order[i]])
                    {
                        parent[next] = order[i];
                        order.Add(next);
                    }

            var down = new int[n];
            for (int i = n - 1; i >= 0; i--)
            {
                int node = order[i];
                down[node] = good[node] == 1 ? 1 : -1;
                foreach (int next in graph[node])
                    if (parent[next] == node)
                        down[node] += Math.Max(0, down[next]);
            }

            var answer = new int[n];
            answer[0] = down[0];
            for (int i = 0; i < n; i++)
            {
                int node = order[i];
                foreach (int next in graph[node])
                    if (parent[next] == node)
                        answer[next] = down[next] + Math.Max(0, answer[node] - Math.Max(0, down[next]));
            }

            return answer;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/total-sum-of-interaction-cost-in-tree-groups/">3786. Total Sum of Interaction Cost in Tree Groups (medium)</a>
        /// Sums pairwise tree distances for nodes sharing a group label.
        /// </summary>
        /// <param name="n">The number of tree nodes.</param>
        /// <param name="edges">Undirected tree edges.</param>
        /// <param name="group">The group label at each node.</param>
        /// <returns>The sum of distances across same-group unordered pairs.</returns>
        public long InteractionCosts(int n, int[][] edges, int[] group)
        {
            var graph = BuildUndirectedGraph(n, edges);
            var parent = new int[n];
            var order = new List<int>(n) { 0 };
            Array.Fill(parent, -2);
            parent[0] = -1;
            for (int i = 0; i < order.Count; i++)
                foreach (int next in graph[order[i]])
                    if (next != parent[order[i]])
                    {
                        parent[next] = order[i];
                        order.Add(next);
                    }

            var totals = new long[21];
            foreach (int value in group)
                totals[value]++;
            var subtreeCounts = new long[n, 21];
            long result = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                int node = order[i];
                subtreeCounts[node, group[node]]++;
                for (int label = 1; label <= 20; label++)
                {
                    long count = subtreeCounts[node, label];
                    result += count * (totals[label] - count);
                    if (parent[node] >= 0)
                        subtreeCounts[parent[node], label] += count;
                }
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-edge-toggles-on-a-tree/">3812. Minimum Edge Toggles on a Tree (medium)</a>
        /// Returns the uniquely determined minimum set of endpoint-toggle edges, or -1 when impossible.
        /// </summary>
        /// <param name="n">The number of tree nodes.</param>
        /// <param name="edges">Undirected tree edges in return-index order.</param>
        /// <param name="start">Initial node colors.</param>
        /// <param name="target">Required node colors.</param>
        /// <returns>Increasing edge indices to toggle, or [-1] when no transformation exists.</returns>
        public IList<int> MinimumFlips(int n, int[][] edges, string start, string target)
        {
            var graph = new List<(int Node, int Edge)>[n];
            for (int i = 0; i < n; i++)
                graph[i] = new List<(int, int)>();
            for (int i = 0; i < edges.Length; i++)
            {
                graph[edges[i][0]].Add((edges[i][1], i));
                graph[edges[i][1]].Add((edges[i][0], i));
            }

            var parent = new int[n];
            var parentEdge = new int[n];
            Array.Fill(parent, -2);
            parent[0] = -1;
            var order = new List<int>(n) { 0 };
            for (int i = 0; i < order.Count; i++)
                foreach (var (next, edge) in graph[order[i]])
                    if (next != parent[order[i]])
                    {
                        parent[next] = order[i];
                        parentEdge[next] = edge;
                        order.Add(next);
                    }

            var parity = new int[n];
            var result = new List<int>();
            for (int i = n - 1; i >= 0; i--)
            {
                int node = order[i];
                parity[node] ^= start[node] - target[node] & 1;
                if (node != 0 && parity[node] == 1)
                    result.Add(parentEdge[node]);
                if (parent[node] >= 0)
                    parity[parent[node]] ^= parity[node];
            }

            if (parity[0] != 0)
                return new List<int> { -1 };
            result.Sort();
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/pythagorean-distance-nodes-in-a-tree/">3820. Pythagorean Distance Nodes in a Tree (medium)</a>
        /// Counts nodes whose distances to three targets form a Pythagorean triplet.
        /// </summary>
        /// <param name="n">The number of tree nodes.</param>
        /// <param name="edges">Undirected tree edges.</param>
        /// <param name="x">The first target node.</param>
        /// <param name="y">The second target node.</param>
        /// <param name="z">The third target node.</param>
        /// <returns>The number of special nodes.</returns>
        public int SpecialNodes(int n, int[][] edges, int x, int y, int z)
        {
            var graph = BuildUndirectedGraph(n, edges);
            int[] dx = TreeDistances(graph, x);
            int[] dy = TreeDistances(graph, y);
            int[] dz = TreeDistances(graph, z);
            int result = 0;
            for (int node = 0; node < n; node++)
            {
                int a = dx[node], b = dy[node], c = dz[node];
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
        /// Processes label updates and determines whether each queried tree path can be rearranged into a palindrome.
        /// </summary>
        /// <param name="n">The number of tree nodes.</param>
        /// <param name="edges">Undirected tree edges.</param>
        /// <param name="s">Initial node labels.</param>
        /// <param name="queries">Update and path queries.</param>
        /// <returns>Results in the order query operations occur.</returns>
        public IList<bool> PalindromePath(int n, int[][] edges, string s, string[] queries)
        {
            var graph = BuildUndirectedGraph(n, edges);
            var parent = new int[n];
            var depth = new int[n];
            var heavy = new int[n];
            var size = new int[n];
            Array.Fill(parent, -1);
            Array.Fill(heavy, -1);
            var order = new List<int>(n) { 0 };
            for (int i = 0; i < order.Count; i++)
                foreach (int next in graph[order[i]])
                    if (next != parent[order[i]])
                    {
                        parent[next] = order[i];
                        depth[next] = depth[order[i]] + 1;
                        order.Add(next);
                    }
            for (int i = n - 1; i >= 0; i--)
            {
                int node = order[i];
                size[node] = 1;
                foreach (int next in graph[node])
                    if (parent[next] == node)
                    {
                        size[node] += size[next];
                        if (heavy[node] == -1 || size[next] > size[heavy[node]])
                            heavy[node] = next;
                    }
            }

            var head = new int[n];
            var position = new int[n];
            int currentPosition = 0;
            var stack = new Stack<(int Node, int Head)>();
            stack.Push((0, 0));
            while (stack.Count > 0)
            {
                var (node, chainHead) = stack.Pop();
                for (int current = node; current != -1; current = heavy[current])
                {
                    head[current] = chainHead;
                    position[current] = currentPosition++;
                    foreach (int next in graph[current])
                        if (parent[next] == current && next != heavy[current])
                            stack.Push((next, next));
                }
            }

            var labels = s.ToCharArray();
            var tree = new XorSegmentTree(n);
            for (int node = 0; node < n; node++)
                tree.Set(position[node], 1 << (labels[node] - 'a'));
            var answer = new List<bool>();
            foreach (string query in queries)
            {
                string[] parts = query.Split(' ');
                int u = int.Parse(parts[1]);
                if (parts[0] == "update")
                {
                    labels[u] = parts[2][0];
                    tree.Set(position[u], 1 << (labels[u] - 'a'));
                    continue;
                }

                int v = int.Parse(parts[2]);
                int mask = 0;
                while (head[u] != head[v])
                {
                    if (depth[head[u]] < depth[head[v]])
                        (u, v) = (v, u);
                    mask ^= tree.Query(position[head[u]], position[u]);
                    u = parent[head[u]];
                }
                if (depth[u] > depth[v])
                    (u, v) = (v, u);
                mask ^= tree.Query(position[u], position[v]);
                answer.Add((mask & (mask - 1)) == 0);
            }

            return answer;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/incremental-even-weighted-cycle-queries/">3887. Incremental Even-Weighted Cycle Queries (hard)</a>
        /// Counts accepted edges while maintaining parity consistency in each component.
        /// </summary>
        /// <param name="n">The number of graph nodes.</param>
        /// <param name="edges">Candidate undirected weighted edges with weights zero or one.</param>
        /// <returns>The number of edges that preserve even total weight for every cycle.</returns>
        public int NumberOfEdgesAdded(int n, int[][] edges)
        {
            var parent = Enumerable.Range(0, n).ToArray();
            var rank = new int[n];
            var parity = new int[n];
            int Find(int node)
            {
                if (parent[node] == node)
                    return node;
                int previousParent = parent[node];
                parent[node] = Find(previousParent);
                parity[node] ^= parity[previousParent];
                return parent[node];
            }

            int accepted = 0;
            foreach (int[] edge in edges)
            {
                int rootU = Find(edge[0]);
                int parityU = parity[edge[0]];
                int rootV = Find(edge[1]);
                int parityV = parity[edge[1]];
                if (rootU == rootV)
                {
                    if ((parityU ^ parityV) == edge[2])
                        accepted++;
                    continue;
                }

                if (rank[rootU] < rank[rootV])
                {
                    (rootU, rootV) = (rootV, rootU);
                    (parityU, parityV) = (parityV, parityU);
                }
                parent[rootV] = rootU;
                parity[rootV] = parityU ^ parityV ^ edge[2];
                if (rank[rootU] == rank[rootV])
                    rank[rootU]++;
                accepted++;
            }

            return accepted;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-the-degree-of-each-vertex/">3898. Find the Degree of Each Vertex (easy)</a>
        /// Calculates each vertex degree from an undirected adjacency matrix.
        /// </summary>
        /// <param name="matrix">The symmetric adjacency matrix.</param>
        /// <returns>The degree of every vertex.</returns>
        public int[] FindDegrees(int[][] matrix)
        {
            return matrix.Select(row => row.Sum()).ToArray();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/multi-source-flood-fill/">3905. Multi Source Flood Fill (medium)</a>
        /// Colors every grid cell with the highest-valued source that reaches it at minimum distance.
        /// </summary>
        /// <param name="n">The grid row count.</param>
        /// <param name="m">The grid column count.</param>
        /// <param name="sources">Initial [row, column, color] cells.</param>
        /// <returns>The final grid colors.</returns>
        public int[][] ColorGrid(int n, int m, int[][] sources)
        {
            var result = new int[n][];
            var distance = new int[n, m];
            for (int row = 0; row < n; row++)
            {
                result[row] = new int[m];
                for (int col = 0; col < m; col++)
                    distance[row, col] = int.MaxValue;
            }

            var queue = new PriorityQueue<(int Row, int Col, int Color), (int Distance, int NegativeColor)>();
            foreach (int[] source in sources)
            {
                distance[source[0], source[1]] = 0;
                result[source[0]][source[1]] = source[2];
                queue.Enqueue((source[0], source[1], source[2]), (0, -source[2]));
            }

            int[] directions = { 1, 0, -1, 0, 1 };
            while (queue.Count > 0)
            {
                var (row, col, color) = queue.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int nextRow = row + directions[i], nextCol = col + directions[i + 1];
                    if (nextRow < 0 || nextRow >= n || nextCol < 0 || nextCol >= m || distance[nextRow, nextCol] != int.MaxValue)
                        continue;
                    distance[nextRow, nextCol] = distance[row, col] + 1;
                    result[nextRow][nextCol] = color;
                    queue.Enqueue((nextRow, nextCol, color), (distance[nextRow, nextCol], -color));
                }
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-connected-subgraphs-with-even-node-sum/">3910. Count Connected Subgraphs with Even Node Sum (medium)</a>
        /// Enumerates small induced vertex subsets and counts connected subsets with even node-value sum.
        /// </summary>
        /// <param name="nums">Binary node values.</param>
        /// <param name="edges">Undirected graph edges.</param>
        /// <returns>The count of nonempty connected subsets with even sum.</returns>
        public int EvenSumSubgraphs(int[] nums, int[][] edges)
        {
            int n = nums.Length;
            var neighbors = new int[n];
            foreach (int[] edge in edges)
            {
                neighbors[edge[0]] |= 1 << edge[1];
                neighbors[edge[1]] |= 1 << edge[0];
            }

            int result = 0;
            for (int subset = 1; subset < 1 << n; subset++)
            {
                int sum = 0, remaining = subset;
                while (remaining != 0)
                {
                    int bit = remaining & -remaining;
                    int node = BitOperations.TrailingZeroCount((uint)bit);
                    sum += nums[node];
                    remaining -= bit;
                }
                if ((sum & 1) != 0)
                    continue;
                int reached = 0;
                var queue = new Queue<int>();
                int start = BitOperations.TrailingZeroCount((uint)subset);
                queue.Enqueue(start);
                reached |= 1 << start;
                while (queue.Count > 0)
                {
                    int node = queue.Dequeue();
                    int candidates = neighbors[node] & subset & ~reached;
                    while (candidates != 0)
                    {
                        int bit = candidates & -candidates;
                        int next = BitOperations.TrailingZeroCount((uint)bit);
                        reached |= bit;
                        queue.Enqueue(next);
                        candidates -= bit;
                    }
                }
                if (reached == subset)
                    result++;
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-threshold-path-with-limited-heavy-edges/">3924. Minimum Threshold Path With Limited Heavy Edges (medium)</a>
        /// Finds the smallest edge-weight threshold admitting a path with at most k heavier edges.
        /// </summary>
        /// <param name="n">The number of graph nodes.</param>
        /// <param name="edges">Undirected weighted edges.</param>
        /// <param name="source">The source node.</param>
        /// <param name="target">The destination node.</param>
        /// <param name="k">The maximum allowed number of heavy edges.</param>
        /// <returns>The smallest threshold, or -1 when no path exists.</returns>
        public int MinimumThreshold(int n, int[][] edges, int source, int target, int k)
        {
            if (source == target)
                return 0;
            var graph = new List<(int Node, int Weight)>[n];
            for (int i = 0; i < n; i++)
                graph[i] = new List<(int, int)>();
            int maximum = 0;
            foreach (int[] edge in edges)
            {
                graph[edge[0]].Add((edge[1], edge[2]));
                graph[edge[1]].Add((edge[0], edge[2]));
                maximum = Math.Max(maximum, edge[2]);
            }
            bool Valid(int threshold)
            {
                var heavyCount = Enumerable.Repeat(int.MaxValue, n).ToArray();
                var queue = new PriorityQueue<int, int>();
                heavyCount[source] = 0;
                queue.Enqueue(source, 0);
                while (queue.Count > 0)
                {
                    int node = queue.Dequeue();
                    if (node == target)
                        return true;
                    foreach (var (next, weight) in graph[node])
                    {
                        int candidate = heavyCount[node] + (weight > threshold ? 1 : 0);
                        if (candidate <= k && candidate < heavyCount[next])
                        {
                            heavyCount[next] = candidate;
                            queue.Enqueue(next, candidate);
                        }
                    }
                }
                return false;
            }
            if (!Valid(maximum))
                return -1;
            int low = 0, high = maximum;
            while (low < high)
            {
                int middle = low + (high - low) / 2;
                if (Valid(middle))
                    high = middle;
                else
                    low = middle + 1;
            }
            return low;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/shortest-path-with-at-most-k-consecutive-identical-characters/">3970. Shortest Path With At Most K Consecutive Identical Characters (hard)</a>
        /// Runs Dijkstra over node and current repeated-label count states.
        /// </summary>
        /// <param name="n">The number of directed graph nodes.</param>
        /// <param name="edges">Directed weighted edges.</param>
        /// <param name="labels">A character label for every node.</param>
        /// <param name="k">The maximum allowed consecutive equal labels.</param>
        /// <returns>The minimum valid path cost, or -1 when unreachable.</returns>
        public int ShortestPath(int n, int[][] edges, string labels, int k)
        {
            var graph = new List<(int Node, int Weight)>[n];
            for (int i = 0; i < n; i++)
                graph[i] = new List<(int, int)>();
            foreach (int[] edge in edges)
                graph[edge[0]].Add((edge[1], edge[2]));
            var distances = new long[n, k + 1];
            for (int node = 0; node < n; node++)
                for (int count = 1; count <= k; count++)
                    distances[node, count] = long.MaxValue;
            var queue = new PriorityQueue<(int Node, int Count), long>();
            distances[0, 1] = 0;
            queue.Enqueue((0, 1), 0);
            while (queue.Count > 0)
            {
                var (node, count) = queue.Dequeue();
                long distance = distances[node, count];
                if (node == n - 1)
                    return (int)distance;
                foreach (var (next, weight) in graph[node])
                {
                    int nextCount = labels[next] == labels[node] ? count + 1 : 1;
                    if (nextCount <= k && distance + weight < distances[next, nextCount])
                    {
                        distances[next, nextCount] = distance + weight;
                        queue.Enqueue((next, nextCount), distance + weight);
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-time-to-reach-target-with-limited-power/">3977. Minimum Time to Reach Target With Limited Power (medium)</a>
        /// Finds the shortest feasible path and the greatest remaining power among shortest paths.
        /// </summary>
        /// <param name="n">The number of directed graph nodes.</param>
        /// <param name="edges">Directed edges [from, to, travel time].</param>
        /// <param name="power">Initial available power.</param>
        /// <param name="cost">Power needed to forward from each node.</param>
        /// <param name="source">The signal source.</param>
        /// <param name="target">The signal destination.</param>
        /// <returns>[minimum time, maximum remaining power], or [-1, -1] when unreachable.</returns>
        public long[] MinTimeMaxPower(int n, int[][] edges, int power, int[] cost, int source, int target)
        {
            var graph = new List<(int Node, int Time)>[n];
            for (int i = 0; i < n; i++)
                graph[i] = new List<(int, int)>();
            foreach (int[] edge in edges)
                graph[edge[0]].Add((edge[1], edge[2]));
            var distances = new long[n, power + 1];
            for (int node = 0; node < n; node++)
                for (int remaining = 0; remaining <= power; remaining++)
                    distances[node, remaining] = long.MaxValue;
            var queue = new PriorityQueue<(int Node, int Remaining), long>();
            distances[source, power] = 0;
            queue.Enqueue((source, power), 0);
            while (queue.Count > 0)
            {
                var (node, remaining) = queue.Dequeue();
                long time = distances[node, remaining];
                if (remaining < cost[node])
                    continue;
                int nextRemaining = remaining - cost[node];
                foreach (var (next, edgeTime) in graph[node])
                    if (time + edgeTime < distances[next, nextRemaining])
                    {
                        distances[next, nextRemaining] = time + edgeTime;
                        queue.Enqueue((next, nextRemaining), time + edgeTime);
                    }
            }
            long bestTime = long.MaxValue;
            int bestPower = -1;
            for (int remaining = 0; remaining <= power; remaining++)
            {
                long time = distances[target, remaining];
                if (time < bestTime)
                {
                    bestTime = time;
                    bestPower = remaining;
                }
                else if (time == bestTime)
                    bestPower = Math.Max(bestPower, remaining);
            }
            return bestTime == long.MaxValue ? new long[] { -1, -1 } : new long[] { bestTime, bestPower };
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-partition-factor/">3710. Maximum Partition Factor (hard)</a>
        /// Maximizes the within-group Manhattan-distance minimum by bipartite feasibility testing.
        /// </summary>
        /// <param name="points">The point coordinates.</param>
        /// <returns>The greatest achievable partition factor.</returns>
        public int MaxPartitionFactor(int[][] points)
        {
            if (points.Length == 2)
                return 0;
            long Distance(int first, int second) => Math.Abs((long)points[first][0] - points[second][0]) + Math.Abs((long)points[first][1] - points[second][1]);
            bool CanPartition(long factor)
            {
                var colors = Enumerable.Repeat(-1, points.Length).ToArray();
                for (int source = 0; source < points.Length; source++)
                {
                    if (colors[source] != -1)
                        continue;
                    colors[source] = 0;
                    var queue = new Queue<int>();
                    queue.Enqueue(source);
                    while (queue.Count > 0)
                    {
                        int node = queue.Dequeue();
                        for (int next = 0; next < points.Length; next++)
                        {
                            if (next == node)
                                continue;
                            if (Distance(node, next) >= factor)
                                continue;
                            if (colors[next] == -1)
                            {
                                colors[next] = colors[node] ^ 1;
                                queue.Enqueue(next);
                            }
                            else if (colors[next] == colors[node])
                                return false;
                        }
                    }
                }
                return true;
            }
            long low = 0, high = 400_000_001;
            while (low + 1 < high)
            {
                long middle = low + (high - low) / 2;
                if (CanPartition(middle))
                    low = middle;
                else
                    high = middle;
            }
            return (int)low;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/sum-of-perfect-square-ancestors/">3715. Sum of Perfect Square Ancestors (medium)</a>
        /// Counts ancestor pairs whose values have equal square-free kernels.
        /// </summary>
        /// <param name="n">The number of tree nodes.</param>
        /// <param name="edges">Undirected tree edges rooted at zero.</param>
        /// <param name="nums">Positive node values.</param>
        /// <returns>The total number of matching ancestor pairs.</returns>
        public long SumOfAncestors(int n, int[][] edges, int[] nums)
        {
            var graph = BuildUndirectedGraph(n, edges);
            int Kernel(int value)
            {
                int kernel = 1;
                for (int factor = 2; factor * factor <= value; factor++)
                {
                    int exponent = 0;
                    while (value % factor == 0)
                    {
                        value /= factor;
                        exponent++;
                    }
                    if ((exponent & 1) == 1)
                        kernel *= factor;
                }
                return value > 1 ? kernel * value : kernel;
            }
            var kernels = nums.Select(Kernel).ToArray();
            var counts = new Dictionary<int, int>();
            long result = 0;
            var stack = new Stack<(int Node, int Parent, bool Leaving)>();
            stack.Push((0, -1, false));
            while (stack.Count > 0)
            {
                var (node, parent, leaving) = stack.Pop();
                if (leaving)
                {
                    counts[kernels[node]]--;
                    continue;
                }
                counts.TryGetValue(kernels[node], out int ancestors);
                result += ancestors;
                counts[kernels[node]] = ancestors + 1;
                stack.Push((node, parent, true));
                foreach (int next in graph[node])
                    if (next != parent)
                        stack.Push((next, node, false));
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-points-activated-with-one-addition/">3873. Maximum Points Activated with One Addition (medium)</a>
        /// Connects coordinate-sharing components through one additional point.
        /// </summary>
        /// <param name="points">Distinct point coordinates.</param>
        /// <returns>The maximum number of activated points, including the added point.</returns>
        public int MaxActivated(int[][] points)
        {
            int n = points.Length;
            var parent = Enumerable.Range(0, n).ToArray();
            int Find(int node) => parent[node] == node ? node : parent[node] = Find(parent[node]);
            void Union(int first, int second)
            {
                first = Find(first);
                second = Find(second);
                if (first != second)
                    parent[second] = first;
            }
            var byX = new Dictionary<int, int>();
            var byY = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                if (byX.TryGetValue(points[i][0], out int sameX)) Union(i, sameX); else byX[points[i][0]] = i;
                if (byY.TryGetValue(points[i][1], out int sameY)) Union(i, sameY); else byY[points[i][1]] = i;
            }
            var sizes = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                int root = Find(i);
                sizes[root] = sizes.TryGetValue(root, out int size) ? size + 1 : 1;
            }
            var xComponents = byX.Values.Select(Find).Distinct().ToArray();
            var yComponents = byY.Values.Select(Find).Distinct().ToArray();
            int best = 1;
            foreach (int x in xComponents)
                foreach (int y in yComponents)
                    best = Math.Max(best, 1 + sizes[x] + (x == y ? 0 : sizes[y]));
            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-cost-to-buy-apples-ii/">3928. Minimum Cost to Buy Apples II (hard)</a>
        /// Finds each shop's best buy-and-return cost using separate shortest paths for empty and loaded travel.
        /// </summary>
        /// <param name="n">The number of shops.</param>
        /// <param name="prices">Apple prices at shops.</param>
        /// <param name="roads">Bidirectional roads [u, v, cost, tax].</param>
        /// <returns>The minimum apple-acquisition cost for every starting shop.</returns>
        public int[] MinCost(int n, int[] prices, int[][] roads)
        {
            var empty = new List<(int Node, long Weight)>[n];
            var loaded = new List<(int Node, long Weight)>[n];
            for (int i = 0; i < n; i++) { empty[i] = new List<(int, long)>(); loaded[i] = new List<(int, long)>(); }
            foreach (int[] road in roads)
            {
                empty[road[0]].Add((road[1], road[2])); empty[road[1]].Add((road[0], road[2]));
                long weight = (long)road[2] * road[3];
                loaded[road[0]].Add((road[1], weight)); loaded[road[1]].Add((road[0], weight));
            }
            long[] Distances(List<(int Node, long Weight)>[] graph, int source)
            {
                var distances = Enumerable.Repeat(long.MaxValue, n).ToArray();
                var queue = new PriorityQueue<int, long>();
                distances[source] = 0; queue.Enqueue(source, 0);
                while (queue.Count > 0)
                {
                    int node = queue.Dequeue();
                    foreach (var (next, weight) in graph[node])
                        if (distances[node] + weight < distances[next])
                        {
                            distances[next] = distances[node] + weight;
                            queue.Enqueue(next, distances[next]);
                        }
                }
                return distances;
            }
            var answer = new int[n];
            for (int source = 0; source < n; source++)
            {
                long[] outward = Distances(empty, source), returnTrip = Distances(loaded, source);
                long best = prices[source];
                for (int shop = 0; shop < n; shop++)
                    if (outward[shop] != long.MaxValue)
                        best = Math.Min(best, outward[shop] + returnTrip[shop] + prices[shop]);
                answer[source] = (int)best;
            }
            return answer;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-non-adjacent-subsets-in-a-rooted-tree/">3939. Count Non Adjacent Subsets in a Rooted Tree (hard)</a>
        /// Counts independent node subsets by their sum modulo k.
        /// </summary>
        /// <param name="parent">The rooted tree parent array.</param>
        /// <param name="nums">Node values.</param>
        /// <param name="k">The required sum divisor.</param>
        /// <returns>The number of nonempty valid subsets modulo 1,000,000,007.</returns>
        public int CountValidSubsets(int[] parent, int[] nums, int k)
        {
            const long Modulo = 1_000_000_007;
            int n = parent.Length;
            var children = new List<int>[n];
            for (int i = 0; i < n; i++) children[i] = new List<int>();
            for (int i = 1; i < n; i++) children[parent[i]].Add(i);
            var excluded = new long[n][];
            var included = new long[n][];
            for (int node = n - 1; node >= 0; node--)
            {
                long[] without = new long[k], with = new long[k];
                without[0] = 1; with[nums[node] % k] = 1;
                foreach (int child in children[node])
                {
                    long[] nextWithout = new long[k], nextWith = new long[k];
                    for (int a = 0; a < k; a++)
                        for (int b = 0; b < k; b++)
                        {
                            nextWithout[(a + b) % k] = (nextWithout[(a + b) % k] + without[a] * ((excluded[child][b] + included[child][b]) % Modulo)) % Modulo;
                            nextWith[(a + b) % k] = (nextWith[(a + b) % k] + with[a] * excluded[child][b]) % Modulo;
                        }
                    without = nextWithout; with = nextWith;
                }
                excluded[node] = without; included[node] = with;
            }
            return (int)((excluded[0][0] + included[0][0] - 1 + Modulo) % Modulo);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/finish-time-of-tasks-i/">3965. Finish Time of Tasks I (medium)</a>
        /// Calculates the root finish time by evaluating task children bottom-up.
        /// </summary>
        /// <param name="n">The number of tasks.</param>
        /// <param name="edges">Parent-to-child task edges.</param>
        /// <param name="baseTime">Individual task durations.</param>
        /// <returns>The finish time of task zero.</returns>
        public long FinishTime(int n, int[][] edges, int[] baseTime)
        {
            var children = new List<int>[n];
            for (int i = 0; i < n; i++) children[i] = new List<int>();
            foreach (int[] edge in edges) children[edge[0]].Add(edge[1]);
            var finish = baseTime.Select(value => (long)value).ToArray();
            for (int node = n - 1; node >= 0; node--)
                if (children[node].Count > 0)
                {
                    long earliest = children[node].Min(child => finish[child]);
                    long latest = children[node].Max(child => finish[child]);
                    finish[node] = latest + latest - earliest + baseTime[node];
                }
            return finish[0];
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-cost-path-with-alternating-directions-iii/">4003. Minimum Cost Path with Alternating Directions III (medium)</a>
        /// Finds the least-cost grid route while tracking the next action's directional parity.
        /// </summary>
        /// <param name="m">The grid row count.</param>
        /// <param name="n">The grid column count.</param>
        /// <param name="penalty">The cost of waiting or violating a direction rule at each cell.</param>
        /// <returns>The minimum arrival cost.</returns>
        public long MinCost(int m, int n, int[][] penalty)
        {
            var distances = new long[m, n, 2];
            for (int row = 0; row < m; row++) for (int col = 0; col < n; col++) { distances[row, col, 0] = long.MaxValue; distances[row, col, 1] = long.MaxValue; }
            var queue = new PriorityQueue<(int Row, int Col, int Parity), long>();
            distances[0, 0, 1] = 1;
            queue.Enqueue((0, 0, 1), 1);
            int[] directions = { 1, 0, -1, 0, 1 };
            while (queue.Count > 0)
            {
                var (row, col, parity) = queue.Dequeue();
                long cost = distances[row, col, parity];
                if (row == m - 1 && col == n - 1) return cost;
                int nextParity = parity ^ 1;
                long wait = cost + penalty[row][col];
                if (wait < distances[row, col, nextParity]) { distances[row, col, nextParity] = wait; queue.Enqueue((row, col, nextParity), wait); }
                for (int i = 0; i < 4; i++)
                {
                    int nextRow = row + directions[i], nextCol = col + directions[i + 1];
                    if (nextRow < 0 || nextRow >= m || nextCol < 0 || nextCol >= n) continue;
                    bool followsRule = parity == 1 ? i == 0 || i == 3 : i == 1 || i == 2;
                    long candidate = cost + (long)(nextRow + 1) * (nextCol + 1) + (followsRule ? 0 : penalty[row][col]);
                    if (candidate < distances[nextRow, nextCol, nextParity]) { distances[nextRow, nextCol, nextParity] = candidate; queue.Enqueue((nextRow, nextCol, nextParity), candidate); }
                }
            }
            return -1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/weighted-sum-of-a-tree/">4015. Weighted Sum of a Tree (easy)</a>
        /// Sums values weighted by their depth relative to the tree height.
        /// </summary>
        /// <param name="parent">The rooted tree parent array.</param>
        /// <param name="nums">Node values.</param>
        /// <returns>The weighted node-value sum.</returns>
        public long WeightedSum(int[] parent, int[] nums)
        {
            var depth = new int[parent.Length];
            depth[0] = 1;
            int height = 1;
            for (int node = 1; node < parent.Length; node++) height = Math.Max(height, depth[node] = depth[parent[node]] + 1);
            long result = 0;
            for (int node = 0; node < parent.Length; node++) result += (long)nums[node] * (height - depth[node] + 1);
            return result;
        }

        /// <summary>
        /// Builds adjacency lists for an undirected graph.
        /// </summary>
        private static List<int>[] BuildUndirectedGraph(int n, int[][] edges)
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

        /// <summary>
        /// Calculates unweighted tree distances from a source node.
        /// </summary>
        private static int[] TreeDistances(List<int>[] graph, int source)
        {
            var distances = Enumerable.Repeat(-1, graph.Length).ToArray();
            var queue = new Queue<int>();
            distances[source] = 0;
            queue.Enqueue(source);
            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                foreach (int next in graph[node])
                    if (distances[next] == -1)
                    {
                        distances[next] = distances[node] + 1;
                        queue.Enqueue(next);
                    }
            }
            return distances;
        }

        /// <summary>
        /// Range-XOR segment tree for character parity masks.
        /// </summary>
        private sealed class XorSegmentTree
        {
            private readonly int size;
            private readonly int[] values;

            /// <summary>
            /// Initializes a tree covering the requested number of positions.
            /// </summary>
            public XorSegmentTree(int length)
            {
                size = 1;
                while (size < length)
                    size <<= 1;
                values = new int[size * 2];
            }

            /// <summary>
            /// Replaces a position's mask.
            /// </summary>
            public void Set(int index, int value)
            {
                index += size;
                values[index] = value;
                while (index > 1)
                {
                    index >>= 1;
                    values[index] = values[index * 2] ^ values[index * 2 + 1];
                }
            }

            /// <summary>
            /// Returns the XOR of an inclusive index range.
            /// </summary>
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
    }

    /// <summary>
    /// <a href="https://leetcode.com/problems/implement-trie-prefix-tree/">208. Implement Trie (Prefix Tree) (medium)</a>
    /// Prefix tree supporting exact-word and prefix lookups.
    /// </summary>
    public class Trie
    {
        private readonly TrieNode root = new TrieNode();

        /// <summary>
        /// Inserts a word into the trie.
        /// </summary>
        /// <param name="word">The word to insert.</param>
        public void Insert(string word)
        {
            var node = root;
            foreach (char c in word)
            {
                if (!node.Children.TryGetValue(c, out var next))
                {
                    next = new TrieNode();
                    node.Children[c] = next;
                }

                node = next;
            }

            node.IsWord = true;
        }

        /// <summary>
        /// Searches for an exact word in the trie.
        /// </summary>
        /// <param name="word">The word to find.</param>
        /// <returns><see langword="true"/> when the word was inserted; otherwise, <see langword="false"/>.</returns>
        public bool Search(string word)
        {
            var node = FindNode(word);
            return node != null && node.IsWord;
        }

        /// <summary>
        /// Searches for any inserted word with the given prefix.
        /// </summary>
        /// <param name="prefix">The prefix to find.</param>
        /// <returns><see langword="true"/> when at least one inserted word starts with the prefix; otherwise, <see langword="false"/>.</returns>
        public bool StartsWith(string prefix)
        {
            return FindNode(prefix) != null;
        }

        private TrieNode FindNode(string text)
        {
            var node = root;
            foreach (char c in text)
            {
                if (!node.Children.TryGetValue(c, out node))
                    return null;
            }

            return node;
        }

        private sealed class TrieNode
        {
            public readonly Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
            public bool IsWord;
        }
    }

    /// <summary>
    /// <a href="https://leetcode.com/problems/design-add-and-search-words-data-structure/">211. Design Add and Search Words Data Structure (medium)</a>
    /// Trie-backed dictionary supporting exact searches and '.' wildcard searches.
    /// </summary>
    public class WordDictionary
    {
        private readonly WordNode root = new WordNode();

        /// <summary>
        /// Adds a word to the dictionary.
        /// </summary>
        /// <param name="word">The word to add.</param>
        public void AddWord(string word)
        {
            var node = root;
            foreach (char c in word)
            {
                if (!node.Children.TryGetValue(c, out var next))
                {
                    next = new WordNode();
                    node.Children[c] = next;
                }

                node = next;
            }

            node.IsWord = true;
        }

        /// <summary>
        /// Searches for a word, where '.' can match any single character.
        /// </summary>
        /// <param name="word">The search pattern.</param>
        /// <returns><see langword="true"/> when a stored word matches the pattern; otherwise, <see langword="false"/>.</returns>
        public bool Search(string word)
        {
            return Search(word, 0, root);
        }

        private static bool Search(string word, int index, WordNode node)
        {
            if (index == word.Length)
                return node.IsWord;

            char c = word[index];
            if (c == '.')
            {
                foreach (var child in node.Children.Values)
                {
                    if (Search(word, index + 1, child))
                        return true;
                }

                return false;
            }

            return node.Children.TryGetValue(c, out var next) && Search(word, index + 1, next);
        }

        private sealed class WordNode
        {
            public readonly Dictionary<char, WordNode> Children = new Dictionary<char, WordNode>();
            public bool IsWord;
        }
    }

    /// <summary>
    /// <a href="https://leetcode.com/problems/find-median-from-data-stream/">295. Find Median from Data Stream (hard)</a>
    /// Maintains a stream of numbers and returns its median in logarithmic update time.
    /// </summary>
    public class MedianFinder
    {
        private readonly PriorityQueue<int, int> lower = new PriorityQueue<int, int>();
        private readonly PriorityQueue<int, int> upper = new PriorityQueue<int, int>();

        /// <summary>
        /// Adds a number from the data stream.
        /// </summary>
        /// <param name="num">The number to add.</param>
        public void AddNum(int num)
        {
            if (lower.Count == 0 || num <= lower.Peek())
                lower.Enqueue(num, -num);
            else
                upper.Enqueue(num, num);

            if (lower.Count > upper.Count + 1)
            {
                int moved = lower.Dequeue();
                upper.Enqueue(moved, moved);
            }
            else if (upper.Count > lower.Count)
            {
                int moved = upper.Dequeue();
                lower.Enqueue(moved, -moved);
            }
        }

        /// <summary>
        /// Returns the current median of all added numbers.
        /// </summary>
        /// <returns>The median value.</returns>
        public double FindMedian()
        {
            if (lower.Count == upper.Count)
                return ((double)lower.Peek() + upper.Peek()) / 2.0;

            return lower.Peek();
        }
    }

    /// <summary>
    /// <a href="https://leetcode.com/problems/design-twitter/">355. Design Twitter (medium)</a>
    /// Small social feed service supporting posts, follows, unfollows, and ten most recent visible tweets.
    /// </summary>
    public class Twitter
    {
        private int timestamp;
        private readonly Dictionary<int, List<(int Time, int TweetId)>> tweets = new Dictionary<int, List<(int, int)>>();
        private readonly Dictionary<int, HashSet<int>> following = new Dictionary<int, HashSet<int>>();

        /// <summary>
        /// Composes a new tweet for the user.
        /// </summary>
        /// <param name="userId">The posting user id.</param>
        /// <param name="tweetId">The tweet id.</param>
        public void PostTweet(int userId, int tweetId)
        {
            if (!tweets.ContainsKey(userId))
                tweets[userId] = new List<(int, int)>();

            tweets[userId].Add((timestamp++, tweetId));
        }

        /// <summary>
        /// Gets the ten most recent tweet ids posted by the user or followed users.
        /// </summary>
        /// <param name="userId">The user whose feed should be returned.</param>
        /// <returns>Up to ten tweet ids ordered from most recent to least recent.</returns>
        public IList<int> GetNewsFeed(int userId)
        {
            var users = new HashSet<int> { userId };
            if (following.TryGetValue(userId, out var followed))
                users.UnionWith(followed);

            var heap = new PriorityQueue<(int UserId, int Index, int Time, int TweetId), int>();
            foreach (int user in users)
            {
                if (tweets.TryGetValue(user, out var list) && list.Count > 0)
                {
                    int index = list.Count - 1;
                    var tweet = list[index];
                    heap.Enqueue((user, index, tweet.Time, tweet.TweetId), -tweet.Time);
                }
            }

            var feed = new List<int>(10);
            while (heap.Count > 0 && feed.Count < 10)
            {
                var item = heap.Dequeue();
                feed.Add(item.TweetId);
                int nextIndex = item.Index - 1;
                if (nextIndex >= 0)
                {
                    var tweet = tweets[item.UserId][nextIndex];
                    heap.Enqueue((item.UserId, nextIndex, tweet.Time, tweet.TweetId), -tweet.Time);
                }
            }

            return feed;
        }

        /// <summary>
        /// Makes one user follow another user.
        /// </summary>
        /// <param name="followerId">The follower user id.</param>
        /// <param name="followeeId">The followee user id.</param>
        public void Follow(int followerId, int followeeId)
        {
            if (followerId == followeeId)
                return;

            if (!following.ContainsKey(followerId))
                following[followerId] = new HashSet<int>();

            following[followerId].Add(followeeId);
        }

        /// <summary>
        /// Makes one user stop following another user.
        /// </summary>
        /// <param name="followerId">The follower user id.</param>
        /// <param name="followeeId">The followee user id.</param>
        public void Unfollow(int followerId, int followeeId)
        {
            if (following.TryGetValue(followerId, out var followed))
                followed.Remove(followeeId);
        }
    }

    /// <summary>
    /// <a href="https://leetcode.com/problems/insert-delete-getrandom-o1/">380. Insert Delete GetRandom O(1) (medium)</a>
    /// Set supporting insert, remove, and random lookup in average O(1) time.
    /// </summary>
    public class RandomizedSet
    {
        private readonly List<int> values = new List<int>();
        private readonly Dictionary<int, int> indexByValue = new Dictionary<int, int>();
        private readonly Random random = new Random();

        /// <summary>
        /// Inserts a value when absent.
        /// </summary>
        /// <param name="val">The value to insert.</param>
        /// <returns><see langword="true"/> when inserted; otherwise, <see langword="false"/>.</returns>
        public bool Insert(int val)
        {
            if (indexByValue.ContainsKey(val))
                return false;

            indexByValue[val] = values.Count;
            values.Add(val);
            return true;
        }

        /// <summary>
        /// Removes a value when present.
        /// </summary>
        /// <param name="val">The value to remove.</param>
        /// <returns><see langword="true"/> when removed; otherwise, <see langword="false"/>.</returns>
        public bool Remove(int val)
        {
            if (!indexByValue.TryGetValue(val, out int index))
                return false;

            int lastValue = values[values.Count - 1];
            values[index] = lastValue;
            indexByValue[lastValue] = index;
            values.RemoveAt(values.Count - 1);
            indexByValue.Remove(val);
            return true;
        }

        /// <summary>
        /// Returns a random currently stored value.
        /// </summary>
        /// <returns>A uniformly random value from the set.</returns>
        public int GetRandom()
        {
            return values[random.Next(values.Count)];
        }
    }

    /// <summary>
    /// <a href="https://leetcode.com/problems/design-circular-deque/">641. Design Circular Deque (medium)</a>
    /// Fixed-capacity circular double-ended queue.
    /// </summary>
    public class MyCircularDeque
    {
        private readonly int[] buffer;
        private int front;
        private int count;

        public MyCircularDeque(int k)
        {
            buffer = new int[k];
        }

        /// <summary>
        /// Inserts a value at the front of the deque.
        /// </summary>
        /// <param name="value">The value to insert.</param>
        /// <returns><see langword="true"/> when inserted; otherwise, <see langword="false"/> if full.</returns>
        public bool InsertFront(int value)
        {
            if (IsFull())
                return false;

            front = (front - 1 + buffer.Length) % buffer.Length;
            buffer[front] = value;
            count++;
            return true;
        }

        /// <summary>
        /// Inserts a value at the rear of the deque.
        /// </summary>
        /// <param name="value">The value to insert.</param>
        /// <returns><see langword="true"/> when inserted; otherwise, <see langword="false"/> if full.</returns>
        public bool InsertLast(int value)
        {
            if (IsFull())
                return false;

            int rear = (front + count) % buffer.Length;
            buffer[rear] = value;
            count++;
            return true;
        }

        /// <summary>
        /// Deletes the front item.
        /// </summary>
        /// <returns><see langword="true"/> when an item was deleted; otherwise, <see langword="false"/>.</returns>
        public bool DeleteFront()
        {
            if (IsEmpty())
                return false;

            front = (front + 1) % buffer.Length;
            count--;
            return true;
        }

        /// <summary>
        /// Deletes the rear item.
        /// </summary>
        /// <returns><see langword="true"/> when an item was deleted; otherwise, <see langword="false"/>.</returns>
        public bool DeleteLast()
        {
            if (IsEmpty())
                return false;

            count--;
            return true;
        }

        /// <summary>
        /// Gets the front item.
        /// </summary>
        /// <returns>The front value, or -1 when empty.</returns>
        public int GetFront()
        {
            return IsEmpty() ? -1 : buffer[front];
        }

        /// <summary>
        /// Gets the rear item.
        /// </summary>
        /// <returns>The rear value, or -1 when empty.</returns>
        public int GetRear()
        {
            return IsEmpty() ? -1 : buffer[(front + count - 1) % buffer.Length];
        }

        /// <summary>
        /// Indicates whether the deque is empty.
        /// </summary>
        /// <returns><see langword="true"/> when no items are stored; otherwise, <see langword="false"/>.</returns>
        public bool IsEmpty()
        {
            return count == 0;
        }

        /// <summary>
        /// Indicates whether the deque is full.
        /// </summary>
        /// <returns><see langword="true"/> when capacity is exhausted; otherwise, <see langword="false"/>.</returns>
        public bool IsFull()
        {
            return count == buffer.Length;
        }
    }

    /// <summary>
    /// <a href="https://leetcode.com/problems/kth-largest-element-in-a-stream/">703. Kth Largest Element in a Stream (easy)</a>
    /// Maintains the kth largest number in a stream using a size-limited min-heap.
    /// </summary>
    public class KthLargest
    {
        private readonly int k;
        private readonly PriorityQueue<int, int> smallestK = new PriorityQueue<int, int>();

        /// <summary>
        /// Initializes the stream with existing numbers.
        /// </summary>
        /// <param name="k">The rank to report.</param>
        /// <param name="nums">Initial stream values.</param>
        public KthLargest(int k, int[] nums)
        {
            this.k = k;
            foreach (int num in nums)
                Add(num);
        }

        /// <summary>
        /// Adds a value to the stream.
        /// </summary>
        /// <param name="val">The value to add.</param>
        /// <returns>The current kth largest value.</returns>
        public int Add(int val)
        {
            smallestK.Enqueue(val, val);
            if (smallestK.Count > k)
                smallestK.Dequeue();
            return smallestK.Peek();
        }
    }

    /// <summary>
    /// <a href="https://leetcode.com/problems/design-hashset/">705. Design HashSet (easy)</a>
    /// Boolean-array backed hash set for integer keys in the LeetCode key range.
    /// </summary>
    public class MyHashSet
    {
        private readonly bool[] present = new bool[1_000_001];

        /// <summary>
        /// Adds a key to the set.
        /// </summary>
        /// <param name="key">The key to add.</param>
        public void Add(int key)
        {
            present[key] = true;
        }

        /// <summary>
        /// Removes a key from the set.
        /// </summary>
        /// <param name="key">The key to remove.</param>
        public void Remove(int key)
        {
            present[key] = false;
        }

        /// <summary>
        /// Determines whether the set contains a key.
        /// </summary>
        /// <param name="key">The key to find.</param>
        /// <returns><see langword="true"/> when the key exists; otherwise, <see langword="false"/>.</returns>
        public bool Contains(int key)
        {
            return present[key];
        }
    }

    /// <summary>
    /// <a href="https://leetcode.com/problems/design-hashmap/">706. Design HashMap (easy)</a>
    /// Array-backed hash map for integer keys in the LeetCode key range.
    /// </summary>
    public class MyHashMap
    {
        private readonly int[] values = Enumerable.Repeat(-1, 1_000_001).ToArray();

        /// <summary>
        /// Inserts or replaces the value for a key.
        /// </summary>
        /// <param name="key">The key to store.</param>
        /// <param name="value">The value to store.</param>
        public void Put(int key, int value)
        {
            values[key] = value;
        }

        /// <summary>
        /// Gets the value for a key.
        /// </summary>
        /// <param name="key">The key to retrieve.</param>
        /// <returns>The stored value, or -1 when the key is absent.</returns>
        public int Get(int key)
        {
            return values[key];
        }

        /// <summary>
        /// Removes the value for a key.
        /// </summary>
        /// <param name="key">The key to remove.</param>
        public void Remove(int key)
        {
            values[key] = -1;
        }
    }

    /// <summary>
    /// <a href="https://leetcode.com/problems/employee-importance/">690. Employee Importance (medium)</a>
    /// Employee node used by Employee Importance.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// The employee id.
        /// </summary>
        public int id;

        /// <summary>
        /// The employee's individual importance.
        /// </summary>
        public int importance;

        /// <summary>
        /// Direct subordinate employee ids.
        /// </summary>
        public IList<int> subordinates;
    }

    /// <summary>
    /// <a href="https://leetcode.com/problems/lru-cache/">146. LRU Cache (medium)</a>
    /// Least-recently-used cache with O(1) get and put operations.
    /// </summary>
    public class LRUCache
    {
        private readonly int capacity;
        private readonly Dictionary<int, LinkedListNode<(int Key, int Value)>> cache;
        private readonly LinkedList<(int Key, int Value)> usage;

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            cache = new Dictionary<int, LinkedListNode<(int Key, int Value)>>(capacity);
            usage = new LinkedList<(int Key, int Value)>();
        }

        /// <summary>
        /// Gets the value for a key and marks it as recently used.
        /// </summary>
        /// <param name="key">The key to retrieve.</param>
        /// <returns>The cached value, or -1 when the key is absent.</returns>
        public int Get(int key)
        {
            if (!cache.TryGetValue(key, out var node))
                return -1;

            usage.Remove(node);
            usage.AddFirst(node);
            return node.Value.Value;
        }

        /// <summary>
        /// Inserts or updates a value and evicts the least-recently-used key when capacity is exceeded.
        /// </summary>
        /// <param name="key">The key to insert or update.</param>
        /// <param name="value">The value to store.</param>
        public void Put(int key, int value)
        {
            if (capacity <= 0)
                return;

            if (cache.TryGetValue(key, out var node))
            {
                node.Value = (key, value);
                usage.Remove(node);
                usage.AddFirst(node);
                return;
            }

            if (cache.Count == capacity)
            {
                var leastUsed = usage.Last;
                cache.Remove(leastUsed.Value.Key);
                usage.RemoveLast();
            }

            var newNode = new LinkedListNode<(int Key, int Value)>((key, value));
            usage.AddFirst(newNode);
            cache[key] = newNode;
        }
    }


    /// <summary>
    /// <a href="https://leetcode.com/problems/design-graph-with-shortest-path-calculator/">2642. Design Graph With Shortest Path Calculator (hard)</a>
    /// Mutable directed weighted graph that answers shortest-path queries with Dijkstra's algorithm.
    /// </summary>
    public class Graph
    {
        private readonly List<(int Node, int Cost)>[] adjacency;

        /// <summary>
        /// Initializes the graph with n nodes and the supplied directed edges.
        /// </summary>
        /// <param name="n">The number of nodes labeled from 0 to n - 1.</param>
        /// <param name="edges">Directed weighted edges [from, to, cost].</param>
        public Graph(int n, int[][] edges)
        {
            adjacency = new List<(int Node, int Cost)>[n];
            for (int i = 0; i < n; i++)
                adjacency[i] = new List<(int, int)>();
            foreach (var edge in edges)
                AddEdge(edge);
        }

        /// <summary>
        /// Adds a directed weighted edge to the graph.
        /// </summary>
        /// <param name="edge">An edge [from, to, cost].</param>
        public void AddEdge(int[] edge)
        {
            adjacency[edge[0]].Add((edge[1], edge[2]));
        }

        /// <summary>
        /// Computes the least cost path between two nodes.
        /// </summary>
        /// <param name="node1">The source node.</param>
        /// <param name="node2">The destination node.</param>
        /// <returns>The shortest path cost, or -1 when unreachable.</returns>
        public int ShortestPath(int node1, int node2)
        {
            var distances = Enumerable.Repeat(long.MaxValue, adjacency.Length).ToArray();
            var queue = new PriorityQueue<int, long>();
            distances[node1] = 0;
            queue.Enqueue(node1, 0);
            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                long distance = distances[node];
                if (node == node2)
                    return (int)distance;
                foreach (var (next, cost) in adjacency[node])
                {
                    long candidate = distance + cost;
                    if (candidate < distances[next])
                    {
                        distances[next] = candidate;
                        queue.Enqueue(next, candidate);
                    }
                }
            }

            return -1;
        }
    }


    /// <summary>
    /// <a href="https://leetcode.com/problems/design-neighbor-sum-service/">3242. Design Neighbor Sum Service (easy)</a>
    /// Looks up a grid value and sums values adjacent or diagonal to its position.
    /// </summary>
    public class NeighborSum
    {
        private readonly int[][] grid;
        private readonly Dictionary<int, (int Row, int Col)> positionByValue = new Dictionary<int, (int, int)>();

        /// <summary>
        /// Initializes the service with a square grid of unique values.
        /// </summary>
        /// <param name="grid">The source grid.</param>
        public NeighborSum(int[][] grid)
        {
            this.grid = grid;
            for (int r = 0; r < grid.Length; r++)
                for (int c = 0; c < grid[r].Length; c++)
                    positionByValue[grid[r][c]] = (r, c);
        }

        /// <summary>
        /// Sums the four orthogonally adjacent neighbor values.
        /// </summary>
        /// <param name="value">The value whose position determines the neighbors.</param>
        /// <returns>The sum of in-bounds adjacent values.</returns>
        public int AdjacentSum(int value)
        {
            int[] directions = { 1, 0, -1, 0, 1 };
            return SumNeighbors(value, directions, diagonal: false);
        }

        /// <summary>
        /// Sums the four diagonally adjacent neighbor values.
        /// </summary>
        /// <param name="value">The value whose position determines the neighbors.</param>
        /// <returns>The sum of in-bounds diagonal values.</returns>
        public int DiagonalSum(int value)
        {
            return SumNeighbors(value, Array.Empty<int>(), diagonal: true);
        }

        private int SumNeighbors(int value, int[] directions, bool diagonal)
        {
            var (row, col) = positionByValue[value];
            int sum = 0;
            if (diagonal)
            {
                for (int dr = -1; dr <= 1; dr += 2)
                    for (int dc = -1; dc <= 1; dc += 2)
                        sum += ValueAt(row + dr, col + dc);
            }
            else
            {
                for (int i = 0; i < 4; i++)
                    sum += ValueAt(row + directions[i], col + directions[i + 1]);
            }

            return sum;
        }

        private int ValueAt(int row, int col)
        {
            return row >= 0 && row < grid.Length && col >= 0 && col < grid[0].Length ? grid[row][col] : 0;
        }
    }

    /// <summary>
    /// <a href="https://leetcode.com/problems/design-task-manager/">3408. Design Task Manager (medium)</a>
    /// Stores tasks by priority and executes the highest-priority task, breaking ties by larger task id.
    /// </summary>
    public class TaskManager
    {
        private readonly Dictionary<int, (int UserId, int Priority)> tasks = new Dictionary<int, (int, int)>();
        private readonly PriorityQueue<(int TaskId, int UserId, int Priority), (int Priority, int TaskId)> heap = new PriorityQueue<(int, int, int), (int, int)>();

        /// <summary>
        /// Initializes the manager from [userId, taskId, priority] rows.
        /// </summary>
        /// <param name="tasks">Initial tasks.</param>
        public TaskManager(IList<IList<int>> tasks)
        {
            foreach (var task in tasks)
                Add(task[0], task[1], task[2]);
        }

        /// <summary>
        /// Adds a task for a user.
        /// </summary>
        /// <param name="userId">The owner user id.</param>
        /// <param name="taskId">The unique task id.</param>
        /// <param name="priority">The task priority.</param>
        public void Add(int userId, int taskId, int priority)
        {
            tasks[taskId] = (userId, priority);
            heap.Enqueue((taskId, userId, priority), (-priority, -taskId));
        }

        /// <summary>
        /// Updates an existing task's priority.
        /// </summary>
        /// <param name="taskId">The task id to update.</param>
        /// <param name="newPriority">The replacement priority.</param>
        public void Edit(int taskId, int newPriority)
        {
            int userId = tasks[taskId].UserId;
            Add(userId, taskId, newPriority);
        }

        /// <summary>
        /// Removes a task from the manager.
        /// </summary>
        /// <param name="taskId">The task id to remove.</param>
        public void Rmv(int taskId)
        {
            tasks.Remove(taskId);
        }

        /// <summary>
        /// Executes and removes the current top task.
        /// </summary>
        /// <returns>The user id for the executed task, or -1 when no task exists.</returns>
        public int ExecTop()
        {
            while (heap.Count > 0)
            {
                var task = heap.Dequeue();
                if (tasks.TryGetValue(task.TaskId, out var current) && current.UserId == task.UserId && current.Priority == task.Priority)
                {
                    tasks.Remove(task.TaskId);
                    return task.UserId;
                }
            }

            return -1;
        }
    }

    /// <summary>
    /// <a href="https://leetcode.com/problems/implement-router/">3508. Implement Router (medium)</a>
    /// Bounded FIFO packet router supporting duplicate suppression, forwarding, and destination-time range counts.
    /// </summary>
    public class Router
    {
        private readonly int memoryLimit;
        private readonly Queue<(int Source, int Destination, int Timestamp)> packets = new Queue<(int, int, int)>();
        private readonly HashSet<(int Source, int Destination, int Timestamp)> present = new HashSet<(int, int, int)>();
        private readonly Dictionary<int, List<int>> timesByDestination = new Dictionary<int, List<int>>();
        private readonly Dictionary<int, int> offsetByDestination = new Dictionary<int, int>();

        /// <summary>
        /// Initializes the router with a maximum number of stored packets.
        /// </summary>
        /// <param name="memoryLimit">The packet capacity.</param>
        public Router(int memoryLimit)
        {
            this.memoryLimit = memoryLimit;
        }

        /// <summary>
        /// Adds a packet unless the same source, destination, and timestamp is already stored.
        /// </summary>
        /// <param name="source">The packet source.</param>
        /// <param name="destination">The packet destination.</param>
        /// <param name="timestamp">The packet timestamp.</param>
        /// <returns><see langword="true"/> when stored; otherwise, <see langword="false"/> for a duplicate.</returns>
        public bool AddPacket(int source, int destination, int timestamp)
        {
            var packet = (source, destination, timestamp);
            if (present.Contains(packet))
                return false;
            if (packets.Count == memoryLimit)
                ForwardPacket();

            packets.Enqueue(packet);
            present.Add(packet);
            if (!timesByDestination.ContainsKey(destination))
            {
                timesByDestination[destination] = new List<int>();
                offsetByDestination[destination] = 0;
            }

            timesByDestination[destination].Add(timestamp);
            return true;
        }

        /// <summary>
        /// Forwards and removes the oldest stored packet.
        /// </summary>
        /// <returns>The forwarded [source, destination, timestamp], or an empty array when no packet exists.</returns>
        public int[] ForwardPacket()
        {
            if (packets.Count == 0)
                return Array.Empty<int>();

            var packet = packets.Dequeue();
            present.Remove(packet);
            offsetByDestination[packet.Destination]++;
            return new[] { packet.Source, packet.Destination, packet.Timestamp };
        }

        /// <summary>
        /// Counts currently stored packets for a destination whose timestamps fall within an inclusive range.
        /// </summary>
        /// <param name="destination">The destination to count.</param>
        /// <param name="startTime">The inclusive start timestamp.</param>
        /// <param name="endTime">The inclusive end timestamp.</param>
        /// <returns>The number of matching packets.</returns>
        public int GetCount(int destination, int startTime, int endTime)
        {
            if (!timesByDestination.TryGetValue(destination, out var times))
                return 0;
            int offset = offsetByDestination[destination];
            int left = LowerBound(times, startTime, offset);
            int right = UpperBound(times, endTime, offset);
            return right - left;
        }

        private static int LowerBound(List<int> values, int target, int start)
        {
            int left = start;
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

        private static int UpperBound(List<int> values, int target, int start)
        {
            int left = start;
            int right = values.Count;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (values[mid] <= target)
                    left = mid + 1;
                else
                    right = mid;
            }

            return left;
        }
    }

    /// <summary>
    /// <a href="https://leetcode.com/problems/min-stack/">155. Min Stack (medium)</a>
    /// Stack that returns the current minimum value in O(1) time.
    /// </summary>
    public class MinStack
    {
        private readonly Stack<int> values = new Stack<int>();
        private readonly Stack<int> minimums = new Stack<int>();

        /// <summary>
        /// Pushes a value onto the stack.
        /// </summary>
        /// <param name="val">The value to push.</param>
        public void Push(int val)
        {
            values.Push(val);
            if (minimums.Count == 0 || val <= minimums.Peek())
                minimums.Push(val);
        }

        /// <summary>
        /// Removes the top value from the stack.
        /// </summary>
        public void Pop()
        {
            int removed = values.Pop();
            if (removed == minimums.Peek())
                minimums.Pop();
        }

        /// <summary>
        /// Returns the top value of the stack.
        /// </summary>
        /// <returns>The current top value.</returns>
        public int Top()
        {
            return values.Peek();
        }

        /// <summary>
        /// Returns the minimum value currently in the stack.
        /// </summary>
        /// <returns>The current minimum value.</returns>
        public int GetMin()
        {
            return minimums.Peek();
        }
    }
}
