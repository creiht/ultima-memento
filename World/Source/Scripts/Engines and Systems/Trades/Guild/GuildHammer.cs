using System;
using Server;
using System.Collections;
using Server.ContextMenus;
using System.Collections.Generic;
using Server.Misc;
using Server.Network;
using Server.Items;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;
using Server.Targeting;
using Server.Engines.GlobalShoppe;

namespace Server.Items
{
    public class GuildHammer : Item
    {
		public override string DefaultDescription{ get{ return "These tools are usually acquired by tradesmen guild members, where using them requires one to be a master in that craft. Unlike other tools, they do not need to be equipped but simply used from your pack. You must be near your guildmaster, or a shoppe that you have in your home. Using this on an item will allow you to spend gold in order to enhance the item with additional attributes."; } }

		public override int Hue{ get { return 0xB2F; } }
		public override int ItemID{ get { return 0x6601; } }

        [Constructable]
        public GuildHammer() : base( 0x6601 )
        {
            Name = "Extraordinary Smithing Tools";
			Weight = 5.0;
        }

        public GuildHammer(Serial serial) : base(serial)
		{
		}

        public override void OnDoubleClick( Mobile from )
        {
			if ( from is PlayerMobile )
			{
				bool canDo = false;
				var eable = GetMobilesInRange( 20 );
				foreach ( var m in eable )
				{
					if ( m is BlacksmithGuildmaster )
					{
						canDo = true;
						break;
					}
				}
				eable.Free();

				if (!canDo)
				{
					eable = GetItemsInRange( 20 );
					foreach ( var m in eable )
					{
						if ( m is BlacksmithShoppe )
						{
							canDo = true;
							break;
						}
					}
					eable.Free();
				}

				if ( !canDo && from.Map == Map.SavagedEmpire && from.X > 1054 && from.X < 1126 && from.Y > 1907 && from.Y < 1983 ){ canDo = true; }

				PlayerMobile pc = (PlayerMobile)from;
				if ( pc.NpcGuild != NpcGuild.BlacksmithsGuild )
				{
					from.SendMessage( "Only those of the Blacksmiths Guild may use this!" );
				}
				else if ( from.Skills[SkillName.Blacksmith].Value < 90 )
				{
					from.SendMessage( "Only a master blacksmith can use this!" );
				}
				else if ( !canDo )
				{
					from.SendMessage( "You need to be near a smithing guildmaster, or a smithing shoppe you own, to use this!" );
				}
				else
				{
					from.SendMessage("Select the metal equipment you would like to enhance...");
					from.BeginTarget(-1, false, TargetFlags.None, new TargetCallback(OnTarget));
				}
			}
        }

        public void OnTarget(Mobile from, object obj)
        {
            if ( obj is Item )
            {
				Item item = (Item)obj;

                if (((Item)obj).RootParent != from)
                {
                    from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
                }
				else if ( !item.ResourceCanChange() )
				{
					from.SendMessage( "You cannot enhance this item any further!" );
				}
				else if ( ( item is BaseWeapon || item is BaseArmor ) && CraftResources.GetType( item.Resource ) == CraftResourceType.Metal )
				{
					GuildCraftingProcess process = new GuildCraftingProcess(from, (Item)obj);
					process.BeginProcess();
				}
            }
        }
        
        public override void Serialize(GenericWriter writer)
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
    }
}