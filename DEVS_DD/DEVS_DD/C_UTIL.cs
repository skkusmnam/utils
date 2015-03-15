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

		public void RemoveGridRow( int R )
		{
			( ( DataGridView )OBJ ).Rows.RemoveAt( R );
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
				return DEFINE.EMPTY;
		}

        public void ClearGrid()
        {
			( ( DataGridView )OBJ ).Rows.Clear();
        }

		public int GetCurrentRowIndex()
		{
			return ( ( DataGridView )OBJ ).CurrentCell.RowIndex;
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

		public void SetLabelText( object LABEL, string text )
		{
			switch( ( (Label)LABEL ).Name )
			{
				case "LB_MESSAGE":
				case "LB_VALUE_01":
				case "LB_VALUE_02":
				case "LB_VALUE_03":
				case "LB_VALUE_04":
					( (Label)LABEL ).TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
					break;
				case "LB_NAME_01":
				case "LB_NAME_02":
				case "LB_NAME_03":
				case "LB_NAME_04":
					( (Label)LABEL ).TextAlign = System.Drawing.ContentAlignment.MiddleRight;
					break;
			}

			( (Label)LABEL ).Visible = true;
			( (Label)LABEL ).Text = text;
		}

		public void SetLabelVisible( object LABEL, bool flag )
		{
			( (Label)LABEL ).Visible = flag;
		}

		//public void SetLabelText( object LB_NAME, object LB_VALUE, string text )
		//{
		//    ( (Label)LB_NAME ).Visible = true;

		//    ( (Label)LB_VALUE ).Visible = true;
		//    ( (Label)LB_VALUE ).Text = text;
		//}

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
