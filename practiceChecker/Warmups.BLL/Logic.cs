using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.BLL
{
    public class Logic
    {

        public bool GreatParty(int cigars, bool isWeekend)
        {
            bool gr8prty = false;
            if (!isWeekend && cigars > 40 && cigars < 60 || isWeekend && cigars > 40)
                gr8prty = true;
            return gr8prty;
        }
        
        public int CanHazTable(int yourStyle, int dateStyle)
        {
            int getTable;
            if (yourStyle > 8 || dateStyle > 8 && yourStyle > 2 && dateStyle > 2)
                getTable = 2;
            else if (yourStyle > 2 && dateStyle > 2)
                getTable = 1;
            else
                getTable = 0;
            return getTable;
        }

        public bool PlayOutside(int n, bool b)
        {
            if (n > 90 && !b)
            {
                return (false);
            }
            else
            {
                return (true);
            }
        }
        
        public int CaughtSpeeding(int speed, bool isBirthday)
        {
            int bDayBonus;
            if (isBirthday)
            {
                bDayBonus = 5;
            }
            else
            {
                bDayBonus = 0;
            }

            int ticketCode = 0;

            if (speed > (61 + bDayBonus) && speed <= (80 + bDayBonus))
            {
                ticketCode = 1;
            }
            else if (speed >= 81 + bDayBonus)
            {
                ticketCode = 2;
            }
            return ticketCode;



        }
        
        public int SkipSum(int a, int b)
        {
            int sum = a + b;
            if (sum > 9 && sum < 20)
                sum = 20;
            return sum;
        }
        
        public string AlarmClock(int day, bool vacation)
        {
            string clockTime;

            if (day>0&&day<6&&!vacation)
            {
                clockTime = "7:00";
            }
            else if (day>0&&day<6 ||!vacation)
            {
                clockTime = "10:00";
            }
            else
            {
                clockTime = "off";
            }
            return clockTime;
        }
        
        public bool LoveSix(int a, int b)
        {
            bool isSix = false; 
            if (a==6||b==6||a+b==6||a-b==6||b-a==6)
            {
                 isSix = true;
            }
            return isSix;
        }
        
        public bool InRange(int n, bool outsideMode)
        {
            bool inOrOut;
            if (outsideMode)
                if (n < 1 || n > 10)
                    inOrOut = true;
                else
                    inOrOut = false;
            else
                if (n > 1 && n < 10)
                inOrOut = true;
            else
                inOrOut = false;
            return inOrOut;

                
            


        }
        
        public bool SpecialEleven(int n)
        {
            bool special = false;
            if (n % 11 == 0 || n % 11 == 1)
                special = true;
            return special;
        }
        
        public bool Mod20(int n)
        {
            bool mod2012 = false;
            if (n % 20 == 1 || n % 20 == 2)
                mod2012 = true;
            return mod2012;
        }
        
        public bool Mod35(int n)
        {
            bool isMod = false;
            if (n % 3 == 0 || n % 5 == 0)
                isMod = true;
            if (n % 3 == 0 && n % 5 == 0)
                isMod = false;
            
            return isMod;
        }
        
        public bool AnswerCell(bool isMorning, bool isMom, bool isAsleep)
        {
            bool doAnswer = true;
            if (isAsleep || isMorning && !isMom)
                doAnswer = false;
            return doAnswer;
        }
        
        public bool TwoIsOne(int a, int b, int c)
        {
            bool doesAdd = false;
            if (a + b == c || a + c == b || b + c == a)
                doesAdd = true;
            return doesAdd;
        }
        
        public bool AreInOrder(int a, int b, int c, bool bOk)
        {
            bool cba = false;
            if (!bOk && c > b && b > a ||bOk && c > a) 
                cba = true;
            return cba;

        }
        
        public bool InOrderEqual(int a, int b, int c, bool equalOk)
        {
            bool eql = false;
            if (!equalOk && c > b && b > a || equalOk && c >= a && b >= a)
                eql = true;
            return eql;
        }
        
        public bool LastDigit(int a, int b, int c)
        {
            bool lst = false;
            while (a > 10 || b > 10 || c > 10)
            {
                a %= 10;
                b %= 10;
                c %= 10;
            }
            if (a == b || b == c|| a == c)
                lst = true;
            return lst;
        }
        
        public int RollDice(int die1, int die2, bool noDoubles)
        {
            int diceSum = die1 + die2; ;

            if (die1 != die2)
            diceSum = die1 + die2;
            else if (noDoubles && die1 == die2)
            {
                if (die1 == 6)
                    die1 = 1;
                else
                {
                    die1++;
                }
                diceSum = die1 + die2;
            }
            return diceSum;
        }

    }
}
