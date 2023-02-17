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
            if (item.RequiredLevel > level)
            {
                Console.WriteLine("\n" + "Level Required to equip : " + item.Name + " Is Level " + item.RequiredLevel + "\n" + "Your current level is : " + level);
                return;
            }

            if (slot == EquipSlotEnum.Weapon)
            {
                Weapon weapon = (Weapon)item;
                if (equipableWeapon.Contains(weapon.GetWeaponType()))
                {
                    Console.WriteLine("\n" + "You have sucessfully equipped : " + weapon.Name);
                    if (equipment.ContainsKey(EquipSlotEnum.Weapon))
                    {
                        RemoveEquipment(weapon.GetEquipSlot(), null);
                        equipment.Add(weapon.GetEquipSlot(), weapon);
                    }
                    else
                    {
                        equipment.Add(weapon.GetEquipSlot(), weapon);
                    }

                }
                else
                {
                    Console.WriteLine("\n" + "You Cannot Equip Weapon Type : " + weapon.GetWeaponType().ToString());
                    Console.WriteLine("\n");
                }
            }

            else if (slot != EquipSlotEnum.Weapon)
            {
                Armor armor = (Armor)item;
                if (equipableArmor.Contains(armor.GetArmorType()))
                {
                    if (equipment.ContainsKey(armor.GetEquipSlot()))
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
                Weapon weapon = (Weapon)GetEquipment(slotToRemove);
                equipment.Remove(weapon.GetEquipSlot());
            }
            else if (slotToRemove != EquipSlotEnum.Weapon)
            {
                Armor armor = (Armor)GetEquipment(slotToRemove);
                HeroAttributes attributes = armor.GetArmorAttributes()!;
                Console.WriteLine("\n" + "Sucessfully Removed : " + armor.Name + "\n");
                dele.Invoke(attributes.GetStrength(), attributes.GetDexterity(), attributes.GetIntelligence(), '-');
                equipment.Remove(armor.GetEquipSlot());
            }
        }

        public Item GetEquipment(EquipSlotEnum slotToFetch) { Item item; equipment.TryGetValue(slotToFetch, out item); if (item != null) { return item; } return null; }

        public Dictionary<EquipSlotEnum, Item> GetEquipments() { return equipment; }
    }
}
