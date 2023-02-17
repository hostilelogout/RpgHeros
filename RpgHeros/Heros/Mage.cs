using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpgHeros.Items;
using RpgHeros.Managers;

namespace RpgHeros.Heros
{
    public sealed class Mage : Hero
    {
        public Mage(string name = "Mage", byte level = 1, Weapon.WeaponTypeEnum[] validWeapons = null, Armor.ArmorTypeEnum[] validArmors = null) : base(name, level, validWeapons, validArmors)
        {
            this.name = name;  // assign name to the hero
            this.level = level; // assign given level
            heroAttributes = new HeroAttributes(1, 1, 8); // assign a new HeroAttribute instance and pass values 
            this.validWeapons = new Weapon.WeaponTypeEnum[] { Weapon.WeaponTypeEnum.Wand, Weapon.WeaponTypeEnum.Staff }; // assign a new collection of equipable weapons
            this.validArmors = new Armor.ArmorTypeEnum[] { Armor.ArmorTypeEnum.Cloth }; // assign a new collection of equipable armor
            equipmentManager = new EquipmentManager(); // create and assign a new instance of equipment manager to the hero
        }


        public override float CalculateDamage()
        {
            if ((Weapon)equipmentManager!.GetEquipment(EquipmentManager.EquipSlotEnum.Weapon) != null)
            {
                float damage = ((Weapon)equipmentManager!.GetEquipment(EquipmentManager.EquipSlotEnum.Weapon)).GetWeaponDamage() * (1 + (float)heroAttributes!.GetIntelligence() / 100);
                Console.WriteLine($"Delt Damage : {damage,0:0.00}");
                return damage;
            }
            Console.WriteLine("Delt Damage : " + 1f.ToString());
            return 1f;
        }

        public override byte CurrentLevel()
        {
            return level;
        }

        public override void DisplayStatus()
        {
            Console.WriteLine("Class Type : " + name);
            Console.WriteLine("Current Level : " + level);

            Console.WriteLine("\n");

            validWeapons!.ToList().ForEach(x => Console.WriteLine("Equipable Weapon : " + x.ToString()));
            validArmors!.ToList().ForEach(x => Console.WriteLine("Equipable Armor : " + x.ToString()));

            Console.WriteLine("\n");

            heroAttributes!.DisplayStats();

            Console.WriteLine("\n");

            CalculateDamage();

            Console.WriteLine("\n");
        }

        public override Armor.ArmorTypeEnum[] EquipableArmor()
        {
            return validArmors;
        }

        public override Weapon.WeaponTypeEnum[] EquipableWeapon()
        {
            return validWeapons;
        }

        public override EquipmentManager GetEquipmentManager()
        {
            return equipmentManager;
        }

        public override HeroAttributes GetHeroAttributes()
        {
            return heroAttributes;
        }

        public override byte GetHeroLevel()
        {
            return level;
        }

        public override string GetHeroName()
        {
            return name;
        }

        public override void LevelUp()
        {
            Console.WriteLine($"old level : {level}");
            Console.WriteLine($"old strngth : {heroAttributes!.GetStrength()} \nold dexterity : {heroAttributes!.GetDexterity()} \nold intelligence : {heroAttributes!.GetIntelligence()}");
            level++;
            heroAttributes!.UpdateAttributesEvent!.Invoke(1, 1, 5, '+');
            Console.WriteLine("\n");
            Console.WriteLine($"new level : {level}");
            Console.WriteLine($"new strngth : {heroAttributes!.GetStrength()} \nnew dexterity : {heroAttributes!.GetDexterity()} \nnew intelligence : {heroAttributes!.GetIntelligence()}");
            Console.WriteLine("\n");
        }

    }
}
