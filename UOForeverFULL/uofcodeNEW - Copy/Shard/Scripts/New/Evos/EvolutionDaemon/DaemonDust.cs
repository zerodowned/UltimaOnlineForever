//Script Transformed By: Cherokee/Mule II aka. HotShot
using System; 
using Server.Items; 

namespace Server.Items 
{ 
   	public class DaemonDust: Item 
   	{ 
		[Constructable]
		public DaemonDust() : this( 1 )
		{
		}

		[Constructable]
		public DaemonDust( int amount ) : base( 0x26B8 )
		{
			Stackable = true;
			Weight = 0.0;
			Amount = amount;
			Name = "daemon's dust";
			Hue = 39;
		}

            	public DaemonDust( Serial serial ) : base ( serial ) 
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