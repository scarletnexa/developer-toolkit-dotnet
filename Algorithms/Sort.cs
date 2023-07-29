using System;

namespace Developer_Toolkit.Algorithms
{
    /// <summary>
    /// A utility class that provides various sorting algorithms for arrays.
    /// </summary>
    public class Sort
    {
        /// <summary>
        /// Performs the Bubble Sort algorithm on the given array, sorting it in ascending order.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <returns>The sorted array.</returns>
        public static int[] BubbleSort(int[] arr)
        {
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                bool swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // Swap elements
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        swapped = true;
                    }
                }

                // If no two elements were swapped in the inner loop, the array is already sorted
                if (!swapped)
                    break;
            }

            return arr;
        }

        /// <summary>
        /// Performs the Insertion Sort algorithm on the given array, sorting it in ascending order.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <returns>The sorted array.</returns>
        public static int[] InsertionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;

                // Move elements of arr[0..i-1] that are greater than key to one position ahead of their current position
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = key;
            }

            return arr;
        }

        /// <summary>
        /// Performs the Selection Sort algorithm on the given array, sorting it in ascending order.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <returns>The sorted array.</returns>
        public static int[] SelectionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIdx = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[minIdx])
                        minIdx = j;
                }

                // Swap the found minimum element with the first element
                int temp = arr[minIdx];
                arr[minIdx] = arr[i];
                arr[i] = temp;
            }

            return arr;
        }
    }
}
