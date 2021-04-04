using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena_FighterA
{
    public class Battle
    {
        public  int usualPosition = 0;
        public bool endFlag = false;
        public bool endTotalFlag = false;

        //private static int  pDice=0,oDice=0;
        public  List<Character> characterList = new List<Character>();
        public  List<Character> characterList1 = new List<Character>();
        public List<Fighters> lstOnePass = new List<Fighters>();
        public List<List<Fighters>> games = new List<List<Fighters>>();

        //static OnePass onePass = new OnePass();
        //public static List<OnePass> onePass = new List<OnePass>();

        public  void GetOpponent()
        {

            foreach (var item in characterList)
            {
                if (item.Rull.Contains("Opponent"))
                {
                    //Console.WriteLine("{0,-10} {1,-10} {2} {3}", item.Name, item.Rull, item.Strength, item.Health);
                    characterList1 = new List<Character>();
                    characterList1.Add(item);
                    characterList.Remove(item);
                    break;
                }


            }
        }
        public  void writePost()
        {
            Fighters onePass = new Fighters(characterList1[0].Strength,
                                             characterList1[0].Health,
                                             characterList[0].Strength,
                                             characterList[0].Health
                                             );

            onePass.pName = characterList[0].Name;
            onePass.pDice = characterList[0].CharacterDice;
            onePass.pStrength = characterList[0].Strength;
            onePass.pHealth = characterList[0].Health;
            onePass.pBeginHealth = characterList[0].BeginHealth;
            onePass.pTotalHealth += Fighters.PTH;
            onePass.pTotalStrenth += Fighters.PTS;

            onePass.oName = characterList1[0].Name;
            onePass.oDice = characterList1[0].CharacterDice;
            onePass.oStrength = characterList1[0].Strength;
            onePass.oHealth = characterList1[0].Health;
            onePass.oBeginHealth = characterList1[0].BeginHealth;
            onePass.oTotalHealth += Fighters.OTH;
            onePass.oTotalStrenth += Fighters.OTS;

            lstOnePass.Add(onePass);
        }
        public void WriteGame()
        {
            List<Fighters> lstPass = new List<Fighters>();
            lstPass = lstOnePass;
            games.Add(lstPass);
        }
        public void RetirOrContinue()
        {
            if (lstOnePass.Last().pTotalHealth > 0 && lstOnePass.Last().oTotalHealth > 0)
            {
                ConsoleKeyInfo k = new ConsoleKeyInfo();
                WriteGame();

                printgameHistori();

                Message("Continue/Retire?(y/n)", 2);
                do
                {
                    k = Console.ReadKey();
                } while (char.ToLower(k.KeyChar) != 'y' && char.ToLower(k.KeyChar) != 'n');

                if (char.ToLower(k.KeyChar) == 'y')
                {
                    ResetGame();
                    Message("", 1);
                }
                else
                    endFlag = true;
            }
            else
            {
                printgameHistori();

                if (lstOnePass.Last().pTotalHealth == 0)
                    Message("You losed game and died.", 2);
                else if (lstOnePass.Last().oTotalHealth == 0)
                    Message("Your Opponent losed game and died.", 2);

                endFlag = true;
            }
        }
      
        public void ResetGame()
        {
            
            

            string playerContinue = characterList[0].Name;
            string OpponentContinue = characterList1[0].Name;

            //characterList[0] = new Character();
            //characterList1[0] = new Character();

            characterList[0].CreateCharacter(playerContinue);
            characterList1[0].CreateCharacter(OpponentContinue);

            characterList[0].Health = lstOnePass.Last().pTotalHealth;
            characterList1[0].Health = lstOnePass.Last().oTotalHealth;
            characterList[0].BeginHealth = lstOnePass.Last().pTotalHealth;
            characterList1[0].BeginHealth = lstOnePass.Last().oTotalHealth;

            PrintField(characterList[0].Lastposition, characterList1[0].Lastposition);

            lstOnePass = new List<Fighters>();
        }
        public void PrintField(int starPosPlyer,int starPosOpponent)
        {

            #region SetConsoleWinow
            Console.WindowTop = 0;
            Console.WindowLeft = 0;
            Console.WindowHeight = 50;
            Console.WindowWidth = 100;
            #endregion


            Console.Clear();
            for (int k = 0; k < 8; k++)
            {
                Console.WriteLine();
            }

            Console.WriteLine("      player                 Opponen ");
            Console.WriteLine("      [{0,5}]                [{1,-5}]", characterList[0].Name, characterList1[0].Name);
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("[Dice Strength Health] [Dice Strength Health]");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("{0,7}{1,9}{2,14}{3,9}", characterList[0].Strength, characterList[0].Health, characterList1[0].Strength, characterList1[0].Health);
            Console.WriteLine("----------------------------------------------");
            usualPosition = Console.CursorTop;

            Console.SetCursorPosition(starPosPlyer, 2);
            Console.WriteLine("#");
            Console.SetCursorPosition(starPosOpponent, 3);
            Console.WriteLine("?");

            Console.SetCursorPosition(10, 2);
            Console.WriteLine("-");
            Console.SetCursorPosition(10, 3);
            Console.WriteLine("-");
            Console.SetCursorPosition(15, 2);
            Console.WriteLine("*");
            Console.SetCursorPosition(15, 3);
            Console.WriteLine("*");

            Console.SetCursorPosition(25, 2);
            Console.WriteLine("+");
            Console.SetCursorPosition(25, 3);
            Console.WriteLine("+");
            Console.SetCursorPosition(50, 2);
            Console.WriteLine(";");
            Console.SetCursorPosition(50, 3);
            Console.WriteLine(":");
            Console.WriteLine();
            //Console.WriteLine("-------------------------------------------------");
            Console.WriteLine();
            Console.SetCursorPosition(0, usualPosition);
        }
        public void printgameHistori() 
        {
            Console.Clear();
            for (int k = 0; k < 8; k++)
            {
                Console.WriteLine();
            }

            Console.WriteLine("      player                 Opponen ");
            Console.WriteLine("      [{0,5}]                [{1,-5}]", characterList[0].Name, characterList1[0].Name);
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("[Dice Strength Health] [Dice Strength Health]");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("{0,7}{1,9}{2,14}{3,9}", lstOnePass[0].pStrength , lstOnePass[0].pBeginHealth , lstOnePass[0].oStrength, lstOnePass[0].oBeginHealth);
            Console.WriteLine("----------------------------------------------");
            usualPosition = Console.CursorTop;
            foreach (var item in lstOnePass)
            {
                Console.WriteLine("{0,2}{1,4}{2,10}{3,8}{4,6}{5,9}"/*,item.pName*/, item.pDice,item.pStrength,item.pHealth, item.oDice, item.oStrength, item.oHealth);

            }
            Console.WriteLine("-----------------------------------------------------");
            //lstOnePass.Reverse();
            
            Console.WriteLine("Player total health   : {0}", lstOnePass.Last().pTotalHealth/*lstOnePass[0].pTotalHealth*/);
            Console.WriteLine("Opponent total health : {0}", lstOnePass.Last().oTotalHealth /*lstOnePass[0].oTotalHealth*/);
        }
        public void PrintPostBypost() 
        {
            Fighters f = lstOnePass.Last();
            Console.SetCursorPosition(0, usualPosition);
            Console.WriteLine("{0,2}{1,4}{2,10}{3,8}{4,6}{5,9}"/*,item.pName*/, f.pDice, f.pStrength, f.pHealth, f.oDice, f.oStrength, f.oHealth);
            usualPosition = Console.CursorTop;

        }
        public void Message(string message, int option)
        {
            switch (option)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(0, 6);
                    //usualPosition = Console.CursorTop;
                    Console.WriteLine("roll Dice");

                    Console.ReadKey();
                    Round.mydelay(50);
                    Console.SetCursorPosition(0, 6);
                    //usualPosition = Console.CursorTop;
                    Console.WriteLine("Play     ");
                    Console.ResetColor();
                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(0, 6);
                    //usualPosition = Console.CursorTop;
                    Console.Write(message);
                    //Console.ReadKey();
                    Round.mydelay(50);
                    Console.ResetColor();
                    break;
                default:
                    break;
            }
        }
    }
}
