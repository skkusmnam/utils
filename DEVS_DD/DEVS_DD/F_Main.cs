using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace DEVS_DD
{
    public partial class F_MAIN: Form 
	{
		C_UTIL		UTIL	= new C_UTIL();
		F_ATOMIC	ATM		= new F_ATOMIC();

        private byte[] data = new byte[1024];
        private int size = 1024;
        private Socket server;

		private	int	row;
		private int packet_cnt;
		private int model_num;	// Model Num
		private	int	model_cnt;	// Model Count

		string recvData = DEFINE.EMPTY;

		List<int> Depth_List = new List<int>();
		List<string> Child_List = new List<string>();
		List<F_MODEL> Form_List = new List<F_MODEL>();

        public F_MAIN()
        {
			row		    = 0;
			packet_cnt = 0;
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
			//MODEL = new F_MODEL[model_cnt + 1];

			int rCnt = UTIL.GetRowCount() - 1;
		}

        private void BT_STEP_Click( object sender, EventArgs e )
        {
			//UTIL.DataGrid = DG_VIEW;

			//if( row == UTIL.GetRowCount() - 2 )
			//{
			//    MessageBox.Show( C_ERROR.E009 );
			//    return;
			//}
			
			//string name = UTIL.GetValue( 1, row );
			//CreateModel( name );

			//UTIL.SetRowSelection( row );

			//int num = FindModel( name );
			//string type = UTIL.GetValue( 0, row );

			//if( ( type == DEFINE.COORDINATOR ) || ( type == DEFINE.SIM_FIRST ) || ( type == DEFINE.SIM_LAST ) )
			//{
			//    //SetModelInfo(type, num);
			//    //MODEL[num].ShowModelInfo(type);

			//    //MODEL[num].Show();
			//    //MODEL[num].BringToFront();
			//}
			//else if( ( type == DEFINE.ATOMIC_IN ) || ( type == DEFINE.ATOMIC_OUT) )
			//{
			//    SetAtomicInfo();
			//    ATM.ShowAtomicInfo( type );

			//    ATM.Show();
			//    ATM.BringToFront();
			//}

			//row++;
        }

		private bool CheckExistModel( string name )
		{
            for (int i = 0; i < model_cnt; i++)
			{
				//if( MODEL[i] == null )
				//    break;

				//if( MODEL[i].Text == name )
				//    return true;
			}
			return false;
		}

		private int FindModel( string name )
		{
			int i = DEFINE.ERR;
            for (i = 0; i < model_cnt; i++)
			{
				//if( MODEL[i].Text == name )
				//    break;
			}

			return i;
		}

        private void AddListItem( string name )
        {
            V_LIST.Items.Add( name );
            V_LIST.EndUpdate();
        }

		private void CreateModel()
		{
			for( int i = 0; i < Form_List.Count; i++ )
			{
				string temp_name = Form_List[i].Name;
				Form_List[i].Text = temp_name;

				AddListItem( temp_name );
				model_num++;
			}
			SetFormPosition();
		}

		private void SetFormPosition()
		{
			int i = 0;
			int pos_x = DEFINE.INIT_X;
			int pos_y = DEFINE.INIT_Y;

			while( true )
			{
				int parent_id = -1;

				if( Form_List[i].Flag != false )
				{
					i++;
					continue;
				}

				parent_id = GetParentId( Form_List[i].Name );
				if( parent_id > 0 )
				{
					pos_x = Form_List[parent_id].Location.X + DEFINE.FORM_GAP;
					pos_y = Form_List[parent_id].Location.Y;

					while( ExistCurrentPosition( pos_x, pos_y ) )
						pos_y = pos_y + DEFINE.FORM_GAP;
				}

				Form_List[i].Location = new Point( pos_x, pos_y );
				Form_List[i].Flag = true;
				Form_List[i].Show();

				GetChildList( Form_List[i].Name );
				
				for( int j = 0; j < Child_List.Count; j++ )
				{
					int index = -1;

					if( i == 0 )
					{
						pos_x = Form_List[i].Location.X + DEFINE.FORM_GAP;
						pos_y = Form_List[i].Location.Y + DEFINE.FORM_GAP;
					}
					else
					{
						if( j == 0 )
							pos_x = Form_List[i].Location.X + DEFINE.FORM_GAP;
						else
							pos_y = Form_List[i].Location.Y + DEFINE.FORM_GAP;
					}
					
					index = GetModelIndex( Child_List[j] );
					Form_List[index].Location = new Point( pos_x, pos_y );
					Form_List[index].Flag = true;
					Form_List[index].Show();
				}

				if( Form_List.Count() != CountFormFlag() )
					i++;
				else
					break;
			}
		}

		private bool ExistCurrentPosition( int x, int y )
		{
			bool result = false;

			for( int i = 0; i < Form_List.Count; i++ )
			{
				if( Form_List[i].Location.X == x && Form_List[i].Location.Y == y )
					result = true;					
			}

			return result;
		}

		private string GetParentName( string model_name )
		{
			string result = DEFINE.EMPTY;

			for( int i = 0; i < Form_List.Count; i++ )
			{
				if( Form_List[i].Name == model_name )
					result = Form_List[i].Parent;
			}

			return result;
		}

		private int GetParentId( string model_name )
		{
			int result = -1;
			string parent_name = GetParentName( model_name );

			for( int i = 0; i < Form_List.Count; i++ )
			{
				if( Form_List[i].Name == parent_name )
					result = i;
			}

			return result;

		}

		private int CountFormFlag()
		{
			int cnt = 0;

			for( int i = 0; i < Form_List.Count; i++ )
			{
				if( Form_List[i].Flag == true )
					cnt++;
			}

			return cnt;
		}

		private void GetChildList( string parent_name )
		{
			Child_List.Clear();

			for( int i = 0; i < Form_List.Count; i++ )
			{
				if( Form_List[i].Parent == parent_name )
					Child_List.Add( Form_List[i].Name );
			}
		}

		private int GetModelIndex( string model_name )
		{
			int result = -1;
			for( int i = 0; i < Form_List.Count(); i++ )
			{
				if( Form_List[i].Name == model_name )
				{
					result = i;
					break;
				}
			}
			return result;
		}

		private void SetModelDepth()
		{
			for( int i = 0; i < Form_List.Count; i++ )
			{
				Depth_List.Add( Form_List[i].Depth );
			}
			Depth_List.Sort();
		}

		private void SetModelInfo( string type, int i )
		{
			UTIL.DataGrid = DG_VIEW;
			
			if( i != DEFINE.ERR )
			{
				//switch( type )
				//{
				//    case DEFINE.COORDINATOR:
				//    case DEFINE.SIM_FIRST:
				//        MODEL[i].Message = UTIL.GetValue( 2, row );
				//        MODEL[i].From = UTIL.GetValue( 3, row );
				//        MODEL[i].Time = UTIL.GetValue( 4, row );
				//        MODEL[i].Port = UTIL.GetValue( 5, row );
				//        MODEL[i].Saying = UTIL.GetValue( 6, row );
				//        break;
				//    case DEFINE.SIM_LAST:
				//        MODEL[i].Sigma = UTIL.GetValue( 2, row );
				//        MODEL[i].Phase = UTIL.GetValue( 3, row );
				//        MODEL[i].Job = UTIL.GetValue( 5, row );
				//        break;
				//}				
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
			//UTIL.DataGrid = DG_VIEW;

			//for (int i = 0; i < row_cnt; i++)
			//{
			//    string name = UTIL.GetValue( 1, row );
			//    CreateModel( name );
			//    UTIL.SetRowSelection( row );
			//    row++;
			//}
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
				CreateModel();
			}
		}

		private void ParseMessage( string message )
		{
			List<string> model_line = new List<string>();

			string[] line = message.Split( '|' );
			for( int i = 0; i < line.Length; i++ )
			{
				if( i == 0 )
					model_line.Add( DEFINE.ROOT_COORDINATOR );
				else if( line[i] != DEFINE.EMPTY )
					model_line.Add( line[i] );
			}

			for( int i = 0; i < model_line.Count; i++ )
			{
				F_MODEL Entity = new F_MODEL();

				if( !Entity.SetData( model_line[i] ) )
				{
					MessageBox.Show( C_ERROR.E010 );
					return;
				}
				Form_List.Add( Entity );
			}
		}

		private void BT_PACKET_Click( object sender, EventArgs e )
		{
			string temp = "0|CM,R:EF_A,EF_A,1,|AM,EF_A,P,2,|CM,EF_A,EF,2,|AM,EF,GENR,3,|AM,EF,TRANSD,3,|";
			CreateModelForm( temp );
		}

        private void V_LIST_DoubleClick( object sender, EventArgs e )
        {
            int index = V_LIST.FocusedItem.Index;
            string finding_model = V_LIST.Items[index].SubItems[0].Text;

			for( int i = 0; i < Form_List.Count; i++ )
			{
				if( Form_List[i].Name == finding_model )
				{
					Form_List[i].Show();
					Form_List[i].BringToFront();
				}
			}
        }

		// <<<<<<<<<<<<<<<< List View >>>>>>>>>>>>>>>>>>>>>
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

		// <<<<<<<<<<<<<<<< Socket Communication >>>>>>>>>>>>>>>>>>>>>
        private void F_MAIN_Load( object sender, EventArgs e )
        {
			server = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
			IPEndPoint iep = new IPEndPoint( IPAddress.Any, 9000 );
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
			Socket client = (Socket)iar.AsyncState;
			try
			{
				int recv = client.EndReceive( iar );

				if( recv == 0 )
				{
					client.Close();
					TB_MSG.Text = "Waiting for a Client...";
					server.BeginAccept( new AsyncCallback( AcceptConn ), server );
					return;
				}

				recvData = Encoding.UTF8.GetString( data, 0, recv );
				TB_LOG.Text = "";
				TB_LOG.Text = recvData;
				byte[] message2 = Encoding.UTF8.GetBytes( recvData );
				client.BeginSend( message2, 0, message2.Length, SocketFlags.None, new AsyncCallback( SendData ), client );

				packet_cnt++;
			}
			catch( Exception e )
			{
				TB_MSG.Text = e.Message.ToString();
			}

			if( packet_cnt == 1 )
			{
				CreateModelForm( recvData );

				for( int i = 0; i < Form_List.Count(); i++ )
					Form_List[i].Refresh();
			}
			
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
