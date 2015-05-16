// Automatically generated by the
// AddonGenerator script by Arya
// Generator edited 10.Mar.07 by Papler
using System;
using Server;
using Server.Items;
namespace Server.Items
{
	public class HarvestLampAddon : BaseAddon {
		public override BaseAddonDeed Deed{get{return new HarvestLampAddonDeed();}}
		[ Constructable ]
		public HarvestLampAddon()
		{
			AddonComponent ac = null;
			ac = new AddonComponent( 2852 );
			ac.Light = LightType.Circle225;
			ac.Hue = 1552;
			AddComponent( ac, 0, 0, 3 );

			ac = new AddonComponent( 15640 );
			AddComponent( ac, 0, 0, 0 );

			ac = new AddonComponent( 3197 );
			AddComponent( ac, 1, 1, 8 );

			ac = new AddonComponent( 15642 );
			AddComponent( ac, 1, 1, 0 );

			ac = new AddonComponent( 7869 );
			AddComponent( ac, 1, 1, 6 );

			ac = new AddonComponent( 6786 );
			ac.Name = "Harvest Cart";
			AddComponent( ac, 1, 0, 0 );

			ac = new AddonComponent( 3186 );
			AddComponent( ac, 1, -1, 7 );

			ac = new AddonComponent( 6787 );
			ac.Name = "Harvest Cart";
			AddComponent( ac, 1, -1, 0 );

			ac = new AddonComponent( 3169 );
			AddComponent( ac, 1, -1, 3 );

			ac = new AddonComponent( 3177 );
			AddComponent( ac, 1, -1, 6 );

			ac = new AddonComponent( 3179 );
			AddComponent( ac, 1, -1, 5 );

			ac = new AddonComponent( 3180 );
			AddComponent( ac, 1, -1, 6 );

			ac = new AddonComponent( 3354 );
			AddComponent( ac, 1, -1, 3 );

			ac = new AddonComponent( 3354 );
			AddComponent( ac, 1, -1, 6 );


		}
		public HarvestLampAddon( Serial serial ) : base( serial ){}
		public override void Serialize( GenericWriter writer ){base.Serialize( writer );writer.Write( 0 );}
		public override void Deserialize( GenericReader reader ){base.Deserialize( reader );reader.ReadInt();}
	}

	public class HarvestLampAddonDeed : BaseAddonDeed {
		public override BaseAddon Addon{get{return new HarvestLampAddon();}}
		[Constructable]
		public HarvestLampAddonDeed(){Name = "HarvestLamp";}
		public HarvestLampAddonDeed( Serial serial ) : base( serial ){}
		public override void Serialize( GenericWriter writer ){	base.Serialize( writer );writer.Write( 0 );}
		public override void	Deserialize( GenericReader reader )	{base.Deserialize( reader );reader.ReadInt();}
	}
}