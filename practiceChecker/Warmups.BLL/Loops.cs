using System;

namespace Warmups.BLL
{
    public class Loops
    {

        public string StringTimes(string str, int n)
        {
            string blah = str;
            for (int i = 0; i < n - 1 ; i++)
            {
                blah += str;
            }
            return blah;
        }

        public string FrontTimes(string str, int n)
        {
            string firstPart;
            string result = "";

            if (str.Length <= 3)
            {
                firstPart = str;
            }
            else
            {
                firstPart = str.Remove(3);
            }

            for (int i = 0; i < n; i++)
            {
                result += firstPart;
            }
            return result;
        }

        public int CountXX(string str)
        {
            
        }

        public bool DoubleX(string str)
        {
            throw new NotImplementedException();
        }s

        public string EveryOther(string str)
        {
            throw new NotImplementedException();
        }

        public string StringSplosion(string str)
        {
            throw new NotImplementedException();
        }

        public int CountLast2(string str)
        {
            throw new NotImplementedException();
        }

        public int Count9(int[] numbers)
        {
            throw new NotImplementedException();
        }

        public bool ArrayFront9(int[] numbers)
        {
            throw new NotImplementedException();
        }

        public bool Array123(int[] numbers)
        {
            throw new NotImplementedException();
        }

        public int SubStringMatch(string a, string b)
        {
            throw new NotImplementedException();
        }

        public string StringX(string str)
        {
            throw new NotImplementedException();
        }

        public string AltPairs(string str)
        {
            throw new NotImplementedException();
        }

        public string DoNotYak(string str)
        {
            throw new NotImplementedException();
        }

        public int Array667(int[] numbers)
        {
            throw new NotImplementedException();
        }

        public bool NoTriples(int[] numbers)
        {
            throw new NotImplementedException();
        }

        public bool Pattern51(int[] numbers)
        {
            throw new NotImplementedException();
        }

    }
}
