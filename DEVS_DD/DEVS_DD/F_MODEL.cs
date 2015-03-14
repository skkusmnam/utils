﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DEVS_DD {
	public partial class F_MODEL: Form 
	{
		C_UTIL UTIL = new C_UTIL();

		public enum Show_Type { Null, Root_Coordinator, Coordinator, Simulator };
		public enum Attributes { Null, Name, Message, Received_From, With_Time };

		private bool flag;
		private string type;
		private string model;
		private string parent;
		private string name;
		private bool pruned;
		private int depth;

		private string message;
		private string received_from;
		private string with_time;

		private string port;		
		private string saying;
		private string sigma;
		private string phase;
		private string job;		

		public F_MODEL()
		{
			flag = false;
			type = DEFINE.EMPTY;
			parent = DEFINE.EMPTY;
			name = DEFINE.EMPTY;
			pruned = false;
			depth = -1;

			message = DEFINE.EMPTY;
			received_from = DEFINE.EMPTY;
			with_time = DEFINE.EMPTY;

			port = DEFINE.EMPTY;			
			saying = DEFINE.EMPTY;
			InitializeComponent();

			TB_POSX.Text = this.Location.X.ToString();
			TB_POSY.Text = this.Location.Y.ToString();
		}

		public bool Flag
		{
			get { return this.flag; }
			set { this.flag = value; }
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

		public int Depth
		{
			get { return this.depth; }
			set { this.depth = value; }
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
						Depth = Convert.ToInt32( token[i] );
						break;
					//Pruned
					//case 4:
					//    bool flag = false;
					//    if( token[i] == DEFINE.YES )
					//        flag = true;
					//    Pruned = flag;
					//    break;
					case 4:
						break;
					default:
						return false;
				}
			}

			return true;
		}

		public void ParseMessage( string message )
		{
			bool flag = false;
			Attributes attribute = Attributes.Null;
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

				if( attribute == Attributes.Null )
					break;
			}
		}

		public Attributes GetAttribute( string name )
		{
			Attributes attribute = Attributes.Null;

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

		public void ShowFlashMessage()
		{
			Show_Type show_type = Show_Type.Null;
			if( name.Contains( "R:" ) )
				show_type = Show_Type.Root_Coordinator;

			switch( show_type )
			{
				case Show_Type.Root_Coordinator:
					ShowRootCoordinator();
					break;
			}


		}

		public void ShowRootCoordinator()
		{
			switch( message )
			{
				case DEFINE.DONE:
					UTIL.SetGroupBoxName( GB_CRD, name );

					UTIL.SetLabelText( LB_MESSAGE, Message + DEFINE.MESSAGE_STRING );

					UTIL.SetLabelText( LB_NAME_01, DEFINE.RECEIVED_FROM );
					UTIL.SetLabelText( LB_NAME_02, DEFINE.WITH_TIME );
					UTIL.SetLabelVisible( LB_NAME_03, false );
					UTIL.SetLabelVisible( LB_NAME_04, false );

					UTIL.SetLabelText( LB_VALUE_01, Received_From );
					UTIL.SetLabelText( LB_VALUE_02, With_Time );
					UTIL.SetLabelVisible( LB_VALUE_03, false );
					UTIL.SetLabelVisible( LB_VALUE_04, false );


					//UTIL.SetLabelText( LB_NAME_01, LB_VALUE_01, Message );
					//UTIL.SetLabelText( LB_NAME_01, LB_VALUE_02, Received_From );
					//UTIL.SetLabelText( LB_NAME_03, LB_VALUE_03, With_Time );
					break;
			}
		}

		private void F_MODEL_Move( object sender, EventArgs e )
		{
			TB_POSX.Text = this.Location.X.ToString();
			TB_POSY.Text = this.Location.Y.ToString();
		}

		
		

		//public string Port
		//{
		//    get { return port; }
		//    set { port = value; }
		//}

		

		//public string Saying
		//{
		//    get { return saying; }
		//    set { saying = value; }
		//}

		//public string Sigma
		//{
		//    get { return sigma; }
		//    set { sigma = value; }
		//}

		//public string Phase
		//{
		//    get { return phase; }
		//    set { phase = value; }
		//}

		//public string Job
		//{
		//    get { return job; }
		//    set { job = value; }
		//}

		//public void ShowModelInfo( string type )
		//{
		//    C_UTIL UTIL = new C_UTIL();
		//    switch( type )
		//    {
		//        case DEFINE.COORDINATOR:
		//        case DEFINE.SIM_FIRST:
		//            UTIL.SetGroupBoxName( GB_CRD, name );

		//            UTIL.SetLabelText( LB_MESSAGE, LB01, Message );
		//            UTIL.SetLabelText( LB_FROM, From );
		//            UTIL.SetLabelText( LB_TIME, LB03, Time );
		//            UTIL.SetLabelText( LB_PORT, LB04, Port );
		//            UTIL.SetLabelText( LB_SAYING, LB05, Saying );

		//            UTIL.SetGroupBoxVisible( GB_SIM, false );
		//            break;
		//        case DEFINE.SIM_LAST:
		//            UTIL.SetGroupBoxName( GB_SIM, name );

		//            string state1 = Sigma + DEFINE.BLANK + Phase;
		//            string state2 = Sigma + DEFINE.BLANK + Phase + DEFINE.BLANK + Job + DEFINE.BLANK + Sigma;
					
		//            UTIL.SetLabelText( LB_STATE1, LB11, state1 );
		//            UTIL.SetLabelText( LB_JOB, LB12, Job );
		//            UTIL.SetLabelText( LB_STATE2, LB13, state2 );

		//            UTIL.SetGroupBoxVisible( GB_CRD, false );
		//            break;
		//    }
		//}

		
	}
}