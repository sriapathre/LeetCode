using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace LeetCode.Library
{
    public class Arrays
    {
        /// <summary>
        /// <a href="https://leetcode.com/problems/two-sum/">1. Two Sum (easy)</a>
        /// Given an array of integers and a target, find the two distinct elements whose sum equals the target. This method returns their zero-based indices.
        /// </summary>
        /// <param name="nums">The array of integers to search.</param>
        /// <param name="target">The target sum to match.</param>
        /// <returns>The indices of the two numbers whose values add up to <paramref name="target"/>.</returns>
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();//{value,index}
            for (int i = 0; i < nums.Length; i++)
            {
                var remainder = target - nums[i];
                if (map.ContainsKey(remainder))
                    return new int[] { map[remainder], i };
                else if (!map.ContainsKey(nums[i]))
                    map.Add(nums[i], i);
            }
            return new int[] { };
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/median-of-two-sorted-arrays/">4. Median of Two Sorted Arrays (hard)</a>
        /// Given two sorted arrays, return the median value of the combined sorted sequence. This method merges the inputs and computes the middle value or average of the two middle values.
        /// </summary>
        /// <param name="nums1">The first sorted integer array.</param>
        /// <param name="nums2">The second sorted integer array.</param>
        /// <returns>The median of the two sorted arrays.</returns>
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var m = nums1.Length;
            var n = nums2.Length;
            var middle = (m + n) / 2;
            int[] sorted = new int[m + n];
            int start = 0, i = 0, j = 0;
            bool flag = true;
            while (start < m + n && flag)
            {
                flag = false;
                while (i < nums1.Length && j < nums2.Length && nums1[i] <= nums2[j])
                {
                    sorted[start++] = nums1[i++];
                    flag = true;
                }
                while (i < nums1.Length && j < nums2.Length && nums2[j] < nums1[i])
                {
                    sorted[start++] = nums2[j++];
                    flag = true;
                }
            }
            while (i < nums1.Length)
                sorted[start++] = nums1[i++];
            while (j < nums2.Length)
                sorted[start++] = nums2[j++];


            if ((m + n) % 2 == 0)
                return ((double)sorted[middle - 1] + (double)sorted[middle]) / 2.0;
            else
                return sorted[middle];
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/container-with-most-water/">11. Container With Most Water (medium)</a>
        /// Given heights of vertical lines, choose two lines that together with the x-axis hold the most water. This method returns the maximum possible area.
        /// </summary>
        /// <param name="height">The heights of the vertical lines.</param>
        /// <returns>The maximum amount of water any valid container can store.</returns>
        public int MaxArea(int[] height)
        {
            int maxArea = 0;
            int left = 0, right = height.Length - 1;
            while (left < right)
            {
                int area = Math.Min(height[left], height[right]) * (right - left);
                if (area > maxArea)
                    maxArea = area;
                if (height[left] < height[right])
                    left++;
                else
                    right--;
            }
            return maxArea;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/longest-common-prefix/">14. Longest Common Prefix (easy)</a>
        /// Given an array of strings, find the longest prefix shared by every string. This method returns the common prefix or an empty string when none exists.
        /// </summary>
        /// <param name="strs">The strings to compare for a shared prefix.</param>
        /// <returns>The longest common prefix among all strings in <paramref name="strs"/>.</returns>
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0)
                return String.Empty;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < strs[0].Length; i++)
            {
                char c = strs[0][i];

                for (int j = 1; j < strs.Length; j++)
                {
                    if (i >= strs[j].Length || strs[j][i] != c)
                        return strs[j].Substring(0, i);
                }
                sb.Append(c);
            }
            return sb.ToString();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/3sum/">15. 3Sum (medium)</a>
        /// Given an integer array, find all unique triplets whose sum is zero. This method returns each valid triplet without duplicates.
        /// </summary>
        /// <param name="nums">The integers to search for zero-sum triplets.</param>
        /// <returns>All unique triplets whose values sum to zero.</returns>
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            IList<IList<int>> result = new List<IList<int>>();
            for (int pivot = 0; pivot < nums.Length; pivot++)
            {
                if (pivot > 0 && nums[pivot] == nums[pivot - 1])
                {
                    continue;
                }

                int targetSum = -(nums[pivot]);

                int startIndex = pivot + 1;
                int endIndex = nums.Length - 1;
                while (startIndex < endIndex)
                {
                    int sumOfValuesAtStartAndEndIndex = nums[startIndex] + nums[endIndex];
                    if (sumOfValuesAtStartAndEndIndex == targetSum)
                    {
                        result.Add(new int[] { nums[pivot], nums[startIndex], nums[endIndex] });

                        //No need to look at the same number if its already is in the result.
                        while (startIndex < endIndex && nums[startIndex] == nums[startIndex + 1])
                        {
                            startIndex++;
                        }

                        while (startIndex < endIndex && nums[endIndex] == nums[endIndex - 1])
                        {
                            endIndex--;
                        }

                        startIndex++;
                        endIndex--;
                    }
                    else
                    {
                        if (sumOfValuesAtStartAndEndIndex < targetSum)
                        {
                            startIndex++;
                        }
                        else
                        {
                            endIndex--;
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/3sum-closest/">16. 3Sum Closest (medium)</a>
        /// Given an integer array and a target, find three numbers whose sum is closest to the target. This method returns that closest sum.
        /// </summary>
        /// <param name="nums">The integers to evaluate.</param>
        /// <param name="target">The target sum to approach.</param>
        /// <returns>The sum of the three integers closest to <paramref name="target"/>.</returns>
        public int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            int minDiff = int.MaxValue;
            int result = 0;
            for (int i = 0; i < nums.Length - 2; i++)
            {
                int start = i + 1;
                int end = nums.Length - 1;
                while (start < end)
                {
                    int sum = nums[i] + nums[start] + nums[end];
                    if (Math.Abs(sum - target) < minDiff)
                    {
                        minDiff = Math.Abs(sum - target);
                        result = sum;
                    }
                    if (sum < target)
                        start++;
                    else if (sum > target)
                        end--;
                    else
                        return sum;
                }
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/4sum/">18. 4Sum (medium)</a>
        /// Given an integer array and a target, find all unique quadruplets whose sum equals the target. This method returns each valid quadruplet without duplicates.
        /// </summary>
        /// <param name="nums">The integers to search for target-sum quadruplets.</param>
        /// <param name="target">The target sum for each quadruplet.</param>
        /// <returns>All unique quadruplets whose values sum to <paramref name="target"/>.</returns>
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            Array.Sort(nums);
            IList<IList<int>> result = new List<IList<int>>();
            int n = nums.Length;
            for (int i = 0; i < n - 3; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;
                for (int j = i + 1; j < n - 2; j++)
                {
                    if (j > i + 1 && nums[j] == nums[j - 1])
                        continue;

                    int left = j + 1, right = n - 1;
                    long remaining = (long)target - nums[i] - nums[j];
                    while (left < right)
                    {
                        long sum = (long)nums[left] + nums[right];
                        if (sum == remaining)
                        {
                            result.Add(new List<int> { nums[i], nums[j], nums[left], nums[right] });
                            while (left < right && nums[left] == nums[left + 1])
                                left++;
                            while (left < right && nums[right] == nums[right - 1])
                                right--;
                            left++;
                            right--;
                        }
                        else if (sum < remaining)
                            left++;
                        else
                            right--;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/remove-duplicates-from-sorted-array/">26. Remove Duplicates from Sorted Array (easy)</a>
        /// Given a sorted array, remove duplicates in-place so each unique value appears once while preserving order. This method returns the new logical length.
        /// </summary>
        /// <param name="nums">The sorted array to compact in-place.</param>
        /// <returns>The number of unique elements remaining at the start of <paramref name="nums"/>.</returns>
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            int fast = 1;
            int slow = 1;

            while (fast < nums.Length)
            {
                if (nums[fast - 1] == nums[fast])
                {
                    fast++;
                    continue;
                }

                nums[slow] = nums[fast];
                fast++;
                slow++;
            }
            return slow;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/remove-element/">27. Remove Element (easy)</a>
        /// Given an array and a value, remove all occurrences of that value in-place. This method returns the new logical length after removals.
        /// </summary>
        /// <param name="nums">The array to modify in-place.</param>
        /// <param name="val">The value to remove from the array.</param>
        /// <returns>The number of elements remaining after all matches are removed.</returns>
        public int RemoveElement(int[] nums, int val)
        {
            int replacementCount = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == val)
                {
                    for (int j = i; j < nums.Length - 1; j++)
                    {
                        nums[j] = nums[j + 1];
                    }

                    nums[nums.Length - 1] = -1015;
                    replacementCount += 1;

                    if (nums[i] == val)
                    {
                        i -= 1;
                    }
                }
            }

            return nums.Length - replacementCount;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/next-permutation/">31. Next Permutation (medium)</a>
        /// Rearrange the numbers into the next lexicographically greater permutation. If no greater permutation exists, this method transforms the array into ascending order.
        /// </summary>
        /// <param name="nums">The sequence to permute in-place.</param>
        public void NextPermutation(int[] nums)
        {
            int i = nums.Length - 2;
            while (i >= 0 && nums[i] >= nums[i + 1])
                i--;

            if (i >= 0)
            {
                int j = nums.Length - 1;
                while (nums[j] <= nums[i])
                    j--;
                (nums[i], nums[j]) = (nums[j], nums[i]);
            }

            Array.Reverse(nums, i + 1, nums.Length - i - 1);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/search-in-rotated-sorted-array/">33. Search in Rotated Sorted Array (medium)</a>
        /// Given a rotated sorted array and a target, locate the target value if it exists. This method returns its index or -1 when it is absent.
        /// </summary>
        /// <param name="nums">The rotated sorted array to search.</param>
        /// <param name="target">The value to find.</param>
        /// <returns>The index of <paramref name="target"/> in <paramref name="nums"/>, or -1 if it is not present.</returns>
        public int Search(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    return mid;

                if (nums[left] <= nums[mid])
                {
                    if (nums[left] <= target && target < nums[mid])
                        right = mid - 1;
                    else
                        left = mid + 1;
                }
                else
                {
                    if (nums[mid] < target && target <= nums[right])
                        left = mid + 1;
                    else
                        right = mid - 1;
                }
            }
            return -1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/">34. Find First and Last Position of Element in Sorted Array (medium)</a>
        /// Given a sorted array and a target, find the first and last positions where the target appears. This method returns [-1, -1] when the value does not exist.
        /// </summary>
        /// <param name="nums">The sorted array to search.</param>
        /// <param name="target">The value whose range should be located.</param>
        /// <returns>The starting and ending indices of <paramref name="target"/> in <paramref name="nums"/>.</returns>
        public int[] SearchRange(int[] nums, int target)
        {
            int first = FindBound(nums, target, true);
            if (first == -1)
                return new int[] { -1, -1 };
            int last = FindBound(nums, target, false);
            return new int[] { first, last };
        }

        private int FindBound(int[] nums, int target, bool findFirst)
        {
            int left = 0, right = nums.Length - 1, result = -1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                {
                    result = mid;
                    if (findFirst)
                        right = mid - 1;
                    else
                        left = mid + 1;
                }
                else if (nums[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/search-insert-position/">35. Search Insert Position (easy)</a>
        /// Given a sorted array and a target, return the index where the target is found or should be inserted to keep the array sorted. This method performs that binary search.
        /// </summary>
        /// <param name="nums">The sorted array to search.</param>
        /// <param name="target">The value to locate or insert.</param>
        /// <returns>The existing index of <paramref name="target"/> or the index where it should be inserted.</returns>
        public int SearchInsert(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1, mid = 0;
            while (left <= right)
            {
                mid = (left + right) / 2;
                if (nums[mid] == target)
                    return mid;
                if (nums[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return left;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/valid-sudoku/">36. Valid Sudoku (medium)</a>
        /// Determine whether a partially filled 9x9 Sudoku board is valid according to Sudoku rules. This method checks rows, columns, and 3x3 sub-boxes for duplicates.
        /// </summary>
        /// <param name="board">The partially filled Sudoku board to validate.</param>
        /// <returns><see langword="true"/> if the board is valid so far; otherwise, <see langword="false"/>.</returns>
        public bool IsValidSudoku(char[][] board)
        {
            var rows = new int[9];
            var cols = new int[9];
            var boxes = new int[9];

            for (var i = 0; i < 9; i++)
            {
                for (var j = 0; j < 9; j++)
                {
                    if (board[i][j] == '.') continue;

                    var val = board[i][j] - '1';
                    var box = i / 3 * 3 + j / 3;

                    bool seen = (rows[i] & (1 << val)) != 0;
                    seen = seen || (cols[j] & (1 << val)) != 0;
                    seen = seen || (boxes[box] & (1 << val)) != 0;

                    if (seen)
                    {
                        return false;
                    }

                    rows[i] |= (1 << val);
                    cols[j] |= (1 << val);
                    boxes[box] |= (1 << val);
                }
            }
            return true;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/sudoku-solver/">37. Sudoku Solver (hard)</a>
        /// Solve a 9x9 Sudoku puzzle by filling empty cells so each row, column, and 3x3 sub-box contains digits 1 through 9 exactly once. This method modifies the board in-place.
        /// </summary>
        /// <param name="board">The Sudoku board to solve in-place.</param>
        public void SolveSudoku(char[][] board)
        {
            SolveSudokuHelper(board);
        }

        private bool SolveSudokuHelper(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] != '.')
                        continue;

                    for (char c = '1'; c <= '9'; c++)
                    {
                        if (IsValidPlacement(board, i, j, c))
                        {
                            board[i][j] = c;
                            if (SolveSudokuHelper(board))
                                return true;
                            board[i][j] = '.';
                        }
                    }
                    return false;
                }
            }
            return true;
        }

        private bool IsValidPlacement(char[][] board, int row, int col, char c)
        {
            int boxRow = row / 3 * 3, boxCol = col / 3 * 3;
            for (int i = 0; i < 9; i++)
            {
                if (board[row][i] == c || board[i][col] == c)
                    return false;
                if (board[boxRow + i / 3][boxCol + i % 3] == c)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/combination-sum/">39. Combination Sum (medium)</a>
        /// Given distinct candidate numbers and a target, find all unique combinations that sum to the target. Each candidate may be chosen any number of times.
        /// </summary>
        /// <param name="candidates">The distinct candidate values.</param>
        /// <param name="target">The target sum to build.</param>
        /// <returns>All unique combinations of <paramref name="candidates"/> that total <paramref name="target"/>.</returns>
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            Array.Sort(candidates);
            var result = new List<IList<int>>();
            CombinationSumBacktrack(candidates, target, 0, new List<int>(), result);
            return result;
        }

        private void CombinationSumBacktrack(int[] candidates, int remaining, int start, List<int> current, List<IList<int>> result)
        {
            if (remaining == 0)
            {
                result.Add(new List<int>(current));
                return;
            }

            for (int i = start; i < candidates.Length; i++)
            {
                if (candidates[i] > remaining)
                    break;

                current.Add(candidates[i]);
                CombinationSumBacktrack(candidates, remaining - candidates[i], i, current, result);
                current.RemoveAt(current.Count - 1);
            }
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/combination-sum-ii/">40. Combination Sum II (medium)</a>
        /// Given candidate numbers and a target, find all unique combinations whose sum equals the target. Each input element may be used at most once.
        /// </summary>
        /// <param name="candidates">The candidate values, which may contain duplicates.</param>
        /// <param name="target">The target sum to build.</param>
        /// <returns>All unique combinations that sum to <paramref name="target"/>.</returns>
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            Array.Sort(candidates);
            var result = new List<IList<int>>();
            CombinationSum2Backtrack(candidates, target, 0, new List<int>(), result);
            return result;
        }

        private void CombinationSum2Backtrack(int[] candidates, int remaining, int start, List<int> current, List<IList<int>> result)
        {
            if (remaining == 0)
            {
                result.Add(new List<int>(current));
                return;
            }

            for (int i = start; i < candidates.Length; i++)
            {
                if (i > start && candidates[i] == candidates[i - 1])
                    continue;
                if (candidates[i] > remaining)
                    break;

                current.Add(candidates[i]);
                CombinationSum2Backtrack(candidates, remaining - candidates[i], i + 1, current, result);
                current.RemoveAt(current.Count - 1);
            }
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/first-missing-positive/">41. First Missing Positive (hard)</a>
        /// Given an unsorted integer array, find the smallest positive integer that does not appear in the array. This method does so in linear time using constant extra space.
        /// </summary>
        /// <param name="nums">The array to inspect and reorder in-place.</param>
        /// <returns>The smallest missing positive integer.</returns>
        public int FirstMissingPositive(int[] nums)
        {
            int n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                while (nums[i] > 0 && nums[i] <= n && nums[nums[i] - 1] != nums[i])
                {
                    int target = nums[i] - 1;
                    (nums[i], nums[target]) = (nums[target], nums[i]);
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (nums[i] != i + 1)
                    return i + 1;
            }
            return n + 1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/trapping-rain-water/">42. Trapping Rain Water (hard)</a>
        /// Given bar heights in an elevation map, compute how much rainwater can be trapped after raining. This method returns the total trapped volume.
        /// </summary>
        /// <param name="height">The bar heights of the elevation map.</param>
        /// <returns>The total amount of trapped rainwater.</returns>
        public int Trap(int[] height)
        {
            if (height.Length == 0)
                return 0;

            int left = 0, right = height.Length - 1;
            int leftMax = 0, rightMax = 0, total = 0;
            while (left < right)
            {
                if (height[left] < height[right])
                {
                    leftMax = Math.Max(leftMax, height[left]);
                    total += leftMax - height[left];
                    left++;
                }
                else
                {
                    rightMax = Math.Max(rightMax, height[right]);
                    total += rightMax - height[right];
                    right--;
                }
            }
            return total;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/rotate-image/">48. Rotate Image (medium)</a>
        /// Rotate an n x n matrix 90 degrees clockwise in-place. This method transposes the matrix and then reverses each row.
        /// </summary>
        /// <param name="matrix">The square matrix to rotate in-place.</param>
        public void Rotate(int[][] matrix)
        {
            int n = matrix.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    (matrix[i][j], matrix[j][i]) = (matrix[j][i], matrix[i][j]);
                }
            }

            for (int i = 0; i < n; i++)
            {
                Array.Reverse(matrix[i]);
            }
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-subarray/">53. Maximum Subarray (medium)</a>
        /// Given an integer array, find the contiguous subarray with the largest sum. This method returns that maximum sum.
        /// </summary>
        /// <param name="nums">The array of integers to scan.</param>
        /// <returns>The largest possible sum of any contiguous subarray.</returns>
        public int MaxSubArray(int[] nums)
        {
            int maxSum = nums[0];
            int currentSum = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                currentSum = Math.Max(nums[i], currentSum + nums[i]);
                maxSum = Math.Max(maxSum, currentSum);
            }
            return maxSum;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/spiral-matrix/">54. Spiral Matrix (medium)</a>
        /// Given an m x n matrix, return its elements in spiral order. This method traverses the matrix layer by layer.
        /// </summary>
        /// <param name="matrix">The matrix to traverse.</param>
        /// <returns>The matrix elements ordered in a spiral traversal.</returns>
        public IList<int> SpiralOrder(int[][] matrix)
        {
            var result = new List<int>();
            if (matrix.Length == 0)
                return result;

            int top = 0, bottom = matrix.Length - 1;
            int left = 0, right = matrix[0].Length - 1;

            while (top <= bottom && left <= right)
            {
                for (int col = left; col <= right; col++)
                    result.Add(matrix[top][col]);
                top++;

                for (int row = top; row <= bottom; row++)
                    result.Add(matrix[row][right]);
                right--;

                if (top <= bottom)
                {
                    for (int col = right; col >= left; col--)
                        result.Add(matrix[bottom][col]);
                    bottom--;
                }

                if (left <= right)
                {
                    for (int row = bottom; row >= top; row--)
                        result.Add(matrix[row][left]);
                    left++;
                }
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/merge-intervals/">56. Merge Intervals (medium)</a>
        /// Given a list of intervals, merge all overlapping ranges. This method returns a new list containing the non-overlapping merged intervals.
        /// </summary>
        /// <param name="intervals">The intervals to merge.</param>
        /// <returns>The merged, non-overlapping intervals.</returns>
        public int[][] Merge(int[][] intervals)
        {
            if (intervals.Length == 0)
                return intervals;

            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
            var result = new List<int[]>();
            var current = intervals[0];
            result.Add(current);

            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][0] <= current[1])
                {
                    current[1] = Math.Max(current[1], intervals[i][1]);
                }
                else
                {
                    current = intervals[i];
                    result.Add(current);
                }
            }
            return result.ToArray();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/insert-interval/">57. Insert Interval (medium)</a>
        /// Insert a new interval into a sorted, non-overlapping interval list and merge overlaps as needed. This method returns the updated interval collection.
        /// </summary>
        /// <param name="intervals">The existing sorted, non-overlapping intervals.</param>
        /// <param name="newInterval">The new interval to insert.</param>
        /// <returns>The intervals after inserting and merging <paramref name="newInterval"/>.</returns>
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            var result = new List<int[]>();
            int i = 0, n = intervals.Length;

            while (i < n && intervals[i][1] < newInterval[0])
            {
                result.Add(intervals[i]);
                i++;
            }

            while (i < n && intervals[i][0] <= newInterval[1])
            {
                newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
                newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
                i++;
            }
            result.Add(newInterval);

            while (i < n)
            {
                result.Add(intervals[i]);
                i++;
            }
            return result.ToArray();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/spiral-matrix-ii/">59. Spiral Matrix II (medium)</a>
        /// Generate an n x n matrix filled with values from 1 through n² in spiral order. This method returns the constructed matrix.
        /// </summary>
        /// <param name="n">The width and height of the square matrix to generate.</param>
        /// <returns>An n x n matrix populated in spiral order.</returns>
        public int[][] GenerateMatrix(int n)
        {
            var matrix = new int[n][];
            for (int i = 0; i < n; i++)
                matrix[i] = new int[n];

            int top = 0, bottom = n - 1, left = 0, right = n - 1;
            int value = 1;

            while (top <= bottom && left <= right)
            {
                for (int col = left; col <= right; col++)
                    matrix[top][col] = value++;
                top++;

                for (int row = top; row <= bottom; row++)
                    matrix[row][right] = value++;
                right--;

                if (top <= bottom)
                {
                    for (int col = right; col >= left; col--)
                        matrix[bottom][col] = value++;
                    bottom--;
                }

                if (left <= right)
                {
                    for (int row = bottom; row >= top; row--)
                        matrix[row][left] = value++;
                    left++;
                }
            }
            return matrix;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/unique-paths/">62. Unique Paths (medium)</a>
        /// Count how many distinct paths a robot can take from the top-left to the bottom-right of an m x n grid when it may only move right or down. This method returns that total.
        /// </summary>
        /// <param name="m">The number of grid rows.</param>
        /// <param name="n">The number of grid columns.</param>
        /// <returns>The number of unique paths through the grid.</returns>
        public int UniquePaths(int m, int n)
        {
            var row = new int[n];
            for (int i = 0; i < n; i++)
                row[i] = 1;

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    row[j] += row[j - 1];
                }
            }
            return row[n - 1];
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/unique-paths-ii/">63. Unique Paths II (medium)</a>
        /// Count the unique paths from the top-left to the bottom-right of a grid that contains blocked cells. This method returns the number of obstacle-avoiding paths.
        /// </summary>
        /// <param name="obstacleGrid">The grid where 1 marks an obstacle and 0 marks an open cell.</param>
        /// <returns>The number of valid paths that avoid obstacles.</returns>
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            int m = obstacleGrid.Length;
            int n = obstacleGrid[0].Length;
            var row = new int[n];
            row[0] = obstacleGrid[0][0] == 1 ? 0 : 1;

            for (int j = 1; j < n; j++)
                row[j] = obstacleGrid[0][j] == 1 ? 0 : row[j - 1];

            for (int i = 1; i < m; i++)
            {
                row[0] = obstacleGrid[i][0] == 1 ? 0 : row[0];
                for (int j = 1; j < n; j++)
                {
                    row[j] = obstacleGrid[i][j] == 1 ? 0 : row[j] + row[j - 1];
                }
            }
            return row[n - 1];
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-path-sum/">64. Minimum Path Sum (medium)</a>
        /// Find a path from the top-left to the bottom-right of a grid that minimizes the sum of visited values, moving only right or down. This method returns that minimum sum.
        /// </summary>
        /// <param name="grid">The grid of non-negative path costs.</param>
        /// <returns>The minimum achievable path sum.</returns>
        public int MinPathSum(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            var row = new int[n];
            row[0] = grid[0][0];
            for (int j = 1; j < n; j++)
                row[j] = row[j - 1] + grid[0][j];

            for (int i = 1; i < m; i++)
            {
                row[0] += grid[i][0];
                for (int j = 1; j < n; j++)
                {
                    row[j] = Math.Min(row[j], row[j - 1]) + grid[i][j];
                }
            }
            return row[n - 1];
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/set-matrix-zeroes/">73. Set Matrix Zeroes (medium)</a>
        /// Given a matrix, set an entire row and column to zero whenever a cell is zero. This method performs the transformation in-place.
        /// </summary>
        /// <param name="matrix">The matrix to update in-place.</param>
        public void SetZeroes(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            bool firstRowHasZero = false, firstColHasZero = false;

            for (int j = 0; j < n; j++)
                if (matrix[0][j] == 0) firstRowHasZero = true;
            for (int i = 0; i < m; i++)
                if (matrix[i][0] == 0) firstColHasZero = true;

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[i][0] = 0;
                        matrix[0][j] = 0;
                    }
                }
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (matrix[i][0] == 0 || matrix[0][j] == 0)
                        matrix[i][j] = 0;
                }
            }

            if (firstRowHasZero)
                for (int j = 0; j < n; j++)
                    matrix[0][j] = 0;

            if (firstColHasZero)
                for (int i = 0; i < m; i++)
                    matrix[i][0] = 0;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/search-a-2d-matrix/">74. Search a 2D Matrix (medium)</a>
        /// Determine whether a target exists in a matrix whose rows are sorted and whose first values strictly increase from row to row. This method performs a binary search over the flattened matrix.
        /// </summary>
        /// <param name="matrix">The matrix to search.</param>
        /// <param name="target">The value to find.</param>
        /// <returns><see langword="true"/> if <paramref name="target"/> exists in the matrix; otherwise, <see langword="false"/>.</returns>
        public bool SearchMatrix(int[][] matrix, int target)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            int left = 0, right = m * n - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int value = matrix[mid / n][mid % n];
                if (value == target)
                    return true;
                if (value < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return false;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/sort-colors/">75. Sort Colors (medium)</a>
        /// Sort an array containing only 0s, 1s, and 2s so equal values are adjacent. This method performs the Dutch national flag partition in-place.
        /// </summary>
        /// <param name="nums">The color-coded array to sort in-place.</param>
        public void SortColors(int[] nums)
        {
            int low = 0, mid = 0, high = nums.Length - 1;
            while (mid <= high)
            {
                if (nums[mid] == 0)
                {
                    (nums[low], nums[mid]) = (nums[mid], nums[low]);
                    low++;
                    mid++;
                }
                else if (nums[mid] == 1)
                {
                    mid++;
                }
                else
                {
                    (nums[mid], nums[high]) = (nums[high], nums[mid]);
                    high--;
                }
            }
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/subsets/">78. Subsets (medium)</a>
        /// Given an array of unique integers, return every possible subset. This method generates the full power set.
        /// </summary>
        /// <param name="nums">The distinct values to combine into subsets.</param>
        /// <returns>All possible subsets of <paramref name="nums"/>.</returns>
        public IList<IList<int>> Subsets(int[] nums)
        {
            var result = new List<IList<int>>();
            SubsetsBacktrack(nums, 0, new List<int>(), result);
            return result;
        }

        private void SubsetsBacktrack(int[] nums, int start, List<int> current, List<IList<int>> result)
        {
            result.Add(new List<int>(current));
            for (int i = start; i < nums.Length; i++)
            {
                current.Add(nums[i]);
                SubsetsBacktrack(nums, i + 1, current, result);
                current.RemoveAt(current.Count - 1);
            }
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/">80. Remove Duplicates from Sorted Array II (medium)</a>
        /// Given a sorted array, remove extra duplicates in-place so each distinct value appears at most twice. This method returns the new logical length.
        /// </summary>
        /// <param name="nums">The sorted array to compact in-place.</param>
        /// <returns>The number of elements kept after limiting duplicates to two occurrences.</returns>
        public int RemoveDuplicatesII(int[] nums)
        {
            if (nums.Length <= 2)
                return nums.Length;

            int slow = 2;
            for (int fast = 2; fast < nums.Length; fast++)
            {
                if (nums[fast] != nums[slow - 2])
                {
                    nums[slow] = nums[fast];
                    slow++;
                }
            }
            return slow;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/subsets-ii/">90. Subsets II (medium)</a>
        /// Given an integer array that may contain duplicates, return all unique subsets. This method avoids duplicate subset results.
        /// </summary>
        /// <param name="nums">The values to combine into distinct subsets.</param>
        /// <returns>All unique subsets of <paramref name="nums"/>.</returns>
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            Array.Sort(nums);
            var result = new List<IList<int>>();
            SubsetsWithDupBacktrack(nums, 0, new List<int>(), result);
            return result;
        }

        private void SubsetsWithDupBacktrack(int[] nums, int start, List<int> current, List<IList<int>> result)
        {
            result.Add(new List<int>(current));
            for (int i = start; i < nums.Length; i++)
            {
                if (i > start && nums[i] == nums[i - 1])
                    continue;

                current.Add(nums[i]);
                SubsetsWithDupBacktrack(nums, i + 1, current, result);
                current.RemoveAt(current.Count - 1);
            }
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/plus-one/">66. Plus One (easy)</a>
        /// Given a non-negative integer represented as an array of digits, add one to it. This method returns the resulting digit array.
        /// </summary>
        /// <param name="digits">The digits of the integer in most-significant-first order.</param>
        /// <returns>The digits of the incremented integer.</returns>
        public int[] PlusOne(int[] digits)
        {
            int carry = 1;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                int digit = digits[i] + carry;
                if (digit > 9)
                {
                    carry = 1;
                    digit = 0;
                }
                else
                {
                    carry = 0;
                }
                digits[i] = digit;
            }
            if (carry > 0)
            {
                Array.Resize(ref digits, digits.Length + 1);
                digits[0] = carry;
            }
            return digits;
        }
        /// <summary>
        /// <a href="https://leetcode.com/problems/merge-sorted-array/">88. Merge Sorted Array (easy)</a>
        /// Merge two sorted arrays into the first array in non-decreasing order. This method fills <paramref name="nums1"/> in-place from the end.
        /// </summary>
        /// <param name="nums1">The destination array containing <paramref name="m"/> valid elements plus extra capacity.</param>
        /// <param name="m">The number of initialized elements in <paramref name="nums1"/>.</param>
        /// <param name="nums2">The second sorted array to merge into <paramref name="nums1"/>.</param>
        /// <param name="n">The number of initialized elements in <paramref name="nums2"/>.</param>
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int t = m + n - 1;
            int first = m - 1;
            int second = n - 1;

            while (t >= 0)
            {
                if (second < 0)
                {
                    break;
                }
                if (first >= 0 && nums1[first] > nums2[second])
                {
                    nums1[t] = nums1[first--];
                }
                else
                {
                    nums1[t] = nums2[second--];
                }
                t--;
            }
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/best-time-to-buy-and-sell-stock/">121. Best Time to Buy and Sell Stock (easy)</a>
        /// Given daily stock prices, find the maximum profit obtainable from one buy followed by one sell. This method returns 0 when no profitable trade exists.
        /// </summary>
        /// <param name="prices">The stock price on each day.</param>
        /// <returns>The maximum profit from a single transaction.</returns>
        public int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length <= 1)
                return 0;
            int profit = 0, buy = prices[0];
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] - buy > profit)
                    profit = prices[i] - buy;
                if (prices[i] < buy)
                    buy = prices[i];
            }
            return profit;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/single-number/">136. Single Number (easy)</a>
        /// Given an array where every value appears twice except one, find the value that appears once. This method returns that unique element.
        /// </summary>
        /// <param name="nums">The array containing paired values and one unpaired value.</param>
        /// <returns>The element that appears exactly once.</returns>
        public int SingleNumber(int[] nums)
        {
            HashSet<int> unique = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                unique.Add(nums[i]);
            }

            return 2 * unique.Sum() - nums.Sum();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/majority-element/">169. Majority Element (easy)</a>
        /// Given an array, return the element that appears more than ⌊n / 2⌋ times. This method assumes such an element always exists.
        /// </summary>
        /// <param name="nums">The array containing a guaranteed majority element.</param>
        /// <returns>The majority element in <paramref name="nums"/>.</returns>
        public int MajorityElement(int[] nums)
        {
            int count = 0;
            int candidate = 0;

            foreach (int num in nums)
            {
                if (count == 0)
                {
                    candidate = num;
                }

                if (num == candidate)
                {
                    count++;
                }
                else
                {
                    count--;
                }
            }

            return candidate;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/group-anagrams/">49. Group Anagrams (medium)</a>
        /// Group strings that are anagrams of one another. This method returns the grouped strings in any order.
        /// </summary>
        /// <param name="strs">The strings to group by anagram signature.</param>
        /// <returns>Lists of strings where each inner list contains anagrams.</returns>
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var anagrams = new Dictionary<string, IList<string>>();
            Span<char> counters = stackalloc char[26];
            foreach (string str in strs)
            {
                foreach (char c in str)
                    counters[c - 'a']++;
                var key = new string(counters);
                counters.Clear();
                if (!anagrams.TryGetValue(key, out var val))
                {
                    val = anagrams[key] = new List<string>();
                }
                val.Add(str);
            }
            return anagrams.Values.ToList();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/contains-duplicate/">217. Contains Duplicate (easy)</a>
        /// Determine whether an integer array contains any repeated value. This method returns whether at least one duplicate exists.
        /// </summary>
        /// <param name="nums">The array to inspect for duplicates.</param>
        /// <returns><see langword="true"/> if any value appears more than once; otherwise, <see langword="false"/>.</returns>
        public bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> result = new HashSet<int>();
            foreach (int num in nums)
            {
                if (result.Contains(num))
                    return true;
                result.Add(num);
            }
            return false;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/product-of-array-except-self/">238. Product of Array Except Self (medium)</a>
        /// For each position in an array, compute the product of all other elements without using division. This method returns the resulting product array.
        /// </summary>
        /// <param name="nums">The input values to multiply around each index.</param>
        /// <returns>An array where each entry is the product of all values except the one at that index.</returns>
        public int[] ProductExceptSelf(int[] nums)
        {
            var result = new int[nums.Length];
            int left = 1, right = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = left;
                left *= nums[i];
            }
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                result[i] = result[i] * right;
                right = right * nums[i];
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/top-k-frequent-elements/">347. Top K Frequent Elements (medium)</a>
        /// Given an integer array, return the k values that appear most frequently. This method uses bucket grouping by frequency to produce the result.
        /// </summary>
        /// <param name="nums">The values whose frequencies should be counted.</param>
        /// <param name="k">The number of most frequent elements to return.</param>
        /// <returns>The <paramref name="k"/> most frequent elements from <paramref name="nums"/>.</returns>
        public int[] TopKFrequent(int[] nums, int k)
        {
            var map = new Dictionary<int, int>();
            foreach (var n in nums)
            {
                int freq = map.GetValueOrDefault(n);
                map[n] = freq + 1;
            }

            var bucket = new List<int>[nums.Length + 1];
            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<int>();
            }

            foreach (var item in map)
            {

                bucket[item.Value].Add(item.Key);
            }

            var result = new int[k];
            int index = 0;
            for (int i = bucket.Length - 1; i >= 0; i--)
            {
                foreach (var n in bucket[i])
                {
                    result[index] = n;
                    index++;
                    if (index == k) return result;
                }
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/jump-game-ii/">45. Jump Game II (medium)</a>
        /// Given jump lengths from each index, find the minimum number of jumps needed to reach the last index. This method uses a greedy range expansion strategy.
        /// </summary>
        /// <param name="nums">The maximum jump length available from each index.</param>
        /// <returns>The minimum number of jumps required to reach the last index.</returns>
        public int Jump(int[] nums)
        {
            int jumps = 0, currentEnd = 0, farthest = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                farthest = Math.Max(farthest, i + nums[i]);
                if (i == currentEnd)
                {
                    jumps++;
                    currentEnd = farthest;
                }
            }
            return jumps;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/jump-game/">55. Jump Game (medium)</a>
        /// Given jump lengths from each index, determine whether the last index is reachable from the first. This method greedily tracks the farthest reachable position.
        /// </summary>
        /// <param name="nums">The maximum jump length available from each index.</param>
        /// <returns><see langword="true"/> if the last index is reachable; otherwise, <see langword="false"/>.</returns>
        public bool CanJump(int[] nums)
        {
            int reach = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > reach)
                    return false;
                reach = Math.Max(reach, i + nums[i]);
            }
            return true;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/permutations/">46. Permutations (medium)</a>
        /// Given an array of distinct integers, return every possible ordering of its elements. This method generates all permutations via backtracking.
        /// </summary>
        /// <param name="nums">The distinct values to permute.</param>
        /// <returns>All possible permutations of <paramref name="nums"/>.</returns>
        public IList<IList<int>> Permute(int[] nums)
        {
            var result = new List<IList<int>>();
            PermuteBacktrack(nums, new List<int>(), new bool[nums.Length], result);
            return result;
        }

        private void PermuteBacktrack(int[] nums, List<int> current, bool[] used, List<IList<int>> result)
        {
            if (current.Count == nums.Length)
            {
                result.Add(new List<int>(current));
                return;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (used[i])
                    continue;
                used[i] = true;
                current.Add(nums[i]);
                PermuteBacktrack(nums, current, used, result);
                current.RemoveAt(current.Count - 1);
                used[i] = false;
            }
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/permutations-ii/">47. Permutations II (medium)</a>
        /// Given numbers that may contain duplicates, return all unique permutations. This method avoids duplicate orderings during backtracking.
        /// </summary>
        /// <param name="nums">The values to permute, including possible duplicates.</param>
        /// <returns>All unique permutations of <paramref name="nums"/>.</returns>
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            Array.Sort(nums);
            var result = new List<IList<int>>();
            PermuteUniqueBacktrack(nums, new List<int>(), new bool[nums.Length], result);
            return result;
        }

        private void PermuteUniqueBacktrack(int[] nums, List<int> current, bool[] used, List<IList<int>> result)
        {
            if (current.Count == nums.Length)
            {
                result.Add(new List<int>(current));
                return;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (used[i])
                    continue;
                if (i > 0 && nums[i] == nums[i - 1] && !used[i - 1])
                    continue;
                used[i] = true;
                current.Add(nums[i]);
                PermuteUniqueBacktrack(nums, current, used, result);
                current.RemoveAt(current.Count - 1);
                used[i] = false;
            }
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/n-queens/">51. N-Queens (hard)</a>
        /// Place n queens on an n x n chessboard so that no two queens attack each other. This method returns every distinct valid board configuration.
        /// </summary>
        /// <param name="n">The size of the chessboard and the number of queens to place.</param>
        /// <returns>All distinct board configurations that solve the n-queens puzzle.</returns>
        public IList<IList<string>> SolveNQueens(int n)
        {
            var result = new List<IList<string>>();
            var cols = new bool[n];
            var diag1 = new bool[2 * n]; // row - col + n
            var diag2 = new bool[2 * n]; // row + col
            var positions = new int[n]; // positions[row] = col
            SolveNQueensBacktrack(0, n, cols, diag1, diag2, positions, result);
            return result;
        }

        private void SolveNQueensBacktrack(int row, int n, bool[] cols, bool[] diag1, bool[] diag2, int[] positions, IList<IList<string>> result)
        {
            if (row == n)
            {
                result.Add(BuildBoard(positions, n));
                return;
            }
            for (int col = 0; col < n; col++)
            {
                int d1 = row - col + n;
                int d2 = row + col;
                if (cols[col] || diag1[d1] || diag2[d2])
                    continue;

                cols[col] = diag1[d1] = diag2[d2] = true;
                positions[row] = col;
                SolveNQueensBacktrack(row + 1, n, cols, diag1, diag2, positions, result);
                cols[col] = diag1[d1] = diag2[d2] = false;
            }
        }

        private IList<string> BuildBoard(int[] positions, int n)
        {
            var board = new List<string>(n);
            for (int row = 0; row < n; row++)
            {
                var chars = new char[n];
                for (int col = 0; col < n; col++)
                    chars[col] = col == positions[row] ? 'Q' : '.';
                board.Add(new string(chars));
            }
            return board;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/n-queens-ii/">52. N-Queens II (hard)</a>
        /// Place n queens on an n x n chessboard so that no two queens attack each other. This method returns the number of distinct valid solutions.
        /// </summary>
        /// <param name="n">The size of the chessboard and the number of queens to place.</param>
        /// <returns>The number of distinct solutions to the n-queens puzzle.</returns>
        public int TotalNQueens(int n)
        {
            var cols = new bool[n];
            var diag1 = new bool[2 * n];
            var diag2 = new bool[2 * n];
            return TotalNQueensBacktrack(0, n, cols, diag1, diag2);
        }

        private int TotalNQueensBacktrack(int row, int n, bool[] cols, bool[] diag1, bool[] diag2)
        {
            if (row == n)
                return 1;

            int count = 0;
            for (int col = 0; col < n; col++)
            {
                int d1 = row - col + n;
                int d2 = row + col;
                if (cols[col] || diag1[d1] || diag2[d2])
                    continue;

                cols[col] = diag1[d1] = diag2[d2] = true;
                count += TotalNQueensBacktrack(row + 1, n, cols, diag1, diag2);
                cols[col] = diag1[d1] = diag2[d2] = false;
            }
            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/permutation-sequence/">60. Permutation Sequence (hard)</a>
        /// Consider all permutations of the numbers 1 through n in lexicographic order and return the k-th one. This method constructs that permutation directly.
        /// </summary>
        /// <param name="n">The count of digits from 1 through n to permute.</param>
        /// <param name="k">The 1-based position of the permutation to return.</param>
        /// <returns>The k-th permutation sequence of the numbers 1 through <paramref name="n"/>.</returns>
        public string GetPermutation(int n, int k)
        {
            var factorial = new int[n + 1];
            factorial[0] = 1;
            for (int i = 1; i <= n; i++)
                factorial[i] = factorial[i - 1] * i;

            var numbers = new List<int>();
            for (int i = 1; i <= n; i++)
                numbers.Add(i);

            k--; // convert to 0-indexed
            var sb = new StringBuilder();
            for (int i = n; i >= 1; i--)
            {
                int index = k / factorial[i - 1];
                k %= factorial[i - 1];
                sb.Append(numbers[index]);
                numbers.RemoveAt(index);
            }
            return sb.ToString();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/combinations/">77. Combinations (medium)</a>
        /// Choose k numbers from the range 1 through n and return every possible combination. This method generates all such combinations in any order.
        /// </summary>
        /// <param name="n">The inclusive upper bound of the number range.</param>
        /// <param name="k">The number of values to choose per combination.</param>
        /// <returns>All possible combinations of <paramref name="k"/> numbers from 1 through <paramref name="n"/>.</returns>
        public IList<IList<int>> Combine(int n, int k)
        {
            var result = new List<IList<int>>();
            CombineBacktrack(1, n, k, new List<int>(), result);
            return result;
        }

        private void CombineBacktrack(int start, int n, int k, List<int> current, List<IList<int>> result)
        {
            if (current.Count == k)
            {
                result.Add(new List<int>(current));
                return;
            }
            // prune: not enough remaining numbers to reach k
            for (int i = start; i <= n - (k - current.Count) + 1; i++)
            {
                current.Add(i);
                CombineBacktrack(i + 1, n, k, current, result);
                current.RemoveAt(current.Count - 1);
            }
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/word-search/">79. Word Search (medium)</a>
        /// Determine whether a word can be formed in a character grid by moving horizontally or vertically to adjacent cells without reusing a cell. This method returns whether such a path exists.
        /// </summary>
        /// <param name="board">The character grid to search.</param>
        /// <param name="word">The word to construct from adjacent cells.</param>
        /// <returns><see langword="true"/> if <paramref name="word"/> exists in <paramref name="board"/>; otherwise, <see langword="false"/>.</returns>
        public bool Exist(char[][] board, string word)
        {
            if (string.IsNullOrEmpty(word))
                return true;
            if (board == null || board.Length == 0 || board[0].Length == 0)
                return false;

            int rows = board.Length, cols = board[0].Length;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (ExistBacktrack(board, word, r, c, 0))
                        return true;
                }
            }
            return false;
        }

        private bool ExistBacktrack(char[][] board, string word, int row, int col, int index)
        {
            if (index == word.Length)
                return true;
            if (row < 0 || row >= board.Length || col < 0 || col >= board[0].Length || board[row][col] != word[index])
                return false;

            char temp = board[row][col];
            board[row][col] = '#'; // mark visited
            bool found = ExistBacktrack(board, word, row + 1, col, index + 1) ||
                         ExistBacktrack(board, word, row - 1, col, index + 1) ||
                         ExistBacktrack(board, word, row, col + 1, index + 1) ||
                         ExistBacktrack(board, word, row, col - 1, index + 1);
            board[row][col] = temp; // restore

            return found;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/search-in-rotated-sorted-array-ii/">81. Search in Rotated Sorted Array II (medium)</a>
        /// Determine whether a target exists in a rotated sorted array that may contain duplicates. This method returns whether the value can be found.
        /// </summary>
        /// <param name="nums">The rotated sorted array to search.</param>
        /// <param name="target">The value to locate.</param>
        /// <returns><see langword="true"/> if <paramref name="target"/> exists in <paramref name="nums"/>; otherwise, <see langword="false"/>.</returns>
        public bool SearchII(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    return true;

                if (nums[left] == nums[mid] && nums[mid] == nums[right])
                {
                    left++;
                    right--;
                }
                else if (nums[left] <= nums[mid])
                {
                    if (nums[left] <= target && target < nums[mid])
                        right = mid - 1;
                    else
                        left = mid + 1;
                }
                else
                {
                    if (nums[mid] < target && target <= nums[right])
                        left = mid + 1;
                    else
                        right = mid - 1;
                }
            }
            return false;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/largest-rectangle-in-histogram/">84. Largest Rectangle in Histogram (hard)</a>
        /// Given histogram bar heights, find the area of the largest rectangle that can be formed. This method computes that maximum area using a monotonic stack.
        /// </summary>
        /// <param name="heights">The heights of the histogram bars.</param>
        /// <returns>The area of the largest rectangle in the histogram.</returns>
        public int LargestRectangleArea(int[] heights)
        {
            var stack = new Stack<int>(); // indices of bars with increasing heights
            int maxArea = 0;
            int n = heights.Length;

            for (int i = 0; i <= n; i++)
            {
                int currentHeight = (i == n) ? 0 : heights[i];
                while (stack.Count > 0 && heights[stack.Peek()] >= currentHeight)
                {
                    int height = heights[stack.Pop()];
                    int width = stack.Count == 0 ? i : i - stack.Peek() - 1;
                    maxArea = Math.Max(maxArea, height * width);
                }
                stack.Push(i);
            }
            return maxArea;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximal-rectangle/">85. Maximal Rectangle (hard)</a>
        /// Given a binary matrix, find the area of the largest rectangle containing only 1s. This method treats each row as a histogram and returns the best area found.
        /// </summary>
        /// <param name="matrix">The binary matrix to evaluate.</param>
        /// <returns>The area of the largest rectangle containing only 1s.</returns>
        public int MaximalRectangle(char[][] matrix)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
                return 0;

            int cols = matrix[0].Length;
            var heights = new int[cols];
            int maxArea = 0;

            foreach (var row in matrix)
            {
                for (int c = 0; c < cols; c++)
                    heights[c] = row[c] == '1' ? heights[c] + 1 : 0;

                maxArea = Math.Max(maxArea, LargestRectangleArea(heights));
            }
            return maxArea;
        }
    }
}
