using System.Diagnostics;

namespace Exercize
{
    class Program
    {
      static void Main(string[] args)
      {
        HeapSort sorter = new HeapSort();
        const int RunCount = 7;
        double[] SelectionElapsed = new double[RunCount];
        Stopwatch sw = new Stopwatch();
        int ItemCount = 100;
        for(int i=0; i<RunCount; i++)
        {
          int[] ArrayA = PrepareArray(ItemCount);
          sw.Start();
          // Either ...
          // SelectionSort(ArrayA);
          // ...or...
          sorter.Sort(ArrayA);
          sw.Stop();
          SelectionElapsed[i] = sw.Elapsed.TotalMilliseconds;
          if(IsSorted(ArrayA))
          {
            string Elapsed = sw.ElapsedMilliseconds.ToString();
            Console.WriteLine($"ItemCount={ItemCount}, {Elapsed} ms elapsed.");

          }
          else
          {
            Console.WriteLine($"Task failed for ItemCount={ItemCount}");
          }
          ItemCount *= 10;
        }
      }
      
      static int[] PrepareArray(int Size)
      {
        int[] Array = new int[Size];
        Random rnd = new Random();
        for(int j=0; j<Size; j++)
        {
          Array[j] = rnd.Next();
        }
        return Array;
      }
      static void HeapSort(int[] Array)
      {
      }

      static void SelectionSort(int[] Array)
      {
        int Length = Array.Length;
        for(int i = Length - 1; i > 0; i--)
        {
          int MaxIdx = 0;
          for(int j=0; j<=i; j++)
          {
            if(Array[j] > Array[MaxIdx])
            {
              MaxIdx = j;
            }
          }
          int Tmp = Array[i];
          Array[i] = Array[MaxIdx];
          Array[MaxIdx] = Tmp;
        }
      }

      static bool IsSorted(int[] Array)
      {
        bool Result = true;
        int From = 0;
        int To = Array.Length - 1;

        for(int i=From; i<To; i++)
        {
          if(Array[i] > Array[i+1])
          {
            Console.WriteLine($"Error at {i}");
            Result = false;
            break;
          }
        }
        return Result;
      }
    }
}