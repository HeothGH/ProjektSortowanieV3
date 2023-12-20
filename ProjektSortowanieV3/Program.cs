using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektSortowanieV3
{
    internal static class Program
    {
        public abstract class Sort
        {
            protected Random random = new Random();
            protected int[] data;
            protected DateTime start, stop;
            protected int size;
            public abstract double Duration { get; }
            public Sort(int size)
            {
                this.size = size;
                GenerateData(size);
            }
            public void GenerateData(int size)
            {
                this.data = new int[size];
                for (int i = 0; i < size; i++)
                {
                    this.data[i] = random.Next(100);
                }
            }
            public abstract void SortData();
        }
        public class BubleSort : Sort
        {

            override public double Duration
            {
                get
                {
                    if (start != null && stop != null)
                    {
                        return (stop - start).TotalMilliseconds;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            public BubleSort(int size) : base(size)
            {

            }
            override public void SortData()
            {
                start = DateTime.Now;
                for (int i = 0; i < data.Length - 1; i++)
                {
                    for (int j = 0; j < data.Length - 1; j++)
                    {
                        if (data[j] > data[j + 1])
                        {
                            int temp = data[j + 1];
                            data[j + 1] = data[j];
                            data[j] = temp;
                        }
                    }
                }
                stop = DateTime.Now;
            }
        }
        public class InsertionSort : Sort
        {
            override public double Duration
            {
                get
                {
                    if (start != null && stop != null)
                    {
                        return (stop - start).TotalMilliseconds;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            public InsertionSort(int size) : base(size)
            {

            }
            override public void SortData()
            {
                start = DateTime.Now;
                for (int i = 1; i < data.Length; i++)
                {
                    int temp = data[i];
                    int j = i - 1;
                    while (j >= 0 && data[j] > temp)
                    {
                        data[j + 1] = data[j];
                        j--;
                    }
                    data[j + 1] = temp;
                }
                stop = DateTime.Now;
            }
            
        }
        public class SelectionSort : Sort
        {
            override public double Duration
            {
                get
                {
                    if (start != null && stop != null)
                    {
                        return (stop - start).TotalMilliseconds;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            public SelectionSort(int size) : base(size)
            {

            }
            override public void SortData()
            {
                start = DateTime.Now;
                for (int i = 0; i < data.Length - 1; i++)
                {
                    int min = i;
                    for (int j = i + 1; j < data.Length; j++)
                    {
                        if (data[j] < data[min])
                        {
                            min = j;
                        }
                    }
                    int temp = data[min];
                    data[min] = data[i];
                    data[i] = temp;
                }
                stop = DateTime.Now;
            }
        }
        public class QuickSort : Sort
        {
            override public double Duration
            {
                get
                {
                    if (start != null && stop != null)
                    {
                        return (stop - start).TotalMilliseconds;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            public QuickSort(int size) : base(size)
            {

            }
            override public void SortData()
            {
                start = DateTime.Now;
                QuickSortAlg(data, 0, data.Length - 1);
                stop = DateTime.Now;
            }
            private void QuickSortAlg(int[] data, int left, int right)
            {
                int i = left;
                int j = right;
                int pivot = data[(left + right) / 2];
                while (i <= j)
                {
                    while (data[i] < pivot)
                    {
                        i++;
                    }
                    while (data[j] > pivot)
                    {
                        j--;
                    }
                    if (i <= j)
                    {
                        int temp = data[i];
                        data[i] = data[j];
                        data[j] = temp;
                        i++;
                        j--;
                    }
                }
                if (left < j)
                {
                    QuickSortAlg(data, left, j);
                }
                if (i < right)
                {
                    QuickSortAlg(data, i, right);
                }
            }
        }
        public class MergeSort : Sort
        {
            override public double Duration
            {
                get
                {
                    if (start != null && stop != null)
                    {
                        return (stop - start).TotalMilliseconds;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            public MergeSort(int size) : base(size)
            {

            }
            override public void SortData()
            {
                start = DateTime.Now;
                MergeSortAlg(data, 0, data.Length - 1);
                stop = DateTime.Now;
            }
            private void MergeSortAlg(int[] data, int left, int right)
            {
                if (left < right)
                {
                    int middle = (left + right) / 2;
                    MergeSortAlg(data, left, middle);
                    MergeSortAlg(data, middle + 1, right);
                    Merge(data, left, middle, right);
                }
            }
            private void Merge(int[] data, int left, int middle, int right)
            {
                int[] temp = new int[data.Length];
                int i, leftEnd, numElements, tmpPos;
                leftEnd = (middle - 1);
                tmpPos = left;
                numElements = (right - left + 1);
                while ((left <= leftEnd) && (middle <= right))
                {
                    if (data[left] <= data[middle])
                    {
                        temp[tmpPos++] = data[left++];
                    }
                    else
                    {
                        temp[tmpPos++] = data[middle++];
                    }
                }
                while (left <= leftEnd)
                {
                    temp[tmpPos++] = data[left++];
                }
                while (middle <= right)
                {
                    temp[tmpPos++] = data[middle++];
                }
                for (i = 0; i < numElements; i++)
                {
                    data[right] = temp[right];
                    right--;
                }
            }
        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ProjektSortowanieV3.Sort());
        }
    }
}
