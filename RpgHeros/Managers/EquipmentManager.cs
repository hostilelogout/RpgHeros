using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using RpgHeros.Heros;
using RpgHeros.Items;

namespace RpgHeros.Managers
{
    public sealed class EquipmentManager
    {
        public enum EquipSlotEnum { Weapon, Head, Body, Legs }

        protected Dictionary<EquipSlotEnum, Item> equipment = new Dictionary<EquipSlotEnum, Item>();

        public void Equip(byte level, Item item, EquipSlotEnum slot, Weapon.WeaponTypeEnum[] equipableWeapon, Armor.ArmorTypeEnum[] equipableArmor, HeroAttributes.UpdateAttributesDele dele)
        {
            if (item.RequiredLevel > level) // checks if item level is over heros level if so error out and do an early return
            {
                Console.WriteLine("\n" + "Level Required to equip : " + item.Name + " Is Level " + item.RequiredLevel + "\n" + "Your current level is : " + level);
                return;
            }

            if (slot == EquipSlotEnum.Weapon) // if the slot matches a weapon type continue
            {
                Weapon weapon = (Weapon)item; // creates a new instance of weapon and cast the item to weapon as we know it is of type weapon
                if (equipableWeapon.Contains(weapon.GetWeaponType())) // checks to see if the hero can equip the weapon of type weapon
                {
                    Console.WriteLine("\n" + "You have sucessfully equipped : " + weapon.Name);
                    if (equipment.ContainsKey(EquipSlotEnum.Weapon)) // checks to see if hero already has a weapon if so. replace it with the new one
                    {
                        RemoveEquipment(weapon.GetEquipSlot(), null);
                        equipment.Add(weapon.GetEquipSlot(), weapon);
                    }
                    else
                    {
                        equipment.Add(weapon.GetEquipSlot(), weapon); // otherwise just add the weapon to the equipment
                    }

                }
                else
                {
                    Console.WriteLine("\n" + "You Cannot Equip Weapon Type : " + weapon.GetWeaponType().ToString());
                    Console.WriteLine("\n");
                }
            }

            else if (slot != EquipSlotEnum.Weapon) // if not a weapon then it must be a armor.
            {
                Armor armor = (Armor)item; // creates a new instance of armor type casted from item
                if (equipableArmor.Contains(armor.GetArmorType())) // checks  if the hero can wear the type of armor
                {
                    if (equipment.ContainsKey(armor.GetEquipSlot())) // checks if armor already exist if so. equip new one and delete old one
                    {
                        RemoveEquipment(armor.GetEquipSlot(), armor.GetArmorAttributes()!.UpdateAttributesEvent!);

                        Console.WriteLine("\n" + "You have sucessfully equipped : " + armor.Name);
                        equipment.Add(armor.GetEquipSlot(), armor);
                        HeroAttributes attributes = armor.GetArmorAttributes()!;
                        dele.Invoke(attributes.GetStrength(), attributes.GetDexterity(), attributes.GetIntelligence(), '+');
                    }
                    else
                    {
                        Console.WriteLine("\n" + "You have sucessfully equipped : " + armor.Name);
                        equipment.Add(armor.GetEquipSlot(), armor);
                        HeroAttributes attributes = armor.GetArmorAttributes()!;
                        dele.Invoke(attributes.GetStrength(), attributes.GetDexterity(), attributes.GetIntelligence(), '+');
                    }

                }
                else
                {
                    Console.WriteLine("\n" + "You Cannot Equip Armor Type : " + armor.GetArmorType().ToString());
                    Console.WriteLine("\n");
                }
            }

        }

        public void RemoveEquipment(EquipSlotEnum slotToRemove, HeroAttributes.UpdateAttributesDele dele)
        {
            if (slotToRemove == EquipSlotEnum.Weapon)
            {
                Weapon weapon = (Weapon)GetEquipment(slotToRemove); // creates a instance of weapon and gets the equipment based on the slot
                equipment.Remove(weapon.GetEquipSlot()); // removes it from the collection based on the slot
            }
            else if (slotToRemove != EquipSlotEnum.Weapon)
            {
                Armor armor = (Armor)GetEquipment(slotToRemove); // creates a instance of armor and gets the current slot. 
                HeroAttributes attributes = armor.GetArmorAttributes()!; // creates a new instance of Hero Attributes and assign it to the one the armor has
                Console.WriteLine("\n" + "Sucessfully Removed : " + armor.Name + "\n");
                dele.Invoke(attributes.GetStrength(), attributes.GetDexterity(), attributes.GetIntelligence(), '-'); // invokes the update attribute event. to reflect changes on armor,
                equipment.Remove(armor.GetEquipSlot()); // finally remove the armor from collection
            }
        }

        public Item GetEquipment(EquipSlotEnum slotToFetch) { Item item; equipment.TryGetValue(slotToFetch, out item); if (item != null) { return item; } return null; } // returns specific type of equipment based on what slot it fetches

        public Dictionary<EquipSlotEnum, Item> GetEquipments() { return equipment; } // returns a collection of equipment
    }
}
