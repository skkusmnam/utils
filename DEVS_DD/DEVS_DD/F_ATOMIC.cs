using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DEVS_DD
{
	public partial class F_ATOMIC: Form
	{
		private	string	name;
		private	string	sigma;
		private	string	phase;
		private string	job;
		private	string	port;

		public F_ATOMIC()
		{
			name	= C_DEFINE.EMPTY;
			sigma	= C_DEFINE.EMPTY;
			phase	= C_DEFINE.EMPTY;
			port	= C_DEFINE.EMPTY;

			InitializeComponent();

			TB_POSX.Text = this.Location.X.ToString();
			TB_POSY.Text = this.Location.Y.ToString();
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
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

		public string Port
		{
			get { return port; }
			set { port = value; }
		}

		public void ShowAtomicInfo( string type )
		{
			C_UTIL UTIL = new C_UTIL();
			switch( type )
			{
				case C_DEFINE.ATOMIC_OUT:
					UTIL.SetGroupBoxName( GB_NAME, Name );

					UTIL.SetGroupBoxName( GB_OUTPORT, Port );
					UTIL.SetLabelText( LB_OUTPORT, Job );

					UTIL.SetGroupBoxName( GB_SIGMA, C_DEFINE.SIGMA );
					UTIL.SetLabelText( LB_SIGMA, Sigma );
					
					UTIL.SetGroupBoxName( GB_PHASE, C_DEFINE.PHASE );
					UTIL.SetLabelText( LB_PHASE, Phase );

					UTIL.SetGroupBoxVisible( GB_INPORT, false );
					break;

				case C_DEFINE.ATOMIC_IN:
					UTIL.SetGroupBoxName( GB_NAME, Name );

					UTIL.SetGroupBoxName( GB_INPORT, Port );
					UTIL.SetLabelText( LB_INPORT, Job );

					UTIL.SetGroupBoxName( GB_SIGMA, C_DEFINE.SIGMA );
					UTIL.SetLabelText( LB_SIGMA, Sigma );

					UTIL.SetGroupBoxName( GB_PHASE, C_DEFINE.PHASE );
					UTIL.SetLabelText( LB_PHASE, Phase );

					UTIL.SetGroupBoxVisible( GB_OUTPORT, false );
					break;
			}
		}

		private void F_ATOMIC_Move( object sender, EventArgs e )
		{
			TB_POSX.Text = this.Location.X.ToString();
			TB_POSY.Text = this.Location.Y.ToString();
		}
	}
}
