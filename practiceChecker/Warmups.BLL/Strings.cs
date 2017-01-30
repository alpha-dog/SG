using System;

namespace Warmups.BLL
{
    public class Strings
    {

        public string SayHi(string name)
        {
            return "Hello " + name + "!";
        }

        public string Abba(string a, string b)
        {
            string abba = a + b + b + a;
            return abba;
        }

        public string MakeTags(string tag, string content)
        {
            string tagger = ($"<{tag}>{content}</{tag}>");
            return tagger;
        }

        public string InsertWord(string container, string word)
        {
            string insert = (container.Substring(0, 2)) + word + (container.Substring(2));
            return insert;
        }

        public string MultipleEndings(string str)
        {
            string dumb = str.Substring(str.Length - 2);
            string dumb3 = dumb + dumb + dumb;
            return dumb3;
        }

        public string FirstHalf(string str)
        {
            string half = str.Remove(str.Length / 2);
            return half;
        }

        public string TrimOne(string str)
        {
            string trim1 = str.Remove(str.Length - 1);
            string trim2 = (trim1.Substring(1));
            return trim2;
        }

        public string LongInMiddle(string a, string b)
        {
            string combo;
            if (a.Length > b.Length)
            {
                combo = b + a + b;
            }
            else
            {
                combo = a + b + a;
            }
            return combo;
        }

        public string RotateLeft2(string str)
        {
            if (str.Length > 2)
            {
                string lastPart = str.Substring(2);
                string firstTwo = str.Remove(2);
                string shifted = lastPart + firstTwo;
                return shifted;
            }
            else
            {
                return str;
            }


        }

        public string RotateRight2(string str)
        {
            if (str.Length > 2)
            {
                string lastTwo = str.Substring(str.Length - 2);
                string firstPart = str.Remove(str.Length - 2);
                string shifted = lastTwo + firstPart;
                return shifted;
            }
            else
            {
                return str;
            }


        }

        public string TakeOne(string str, bool fromFront)
        {
            if (fromFront == true)
            {
                string frontOne = str.Remove(1);
                return frontOne;
            }
            else
            {
                string lastOne = str.Substring(str.Length - 1);
                return lastOne;
            }
        }

        public string MiddleTwo(string str)
        {
            string middle2 = str.Substring((str.Length / 2 - 1), (2));
            return middle2;
        }

        public bool EndsWithLy(string str)
        {
            if (str.Length < 2)
            {
                return false;
            }
            else
            {
                string ending = str.Substring((str.Length - 2), (2));
                if (ending == "ly")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


        }

        public string FrontAndBack(string str, int n)
        {
            string lastOnes = str.Substring(str.Length - n);
            string firstOnes = str.Remove(n);
            string firstAndLast = firstOnes + lastOnes;

            return firstAndLast;
        }

        public string TakeTwoFromPosition(string str, int n)

        {
            if (n + 2 > str.Length)
            {
                string nTooBig = str.Substring(0, 2);
                return nTooBig;
            }
            else
            {
                string getTwo = str.Substring(n, 2);
                return getTwo;
            }
        }


        public bool HasBad(string str)
        {
            if (str.Length < 4)
            {
                return false;
            }

            else
            {
                string badCheck1 = str.Substring(0, 3);
                string badCheck2 = str.Substring(1, 3);

                if (badCheck1 == "bad" || badCheck2 == "bad")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public string AtFirst(string str)
        {
            string atDefault = "@@";

            if (str.Length == 0)
            {
                return atDefault;
            }
            else if (str.Length == 1)
            {
                string oneLetter = str + "@";
                return oneLetter;
            }
            else
            {
                string twoOrMore = str.Substring(0, 2);
                return twoOrMore;
            }
        }

        public string LastChars(string a, string b)
        {
            if (a.Length == 0 && b.Length == 0)
            {
                string emptyArgs = "@@";
                return emptyArgs;
            }
            else if (b.Length == 0)
            {
                string bEmpty = a.Remove(1) + "@";
                return bEmpty;
            }
            else if (a.Length == 0)
            {
                string aEmpty = "@" + b.Substring(b.Length - 1);
                return aEmpty;
            }
            else
            {
                string firstAndLast = a.Remove(1) + b.Substring(b.Length - 1);
                return firstAndLast;
            }
        }


        public string ConCat(string a, string b)
        {
            string conKat;

            if (a.Length == 0 || b.Length == 0)
            {
                conKat = a + b;
            }
            else if (a[a.Length - 1] == b[0])
            {
                string aShorter = a.Remove(a.Length - 1);
                conKat = aShorter + b;
            }
            else
            {
                conKat = a + b;
            }

            return conKat;
        }

        public string SwapLast(string str)
        {
            if (str.Length == 0 || str.Length == 1)
                return str;

            else if (str.Length == 2)
            {
                char[] firstTwo = { str[1], str[0] };
                string swapTwo = new string(firstTwo);
                return swapTwo;
            }
            else
            {
                string firstPart = str.Remove(str.Length - 2);
                string nextToLast = str.Substring(str.Length - 2, 1);
                string last = str.Substring(str.Length - 1);
                string swapLastTwo = firstPart + last + nextToLast;
                return swapLastTwo;
            }

        }

        public bool FrontAgain(string str)
        {

            if (str.Length == 0 || str.Length == 1 || str.Length == 2)
                return true;
            else
            {
                string backTwo = str.Substring(str.Length - 2);
                string frontTwo = str.Remove(2);

                if (backTwo == frontTwo)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public string MinCat(string a, string b)
        {
            string konkat;

            if (a.Length > b.Length)
            {
                string shortA = a.Substring(a.Length - b.Length);
                konkat = shortA + b;

            }
            else if (b.Length > a.Length)
            {
                string shortB = b.Substring(b.Length - a.Length);
                konkat = a + shortB;
            }
            else
            {
                konkat = a + b;
            }
            return konkat;
        }

        public string TweakFront(string str)
        {


            if (str.Length == 0)
                return str;

            else if (str.Length == 1 && str[0] == 'a')
            {
                string a = "a";
                return a;
            }
            else
            {
                string backEnd = str.Substring(2);
                string tweaked;

                if (str[0] == 'a' && str[1] == 'b')
                {
                    tweaked = "a" + "b" + backEnd;
                }
                else if (str[0] == 'a')
                {
                    tweaked = "a" + backEnd;
                }
                else if (str[1] == 'b')
                {
                    tweaked = "b" + backEnd;
                }
                else
                {
                    tweaked = backEnd;
                }
                return tweaked;
            }

        }

        public string StripX(string str)
        {
            char[] letters = new char[str.Length];
            string noX = "";
            for (int i = 0; i <= letters.Length - 1; i++)
            {
                if (str[i] != 'x')
                {
                    noX += str[i];
                }
            }
            
            return noX;


        }
    }
}

