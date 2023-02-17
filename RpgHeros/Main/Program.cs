using RpgHeros.Heros;
using RpgHeros.Items;
using RpgHeros.Managers;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices;

public class Program
{
    static void Main()
    {
    Start:
        Console.WriteLine("Welcome to RPG Heroes." + "\n");
        Dictionary<byte, String> heros = new Dictionary<byte, string>()
        {
            {1,"Warrior"},
            {2,"Ranger"},
            {3,"Rogue"},
            {4,"Mage"},
        };

        Console.WriteLine("Heros available to create");

        heros.ToList().ForEach(x => Console.WriteLine($"{x.Key}) :  {x.Value}")); // writes out each value to the console

        byte chooseHero; byte.TryParse(Console.ReadLine(), out chooseHero);  // try to parse the value from console as byte

        Console.WriteLine("\n");

        if (heros.ContainsKey(chooseHero))
        {
            Console.WriteLine("Creating New Hero of type : " + heros[chooseHero] + "\n");

            Hero hero = null;

            switch (heros[chooseHero])
            {
                case "Warrior":
                    hero = new Warrior();
                    break;
                case "Ranger":
                    hero = new Ranger();
                    break;
                case "Rogue":
                    hero = new Rogue();
                    break;
                case "Mage":
                    hero = new Mage();
                    break;
            }

            options:

            Dictionary<byte, String> options = new Dictionary<byte, string>()
            {
                {1,"Display Status"},
                {2,"Create Equipment"},
                {3,"Level up"},
                {4,"Display Equipment"},
            };

            options.ToList().ForEach(x => Console.WriteLine($"{x.Key}) :  {x.Value}")); // writes out each value to the console

            byte choosenOption; byte.TryParse(Console.ReadLine(), out choosenOption); // try to parse the value from console as byte

            switch (choosenOption)
            {
                case 1:
                    Console.Clear();
                    hero!.DisplayStatus();
                    goto options;
                case 2:
                    Console.WriteLine("\n");
                    Dictionary<byte, String> equipmentTypes = new Dictionary<byte, string>()
                        {
                            {1,"Weapon"},
                            {2,"Head"},
                            {3,"Body"},
                            {4,"Legs"}
                        };

                    equipmentTypes.ToList().ForEach(x => Console.WriteLine($"{x.Key}) :  {x.Value}")); // writes out each value to the console

                    byte choosenEquipmentType; byte.TryParse(Console.ReadLine(), out choosenEquipmentType); // try to parse the value from console as byte

                    if (choosenEquipmentType == 1)
                    {
                        WeaponChoice:
                        Console.WriteLine("\n");
                        Weapon weapon = null;
                        Dictionary<byte, String> weaponTypes = new Dictionary<byte, string>()
                        {
                            {1,"Axe"},
                            {2,"Bow"},
                            {3,"Dagger"},
                            {4,"Hammer"},
                            {5,"Staff"},
                            {6,"Sword"},
                            {7,"Wand"}
                        };

                        weaponTypes = weaponTypes.Where(x => hero!.EquipableWeapon().Any(y => y.ToString() == x.Value)).ToDictionary(x => x.Key, x => x.Value); // sort out the types we cannot choose as the specific hero and then converts it back to a dictonary
                        weaponTypes.ToList().ForEach(x => Console.WriteLine($"{x.Key}) :  {x.Value}")); // writes each value found in dictonary to console
                     

                        byte choosenWeaponType; byte.TryParse(Console.ReadLine(), out choosenWeaponType); // try to parse the value from console as byte
                        Console.WriteLine("\n");

                        if (weaponTypes.ContainsKey(choosenWeaponType)) // checks the collection if key exist if so go on otherwise go false
                        {
                            Console.WriteLine("Choose a name for your weapon");
                            string weaponName = Console.ReadLine()!;

                            Console.WriteLine("\n");
                            Console.WriteLine("Choose a required Level for your weapon");
                            byte weaponLevel; byte.TryParse(Console.ReadLine(), out weaponLevel);

                            Console.WriteLine("\n");
                            Console.WriteLine("Choose your weapon damage.");
                            float weaponDamage; float.TryParse(Console.ReadLine(), out weaponDamage);
                            Console.WriteLine("\n");

                            Console.WriteLine("Creating Weapon : \n");
                            Console.WriteLine("WeaponName : " + $"{weaponName}");
                            Console.WriteLine("RequiredLevel : " + $"{weaponLevel}");
                            Console.WriteLine("WeaponDamage : " + $"{weaponDamage,0:0.00}");
                            Console.WriteLine("\n");

                            Weapon.WeaponTypeEnum weaponType; Enum.TryParse(weaponTypes[choosenWeaponType].ToString(), false, out weaponType); // try and parse the byte value and match it to anything in the collection if true return the type otherwise return nothing

                            weapon = new Weapon(weaponName, weaponLevel, weaponDamage, EquipmentManager.EquipSlotEnum.Weapon, weaponType); // creates a new instance of the weapon class and pass in values
                            hero!.GetEquipmentManager().Equip(hero.GetHeroLevel(), weapon, weapon.GetEquipSlot(), hero.EquipableWeapon(), hero.EquipableArmor(), null!); // equip the given equipment.
                        }
                        
                        else
                        {
                            Console.WriteLine("Choosen Type does not exist");
                            Console.Clear();
                            goto WeaponChoice;
                        }
                    }
                    else
                    {
                        ArmnorChoice:
                        Console.WriteLine("\n");
                        Dictionary<byte, String> armorTypes = new Dictionary<byte, string>()
                        {
                            {1,"Cloth"},
                            {2,"Leather"},
                            {3,"Mail"},
                            {4,"Plate"}
                        };

                        armorTypes = armorTypes.Where(x => hero!.EquipableWeapon().Any(y => y.ToString() == x.Value)).ToDictionary(x => x.Key, x => x.Value); // sort out the types we cannot choose as the specific hero and then converts it back to a dictonary
                        armorTypes.ToList().ForEach(x => Console.WriteLine($"{x.Key}) :  {x.Value}")); // writes each value found in dictonary to console

                        byte choosenArmorType; byte.TryParse(Console.ReadLine(), out choosenArmorType); // try to parse the value from console as byte
                        if (armorTypes.ContainsKey(choosenArmorType)) // checks the collection if key exist if so go on otherwise go false
                        {
                            Console.WriteLine("\n");

                            Console.WriteLine("Choose a name for your Armor");
                            string armorName = Console.ReadLine()!;

                            Console.WriteLine("\n");
                            Console.WriteLine("Choose a required Level for your armor");
                            byte armorLevel; byte.TryParse(Console.ReadLine(), out armorLevel);

                            Console.WriteLine("\n");
                            Console.WriteLine("Choose amount of strength");
                            byte strength; byte.TryParse(Console.ReadLine(), out strength);

                            Console.WriteLine("Choose amount of dexterity");
                            byte dexterity; byte.TryParse(Console.ReadLine(), out dexterity);

                            Console.WriteLine("Choose amount of intelligence");
                            byte intelligence; byte.TryParse(Console.ReadLine(), out intelligence);

                            Console.WriteLine("\n");

                            Console.WriteLine("Creating Armor : \n");
                            Console.WriteLine("ArmorName : " + $"{armorName}");
                            Console.WriteLine("RequiredLevel : " + $"{armorLevel}");
                            Console.WriteLine($"strngth : {strength} \ndexterity : {dexterity} \nintelligence : {intelligence}");
                            Console.WriteLine("\n");

                            Armor.ArmorTypeEnum armorType; Enum.TryParse(armorTypes[choosenArmorType].ToString(), false, out armorType); // try and parse the byte value and match it to anything in the collection if true return the type otherwise return nothing
                            EquipmentManager.EquipSlotEnum equipmentSlot; Enum.TryParse(equipmentTypes[choosenEquipmentType].ToString(), false, out equipmentSlot); // try and parse the byte value and match it to anything in the collection if true return the type otherwise return nothing

                            Armor armor = new Armor(armorName, armorLevel, equipmentSlot, armorType, new HeroAttributes(strength, dexterity, intelligence)); // Create a new armor class with parameters

                            hero!.GetEquipmentManager().Equip(hero.GetHeroLevel(), armor, armor.GetEquipSlot(), hero.EquipableWeapon(), hero.EquipableArmor(), hero.GetHeroAttributes()!.UpdateAttributesEvent!); // equips the new armor and pass along the hero's update event
                        }

                        else
                        {
                            Console.WriteLine("Choosen Type does not exist");
                            Console.Clear();
                            goto ArmnorChoice;
                        }

                    }

                    goto options;
                case 3:
                    Console.Clear();
                    hero!.LevelUp();
                    goto options;
                case 4:
                    Console.Clear();
                    foreach (var item in hero!.GetEquipmentManager().GetEquipments())
                    {
                        if(item.Key == EquipmentManager.EquipSlotEnum.Weapon)
                        {
                            Weapon weapon = (Weapon)item.Value;

                            Console.WriteLine($"Equipment Type : {item.Key}");
                            Console.WriteLine($"Weapon Name : {weapon.Name}");
                            Console.WriteLine($"Required Level : {weapon.RequiredLevel}");
                            Console.WriteLine($"Weapon Type : {weapon.GetWeaponType().ToString()}");
                            Console.WriteLine($"WeaponDamage : {weapon.GetWeaponDamage(),0:0.00}");
                        }
                        else
                        {
                            Armor armor = (Armor)item.Value;

                            Console.WriteLine($"Equipment Type : {item.Key}");
                            Console.WriteLine($"Equipment Name : {armor.Name}");
                            Console.WriteLine($"Required Level : {armor.RequiredLevel}");
                            Console.WriteLine($"Armor Type : {armor.GetArmorType().ToString()}");
                            armor.GetArmorAttributes()!.DisplayStats();
                        }
                    }
                    Console.WriteLine("\n");
                    goto options;
            }
        }
        else
        {
            Console.WriteLine("Choosen option does not exist.");
            System.Threading.Thread.Sleep(1500);
            Console.Clear();
            goto Start;
        }

        Console.WriteLine("\n");

        Console.ReadKey();
    }
}