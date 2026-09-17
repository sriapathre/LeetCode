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
        /// <a href="https://leetcode.com/problems/triangle/">120. Triangle (medium)</a>
        /// Given a triangle array, find the minimum path sum from top to bottom by moving only to adjacent values on the next row.
        /// </summary>
        /// <param name="triangle">The triangle rows to evaluate.</param>
        /// <returns>The minimum top-to-bottom path sum.</returns>
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            var dp = triangle[triangle.Count - 1].ToArray();
            for (int row = triangle.Count - 2; row >= 0; row--)
            {
                for (int col = 0; col < triangle[row].Count; col++)
                {
                    dp[col] = triangle[row][col] + Math.Min(dp[col], dp[col + 1]);
                }
            }
            return dp[0];
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/">122. Best Time to Buy and Sell Stock II (medium)</a>
        /// Given daily stock prices, find the maximum profit with as many buy-sell transactions as desired, while holding at most one share at a time.
        /// </summary>
        /// <param name="prices">The stock price on each day.</param>
        /// <returns>The maximum profit from unlimited transactions.</returns>
        public int MaxProfitII(int[] prices)
        {
            int profit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                    profit += prices[i] - prices[i - 1];
            }
            return profit;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iii/">123. Best Time to Buy and Sell Stock III (hard)</a>
        /// Given daily stock prices, find the maximum profit using at most two complete buy-sell transactions.
        /// </summary>
        /// <param name="prices">The stock price on each day.</param>
        /// <returns>The maximum profit from at most two transactions.</returns>
        public int MaxProfitIII(int[] prices)
        {
            int buy1 = int.MinValue, buy2 = int.MinValue;
            int sell1 = 0, sell2 = 0;
            foreach (int price in prices)
            {
                buy1 = Math.Max(buy1, -price);
                sell1 = Math.Max(sell1, buy1 + price);
                buy2 = Math.Max(buy2, sell1 - price);
                sell2 = Math.Max(sell2, buy2 + price);
            }
            return sell2;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/longest-consecutive-sequence/">128. Longest Consecutive Sequence (medium)</a>
        /// Given an unsorted integer array, find the length of the longest run of consecutive values.
        /// </summary>
        /// <param name="nums">The values to inspect.</param>
        /// <returns>The length of the longest consecutive sequence.</returns>
        public int LongestConsecutive(int[] nums)
        {
            var values = new HashSet<int>(nums);
            int longest = 0;
            foreach (int num in values)
            {
                if (values.Contains(num - 1))
                    continue;

                int current = num;
                int length = 1;
                while (values.Contains(current + 1))
                {
                    current++;
                    length++;
                }
                longest = Math.Max(longest, length);
            }
            return longest;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/gas-station/">134. Gas Station (medium)</a>
        /// Given gas available and travel costs around a circular route, find a starting station that can complete the circuit if one exists.
        /// </summary>
        /// <param name="gas">The gas available at each station.</param>
        /// <param name="cost">The gas required to travel from each station to the next.</param>
        /// <returns>The valid starting station index, or -1 when the circuit cannot be completed.</returns>
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            int total = 0, tank = 0, start = 0;
            for (int i = 0; i < gas.Length; i++)
            {
                int delta = gas[i] - cost[i];
                total += delta;
                tank += delta;
                if (tank < 0)
                {
                    start = i + 1;
                    tank = 0;
                }
            }
            return total >= 0 ? start : -1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/candy/">135. Candy (hard)</a>
        /// Given children's ratings, distribute the fewest candies so every child gets one and higher-rated neighbors get more than adjacent lower-rated children.
        /// </summary>
        /// <param name="ratings">The rating of each child in line.</param>
        /// <returns>The minimum number of candies required.</returns>
        public int Candy(int[] ratings)
        {
            var candies = new int[ratings.Length];
            Array.Fill(candies, 1);

            for (int i = 1; i < ratings.Length; i++)
            {
                if (ratings[i] > ratings[i - 1])
                    candies[i] = candies[i - 1] + 1;
            }

            for (int i = ratings.Length - 2; i >= 0; i--)
            {
                if (ratings[i] > ratings[i + 1])
                    candies[i] = Math.Max(candies[i], candies[i + 1] + 1);
            }
            return candies.Sum();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-product-subarray/">152. Maximum Product Subarray (medium)</a>
        /// Given an integer array, find the largest product of any contiguous subarray.
        /// </summary>
        /// <param name="nums">The values to scan.</param>
        /// <returns>The maximum product of a contiguous subarray.</returns>
        public int MaxProduct(int[] nums)
        {
            int currentMax = nums[0], currentMin = nums[0], best = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                int num = nums[i];
                if (num < 0)
                    (currentMax, currentMin) = (currentMin, currentMax);

                currentMax = Math.Max(num, currentMax * num);
                currentMin = Math.Min(num, currentMin * num);
                best = Math.Max(best, currentMax);
            }
            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/">153. Find Minimum in Rotated Sorted Array (medium)</a>
        /// Given a rotated strictly increasing array, find its minimum element.
        /// </summary>
        /// <param name="nums">The rotated sorted array without duplicates.</param>
        /// <returns>The minimum value in <paramref name="nums"/>.</returns>
        public int FindMin(int[] nums)
        {
            int left = 0, right = nums.Length - 1;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] > nums[right])
                    left = mid + 1;
                else
                    right = mid;
            }
            return nums[left];
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-minimum-in-rotated-sorted-array-ii/">154. Find Minimum in Rotated Sorted Array II (hard)</a>
        /// Given a rotated sorted array that may contain duplicates, find its minimum element.
        /// </summary>
        /// <param name="nums">The rotated sorted array that may include duplicate values.</param>
        /// <returns>The minimum value in <paramref name="nums"/>.</returns>
        public int FindMinII(int[] nums)
        {
            int left = 0, right = nums.Length - 1;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] > nums[right])
                    left = mid + 1;
                else if (nums[mid] < nums[right])
                    right = mid;
                else
                    right--;
            }
            return nums[left];
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-peak-element/">162. Find Peak Element (medium)</a>
        /// Given an array where adjacent values are not equal, find an index of any peak element greater than its neighbors.
        /// </summary>
        /// <param name="nums">The values to search for a peak.</param>
        /// <returns>An index containing a peak element.</returns>
        public int FindPeakElement(int[] nums)
        {
            int left = 0, right = nums.Length - 1;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] < nums[mid + 1])
                    left = mid + 1;
                else
                    right = mid;
            }
            return left;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-gap/">164. Maximum Gap (medium)</a>
        /// Given an unsorted array, find the maximum difference between successive elements in its sorted order without fully sorting the array.
        /// </summary>
        /// <param name="nums">The non-negative integers to evaluate.</param>
        /// <returns>The maximum sorted adjacent gap, or 0 when fewer than two values exist.</returns>
        public int MaximumGap(int[] nums)
        {
            if (nums.Length < 2)
                return 0;

            int min = nums.Min();
            int max = nums.Max();
            if (min == max)
                return 0;

            int n = nums.Length;
            int bucketSize = Math.Max(1, (int)Math.Ceiling((double)(max - min) / (n - 1)));
            int bucketCount = ((max - min) / bucketSize) + 1;
            var bucketMins = Enumerable.Repeat(int.MaxValue, bucketCount).ToArray();
            var bucketMaxes = Enumerable.Repeat(int.MinValue, bucketCount).ToArray();

            foreach (int num in nums)
            {
                int index = (num - min) / bucketSize;
                bucketMins[index] = Math.Min(bucketMins[index], num);
                bucketMaxes[index] = Math.Max(bucketMaxes[index], num);
            }

            int previousMax = min;
            int result = 0;
            for (int i = 0; i < bucketCount; i++)
            {
                if (bucketMins[i] == int.MaxValue)
                    continue;

                result = Math.Max(result, bucketMins[i] - previousMax);
                previousMax = bucketMaxes[i];
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/">167. Two Sum II - Input Array Is Sorted (medium)</a>
        /// Given a 1-indexed sorted array, find the two numbers whose sum equals the target.
        /// </summary>
        /// <param name="numbers">The non-decreasing sorted numbers to search.</param>
        /// <param name="target">The target sum to find.</param>
        /// <returns>The one-based indices of the two matching values, or an empty array if no pair exists.</returns>
        public int[] TwoSumII(int[] numbers, int target)
        {
            int left = 0, right = numbers.Length - 1;
            while (left < right)
            {
                int sum = numbers[left] + numbers[right];
                if (sum == target)
                    return new[] { left + 1, right + 1 };
                if (sum < target)
                    left++;
                else
                    right--;
            }
            return Array.Empty<int>();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/dungeon-game/">174. Dungeon Game (hard)</a>
        /// Given a dungeon grid, compute the knight's minimum initial health needed to rescue the princess while never dropping to zero health.
        /// </summary>
        /// <param name="dungeon">The dungeon rooms, where negative values damage and positive values heal.</param>
        /// <returns>The minimum initial health required.</returns>
        public int CalculateMinimumHP(int[][] dungeon)
        {
            int rows = dungeon.Length;
            int cols = dungeon[0].Length;
            var dp = Enumerable.Repeat(int.MaxValue, cols + 1).ToArray();
            dp[cols - 1] = 1;

            for (int row = rows - 1; row >= 0; row--)
            {
                for (int col = cols - 1; col >= 0; col--)
                {
                    int needed = Math.Min(dp[col], dp[col + 1]) - dungeon[row][col];
                    dp[col] = Math.Max(1, needed);
                }
            }
            return dp[0];
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iv/">188. Best Time to Buy and Sell Stock IV (hard)</a>
        /// Given daily stock prices and at most k transactions, find the maximum achievable profit.
        /// </summary>
        /// <param name="k">The maximum number of complete buy-sell transactions allowed.</param>
        /// <param name="prices">The stock price on each day.</param>
        /// <returns>The maximum profit from at most <paramref name="k"/> transactions.</returns>
        public int MaxProfitIV(int k, int[] prices)
        {
            if (k == 0 || prices.Length < 2)
                return 0;
            if (k >= prices.Length / 2)
                return MaxProfitII(prices);

            var buys = Enumerable.Repeat(int.MinValue, k + 1).ToArray();
            var sells = new int[k + 1];
            foreach (int price in prices)
            {
                for (int transaction = 1; transaction <= k; transaction++)
                {
                    buys[transaction] = Math.Max(buys[transaction], sells[transaction - 1] - price);
                    sells[transaction] = Math.Max(sells[transaction], buys[transaction] + price);
                }
            }
            return sells[k];
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/rotate-array/">189. Rotate Array (medium)</a>
        /// Given an array, rotate it to the right by k steps in-place.
        /// </summary>
        /// <param name="nums">The array to rotate in-place.</param>
        /// <param name="k">The number of right-rotation steps.</param>
        public void Rotate(int[] nums, int k)
        {
            if (nums.Length == 0)
                return;

            k %= nums.Length;
            Array.Reverse(nums);
            Array.Reverse(nums, 0, k);
            Array.Reverse(nums, k, nums.Length - k);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/house-robber/">198. House Robber (medium)</a>
        /// Given money in houses along a street, find the maximum amount that can be robbed without robbing adjacent houses.
        /// </summary>
        /// <param name="nums">The money available in each house.</param>
        /// <returns>The maximum non-adjacent sum that can be robbed.</returns>
        public int Rob(int[] nums)
        {
            int previousTwo = 0, previousOne = 0;
            foreach (int num in nums)
            {
                int current = Math.Max(previousOne, previousTwo + num);
                previousTwo = previousOne;
                previousOne = current;
            }
            return previousOne;
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


        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-size-subarray-sum/">209. Minimum Size Subarray Sum (medium)</a>
        /// Given positive integers and a target, find the smallest length of a contiguous subarray whose sum is at least the target.
        /// </summary>
        /// <param name="target">The minimum required subarray sum.</param>
        /// <param name="nums">The positive integers to scan.</param>
        /// <returns>The minimum qualifying subarray length, or 0 when none exists.</returns>
        public int MinSubArrayLen(int target, int[] nums)
        {
            int left = 0, sum = 0, best = int.MaxValue;
            for (int right = 0; right < nums.Length; right++)
            {
                sum += nums[right];
                while (sum >= target)
                {
                    best = Math.Min(best, right - left + 1);
                    sum -= nums[left++];
                }
            }
            return best == int.MaxValue ? 0 : best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/kth-largest-element-in-an-array/">215. Kth Largest Element in an Array (medium)</a>
        /// Given an unsorted array, find the kth largest element in sorted order. This method uses quickselect in-place.
        /// </summary>
        /// <param name="nums">The values to select from.</param>
        /// <param name="k">The one-based rank from largest to smallest.</param>
        /// <returns>The kth largest value.</returns>
        public int FindKthLargest(int[] nums, int k)
        {
            int target = nums.Length - k;
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                int pivot = Partition(nums, left, right);
                if (pivot == target)
                    return nums[pivot];
                if (pivot < target)
                    left = pivot + 1;
                else
                    right = pivot - 1;
            }
            return -1;
        }

        private int Partition(int[] nums, int left, int right)
        {
            int mid = left + (right - left) / 2;
            (nums[mid], nums[right]) = (nums[right], nums[mid]);
            int pivot = nums[right];
            int store = left;
            for (int i = left; i < right; i++)
            {
                if (nums[i] < pivot)
                {
                    (nums[store], nums[i]) = (nums[i], nums[store]);
                    store++;
                }
            }
            (nums[store], nums[right]) = (nums[right], nums[store]);
            return store;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/contains-duplicate-ii/">219. Contains Duplicate II (easy)</a>
        /// Determine whether any equal values appear at indices whose distance is at most k.
        /// </summary>
        /// <param name="nums">The values to inspect.</param>
        /// <param name="k">The maximum allowed index distance.</param>
        /// <returns><see langword="true"/> if a nearby duplicate exists; otherwise, <see langword="false"/>.</returns>
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            var seen = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > k)
                    seen.Remove(nums[i - k - 1]);
                if (!seen.Add(nums[i]))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/contains-duplicate-iii/">220. Contains Duplicate III (hard)</a>
        /// Determine whether two distinct indices are within indexDiff positions and their values differ by at most valueDiff.
        /// </summary>
        /// <param name="nums">The values to inspect.</param>
        /// <param name="indexDiff">The maximum allowed index distance.</param>
        /// <param name="valueDiff">The maximum allowed value difference.</param>
        /// <returns><see langword="true"/> if such a pair exists; otherwise, <see langword="false"/>.</returns>
        public bool ContainsNearbyAlmostDuplicate(int[] nums, int indexDiff, int valueDiff)
        {
            if (indexDiff <= 0 || valueDiff < 0)
                return false;

            var buckets = new Dictionary<long, long>();
            long width = (long)valueDiff + 1;
            for (int i = 0; i < nums.Length; i++)
            {
                long value = nums[i];
                long bucket = GetBucketId(value, width);
                if (buckets.ContainsKey(bucket))
                    return true;
                if (buckets.TryGetValue(bucket - 1, out long left) && value - left <= valueDiff)
                    return true;
                if (buckets.TryGetValue(bucket + 1, out long right) && right - value <= valueDiff)
                    return true;

                buckets[bucket] = value;
                if (i >= indexDiff)
                    buckets.Remove(GetBucketId(nums[i - indexDiff], width));
            }
            return false;
        }

        private long GetBucketId(long value, long width)
        {
            return value >= 0 ? value / width : ((value + 1) / width) - 1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/summary-ranges/">228. Summary Ranges (easy)</a>
        /// Summarize sorted unique integers as the smallest list of consecutive ranges.
        /// </summary>
        /// <param name="nums">The sorted unique integers to summarize.</param>
        /// <returns>Range strings using either single values or start-&gt;end notation.</returns>
        public IList<string> SummaryRanges(int[] nums)
        {
            var result = new List<string>();
            for (int i = 0; i < nums.Length; i++)
            {
                int start = nums[i];
                while (i + 1 < nums.Length && nums[i + 1] == nums[i] + 1)
                    i++;
                result.Add(start == nums[i] ? start.ToString() : start + "->" + nums[i]);
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/majority-element-ii/">229. Majority Element II (medium)</a>
        /// Find all values that appear more than ⌊n / 3⌋ times in an integer array.
        /// </summary>
        /// <param name="nums">The values to inspect.</param>
        /// <returns>All elements appearing more than one third of the time.</returns>
        public IList<int> MajorityElementII(int[] nums)
        {
            int candidate1 = 0, candidate2 = 1, count1 = 0, count2 = 0;
            foreach (int num in nums)
            {
                if (num == candidate1)
                    count1++;
                else if (num == candidate2)
                    count2++;
                else if (count1 == 0)
                {
                    candidate1 = num;
                    count1 = 1;
                }
                else if (count2 == 0)
                {
                    candidate2 = num;
                    count2 = 1;
                }
                else
                {
                    count1--;
                    count2--;
                }
            }

            count1 = 0;
            count2 = 0;
            foreach (int num in nums)
            {
                if (num == candidate1)
                    count1++;
                else if (num == candidate2)
                    count2++;
            }

            var result = new List<int>();
            if (count1 > nums.Length / 3)
                result.Add(candidate1);
            if (count2 > nums.Length / 3)
                result.Add(candidate2);
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/sliding-window-maximum/">239. Sliding Window Maximum (hard)</a>
        /// Return the maximum value in every contiguous window of size k.
        /// </summary>
        /// <param name="nums">The values to scan.</param>
        /// <param name="k">The window size.</param>
        /// <returns>The maximum value for each window.</returns>
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums.Length == 0 || k == 0)
                return Array.Empty<int>();

            var result = new int[nums.Length - k + 1];
            var deque = new int[nums.Length];
            int head = 0, tail = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                while (head <= tail && deque[head] <= i - k)
                    head++;
                while (head <= tail && nums[deque[tail]] <= nums[i])
                    tail--;
                deque[++tail] = i;
                if (i >= k - 1)
                    result[i - k + 1] = nums[deque[head]];
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/search-a-2d-matrix-ii/">240. Search a 2D Matrix II (medium)</a>
        /// Search for a target in a matrix sorted ascending both left-to-right by row and top-to-bottom by column.
        /// </summary>
        /// <param name="matrix">The row- and column-sorted matrix.</param>
        /// <param name="target">The value to find.</param>
        /// <returns><see langword="true"/> if the value exists; otherwise, <see langword="false"/>.</returns>
        public bool SearchMatrixII(int[][] matrix, int target)
        {
            if (matrix.Length == 0 || matrix[0].Length == 0)
                return false;

            int row = 0, col = matrix[0].Length - 1;
            while (row < matrix.Length && col >= 0)
            {
                if (matrix[row][col] == target)
                    return true;
                if (matrix[row][col] > target)
                    col--;
                else
                    row++;
            }
            return false;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/missing-number/">268. Missing Number (easy)</a>
        /// Given distinct numbers from 0 through n with one missing, find the missing value.
        /// </summary>
        /// <param name="nums">The n distinct present values.</param>
        /// <returns>The value from 0 through n that is absent.</returns>
        public int MissingNumber(int[] nums)
        {
            int missing = nums.Length;
            for (int i = 0; i < nums.Length; i++)
                missing ^= i ^ nums[i];
            return missing;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/h-index/">274. H-Index (medium)</a>
        /// Compute the largest h such that at least h papers have at least h citations each.
        /// </summary>
        /// <param name="citations">The citation count for each paper.</param>
        /// <returns>The researcher's h-index.</returns>
        public int HIndex(int[] citations)
        {
            int n = citations.Length;
            var buckets = new int[n + 1];
            foreach (int citation in citations)
                buckets[Math.Min(citation, n)]++;

            int papers = 0;
            for (int h = n; h >= 0; h--)
            {
                papers += buckets[h];
                if (papers >= h)
                    return h;
            }
            return 0;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/h-index-ii/">275. H-Index II (medium)</a>
        /// Compute the h-index from citations sorted in ascending order.
        /// </summary>
        /// <param name="citations">The sorted citation counts.</param>
        /// <returns>The researcher's h-index.</returns>
        public int HIndexII(int[] citations)
        {
            int n = citations.Length;
            int left = 0, right = n - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (citations[mid] >= n - mid)
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            return n - left;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/move-zeroes/">283. Move Zeroes (easy)</a>
        /// Move all zeroes to the end of an array in-place while preserving the relative order of non-zero values.
        /// </summary>
        /// <param name="nums">The array to rearrange in-place.</param>
        public void MoveZeroes(int[] nums)
        {
            int write = 0;
            for (int read = 0; read < nums.Length; read++)
            {
                if (nums[read] != 0)
                    nums[write++] = nums[read];
            }
            while (write < nums.Length)
                nums[write++] = 0;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-the-duplicate-number/">287. Find the Duplicate Number (medium)</a>
        /// Find the repeated number in an array containing n + 1 values in the range 1 through n.
        /// </summary>
        /// <param name="nums">The values containing exactly one duplicate number.</param>
        /// <returns>The duplicate value.</returns>
        public int FindDuplicate(int[] nums)
        {
            int slow = nums[0], fast = nums[0];
            do
            {
                slow = nums[slow];
                fast = nums[nums[fast]];
            }
            while (slow != fast);

            slow = nums[0];
            while (slow != fast)
            {
                slow = nums[slow];
                fast = nums[fast];
            }
            return slow;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/game-of-life/">289. Game of Life (medium)</a>
        /// Advance Conway's Game of Life board by one generation in-place.
        /// </summary>
        /// <param name="board">The binary board to update in-place.</param>
        public void GameOfLife(int[][] board)
        {
            int rows = board.Length, cols = board[0].Length;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    int liveNeighbors = CountLiveNeighbors(board, row, col);
                    if (board[row][col] == 1 && (liveNeighbors == 2 || liveNeighbors == 3))
                        board[row][col] = 3;
                    if (board[row][col] == 0 && liveNeighbors == 3)
                        board[row][col] = 2;
                }
            }

            for (int row = 0; row < rows; row++)
                for (int col = 0; col < cols; col++)
                    board[row][col] >>= 1;
        }

        private int CountLiveNeighbors(int[][] board, int row, int col)
        {
            int count = 0;
            for (int dr = -1; dr <= 1; dr++)
            {
                for (int dc = -1; dc <= 1; dc++)
                {
                    if (dr == 0 && dc == 0)
                        continue;
                    int nr = row + dr, nc = col + dc;
                    if (nr >= 0 && nr < board.Length && nc >= 0 && nc < board[0].Length)
                        count += board[nr][nc] & 1;
                }
            }
            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/longest-increasing-subsequence/">300. Longest Increasing Subsequence (medium)</a>
        /// Find the length of the longest strictly increasing subsequence in an array.
        /// </summary>
        /// <param name="nums">The values to evaluate.</param>
        /// <returns>The length of the longest increasing subsequence.</returns>
        public int LengthOfLIS(int[] nums)
        {
            var tails = new int[nums.Length];
            int length = 0;
            foreach (int num in nums)
            {
                int left = 0, right = length;
                while (left < right)
                {
                    int mid = left + (right - left) / 2;
                    if (tails[mid] < num)
                        left = mid + 1;
                    else
                        right = mid;
                }
                tails[left] = num;
                if (left == length)
                    length++;
            }
            return length;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/increasing-triplet-subsequence/">334. Increasing Triplet Subsequence (medium)</a>
        /// Determine whether the array contains three indices i &lt; j &lt; k with strictly increasing values.
        /// </summary>
        /// <param name="nums">The values to scan.</param>
        /// <returns><see langword="true"/> if an increasing triplet exists; otherwise, <see langword="false"/>.</returns>
        public bool IncreasingTriplet(int[] nums)
        {
            int first = int.MaxValue, second = int.MaxValue;
            foreach (int num in nums)
            {
                if (num <= first)
                    first = num;
                else if (num <= second)
                    second = num;
                else
                    return true;
            }
            return false;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/intersection-of-two-arrays/">349. Intersection of Two Arrays (easy)</a>
        /// Return the unique values that appear in both input arrays.
        /// </summary>
        /// <param name="nums1">The first array.</param>
        /// <param name="nums2">The second array.</param>
        /// <returns>The distinct intersection values.</returns>
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            var set = new HashSet<int>(nums1);
            set.IntersectWith(nums2);
            return set.ToArray();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/intersection-of-two-arrays-ii/">350. Intersection of Two Arrays II (easy)</a>
        /// Return the intersection of two arrays including duplicate occurrences.
        /// </summary>
        /// <param name="nums1">The first array.</param>
        /// <param name="nums2">The second array.</param>
        /// <returns>The multiset intersection values.</returns>
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            if (nums1.Length > nums2.Length)
                return Intersect(nums2, nums1);

            var counts = new Dictionary<int, int>();
            foreach (int num in nums1)
                counts[num] = counts.GetValueOrDefault(num) + 1;

            var result = new List<int>();
            foreach (int num in nums2)
            {
                if (counts.TryGetValue(num, out int count) && count > 0)
                {
                    result.Add(num);
                    counts[num] = count - 1;
                }
            }
            return result.ToArray();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/rotate-function/">396. Rotate Function (medium)</a>
        /// Compute the maximum value of the rotation function over all rotations of an array.
        /// </summary>
        /// <param name="nums">The values used by the rotation function.</param>
        /// <returns>The maximum rotation function value.</returns>
        public int MaxRotateFunction(int[] nums)
        {
            long sum = 0, current = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                current += (long)i * nums[i];
            }

            long best = current;
            for (int k = 1; k < nums.Length; k++)
            {
                current = current + sum - (long)nums.Length * nums[nums.Length - k];
                best = Math.Max(best, current);
            }
            return (int)best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/third-maximum-number/">414. Third Maximum Number (easy)</a>
        /// Return the third distinct maximum number, or the maximum number when fewer than three distinct values exist.
        /// </summary>
        /// <param name="nums">The values to evaluate.</param>
        /// <returns>The third distinct maximum or overall maximum.</returns>
        public int ThirdMax(int[] nums)
        {
            long first = long.MinValue, second = long.MinValue, third = long.MinValue;
            foreach (int num in nums)
            {
                if (num == first || num == second || num == third)
                    continue;
                if (num > first)
                {
                    third = second;
                    second = first;
                    first = num;
                }
                else if (num > second)
                {
                    third = second;
                    second = num;
                }
                else if (num > third)
                {
                    third = num;
                }
            }
            return third == long.MinValue ? (int)first : (int)third;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/">448. Find All Numbers Disappeared in an Array (easy)</a>
        /// Find all values in the range 1 through n that do not appear in an array of length n.
        /// </summary>
        /// <param name="nums">The array whose values are in the range 1 through n.</param>
        /// <returns>The missing values from 1 through n.</returns>
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                int index = Math.Abs(nums[i]) - 1;
                if (nums[index] > 0)
                    nums[index] = -nums[index];
            }

            var result = new List<int>();
            for (int i = 0; i < nums.Length; i++)
                if (nums[i] > 0)
                    result.Add(i + 1);
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/max-consecutive-ones/">485. Max Consecutive Ones (easy)</a>
        /// Find the longest contiguous run of 1s in a binary array.
        /// </summary>
        /// <param name="nums">The binary values to scan.</param>
        /// <returns>The maximum number of consecutive 1s.</returns>
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int current = 0, best = 0;
            foreach (int num in nums)
            {
                current = num == 1 ? current + 1 : 0;
                best = Math.Max(best, current);
            }
            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/diagonal-traverse/">498. Diagonal Traverse (medium)</a>
        /// Return all matrix elements in zigzag diagonal order.
        /// </summary>
        /// <param name="mat">The matrix to traverse.</param>
        /// <returns>The values in diagonal traversal order.</returns>
        public int[] FindDiagonalOrder(int[][] mat)
        {
            if (mat.Length == 0 || mat[0].Length == 0)
                return Array.Empty<int>();

            int rows = mat.Length, cols = mat[0].Length;
            var result = new int[rows * cols];
            int row = 0, col = 0;
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = mat[row][col];
                if ((row + col) % 2 == 0)
                {
                    if (col == cols - 1)
                        row++;
                    else if (row == 0)
                        col++;
                    else
                    {
                        row--;
                        col++;
                    }
                }
                else
                {
                    if (row == rows - 1)
                        col++;
                    else if (col == 0)
                        row++;
                    else
                    {
                        row++;
                        col--;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/subarray-sum-equals-k/">560. Subarray Sum Equals K (medium)</a>
        /// Count contiguous subarrays whose values sum to k.
        /// </summary>
        /// <param name="nums">The values to scan.</param>
        /// <param name="k">The target subarray sum.</param>
        /// <returns>The number of subarrays summing to <paramref name="k"/>.</returns>
        public int SubarraySum(int[] nums, int k)
        {
            var prefixCounts = new Dictionary<int, int> { [0] = 1 };
            int prefix = 0, result = 0;
            foreach (int num in nums)
            {
                prefix += num;
                result += prefixCounts.GetValueOrDefault(prefix - k);
                prefixCounts[prefix] = prefixCounts.GetValueOrDefault(prefix) + 1;
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/reshape-the-matrix/">566. Reshape the Matrix (easy)</a>
        /// Reshape a matrix to the requested dimensions while preserving row-major order when possible.
        /// </summary>
        /// <param name="mat">The source matrix.</param>
        /// <param name="r">The requested row count.</param>
        /// <param name="c">The requested column count.</param>
        /// <returns>The reshaped matrix, or the original matrix when dimensions are incompatible.</returns>
        public int[][] MatrixReshape(int[][] mat, int r, int c)
        {
            int rows = mat.Length, cols = mat[0].Length;
            if (rows * cols != r * c)
                return mat;

            var result = new int[r][];
            for (int i = 0; i < r; i++)
                result[i] = new int[c];

            for (int i = 0; i < rows * cols; i++)
                result[i / c][i % c] = mat[i / cols][i % cols];
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/shortest-unsorted-continuous-subarray/">581. Shortest Unsorted Continuous Subarray (medium)</a>
        /// Find the shortest continuous subarray that must be sorted so the whole array becomes sorted.
        /// </summary>
        /// <param name="nums">The values to inspect.</param>
        /// <returns>The length of the shortest unsorted subarray, or 0 if already sorted.</returns>
        public int FindUnsortedSubarray(int[] nums)
        {
            int n = nums.Length;
            int end = -1, start = 0;
            int maxSeen = int.MinValue, minSeen = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                maxSeen = Math.Max(maxSeen, nums[i]);
                if (nums[i] < maxSeen)
                    end = i;

                int j = n - 1 - i;
                minSeen = Math.Min(minSeen, nums[j]);
                if (nums[j] > minSeen)
                    start = j;
            }
            return end == -1 ? 0 : end - start + 1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-average-subarray-i/">643. Maximum Average Subarray I (easy)</a>
        /// Find the maximum average among all contiguous subarrays of length k.
        /// </summary>
        /// <param name="nums">The values to scan.</param>
        /// <param name="k">The required subarray length.</param>
        /// <returns>The largest average value.</returns>
        public double FindMaxAverage(int[] nums, int k)
        {
            int sum = 0;
            for (int i = 0; i < k; i++)
                sum += nums[i];

            int best = sum;
            for (int i = k; i < nums.Length; i++)
            {
                sum += nums[i] - nums[i - k];
                best = Math.Max(best, sum);
            }
            return (double)best / k;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/image-smoother/">661. Image Smoother (easy)</a>
        /// Replace every image cell with the floor of the average of itself and valid neighboring cells.
        /// </summary>
        /// <param name="img">The image grid.</param>
        /// <returns>The smoothed image grid.</returns>
        public int[][] ImageSmoother(int[][] img)
        {
            int rows = img.Length, cols = img[0].Length;
            var result = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                result[row] = new int[cols];
                for (int col = 0; col < cols; col++)
                {
                    int sum = 0, count = 0;
                    for (int dr = -1; dr <= 1; dr++)
                    {
                        for (int dc = -1; dc <= 1; dc++)
                        {
                            int nr = row + dr, nc = col + dc;
                            if (nr >= 0 && nr < rows && nc >= 0 && nc < cols)
                            {
                                sum += img[nr][nc];
                                count++;
                            }
                        }
                    }
                    result[row][col] = sum / count;
                }
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/non-decreasing-array/">665. Non-decreasing Array (medium)</a>
        /// Determine whether an array can become non-decreasing by modifying at most one element.
        /// </summary>
        /// <param name="nums">The values to inspect.</param>
        /// <returns><see langword="true"/> if at most one change can make the array non-decreasing; otherwise, <see langword="false"/>.</returns>
        public bool CheckPossibility(int[] nums)
        {
            int changes = 0;
            for (int i = 1; i < nums.Length && changes <= 1; i++)
            {
                if (nums[i - 1] <= nums[i])
                    continue;

                changes++;
                if (i < 2 || nums[i - 2] <= nums[i])
                    nums[i - 1] = nums[i];
                else
                    nums[i] = nums[i - 1];
            }
            return changes <= 1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/longest-continuous-increasing-subsequence/">674. Longest Continuous Increasing Subsequence (easy)</a>
        /// Find the length of the longest contiguous strictly increasing segment.
        /// </summary>
        /// <param name="nums">The values to scan.</param>
        /// <returns>The longest continuous increasing subsequence length.</returns>
        public int FindLengthOfLCIS(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            int current = 1, best = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                current = nums[i] > nums[i - 1] ? current + 1 : 1;
                best = Math.Max(best, current);
            }
            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/degree-of-an-array/">697. Degree of an Array (easy)</a>
        /// Find the shortest contiguous subarray with the same degree as the full array.
        /// </summary>
        /// <param name="nums">The values to inspect.</param>
        /// <returns>The length of the shortest subarray matching the array degree.</returns>
        public int FindShortestSubArray(int[] nums)
        {
            var counts = new Dictionary<int, int>();
            var firstIndex = new Dictionary<int, int>();
            int degree = 0, best = nums.Length;
            for (int i = 0; i < nums.Length; i++)
            {
                if (!firstIndex.ContainsKey(nums[i]))
                    firstIndex[nums[i]] = i;
                counts[nums[i]] = counts.GetValueOrDefault(nums[i]) + 1;
                if (counts[nums[i]] > degree)
                {
                    degree = counts[nums[i]];
                    best = i - firstIndex[nums[i]] + 1;
                }
                else if (counts[nums[i]] == degree)
                {
                    best = Math.Min(best, i - firstIndex[nums[i]] + 1);
                }
            }
            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/binary-search/">704. Binary Search (easy)</a>
        /// Given a sorted array, find the target index using binary search.
        /// </summary>
        /// <param name="nums">The ascending sorted values to search.</param>
        /// <param name="target">The value to locate.</param>
        /// <returns>The target index, or -1 when absent.</returns>
        public int Search704(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    return mid;
                if (nums[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return -1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/subarray-product-less-than-k/">713. Subarray Product Less Than K (medium)</a>
        /// Count contiguous subarrays whose product is strictly less than k.
        /// </summary>
        /// <param name="nums">The positive integers to scan.</param>
        /// <param name="k">The exclusive product limit.</param>
        /// <returns>The number of qualifying contiguous subarrays.</returns>
        public int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            if (k <= 1)
                return 0;

            int left = 0, count = 0;
            long product = 1;
            for (int right = 0; right < nums.Length; right++)
            {
                product *= nums[right];
                while (product >= k)
                    product /= nums[left++];
                count += right - left + 1;
            }
            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-transaction-fee/">714. Best Time to Buy and Sell Stock with Transaction Fee (medium)</a>
        /// Given daily prices and a fixed transaction fee, maximize profit with any number of transactions.
        /// </summary>
        /// <param name="prices">The stock price on each day.</param>
        /// <param name="fee">The fee paid for each completed transaction.</param>
        /// <returns>The maximum profit after transaction fees.</returns>
        public int MaxProfit(int[] prices, int fee)
        {
            int cash = 0, hold = -prices[0];
            for (int i = 1; i < prices.Length; i++)
            {
                cash = Math.Max(cash, hold + prices[i] - fee);
                hold = Math.Max(hold, cash - prices[i]);
            }
            return cash;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-length-of-repeated-subarray/">718. Maximum Length of Repeated Subarray (medium)</a>
        /// Find the length of the longest contiguous subarray appearing in both arrays.
        /// </summary>
        /// <param name="nums1">The first array.</param>
        /// <param name="nums2">The second array.</param>
        /// <returns>The maximum common subarray length.</returns>
        public int FindLength(int[] nums1, int[] nums2)
        {
            var dp = new int[nums2.Length + 1];
            int best = 0;
            for (int i = 1; i <= nums1.Length; i++)
            {
                for (int j = nums2.Length; j >= 1; j--)
                {
                    dp[j] = nums1[i - 1] == nums2[j - 1] ? dp[j - 1] + 1 : 0;
                    best = Math.Max(best, dp[j]);
                }
            }
            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-pivot-index/">724. Find Pivot Index (easy)</a>
        /// Find an index where the sum of values to its left equals the sum of values to its right.
        /// </summary>
        /// <param name="nums">The values to inspect.</param>
        /// <returns>The leftmost pivot index, or -1 when none exists.</returns>
        public int PivotIndex(int[] nums)
        {
            int total = nums.Sum();
            int left = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (left == total - left - nums[i])
                    return i;
                left += nums[i];
            }
            return -1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/asteroid-collision/">735. Asteroid Collision (medium)</a>
        /// Simulate collisions between moving asteroids and return the surviving asteroids.
        /// </summary>
        /// <param name="asteroids">Positive values move right and negative values move left.</param>
        /// <returns>The asteroid values remaining after all collisions.</returns>
        public int[] AsteroidCollision(int[] asteroids)
        {
            var stack = new Stack<int>();
            foreach (int asteroid in asteroids)
            {
                bool alive = true;
                while (alive && asteroid < 0 && stack.Count > 0 && stack.Peek() > 0)
                {
                    int top = stack.Peek();
                    if (top < -asteroid)
                        stack.Pop();
                    else
                    {
                        if (top == -asteroid)
                            stack.Pop();
                        alive = false;
                    }
                }
                if (alive)
                    stack.Push(asteroid);
            }
            return stack.Reverse().ToArray();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/daily-temperatures/">739. Daily Temperatures (medium)</a>
        /// For each day, find how many days must pass until a warmer temperature.
        /// </summary>
        /// <param name="temperatures">The daily temperatures.</param>
        /// <returns>An array of waits for warmer days, or 0 when no warmer day exists.</returns>
        public int[] DailyTemperatures(int[] temperatures)
        {
            var result = new int[temperatures.Length];
            var stack = new Stack<int>();
            for (int i = 0; i < temperatures.Length; i++)
            {
                while (stack.Count > 0 && temperatures[i] > temperatures[stack.Peek()])
                {
                    int previous = stack.Pop();
                    result[previous] = i - previous;
                }
                stack.Push(i);
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/min-cost-climbing-stairs/">746. Min Cost Climbing Stairs (easy)</a>
        /// Find the minimum cost to reach the top when each move climbs one or two steps.
        /// </summary>
        /// <param name="cost">The cost paid when stepping on each stair.</param>
        /// <returns>The minimum total cost to reach beyond the last stair.</returns>
        public int MinCostClimbingStairs(int[] cost)
        {
            int prev2 = 0, prev1 = 0;
            for (int i = 2; i <= cost.Length; i++)
            {
                int current = Math.Min(prev1 + cost[i - 1], prev2 + cost[i - 2]);
                prev2 = prev1;
                prev1 = current;
            }
            return prev1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/largest-number-at-least-twice-of-others/">747. Largest Number At Least Twice of Others (easy)</a>
        /// Determine whether the largest element is at least twice every other element.
        /// </summary>
        /// <param name="nums">The non-negative values to inspect.</param>
        /// <returns>The index of the dominant largest value, or -1 when it is not dominant.</returns>
        public int DominantIndex(int[] nums)
        {
            int largest = -1, second = -1, index = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > largest)
                {
                    second = largest;
                    largest = nums[i];
                    index = i;
                }
                else if (nums[i] > second)
                {
                    second = nums[i];
                }
            }
            return largest >= 2 * second ? index : -1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/toeplitz-matrix/">766. Toeplitz Matrix (easy)</a>
        /// Check whether every diagonal from top-left to bottom-right contains the same value.
        /// </summary>
        /// <param name="matrix">The matrix to inspect.</param>
        /// <returns><see langword="true"/> when the matrix is Toeplitz; otherwise, <see langword="false"/>.</returns>
        public bool IsToeplitzMatrix(int[][] matrix)
        {
            for (int r = 1; r < matrix.Length; r++)
            {
                for (int c = 1; c < matrix[0].Length; c++)
                {
                    if (matrix[r][c] != matrix[r - 1][c - 1])
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/number-of-subarrays-with-bounded-maximum/">795. Number of Subarrays with Bounded Maximum (medium)</a>
        /// Count subarrays whose maximum value lies between the provided bounds.
        /// </summary>
        /// <param name="nums">The values to scan.</param>
        /// <param name="left">The minimum allowed subarray maximum.</param>
        /// <param name="right">The maximum allowed subarray maximum.</param>
        /// <returns>The number of subarrays with bounded maximum.</returns>
        public int NumSubarrayBoundedMax(int[] nums, int left, int right)
        {
            return CountSubarraysWithMaxAtMost(nums, right) - CountSubarraysWithMaxAtMost(nums, left - 1);
        }

        private int CountSubarraysWithMaxAtMost(int[] nums, int bound)
        {
            int current = 0, total = 0;
            foreach (int num in nums)
            {
                current = num <= bound ? current + 1 : 0;
                total += current;
            }
            return total;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/flipping-an-image/">832. Flipping an Image (easy)</a>
        /// Flip each binary image row horizontally and invert every bit.
        /// </summary>
        /// <param name="image">The binary image to transform in-place.</param>
        /// <returns>The flipped and inverted image.</returns>
        public int[][] FlipAndInvertImage(int[][] image)
        {
            foreach (var row in image)
            {
                int left = 0, right = row.Length - 1;
                while (left <= right)
                {
                    int leftValue = row[left] ^ 1;
                    int rightValue = row[right] ^ 1;
                    row[left++] = rightValue;
                    row[right--] = leftValue;
                }
            }
            return image;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximize-distance-to-closest-person/">849. Maximize Distance to Closest Person (medium)</a>
        /// Find the seat maximizing distance to the closest occupied seat.
        /// </summary>
        /// <param name="seats">The row of seats, where 1 is occupied and 0 is empty.</param>
        /// <returns>The greatest possible distance to the closest occupied seat.</returns>
        public int MaxDistToClosest(int[] seats)
        {
            int previous = -1, best = 0;
            for (int i = 0; i < seats.Length; i++)
            {
                if (seats[i] == 0)
                    continue;
                best = previous < 0 ? i : Math.Max(best, (i - previous) / 2);
                previous = i;
            }
            return Math.Max(best, seats.Length - 1 - previous);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/peak-index-in-a-mountain-array/">852. Peak Index in a Mountain Array (medium)</a>
        /// Find the peak index in a mountain array.
        /// </summary>
        /// <param name="arr">The mountain array to search.</param>
        /// <returns>The index of the peak value.</returns>
        public int PeakIndexInMountainArray(int[] arr)
        {
            int left = 0, right = arr.Length - 1;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] < arr[mid + 1])
                    left = mid + 1;
                else
                    right = mid;
            }
            return left;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/koko-eating-bananas/">875. Koko Eating Bananas (medium)</a>
        /// Find the minimum integer eating speed that finishes all piles within h hours.
        /// </summary>
        /// <param name="piles">The banana piles.</param>
        /// <param name="h">The maximum hours available.</param>
        /// <returns>The minimum feasible bananas-per-hour speed.</returns>
        public int MinEatingSpeed(int[] piles, int h)
        {
            int left = 1, right = piles.Max();
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                long hours = 0;
                foreach (int pile in piles)
                    hours += (pile + mid - 1) / mid;
                if (hours <= h)
                    right = mid;
                else
                    left = mid + 1;
            }
            return left;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/boats-to-save-people/">881. Boats to Save People (medium)</a>
        /// Pair people greedily to minimize rescue boats subject to a boat weight limit.
        /// </summary>
        /// <param name="people">The people's weights.</param>
        /// <param name="limit">The maximum weight each boat can carry.</param>
        /// <returns>The minimum number of boats required.</returns>
        public int NumRescueBoats(int[] people, int limit)
        {
            Array.Sort(people);
            int left = 0, right = people.Length - 1, boats = 0;
            while (left <= right)
            {
                if (people[left] + people[right] <= limit)
                    left++;
                right--;
                boats++;
            }
            return boats;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/monotonic-array/">896. Monotonic Array (easy)</a>
        /// Determine whether an array is entirely non-decreasing or non-increasing.
        /// </summary>
        /// <param name="nums">The values to inspect.</param>
        /// <returns><see langword="true"/> when the array is monotonic; otherwise, <see langword="false"/>.</returns>
        public bool IsMonotonic(int[] nums)
        {
            bool increasing = true, decreasing = true;
            for (int i = 1; i < nums.Length; i++)
            {
                increasing &= nums[i - 1] <= nums[i];
                decreasing &= nums[i - 1] >= nums[i];
            }
            return increasing || decreasing;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/sort-array-by-parity/">905. Sort Array By Parity (easy)</a>
        /// Reorder an array so even values appear before odd values.
        /// </summary>
        /// <param name="nums">The values to reorder.</param>
        /// <returns>The same array with evens before odds.</returns>
        public int[] SortArrayByParity(int[] nums)
        {
            int left = 0, right = nums.Length - 1;
            while (left < right)
            {
                if (nums[left] % 2 <= nums[right] % 2)
                    left++;
                else
                    (nums[left], nums[right]) = (nums[right], nums[left]);
                if (nums[right] % 2 == 1)
                    right--;
            }
            return nums;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-sum-circular-subarray/">918. Maximum Sum Circular Subarray (medium)</a>
        /// Find the maximum non-empty subarray sum in a circular array.
        /// </summary>
        /// <param name="nums">The circular array values.</param>
        /// <returns>The maximum circular subarray sum.</returns>
        public int MaxSubarraySumCircular(int[] nums)
        {
            int total = 0, maxEnding = 0, maxSum = nums[0], minEnding = 0, minSum = nums[0];
            foreach (int num in nums)
            {
                maxEnding = Math.Max(num, maxEnding + num);
                maxSum = Math.Max(maxSum, maxEnding);
                minEnding = Math.Min(num, minEnding + num);
                minSum = Math.Min(minSum, minEnding);
                total += num;
            }
            return maxSum < 0 ? maxSum : Math.Max(maxSum, total - minSum);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/valid-mountain-array/">941. Valid Mountain Array (easy)</a>
        /// Determine whether the array strictly increases to one peak and then strictly decreases.
        /// </summary>
        /// <param name="arr">The values to inspect.</param>
        /// <returns><see langword="true"/> when the values form a valid mountain; otherwise, <see langword="false"/>.</returns>
        public bool ValidMountainArray(int[] arr)
        {
            int i = 0;
            while (i + 1 < arr.Length && arr[i] < arr[i + 1])
                i++;
            if (i == 0 || i == arr.Length - 1)
                return false;
            while (i + 1 < arr.Length && arr[i] > arr[i + 1])
                i++;
            return i == arr.Length - 1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/k-closest-points-to-origin/">973. K Closest Points to Origin (medium)</a>
        /// Return the k points closest to the origin by squared Euclidean distance.
        /// </summary>
        /// <param name="points">The points as [x, y] pairs.</param>
        /// <param name="k">The number of closest points to return.</param>
        /// <returns>The k closest points to the origin.</returns>
        public int[][] KClosest(int[][] points, int k)
        {
            return points
                .OrderBy(point => (long)point[0] * point[0] + (long)point[1] * point[1])
                .Take(k)
                .Select(point => new[] { point[0], point[1] })
                .ToArray();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/squares-of-a-sorted-array/">977. Squares of a Sorted Array (easy)</a>
        /// Square each sorted input value and return the squares in non-decreasing order.
        /// </summary>
        /// <param name="nums">The non-decreasing sorted values.</param>
        /// <returns>The sorted squares of <paramref name="nums"/>.</returns>
        public int[] SortedSquares(int[] nums)
        {
            var result = new int[nums.Length];
            int left = 0, right = nums.Length - 1;
            for (int index = nums.Length - 1; index >= 0; index--)
            {
                if (Math.Abs(nums[left]) > Math.Abs(nums[right]))
                {
                    result[index] = nums[left] * nums[left];
                    left++;
                }
                else
                {
                    result[index] = nums[right] * nums[right];
                    right--;
                }
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/interval-list-intersections/">986. Interval List Intersections (medium)</a>
        /// Find every intersection between two sorted disjoint interval lists.
        /// </summary>
        /// <param name="firstList">The first sorted disjoint interval list.</param>
        /// <param name="secondList">The second sorted disjoint interval list.</param>
        /// <returns>All interval intersections in ascending order.</returns>
        public int[][] IntervalIntersection(int[][] firstList, int[][] secondList)
        {
            var result = new List<int[]>();
            int i = 0, j = 0;
            while (i < firstList.Length && j < secondList.Length)
            {
                int start = Math.Max(firstList[i][0], secondList[j][0]);
                int end = Math.Min(firstList[i][1], secondList[j][1]);
                if (start <= end)
                    result.Add(new[] { start, end });
                if (firstList[i][1] < secondList[j][1])
                    i++;
                else
                    j++;
            }
            return result.ToArray();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/pairs-of-songs-with-total-durations-divisible-by-60/">1010. Pairs of Songs With Total Durations Divisible by 60 (medium)</a>
        /// Count song pairs whose total duration is divisible by 60.
        /// </summary>
        /// <param name="time">The song durations in seconds.</param>
        /// <returns>The number of duration pairs divisible by 60.</returns>
        public int NumPairsDivisibleBy60(int[] time)
        {
            var remainders = new int[60];
            int pairs = 0;
            foreach (int duration in time)
            {
                int remainder = duration % 60;
                pairs += remainders[(60 - remainder) % 60];
                remainders[remainder]++;
            }
            return pairs;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/capacity-to-ship-packages-within-d-days/">1011. Capacity To Ship Packages Within D Days (medium)</a>
        /// Find the minimum ship capacity needed to ship packages in order within the given days.
        /// </summary>
        /// <param name="weights">The package weights in shipping order.</param>
        /// <param name="days">The maximum number of shipping days.</param>
        /// <returns>The minimum feasible ship capacity.</returns>
        public int ShipWithinDays(int[] weights, int days)
        {
            int left = weights.Max(), right = weights.Sum();
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                int usedDays = 1, current = 0;
                foreach (int weight in weights)
                {
                    if (current + weight > mid)
                    {
                        usedDays++;
                        current = 0;
                    }
                    current += weight;
                }
                if (usedDays <= days)
                    right = mid;
                else
                    left = mid + 1;
            }
            return left;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/last-stone-weight/">1046. Last Stone Weight (easy)</a>
        /// Repeatedly smash the two heaviest stones and return the final remaining weight.
        /// </summary>
        /// <param name="stones">The stone weights.</param>
        /// <returns>The final stone weight, or 0 when none remain.</returns>
        public int LastStoneWeight(int[] stones)
        {
            var queue = new PriorityQueue<int, int>();
            foreach (int stone in stones)
                queue.Enqueue(stone, -stone);
            while (queue.Count > 1)
            {
                int first = queue.Dequeue();
                int second = queue.Dequeue();
                if (first != second)
                    queue.Enqueue(first - second, second - first);
            }
            return queue.Count == 0 ? 0 : queue.Dequeue();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/height-checker/">1051. Height Checker (easy)</a>
        /// Count positions where the current heights differ from non-decreasing sorted order.
        /// </summary>
        /// <param name="heights">The current student heights.</param>
        /// <returns>The number of indices not matching sorted order.</returns>
        public int HeightChecker(int[] heights)
        {
            var expected = heights.OrderBy(height => height).ToArray();
            int count = 0;
            for (int i = 0; i < heights.Length; i++)
            {
                if (heights[i] != expected[i])
                    count++;
            }
            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/grumpy-bookstore-owner/">1052. Grumpy Bookstore Owner (medium)</a>
        /// Maximize satisfied customers by choosing one window where the owner suppresses grumpiness.
        /// </summary>
        /// <param name="customers">The customer count each minute.</param>
        /// <param name="grumpy">Whether the owner is grumpy each minute.</param>
        /// <param name="minutes">The length of the grumpiness-suppression window.</param>
        /// <returns>The maximum number of satisfied customers.</returns>
        public int MaxSatisfied(int[] customers, int[] grumpy, int minutes)
        {
            int baseline = 0, extra = 0, bestExtra = 0;
            for (int i = 0; i < customers.Length; i++)
            {
                if (grumpy[i] == 0)
                    baseline += customers[i];
                else
                    extra += customers[i];

                if (i >= minutes && grumpy[i - minutes] == 1)
                    extra -= customers[i - minutes];
                bestExtra = Math.Max(bestExtra, extra);
            }
            return baseline + bestExtra;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/duplicate-zeros/">1089. Duplicate Zeros (easy)</a>
        /// Duplicate each zero in-place while keeping the array length unchanged.
        /// </summary>
        /// <param name="arr">The array to mutate in-place.</param>
        public void DuplicateZeros(int[] arr)
        {
            int zeros = arr.Count(value => value == 0);
            for (int i = arr.Length - 1, write = arr.Length + zeros - 1; i >= 0; i--, write--)
            {
                if (write < arr.Length)
                    arr[write] = arr[i];
                if (arr[i] == 0)
                {
                    write--;
                    if (write < arr.Length)
                        arr[write] = 0;
                }
            }
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/car-pooling/">1094. Car Pooling (medium)</a>
        /// Determine whether all trips can be served without exceeding vehicle capacity.
        /// </summary>
        /// <param name="trips">Trips as [passengers, start, end].</param>
        /// <param name="capacity">The maximum passengers in the vehicle.</param>
        /// <returns><see langword="true"/> when capacity is never exceeded; otherwise, <see langword="false"/>.</returns>
        public bool CarPooling(int[][] trips, int capacity)
        {
            int last = trips.Max(trip => trip[2]);
            var delta = new int[last + 1];
            foreach (var trip in trips)
            {
                delta[trip[1]] += trip[0];
                delta[trip[2]] -= trip[0];
            }
            int passengers = 0;
            foreach (int change in delta)
            {
                passengers += change;
                if (passengers > capacity)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/relative-sort-array/">1122. Relative Sort Array (easy)</a>
        /// Sort one array so values listed in another array come first in that order, then remaining values ascend.
        /// </summary>
        /// <param name="arr1">The values to sort.</param>
        /// <param name="arr2">The priority order for distinct values in <paramref name="arr1"/>.</param>
        /// <returns>The relatively sorted array.</returns>
        public int[] RelativeSortArray(int[] arr1, int[] arr2)
        {
            var counts = new SortedDictionary<int, int>();
            foreach (int num in arr1)
                counts[num] = counts.GetValueOrDefault(num) + 1;

            int index = 0;
            foreach (int num in arr2)
            {
                while (counts[num]-- > 0)
                    arr1[index++] = num;
                counts.Remove(num);
            }

            foreach (var pair in counts)
            {
                for (int i = 0; i < pair.Value; i++)
                    arr1[index++] = pair.Key;
            }
            return arr1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-absolute-difference/">1200. Minimum Absolute Difference (easy)</a>
        /// Return all pairs with the minimum absolute difference after sorting the array.
        /// </summary>
        /// <param name="arr">The distinct integers to compare.</param>
        /// <returns>All adjacent sorted pairs with the minimum difference.</returns>
        public IList<IList<int>> MinimumAbsDifference(int[] arr)
        {
            Array.Sort(arr);
            int best = int.MaxValue;
            var result = new List<IList<int>>();
            for (int i = 1; i < arr.Length; i++)
            {
                int difference = arr[i] - arr[i - 1];
                if (difference < best)
                {
                    best = difference;
                    result.Clear();
                }
                if (difference == best)
                    result.Add(new List<int> { arr[i - 1], arr[i] });
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/unique-number-of-occurrences/">1207. Unique Number of Occurrences (easy)</a>
        /// Check whether all distinct values have unique occurrence counts.
        /// </summary>
        /// <param name="arr">The values to inspect.</param>
        /// <returns><see langword="true"/> when every frequency is unique; otherwise, <see langword="false"/>.</returns>
        public bool UniqueOccurrences(int[] arr)
        {
            var counts = arr.GroupBy(num => num).Select(group => group.Count());
            return counts.Count() == counts.Distinct().Count();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-time-visiting-all-points/">1266. Minimum Time Visiting All Points (easy)</a>
        /// Compute the minimum king-move time needed to visit all points in order.
        /// </summary>
        /// <param name="points">The points as [x, y] pairs.</param>
        /// <returns>The minimum time to visit each point in order.</returns>
        public int MinTimeToVisitAllPoints(int[][] points)
        {
            int time = 0;
            for (int i = 1; i < points.Length; i++)
                time += Math.Max(Math.Abs(points[i][0] - points[i - 1][0]), Math.Abs(points[i][1] - points[i - 1][1]));
            return time;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/replace-elements-with-greatest-element-on-right-side/">1299. Replace Elements with Greatest Element on Right Side (easy)</a>
        /// Replace each element by the greatest element to its right and put -1 at the end.
        /// </summary>
        /// <param name="arr">The array to transform in-place.</param>
        /// <returns>The transformed array.</returns>
        public int[] ReplaceElements(int[] arr)
        {
            int best = -1;
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                int current = arr[i];
                arr[i] = best;
                best = Math.Max(best, current);
            }
            return arr;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/the-k-weakest-rows-in-a-matrix/">1337. The K Weakest Rows in a Matrix (easy)</a>
        /// Return the k row indices with the fewest soldiers, breaking ties by row index.
        /// </summary>
        /// <param name="mat">The binary rows with soldiers before civilians.</param>
        /// <param name="k">The number of weakest rows to return.</param>
        /// <returns>The indices of the k weakest rows.</returns>
        public int[] KWeakestRows(int[][] mat, int k)
        {
            return mat.Select((row, index) => (soldiers: CountSoldiers(row), index))
                .OrderBy(item => item.soldiers)
                .ThenBy(item => item.index)
                .Take(k)
                .Select(item => item.index)
                .ToArray();
        }

        private int CountSoldiers(int[] row)
        {
            int left = 0, right = row.Length;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (row[mid] == 1)
                    left = mid + 1;
                else
                    right = mid;
            }
            return left;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/check-if-n-and-its-double-exist/">1346. Check If N and Its Double Exist (easy)</a>
        /// Determine whether two distinct elements exist where one is double the other.
        /// </summary>
        /// <param name="arr">The values to inspect.</param>
        /// <returns><see langword="true"/> when such a pair exists; otherwise, <see langword="false"/>.</returns>
        public bool CheckIfExist(int[] arr)
        {
            var seen = new HashSet<int>();
            foreach (int num in arr)
            {
                if (seen.Contains(num * 2) || (num % 2 == 0 && seen.Contains(num / 2)))
                    return true;
                seen.Add(num);
            }
            return false;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-negative-numbers-in-a-sorted-matrix/">1351. Count Negative Numbers in a Sorted Matrix (easy)</a>
        /// Count negative numbers in a matrix sorted non-increasingly by rows and columns.
        /// </summary>
        /// <param name="grid">The row- and column-sorted matrix.</param>
        /// <returns>The count of negative values.</returns>
        public int CountNegatives(int[][] grid)
        {
            int row = grid.Length - 1, col = 0, count = 0;
            while (row >= 0 && col < grid[0].Length)
            {
                if (grid[row][col] < 0)
                {
                    count += grid[0].Length - col;
                    row--;
                }
                else
                {
                    col++;
                }
            }
            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-points-you-can-obtain-from-cards/">1423. Maximum Points You Can Obtain from Cards (medium)</a>
        /// Choose k cards from either end to maximize total points.
        /// </summary>
        /// <param name="cardPoints">The card point values.</param>
        /// <param name="k">The number of cards to take.</param>
        /// <returns>The maximum obtainable score.</returns>
        public int MaxScore(int[] cardPoints, int k)
        {
            int total = cardPoints.Sum();
            int windowLength = cardPoints.Length - k;
            if (windowLength == 0)
                return total;

            int window = 0;
            for (int i = 0; i < windowLength; i++)
                window += cardPoints[i];
            int minWindow = window;
            for (int i = windowLength; i < cardPoints.Length; i++)
            {
                window += cardPoints[i] - cardPoints[i - windowLength];
                minWindow = Math.Min(minWindow, window);
            }
            return total - minWindow;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/shuffle-the-array/">1470. Shuffle the Array (easy)</a>
        /// Interleave the first n values and last n values of an array.
        /// </summary>
        /// <param name="nums">The array [x1..xn,y1..yn].</param>
        /// <param name="n">The number of x and y values.</param>
        /// <returns>The shuffled array [x1,y1,...,xn,yn].</returns>
        public int[] Shuffle(int[] nums, int n)
        {
            var result = new int[nums.Length];
            for (int i = 0; i < n; i++)
            {
                result[2 * i] = nums[i];
                result[2 * i + 1] = nums[i + n];
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/final-prices-with-a-special-discount-in-a-shop/">1475. Final Prices With a Special Discount in a Shop (easy)</a>
        /// Subtract from each price the first following price that is less than or equal to it.
        /// </summary>
        /// <param name="prices">The item prices.</param>
        /// <returns>The final prices after discounts.</returns>
        public int[] FinalPrices(int[] prices)
        {
            var result = (int[])prices.Clone();
            var stack = new Stack<int>();
            for (int i = 0; i < prices.Length; i++)
            {
                while (stack.Count > 0 && prices[stack.Peek()] >= prices[i])
                    result[stack.Pop()] -= prices[i];
                stack.Push(i);
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/running-sum-of-1d-array/">1480. Running Sum of 1d Array (easy)</a>
        /// Convert an array into its running prefix sums.
        /// </summary>
        /// <param name="nums">The values to accumulate in-place.</param>
        /// <returns>The running sum array.</returns>
        public int[] RunningSum(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
                nums[i] += nums[i - 1];
            return nums;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/longest-subarray-of-1s-after-deleting-one-element/">1493. Longest Subarray of 1's After Deleting One Element (medium)</a>
        /// Find the longest all-ones subarray obtainable after deleting exactly one element.
        /// </summary>
        /// <param name="nums">The binary values to scan.</param>
        /// <returns>The maximum length of ones after one deletion.</returns>
        public int LongestSubarray(int[] nums)
        {
            int left = 0, zeros = 0, best = 0;
            for (int right = 0; right < nums.Length; right++)
            {
                if (nums[right] == 0)
                    zeros++;
                while (zeros > 1)
                {
                    if (nums[left++] == 0)
                        zeros--;
                }
                best = Math.Max(best, right - left);
            }
            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/kth-missing-positive-number/">1539. Kth Missing Positive Number (easy)</a>
        /// Find the kth positive integer missing from a strictly increasing positive array.
        /// </summary>
        /// <param name="arr">The present positive integers.</param>
        /// <param name="k">The missing-number rank to find.</param>
        /// <returns>The kth missing positive integer.</returns>
        public int FindKthPositive(int[] arr, int k)
        {
            int current = 1, index = 0;
            while (true)
            {
                if (index < arr.Length && arr[index] == current)
                    index++;
                else if (--k == 0)
                    return current;
                current++;
            }
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/matrix-diagonal-sum/">1572. Matrix Diagonal Sum (easy)</a>
        /// Sum the primary and secondary diagonals of a square matrix without double-counting the center.
        /// </summary>
        /// <param name="mat">The square matrix.</param>
        /// <returns>The sum of both diagonals.</returns>
        public int DiagonalSum(int[][] mat)
        {
            int sum = 0, n = mat.Length;
            for (int i = 0; i < n; i++)
                sum += mat[i][i] + (i == n - 1 - i ? 0 : mat[i][n - 1 - i]);
            return sum;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/sum-of-all-odd-length-subarrays/">1588. Sum of All Odd Length Subarrays (easy)</a>
        /// Sum every odd-length contiguous subarray.
        /// </summary>
        /// <param name="arr">The values to aggregate.</param>
        /// <returns>The sum of all odd-length subarrays.</returns>
        public int SumOddLengthSubarrays(int[] arr)
        {
            int total = 0, n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                int subarrays = (i + 1) * (n - i);
                total += ((subarrays + 1) / 2) * arr[i];
            }
            return total;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/special-array-with-x-elements-greater-than-or-equal-x/">1608. Special Array With X Elements Greater Than or Equal X (easy)</a>
        /// Find x such that exactly x elements are greater than or equal to x.
        /// </summary>
        /// <param name="nums">The non-negative values to inspect.</param>
        /// <returns>The special value x, or -1 when none exists.</returns>
        public int SpecialArray(int[] nums)
        {
            for (int x = 0; x <= nums.Length; x++)
            {
                if (nums.Count(num => num >= x) == x)
                    return x;
            }
            return -1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/defuse-the-bomb/">1652. Defuse the Bomb (easy)</a>
        /// Replace each circular code value by the sum of the next or previous k values.
        /// </summary>
        /// <param name="code">The circular code values.</param>
        /// <param name="k">Positive sums next values, negative sums previous values, and zero returns zeros.</param>
        /// <returns>The decrypted code.</returns>
        public int[] Decrypt(int[] code, int k)
        {
            var result = new int[code.Length];
            if (k == 0)
                return result;

            int n = code.Length;
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                for (int step = 1; step <= Math.Abs(k); step++)
                {
                    int index = k > 0 ? (i + step) % n : (i - step + n) % n;
                    sum += code[index];
                }
                result[i] = sum;
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/richest-customer-wealth/">1672. Richest Customer Wealth (easy)</a>
        /// Find the largest row sum in a customer-account matrix.
        /// </summary>
        /// <param name="accounts">Rows of account balances per customer.</param>
        /// <returns>The greatest customer wealth.</returns>
        public int MaximumWealth(int[][] accounts)
        {
            return accounts.Max(customer => customer.Sum());
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/max-number-of-k-sum-pairs/">1679. Max Number of K-Sum Pairs (medium)</a>
        /// Remove as many disjoint pairs as possible whose values sum to k.
        /// </summary>
        /// <param name="nums">The values to pair.</param>
        /// <param name="k">The required pair sum.</param>
        /// <returns>The maximum number of disjoint k-sum pairs.</returns>
        public int MaxOperations(int[] nums, int k)
        {
            var counts = new Dictionary<int, int>();
            int operations = 0;
            foreach (int num in nums)
            {
                int complement = k - num;
                if (counts.GetValueOrDefault(complement) > 0)
                {
                    counts[complement]--;
                    operations++;
                }
                else
                {
                    counts[num] = counts.GetValueOrDefault(num) + 1;
                }
            }
            return operations;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/where-will-the-ball-fall/">1706. Where Will the Ball Fall (medium)</a>
        /// Simulate each ball through a grid of diagonal boards and report the exit column or -1 when it gets stuck.
        /// </summary>
        /// <param name="grid">The board directions, where 1 redirects right and -1 redirects left.</param>
        /// <returns>An array containing each ball's final column, or -1 for stuck balls.</returns>
        public int[] FindBall(int[][] grid)
        {
            int rows = grid.Length, cols = grid[0].Length;
            var result = new int[cols];
            for (int start = 0; start < cols; start++)
            {
                int col = start;
                for (int row = 0; row < rows; row++)
                {
                    int nextCol = col + grid[row][col];
                    if (nextCol < 0 || nextCol == cols || grid[row][nextCol] != grid[row][col])
                    {
                        col = -1;
                        break;
                    }
                    col = nextCol;
                }
                result[start] = col;
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-the-highest-altitude/">1732. Find the Highest Altitude (easy)</a>
        /// Track cumulative altitude changes and return the highest altitude reached starting from zero.
        /// </summary>
        /// <param name="gain">The altitude gain between consecutive points.</param>
        /// <returns>The maximum altitude reached along the trip.</returns>
        public int LargestAltitude(int[] gain)
        {
            int altitude = 0, highest = 0;
            foreach (int delta in gain)
            {
                altitude += delta;
                highest = Math.Max(highest, altitude);
            }
            return highest;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/restore-the-array-from-adjacent-pairs/">1743. Restore the Array From Adjacent Pairs (medium)</a>
        /// Reconstruct the original array whose neighboring values are described by unordered adjacent pairs.
        /// </summary>
        /// <param name="adjacentPairs">Pairs of values that were adjacent in the original array.</param>
        /// <returns>The restored array in either valid orientation.</returns>
        public int[] RestoreArray(int[][] adjacentPairs)
        {
            var graph = new Dictionary<int, List<int>>();
            foreach (int[] pair in adjacentPairs)
            {
                if (!graph.ContainsKey(pair[0]))
                    graph[pair[0]] = new List<int>();
                if (!graph.ContainsKey(pair[1]))
                    graph[pair[1]] = new List<int>();
                graph[pair[0]].Add(pair[1]);
                graph[pair[1]].Add(pair[0]);
            }

            int start = graph.First(node => node.Value.Count == 1).Key;
            var result = new int[adjacentPairs.Length + 1];
            result[0] = start;
            int previous = int.MinValue;
            for (int i = 1; i < result.Length; i++)
            {
                int current = result[i - 1];
                result[i] = graph[current].First(next => next != previous);
                previous = current;
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-number-of-operations-to-move-all-balls-to-each-box/">1769. Minimum Number of Operations to Move All Balls to Each Box (medium)</a>
        /// For every box, compute the total adjacent moves needed to bring all balls to that box.
        /// </summary>
        /// <param name="boxes">A binary string where '1' marks a box containing a ball.</param>
        /// <returns>The operation count for every target box.</returns>
        public int[] MinOperations(string boxes)
        {
            int n = boxes.Length;
            var result = new int[n];
            int balls = 0, moves = 0;
            for (int i = 0; i < n; i++)
            {
                result[i] += moves;
                balls += boxes[i] == '1' ? 1 : 0;
                moves += balls;
            }

            balls = 0;
            moves = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                result[i] += moves;
                balls += boxes[i] == '1' ? 1 : 0;
                moves += balls;
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-nearest-point-that-has-the-same-x-or-y-coordinate/">1779. Find Nearest Point That Has the Same X or Y Coordinate (easy)</a>
        /// Find the valid point sharing x or y with the query that has the smallest Manhattan distance.
        /// </summary>
        /// <param name="x">The query x-coordinate.</param>
        /// <param name="y">The query y-coordinate.</param>
        /// <param name="points">The candidate points as [x, y] pairs.</param>
        /// <returns>The index of the nearest valid point, or -1 when none exists.</returns>
        public int NearestValidPoint(int x, int y, int[][] points)
        {
            int bestIndex = -1, bestDistance = int.MaxValue;
            for (int i = 0; i < points.Length; i++)
            {
                if (points[i][0] != x && points[i][1] != y)
                    continue;

                int distance = Math.Abs(points[i][0] - x) + Math.Abs(points[i][1] - y);
                if (distance < bestDistance)
                {
                    bestDistance = distance;
                    bestIndex = i;
                }
            }
            return bestIndex;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/sign-of-the-product-of-an-array/">1822. Sign of the Product of an Array (easy)</a>
        /// Determine the sign of the product of all values without computing the product itself.
        /// </summary>
        /// <param name="nums">The integer values to multiply conceptually.</param>
        /// <returns>1 for positive product, -1 for negative product, or 0 when any value is zero.</returns>
        public int ArraySign(int[] nums)
        {
            int sign = 1;
            foreach (int num in nums)
            {
                if (num == 0)
                    return 0;
                if (num < 0)
                    sign = -sign;
            }
            return sign;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-population-year/">1854. Maximum Population Year (easy)</a>
        /// Use birth/death difference events to find the earliest year with the maximum living population.
        /// </summary>
        /// <param name="logs">Birth and death years as [birth, death), one row per person.</param>
        /// <returns>The earliest year with the highest population.</returns>
        public int MaximumPopulation(int[][] logs)
        {
            var changes = new int[101];
            foreach (int[] log in logs)
            {
                changes[log[0] - 1950]++;
                changes[log[1] - 1950]--;
            }

            int population = 0, bestPopulation = 0, bestYear = 1950;
            for (int year = 0; year < changes.Length; year++)
            {
                population += changes[year];
                if (population > bestPopulation)
                {
                    bestPopulation = population;
                    bestYear = 1950 + year;
                }
            }
            return bestYear;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimize-maximum-pair-sum-in-array/">1877. Minimize Maximum Pair Sum in Array (medium)</a>
        /// Pair smallest values with largest values to minimize the largest pair sum.
        /// </summary>
        /// <param name="nums">An even-length array of values to pair.</param>
        /// <returns>The minimized maximum pair sum.</returns>
        public int MinPairSum(int[] nums)
        {
            Array.Sort(nums);
            int result = 0;
            for (int left = 0, right = nums.Length - 1; left < right; left++, right--)
                result = Math.Max(result, nums[left] + nums[right]);
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/build-array-from-permutation/">1920. Build Array from Permutation (easy)</a>
        /// Build ans where ans[i] equals nums[nums[i]] for a zero-based permutation.
        /// </summary>
        /// <param name="nums">A zero-based permutation.</param>
        /// <returns>The derived permutation array.</returns>
        public int[] BuildArray(int[] nums)
        {
            var result = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
                result[i] = nums[nums[i]];
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/concatenation-of-array/">1929. Concatenation of Array (easy)</a>
        /// Concatenate an array with itself.
        /// </summary>
        /// <param name="nums">The input array.</param>
        /// <returns>The array [nums, nums].</returns>
        public int[] GetConcatenation(int[] nums)
        {
            var result = new int[nums.Length * 2];
            Array.Copy(nums, result, nums.Length);
            Array.Copy(nums, 0, result, nums.Length, nums.Length);
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-matrix-sum/">1975. Maximum Matrix Sum (medium)</a>
        /// Maximize the matrix sum after any number of adjacent sign flips by making all values non-negative except possibly the smallest absolute value.
        /// </summary>
        /// <param name="matrix">The integer matrix.</param>
        /// <returns>The maximum possible matrix sum.</returns>
        public long MaxMatrixSum(int[][] matrix)
        {
            long sum = 0;
            int negatives = 0, minAbs = int.MaxValue;
            foreach (int[] row in matrix)
            {
                foreach (int value in row)
                {
                    if (value < 0)
                        negatives++;
                    int absolute = Math.Abs(value);
                    sum += absolute;
                    minAbs = Math.Min(minAbs, absolute);
                }
            }
            return negatives % 2 == 0 ? sum : sum - 2L * minAbs;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-the-middle-index-in-array/">1991. Find the Middle Index in Array (easy)</a>
        /// Find the leftmost index where the sum to the left equals the sum to the right.
        /// </summary>
        /// <param name="nums">The values to inspect.</param>
        /// <returns>The first middle index, or -1 if none exists.</returns>
        public int FindMiddleIndex(int[] nums)
        {
            int total = nums.Sum(), left = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (left == total - left - nums[i])
                    return i;
                left += nums[i];
            }
            return -1;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-difference-between-increasing-elements/">2016. Maximum Difference Between Increasing Elements (easy)</a>
        /// Find the largest positive nums[j] - nums[i] with i before j.
        /// </summary>
        /// <param name="nums">The values to scan.</param>
        /// <returns>The maximum positive difference, or -1 when no increasing pair exists.</returns>
        public int MaximumDifference(int[] nums)
        {
            int min = nums[0], best = -1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > min)
                    best = Math.Max(best, nums[i] - min);
                min = Math.Min(min, nums[i]);
            }
            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/k-radius-subarray-averages/">2090. K Radius Subarray Averages (medium)</a>
        /// Compute each centered radius-k window average, using -1 when a full window does not fit.
        /// </summary>
        /// <param name="nums">The array values.</param>
        /// <param name="k">The radius on each side of a center index.</param>
        /// <returns>The k-radius average for every index.</returns>
        public int[] GetAverages(int[] nums, int k)
        {
            var result = Enumerable.Repeat(-1, nums.Length).ToArray();
            int windowLength = 2 * k + 1;
            if (k == 0)
                return (int[])nums.Clone();
            if (windowLength > nums.Length)
                return result;

            long window = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                window += nums[i];
                if (i >= windowLength)
                    window -= nums[i - windowLength];
                if (i >= windowLength - 1)
                    result[i - k] = (int)(window / windowLength);
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/rearrange-array-elements-by-sign/">2149. Rearrange Array Elements by Sign (medium)</a>
        /// Rearrange equal counts of positive and negative values so signs alternate starting with positive while preserving relative sign order.
        /// </summary>
        /// <param name="nums">The values containing equal positive and negative counts.</param>
        /// <returns>The sign-alternating rearranged array.</returns>
        public int[] RearrangeArray(int[] nums)
        {
            var result = new int[nums.Length];
            int positive = 0, negative = 1;
            foreach (int num in nums)
            {
                if (num > 0)
                {
                    result[positive] = num;
                    positive += 2;
                }
                else
                {
                    result[negative] = num;
                    negative += 2;
                }
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/partition-array-according-to-given-pivot/">2161. Partition Array According to Given Pivot (medium)</a>
        /// Stably partition values less than, equal to, and greater than a pivot.
        /// </summary>
        /// <param name="nums">The values to partition.</param>
        /// <param name="pivot">The pivot value.</param>
        /// <returns>The partitioned array.</returns>
        public int[] PivotArray(int[] nums, int pivot)
        {
            var result = new int[nums.Length];
            int index = 0;
            foreach (int num in nums.Where(num => num < pivot))
                result[index++] = num;
            foreach (int num in nums.Where(num => num == pivot))
                result[index++] = num;
            foreach (int num in nums.Where(num => num > pivot))
                result[index++] = num;
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-the-difference-of-two-arrays/">2215. Find the Difference of Two Arrays (easy)</a>
        /// Return distinct values present in each array but absent from the other.
        /// </summary>
        /// <param name="nums1">The first array.</param>
        /// <param name="nums2">The second array.</param>
        /// <returns>Two lists: values unique to nums1 and values unique to nums2.</returns>
        public IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
        {
            var set1 = nums1.ToHashSet();
            var set2 = nums2.ToHashSet();
            return new List<IList<int>>
            {
                set1.Where(num => !set2.Contains(num)).ToList(),
                set2.Where(num => !set1.Contains(num)).ToList()
            };
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/longest-subsequence-with-limited-sum/">2389. Longest Subsequence With Limited Sum (easy)</a>
        /// For each query, find the longest subsequence whose sum is at most the query by greedily taking smallest values.
        /// </summary>
        /// <param name="nums">The available positive values.</param>
        /// <param name="queries">The sum limits to answer.</param>
        /// <returns>The maximum subsequence length for each query.</returns>
        public int[] AnswerQueries(int[] nums, int[] queries)
        {
            Array.Sort(nums);
            var prefix = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
                prefix[i] = nums[i] + (i == 0 ? 0 : prefix[i - 1]);

            var result = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                int index = Array.BinarySearch(prefix, queries[i]);
                result[i] = index >= 0 ? index + 1 : ~index;
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-the-original-array-of-prefix-xor/">2433. Find The Original Array of Prefix Xor (medium)</a>
        /// Recover the original array from its prefix XOR array.
        /// </summary>
        /// <param name="pref">The prefix XOR values.</param>
        /// <returns>The original array.</returns>
        public int[] FindArray(int[] pref)
        {
            var result = new int[pref.Length];
            result[0] = pref[0];
            for (int i = 1; i < pref.Length; i++)
                result[i] = pref[i - 1] ^ pref[i];
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/apply-operations-to-an-array/">2460. Apply Operations to an Array (easy)</a>
        /// Double equal adjacent values, zero the second value, then move all zeros to the end.
        /// </summary>
        /// <param name="nums">The values to transform.</param>
        /// <returns>The transformed array.</returns>
        public int[] ApplyOperations(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] == nums[i + 1])
                {
                    nums[i] *= 2;
                    nums[i + 1] = 0;
                }
            }

            var result = new int[nums.Length];
            int index = 0;
            foreach (int num in nums)
            {
                if (num != 0)
                    result[index++] = num;
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/merge-two-2d-arrays-by-summing-values/">2570. Merge Two 2D Arrays by Summing Values (easy)</a>
        /// Merge two sorted [id, value] arrays, summing rows with the same id.
        /// </summary>
        /// <param name="nums1">The first sorted [id, value] array.</param>
        /// <param name="nums2">The second sorted [id, value] array.</param>
        /// <returns>The merged sorted [id, value] array.</returns>
        public int[][] MergeArrays(int[][] nums1, int[][] nums2)
        {
            var result = new List<int[]>();
            int i = 0, j = 0;
            while (i < nums1.Length || j < nums2.Length)
            {
                if (j == nums2.Length || (i < nums1.Length && nums1[i][0] < nums2[j][0]))
                {
                    result.Add(new[] { nums1[i][0], nums1[i][1] });
                    i++;
                }
                else if (i == nums1.Length || nums2[j][0] < nums1[i][0])
                {
                    result.Add(new[] { nums2[j][0], nums2[j][1] });
                    j++;
                }
                else
                {
                    result.Add(new[] { nums1[i][0], nums1[i][1] + nums2[j][1] });
                    i++;
                    j++;
                }
            }
            return result.ToArray();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/convert-an-array-into-a-2d-array-with-conditions/">2610. Convert an Array Into a 2D Array With Conditions (medium)</a>
        /// Split values into the fewest rows so each row contains distinct values.
        /// </summary>
        /// <param name="nums">The values to arrange.</param>
        /// <returns>A valid minimum-height matrix of distinct rows.</returns>
        public IList<IList<int>> FindMatrix(int[] nums)
        {
            var counts = new Dictionary<int, int>();
            var result = new List<IList<int>>();
            foreach (int num in nums)
            {
                int row = counts.GetValueOrDefault(num);
                if (row == result.Count)
                    result.Add(new List<int>());
                result[row].Add(num);
                counts[num] = row + 1;
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/prime-in-diagonal/">2614. Prime In Diagonal (easy)</a>
        /// Find the largest prime on either main diagonal of a square matrix.
        /// </summary>
        /// <param name="nums">The square matrix to inspect.</param>
        /// <returns>The largest diagonal prime, or 0 when none exists.</returns>
        public int DiagonalPrime(int[][] nums)
        {
            int result = 0, n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                if (IsPrime(nums[i][i]))
                    result = Math.Max(result, nums[i][i]);
                if (IsPrime(nums[i][n - 1 - i]))
                    result = Math.Max(result, nums[i][n - 1 - i]);
            }
            return result;
        }

        private bool IsPrime(int value)
        {
            if (value < 2)
                return false;
            if (value == 2)
                return true;
            if (value % 2 == 0)
                return false;
            for (int divisor = 3; divisor * divisor <= value; divisor += 2)
            {
                if (value % divisor == 0)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/row-with-maximum-ones/">2643. Row With Maximum Ones (easy)</a>
        /// Find the row containing the most ones, choosing the smallest index on ties.
        /// </summary>
        /// <param name="mat">The binary matrix.</param>
        /// <returns>A two-element array [rowIndex, onesCount].</returns>
        public int[] RowAndMaximumOnes(int[][] mat)
        {
            int bestRow = 0, bestCount = -1;
            for (int row = 0; row < mat.Length; row++)
            {
                int count = mat[row].Sum();
                if (count > bestCount)
                {
                    bestCount = count;
                    bestRow = row;
                }
            }
            return new[] { bestRow, bestCount };
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-the-prefix-common-array-of-two-arrays/">2657. Find the Prefix Common Array of Two Arrays (medium)</a>
        /// For two permutations, count common values after each pair of prefixes.
        /// </summary>
        /// <param name="A">The first permutation.</param>
        /// <param name="B">The second permutation.</param>
        /// <returns>The prefix common counts.</returns>
        public int[] FindThePrefixCommonArray(int[] A, int[] B)
        {
            var frequencies = new int[A.Length + 1];
            var result = new int[A.Length];
            int common = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (++frequencies[A[i]] == 2)
                    common++;
                if (++frequencies[B[i]] == 2)
                    common++;
                result[i] = common;
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/sum-in-a-matrix/">2679. Sum in a Matrix (medium)</a>
        /// Repeatedly take each row's current maximum and add the largest among those values.
        /// </summary>
        /// <param name="nums">The matrix values.</param>
        /// <returns>The final score after removing all values.</returns>
        public int MatrixSum(int[][] nums)
        {
            foreach (int[] row in nums)
                Array.Sort(row);

            int score = 0;
            for (int col = nums[0].Length - 1; col >= 0; col--)
            {
                int columnMax = 0;
                for (int row = 0; row < nums.Length; row++)
                    columnMax = Math.Max(columnMax, nums[row][col]);
                score += columnMax;
            }
            return score;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/buy-two-chocolates/">2706. Buy Two Chocolates (easy)</a>
        /// Buy the two cheapest chocolates when possible and return the remaining money.
        /// </summary>
        /// <param name="prices">The chocolate prices.</param>
        /// <param name="money">The starting amount of money.</param>
        /// <returns>The money left after buying two chocolates, or the original money when unaffordable.</returns>
        public int BuyChoco(int[] prices, int money)
        {
            int first = int.MaxValue, second = int.MaxValue;
            foreach (int price in prices)
            {
                if (price < first)
                {
                    second = first;
                    first = price;
                }
                else if (price < second)
                {
                    second = price;
                }
            }

            int cost = first + second;
            return cost <= money ? money - cost : money;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/neither-minimum-nor-maximum/">2733. Neither Minimum nor Maximum (easy)</a>
        /// Find any value that is neither the minimum nor the maximum.
        /// </summary>
        /// <param name="nums">The distinct values to inspect.</param>
        /// <returns>A value that is neither minimum nor maximum, or -1 when none exists.</returns>
        public int FindNonMinOrMax(int[] nums)
        {
            if (nums.Length < 3)
                return -1;

            int minimum = nums.Min();
            int maximum = nums.Max();
            return nums.First(num => num != minimum && num != maximum);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/continuous-subarrays/">2762. Continuous Subarrays (medium)</a>
        /// Count subarrays where the difference between the maximum and minimum values is at most two.
        /// </summary>
        /// <param name="nums">The values to scan.</param>
        /// <returns>The number of valid continuous subarrays.</returns>
        public long ContinuousSubarrays(int[] nums)
        {
            var counts = new SortedDictionary<int, int>();
            long total = 0;
            int left = 0;

            for (int right = 0; right < nums.Length; right++)
            {
                counts[nums[right]] = counts.GetValueOrDefault(nums[right]) + 1;
                while (counts.Keys.Last() - counts.Keys.First() > 2)
                {
                    if (--counts[nums[left]] == 0)
                        counts.Remove(nums[left]);
                    left++;
                }
                total += right - left + 1;
            }

            return total;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-beauty-of-an-array-after-applying-operation/">2779. Maximum Beauty of an Array After Applying Operation (medium)</a>
        /// Find the largest group that can be made equal when each value may change by at most k.
        /// </summary>
        /// <param name="nums">The original values.</param>
        /// <param name="k">The maximum absolute adjustment per value.</param>
        /// <returns>The maximum possible beauty.</returns>
        public int MaximumBeauty(int[] nums, int k)
        {
            Array.Sort(nums);
            int best = 0, left = 0;
            for (int right = 0; right < nums.Length; right++)
            {
                while (nums[right] - nums[left] > 2 * k)
                    left++;
                best = Math.Max(best, right - left + 1);
            }
            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/largest-element-in-an-array-after-merge-operations/">2789. Largest Element in an Array after Merge Operations (medium)</a>
        /// Merge from right to left whenever a left value can be absorbed into the current suffix sum.
        /// </summary>
        /// <param name="nums">The array values.</param>
        /// <returns>The largest value obtainable after valid merge operations.</returns>
        public long MaxArrayValue(int[] nums)
        {
            long current = nums[^1], best = current;
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                current = nums[i] <= current ? current + nums[i] : nums[i];
                best = Math.Max(best, current);
            }
            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/number-of-employees-who-met-the-target/">2798. Number of Employees Who Met the Target (easy)</a>
        /// Count employees whose worked hours meet or exceed the target.
        /// </summary>
        /// <param name="hours">The hours worked by each employee.</param>
        /// <param name="target">The target number of hours.</param>
        /// <returns>The number of employees meeting the target.</returns>
        public int NumberOfEmployeesWhoMetTarget(int[] hours, int target)
        {
            return hours.Count(hour => hour >= target);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-pairs-whose-sum-is-less-than-target/">2824. Count Pairs Whose Sum is Less than Target (easy)</a>
        /// Count index pairs whose values sum to less than the target.
        /// </summary>
        /// <param name="nums">The values to pair.</param>
        /// <param name="target">The exclusive upper bound for each pair sum.</param>
        /// <returns>The number of pairs with sum less than <paramref name="target"/>.</returns>
        public int CountPairs(IList<int> nums, int target)
        {
            var sorted = nums.OrderBy(num => num).ToArray();
            int left = 0, right = sorted.Length - 1, count = 0;
            while (left < right)
            {
                if (sorted[left] + sorted[right] < target)
                {
                    count += right - left;
                    left++;
                }
                else
                {
                    right--;
                }
            }
            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-sum-of-almost-unique-subarray/">2841. Maximum Sum of Almost Unique Subarray (medium)</a>
        /// Find the maximum sum of a length-k subarray containing at least m distinct values.
        /// </summary>
        /// <param name="nums">The values to scan.</param>
        /// <param name="m">The minimum number of distinct values required.</param>
        /// <param name="k">The exact subarray length.</param>
        /// <returns>The maximum qualifying subarray sum, or 0 when none qualifies.</returns>
        public long MaxSum(IList<int> nums, int m, int k)
        {
            var counts = new Dictionary<int, int>();
            long sum = 0, best = 0;
            for (int i = 0; i < nums.Count; i++)
            {
                sum += nums[i];
                counts[nums[i]] = counts.GetValueOrDefault(nums[i]) + 1;

                if (i >= k)
                {
                    sum -= nums[i - k];
                    if (--counts[nums[i - k]] == 0)
                        counts.Remove(nums[i - k]);
                }

                if (i >= k - 1 && counts.Count >= m)
                    best = Math.Max(best, sum);
            }
            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-number-of-operations-to-make-array-empty/">2870. Minimum Number of Operations to Make Array Empty (medium)</a>
        /// Remove equal values in groups of two or three using the fewest operations.
        /// </summary>
        /// <param name="nums">The values to remove.</param>
        /// <returns>The minimum operation count, or -1 when a singleton value prevents removal.</returns>
        public int MinOperations(int[] nums)
        {
            int operations = 0;
            foreach (var group in nums.GroupBy(num => num))
            {
                int count = group.Count();
                if (count == 1)
                    return -1;
                operations += (count + 2) / 3;
            }
            return operations;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-value-of-an-ordered-triplet-i/">2873. Maximum Value of an Ordered Triplet I (easy)</a>
        /// Maximize (nums[i] - nums[j]) * nums[k] over increasing indices.
        /// </summary>
        /// <param name="nums">The values to evaluate.</param>
        /// <returns>The maximum triplet value, or 0 when all candidates are negative.</returns>
        public long MaximumTripletValue(int[] nums)
        {
            long best = 0, bestDifference = 0;
            int maxPrefix = nums[0];
            for (int j = 1; j < nums.Length - 1; j++)
            {
                bestDifference = Math.Max(bestDifference, maxPrefix - nums[j]);
                best = Math.Max(best, bestDifference * nums[j + 1]);
                maxPrefix = Math.Max(maxPrefix, nums[j]);
            }
            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-processing-time/">2895. Minimum Processing Time (medium)</a>
        /// Assign four tasks to each processor to minimize the latest finishing time.
        /// </summary>
        /// <param name="processorTime">The start time for each processor.</param>
        /// <param name="tasks">The task durations.</param>
        /// <returns>The minimum possible processing finish time.</returns>
        public int MinProcessingTime(IList<int> processorTime, IList<int> tasks)
        {
            var processors = processorTime.OrderBy(time => time).ToArray();
            var sortedTasks = tasks.OrderByDescending(task => task).ToArray();
            int result = 0;
            for (int i = 0; i < processors.Length; i++)
                result = Math.Max(result, processors[i] + sortedTasks[i * 4]);
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-indices-with-index-and-value-difference-i/">2903. Find Indices With Index and Value Difference I (easy)</a>
        /// Find two indices that satisfy minimum index and value differences.
        /// </summary>
        /// <param name="nums">The values to inspect.</param>
        /// <param name="indexDifference">The minimum absolute index difference.</param>
        /// <param name="valueDifference">The minimum absolute value difference.</param>
        /// <returns>A valid pair of indices, or [-1, -1] when none exists.</returns>
        public int[] FindIndices(int[] nums, int indexDifference, int valueDifference)
        {
            int minIndex = 0, maxIndex = 0;
            for (int j = indexDifference; j < nums.Length; j++)
            {
                int candidate = j - indexDifference;
                if (nums[candidate] < nums[minIndex])
                    minIndex = candidate;
                if (nums[candidate] > nums[maxIndex])
                    maxIndex = candidate;

                if (nums[maxIndex] - nums[j] >= valueDifference)
                    return new[] { maxIndex, j };
                if (nums[j] - nums[minIndex] >= valueDifference)
                    return new[] { minIndex, j };
            }
            return new[] { -1, -1 };
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/subarrays-distinct-element-sum-of-squares-i/">2913. Subarrays Distinct Element Sum of Squares I (easy)</a>
        /// Sum the square of the distinct-value count for every subarray.
        /// </summary>
        /// <param name="nums">The values to enumerate.</param>
        /// <returns>The total sum of squared distinct counts.</returns>
        public int SumCounts(IList<int> nums)
        {
            int total = 0;
            for (int start = 0; start < nums.Count; start++)
            {
                var seen = new HashSet<int>();
                for (int end = start; end < nums.Count; end++)
                {
                    seen.Add(nums[end]);
                    total += seen.Count * seen.Count;
                }
            }
            return total;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-the-peaks/">2951. Find the Peaks (easy)</a>
        /// Return indices whose values are strictly greater than both neighbors.
        /// </summary>
        /// <param name="mountain">The mountain candidate values.</param>
        /// <returns>The peak indices, excluding endpoints.</returns>
        public IList<int> FindPeaks(int[] mountain)
        {
            var result = new List<int>();
            for (int i = 1; i < mountain.Length - 1; i++)
                if (mountain[i] > mountain[i - 1] && mountain[i] > mountain[i + 1])
                    result.Add(i);
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-missing-and-repeated-values/">2965. Find Missing and Repeated Values (easy)</a>
        /// In an n x n grid containing one repeated value and one missing value from 1..n², find both.
        /// </summary>
        /// <param name="grid">The grid values.</param>
        /// <returns>[repeated, missing].</returns>
        public int[] FindMissingAndRepeatedValues(int[][] grid)
        {
            int n = grid.Length, size = n * n;
            var seen = new bool[size + 1];
            int repeated = -1;
            foreach (var row in grid)
            {
                foreach (int value in row)
                {
                    if (seen[value])
                        repeated = value;
                    seen[value] = true;
                }
            }

            for (int value = 1; value <= size; value++)
                if (!seen[value])
                    return new[] { repeated, value };
            return new[] { repeated, -1 };
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/divide-array-into-arrays-with-max-difference/">2966. Divide Array Into Arrays With Max Difference (medium)</a>
        /// Split sorted values into triples whose internal max-min difference is at most k.
        /// </summary>
        /// <param name="nums">The values to divide.</param>
        /// <param name="k">The maximum allowed difference per triple.</param>
        /// <returns>The grouped triples, or an empty matrix when grouping is impossible.</returns>
        public int[][] DivideArray(int[] nums, int k)
        {
            Array.Sort(nums);
            var result = new int[nums.Length / 3][];
            for (int i = 0; i < nums.Length; i += 3)
            {
                if (nums[i + 2] - nums[i] > k)
                    return Array.Empty<int[]>();
                result[i / 3] = new[] { nums[i], nums[i + 1], nums[i + 2] };
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-number-game/">2974. Minimum Number Game (easy)</a>
        /// Sort the values and swap each adjacent pair after Alice and Bob remove the two smallest numbers.
        /// </summary>
        /// <param name="nums">The values in the game.</param>
        /// <returns>The generated result array.</returns>
        public int[] NumberGame(int[] nums)
        {
            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i += 2)
                (nums[i], nums[i + 1]) = (nums[i + 1], nums[i]);
            return nums;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-elements-with-maximum-frequency/">3005. Count Elements With Maximum Frequency (easy)</a>
        /// Sum frequencies of all values that appear with maximum frequency.
        /// </summary>
        /// <param name="nums">The values to count.</param>
        /// <returns>The total occurrences belonging to most-frequent values.</returns>
        public int MaxFrequencyElements(int[] nums)
        {
            var counts = new Dictionary<int, int>();
            int maxFrequency = 0, total = 0;
            foreach (int num in nums)
            {
                int frequency = counts.GetValueOrDefault(num) + 1;
                counts[num] = frequency;
                if (frequency > maxFrequency)
                {
                    maxFrequency = frequency;
                    total = frequency;
                }
                else if (frequency == maxFrequency)
                {
                    total += frequency;
                }
            }
            return total;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/divide-an-array-into-subarrays-with-minimum-cost-i/">3010. Divide an Array Into Subarrays With Minimum Cost I (easy)</a>
        /// Choose the first element and the two cheapest remaining starts to minimize total cost.
        /// </summary>
        /// <param name="nums">The array values.</param>
        /// <returns>The minimum division cost.</returns>
        public int MinimumCost(int[] nums)
        {
            int first = int.MaxValue, second = int.MaxValue;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < first)
                {
                    second = first;
                    first = nums[i];
                }
                else if (nums[i] < second)
                {
                    second = nums[i];
                }
            }
            return nums[0] + first + second;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-if-array-can-be-sorted/">3011. Find if Array Can Be Sorted (medium)</a>
        /// Determine whether adjacent swaps among values with equal set-bit counts can sort the array.
        /// </summary>
        /// <param name="nums">The values to inspect.</param>
        /// <returns><see langword="true"/> when the array can be sorted; otherwise, <see langword="false"/>.</returns>
        public bool CanSortArray(int[] nums)
        {
            int previousGroupMax = int.MinValue;
            int i = 0;
            while (i < nums.Length)
            {
                int bitCount = CountBits(nums[i]);
                int groupMin = nums[i], groupMax = nums[i];
                while (i < nums.Length && CountBits(nums[i]) == bitCount)
                {
                    groupMin = Math.Min(groupMin, nums[i]);
                    groupMax = Math.Max(groupMax, nums[i]);
                    i++;
                }

                if (groupMin < previousGroupMax)
                    return false;
                previousGroupMax = groupMax;
            }
            return true;
        }

        private int CountBits(int value)
        {
            int count = 0;
            while (value > 0)
            {
                count += value & 1;
                value >>= 1;
            }
            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/ant-on-the-boundary/">3028. Ant on the Boundary (easy)</a>
        /// Count how many moves return the ant to position zero.
        /// </summary>
        /// <param name="nums">The signed movement distances.</param>
        /// <returns>The number of boundary returns.</returns>
        public int ReturnToBoundaryCount(int[] nums)
        {
            int position = 0, count = 0;
            foreach (int move in nums)
            {
                position += move;
                if (position == 0)
                    count++;
            }
            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-operations-to-exceed-threshold-value-i/">3065. Minimum Operations to Exceed Threshold Value I (easy)</a>
        /// Count values that are below the threshold.
        /// </summary>
        /// <param name="nums">The values to inspect.</param>
        /// <param name="k">The threshold value.</param>
        /// <returns>The number of values less than <paramref name="k"/>.</returns>
        public int MinOperations(int[] nums, int k)
        {
            return nums.Count(num => num < k);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-operations-to-exceed-threshold-value-ii/">3066. Minimum Operations to Exceed Threshold Value II (medium)</a>
        /// Repeatedly combine the two smallest values until every value is at least k.
        /// </summary>
        /// <param name="nums">The starting values.</param>
        /// <param name="k">The threshold value.</param>
        /// <returns>The minimum number of combine operations.</returns>
        public int MinOperationsII(int[] nums, int k)
        {
            var queue = new PriorityQueue<long, long>();
            foreach (int num in nums)
                queue.Enqueue(num, num);

            int operations = 0;
            while (queue.Count > 0 && queue.Peek() < k)
            {
                long first = queue.Dequeue();
                long second = queue.Dequeue();
                long combined = first * 2 + second;
                queue.Enqueue(combined, combined);
                operations++;
            }
            return operations;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/apple-redistribution-into-boxes/">3074. Apple Redistribution into Boxes (easy)</a>
        /// Choose the fewest largest boxes whose capacity can hold all apples.
        /// </summary>
        /// <param name="apple">The apple counts in packs.</param>
        /// <param name="capacity">The box capacities.</param>
        /// <returns>The minimum number of boxes needed.</returns>
        public int MinimumBoxes(int[] apple, int[] capacity)
        {
            int remaining = apple.Sum();
            Array.Sort(capacity);
            int boxes = 0;
            for (int i = capacity.Length - 1; remaining > 0; i--)
            {
                remaining -= capacity[i];
                boxes++;
            }
            return boxes;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximize-happiness-of-selected-children/">3075. Maximize Happiness of Selected Children (medium)</a>
        /// Select k children greedily while each prior selection lowers remaining happiness by one.
        /// </summary>
        /// <param name="happiness">The initial happiness values.</param>
        /// <param name="k">The number of children to select.</param>
        /// <returns>The maximum total happiness.</returns>
        public long MaximumHappinessSum(int[] happiness, int k)
        {
            Array.Sort(happiness);
            long total = 0;
            for (int taken = 0; taken < k; taken++)
                total += Math.Max(0, happiness[happiness.Length - 1 - taken] - taken);
            return total;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/shortest-subarray-with-or-at-least-k-i/">3095. Shortest Subarray With OR at Least K I (easy)</a>
        /// Find the shortest non-empty subarray whose bitwise OR is at least k.
        /// </summary>
        /// <param name="nums">The values to scan.</param>
        /// <param name="k">The required minimum OR value.</param>
        /// <returns>The shortest qualifying length, or -1 when none exists.</returns>
        public int MinimumSubarrayLength(int[] nums, int k)
        {
            int best = int.MaxValue;
            for (int start = 0; start < nums.Length; start++)
            {
                int current = 0;
                for (int end = start; end < nums.Length; end++)
                {
                    current |= nums[end];
                    if (current >= k)
                    {
                        best = Math.Min(best, end - start + 1);
                        break;
                    }
                }
            }
            return best == int.MaxValue ? -1 : best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/longest-strictly-increasing-or-strictly-decreasing-subarray/">3105. Longest Strictly Increasing or Strictly Decreasing Subarray (easy)</a>
        /// Find the longest contiguous subarray that is strictly monotonic.
        /// </summary>
        /// <param name="nums">The values to scan.</param>
        /// <returns>The maximum strictly increasing or decreasing subarray length.</returns>
        public int LongestMonotonicSubarray(int[] nums)
        {
            int increasing = 1, decreasing = 1, best = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                increasing = nums[i] > nums[i - 1] ? increasing + 1 : 1;
                decreasing = nums[i] < nums[i - 1] ? decreasing + 1 : 1;
                best = Math.Max(best, Math.Max(increasing, decreasing));
            }
            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-the-integer-added-to-array-i/">3131. Find the Integer Added to Array I (easy)</a>
        /// Find the constant added to every value of nums1 to obtain nums2.
        /// </summary>
        /// <param name="nums1">The original values.</param>
        /// <param name="nums2">The shifted values.</param>
        /// <returns>The added integer.</returns>
        public int AddedInteger(int[] nums1, int[] nums2)
        {
            return nums2.Min() - nums1.Min();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/special-array-i/">3151. Special Array I (easy)</a>
        /// Check whether adjacent values always have different parity.
        /// </summary>
        /// <param name="nums">The values to inspect.</param>
        /// <returns><see langword="true"/> when every adjacent pair has different parity; otherwise, <see langword="false"/>.</returns>
        public bool IsArraySpecial(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
                if ((nums[i] & 1) == (nums[i - 1] & 1))
                    return false;
            return true;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/special-array-ii/">3152. Special Array II (medium)</a>
        /// Answer whether each queried subarray has alternating parity throughout.
        /// </summary>
        /// <param name="nums">The values to inspect.</param>
        /// <param name="queries">Queries as [from, to] inclusive ranges.</param>
        /// <returns>For each query, whether that range is special.</returns>
        public bool[] IsArraySpecial(int[] nums, int[][] queries)
        {
            var badPrefix = new int[nums.Length];
            for (int i = 1; i < nums.Length; i++)
                badPrefix[i] = badPrefix[i - 1] + (((nums[i] & 1) == (nums[i - 1] & 1)) ? 1 : 0);

            var result = new bool[queries.Length];
            for (int i = 0; i < queries.Length; i++)
                result[i] = badPrefix[queries[i][1]] == badPrefix[queries[i][0]];
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-the-number-of-good-pairs-i/">3162. Find the Number of Good Pairs I (easy)</a>
        /// Count pairs where nums1[i] is divisible by nums2[j] times k.
        /// </summary>
        /// <param name="nums1">The dividend values.</param>
        /// <param name="nums2">The divisor base values.</param>
        /// <param name="k">The divisor multiplier.</param>
        /// <returns>The number of good pairs.</returns>
        public int NumberOfPairs(int[] nums1, int[] nums2, int k)
        {
            int pairs = 0;
            foreach (int left in nums1)
                foreach (int right in nums2)
                    if (left % (right * k) == 0)
                        pairs++;
            return pairs;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-average-of-smallest-and-largest-elements/">3194. Minimum Average of Smallest and Largest Elements (easy)</a>
        /// Pair current smallest and largest values and return the minimum pair average.
        /// </summary>
        /// <param name="nums">The values to pair.</param>
        /// <returns>The minimum average among all removed pairs.</returns>
        public double MinimumAverage(int[] nums)
        {
            Array.Sort(nums);
            double best = double.MaxValue;
            for (int left = 0, right = nums.Length - 1; left < right; left++, right--)
                best = Math.Min(best, (nums[left] + nums[right]) / 2.0);
            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-the-minimum-area-to-cover-all-ones-i/">3195. Find the Minimum Area to Cover All Ones I (medium)</a>
        /// Find the area of the smallest axis-aligned rectangle covering every one in the grid.
        /// </summary>
        /// <param name="grid">The binary grid.</param>
        /// <returns>The minimum covering rectangle area.</returns>
        public int MinimumArea(int[][] grid)
        {
            int minRow = grid.Length, minCol = grid[0].Length, maxRow = -1, maxCol = -1;
            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = 0; col < grid[0].Length; col++)
                {
                    if (grid[row][col] == 1)
                    {
                        minRow = Math.Min(minRow, row);
                        minCol = Math.Min(minCol, col);
                        maxRow = Math.Max(maxRow, row);
                        maxCol = Math.Max(maxCol, col);
                    }
                }
            }
            return (maxRow - minRow + 1) * (maxCol - minCol + 1);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/alternating-groups-i/">3206. Alternating Groups I (easy)</a>
        /// Count length-three circular groups whose middle color differs from both neighbors.
        /// </summary>
        /// <param name="colors">The circular color array.</param>
        /// <returns>The number of alternating groups.</returns>
        public int NumberOfAlternatingGroups(int[] colors)
        {
            int count = 0, n = colors.Length;
            for (int i = 0; i < n; i++)
                if (colors[i] != colors[(i + n - 1) % n] && colors[i] != colors[(i + 1) % n])
                    count++;
            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/alternating-groups-ii/">3208. Alternating Groups II (medium)</a>
        /// Count circular length-k windows whose adjacent colors alternate.
        /// </summary>
        /// <param name="colors">The circular color array.</param>
        /// <param name="k">The alternating group length.</param>
        /// <returns>The number of alternating groups of length <paramref name="k"/>.</returns>
        public int NumberOfAlternatingGroups(int[] colors, int k)
        {
            int n = colors.Length, alternatingRun = 1, count = 0;
            for (int i = 1; i < n + k - 1; i++)
            {
                if (colors[i % n] != colors[(i - 1) % n])
                    alternatingRun++;
                else
                    alternatingRun = 1;

                if (i >= k - 1 && alternatingRun >= k)
                    count++;
            }
            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-operations-to-make-array-values-equal-to-k/">3375. Minimum Operations to Make Array Values Equal to K (easy)</a>
        /// Count distinct values above k when all values are at least k.
        /// </summary>
        /// <param name="nums">The values to reduce.</param>
        /// <param name="k">The target value.</param>
        /// <returns>The minimum operation count, or -1 if any value is below k.</returns>
        public int MinOperationsToMakeArrayValuesEqualToK(int[] nums, int k)
        {
            var above = new HashSet<int>();
            foreach (int num in nums)
            {
                if (num < k)
                    return -1;
                if (num > k)
                    above.Add(num);
            }
            return above.Count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-subarrays-of-length-three-with-a-condition/">3392. Count Subarrays of Length Three With a Condition (easy)</a>
        /// Count length-three windows where the sum of the first and third equals half the middle value.
        /// </summary>
        /// <param name="nums">The values to scan.</param>
        /// <returns>The number of qualifying length-three subarrays.</returns>
        public int CountSubarrays(int[] nums)
        {
            int count = 0;
            for (int i = 0; i + 2 < nums.Length; i++)
                if ((nums[i] + nums[i + 2]) * 2 == nums[i + 1])
                    count++;
            return count;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-difference-between-adjacent-elements-in-a-circular-array/">3423. Maximum Difference Between Adjacent Elements in a Circular Array (easy)</a>
        /// Find the maximum absolute difference between adjacent circular elements.
        /// </summary>
        /// <param name="nums">The circular values.</param>
        /// <returns>The maximum adjacent absolute difference.</returns>
        public int MaxAdjacentDistance(int[] nums)
        {
            int best = 0;
            for (int i = 0; i < nums.Length; i++)
                best = Math.Max(best, Math.Abs(nums[i] - nums[(i + 1) % nums.Length]));
            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/find-the-largest-almost-missing-integer/">3471. Find the Largest Almost Missing Integer (easy)</a>
        /// Find the largest value that appears in exactly one subarray of length k.
        /// </summary>
        /// <param name="nums">The values to inspect.</param>
        /// <param name="k">The subarray length.</param>
        /// <returns>The largest almost missing value, or -1 when none exists.</returns>
        public int LargestInteger(int[] nums, int k)
        {
            var appearances = new Dictionary<int, int>();
            for (int start = 0; start + k <= nums.Length; start++)
            {
                var uniqueInWindow = new HashSet<int>();
                for (int i = start; i < start + k; i++)
                    uniqueInWindow.Add(nums[i]);
                foreach (int value in uniqueInWindow)
                    appearances[value] = appearances.GetValueOrDefault(value) + 1;
            }
            return appearances.Where(pair => pair.Value == 1).Select(pair => pair.Key).DefaultIfEmpty(-1).Max();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-unique-subarray-sum-after-deletion/">3487. Maximum Unique Subarray Sum After Deletion (easy)</a>
        /// Maximize the sum of a non-empty subarray after deleting elements so remaining values are unique.
        /// </summary>
        /// <param name="nums">The values to choose from.</param>
        /// <returns>The maximum possible unique positive sum, or the largest value when all are non-positive.</returns>
        public int MaxSum(int[] nums)
        {
            var positives = nums.Where(num => num > 0).Distinct().ToArray();
            return positives.Length == 0 ? nums.Max() : positives.Sum();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/closest-equal-element-queries/">3488. Closest Equal Element Queries (medium)</a>
        /// For each index, find the closest circular distance to another equal value.
        /// </summary>
        /// <param name="nums">The circular values.</param>
        /// <param name="queries">The queried indices.</param>
        /// <returns>The closest equal-value circular distance per query, or -1 when unique.</returns>
        public IList<int> SolveQueries(int[] nums, int[] queries)
        {
            var positions = new Dictionary<int, List<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!positions.ContainsKey(nums[i]))
                    positions[nums[i]] = new List<int>();
                positions[nums[i]].Add(i);
            }

            var result = new List<int>(queries.Length);
            foreach (int query in queries)
            {
                List<int> list = positions[nums[query]];
                if (list.Count == 1)
                {
                    result.Add(-1);
                    continue;
                }

                int index = list.BinarySearch(query);
                int previous = list[(index - 1 + list.Count) % list.Count];
                int next = list[(index + 1) % list.Count];
                int distancePrevious = Math.Abs(query - previous);
                int distanceNext = Math.Abs(query - next);
                result.Add(Math.Min(Math.Min(distancePrevious, nums.Length - distancePrevious), Math.Min(distanceNext, nums.Length - distanceNext)));
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-operations-to-make-array-sum-divisible-by-k/">3512. Minimum Operations to Make Array Sum Divisible by K (easy)</a>
        /// Compute how many unit decrements are needed to make the array sum divisible by k.
        /// </summary>
        /// <param name="nums">The values to sum.</param>
        /// <param name="k">The divisor.</param>
        /// <returns>The minimum number of decrement operations.</returns>
        public int MinOperationsDivisibleSum(int[] nums, int k)
        {
            return nums.Sum() % k;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/calculate-score-after-performing-instructions/">3522. Calculate Score After Performing Instructions (medium)</a>
        /// Simulate jump/add instructions until an instruction repeats or execution leaves the array.
        /// </summary>
        /// <param name="instructions">The instructions, each either "add" or "jump".</param>
        /// <param name="values">The values used by the instructions.</param>
        /// <returns>The accumulated score before stopping.</returns>
        public long CalculateScore(string[] instructions, int[] values)
        {
            long score = 0;
            int index = 0;
            var visited = new bool[instructions.Length];
            while (index >= 0 && index < instructions.Length && !visited[index])
            {
                visited[index] = true;
                if (instructions[index] == "add")
                {
                    score += values[index];
                    index++;
                }
                else
                {
                    index += values[index];
                }
            }
            return score;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/compute-alternating-sum/">3701. Compute Alternating Sum (easy)</a>
        /// Computes the sum of even-indexed values minus the sum of odd-indexed values.
        /// </summary>
        /// <param name="nums">The values to alternate.</param>
        /// <returns>The alternating sum.</returns>
        public int AlternatingSum(int[] nums)
        {
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
                sum += i % 2 == 0 ? nums[i] : -nums[i];
            return sum;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-distance-between-three-equal-elements-ii/">3741. Minimum Distance Between Three Equal Elements II (medium)</a>
        /// Finds the smallest distance among triples of equal values.
        /// </summary>
        /// <param name="nums">The values whose equal triples are considered.</param>
        /// <returns>The minimum triple distance, or -1 when no triple exists.</returns>
        public int MinimumDistance(int[] nums)
        {
            var positions = new Dictionary<int, Queue<int>>();
            int minimum = int.MaxValue;
            for (int i = 0; i < nums.Length; i++)
            {
                if (!positions.TryGetValue(nums[i], out Queue<int> indices))
                {
                    indices = new Queue<int>();
                    positions[nums[i]] = indices;
                }

                indices.Enqueue(i);
                if (indices.Count == 3)
                {
                    minimum = Math.Min(minimum, 2 * (i - indices.Peek()));
                    indices.Dequeue();
                }
            }
            return minimum == int.MaxValue ? -1 : minimum;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-elements-with-at-least-k-greater-values/">3759. Count Elements With at Least K Greater Values (medium)</a>
        /// Counts values that have at least <paramref name="k"/> strictly greater values.
        /// </summary>
        /// <param name="nums">The values to evaluate.</param>
        /// <param name="k">The required number of greater values.</param>
        /// <returns>The number of qualified elements.</returns>
        public int CountElements(int[] nums, int k)
        {
            if (k == 0)
                return nums.Length;

            int[] sorted = nums.OrderBy(value => value).ToArray();
            int threshold = sorted[nums.Length - k];
            return sorted.Count(value => value < threshold);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/absolute-difference-between-maximum-and-minimum-k-elements/">3774. Absolute Difference Between Maximum and Minimum K Elements (easy)</a>
        /// Returns the difference between the sums of the largest and smallest <paramref name="k"/> values.
        /// </summary>
        /// <param name="nums">The values to select from.</param>
        /// <param name="k">The number of values in each selection.</param>
        /// <returns>The absolute difference between the two sums.</returns>
        public int AbsDifference(int[] nums, int k)
        {
            int[] sorted = nums.OrderBy(value => value).ToArray();
            int difference = 0;
            for (int i = 0; i < k; i++)
                difference += sorted[sorted.Length - 1 - i] - sorted[i];
            return Math.Abs(difference);
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/maximum-score-of-a-split/">3788. Maximum Score of a Split (medium)</a>
        /// Maximizes a prefix sum minus the minimum value in the following suffix.
        /// </summary>
        /// <param name="nums">The values to split.</param>
        /// <returns>The greatest valid split score.</returns>
        public long MaximumScore(int[] nums)
        {
            var suffixMinimums = new int[nums.Length];
            suffixMinimums[nums.Length - 1] = nums[nums.Length - 1];
            for (int i = nums.Length - 2; i >= 0; i--)
                suffixMinimums[i] = Math.Min(nums[i], suffixMinimums[i + 1]);

            long prefixSum = 0;
            long best = long.MinValue;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                prefixSum += nums[i];
                best = Math.Max(best, prefixSum - suffixMinimums[i + 1]);
            }
            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-subarray-length-with-distinct-sum-at-least-k/">3795. Minimum Subarray Length With Distinct Sum At Least K (medium)</a>
        /// Finds the shortest window whose distinct values sum to at least <paramref name="k"/>.
        /// </summary>
        /// <param name="nums">The positive values to scan.</param>
        /// <param name="k">The required distinct-value sum.</param>
        /// <returns>The shortest qualifying length, or -1 when none exists.</returns>
        public int MinLength(int[] nums, int k)
        {
            var counts = new Dictionary<int, int>();
            long sum = 0;
            int left = 0, best = int.MaxValue;
            for (int right = 0; right < nums.Length; right++)
            {
                counts[nums[right]] = counts.GetValueOrDefault(nums[right]) + 1;
                if (counts[nums[right]] == 1)
                    sum += nums[right];

                while (sum >= k)
                {
                    best = Math.Min(best, right - left + 1);
                    if (--counts[nums[left]] == 0)
                    {
                        counts.Remove(nums[left]);
                        sum -= nums[left];
                    }
                    left++;
                }
            }
            return best == int.MaxValue ? -1 : best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-subarrays-with-k-distinct-integers/">3859. Count Subarrays With K Distinct Integers (hard)</a>
        /// Counts subarrays with exactly <paramref name="k"/> distinct values, each occurring at least <paramref name="m"/> times.
        /// </summary>
        /// <param name="nums">The values to partition into subarrays.</param>
        /// <param name="k">The required distinct-value count.</param>
        /// <param name="m">The minimum frequency of every distinct value.</param>
        /// <returns>The number of qualifying subarrays.</returns>
        public long CountSubarrays(int[] nums, int k, int m)
        {
            var positions = new Dictionary<int, Queue<int>>();
            var thresholds = new SortedSet<(int Position, int Value)>();
            int left = 0, distinct = 0;
            long result = 0;

            for (int right = 0; right < nums.Length; right++)
            {
                UpdatePositions(nums[right], right, positions, thresholds, m, true);
                if (positions[nums[right]].Count == 1)
                    distinct++;

                while (distinct > k)
                {
                    int value = nums[left++];
                    UpdatePositions(value, 0, positions, thresholds, m, false);
                    if (positions[value].Count == 0)
                    {
                        positions.Remove(value);
                        distinct--;
                    }
                }

                if (distinct == k && thresholds.Count == k)
                    result += thresholds.Min.Position - left + 1;
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/concatenate-array-with-reverse/">3925. Concatenate Array With Reverse (easy)</a>
        /// Concatenates an array with a reversed copy of itself.
        /// </summary>
        /// <param name="nums">The values to concatenate.</param>
        /// <returns>The original values followed by their reverse.</returns>
        public int[] ConcatWithReverse(int[] nums)
        {
            var result = new int[nums.Length * 2];
            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = nums[i];
                result[nums.Length + i] = nums[nums.Length - 1 - i];
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/minimum-swaps-to-move-zeros-to-end/">3936. Minimum Swaps to Move Zeros to End (easy)</a>
        /// Counts the swaps needed to place every zero after all nonzero values.
        /// </summary>
        /// <param name="nums">The values containing zeros to move.</param>
        /// <returns>The minimum number of arbitrary swaps.</returns>
        public int MinimumSwaps(int[] nums)
        {
            int left = 0, right = nums.Length - 1, swaps = 0;
            while (left < right)
            {
                while (left < right && nums[left] != 0)
                    left++;
                while (left < right && nums[right] == 0)
                    right--;
                if (left < right)
                {
                    swaps++;
                    left++;
                    right--;
                }
            }
            return swaps;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/limit-occurrences-in-sorted-array/">3940. Limit Occurrences in Sorted Array (easy)</a>
        /// Retains no more than <paramref name="k"/> copies of each value in sorted order.
        /// </summary>
        /// <param name="nums">The sorted values to filter.</param>
        /// <param name="k">The maximum copies retained for each value.</param>
        /// <returns>The filtered values.</returns>
        public int[] LimitOccurrences(int[] nums, int k)
        {
            var result = new List<int>(nums.Length);
            foreach (int value in nums)
            {
                if (result.Count < k || result[result.Count - k] != value)
                    result.Add(value);
            }
            return result.ToArray();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/longest-subarray-with-at-most-k-distinct-prime-factors/">4032. Longest Subarray With at Most K Distinct Prime Factors (medium)</a>
        /// Finds the longest window whose union of prime factors contains at most <paramref name="k"/> primes.
        /// </summary>
        /// <param name="nums">The positive values to factor.</param>
        /// <param name="k">The maximum number of distinct prime factors.</param>
        /// <returns>The length of the longest qualifying subarray.</returns>
        public int LongestSubarray(int[] nums, int k)
        {
            var factors = nums.Select(GetDistinctPrimeFactors).ToArray();
            var counts = new Dictionary<int, int>();
            int left = 0, best = 0;
            for (int right = 0; right < nums.Length; right++)
            {
                foreach (int factor in factors[right])
                    counts[factor] = counts.GetValueOrDefault(factor) + 1;

                while (counts.Count > k)
                {
                    foreach (int factor in factors[left++])
                    {
                        if (--counts[factor] == 0)
                            counts.Remove(factor);
                    }
                }
                best = Math.Max(best, right - left + 1);
            }
            return best;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/count-integers-appearing-in-a-single-block/">4038. Count Integers Appearing in a Single Block (easy)</a>
        /// Counts distinct values whose occurrences form exactly one contiguous block.
        /// </summary>
        /// <param name="nums">The values to inspect.</param>
        /// <returns>The count of values that appear in one block.</returns>
        public int CountSpecialIntegers(int[] nums)
        {
            var blocks = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0 || nums[i] != nums[i - 1])
                    blocks[nums[i]] = blocks.GetValueOrDefault(nums[i]) + 1;
            }
            return blocks.Count(pair => pair.Value == 1);
        }

        private static void UpdatePositions(int value, int index, Dictionary<int, Queue<int>> positions, SortedSet<(int Position, int Value)> thresholds, int minimumFrequency, bool add)
        {
            if (!positions.TryGetValue(value, out Queue<int> queue))
            {
                queue = new Queue<int>();
                positions[value] = queue;
            }

            if (queue.Count >= minimumFrequency)
                thresholds.Remove((queue.ElementAt(queue.Count - minimumFrequency), value));

            if (add)
                queue.Enqueue(index);
            else
                queue.Dequeue();

            if (queue.Count >= minimumFrequency)
                thresholds.Add((queue.ElementAt(queue.Count - minimumFrequency), value));
        }

        private static IEnumerable<int> GetDistinctPrimeFactors(int value)
        {
            for (int factor = 2; factor * factor <= value; factor++)
            {
                if (value % factor != 0)
                    continue;

                yield return factor;
                while (value % factor == 0)
                    value /= factor;
            }
            if (value > 1)
                yield return value;
        }


    }
}
