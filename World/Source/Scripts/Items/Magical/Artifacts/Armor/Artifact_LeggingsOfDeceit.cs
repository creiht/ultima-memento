using System;
using Server;

namespace Server.Items
{
	public class Artifact_LeggingsOfDeceit : GiftChainLegs
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

        public override int BasePhysicalResistance{ get{ return 8; } }
		public override int BaseFireResistance{ get{ return 6; } } 
		public override int BaseColdResistance{ get{ return 5; } }
		public override int BasePoisonResistance{ get{ return 15; } }
		public override int BaseEnergyResistance{ get{ return 12; } }

	 	[Constructable]
	 	public Artifact_LeggingsOfDeceit()
	 	{
	 	 	Name = "Leggings Of Deceit";
	 	 	Hue = 38;
			ItemID = 0x13BE;
	 	 	Attributes.AttackChance = 5;
	 	 	Attributes.DefendChance = 10;
	 	 	Attributes.LowerManaCost = 8;
	 	 	ArmorAttributes.MageArmor = 1;
			Attributes.BonusStam = 5;
	 	 	Attributes.NightSight = 1;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
		}

	 	public Artifact_LeggingsOfDeceit(Serial serial) : base( serial )
	 	{
	 	}
	 	public override void Serialize( GenericWriter writer )
	 	{
	 	 	base.Serialize( writer );

	 	 	writer.Write( (int) 0 );
	 	}
	 	public override void Deserialize(GenericReader reader)
	 	{
	 	 	base.Deserialize( reader );
			ArtifactLevel = 2;
	 	 	int version = reader.ReadInt();
	 	}
	}
}
