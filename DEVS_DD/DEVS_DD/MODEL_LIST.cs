using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEVS_DD
{
	class MODEL_LIST
	{
		private string type;
		private enum model { Coupled, Atomic };
		//private string model;
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
	}
}
