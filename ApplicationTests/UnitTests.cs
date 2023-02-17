using RpgHeros.Heros;
using RpgHeros.Items;
using RpgHeros.Managers;

namespace ApplicationTests
{

    public class UnitTests
    {
        [Fact]
        public void TestValidRangerCreation()
        {
            // Creates a Ranger class.
            Ranger ranger = new Ranger();

            // Test to see if expected name is correct
            Assert.Equal("Ranger",ranger.GetHeroName()); // should return Ranger

            //Test to see if the correct level is given
            Assert.Equal(1,ranger.GetHeroLevel()); // should return level 1

            //Test to see if hero has been given the correct attributes at level 1 should be 1, 7, 1
            Assert.Equal(1, ranger.GetHeroAttributes().GetStrength());
            Assert.Equal(7, ranger.GetHeroAttributes().GetDexterity());
            Assert.Equal(1, ranger.GetHeroAttributes().GetIntelligence());
        }

        [Fact]
        public void TestValidWarriorCreation()
        {
            // Creates a Warrior class.
            Warrior warrior = new Warrior();

            // Test to see if expected name is correct
            Assert.Equal("Warrior", warrior.GetHeroName()); // should return Ranger

            //Test to see if the correct level is given
            Assert.Equal(1, warrior.GetHeroLevel()); // should return level 1

            //Test to see if hero has been given the correct attributes at level 1 should be 5, 2, 1
            Assert.Equal(5, warrior.GetHeroAttributes().GetStrength());
            Assert.Equal(2, warrior.GetHeroAttributes().GetDexterity());
            Assert.Equal(1, warrior.GetHeroAttributes().GetIntelligence());
        }

        [Fact]
        public void TestValidMageCreation()
        {
            // Creates a Ranger class.
            Mage mage = new Mage();

            // Test to see if expected name is correct
            Assert.Equal("Mage", mage.GetHeroName()); // should return Ranger

            //Test to see if the correct level is given
            Assert.Equal(1, mage.GetHeroLevel()); // should return level 1

            //Test to see if hero has been given the correct attributes at level 1 should be 1, 1, 8
            Assert.Equal(1, mage.GetHeroAttributes().GetStrength());
            Assert.Equal(1, mage.GetHeroAttributes().GetDexterity());
            Assert.Equal(8, mage.GetHeroAttributes().GetIntelligence());
        }

        [Fact]
        public void TestValidRogueCreation()
        {
            // Creates a Ranger class.
            Rogue rogue = new Rogue();

            // Test to see if expected name is correct
            Assert.Equal("Rogue", rogue.GetHeroName()); // should return Ranger

            //Test to see if the correct level is given
            Assert.Equal(1, rogue.GetHeroLevel()); // should return level 1

            //Test to see if hero has been given the correct attributes at level 1 should be 2, 6, 1
            Assert.Equal(2, rogue.GetHeroAttributes().GetStrength());
            Assert.Equal(6, rogue.GetHeroAttributes().GetDexterity());
            Assert.Equal(1, rogue.GetHeroAttributes().GetIntelligence());
        }

        [Fact]
        public void TestValidRangerLevelUp()
        {
            // Creates a Ranger class.
            Ranger ranger = new Ranger();

            // Test the current level first.
            Assert.Equal(1, ranger.GetHeroLevel());

            //Level up the hero and check the level increase should increase by 1, 5, 1
            ranger.LevelUp();
            Assert.Equal(2, ranger.GetHeroLevel());
            //Check for valid Attribute increase
            Assert.Equal(2, ranger.GetHeroAttributes().GetStrength());
            Assert.Equal(12, ranger.GetHeroAttributes().GetDexterity());
            Assert.Equal(2, ranger.GetHeroAttributes().GetIntelligence());
        }

        [Fact]
        public void TestValidRogueLevelUp()
        {
            // Creates a Rogue class.
            Rogue rogue = new Rogue();

            // Test the current level first.
            Assert.Equal(1, rogue.GetHeroLevel());

            //Level up the hero and check the level increase should increase by 3, 10, 2
            rogue.LevelUp();
            Assert.Equal(2, rogue.GetHeroLevel());
            //Check for valid Attribute increase
            Assert.Equal(3, rogue.GetHeroAttributes().GetStrength());
            Assert.Equal(10, rogue.GetHeroAttributes().GetDexterity());
            Assert.Equal(2, rogue.GetHeroAttributes().GetIntelligence());
        }

        [Fact]
        public void TestValidWarriorLevelUp()
        {
            // Creates a Warrior class.
            Warrior warrior = new Warrior();

            // Test the current level first.
            Assert.Equal(1, warrior.GetHeroLevel());

            //Level up the hero and check the level increase should increase by 8, 4, 2
            warrior.LevelUp();
            Assert.Equal(2, warrior.GetHeroLevel());
            //Check for valid Attribute increase
            Assert.Equal(8, warrior.GetHeroAttributes().GetStrength());
            Assert.Equal(4, warrior.GetHeroAttributes().GetDexterity());
            Assert.Equal(2, warrior.GetHeroAttributes().GetIntelligence());
        }

        [Fact]
        public void TestValidMageLevelUp()
        {
            // Creates a Mage class.
            Mage mage = new Mage();

            // Test the current level first.
            Assert.Equal(1, mage.GetHeroLevel());

            //Level up the hero and check the level increase should increase by 1, 1, 5
            mage.LevelUp();
            Assert.Equal(2, mage.GetHeroLevel());
            //Check for valid Attribute increase
            Assert.Equal(2, mage.GetHeroAttributes().GetStrength());
            Assert.Equal(2, mage.GetHeroAttributes().GetDexterity());
            Assert.Equal(13, mage.GetHeroAttributes().GetIntelligence());
        }

        [Fact]
        public void TestWeaponCreation()
        {
            // creates a weapon
            Weapon newWeapon = new Weapon("Broken Axe",1,0.4f,EquipmentManager.EquipSlotEnum.Weapon,Weapon.WeaponTypeEnum.Axe);

            //Check if if has been given the correct slot type
            Assert.True(newWeapon.GetEquipSlot() == EquipmentManager.EquipSlotEnum.Weapon);

            //check if it has been given the correct weapon type
            Assert.True(newWeapon.GetWeaponType() == Weapon.WeaponTypeEnum.Axe);

            //check if the required level has been set correctly
            Assert.Equal(1, newWeapon.RequiredLevel);
        }

        [Fact]
        public void TestValidArmorCreation()
        {
            // creates a armor
            Armor newArmor = new Armor("Simple Cloth helm",1, EquipmentManager.EquipSlotEnum.Head,Armor.ArmorTypeEnum.Cloth,new HeroAttributes(0,0,2));

            //Check if if has been given the correct slot type
            Assert.True(newArmor.GetEquipSlot() == EquipmentManager.EquipSlotEnum.Head);

            //check if it has been given the correct armor type
            Assert.True(newArmor.GetArmorType() == Armor.ArmorTypeEnum.Cloth);

            //check if the required level has been set correctly
            Assert.Equal(1, newArmor.RequiredLevel);
        }

        [Fact]
        public void TestAttributesWithNoEquipment()
        {
            // Creates a Warrior class.
            Warrior warrior = new Warrior();


            //Test to see if hero has been given the correct attributes at level 1 should be 5, 2, 1
            Assert.Equal(5, warrior.GetHeroAttributes().GetStrength());
            Assert.Equal(2, warrior.GetHeroAttributes().GetDexterity());
            Assert.Equal(1, warrior.GetHeroAttributes().GetIntelligence());
            Assert.Equal(1, warrior.CalculateDamage());
        }

        [Fact]
        public void TestArributesWithOneEquipment()
        {
            // Creates a Warrior class.
            Warrior warrior = new Warrior();

            Armor newArmor = new Armor("Simple Plate helm", 1, EquipmentManager.EquipSlotEnum.Head, Armor.ArmorTypeEnum.Plate, new HeroAttributes(2, 0, 0));

            warrior.GetEquipmentManager().Equip(warrior.GetHeroLevel(),newArmor,EquipmentManager.EquipSlotEnum.Head,warrior.EquipableWeapon(),warrior.EquipableArmor(),warrior!.GetHeroAttributes()!.UpdateAttributesEvent!);

            Assert.Equal(7, warrior.GetHeroAttributes().GetStrength());
            Assert.Equal(2, warrior.GetHeroAttributes().GetDexterity());
            Assert.Equal(1, warrior.GetHeroAttributes().GetIntelligence());
            Assert.Equal(1, warrior.CalculateDamage());
        }

        [Fact]
        public void TestArributesWithTwoEquipment()
        {
            // Creates a Warrior class.
            Warrior warrior = new Warrior();

            Armor helm = new Armor("Simple Plate helm", 1, EquipmentManager.EquipSlotEnum.Head, Armor.ArmorTypeEnum.Plate, new HeroAttributes(2, 0, 0));
            Armor body = new Armor("Simple Plate Body", 1, EquipmentManager.EquipSlotEnum.Body, Armor.ArmorTypeEnum.Plate, new HeroAttributes(4, 0, 0));

            warrior.GetEquipmentManager().Equip(warrior.GetHeroLevel(), helm, EquipmentManager.EquipSlotEnum.Head, warrior.EquipableWeapon(), warrior.EquipableArmor(), warrior!.GetHeroAttributes()!.UpdateAttributesEvent!);
            warrior.GetEquipmentManager().Equip(warrior.GetHeroLevel(), body, EquipmentManager.EquipSlotEnum.Head, warrior.EquipableWeapon(), warrior.EquipableArmor(), warrior!.GetHeroAttributes()!.UpdateAttributesEvent!);

            Assert.Equal(11, warrior.GetHeroAttributes().GetStrength());
            Assert.Equal(2, warrior.GetHeroAttributes().GetDexterity());
            Assert.Equal(1, warrior.GetHeroAttributes().GetIntelligence());
            Assert.Equal(1, warrior.CalculateDamage());
        }

        [Fact]
        public void TestArributesWithThreeEquipment()
        {
            // Creates a Warrior class.
            Warrior warrior = new Warrior();

            Armor helm = new Armor("Simple Plate helm", 1, EquipmentManager.EquipSlotEnum.Head, Armor.ArmorTypeEnum.Plate, new HeroAttributes(2, 0, 0));
            Armor body = new Armor("Simple Plate body", 1, EquipmentManager.EquipSlotEnum.Body, Armor.ArmorTypeEnum.Plate, new HeroAttributes(4, 0, 0));
            Armor legs = new Armor("Simple Plate Legs", 1, EquipmentManager.EquipSlotEnum.Legs, Armor.ArmorTypeEnum.Plate, new HeroAttributes(3, 0, 0));

            warrior.GetEquipmentManager().Equip(warrior.GetHeroLevel(), helm, EquipmentManager.EquipSlotEnum.Head, warrior.EquipableWeapon(), warrior.EquipableArmor(), warrior!.GetHeroAttributes()!.UpdateAttributesEvent!);
            warrior.GetEquipmentManager().Equip(warrior.GetHeroLevel(), body, EquipmentManager.EquipSlotEnum.Head, warrior.EquipableWeapon(), warrior.EquipableArmor(), warrior!.GetHeroAttributes()!.UpdateAttributesEvent!);
            warrior.GetEquipmentManager().Equip(warrior.GetHeroLevel(), legs, EquipmentManager.EquipSlotEnum.Head, warrior.EquipableWeapon(), warrior.EquipableArmor(), warrior!.GetHeroAttributes()!.UpdateAttributesEvent!);

            Assert.Equal(14, warrior.GetHeroAttributes().GetStrength());
            Assert.Equal(2, warrior.GetHeroAttributes().GetDexterity());
            Assert.Equal(1, warrior.GetHeroAttributes().GetIntelligence());
            Assert.Equal(1, warrior.CalculateDamage());
        }

        [Fact]
        public void TestArributesWithFullEquipmentIncludingWeapon()
        {
            // Creates a Warrior class.
            Warrior warrior = new Warrior();

            Armor helm = new Armor("Simple Plate helm", 1, EquipmentManager.EquipSlotEnum.Head, Armor.ArmorTypeEnum.Plate, new HeroAttributes(2, 0, 0));
            Armor body = new Armor("Simple Plate body", 1, EquipmentManager.EquipSlotEnum.Body, Armor.ArmorTypeEnum.Plate, new HeroAttributes(4, 0, 0));
            Armor legs = new Armor("Simple Plate Legs", 1, EquipmentManager.EquipSlotEnum.Legs, Armor.ArmorTypeEnum.Plate, new HeroAttributes(3, 0, 0));

            Weapon weapon = new Weapon("Simple Sword",1,2,EquipmentManager.EquipSlotEnum.Weapon,Weapon.WeaponTypeEnum.Sword);

            warrior.GetEquipmentManager().Equip(warrior.GetHeroLevel(), helm, EquipmentManager.EquipSlotEnum.Head, warrior.EquipableWeapon(), warrior.EquipableArmor(), warrior!.GetHeroAttributes()!.UpdateAttributesEvent!);
            warrior.GetEquipmentManager().Equip(warrior.GetHeroLevel(), body, EquipmentManager.EquipSlotEnum.Head, warrior.EquipableWeapon(), warrior.EquipableArmor(), warrior!.GetHeroAttributes()!.UpdateAttributesEvent!);
            warrior.GetEquipmentManager().Equip(warrior.GetHeroLevel(), legs, EquipmentManager.EquipSlotEnum.Head, warrior.EquipableWeapon(), warrior.EquipableArmor(), warrior!.GetHeroAttributes()!.UpdateAttributesEvent!);
            warrior.GetEquipmentManager().Equip(warrior.GetHeroLevel(), weapon, EquipmentManager.EquipSlotEnum.Weapon, warrior.EquipableWeapon(), warrior.EquipableArmor(),null!);


            Assert.Equal(14, warrior.GetHeroAttributes().GetStrength());
            Assert.Equal(2, warrior.GetHeroAttributes().GetDexterity());
            Assert.Equal(1, warrior.GetHeroAttributes().GetIntelligence());
            Assert.Equal(2.28f, warrior.CalculateDamage());
        }

        [Fact]
        public void TestDamageWithNoWWeapon()
        {
            // Creates a Warrior class.
            Warrior warrior = new Warrior();

            Assert.Equal(1f, warrior.CalculateDamage());
        }

        [Fact]
        public void TestDamageWithWWeapon()
        {
            // Creates a Warrior class.
            Warrior warrior = new Warrior();
            Weapon weapon = new Weapon("Simple Sword", 1, 2, EquipmentManager.EquipSlotEnum.Weapon, Weapon.WeaponTypeEnum.Sword);
            warrior.GetEquipmentManager().Equip(warrior.GetHeroLevel(), weapon, EquipmentManager.EquipSlotEnum.Weapon, warrior.EquipableWeapon(), warrior.EquipableArmor(), null!);

            Assert.Equal(2.1f, warrior.CalculateDamage());
        }

        [Fact]
        public void TestTotalAttributes()
        {
            // Creates a Warrior class.
            Warrior warrior = new Warrior();
            Weapon weapon = new Weapon("Simple Sword", 1, 2, EquipmentManager.EquipSlotEnum.Weapon, Weapon.WeaponTypeEnum.Sword);
            warrior.GetEquipmentManager().Equip(warrior.GetHeroLevel(), weapon, EquipmentManager.EquipSlotEnum.Weapon, warrior.EquipableWeapon(), warrior.EquipableArmor(), null!);

            Assert.Equal(8, warrior.GetHeroAttributes().GetTotalAttributes()); // based on a lvl 1 warrior should return 8
        }

    }
}