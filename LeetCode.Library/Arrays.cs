using System;
using System.Collections.Generic;

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
    }
}
