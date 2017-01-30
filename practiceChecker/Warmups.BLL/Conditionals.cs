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
            if (str[0] == 'h' && str[1] == 'i')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool IcyHot(int temp1, int temp2)
        {
            throw new NotImplementedException();
        }
        
        public bool Between10and20(int a, int b)
        {
            throw new NotImplementedException();
        }
        
        public bool HasTeen(int a, int b, int c)
        {
            throw new NotImplementedException();
        }
        
        public bool SoAlone(int a, int b)
        {
            throw new NotImplementedException();
        }
        
        public string RemoveDel(string str)
        {
            throw new NotImplementedException();
        }
        
        public bool IxStart(string str)
        {
            throw new NotImplementedException();
        }
        
        public string StartOz(string str)
        {
            throw new NotImplementedException();
        }
        
        public int Max(int a, int b, int c)
        {
            throw new NotImplementedException();
        }
        
        public int Closer(int a, int b)
        {
            throw new NotImplementedException();
        }
        
        public bool GotE(string str)
        {
            throw new NotImplementedException();
        }
        
        public string EndUp(string str)
        {
            throw new NotImplementedException();
        }
        
        public string EveryNth(string str, int n)
        {
            throw new NotImplementedException();
        }
    }
}
