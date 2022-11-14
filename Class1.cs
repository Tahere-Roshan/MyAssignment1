//1-Create Dynamic Library

using System;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Threading;


namespace Algorithm
{
    public class Myclass
    {
        //Part D

        //Delegate 
        public delegate void SortedDelegate1(int[] myArray);

        //Swap Method
        public static void Swap(int[] myArray, int i, int j)
        {
            int temp;
            temp = myArray[i];
            myArray[i] = myArray[j];
            myArray[j] = temp;
        }

        //Randomize Method
        public static int[] Randmize(int[] myArray)
        {
            Random random = new();
            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = random.Next(0, 10 * myArray.Length);

            }
            return myArray;
        }

        //Prepare Method
        public static int[] Prepare(int Arraysize)
        {
            int[] myArray = new int[Arraysize];
            return Randmize(myArray);
            //return myArray;
        }


        //Insertion Sort Method-https://www.w3resource.com/csharp-exercises/searching-and-sorting-algorithm/searching-and-sorting-algorithm-exercise-6.php
        public static void InstertionSort(int[] myArray)
        {
            for (int i = 0; i <= myArray.Length - 1; i++) {
                for (int j = i + 1; j > 0; j--)
                {
                    if (myArray[j - 1] > myArray[j])
                    {
                        Swap(myArray, j - 1, j);
                    }
                }
            }
            Console.WriteLine("Insertion Sort:" + myArray);
            Console.ReadLine();
        }

        //Selection Sort Method-https://youtu.be/yCxV0kBpA6M
        public static void SelectionSort(int[] myArray)
        {
            for (int i = 0; i < myArray.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < myArray.Length; j++)
                {
                    if (myArray[min] > myArray[j])
                    {
                        min = j;
                    }
                    Swap(myArray, i, min);
                }

            }
            Console.WriteLine("Selection Sort:" + myArray);
            Console.ReadLine();
        }

        //Bubble Sort Method-https://www.educba.com/bubble-sort-in-c-sharp/
        public static void BubbleSort(int[] myArray)
        {
            for (int i = 0; i < myArray.Length - 1; i++)
            {
                for (int j = 0; j < myArray.Length - i - 1; j++)
                {
                    if (myArray[j] > myArray[j + 1])
                    {
                        Swap(myArray, j + 1, j);
                    }
                }
            }
            Console.WriteLine("Bubble Sort:" + myArray);
            Console.ReadLine();
        }
         
       //Merg Sort Metho-https://www.c-sharpcorner.com/blogs/a-simple-merge-sort-implementation-c-sharp
        public static int[] MergeSort(int[] myArray)
        {
            int[] left;
            int[] right;
            //int[] result = new int[myArray.Length];
            if (myArray.Length <= 1)
                return myArray;
            int midPoint = myArray.Length / 2;
            left = new int[midPoint];
            if (myArray.Length % 2 == 0)
                right = new int[midPoint];
            else
                right = new int[midPoint + 1];
            for (int i = 0; i <= midPoint; i++)
            {
                left[i] = myArray[i];
            }
            int x = 0;
            for (int i = midPoint; i <= midPoint + 1; i++)
            {
                right[x++] = myArray[i];
            }
            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(right, left);
            //result = Merge(right, left);
            //return result;
        }
               

       //Quick Sort Method-https://code-maze.com/csharp-quicksort-algorithm/
        public static int[] QuickSort(int[] myArray)
        {
            int leftIndex = 0;
            int rightIndex = myArray.Length-1;
            int pivot = myArray[leftIndex];
            while (leftIndex <= rightIndex)
            {
                while (myArray[leftIndex] < pivot)
                {
                    leftIndex++;
                }
                while (myArray[rightIndex] < pivot)
                {
                    rightIndex--;
                }
                if (leftIndex <= rightIndex)
                {
                    Swap(myArray, leftIndex, rightIndex);
                    leftIndex++;
                    rightIndex--;
                }
            }
            if (leftIndex < rightIndex)
            {
                QuickSort(myArray);
            }
            return myArray;
        }
           

       //Merge Method (useful for sort method)-https://www.c-sharpcorner.com/blogs/a-simple-merge-sort-implementation-c-sharp
            static int[] Merge(int[] right, int[] left)
                {
                    int resultLength = left.Length + right.Length;
                    int[] result = new int[resultLength];
                    int indexLeft = 0, indexRight = 0, indexResult = 0;
                    while (indexLeft < left.Length || indexRight < right.Length)
                    {
                        if (indexLeft < left.Length && indexRight < right.Length)
                        {
                            if (left[indexLeft] <= right[indexRight])
                            {
                                result[indexResult] = left[indexLeft];
                                indexLeft++;
                                indexResult++;
                            }
                            else
                            {
                                result[indexResult] = right[indexRight];
                                indexRight++;
                                indexResult++;
                            }
                        }
                        else if (indexLeft < left.Length)
                        {
                            result[indexResult] = left[indexLeft];
                            indexLeft++;
                            indexResult++;
                        }
                        else if (indexRight < right.Length)
                        {
                            result[indexResult] = right[indexRight];
                            indexRight++;
                            indexResult++;
                        }
                    }
                    return result;
                }

        //Method "SortByLamba"-https://www.dotnetperls.com/sort-list-https://www.youtube.com/watch?v=F6iHzYLh2cA
        public static void SortByLamba(int[] myArray)
        {
            int[] LambaArray= new int[myArray.Length];
            LambaArray= myArray.OrderBy(x => x).ToArray();
            Console.WriteLine("Sort by Lamba:" + myArray);
            Console.ReadLine();
        }

        //Method "DisplayRunningTime"
        public static void DisplayRunngTime1(int[] myArray, SortedDelegate1 sorteddelgate1)
        {
            Stopwatch myStopwatch = new();
            myStopwatch.Start();
            sorteddelgate1(myArray);
            myStopwatch.Stop();
            TimeSpan ts = myStopwatch.Elapsed;
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("RunTime" + elapsedTime);

        }

        //Part C

        //Delegated Method
        public delegate void SortedDelegate2(int[] myArray, int item);

        //Linear Search Method-http://anh.cs.luc.edu/170/notes/CSharpHtml/searching.html
        public static int LinearSearch(int[] myArray, int item)
        {
            int N = myArray.Length;
            for (int i = 0; i < N; i++)
                if (myArray[i] == item)
                    return i;
            return -1;
        }

        //Linear Search Method-https://www.geeksforgeeks.org/binary-search/?ref=lbp
        public static int BinarySearch(int[] myArray, int item)
        {
            MergeSort(myArray);//which sort is the best?
            int low = 0, high = myArray.Length - 1;
            while(low<= high)
            {
                int mid = (low + high) / 2;
                if (myArray[mid]==item)
                    return mid;
                if (myArray[mid]<item) 
                    low = mid + 1;
                else
                    high = mid - 1;
            }
            return -1;
        }

        //Method "DisplayRunningTime"
        public static void DisplayRunngTime2(int[] myArray, int item, SortedDelegate2 sorteddelgate2)
        {
            Stopwatch myStopwatch = new();
            myStopwatch.Start();
            sorteddelgate2(myArray, item);
            myStopwatch.Stop();
            TimeSpan ts = myStopwatch.Elapsed;
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("RunTime" + elapsedTime);

        }


    }
}
  
