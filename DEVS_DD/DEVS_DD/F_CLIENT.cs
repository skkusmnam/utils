using System;
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
	public partial class F_CLIENT : Form
	{
		private Socket client;
		private byte[] data = new byte[1024];
		private int size = 1024;

		public F_CLIENT()
		{
			InitializeComponent();

			textBox1.Text = "접속중......";
			Socket newsock = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
			IPEndPoint iep = new IPEndPoint( IPAddress.Parse( "127.0.0.1" ), 10000 );
			newsock.BeginConnect( iep, new AsyncCallback( Connected ), newsock );
		}

		private void button1_Click( object sender, EventArgs e )
		{
			string temp = "0|CM,R:EF_A,EF_A,1,|AM,EF_A,P,2,|CM,EF_A,EF,2,|AM,EF,GENR,3,|AM,EF,TRANSD,3,|";
			byte[] message = Encoding.UTF8.GetBytes( temp );
			client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
		}

		private void Form1_FormClosing( object sender, FormClosingEventArgs e )
		{
			if( client != null )
			{
				client.Close();
			}
		}

		private void Connected( IAsyncResult iar )
		{
			client = (Socket)iar.AsyncState;
			try
			{
				client.EndConnect( iar );
				textBox1.Text = client.RemoteEndPoint.ToString() + "에 연결 완료";
				client.BeginReceive( data, 0, size, SocketFlags.None, new AsyncCallback( ReceiveData ), client );
			}
			catch( SocketException )
			{
				textBox1.Text = "연결 실패";
			}
		}

		private void ReceiveData( IAsyncResult iar )
		{
			//Socket remote = (Socket)iar.AsyncState;
			//int recv = remote.EndReceive( iar );
			//string stringData = Encoding.UTF8.GetString( data, 0, recv );
			//textBox2.Text += stringData + Environment.NewLine;
		}

		private void SendData( IAsyncResult iar )
		{
			Socket remote = (Socket)iar.AsyncState;
			int sent = remote.EndSend( iar );
			remote.BeginReceive( data, 0, size, SocketFlags.None, new AsyncCallback( ReceiveData ), remote );
		}

	}
}
