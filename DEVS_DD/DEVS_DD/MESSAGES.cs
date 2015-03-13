using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEVS_DD
{
	class MESSAGES
	{
		public enum Attributes { Empty, Name, Message, Received_From, With_Time };

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

		public void ParseMessage( string message )
		{
			bool flag = false;
			Attributes attribute = Attributes.Empty;
			string[] token = message.Split( ',', '=' );

			for( int i = 0; i < token.Length; i++ )
			{
				if( flag == false )
				{
					attribute = GetAttribute( token[i] );
					flag = true;
				}
				else
				{
					SetData( attribute, token[i] );
					flag = false;
				}

				if( attribute == Attributes.Empty )
					break;
			}
		}

		public Attributes GetAttribute( string name )
		{
			Attributes attribute = Attributes.Empty;

			switch( name )
			{
				case "name":
					attribute = Attributes.Name;
					break;
				case "message":
					attribute = Attributes.Message;
					break;
				case "received from":
					attribute = Attributes.Received_From;
					break;
				case "with time":
					attribute = Attributes.With_Time;
					break;
			}

			return attribute;
		}

		public void SetData( Attributes index, string value )
		{
			switch( index )
			{
				case Attributes.Name:
					Name = value;
					break;
				case Attributes.Message:
					Message = value;
					break;
				case Attributes.Received_From:
					Received_From = value;
					break;
				case Attributes.With_Time:
					With_Time = value;
					break;
			}
		}

	}
}
