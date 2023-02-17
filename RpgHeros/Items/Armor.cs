using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpgHeros.Heros;
using RpgHeros.Managers;

namespace RpgHeros.Items
{
    public class Armor : Item
    {
        public enum ArmorTypeEnum { Cloth, Leather, Mail, Plate }
        protected EquipmentManager.EquipSlotEnum equipSlot;
        protected ArmorTypeEnum armorType;

        protected HeroAttributes? armorAttributes;

        public Armor(string name, byte requiredLevel, EquipmentManager.EquipSlotEnum slot, ArmorTypeEnum armorType, HeroAttributes attributes) : base(name, requiredLevel)
        {
            this.name = name;
            this.requiredLevel = requiredLevel;
            equipSlot = slot;
            this.armorType = armorType;
            armorAttributes = attributes;
        }

        public EquipmentManager.EquipSlotEnum GetEquipSlot()
        {
            return equipSlot;
        }

        public ArmorTypeEnum GetArmorType() { return armorType; }

        public HeroAttributes? GetArmorAttributes() { return armorAttributes; }

    }
}
