using System;

namespace Developer_Toolkit.Algorithms
{
    /// <summary>
    /// A utility class that provides various searching algorithms for arrays.
    /// </summary>
    public class Search
    {
        /// <summary>
        /// Performs a binary search on a sorted array to find the index of the target element.
        /// </summary>
        /// <param name="arr">The sorted array to search in.</param>
        /// <param name="target">The target element to find.</param>
        /// <returns>The index of the target element in the array, or -1 if not found.</returns>
        public static int BinarySearch(int[] arr, int target)
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] == target)
                    return mid;
                else if (arr[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1; // Target not found
        }

        /// <summary>
        /// Performs a linear search on an array to find the index of the target element.
        /// </summary>
        /// <param name="arr">The array to search in.</param>
        /// <param name="target">The target element to find.</param>
        /// <returns>The index of the target element in the array, or -1 if not found.</returns>
        public static int LinearSearch(int[] arr, int target)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == target)
                    return i;
            }

            return -1; // Target not found
        }

        /// <summary>
        /// Performs a jump search on a sorted array to find the index of the target element.
        /// </summary>
        /// <param name="arr">The sorted array to search in.</param>
        /// <param name="target">The target element to find.</param>
        /// <returns>The index of the target element in the array, or -1 if not found.</returns>
        public static int JumpSearch(int[] arr, int target)
        {
            int n = arr.Length;
            int step = (int)System.Math.Floor(System.Math.Sqrt(n));
            int prev = 0;

            while (arr[System.Math.Min(step, n) - 1] < target)
            {
                prev = step;
                step += (int)System.Math.Floor(System.Math.Sqrt(n));
                if (prev >= n)
                    return -1;
            }

            while (arr[prev] < target)
            {
                prev++;

                if (prev == System.Math.Min(step, n))
                    return -1;
            }

            if (arr[prev] == target)
                return prev;

            return -1; // Target not found
        }

        /// <summary>
        /// Performs an interpolation search on a sorted array to find the index of the target element.
        /// </summary>
        /// <param name="arr">The sorted array to search in.</param>
        /// <param name="target">The target element to find.</param>
        /// <returns>The index of the target element in the array, or -1 if not found.</returns>
        public static int InterpolationSearch(int[] arr, int target)
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left <= right && target >= arr[left] && target <= arr[right])
            {
                if (left == right)
                {
                    if (arr[left] == target)
                        return left;
                    return -1; // Target not found
                }

                int pos = left + (((right - left) / (arr[right] - arr[left])) * (target - arr[left]));

                if (arr[pos] == target)
                    return pos;
                else if (arr[pos] < target)
                    left = pos + 1;
                else
                    right = pos - 1;
            }

            return -1; // Target not found
        }
    }
}
