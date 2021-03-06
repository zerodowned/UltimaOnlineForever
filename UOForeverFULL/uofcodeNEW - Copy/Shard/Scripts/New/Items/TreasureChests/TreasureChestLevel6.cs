using System;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Multis;
using Server.Network;
using Server.ContextMenus;
using Server.Engines.PartySystem;
using Server.Games;

namespace Server.Items
{
    public class TreasureChestLevel6 : LockableContainer
    {
        private const int m_Level = 6;

        public override bool Decays{ get{ return true; } } 

        public override TimeSpan DecayTime{ get{ return TimeSpan.FromMinutes( Utility.Random( 15, 60 ) ); } }

        private void SetChestAppearance()
        {

            bool UseFirstItemId = Utility.RandomBool();

            switch( Utility.RandomList(0, 1, 2 ) )
            {
                
                case 0:// Wooden Chest
                    this.ItemID = ( UseFirstItemId ? 0xe42 : 0xe43 );
                    this.GumpID = 0x49;
                    break;

                case 1:// Metal Chest
                    this.ItemID = ( UseFirstItemId ? 0x9ab : 0xe7c );
                    this.GumpID = 0x4A;
                    break;
                
                case 2:// Metal Golden Chest
                    this.ItemID = ( UseFirstItemId ? 0xe40 : 0xe41 );
                    this.GumpID = 0x42;
                    break;
            }
        }

        public override int DefaultGumpID{ get{ return 0x42; } }
        public override int DefaultDropSound{ get{ return 0x42; } }

        public override Rectangle2D Bounds
        {
            get{ return new Rectangle2D( 18, 105, 144, 73 ); }
        }

        [Constructable]
        public TreasureChestLevel6()
            : base(0xE41)
        {
            this.SetChestAppearance();
            Movable = false;
            LiftOverride = true;

            TrapType = TrapType.ExplosionTrap;
            TrapPower = m_Level * Utility.Random( 20, 35 );
            Locked = true;
            Breakable = false;

            RequiredSkill = 95;
            LockLevel = this.RequiredSkill - Utility.Random( 1, 10 );
            MaxLockLevel = this.RequiredSkill + 21;

            // According to OSI, loot in level 4 chest is:
            //  Gold 500 - 900
            //  Reagents
            //  Scrolls
            //  Blank scrolls
            //  Potions
            //  Gems
            //  Magic Wand
            //  Magic weapon
            //  Magic armour
            //  Magic clothing (not implemented)
            //  Magic jewelry (not implemented)
            //  Crystal ball (not implemented)

            // Gold
            DropItem( new Gold( Utility.Random( 1400, 2000 ) ) );
            
            // Reagents 
            for( int i = Utility.Random( 1, m_Level ); i > 1; i-- )
            {
                Item ReagentLoot = Loot.RandomReagent();
                ReagentLoot.Amount = 12;
                DropItem( ReagentLoot );
            }

            // Scrolls
            for( int i = Utility.Random( 1, m_Level ); i > 1; i-- )
            {
                Item ScrollLoot = Loot.RandomScroll( 0, 47, SpellbookType.Regular );
                ScrollLoot.Amount = Utility.Random(1, 3); ;
                DropItem( ScrollLoot );
            }

            // Drop blank scrolls
            DropItem( new BlankScroll( Utility.Random( 1, m_Level ) ) );

            // Potions
            for ( int i = Utility.Random( 1, m_Level ); i > 1; i-- )
            {
                Item PotionLoot = Loot.RandomPotion();
                DropItem( PotionLoot );
            }

            // Gems
            for( int i = Utility.Random( 1, m_Level ); i > 1; i-- )
            {
                Item GemLoot = Loot.RandomGem();
                GemLoot.Amount = Utility.Random(1, 4); ;
                DropItem( GemLoot );
            }


            // Equipment
            for( int i = Utility.Random( 1, m_Level ); i > 1; i-- )
            {
                Item item = Loot.RandomArmorOrShieldOrWeapon();

                if( item is BaseWeapon )
                {
                    BaseWeapon weapon = (BaseWeapon)item;
                    int damageLevel = PseudoSeerStone.GetDamageLevel(m_Level);
                    if (PseudoSeerStone.HighestDamageLevelSpawn < damageLevel)
                    {
                        if (damageLevel == 5 && PseudoSeerStone.ReplaceVanqWithSkillScrolls) { DropItem(PuzzleChest.CreateRandomSkillScroll()); }
                        int platAmount = PseudoSeerStone.PlatinumPerMissedDamageLevel * (damageLevel - PseudoSeerStone.Instance._HighestDamageLevelSpawn);
                        if (platAmount > 0) DropItem(new Platinum(platAmount));
                        damageLevel = PseudoSeerStone.Instance._HighestDamageLevelSpawn;
                    }
                    weapon.DamageLevel = (WeaponDamageLevel)damageLevel;
                    weapon.DurabilityLevel = (WeaponDurabilityLevel)PseudoSeerStone.GetDurabilityLevel(m_Level);
                    weapon.AccuracyLevel = (WeaponAccuracyLevel)PseudoSeerStone.GetAccuracyLevel(m_Level);
                    weapon.Quality = WeaponQuality.Regular;
                }
                else if( item is BaseArmor )
                {
                    BaseArmor armor = (BaseArmor)item;
                    armor.ProtectionLevel = (ArmorProtectionLevel)Utility.Random( m_Level );
                    armor.Durability = (ArmorDurabilityLevel)Utility.Random( m_Level );
                    armor.Quality = ArmorQuality.Regular;
                }

                DropItem( item );
            }

            // Clothing
            for( int i = Utility.Random( 1, 2 ); i > 1; i-- )
                DropItem( Loot.RandomClothing() );

            // Jewelry
            for( int i = Utility.Random( 1, 2 ); i > 1; i-- )
                DropItem( Loot.RandomJewelry() );

            // Crystal ball (not implemented)
        }

        public TreasureChestLevel6( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );
            writer.Write( (int) 1 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );
            int version = reader.ReadInt();
        }
    }
}
