using System;

namespace Warmups.BLL
{
    public class Arrays
    {

        public bool FirstLast6(int[] numbers)
        {
            if (numbers[0] == 6 || numbers[numbers.Length - 1] == 6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SameFirstLast(int[] numbers)
        {
            bool same = false;
            if (numbers.Length > 1 && numbers[0] == numbers[numbers.Length - 1])
            {
                same = true;
            }
            return same;





        }
        public int[] MakePi(int n)
        {
            char[] charResult = new char[n];
            string pi = "314159265358979323846";
            int[] numResult = new int[n];

            for (int i = 0; i < numResult.Length; i++)
            {
                charResult[i] = pi[i];
            }
            for (int i = 0; i < numResult.Length; i++)
            {
                numResult[i] = int.Parse(charResult[i].ToString());
            }
            return numResult;
        }

        public bool CommonEnd(int[] a, int[] b)
        {
            if (a[0] == b[0] || a[a.Length -1] == b[b.Length - 1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public int Sum(int[] numbers)
        {
            int sumAdder = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sumAdder += numbers[i];
            }
            return sumAdder;
        }
        
        public int[] RotateLeft(int[] numbers)
        {
            int firstOne = numbers[0];
            int[] shifted = new int[numbers.Length];
            for (int i = 1; i < numbers.Length; i++)
            {

            }
        }
        
        public int[] Reverse(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public int[] HigherWins(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public int[] GetMiddle(int[] a, int[] b)
        {
            throw new NotImplementedException();
        }
        
        public bool HasEven(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public int[] KeepLast(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public bool Double23(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public int[] Fix23(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public bool Unlucky1(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public int[] Make2(int[] a, int[] b)
        {
            throw new NotImplementedException();
        }

    }
}
