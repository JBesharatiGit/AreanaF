using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena_FighterA
{
    public class Round
    {
        # region Fields
        //private static int _lastPosition = 0;
        private static int _dice;
        private static Random rnd = new Random();
        public static int Dice { get { return _dice; } }
        #endregion
        public static int RollDice(int from,int to)
        {
            _dice = rnd.Next(from, to);
            return Dice;
        }

        //===============
        public static void MoveAhead(int line, char icon, int distance, ref int lastPosition)
        {
            int i = lastPosition;
            while (i < lastPosition + distance)
            {
                if (i > 0)
                {
                    Console.SetCursorPosition(i - 1, line);
                    Console.WriteLine(" ");
                }

                mydelay(50);
                Console.SetCursorPosition(i, line);
                Console.WriteLine(icon);
                mydelay(50);
                i++;
            }
            lastPosition = i;

            //PersonLog.Add((Dice + ',' + Strength).ToString());

        }
        public static void MoveBack(int line, char icon, int distance, ref int lastPosition)
        {
            int i = lastPosition;
            while (i > lastPosition + distance)
            {
                i--;
                if (i > 0)
                {
                    Console.SetCursorPosition(i + 1, line);
                    Console.WriteLine(" ");
                }

                mydelay(25);
                Console.SetCursorPosition(i, line);
                Console.WriteLine(icon);
                mydelay(25);
                //i++;
            }
            lastPosition = i;


        }
        public static void Changestrength(int line, char icon, ref int Strength, ref int lastPosition)
        {
            switch (lastPosition)
            {
                case 11:
                    mydelay(200);
                    Strength = -2;
                    MoveBack(line, icon, -2, ref lastPosition);
                    break;
                case 16:
                    mydelay(200);
                    Strength = 4;
                    MoveAhead(line, icon, 4, ref lastPosition);
                    break;
                case 26:
                    mydelay(200);
                    Strength = 2;
                    MoveAhead(line, icon, 2, ref lastPosition);
                    break;
                case 50:
                    break;
                default:
                    break;
            }
            //PersonLog.Add((Dice + ',' + Strength).ToString());
        }
        public static void mydelay(double seconds)
        {
            DateTime d = DateTime.Now.AddMilliseconds(seconds);
            do { } while (DateTime.Now < d);
        }

    }
}

