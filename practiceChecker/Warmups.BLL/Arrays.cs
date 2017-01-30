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
            int firstToLast = numbers[0];                  //get the first value out of the array
            int[] shifted = new int[numbers.Length];
            shifted[numbers.Length - 1] = firstToLast;

            for (int i = 0; i < numbers.Length - 1; i++)    //for loop
            {
                shifted[i] = numbers[i + 1];
            }
            return shifted;
        }
        
        public int[] Reverse(int[] numbers)
        {
            int[] reverso = new int[numbers.Length];
            int iUp = 0;

            for (int iDown = numbers.Length - 1; iDown >= 0; iDown--)
            {
                reverso[iUp] = numbers[iDown];
                iUp++;
            }
            return reverso;
        }
        
        public int[] HigherWins(int[] numbers)
        {
            int hiCount = numbers[0];
            int[] hiArray = new int[numbers.Length];

            for (int i = 0; i <= numbers.Length - 1; i++) //set hiCount = to highest array element in this loop
            {
                if (numbers[i] > hiCount)
                {
                    hiCount = numbers[i];
                }
            }

            for (int i = 0; i <= numbers.Length - 1; i++) //reaplce all elements with hiCount in this loop
            {
                hiArray[i] = hiCount;
            }
            return hiArray;
        }
        
        public int[] GetMiddle(int[] a, int[] b)
        {
            int[] middles = new int[2];
            middles[0] = a[1];
            middles[1] = b[1];

            return middles;
             
        }
        
        public bool HasEven(int[] numbers)
        {
            bool even = false;
            for (int i = 0; i <= numbers.Length - 1; i ++)
            {
                if (numbers[i] % 2 == 0)
                {
                    even = true;
                }
            }
            return even;
        }


        public int[] KeepLast(int[] numbers)
        {
            int[] bigLast = new int[numbers.Length * 2];
            int lastNum = numbers[numbers.Length - 1];
            bigLast[bigLast.Length - 1] = lastNum;

            return bigLast;
        }

        
        public bool Double23(int[] numbers)
        {
            int twoCount = 0, threeCount = 0;

            for (int i = 0; i <= numbers.Length - 1; i++)
            {
                if (numbers[i] == 2)
                {
                    twoCount++;
                }
                if (numbers[i] == 3)
                {
                    threeCount++;
                }
            }
            if (twoCount == 2 || threeCount == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public int[] Fix23(int[] numbers)
        {
            for (int i = 0; i <= numbers.Length - 1; i++)
            {
                if (numbers[i] == 2 && numbers[i + 1] == 3)
                {
                    numbers[i + 1] -= 3;
                }
            }
            return numbers;
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
