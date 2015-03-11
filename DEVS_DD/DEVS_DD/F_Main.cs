using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace DEVS_DD
{
    public partial class F_MAIN: Form 
	{
		C_UTIL		UTIL	= new C_UTIL();
		MODEL_LIST MODEL_LIST = new MODEL_LIST();
		F_ATOMIC	ATM		= new F_ATOMIC();
		F_MODEL[] MODEL;

        private byte[] data = new byte[1024];
        private int size = 1024;
        private Socket server;

		private	int	row;
		private int row_cnt;	// Row Count
		private int model_num;	// Model Num
		private	int	model_cnt;	// Model Count

		List<MODEL_LIST> model_list = new List<MODEL_LIST>();

        public F_MAIN()
        {
			row		    = 0;
            row_cnt     = 0;
			model_num	= 0;
            model_cnt   = 0;

            InitializeComponent();
        }

        private void BT_LOAD_Click( object sender, EventArgs e )
        {
			string	fileName = DEFINE.EMPTY;

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

			if( ( type == DEFINE.COORDINATOR ) || ( type == DEFINE.SIM_FIRST ) || ( type == DEFINE.SIM_LAST ) )
			{
                SetModelInfo(type, num);
                MODEL[num].ShowModelInfo(type);

                MODEL[num].Show();
                MODEL[num].BringToFront();
			}
			else if( ( type == DEFINE.ATOMIC_IN ) || ( type == DEFINE.ATOMIC_OUT) )
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
			int i = DEFINE.ERR;
            for (i = 0; i < model_cnt; i++)
			{
				if( MODEL[i].Text == name )
					break;
			}

			return i;
		}

        private void AddListItem( string name )
        {
            V_LIST.Items.Add( name );
            V_LIST.EndUpdate();
        }

		private void CreateModel( string name )
		{
            // 첫 번재 생성되는 모델일 때
            if ( row == 0 || !CheckExistModel( name ) )
			{
				MODEL[model_num] = new F_MODEL( name );
                AddListItem( name );
				MODEL[model_num].Text = name;
				SetFormPosition( name );
				model_num++;
			}
		}

		private void SetFormPosition( string name )
		{
			if( model_num == 0 )
			{
				MODEL[model_num].Location = new Point( DEFINE.INIT_X, DEFINE.INIT_Y );
			}
			else
			{
				int n = -1, x = -1, y = -1;

				if( name == DEFINE.EF )
				{
					x = MODEL[0].Location.X + MODEL[0].Size.Width + DEFINE.FORM_GAP;
					y = MODEL[0].Location.Y;
				}
				else if( name == DEFINE.GENR )
				{
					n = FindModel( DEFINE.EF );
					x = MODEL[n].Location.X + ( DEFINE.INIT_X );
					y = MODEL[n].Location.Y + ( DEFINE.INIT_X );
				}
				else if( name == DEFINE.TRANSD )
				{
					n = FindModel( DEFINE.EF );
					x = MODEL[n].Location.X + DEFINE.INIT_X;
					y = MODEL[n].Location.Y + DEFINE.INIT_Y * 2;
				}
				else
				{
					int size = FindLargeLocation();

					x = size + DEFINE.INIT_X;
					y = size + DEFINE.INIT_Y;
				}

				MODEL[model_num].Location = new Point( x, y );
			}
		}

		private int FindLargeLocation()
		{
			int max = -9;

			for( int i = 0; i < model_num; i++ )
			{
				if( ( MODEL[i].Text == DEFINE.EF ) || ( MODEL[i].Text == DEFINE.GENR ) || ( MODEL[i].Text == DEFINE.TRANSD ) )
					continue;

				if( MODEL[i].Location.X > max )
					max = MODEL[i].Location.X;
			}

			return max;
		}

		private void SetModelInfo( string type, int i )
		{
			UTIL.DataGrid = DG_VIEW;
			
			if( i != DEFINE.ERR )
			{
				switch( type )
				{
					case DEFINE.COORDINATOR:
					case DEFINE.SIM_FIRST:
						MODEL[i].Message= UTIL.GetValue( 2, row );
						MODEL[i].From	= UTIL.GetValue( 3, row );
						MODEL[i].Time	= UTIL.GetValue( 4, row );
						MODEL[i].Port	= UTIL.GetValue( 5, row );
						MODEL[i].Saying	= UTIL.GetValue( 6, row );
						break;
					case DEFINE.SIM_LAST:
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

        private void V_LIST_DoubleClick( object sender, EventArgs e )
        {
            int index = V_LIST.FocusedItem.Index;
            string finding_model = V_LIST.Items[index].SubItems[0].Text;
            int num = FindModel( finding_model );

            MODEL[num].Show();
            MODEL[num].BringToFront();
        }

        private void V_LIST_ColumnClick( object sender, ColumnClickEventArgs e )
        {
            // 방향 초기화
            for ( int i = 0; i < V_LIST.Columns.Count; i++ )
            {
                V_LIST.Columns[i].Text = V_LIST.Columns[i].Text.Replace( " △", "" );
                V_LIST.Columns[i].Text = V_LIST.Columns[i].Text.Replace( " ▽", "" );
            }

            // DESC
            if ( this.V_LIST.Sorting == SortOrder.Ascending || V_LIST.Sorting == SortOrder.None )
            {
                this.V_LIST.ListViewItemSorter = new ListViewItemComparer( e.Column, "desc" );
                V_LIST.Sorting = SortOrder.Descending;
                V_LIST.Columns[e.Column].Text = V_LIST.Columns[e.Column].Text + " ▽";
            }
            // ASC
            else
            {
                this.V_LIST.ListViewItemSorter = new ListViewItemComparer( e.Column, "asc" );
                V_LIST.Sorting = SortOrder.Ascending;
                V_LIST.Columns[e.Column].Text = V_LIST.Columns[e.Column].Text + " △";
            }
            V_LIST.Sort();

            // 컬럼 갯수가 변경되는 구조라면 sorter를 null 처리하여야 함
            V_LIST.ListViewItemSorter = null;
        }

        private void F_MAIN_Load( object sender, EventArgs e )
        {
            server = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
            IPEndPoint iep = new IPEndPoint( IPAddress.Any, 10000 );
            server.Bind( iep );
            server.Listen( 5 );
            server.BeginAccept( new AsyncCallback( AcceptConn ), server );
        }

        private void AcceptConn( IAsyncResult iar )
        {
            TB_MSG.Text = "";
            Socket oldserver = (Socket)iar.AsyncState;
            Socket client = oldserver.EndAccept( iar );
            TB_MSG.Text = client.RemoteEndPoint.ToString() + " is accepted.";
            string welcome = "Welcome to DEVS Diagram Display";
            byte[] message1 = Encoding.UTF8.GetBytes( welcome );
            client.BeginSend( message1, 0, message1.Length, SocketFlags.None, new AsyncCallback( SendData ), client );
        }

        private void SendData( IAsyncResult iar )
        {
            Socket client = (Socket)iar.AsyncState;
            int sent = client.EndSend( iar );
            client.BeginReceive( data, 0, size, SocketFlags.None, new AsyncCallback( ReceiveData ), client );
        }

        private void ReceiveData( IAsyncResult iar )
        {
            try
            {
                Socket client = (Socket)iar.AsyncState;
                int recv = client.EndReceive( iar );

                if ( recv == 0 )
                {
                    client.Close();
                    TB_MSG.Text = "Waiting for a Client...";
                    server.BeginAccept( new AsyncCallback( AcceptConn ), server );
                    return;
                }

                string recvData = Encoding.UTF8.GetString( data, 0, recv );
                TB_LOG.Text = "";
                TB_LOG.Text += recvData + Environment.NewLine;
				//byte[] message2 = Encoding.UTF8.GetBytes( recvData );
				//client.BeginSend( message2, 0, message2.Length, SocketFlags.None, new AsyncCallback( SendData ), client );
				CreateModelForm( recvData );
            }
            catch ( Exception e )
            {
                TB_MSG.Text = e.Message.ToString();
            }
        }

        private void TB_LOG_TextChanged( object sender, EventArgs e )
        {
            TB_LOG.SelectionStart = TB_LOG.Text.Length;
            TB_LOG.ScrollToCaret();
        }

		private void CreateModelForm( string message )
		{
			int num = Convert.ToInt32( message[0] ) - 48;
			if( num == DEFINE.INIT )
			{
				ParseMessage( message );

			}
		}

		private void ParseMessage( string message )
		{
			MODEL_LIST Entity = new MODEL_LIST();
			List<string> model_line = new List<string>();

			string[] line = message.Split( '|' );
			for( int i = 0; i < line.Length; i++ )
			{
				if( i == 0 )
					continue;
				else if( line[i] != DEFINE.STR_EMPTY )
					model_line.Add( line[i] );
			}

			for( int i = 0; i < model_line.Count; i++ )
			{
				if( !Entity.SetData( model_line[i] ) )
				{
					MessageBox.Show( C_ERROR.E010 );
					return;
				}
				model_list.Add( Entity );
			}
		}

		private void BT_PACKET_Click ( object sender, EventArgs e )
		{
			string temp = "0|CM,root,EF_A,1,|AM,EF_A,P,2,|CM,EF_A,EF,2,|AM,EF,GENR,3,|AM,EF,TRANSD,3,|";
			ParseMessage( temp );
		}
    }

    // 리스트뷰의 정렬을 위하여 사용함.
    class ListViewItemComparer : IComparer
    {
        private int col;
        public string sort = "asc";
        public ListViewItemComparer()
        {
            col = 0;
        }

        /// <summary>
        /// 컬럼과 정렬 기준(asc, desc)을 사용하여 정렬 함.
        /// </summary>
        /// <param name="column">몇 번째 컬럼인지를 나타냄.</param>
        /// <param name="sort">정렬 방법을 나타냄. Ex) asc, desc</param>
        public ListViewItemComparer( int column, string sort )
        {
            col = column;
            this.sort = sort;
        }

        public int Compare( object x, object y )
        {
            if ( sort == "asc" )
                return String.Compare( ( (ListViewItem)x ).SubItems[col].Text, ( (ListViewItem)y ).SubItems[col].Text );
            else
                return String.Compare( ( (ListViewItem)y ).SubItems[col].Text, ( (ListViewItem)x ).SubItems[col].Text );
        }
    }
}
