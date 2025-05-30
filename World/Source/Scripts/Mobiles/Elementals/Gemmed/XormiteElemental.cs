using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an elemental corpse" )]
	public class XormiteElemental : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		public override double DispelDifficulty{ get{ return 120.5; } }
		public override double DispelFocus{ get{ return 35.0; } }

		public override int BreathPhysicalDamage{ get{ return 50; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 50; } }
		public override int BreathEffectHue{ get{ return Hue-1; } }
		public override int BreathEffectSound{ get{ return 0x658; } }
		public override int BreathEffectItemID{ get{ return 0; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override double BreathEffectDelay{ get{ return 0.1; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 33 ); }

		[Constructable]
		public XormiteElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a xormite elemental";
			Body = 322;
			BaseSoundID = 268;
			Hue = 2966;
			Resource = CraftResource.Xormite;

			SetStr( 256, 385 );
			SetDex( 196, 215 );
			SetInt( 221, 242 );

			SetHits( 194, 211 );

			SetDamage( 18, 29 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Energy, 50 );

			SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Fire, 25, 35 );
			SetResistance( ResistanceType.Cold, 25, 35 );
			SetResistance( ResistanceType.Poison, 20, 30 );
			SetResistance( ResistanceType.Energy, 50, 60 );

			SetSkill( SkillName.Psychology, 40.5, 90.0 );
			SetSkill( SkillName.Magery, 40.5, 90.0 );
			SetSkill( SkillName.MagicResist, 60.1, 110.0 );
			SetSkill( SkillName.Tactics, 100.1, 130.0 );
			SetSkill( SkillName.FistFighting, 90.1, 120.0 );

			Fame = 7000;
			Karma = -7000;

			VirtualArmor = 60;

			AddItem( new LightSource() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average, 1 );
			AddLoot( LootPack.Rich, 1 );
		}

		public override bool BleedImmune{ get{ return true; } }
		public override int Rocks{ get{ return Utility.RandomMinMax( 5, 10 ); } }
		public override RockType RockType{ get{ return ResourceRocks(); } }

		public override void CheckReflect( Mobile caster, ref bool reflect )
		{
			if ( Utility.RandomMinMax( 1, 4 ) == 1 ){ reflect = true; } // 25% spells are reflected back to the caster
			else { reflect = false; }
		}

		public XormiteElemental( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}