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
        /// <a href="">1. Two Sum (easy)</a>
        /// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
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
        /// <a href="">4. Median of Two Sorted Arrays (hard)</a>
        /// Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
        /// </summary>
        /// <param name="nums1">Sorted Array 1</param>
        /// <param name="nums2">Sorted Array 2</param>
        /// <returns>median of the two sorted arrays</returns>
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
        /// <a href="">11. Container With Most Water (medium)</a>
        /// Find two lines that together with the x-axis form a container, such that the container contains the most water.
        /// </summary>
        /// <param name="height"></param>
        /// <returns>the maximum amount of water a container can store</returns>
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
        /// <a href="">14. Longest Common Prefix (easy)</a>
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
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
        /// <a href="">15. 3Sum (medium)</a>
        /// Given an integer array nums, return all the triplets
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
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
        /// <a href="">16. 3Sum Closest (medium)</a>
        /// Given an integer array nums of length n and an integer target, find three integers in nums such that the sum is closest to target.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns>the sum of the three integers</returns>
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
        /// <a href="">26. Remove Duplicates from Sorted Array (easy)</a>
        /// Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int RemoveDuplicates(int[] nums)
        {
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
        /// <a href="">27. Remove Element (easy)</a>
        /// Given an integer array nums and an integer val, remove all occurrences of val in nums in-place. The relative order of the elements may be changed.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="val"></param>
        /// <returns></returns>
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
        /// <a href="">35. Search Insert Position (easy)</a>
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
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
        /// <a href="https://leetcode.com/problems/plus-one/">66. Plus One (easy)</a>
        /// You are given a large integer represented as an integer array digits, where each digits[i] is the ith digit of the integer. The digits are ordered from most significant to least significant in left-to-right order. The large integer does not contain any leading 0's.
        /// Increment the large integer by one and return the resulting array of digits.
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
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
        /// You are given two integer arrays nums1 and nums2, sorted in non-decreasing order, and two integers m and n, representing the number of elements in nums1 and nums2 respectively.
        /// Merge nums1 and nums2 into a single array sorted in non-decreasing order.
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
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
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
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
        /// Given a non-empty array of integers nums, every element appears twice except for one. Find that single one. 
        /// You must implement a solution with a linear runtime complexity and use only constant extra space.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
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
        /// <a href="https://leetcode.com/problems/majority-element/description/">169. Majority Element (easy)</a>
        /// Given an array nums of size n, return the majority element.
        /// The majority element is the element that appears more than ⌊n / 2⌋ times.You may assume that the majority element always exists in the array.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
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
        /// <a href="">217. Contains Duplicate (easy)</a>
        /// Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
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
    }
}
