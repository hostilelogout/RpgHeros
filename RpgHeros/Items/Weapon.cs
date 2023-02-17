using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpgHeros.Managers;

namespace RpgHeros.Items
{
    public class Weapon : Item
    {
        public enum WeaponTypeEnum { Axe, Bow, Dagger, Hammer, Staff, Sword, Wand };
        protected EquipmentManager.EquipSlotEnum equipSlot;
        protected WeaponTypeEnum weaponType;

        protected float weaponDamage;

        public Weapon(string name, byte requiredLevel, float weaponDamage, EquipmentManager.EquipSlotEnum slot, WeaponTypeEnum weaponType) : base(name, requiredLevel)
        {
            this.name = name;
            this.requiredLevel = requiredLevel;
            equipSlot = slot;
            this.weaponType = weaponType;
            this.weaponDamage = weaponDamage;
        }
        // return the equipments slot
        public EquipmentManager.EquipSlotEnum GetEquipSlot()
        {
            return equipSlot;
        }

        // return the type of weapon
        public WeaponTypeEnum GetWeaponType() { return weaponType; }
        // returns the damage of the weapon
        public float GetWeaponDamage() { return weaponDamage; }

    }
}
