using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Library
{
    public class LinkedLists
    {
        /// <summary>
        /// 203. Remove Linked List Elements
        /// </summary>
        /// <param name="head"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public ListNode RemoveElements(ListNode head, int val)
        {
            ListNode current = head;
            ListNode previous = null;
            while (current != null && current.val == val)
            {
                current = current.next;
            }
            head = current;
            while (current != null)
            {
                if (current.val == val)
                {
                    if (previous == null)
                    {
                        head = current.next;
                    }
                    else
                    {
                        previous.next = current.next;
                    }
                }
                else
                {
                    previous = current;
                }
                current = current.next;
            }
            return head;
        }

        /// <summary>
        /// 206. Reverse Linked List
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>

        public ListNode ReverseList(ListNode head)
        {
            ListNode newRoot = null;
            while (head != null)
            {
                newRoot = new ListNode(head.val, newRoot);
                head = head.next;
            }
            return newRoot;
        }
    }

    /// <summary>
    /// Definition for singly-linked list
    /// </summary>
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
