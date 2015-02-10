using System;
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
		private string name;
		private string message;
		private string from;
		private string port;
		private string time;
		private string saying;
		private string sigma;
		private string phase;
		private string job;

		public F_MODEL( string name )
		{
			this.name	= name;

			message = C_DEFINE.EMPTY;
			from	= C_DEFINE.EMPTY;
			port	= C_DEFINE.EMPTY;
			time	= C_DEFINE.EMPTY;
			saying	= C_DEFINE.EMPTY;

			InitializeComponent();

			TB_POSX.Text = this.Location.X.ToString();
			TB_POSY.Text = this.Location.Y.ToString();
		}

		public string Message
		{
			get { return message; }
			set { message = value; }
		}

		public string From
		{
			get { return from; }
			set { from = value; }
		}

		public string Port
		{
			get { return port; }
			set { port = value; }
		}

		public string Time
		{
			get { return time; }
			set { time = value; }
		}

		public string Saying
		{
			get { return saying; }
			set { saying = value; }
		}

		public string Sigma
		{
			get { return sigma; }
			set { sigma = value; }
		}

		public string Phase
		{
			get { return phase; }
			set { phase = value; }
		}

		public string Job
		{
			get { return job; }
			set { job = value; }
		}

		public void ShowModelInfo( string type )
		{
			C_UTIL UTIL = new C_UTIL();
			switch( type )
			{
				case C_DEFINE.COORDINATOR:
				case C_DEFINE.SIM_FIRST:
					UTIL.SetGroupBoxName( GB_CRD, name );

					UTIL.SetLabelText( LB_MESSAGE, LB01, Message );
					UTIL.SetLabelText( LB_FROM, From );
					UTIL.SetLabelText( LB_TIME, LB03, Time );
					UTIL.SetLabelText( LB_PORT, LB04, Port );
					UTIL.SetLabelText( LB_SAYING, LB05, Saying );


					UTIL.SetGroupBoxVisible( GB_SIM, false );
					break;
				case C_DEFINE.SIM_LAST:
					UTIL.SetGroupBoxName( GB_SIM, name );

					string state1 = Sigma + C_DEFINE.BLANK + Phase;
					string state2 = Sigma + C_DEFINE.BLANK + Phase + C_DEFINE.BLANK + Job + C_DEFINE.BLANK + Sigma;
					
					UTIL.SetLabelText( LB_STATE1, LB11, state1 );
					UTIL.SetLabelText( LB_JOB, LB12, Job );
					UTIL.SetLabelText( LB_STATE2, LB13, state2 );

					UTIL.SetGroupBoxVisible( GB_CRD, false );
					break;
			}
		}

		private void F_MODEL_Move( object sender, EventArgs e )
		{
			TB_POSX.Text = this.Location.X.ToString();
			TB_POSY.Text = this.Location.Y.ToString();
		}
	}
}