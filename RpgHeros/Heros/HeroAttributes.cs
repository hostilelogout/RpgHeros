using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgHeros.Heros
{
    public sealed class HeroAttributes
    {
        byte strength;
        byte dexterity;
        byte intelligence;
        short totalAttributes;

        public delegate void UpdateAttributesDele(byte strength, byte dexterity, byte intelligence, char modifier); // creates a delegate
        public UpdateAttributesDele? UpdateAttributesEvent; // uses the delegate and assign a strong typed delegate for invoking

        public HeroAttributes(byte strength, byte dexterity, byte intelligence)
        {
            this.strength = strength;
            this.dexterity = dexterity;
            this.intelligence = intelligence;
            CalculateTotalAttributes();
            UpdateAttributesEvent += UpdateAttributes; // assign the delegate to the method UpdateAttributes so it can be called
        }

        short CalculateTotalAttributes() { return totalAttributes = (short)(strength + dexterity + intelligence); } // returns the total attributes

        public void DisplayStats()
        {
            Console.WriteLine("Total Strength : " + strength);
            Console.WriteLine("Total Dexterity : " + dexterity);
            Console.WriteLine("Total Intelligence : " + intelligence);
            Console.WriteLine("Total Attributes : " + totalAttributes);
        }

        public byte GetStrength() { return strength; } // returns strength
        public byte GetDexterity() { return dexterity; } // return dexerity
        public byte GetIntelligence() { return intelligence; } // returns intelligence
        public short GetTotalAttributes() { return totalAttributes; } // returns the total amount

        void UpdateAttributes(byte strength, byte dexterity, byte intelligence, char modifier) // updates the heros attributes by invoking the delegate. 
        {
            switch (modifier)
            {
                case '+':
                    this.strength += strength;
                    this.dexterity += dexterity;
                    this.intelligence += intelligence;
                    break;
                case '-':
                    this.strength -= strength;
                    this.dexterity -= dexterity;
                    this.intelligence -= intelligence;
                    break;
            }

            CalculateTotalAttributes();
        }

    }
}
