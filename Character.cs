using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena_FighterA
{
    public class Character
    {
        #region fields
        private static int count = 0;
        public string Name { get; set; }
        public string Rull { get; set; }
        public int Strength { get { return _strength; } set { _strength = value; } }
        public int BeginHealth { get { return _beginHealth; } set { _beginHealth = value; } }
        public int Health { get; set; }
        public int Line { get; set; }
        public char MoveIcon { get; set; }
        public int CharacterDice { get; set; }
        public int Lastposition { get { return _lastPosition; } set { _lastPosition = value; } }
        public int _lastPosition = 0;
        public int _strength = 0;
        public int _beginHealth = 0;
        #endregion
        public void CreateCharacter(string name)
        {
            Name = name;
            Strength = Round.RollDice(1,7);
            //if (count < 7)
            //{
                _lastPosition = Strength;
                count++;
            //}
            Health = Round.RollDice(1,4);
            BeginHealth = Health;
        }
        public void characterSpel()
        {
            release();
            CharacterDice = Round.RollDice(1,7);
            
            Round.MoveAhead(Line, MoveIcon, CharacterDice, ref _lastPosition);
            Round.Changestrength(Line, MoveIcon, ref _strength, ref _lastPosition);

        }
        public void release()
        {
            CharacterDice = 0;
            Strength = 0;
            Health = 0;
        }
    }
}

