/////////////////////////////////////////////////
//
// Automatically generated by the
// AddonGenerator script by Arya
//
/////////////////////////////////////////////////
using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class TallPineTreeNoLeaves : BaseAddon
	{
		public override BaseAddonDeed Deed
		{
			get
			{
				return new TallPineTreeNoLeavesDeed();
			}
		}

		[ Constructable ]
		public TallPineTreeNoLeaves()
		{
			AddonComponent ac = null;
			ac = new AddonComponent( 12453 );
			AddComponent( ac, 2, -2, 0 );
			ac = new AddonComponent( 12452 );
			AddComponent( ac, 2, -1, 0 );
			ac = new AddonComponent( 12451 );
			AddComponent( ac, 2, 0, 0 );
			ac = new AddonComponent( 12450 );
			AddComponent( ac, 2, 1, 0 );
			ac = new AddonComponent( 12449 );
			AddComponent( ac, 2, 2, 0 );
			ac = new AddonComponent( 12448 );
			AddComponent( ac, -2, 3, 0 );
			ac = new AddonComponent( 12447 );
			AddComponent( ac, -1, 3, 0 );
			ac = new AddonComponent( 12446 );
			AddComponent( ac, 0, 3, 0 );
			ac = new AddonComponent( 12445 );
			AddComponent( ac, 1, 3, 0 );
			ac = new AddonComponent( 12444 );
			AddComponent( ac, 2, 3, 0 );

		}

		public TallPineTreeNoLeaves( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class TallPineTreeNoLeavesDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new TallPineTreeNoLeaves();
			}
		}

		[Constructable]
		public TallPineTreeNoLeavesDeed()
		{
			Name = "TallPineTreeNoLeaves";
		}

		public TallPineTreeNoLeavesDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void	Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
