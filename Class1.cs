//Reference-https://www.tutorialsteacher.com/articles/generate-random-numbers-in-csharp


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
using System.Runtime.CompilerServices;

namespace Algorithm
{
   
    public class Myclass
    {

        //Part D

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
            Random random = new Random();
            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = random.Next(0, 10 * myArray.Length);

            }
            return myArray;
        }

        //Prepare Method
        public int[] Prepare(int Arraysize)
        {
            int[] myArray = new int[Arraysize];
            return Randmize(myArray);
            //return myArray;
        }



       
        //Insertion Sort Method-https://www.youtube.com/watch?v=yCxV0kBpA6M
        
        public void InstertionSort(int[] myArray)
        {
            int j, temp;
      
            for (int i = 1; i < myArray.Length; i++) {
                temp= myArray[i];
                j= i - 1;
                while(j>= 0 && myArray[j]>temp)
                {
                    myArray[j+1] = myArray[j];
                    j--;
                }
                myArray[j+1] = temp;
            }
            //for(int count=0; count<myArray.Length; count++)
            //    Console.WriteLine(myArray[count]);
            
           
        }

        //Selection Sort Method-https://youtu.be/yCxV0kBpA6M
        public void SelectionSort(int[] myArray)
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
            //for (int count = 0; count < myArray.Length; count++)
            //    Console.WriteLine(myArray[count]);

        }

        //Bubble Sort Method-https://www.educba.com/bubble-sort-in-c-sharp/
        public void BubbleSort(int[] myArray)
        {
            for (int i = 0; i < myArray.Length; i++)
            {
                for (int j = 0; j < myArray.Length - 1; j++)
                {
                    if (myArray[j] > myArray[j + 1])
                    {
                        Swap(myArray, j + 1, j);
                    }
                }
            }
            //for (int count = 0; count < myArray.Length; count++)
              //  Console.WriteLine(myArray[count]);

        }
         
       //Merg Sort Metho-https://www.c-sharpcorner.com/blogs/a-simple-merge-sort-implementation-c-sharp
        public int[] MergeSort(int[] myArray)
        {
            int[] left;
            int[] right;
            int midPoint = myArray.Length / 2;
            //int[] result = new int[myArray.Length];
            if (myArray.Length <= 1)
                return myArray;
            
            left = new int[midPoint];
            if (myArray.Length % 2 == 0)
                right = new int[midPoint];
            else
                right = new int[midPoint + 1];
            for (int i = 0; i < midPoint; i++)
            {
                left[i] = myArray[i];
            }
            int x = 0;
            for (int i = midPoint; i <= midPoint + 1; i++)
            {
                right[x] = myArray[i];
                x++;
            }
            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(right, left);
            //result = Merge(right, left);
            //return result;
        }
               

       //Quick Sort Method-https://code-maze.com/csharp-quicksort-algorithm/
        public void QuickSort(int[] myArray)
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
            //for (int count = 0; count < myArray.Length; count++)
            //    Console.WriteLine(myArray[count]);
        }
           

       //Merge Method (useful for sort method)-https://www.c-sharpcorner.com/blogs/a-simple-merge-sort-implementation-c-sharp
            public int[] Merge(int[] right, int[] left)
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
        
        public void SortByLamba(int[] myArray)
        {
            Array.Sort(myArray, (x, y) => x.CompareTo(y));
            //for (int count = 0; count < myArray.Length; count++)
              //  Console.WriteLine(myArray[count]);

        }


        //Delegate 
        public delegate int SortedDelegate1(int[] myArray);

        
        //just to initial Delegated Method in the Consol App
        public static int Spam1(int[] myArray)
        {
            return 1;
        }

        //Method "DisplayRunningTime"
        public void SortDisplayRunngTime(int[] myArray, SortedDelegate1 sorteddelgate1)
        {
            Stopwatch myStopwatch = new Stopwatch();
            myStopwatch.Start();
            Console.WriteLine(sorteddelgate1(myArray));
            myStopwatch.Stop();
            TimeSpan ts = myStopwatch.Elapsed;
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            Console.WriteLine("SortRunTime" + elapsedTime);

        }


        //Part C

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
        public int BinarySearch(int[] myArray, int item)
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

        //Search By Lamba
        public static int LambaSearch(int[] myArray, int item)
        {
            return Array.Find(myArray, x => x==item);

        }



        //Delegated Method
        public delegate int SearchDelegate2(int[] myArray, int item);
        public static int Spam2(int[] myArray, int item)
        {
            return 1;
        }

        //Method "DisplayRunningTime"

        public void SearchDisplayRunngTime1(int[] myArray, SearchDelegate2 searchdelgate2)
        {
            Stopwatch myStopwatch = new Stopwatch();
            //First in the Array
            myStopwatch.Start();
            Console.WriteLine(searchdelgate2(myArray, myArray[0]));
            //searchdelgate2(myArray, myArray[0]);
            myStopwatch.Stop();
            TimeSpan ts = myStopwatch.Elapsed;
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            Console.WriteLine("FirtSearchRunTime:"+"" + elapsedTime);


            //Middle of  the Array
            myStopwatch.Start();
            Console.WriteLine(searchdelgate2(myArray, myArray[(myArray.Length)/2]));
            //searchdelgate2(myArray, myArray[0]);
            myStopwatch.Stop();
            //elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            Console.WriteLine("MiddleSearchRunTime:" + "" + elapsedTime);

            //Last of  the Array
            myStopwatch.Start();
            Console.WriteLine(searchdelgate2(myArray, myArray[myArray.Length-1 ]));
            //searchdelgate2(myArray, myArray[0]);
            myStopwatch.Stop();
            //elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            Console.WriteLine("LastSearchRunTime:" + "" + elapsedTime);


        }



        //Part B
        //Compare Performance
        //refences-https://www.tutorialsteacher.com/csharp/csharp-arraylist
        //reference-https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic?view=net-7.0

        public void performance(int number)
        {
            int[] myArray = new int[];
            List<int> myList = new List<int>();
            Stack<int> mystack = new Stack<int>();
            Queue<int> myQeue = new Queue<int>();
            Dictionary<int, int> myDictionary = new Dictionary<int, int>();
            SortedDictionary<int, int> mySortedDictionary = new SortedDictionary<int, int>();
            HashSet<int> myHashset = new HashSet<int>();
            Random myRandom = new Random();
            Stopwatch myStopwatch = new Stopwatch();
            TimeSpan Performts = myStopwatch.Elapsed;
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", Performts.Hours, Performts.Minutes, Performts.Seconds, Performts.Milliseconds);

            static void Addition(int element)
            {

                //Perfomance of Add into Array
                AddStopwatch.Start();
                for (int i = 0; i < number; i++)
                {
                    AddArray.SetValue(i, AddArray[i]);
                    AddArray.Initialize();

                }
                AddStopwatch.Stop();
                Console.WriteLine("Add in Array:" + "" + elapsedTime);

                //Perfomance of Add into Dynamic Array List
                AddStopwatch.Start();
                for (int i = 0; i < number; i++)
                {
                    AddList.Add(AddRandom.Next(0, 10 * i));

                }
                AddStopwatch.Stop();
                Console.WriteLine("Add in List:" + "" + elapsedTime);

                //Perfomance of Add into Stack
                AddStopwatch.Start();
                for (int i = 0; i < number; i++)
                {
                    AddStack.Push(AddRandom.Next(0, 10 * i));

                }
                AddStopwatch.Stop();
                Console.WriteLine("Add in List:" + "" + elapsedTime);

                //Perfomance of Add into Qeue
                AddStopwatch.Start();
                for (int i = 0; i < number; i++)
                {
                    AddQeue.Enqueue(AddRandom.Next(0, 10 * i));

                }
                AddStopwatch.Stop();
                Console.WriteLine("Add in List:" + "" + elapsedTime);

                //Perfomance of Add into Dictionary
                AddStopwatch.Start();
                for (int i = 0; i < number; i++)
                {
                    AddDictionary.Add(AddDictionary.Count, AddRandom.Next(0, 10 * i));

                }
                AddStopwatch.Stop();
                Console.WriteLine("Add in List:" + "" + elapsedTime);

                //Perfomance of Add into SotedDictionary
                AddStopwatch.Start();
                for (int i = 0; i < number; i++)
                {
                    AddSortedDic.Add(AddDictionary.Count, AddRandom.Next(0, 10 * i));

                }
                AddStopwatch.Stop();
                Console.WriteLine("Add in List:" + "" + elapsedTime);

                //Perfomance of Add into HashSet
                AddStopwatch.Start();
                for (int i = 0; i < number; i++)
                {
                    AddHashSet.Add(AddRandom.Next(0, 10 * i));

                }
                AddStopwatch.Stop();
                Console.WriteLine("Add in List:" + "" + elapsedTime);


            }


            public void Deletion(int number)
            {
                int[] DelArray = new int[number];
                List<int> DelList = new List<int>();
                Stack<int> DelStack = new Stack<int>();
                Queue<int> DelQeue = new Queue<int>();
                Dictionary<int, int> DelDictionary = new Dictionary<int, int>();
                SortedDictionary<int, int> DelSortDic = new SortedDictionary<int, int>();
                HashSet<int> DelHash = new HashSet<int>();
                Random DelRandom = new Random();
                Stopwatch DelStopwatch = new Stopwatch();
                TimeSpan Delts = DelStopwatch.Elapsed;
                string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", Delts.Hours, Delts.Minutes, Delts.Seconds, Delts.Milliseconds);

                //Perfomance of Delete form Array
                DelStopwatch.Start();
                for (int i = 0; i < number; i++)
                {

                    int value = DelArray[i];
                }
                DelStopwatch.Stop();
                Console.WriteLine("Add in Array:" + "" + elapsedTime);

                //Perfomance of Delete form Dynamic Array List
                DelStopwatch.Start();
                for (int i = 0; i < number; i++)
                {
                    DelList.Remove(DelRandom.Next(0, 10 * i));

                }
                DelStopwatch.Stop();
                Console.WriteLine("Add in List:" + "" + elapsedTime);

                //Perfomance of Delete form Stack
                DelStopwatch.Start();
                for (int i = 0; i < number; i++)
                {
                    DelStack.Pop();

                }
                DelStopwatch.Stop();
                Console.WriteLine("Add in List:" + "" + elapsedTime);

                //Perfomance of Delete form Qeue
                DelStopwatch.Start();
                for (int i = 0; i < number; i++)
                {
                    DelQeue.Dequeue();

                }
                DelStopwatch.Stop();
                Console.WriteLine("Add in List:" + "" + elapsedTime);

                //Perfomance of Delete form Dictionary
                DelStopwatch.Start();
                for (int i = 0; i < number; i++)
                {
                    DelDictionary.Remove(DelDictionary.Count);

                }
                DelStopwatch.Stop();
                Console.WriteLine("Add in List:" + "" + elapsedTime);

                //Perfomance of Delete form SotedDictionary
                DelStopwatch.Start();
                for (int i = 0; i < number; i++)
                {
                    DelSortDic.Remove(DelSortDic.Count);

                }
                DelStopwatch.Stop();
                Console.WriteLine("Add in List:" + "" + elapsedTime);

                //Perfomance of Delete form HashSet
                DelStopwatch.Start();
                for (int i = 0; i < number; i++)
                {
                    DelHash.Remove(DelRandom.Next(0, 10 * i));

                }
                DelStopwatch.Stop();
                Console.WriteLine("Add in List:" + "" + elapsedTime);


            }

            public void Search(int number)
            {
                int[] SearchArray = new int[];
                List<int> SearchList = new List<int>();
                Stack<int> SearchStack = new Stack<int>();
                Queue<int> SearchQeue = new Queue<int>();
                Dictionary<int, int> SearchDic = new Dictionary<int, int>();
                SortedDictionary<int, int> SearchSortDic = new SortedDictionary<int, int>();
                HashSet<int> SearchHash = new HashSet<int>();
                Random SearcRansom = new Random();
                Stopwatch SearchStopwatch = new Stopwatch();
                TimeSpan Searchts = SearchStopwatch.Elapsed;
                string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", Searchts.Hours, Searchts.Minutes, Searchts.Seconds, Searchts.Milliseconds);

                //Perfomance of Search in Array
                SearchStopwatch.Start();
                for (int i = 0; i < SearchArray.Length; i++)
                {
                    int addValue = Array.Find(SearchArray, x => x == number);
                }

                SearchStopwatch.Stop();
                Console.WriteLine("Add in Array:" + "" + elapsedTime);

                //Perfomance of Search in Dynamic Array List
                SearchStopwatch.Start();
                for (int i = 0; i < number; i++)
                {
                    int addValue = SearchList.Find(x => x == number);
                }
                SearchStopwatch.Stop();
                Console.WriteLine("Add in List:" + "" + elapsedTime);

                //Perfomance of Search in Stack
                SearchStopwatch.Start();
                for (int i = 0; i < number; i++)
                {
                    SearchStack.Pop();

                }
                SearchStopwatch.Stop();
                Console.WriteLine("Add in List:" + "" + elapsedTime);

                //Perfomance of Search in Qeue
                SearchStopwatch.Start();
                for (int i = 0; i < number; i++)
                {
                    SearchQeue.Dequeue();

                }
                SearchStopwatch.Stop();
                Console.WriteLine("Add in List:" + "" + elapsedTime);

                //Perfomance of Search in Dictionary
                SearchStopwatch.Start();
                for (int i = 0; i < number; i++)
                {
                    SearchDic.Remove(SearchDic.Count);

                }
                SearchStopwatch.Stop();
                Console.WriteLine("Add in List:" + "" + elapsedTime);

                //Perfomance of Search in SotedDictionary
                SearchStopwatch.Start();
                for (int i = 0; i < number; i++)
                {
                    SearchSortDic.Remove(SearchSortDic.Count);

                }
                SearchStopwatch.Stop();
                Console.WriteLine("Add in List:" + "" + elapsedTime);

                //Perfomance ofSearch in HashSet
                SearchStopwatch.Start();
                for (int i = 0; i < number; i++)
                {
                    SearchHash.Remove(SearcRansom.Next(0, 10 * i));

                }
                SearchStopwatch.Stop();
                Console.WriteLine("Add in List:" + "" + elapsedTime);


            }
        }






    }
}
  
