using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEVS_DD
{
	class MODEL_LIST
	{
		//private enum model { Coupled, Atomic };

		private string type;
		private string model;
		private string parent;
		private string name;
		private bool pruned;
		
		private int depth;

		public MODEL_LIST ()
		{
			type = "";
			parent = "";
			name = "";
			pruned = false;
			depth = -1;
		}

		public string Type
		{
			get { return this.type; }
			set { this.type = value; }
		}

		public string Model
		{
			get { return this.model; }
			set { this.model = value; }
		}

		public string Parent
		{
			get { return this.parent; }
			set { this.parent = value; }
		}

		public string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}

		public bool Pruned
		{
			get { return this.pruned; }
			set { this.pruned = value; }
		}

		public bool SetData( string data )
		{
			string[] token = data.Split( ',' );

			for( int i = 0; i < token.Length; i++ )
			{
				switch( i )
				{
					//case 0:
					//    Type = token[i];
					//    break;
					case 0:
						Model = token[i];
						break;
					case 1:
						Parent = token[i];
						break;
					case 2:
						Name = token[i];
						break;
					case 3:
						bool flag = false;
						if( token[i] == "yes" )
							flag = true;
						Pruned = flag;
						break;
					case 4:
						break;
					default:
						return false;
				}
			}

			return true;
		}
	}
}
