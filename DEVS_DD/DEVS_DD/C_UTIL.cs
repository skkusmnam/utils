using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace DEVS_DD
{
    public class C_UTIL 
    {
        private object  OBJ;

		public C_UTIL()
		{
		}

        public C_UTIL( object obj )
        {
            OBJ = obj;
        }

        public object DataGrid
        {
			get { return OBJ; }
			set { OBJ = value; }
        }

        public void AddGridRow( int N )
        {
			( ( DataGridView )OBJ ).Rows.Add( N );
        }

		public void RemoveGridRow( int N )
		{
			( ( DataGridView )OBJ ).Rows.RemoveAt( N );
		}

        public void SetCell( int C, string S )
        {
			( ( DataGridView )OBJ )[C, ( ( DataGridView )OBJ ).RowCount - 2].Value = S;
        }

		public string GetValue( int C, int R )
		{
			if( ( ( DataGridView )OBJ )[C, R].Value != null )
				return ( ( DataGridView )OBJ )[C, R].Value.ToString();
			else
				return C_DEFINE.EMPTY;
		}

        public void ClearGrid()
        {
			( ( DataGridView )OBJ ).Rows.Clear();
        }

		public int GetRowCount()
		{
			return ( ( DataGridView )OBJ ).RowCount;
		}

		public void SetRowSelection( int R )
		{
			for( int i = 0; i < ( ( DataGridView )OBJ ).RowCount; i++ )
				( ( DataGridView )OBJ ).Rows[i].Selected = false;

			( ( DataGridView )OBJ ).Rows[R].Selected = true;
		}

		public void SetLabelText( object obj, string text )
		{
			if( text == C_DEFINE.EMPTY )
				( ( Label )obj ).Visible = false;
			else
			{
				( ( Label )obj ).Visible	= true;
				( ( Label )obj ).Text		= text;
			}
		}

		public void SetLabelText( object obj1, object obj2, string text )
		{
			if( text == C_DEFINE.EMPTY )
			{
				( ( Label )obj1 ).Visible = false;
				( ( Label )obj2 ).Visible = false;
			}
			else
			{
				( ( Label )obj2 ).Visible	= true;
				( ( Label )obj1 ).Visible = true;
				( ( Label )obj1 ).Text		= text;
			}
		}

		public void SetGroupBoxName( object obj, string name )
		{
			( ( GroupBox )obj ).Text = name;
			( ( GroupBox )obj ).Visible = true;
			( ( GroupBox )obj ).BringToFront();
		}

		public void SetGroupBoxVisible( object obj, bool flag )
		{
			( ( GroupBox )obj ).Visible = flag;
		}
    }
}
