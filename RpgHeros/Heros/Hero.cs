using RpgHeros.Items;
using RpgHeros.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgHeros.Heros
{
    public abstract class Hero
    {
        protected string name;
        protected byte level;
        protected HeroAttributes? heroAttributes;
        protected Weapon.WeaponTypeEnum[]? validWeapons;
        protected Armor.ArmorTypeEnum[]? validArmors;
        protected EquipmentManager? equipmentManager;

        public Hero(string name, byte level, Weapon.WeaponTypeEnum[] validWeapons, Armor.ArmorTypeEnum[] validArmors)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.level = level;
            this.validWeapons = validWeapons;
            this.validArmors = validArmors;
        }

        public abstract void LevelUp(); // levels up the hero
        public abstract float CalculateDamage(); // returns the damage based on weapon

        public abstract void DisplayStatus(); // defines what should be displayed 

        public abstract byte CurrentLevel(); // returns current level

        public abstract string GetHeroName(); // returns the hero name

        public abstract byte GetHeroLevel(); // returns a level

        public abstract EquipmentManager GetEquipmentManager(); // returns the equipment manager

        public abstract HeroAttributes GetHeroAttributes(); // returns the attribute class

        public abstract Weapon.WeaponTypeEnum[] EquipableWeapon(); // returns all equipable weapons

        public abstract Armor.ArmorTypeEnum[] EquipableArmor(); // returns all equipable armor
    }
}
