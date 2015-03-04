using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DEVS_DD
{
    public partial class F_VIEW : Form
    {
        public F_VIEW()
        {
            InitializeComponent();
        }

        public void AddModelName( string name )
        {
            V_LIST.Items.Add( name );
            V_LIST.EndUpdate();
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
        public ListViewItemComparer(int column, string sort)
        {
            col = column;
            this.sort = sort;
        }

        public int Compare(object x, object y)
        {
            if (sort == "asc")
                return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            else
                return String.Compare(((ListViewItem)y).SubItems[col].Text, ((ListViewItem)x).SubItems[col].Text);
        }
    }
}
