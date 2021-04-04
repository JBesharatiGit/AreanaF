using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena_FighterA
{
    class Program
    {
        public static  Battle battle = new Battle();
        static int usualPosition = 0;
        static void Main(string[] args)
        {


            #region Start
            MakeCharacters();



            #endregion
 
            while (battle.endTotalFlag == false)
            {
                battle.GetOpponent();

                battle.PrintField(battle.characterList[0].Lastposition, battle.characterList1[0].Lastposition);
                usualPosition = Console.CursorTop;

                battle.writePost();

                Round.mydelay(2000);
                battle.Message("", 1);
                battle.endFlag = false;
                while (battle.endFlag == false)
                {
                    battle.characterList[0].characterSpel();

                    if (battle.characterList[0].Lastposition >= 50)
                    {
                        battle.characterList[0].Health = 1;
                        battle.characterList1[0].Health = -1;
                        battle.writePost();
                        battle.PrintPostBypost();
                        battle.RetirOrContinue();
                    }
                    else
                    {
                        battle.characterList1[0].characterSpel();

                        if (battle.characterList1[0].Lastposition >= 50)
                        {
                            battle.characterList1[0].Health = 1;
                            battle.characterList[0].Health = -1;
                            battle.writePost();
                            battle.PrintPostBypost();
                            battle.RetirOrContinue();
                        }
                        else
                        {
                            battle.Message("", 1);
                            battle.writePost();
                            battle.PrintPostBypost();
                        }
                    }
                }

                RetirOrContinueNext();

                
            }

            
        }

        public static  void RetirOrContinueNext()
        {
            //if (lstOnePass.Last().pTotalHealth > 0 && lstOnePass.Last().oTotalHealth > 0)
            //{
            ConsoleKeyInfo k = new ConsoleKeyInfo();
            //    WriteGame();

            //    printgameHistori();

            battle.Message("Continue Next Opponent?(y/n) ", 2);
            do
            {
                k = Console.ReadKey();
            } while (char.ToLower(k.KeyChar) != 'y' && char.ToLower(k.KeyChar) != 'n');

            if (char.ToLower(k.KeyChar) == 'y')
            {
                //ResetGame();
                battle.lstOnePass = new List<Fighters>();
                ResetPlayerCharacter();

                //battle.PrintField(battle.characterList[0].Lastposition, battle.characterList1[0].Lastposition);

                //battle.Message("", 1);
            }
            else
                battle.endTotalFlag = true;
            //}
            //else
            //{
            //    //printgameHistori();

            //    //if (lstOnePass.Last().pTotalHealth == 0)
            //    //    Message("You losed game and died.", 2);
            //    //else if (lstOnePass.Last().oTotalHealth == 0)
            //    //    Message("Your Opponent losed game and died.", 2);

            //    //endFlag = true;
            //}
        }
        static void ResetPlayerCharacter()
        {
            Character Plyer = new Character();
            Plyer.CreateCharacter("Ali");
            Plyer.Rull = "Player";
            Plyer.Line = 2;
            Plyer.MoveIcon = '#';
            battle.characterList[0]= Plyer;//.Add(Plyer);
        }
        static void MakeCharacters() 
        {
            Character Plyer = new Character();
            Plyer.CreateCharacter("Ali");
            Plyer.Rull = "Player";
            Plyer.Line = 2;
            Plyer.MoveIcon = '#';
            battle.characterList.Add(Plyer);

            Plyer = new Character();
            for (int q = 0; q < 4; q++)
            {
                Plyer.CreateCharacter("Rabite" + q);
                Plyer.Rull = "Opponent";
                Plyer.Line = 3;
                Plyer.MoveIcon = '?';
                battle.characterList.Add(Plyer);
                Plyer = new Character();
                //Console.WriteLine("{0,-10} {1,-10} {2} {3}", battle.characterList[0].Name, battle.characterList[0].Rull, battle.characterList[0].Strength, battle.characterList[0].Health);
                //Console.WriteLine("{0,-10} {1,-10} {2} {3}", battle.characterList1[0].Name, battle.characterList1[0].Rull, battle.characterList1[0].Strength, battle.characterList1[0].Health);

            }

        }
    }
}
