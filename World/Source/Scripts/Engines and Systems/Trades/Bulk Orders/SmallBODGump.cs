using System;
using Server;
using Server.Gumps;
using Server.Network;

namespace Server.Engines.BulkOrders
{
	public class SmallBODGump : Gump
	{
		private SmallBOD m_Deed;
		private Mobile m_From;

		public SmallBODGump( Mobile from, SmallBOD deed ) : base( 25, 25 )
		{
			m_From = from;
			m_Deed = deed;

			m_From.CloseGump( typeof( LargeBODGump ) );
			m_From.CloseGump( typeof( SmallBODGump ) );

			AddPage( 0 );

			AddBackground( 50, 10, 455, 260, 0x1453 );
			AddImageTiled( 58, 20, 438, 241, 2624 );
			AddAlphaRegion( 58, 20, 438, 241 );

			AddHtmlLocalized( 225, 25, 120, 20, 1045133, 0x7FFF, false, false ); // A bulk order

			AddHtmlLocalized( 75, 48, 250, 20, 1045138, 0x7FFF, false, false ); // Amount to make:
			AddLabel( 275, 48, 1152, deed.AmountMax.ToString() );

			AddHtmlLocalized( 275, 76, 200, 20, 1045153, 0x7FFF, false, false ); // Amount finished:
			AddHtmlLocalized( 75, 72, 120, 20, 1045136, 0x7FFF, false, false ); // Item requested:

			AddItem( 410, 72, deed.Graphic );

			AddHtmlLocalized( 75, 96, 210, 20, deed.Number, 0x7FFF, false, false );
			AddLabel( 275, 96, 0x480, deed.AmountCur.ToString() );

			if ( deed.RequireExceptional || deed.Material != BulkMaterialType.None )
				AddHtmlLocalized( 75, 120, 200, 20, 1045140, 0x7FFF, false, false ); // Special requirements to meet:

			if ( deed.RequireExceptional )
				AddHtmlLocalized( 75, 144, 300, 20, 1045141, 0x7FFF, false, false ); // All items must be exceptional.

			if ( deed.Material != BulkMaterialType.None )
				AddHtmlLocalized( 75, deed.RequireExceptional ? 168 : 144, 300, 20, GetMaterialNumberFor( deed.Material ), 0x7FFF, false, false ); // All items must be made with x material.

			AddButton( 125, 192, 4005, 4007, 2, GumpButtonType.Reply, 0 );
			AddHtmlLocalized( 160, 192, 300, 20, 1045154, 0x7FFF, false, false ); // Combine this deed with the item requested.

			AddButton( 125, 216, 4005, 4007, 1, GumpButtonType.Reply, 0 );
			AddHtmlLocalized( 160, 216, 120, 20, 1011441, 0x7FFF, false, false ); // EXIT
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( m_Deed.Deleted || !m_Deed.IsChildOf( m_From.Backpack ) )
				return;

			if ( info.ButtonID == 2 ) // Combine
			{
				m_From.SendGump( new SmallBODGump( m_From, m_Deed ) );
				m_Deed.BeginCombine( m_From );
			}
		}

		public static int GetMaterialNumberFor( BulkMaterialType material )
		{
			if ( material >= BulkMaterialType.DullCopper && material <= BulkMaterialType.Valorite )
				return 1045142 + (int)(material - BulkMaterialType.DullCopper);
			else if ( material >= BulkMaterialType.Spined && material <= BulkMaterialType.Barbed )
				return 1049348 + (int)(material - BulkMaterialType.Spined);

			return 0;
		}
	}
}