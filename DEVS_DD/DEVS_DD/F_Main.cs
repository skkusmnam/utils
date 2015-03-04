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
    public partial class F_MAIN: Form 
	{
		C_UTIL		UTIL	= new C_UTIL();
		F_ATOMIC	ATM		= new F_ATOMIC();
        F_VIEW      LIST     = new F_VIEW();
		F_MODEL[] MODEL;

		private	int	row;
		private int row_cnt;	// Row Count
		private int model_num;	// Model Num
		private	int	model_cnt;	// Model Count

        public F_MAIN()
        {
			row		    = 0;
            row_cnt     = 0;
			model_num	= 0;
            model_cnt   = 0;

            InitializeComponent();
            LIST.Show();
        }

        private void BT_LOAD_Click( object sender, EventArgs e )
        {
			string	fileName = C_DEFINE.EMPTY;

            OpenFileDialog open_fine = new OpenFileDialog();
            {
				open_fine.AutoUpgradeEnabled = false;
                //open_fine.InitialDirectory = ".\\log\\xml\\";
				open_fine.RestoreDirectory = true;
				open_fine.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
				open_fine.FilterIndex = 0;

				if( open_fine.ShowDialog() == DialogResult.OK )
                {
                    try
                    {
						fileName = open_fine.FileName;
                    }
                    catch( Exception ex )
                    {
                        MessageBox.Show( ex.Message );
                    }
                }
            }
			StartXML( fileName );
        }

		private void StartXML( string filename )
		{
			UTIL.DataGrid = DG_VIEW;

			C_XML XML = new C_XML( DG_VIEW, filename );
			XML.OpenXmlFile();

            model_cnt = XML.GetModelListCount();
            MODEL = new F_MODEL[model_cnt + 1];

			int rCnt = UTIL.GetRowCount() - 1;
		}

        private void BT_STEP_Click( object sender, EventArgs e )
        {
			UTIL.DataGrid = DG_VIEW;

			if( row == UTIL.GetRowCount() - 2 )
			{
				MessageBox.Show( C_ERROR.E009 );
				return;
			}
			
			string name = UTIL.GetValue( 1, row );
			CreateModel( name );

			UTIL.SetRowSelection( row );

			int num = FindModel( name );
			string type = UTIL.GetValue( 0, row );

			if( ( type == C_DEFINE.COORDINATOR ) || ( type == C_DEFINE.SIM_FIRST ) || ( type == C_DEFINE.SIM_LAST ) )
			{
                SetModelInfo(type, num);
                MODEL[num].ShowModelInfo(type);

                MODEL[num].Show();
                MODEL[num].BringToFront();
			}
			else if( ( type == C_DEFINE.ATOMIC_IN ) || ( type == C_DEFINE.ATOMIC_OUT) )
			{
				SetAtomicInfo();
				ATM.ShowAtomicInfo( type );

				ATM.Show();
				ATM.BringToFront();
			}

			row++;
        }

		private bool CheckExistModel( string name )
		{
            for (int i = 0; i < model_cnt; i++)
			{
				if( MODEL[i] == null )
					break;

				if( MODEL[i].Text == name )
					return true;
			}
			return false;
		}

		private int FindModel( string name )
		{
			int i = C_DEFINE.ERR;
            for (i = 0; i < model_cnt; i++)
			{
				if( MODEL[i].Text == name )
					break;
			}

			return i;
		}

		private void CreateModel( string name )
		{
            // 첫 번재 생성되는 모델일 때
            if ( row == 0 || !CheckExistModel( name ) )
			{
				MODEL[model_num] = new F_MODEL( name );
                LIST.AddModelName( name );
				MODEL[model_num].Text = name;
				SetFormPosition( name );
				model_num++;
			}
		}

		private void SetFormPosition( string name )
		{
			if( model_num == 0 )
			{
				MODEL[model_num].Location = new Point( C_DEFINE.INIT_X, C_DEFINE.INIT_Y );
			}
			else
			{
				int n = -1, x = -1, y = -1;

				if( name == C_DEFINE.EF )
				{
					x = MODEL[0].Location.X + MODEL[0].Size.Width + C_DEFINE.FORM_GAP;
					y = MODEL[0].Location.Y;
				}
				else if( name == C_DEFINE.GENR )
				{
					n = FindModel( C_DEFINE.EF );
					x = MODEL[n].Location.X + ( C_DEFINE.INIT_X );
					y = MODEL[n].Location.Y + ( C_DEFINE.INIT_X );
				}
				else if( name == C_DEFINE.TRANSD )
				{
					n = FindModel( C_DEFINE.EF );
					x = MODEL[n].Location.X + C_DEFINE.INIT_X;
					y = MODEL[n].Location.Y + C_DEFINE.INIT_Y * 2;
				}
				else
				{
					int size = FindLargeLocation();

					x = size + C_DEFINE.INIT_X;
					y = size + C_DEFINE.INIT_Y;
				}

				MODEL[model_num].Location = new Point( x, y );
			}
		}

		private int FindLargeLocation()
		{
			int max = -9;

			for( int i = 0; i < model_num; i++ )
			{
				if( ( MODEL[i].Text == C_DEFINE.EF ) || ( MODEL[i].Text == C_DEFINE.GENR ) || ( MODEL[i].Text == C_DEFINE.TRANSD ) )
					continue;

				if( MODEL[i].Location.X > max )
					max = MODEL[i].Location.X;
			}

			return max;
		}

		private void SetModelInfo( string type, int i )
		{
			UTIL.DataGrid = DG_VIEW;
			
			if( i != C_DEFINE.ERR )
			{
				switch( type )
				{
					case C_DEFINE.COORDINATOR:
					case C_DEFINE.SIM_FIRST:
						MODEL[i].Message= UTIL.GetValue( 2, row );
						MODEL[i].From	= UTIL.GetValue( 3, row );
						MODEL[i].Time	= UTIL.GetValue( 4, row );
						MODEL[i].Port	= UTIL.GetValue( 5, row );
						MODEL[i].Saying	= UTIL.GetValue( 6, row );
						break;
					case C_DEFINE.SIM_LAST:
						MODEL[i].Sigma	= UTIL.GetValue( 2, row );
						MODEL[i].Phase	= UTIL.GetValue( 3, row );
						MODEL[i].Job	= UTIL.GetValue( 5, row );
						break;
				}				
			}
			else
				MessageBox.Show( C_ERROR.E009 );
		}

		private void SetAtomicInfo()
		{
			UTIL.DataGrid = DG_VIEW;
			ATM.Name	= UTIL.GetValue( 1, row );
			ATM.Sigma	= UTIL.GetValue( 2, row );
			ATM.Phase	= UTIL.GetValue( 3, row );
			ATM.Port	= UTIL.GetValue( 4, row );
			ATM.Job		= UTIL.GetValue( 5, row );
		}

		private void BT_PLAY_Click( object sender, EventArgs e )
		{
			UTIL.DataGrid = DG_VIEW;

            for (int i = 0; i < row_cnt; i++)
			{
				string name = UTIL.GetValue( 1, row );
				CreateModel( name );
				UTIL.SetRowSelection( row );
				row++;
			}
		}
    }
}
