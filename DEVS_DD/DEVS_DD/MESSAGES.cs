using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEVS_DD
{
	class MESSAGES
	{
		

		private string name;
		private string message;
		private string received_from;
		private string with_time;

		public MESSAGES()
		{
			name = DEFINE.EMPTY;
			message = DEFINE.EMPTY;
			received_from = DEFINE.EMPTY;
			with_time = DEFINE.EMPTY;
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public string Message
		{
			get { return message; }
			set { message = value; }
		}

		public string Received_From
		{
			get { return received_from; }
			set { received_from = value; }
		}

		public string With_Time
		{
			get { return with_time; }
			set { with_time = value; }
		}

		

		

	}
}
