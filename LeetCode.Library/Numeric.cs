using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Library
{
    public class Numeric
    {
        /// <summary>
        /// <a href="https://leetcode.com/problems/palindrome-number">9. Palindrome Number (easy)</a>
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool IsPalindrome(int x)
        {
            if (x < 0) return false;
            int original = x;
            int reversed = 0;
            while (x > 0)
            {
                reversed = reversed * 10 + x % 10;
                x /= 10;
            }
            return reversed == original;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/sqrtx/">69. Sqrt(x) (easy)</a>
        /// Given a non-negative integer x, return the square root of x rounded down to the nearest integer. The returned integer should be non-negative as well.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int MySqrt(int x)
        {
            long low, high;
            low = 1;
            high = x;
            long mid = (low + high) / 2; ;

            while (low <= high)
            {
                mid = (low + high) / 2;

                if (mid * mid <= x)
                    low = mid + 1;

                else
                    high = mid - 1;
            }
            return (int)high;
        }

        /// <summary>
        /// <a href"https://leetcode.com/problems/climbing-stairs/">70. Climbing Stairs (easy)</a>
        /// You are climbing a staircase. It takes n steps to reach the top.
        /// Each time you can either climb 1 or 2 steps.In how many distinct ways can you climb to the top?
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs(int n)
        {
            if (n == 1)
                return 1;
            int first = 1;
            int last = 2;
            for (int i = 3; i <= n; i++)
            {
                var r = first + last;
                first = last;
                last = r;
            }

            return last;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/pascals-triangle/">118. Pascal's Triangle (easy)</a>
        /// Given an integer numRows, return the first numRows of Pascal's triangle.
        /// </summary>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public IList<IList<int>> Generate(int numRows)
        {
            List<IList<int>> result = new List<IList<int>>();
            List<int> lastrow = new List<int>();
            while (numRows-- > 0)
            {
                List<int> newrow = new List<int>();
                if (lastrow.Count == 0)
                {
                    newrow.Add(1);
                }
                else
                {
                    newrow.Add(1);
                    for (int i = 0; i < lastrow.Count - 1; i++)
                    {
                        newrow.Add(lastrow[i] + lastrow[i + 1]);
                    }
                    newrow.Add(1);
                }
                result.Add(newrow);
                lastrow = newrow;
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/excel-sheet-column-title/description/">168. Excel Sheet Column Title</a>
        /// Given an integer columnNumber, return its corresponding column title as it appears in an Excel sheet.
        /// </summary>
        /// <param name="columnNumber"></param>
        /// <returns></returns>
        public string ConvertToTitle(int columnNumber)
        {
            StringBuilder sb = new StringBuilder();
            while (columnNumber > 0)
            {
                columnNumber--;
                sb.Insert(0, (char)('A' + columnNumber % 26));
                columnNumber /= 26;
            }

            return sb.ToString();
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/happy-number/">202. Happy Number (easy)</a>
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsHappy(int n)
        {
            if (n == 1)
            {
                return true;
            }
            HashSet<int> seen = new HashSet<int>();
            while (n != 1)
            {
                int sum = 0;
                while (n != 0)
                {
                    sum += (n % 10) * (n % 10);
                    n /= 10;
                }
                if (seen.Contains(sum))
                {
                    return false;
                }
                seen.Add(sum);
                n = sum;
            }
            return true;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/nim-game/">292. Nim Game (easy)</a>
        /// Given n, the number of stones in the heap, return true if you can win the game assuming both you and your friend play optimally, otherwise return false.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool CanWinNim(int n)
        {
            return n % 4 != 0;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/power-of-three/">326. Power of Three (easy)</a>
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsPowerOfThree(int n)
        {
            if (n == 0)
            {
                return false;
            }

            while (n != 1)
            {
                if ((n - (3 * (n / 3))) != 0)// not cleanly divisible by 3
                {
                    return false;
                }
                else
                {
                    n = (n / 3);
                }
            }
            return true;
        }


        /// <summary>
        /// <a href="https://leetcode.com/problems/fizz-buzz/">412. Fizz Buzz (easy)</a>
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<string> FizzBuzz(int n)
        {
            List<string> result = new List<string>();
            for (int i = 1; i <= n; i++)
            {
                if (i % 15 == 0)
                    result.Add("FizzBuzz");
                else if (i % 3 == 0)
                    result.Add("Fizz");
                else if (i % 5 == 0)
                    result.Add("Buzz");
                else
                    result.Add(i.ToString());
            }
            return result;
        }

        /// <summary>
        /// <a href="https://leetcode.com/problems/arranging-coins/">441. Arranging Coins (easy)</a>
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ArrangeCoins(int n)
        {
            int l = 1, r = n;
            int total = 0;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                double coins = (double)(mid) / 2.0 * (mid + 1);
                if (coins > n)
                    r = mid - 1;
                else
                {
                    // coins <= n, we need to record total for coins == n
                    l = mid + 1;
                    total = Math.Max(total, mid);
                }
            }
            return total;
        }
    }
}
