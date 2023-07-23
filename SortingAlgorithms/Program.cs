using System.Collections.Generic;

class Program
{
    //DateTime start = DateTime.Now;
    // Do some work
    //TimeSpan timeDiff = DateTime.Now - start;
    //timeDiff.TotalMilliseconds;
    public static void BubbleSort(List<int> input)
    {
        DateTime start = DateTime.Now;
        int n = input.Count;
        bool swapped;

        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;

            for (int j = 0; j < n - i - 1; j++)
            {
                if (input[j] > input[j + 1])
                {

                    int temp = input[j];
                    input[j] = input[j + 1];
                    input[j + 1] = temp;
                    swapped = true;
                }
            }

            if (!swapped)
                break;
        }

        TimeSpan timeDiff = DateTime.Now - start;
        Console.WriteLine("BubbleSort :" + timeDiff.TotalMilliseconds);

        PrintValues(list:input);

        //return (input);
    }

    public static void InsertionSort(List<int> input)
    {
        DateTime start = DateTime.Now;
        for (int i = 0; i < input.Count(); i++)
        {
            var item = input[i];
            var currentIndex = i;
            while (currentIndex > 0 && input[currentIndex - 1] > item)
            {
                input[currentIndex] = input[currentIndex - 1];
                currentIndex--;
            }
            input[currentIndex] = item;
        }

        TimeSpan timeDiff = DateTime.Now - start;
        Console.WriteLine("Insertion Sort: " + timeDiff.TotalMilliseconds);

        PrintValues(input);

        //return (input);
    }

    public static void SelectionSort(List<int> input)
    {
        DateTime start = DateTime.Now;
        for (var i = 0; i < input.Count; i++)
        {
            var min = i;
            for (var j = i + 1; j < input.Count; j++)
            {
                if (input[min] > input[j])
                {
                    min = j;
                }
            }
            if (min != i)
            {
                var lowerValue = input[min];
                input[min] = input[i];
                input[i] = lowerValue;
            }
        }

        TimeSpan timeDiff = DateTime.Now - start;
        Console.WriteLine("Selection Sort: " + timeDiff.TotalMilliseconds);

        PrintValues(input);

        //return (input);
    }

    public static List<int> QuickSort(List<int> A, int p, int r)
    {
        int q;
        if (p < r)
        {
            q = partition(A, p, r);
            QuickSort(A, p, q - 1);
            QuickSort(A, q + 1, r);
        }

        return A;
    }

    public static int partition(List<int> A, int p, int r)
    {
        int tmp;
        int x = A[r];
        int i = p - 1;

        for (int j = p; j <= r - 1; j++)
        {
            if (A[j] <= x)
            {
                i++;
                tmp = A[i];
                A[i] = A[j];
                A[j] = tmp;
            }
        }
        tmp = A[i + 1];
        A[i + 1] = A[r];
        A[r] = tmp;
        return i + 1;
    }


    public static List<int> getInputs()
    {
        List<int> inputs = new List<int>();
        Console.WriteLine("Enter an integer. If you enter 'e', this program ends.");
        string x = "";
        while (x != "e")
        {
            try {
                x = Console.ReadLine();
                inputs.Add(Convert.ToInt16(x));
            } 
            catch {

            }

        }

        return inputs;
    }
 


    public static void PrintValues(List<int> list)
    {
        foreach (int value in list)
        {
            Console.Write(value + " ");
        }
        Console.WriteLine();
    }

    public static void Main(string[] args)
    {

        List<int> list = getInputs();

        BubbleSort(list);
        InsertionSort(list);
        SelectionSort(list);
        DateTime start = DateTime.Now;
        list = QuickSort(list, 0, list.Count - 1);
        TimeSpan timeDiff = DateTime.Now - start;
        Console.WriteLine("Quick Sort: " + timeDiff.TotalMilliseconds);
        PrintValues(list);
    }
}