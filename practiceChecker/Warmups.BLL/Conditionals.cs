using System;

namespace Warmups.BLL
{
    public class Conditionals
    {
        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
            if (aSmile == bSmile)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CanSleepIn(bool isWeekday, bool isVacation)
        {
            if (isWeekday == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int SumDouble(int a, int b)
        {
            int sum = a + b;

            if (a == b)
            {
                return sum * 2;
            }
            else
            {
                return sum;
            }
        }
        
        public int Diff21(int n)
        {
            int absVal;
            if (n > 21)
            {
                absVal = (21 - n) * -2;
            }
            else
            {
                absVal = 21 - n;
            }
            return absVal;
        }
        
        public bool ParrotTrouble(bool isTalking, int hour)
        {
            if (isTalking == true && hour < 7 || hour > 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool Makes10(int a, int b)
        {
            if (a == 10 || b == 10 || a+b == 10 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool NearHundred(int n)
        {
            if ((n >= 90 && n <= 110) || (n >= 190 && n <= 210))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool PosNeg(int a, int b, bool negative)
        {
            if ((a < 0 || b < 0) && negative == false)
            {
                return true;
            }
            else if ((a < 0 && b < 0) && negative == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        
        public string NotString(string s)
        {
            string notAdder;
            if (s[0] == 'n' && s[1] == 'o' & s[2] == 't')
                notAdder = s;
            else
            {
                notAdder = "not " + s;
            }
            return notAdder;
        }
        
        public string MissingChar(string str, int n)
        {
            string oneGone = str.Remove(n, 1);
            return oneGone;
        }
        
        public string FrontBack(string str)
        {
            if (str.Length == 0 || str.Length == 1)
            {
                return str;
            }
            else
            {
                string firstLetter = str.Remove(1);
                string lastLetter = str.Substring(str.Length - 1);
                string middlePart = str.Substring(1, str.Length - 2);
                string frontToBack = lastLetter + middlePart + firstLetter;
                return frontToBack;
            } 
        }
        
        public string Front3(string str)
        {
            string firstPart;

            if (str.Length <= 3)
            {
                firstPart = str;
            }
            else
            {
                firstPart = str.Remove(3);
            }
            string triple = firstPart + firstPart + firstPart;
            return triple;

        }

        
        public string BackAround(string str)
        {
            string lstChr = str.Substring(str.Length - 1);
            string silywrd = lstChr + str + lstChr;
            return silywrd; 
        }
        
        public bool Multiple3or5(int number)
        {
            if (number % 3 == 0 || number % 5 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool StartHi(string str)
        {

            if (str.Length < 2)
                return false;
            else if (str.Length == 2 && str[0] == 'h' && str[1] == 'i')
                return true;
            else if (str.Length > 2 && str[0] == 'h' && str[1] == 'i' && str[2] == ' ' || str[2] == ',')
                return true;
            else
                return false;
        }
        
        public bool IcyHot(int temp1, int temp2)
        {
            bool hotCold;

            if (temp1 > 100 && temp2 < 0 || temp1 < 0 && temp2 > 100)
            {
                hotCold = true;
            }
            else
            {
                hotCold = false;
            }
            return hotCold;
        }
        
        public bool Between10and20(int a, int b)
        {
            if (a >= 10 && a <= 20 || b >= 10 && b <= 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool HasTeen(int a, int b, int c)
        {
            int[] teens = new int[] {a, b, c };
            bool isTeen = false;

            for (int i = 0; i < 2; i++)
            {
                if (teens[i] > 12 && teens[i] < 20)
                {
                    isTeen = true;
                }  
            }
            return isTeen;

        }
        
        public bool SoAlone(int a, int b)
        {
            bool aTeen = false; 
            bool bTeen = false;
            bool result;

            if (a > 12 && a < 20)
            {
                aTeen = true;
            }
            if (b > 12 && b < 20)
            {
                bTeen = true;
            }

            if (aTeen && bTeen || !aTeen && !bTeen)
            {
                result = false;
            }
            else
            {
                result = true;
            }
            return result;
        }

        public string RemoveDel(string str)
        {
            if (str[1] == 'd' && str[2] == 'e' && str[3] == 'l')
            {
                string lastPart = str.Substring(4);
                string result = str[0] + lastPart;
                return result;
            }
            else
            {
                return str;
            }
        }
        public bool IxStart(string str)
        {
            if (str[1] == 'i' && str[2] == 'x')
                return true;
            else
            {
                return false;
            }
        }
        
        public string StartOz(string str)
        {
            string result;
      
            if (str[0] != 'o' && str.Length < 2)
            {
                result = "";
            }
            else if (str[0] == 'o' && str[1] == 'z')
            {
                result = "oz";
            }
            else if (str[0] == 'o')
            {
                result = "o";
            }
            else
            {
                result = "z";     
            }
            return result;  
        }
        
        public int Max(int a, int b, int c)
        {
            int max;
            if (a > b && a > c)
            {
                max = a;
            }
            else if (b > c)
            {
                max = b;
            }
            else
            {
                max = c;
            }
            return max;
        }
        
        public int Closer(int a, int b)
        {
            int result;
            if ( Math.Abs(a - 10) == Math.Abs(b - 10))
            {
                result = 0;
            }
            else if (Math.Abs(a - 10) > Math.Abs(b - 10))
            {
                result = b;
            }
            else
            {
                result = a;
            }
            return result;
        }
        
        public bool GotE(string str)
        {
            bool betweenOneAndThreeEs = false;
            int eCounter = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'e')
                {
                    eCounter++;
                }
            }
            if (eCounter > 0 && eCounter <= 3)
            {
                betweenOneAndThreeEs = true;
            }
            return betweenOneAndThreeEs;
        }
        
        public string EndUp(string str)
        {
            string upperLast3;

            if (str.Length < 3)
            {
                upperLast3 = str.ToUpper();
            }
            else
            {
                string firstPart = str.Remove(str.Length - 3);
                string last3 = str.Substring(str.Length - 3);
                upperLast3 = firstPart + last3.ToUpper(); 
            }
            return upperLast3;

        }
        
        public string EveryNth(string str, int n)
        {
            string nth = "";
            for (int i = 0; i < str.Length; i+=n)
            {
                nth += str[i];
            }
            return nth;
        }
    }
}
