using System;

namespace Warmups.BLL
{
    public class Loops
    {

        public string StringTimes(string str, int n)
        {
            string blah = str;
            for (int i = 0; i < n - 1; i++)
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
            int xCounter = 0;

            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] == 'x' && str[i + 1] == 'x')
                {
                    xCounter++;
                }
            }
            return xCounter;
        }

        public bool DoubleX(string str)
        {
            bool firstDouble = false;

            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] == 'x' && str[i + 1] == 'x')
                {
                    firstDouble = true;
                    break;
                }
                else if (str[i] == 'x' && str[i + 1] != 'x')
                {
                    firstDouble = false;
                    break;
                }
                else
                {
                    firstDouble = false;
                }
            }
            return firstDouble;
        }

        public string EveryOther(string str)
        {
            string everyOther = "";

            for (int i = 0; i < str.Length; i += 2)
            {
                everyOther += str[i];
            }
            return everyOther;
        }

        public string StringSplosion(string str)
        {
            string sploder = "";

            for (int i = 0; i < str.Length + 1; i++)
            {
                sploder += str.Substring(0, i);
            }
            return sploder;
        }

        public int CountLast2(string str)
        {
            int counter = 0;

            for (int i = 0; i < str.Length - 2; i++)
            {
                if (str[i] == 'x' && str[1 + i] == 'x')
                {
                    counter++;
                }
            }
            return counter;
        }

        public int Count9(int[] numbers)
        {
            int nineCount = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 9)
                {
                    nineCount++;
                }

            }
            return nineCount;
        }

        public bool ArrayFront9(int[] numbers)
        {
            bool nine = false;

            for (int i = 0; i < 3; i++)
            {
                if (numbers[i] == 9)
                {
                    nine = true;
                }
            }
            return nine;
        }

        public bool Array123(int[] numbers)
        {
            bool is123 = false;

            for (int i = 0; i < numbers.Length - 2; i++)
            {
                if (numbers[i] == 1 && numbers[i + 1] == 2 && numbers[i + 2] == 3)
                {
                    is123 = true;
                }
            }
            return is123;
        }

        public int SubStringMatch(string a, string b)
        {
            int matchCount = 0;
            int loopLength;

            if (a.Length > b.Length)
            {
                loopLength = b.Length;
            }
            else
            {
                loopLength = a.Length;
            }

            for (int i = 0; i < loopLength - 1; i++)
            {
                if (a[i] == b[i] && a[i + 1] == b[i + 1])
                {
                    matchCount++;
                }
            }
            return matchCount;
        }

        public string StringX(string str)
        {
            string lessX = "";

            for (int i = 0; i < str.Length; i++)
            {
                if (i == 0 || i == str.Length - 1)
                {
                    lessX += str[i];
                }
                else if (str[i] != 'x')
                {
                    lessX += str[i];
                }
            }
            return lessX;
        }

        public string AltPairs(string str)
        {
            string skipper = "";

            //int i = 0 ;
            //while (true)
            //{
            //    skipper += str[i];
            //    skipper += str[i + 1];
            //}


            for (int i = 0; i <= str.Length - 1; i += 4)
            {
                skipper += str[i];
                if (i >= str.Length - 1)
                    break;
                skipper += str[i + 1];
            }
            return skipper;
        }

        public string DoNotYak(string str)
        {
            string noYak = "";

            for (int i = 0; i < str.Length; i++)//str.length
            {
                if (i < str.Length - 2 && str[i] == 'y' && str[i + 2] == 'k')
                {
                    i += 2;
                }
                else
                {
                    if (i == str.Length)
                    {
                        break;
                    }
                    else
                    {
                        noYak += str[i];
                    }


                }

            }
            return noYak;
        }

        public int Array667(int[] numbers)
        {
            int count66 = 0;
            int count67 = 0;
            int totalCount;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == 6 && numbers[i + 1] == 6)
                {
                    count66++;
                }
                if (numbers[i] == 6 && numbers[i + 1] == 7)
                {
                    count67++;
                }
            }
            totalCount = count66 + count67;
            return totalCount;
        }

        public bool NoTriples(int[] numbers)
        {
            bool noTrips = true;

            for (int i = 0; i < numbers.Length - 2; i++)
            {
                if (numbers[i] == numbers[i + 1] && numbers[i + 1] == numbers[i + 2])
                {
                    noTrips = false;
                }
            }
            return noTrips;
        }

        public bool Pattern51(int[] numbers)
        {
            bool isDumbPattern = false;
            int loopLength = numbers.Length;

            for (int i = 0; i < loopLength - 2; i++)
            {
                if (numbers[i] == numbers[i + 1] - 5 && numbers[i + 2] == numbers[i] - 1)
                {
                    isDumbPattern = true;
                    break;
                }
                else
                    isDumbPattern = false;
            }
            return isDumbPattern;

        }

    }
}
