﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Library
{
    public class Arrays
    {
        /// <summary>
        /// 1. Two Sum (easy)
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
        /// 4. Median of Two Sorted Arrays (hard)
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
        /// 11. Container With Most Water (medium)
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
        /// 14. Longest Common Prefix (easy)
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
        /// 15. 3Sum (medium)
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
        /// 16. 3Sum Closest (medium)
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
        /// 26. Remove Duplicates from Sorted Array (easy)
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
        /// 27. Remove Element (easy)
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
        /// 169. Majority Element (easy)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MajorityElement(int[] nums)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (int i in nums)
            {
                if (dict.ContainsKey(i))
                {
                    if (dict[i] + 1 > nums.Length / 2)
                        return i;
                    dict[i] += 1;
                }
                else
                    dict.Add(i, 1);
            }
            return nums[0];
        }

        /// <summary>
        /// 217. Contains Duplicate
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
