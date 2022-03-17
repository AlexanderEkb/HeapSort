namespace Exercize
{
  class HeapSort
  {
    int[] InArray = new int[0];
    public void Sort(int[] Array)
    {
      InArray = Array;

      StageOne();
      StageTwo();
    }

    void StageOne()
    {
      int From = Parent(InArray.Length - 1);
      for(int Root=From; Root >= 0; Root--)
      {
        FloatMax(Root, InArray.Length);
      }
    }

    void StageTwo()
    {
      for(int Rem = InArray.Length - 1; Rem > 0; Rem--)
      {
        Swap(0, Rem);
        FloatMax(0, Rem);
      }
    }

    void FloatMax(int Root, int Length)
    {
      int L = Left(Root);
      int R = Right(Root);
      int X = Root;

      if((L < Length) && (InArray[L] > InArray[X]))
      {
        X = L;
      }
      if((R < Length) && (InArray[R] > InArray[X]))
      {
        X = R;
      }
      if(X != Root)
      {
        Swap(X, Root);
        FloatMax(X, Length);
      }
    }

    int Left(int P)
    {
      int result = P * 2 + 1;
      return result;
    }

    int Right(int P)
    {
      int result = P * 2 + 2;
      return result;
    }

    int Parent(int A)
    {
      int result = (A - 1) / 2;
      return result;
    }

    void Swap(int a, int b)
    {
      int tmp = InArray[a];
      InArray[a] = InArray[b];
      InArray[b] = tmp;
    }
  }
}