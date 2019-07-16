//17643904 Weronika Wawrzyniak Assesement2 20.04.2018
// -------------CHANGE STRING PATH TO WHEREVER YOUR FILES ARE--------------
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace NikaAlgorytmy
{
    class Program
    {
        string path = @"C:\Users\Alicja\Desktop\bank\"; //change this string to wherever your files are
        double[] numbers; // array used in loadArray method
        double[] numbers2; //array used in mergeArrays
        double[] numbers3; // array used in mergeArrays
        int count;
        //-----------------------------------------------------------------Sorting Algorithms------------------------------------------------------------
        // Quic Sort Algorithm Ascending
        public void quickSortA(double[] A, int left, int right)
        {
            count++;
            if (left > right || left < 0 || right < 0) return;

            int index = partition(A, left, right);

            if (index != -1)
            {
                quickSortA(A, left, index - 1);
                quickSortA(A, index + 1, right);
            }
        }
        private int partition(double[] A, int left, int right)
        {
            if (left > right) return -1;

            int end = left;

            double pivot = A[right];
            for (int i = left; i < right; i++)
            {
                if (A[i] < pivot)
                {
                    swap(A, i, end);
                    end++;
                    count++;
                }
            }

            swap(A, end, right);

            return end;
        }
        // Quick Sort Algorithm Descending
        public void quickSortD(double[] A, int left, int right)
        {
            count++;
            if (left > right || left < 0 || right < 0) return;

            int index = partition2(A, left, right);

            if (index != -1)
            {
                quickSortD(A, left, index - 1);
                quickSortD(A, index + 1, right);
            }
        }
        private int partition2(double[] A, int left, int right)
        {
            if (left > right) return -1;

            int end = left;

            double pivot = A[right];
            for (int i = left; i < right; i++)
            {
                if (A[i] > pivot)
                {
                    swap(A, i, end);
                    end++;
                    count++;
                }
            }

            swap(A, end, right);

            return end;
        }
        // Method that swaps elements in array. Used in Quick Sort Algorithms
        private void swap(double[] A, int left, int right)
        {
            count++;
            double tmp = A[left];
            A[left] = A[right];
            A[right] = tmp;
        }
        // QuickSort Algorithm which ascendingly prints out quick sorted array
        public void QuickSortA(double[] input)
        {
            quickSortA(input, 0, input.Length - 1);
            Console.WriteLine("Nunber of steps in Quick Sort Ascending: " + count);
            Console.WriteLine("Ascendingly sorted array with indexes: ");
            for (int i = 0; i < input.Length; i++) Console.Write("[" + i + "]" + " " + input[i] + "  ");
        }
        // QuickSort Algorithm which descendingly prints out quick sorted array
        public void QuickSortD(double[] input)
        {
            quickSortD(input, 0, input.Length - 1);
            Console.WriteLine("Nunber of steps in Quick Sort Descending: " + count);
            Console.WriteLine("Descendingly sorted array with indexes: ");
            for (int i = 0; i < input.Length; i++) Console.Write("[" + i + "]" + " " + input[i] + "  ");
        }
        // MergeSort Algorithm
        public void MergeSort(double[] input, int low, int high)
        {
            if (low < high)
            {
                int middle = (low / 2) + (high / 2);
                MergeSort(input, low, middle);
                MergeSort(input, middle + 1, high);
                Merge(input, low, middle, high);
            }
        }
        // MergeSort Algorithm
        private void Merge(double[] input, int low, int middle, int high)
        {
            int left = low;
            int right = middle + 1;
            double[] tmp = new double[(high - low) + 1];
            int tmpIndex = 0;

            while ((left <= middle) && (right <= high))
            {
                if (input[left] < input[right])
                {
                    count++;
                    tmp[tmpIndex] = input[left];
                    left = left + 1;
                }
                else
                {
                    tmp[tmpIndex] = input[right];
                    right = right + 1;
                    count++;
                }
                tmpIndex = tmpIndex + 1;
            }
            if (left <= middle)
            {
                while (left <= middle)
                {
                    count++;
                    tmp[tmpIndex] = input[left];
                    left = left + 1;
                    tmpIndex = tmpIndex + 1;
                }
            }
            if (right <= high)
            {
                while (right <= high)
                {
                    count++;
                    tmp[tmpIndex] = input[right];
                    right = right + 1;
                    tmpIndex = tmpIndex + 1;
                }
            }
            for (int i = 0; i < tmp.Length; i++)
            {
                input[low + i] = tmp[i];
                count++;
            }
        }
        // MergeSort Algorithm which ascendlingly prints out already sorted array
        public void MergeSortA(double[] input)
        {
            MergeSort(input, 0, input.Length - 1);
            Console.WriteLine("In Merge Stort the number of steps is: " + count);
            Console.WriteLine("Ascendingly sorted array with indexes: ");
            for (int i = 0; i < input.Length; i++) Console.Write("[" + i + "]" + " " + input[i] + "  ");
        }
        private void MergeD(double[] input, int low, int middle, int high)
        {
            int left = low;
            int right = middle + 1;
            double[] tmp = new double[(high - low) + 1];
            int tmpIndex = 0;
            while ((left <= middle) && (right <= high))
            {
                if (input[left] > input[right])
                {
                    count++;
                    tmp[tmpIndex] = input[left];
                    left = left + 1;
                }
                else
                {
                    tmp[tmpIndex] = input[right];
                    right = right + 1;
                    count++;
                }
                tmpIndex = tmpIndex + 1;
            }
            if (left <= middle)
            {
                while (left <= middle)
                {
                    tmp[tmpIndex] = input[left];
                    left = left + 1;
                    tmpIndex = tmpIndex + 1;
                    count++;
                }
            }
            if (right <= high)
            {
                while (right <= high)
                {
                    tmp[tmpIndex] = input[right];
                    right = right + 1;
                    tmpIndex = tmpIndex + 1;
                    count++;
                }
            }
            for (int i = 0; i < tmp.Length; i++)
            {
                input[low + i] = tmp[i];
                count++;
            }
        }
        // MergeSort Algorithm which ascendlingly prints out already sorted array
        public void MergeSortD(double[] input, int low, int high)
        {
            if (low < high)
            {
                int middle = (low / 2) + (high / 2);
                MergeSortD(input, low, middle);
                MergeSortD(input, middle + 1, high);
                MergeD(input, low, middle, high);
            }
        }
        // MergeSort Algorithm which changes order of the array and descendingly prints out already sorted array
        public void MergeSortDesc(double[] input)
        {
            MergeSortD(input, 0, input.Length - 1);
            Console.WriteLine("In Merge Stort the number of steps is: " + count);
            Console.WriteLine("Descendingly sorted array with indexes: ");
            for (int i = 0; i < input.Length; i++) Console.Write("[" + i + "]" + " " + input[i] + "  ");
        }
        //HeapSort Algorithm which ascendlingly prints out already sorted array
        public void HeapSortA(double[] input)
        {
            int heapSize = input.Length;
            for (int p = (heapSize - 1) / 2; p >= 0; p--)
            { MaxHeapify(input, heapSize, p); count++; }

            for (int i = input.Length - 1; i > 0; i--)
            {
                count++;
                double temp = input[i];
                input[i] = input[0];
                input[0] = temp;
                heapSize--;
                MaxHeapify(input, heapSize, 0);
            }
            Console.WriteLine("Heap Sort number of operations is :" + count);
            Console.WriteLine("Ascendingly sorted array with indexes: ");
            for (int i = 0; i < input.Length; i++) Console.Write("[" + i + "]" + " " + input[i] + "  ");
        }
        // MergeSort Algorithm which descendlingly prints out already sorted array
        public void HeapSortD(double[] input)
        {
            int heapSize = input.Length;
            for (int p = (heapSize - 1) / 2; p >= 0; p--)
            { MaxHeapifyD(input, heapSize, p); count++; }

            for (int i = input.Length - 1; i > 0; i--)
            {
                count++;
                double temp = input[i];
                input[i] = input[0];
                input[0] = temp;

                heapSize--;
                MaxHeapifyD(input, heapSize, 0);
            }
            Console.WriteLine("Heap Sort number of operations is :" + count);
            Console.WriteLine("Descendingly sorted array with indexes: ");
            for (int i = 0; i < input.Length; i++) Console.Write("[" + i + "]" + " " + input[i] + "  ");
        }
        //HeapSort Algorithm
        private void MaxHeapify(double[] input, int heapSize, int index)
        {
            int left = (index + 1) * 2 - 1;
            int right = (index + 1) * 2;
            int largest = 0;

            if (left < heapSize && input[left] > input[index])
            { largest = left; count++; }
            else
            { largest = index; count++; }

            if (right < heapSize && input[right] > input[largest])
            { largest = right; count++; }

            if (largest != index)
            {
                count++;
                double temp = input[index];
                input[index] = input[largest];
                input[largest] = temp;

                MaxHeapify(input, heapSize, largest);
            }
        }
        //HeapSort Algorithm for descending arrays
        private void MaxHeapifyD(double[] input, int heapSize, int index)
        {
            int left = (index + 1) * 2 - 1;
            int right = (index + 1) * 2;
            int largest = 0;

            if (left < heapSize && input[left] < input[index])
            { largest = left; count++; }
            else
            { largest = index; count++; }

            if (right < heapSize && input[right] < input[largest])
            { largest = right; count++; }

            if (largest != index)
            {
                count++;
                double temp = input[index];
                input[index] = input[largest];
                input[largest] = temp;

                MaxHeapifyD(input, heapSize, largest);
            }
        }
        //Bubble sort for descending arrays
        public void bubbleSortD(double[] myArray)
        {
            bool flag = true;
            double temp;
            int numLength = myArray.Length;
            for (int i = 1; (i <= (numLength - 1)) && flag; i++)
            {
                flag = false;
                for (int j = 0; j < numLength - i; j++)
                {
                    if (myArray[j + 1] > myArray[j])
                    {
                        temp = myArray[j];
                        myArray[j] = myArray[j + 1];
                        myArray[j + 1] = temp;
                        flag = true;

                    }
                    count++;
                }
                count++;
            }
            Console.WriteLine("In this algorithm we have counted {0} operations", count);
            Console.WriteLine("Descendingly sorted array with indexes: ");
            for (int i = 0; i < myArray.Length; i++) Console.Write("[" + i + "]" + " " + myArray[i] + "  ");
        }
        //Bubble sort for ascending arrays
        public void bubbleSortA(double[] myArray)
        {
            bool flag = true;
            double temp;
            int numLength = myArray.Length;
            for (int i = 1; (i <= (numLength - 1)) && flag; i++)
            {
                flag = false;
                for (int j = 0; j < numLength - i; j++)
                {
                    if (myArray[j + 1] < myArray[j])
                    {
                        temp = myArray[j];
                        myArray[j] = myArray[j + 1];
                        myArray[j + 1] = temp;
                        flag = true;

                    }
                    count++;
                }
                count++;
            }


            Console.WriteLine("In bubble sort algorithm we have counted {0} operations", count);
            Console.WriteLine("Ascendingly sorted array with indexes: ");
            for (int i = 0; i < myArray.Length; i++) Console.Write("[" + i + "]" + " " + myArray[i] + "  ");
        }
        //-----------------------------------------------------------------Searching Algorithms------------------------------------------------------------
        //BinarySearch Algorithm for descending arrays
        public int BinarySearch(double[] inputArray, double key)
        {
            count++;
            int max = 0;
            int min = inputArray.Length - 1;
            if (key > inputArray[0] || key < inputArray[inputArray.Length - 1]) return -1; //value is not in the array
            while (min >= max)
            {
                count++;
                int mid = (min + max) / 2;
                if (key == inputArray[mid])
                {
                    return ++mid;
                }
                // else if (key < inputArray[mid]) return -1;
                else if (key > inputArray[mid])
                {

                    min = mid + 1;
                }
                else
                {
                    max = mid - 1;
                }
            }
            return -1;
        }
        //Interpolation Search Algorithm for ascending arrays
        public int InterSearch(double[] arr, double key)
        {
            count++;
            int size = arr.Length;
            int low = 0;
            int high = size - 1;
            int mid;

            while ((arr[high] != arr[low]) && (key >= arr[low]) && (key <= arr[high]))
            {
                mid = (int)(low + (((double)(high - low) / (arr[high] - arr[low])) * (key - arr[low])));

                if (arr[mid] < key)
                { low = mid + 1; count++; }
                else if (key < arr[mid])
                { high = mid - 1; count++; }
                else
                    return mid;
            }

            if (key == arr[low])
            { return low; count++; }
                else
                    return -1;
            
        }
        //-----------------------------------------------------------------Task 3------------------------------------------------------------
        //Method that shows location of Interpolation Search
        public void showLoactionInter(double[] arr, double val)
        {
            int location = 0;
            Program bombelek = new Program();
            location = bombelek.InterSearch(arr, val);
            if (location == -1)
            {
                Console.WriteLine("In InterpolationSearch algorithm we have counted {0} steps", count);
                bombelek.neighbourValues(arr, val);
            }
            else
            {
                Console.Write("Value was found at index: " + location + " ");
                //by using two for loops, one starting at location and going up, second going down the array , it checks which values in the array equals searched value and print out its indexes. If the value is not equal, the loop breaks.
                for (int i = location + 1; i < arr.Length - 1; i++)
                {
                    if (arr[location] == arr[i]) { Console.Write(" " + i + " "); count++; }
                    else break;
                }
                for (int i = location - 1; i > -1; i--)
                {
                    if (arr[location] == arr[i]) { Console.Write(" " + i + " "); count++; }
                    else break;
                }
                Console.WriteLine();
                Console.WriteLine("In InterpolationSearch algorithm we have counted {0} steps", count);
            }
        }
        //Method that shows location of Binary Search
        public void showLocationBinary(double[] arr, double val)
        {
            Program bombelek = new Program();
            int locationB = (bombelek.BinarySearch(arr, val)) - 1;
            if (locationB == -2)
                bombelek.neighbourValues(arr, val);
            else
            {

                Console.Write("Value was found at index " + locationB + " ");
                for (int i = locationB + 1; i < arr.Length - 1; i++)
                {
                    if (arr[locationB] == arr[i]) { Console.Write(" " + i + " "); count++; }
                    else break;
                }
                for (int i = locationB - 1; i > -1; i--)
                {
                    if (arr[locationB] == arr[i]) { Console.Write(" " + i + " "); count++; }
                    else break;
                }
                Console.WriteLine("In Binary Search algorithm and showLocation method we have counted {0} operations", count);
            }
        }
        //loadArray which loads array from file of users choice. method that contains File.ReadAllText method to read all text from the file into a string and then uses the string.Split method to put each number into a string array and by using foreach loop parse it into double array. 
        public double[] loadArray(string source)
        {
            String[] items = File.ReadAllText(path + source).
                Split(new String[] { " ", Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries);
            List<double> numbersLista = new List<double>();
            foreach (String item in items)
            {
                try
                {
                    double value = Convert.ToDouble(item.Replace(('.'), (',')));
                    numbersLista.Add(value);
                }
                catch { Console.WriteLine(item + " Is not a number"); }
            }
            numbers = numbersLista.ToArray();
            return numbers;
        }
        //----------------------------------------------------------------Task 6------------------------------------------------------------
        // method “mergeArrays” which takes two strings as arguments. Strings are names of files User wants to merge and are included in paths. Method reads files and puts data into two arrays the same way as “loadArray”. I have created third array of the size of added sizes of two arrays. I made two for loops. First loop was starting index 0 and finishing at thirdArray.length/2 and put values from first array into third array. Second loop was starting at thirdArray.length/2 and finishing at thirdArray.length-1 and put values from second array indexes [i-(thirdArray.Length)/2] into the third one (looks complicated but I needed to find a way to keep filling higher indexes in third array and at the same time taking values from regular array starting at index 0).
        public double[] mergeArrays(string source, string source2)
        {
            String[] items = File.ReadAllText(path + source).
                Split(new String[] { " ", Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries);
            List<double> numbersLista = new List<double>();
            foreach (String item in items)
            {
                try
                {
                    double value = Convert.ToDouble(item.Replace(('.'), (',')));
                    numbersLista.Add(value);
                }
                catch { Console.WriteLine(item + " Is not a number"); }
            }
            numbers2 = numbersLista.ToArray();

            String[] items2 = File.ReadAllText(path + source).
                Split(new String[] { " ", Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries);
            List<double> numbersLista2 = new List<double>();
            foreach (String item in items2)
            {
                try
                {
                    double value = Convert.ToDouble(item.Replace(('.'), (',')));
                    numbersLista2.Add(value);
                }
                catch { Console.WriteLine(item + " Is not a number"); }
            }
            numbers3 = numbersLista2.ToArray();
            double[] numbers4 = new double[numbers3.Length + numbers2.Length];

            for (int i = 0; i < numbers2.Length; i++)
            {
                numbers4[i] = numbers2[i];
            }
            for (int i = numbers2.Length; i < numbers3.Length + numbers2.Length; i++)
            {
                numbers4[i] = numbers3[i - numbers2.Length];
            }
            Console.WriteLine("This is merged, not-sorted array");
            for (int i = 0; i < numbers4.Length; i++)
            {
                Console.Write(" [" + i + "]" + numbers4[i]);
            }
            return numbers4;

        }
        //-----------------------------------------------------------------Task 4------------------------------------------------------------
        //“neighbourValues” method calculating closest indexes in case value is not in the array
      
            public void neighbourValues(double[] x, double valueToFind)
            {
                double minDistance = 0;
                int minIndex = -1;
            for (int i = 0; i < x.Length - 1; i++)
            {

                if (((x[i] < valueToFind) && (x[i + 1] > valueToFind)) || ((x[i] > valueToFind) && (x[i + 1] < valueToFind))) Console.WriteLine("Value is not in the array, it is between index {0} = {1} and index {2} ={3}", i, x[i], i + 1, x[i + 1]);

            }
          
            for (int i = 0; i < x.Length; i++)
            {
                    var distance = Math.Abs(valueToFind - x[i]);
                    if (minIndex == -1 || distance < minDistance)
                    {
                        minDistance = distance;
                        minIndex = i;
                    }
                }
                Console.WriteLine("Value is not in the array, the closest is index {0} of value {1}", minIndex, x[minIndex]);
            
            }
            static void Main(string[] args)
        {
            Program bombelek = new Program();
            string answer, answer2, answer4, answer6, answer7, answer8, answer10, answer1, answer11, answer13;
            do
            {
                Console.WriteLine("Welcome to Sort and Search! Enter your text file (eg Change_128.txt)");
                answer = Console.ReadLine().ToLower();


                double[] myArray = bombelek.loadArray(answer);
                Console.WriteLine("Which sorting algorythm would you like to use? (heap/bubble/merge/quick?)");
                answer2 = Console.ReadLine().ToLower();
                Console.WriteLine("Would you like to sort ascending or descending? (a/d)");
                answer1 = Console.ReadLine().ToLower();
                if (answer2 == "heap")
                {
                    if (answer1 == "a") bombelek.HeapSortA(myArray);
                    else bombelek.HeapSortD(myArray);
                }
                else if (answer2 == "bubble")
                {
                    if (answer1 == "a") bombelek.bubbleSortA(myArray);
                    else bombelek.bubbleSortD(myArray);
                }
                else if (answer2 == "merge")
                {
                    if (answer1 == "a") bombelek.MergeSortA(myArray);
                    else bombelek.MergeSortDesc(myArray);
                }
                else if (answer2 == "quick")
                {
                    if (answer1 == "a") bombelek.QuickSortA(myArray);
                    else bombelek.QuickSortD(myArray);
                }
                Console.WriteLine();
                Console.WriteLine("Now etnter a value you would like to find");
                answer4 = Console.ReadLine().ToLower();
                bombelek.count = 0;
                if (answer1 == "d")
                {
                    bombelek.BinarySearch(myArray, Convert.ToDouble(answer4));
                    bombelek.showLocationBinary(myArray, Convert.ToDouble(answer4));
                }
                else
                {
                    bombelek.InterSearch(myArray, Convert.ToDouble(answer4));
                    bombelek.showLoactionInter(myArray, Convert.ToDouble(answer4));
                }
                Console.WriteLine();
                bombelek.count = 0;


                Console.WriteLine("Which arrays would you like to merge (write one -> enter -> the other one eg Change_128.txt enter Open_128).txt");
                answer6 = Console.ReadLine().ToLower();
                answer7 = Console.ReadLine().ToLower();
                Console.WriteLine();
                double[] myArray2 = bombelek.mergeArrays(answer6, answer7);
                Console.WriteLine("Which sorting algorythm would you like to use? (heap/bubble/merge/quick?)");
                answer8 = Console.ReadLine().ToLower();
                Console.WriteLine("Would you like to sort ascending or descending? (a/d)");
                answer11 = Console.ReadLine().ToLower();
                if (answer8 == "heap")
                {
                    if (answer11 == "a") bombelek.HeapSortA(myArray2);
                    else bombelek.HeapSortD(myArray2);
                }
                else if (answer8 == "bubble")
                {
                    if (answer11 == "a") bombelek.bubbleSortA(myArray2);
                    else bombelek.bubbleSortD(myArray2);
                }
                else if (answer8 == "merge")
                {
                    if (answer11 == "a") bombelek.MergeSortA(myArray2);
                    else bombelek.MergeSortDesc(myArray2);
                }
                else if (answer8 == "quick")
                {
                    if (answer11 == "a") bombelek.QuickSortA(myArray2);
                    else bombelek.QuickSortD(myArray2);
                }
                bombelek.count = 0;
                Console.WriteLine();
                Console.WriteLine("Now etnter a value you would like to find");
                answer10 = Console.ReadLine().ToLower();
                if (answer11 == "d")
                {
                    bombelek.BinarySearch(myArray2, Convert.ToDouble(answer10));
                    bombelek.showLocationBinary(myArray2, Convert.ToDouble(answer10));
                }
                else
                {
                    bombelek.InterSearch(myArray2, Convert.ToDouble(answer10));
                    bombelek.showLoactionInter(myArray2, Convert.ToDouble(answer10));
                }


                Console.WriteLine("Thanks for using my program! Would you like to start again? (yes/no)");
                answer13 = Console.ReadLine().ToLower();
            } while (answer13 == "yes");
            Console.WriteLine("See you next time! :) Program written by Weronika Wawrzyniak 17643904 for Algorithms and Complexity module semester B Assessment2 University of Lincoln. May 2018");
            Console.ReadLine();
        }
    }
}

