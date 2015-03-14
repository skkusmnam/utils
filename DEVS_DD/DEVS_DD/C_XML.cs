using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections;

namespace DEVS_DD 
{
    class C_XML : C_UTIL 
	{
        XmlTextReader reader;

		// Model List
		ArrayList mList = new ArrayList();

		// DEVS_ObjectC로부터 XML를 받을 때 시작 모델의 정보가 다르기 때문에
		// EF-A부터 시작을 알리기 위한 변수
		private bool start_flag = false; 

        private string fileName;

        public C_XML( object oDG, string file ) : base( oDG )
        {
            DataGrid = oDG;
            ClearGrid();
            reader = new XmlTextReader( file );
        }

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

		public int GetModelListCount()
		{
			return mList.Count;
		}

        public void OpenXmlFile()
        {
            while( reader.Read() )
            {
                if( CheckEndElement( reader.Name, reader.NodeType.ToString() ) == true )
                    continue;
		
                switch( reader.Name )
                {
                    case DEFINE.COORDINATOR:
						AddGridRow( 1 );
                        SetCell( 0, DEFINE.COORDINATOR );
                        LoadAttributes( reader.NodeType, DEFINE.CRD );
                        break;
                    case DEFINE.SIM_FIRST:
						AddGridRow( 1 );
						SetCell( 0, DEFINE.SIM_FIRST );
                        LoadAttributes( reader.NodeType, DEFINE.SIM );
                        break;
					case DEFINE.SIM_LAST:
						AddGridRow( 1 );
						SetCell( 0, DEFINE.SIM_LAST );
						LoadAttributes( reader.NodeType, DEFINE.SIM );
						break;
                    case DEFINE.ATOMIC_IN:
						AddGridRow( 1 );
						SetCell( 0, DEFINE.ATOMIC_IN );
						LoadAttributes( reader.NodeType, DEFINE.ATM );
						break;
					case DEFINE.ATOMIC_OUT:
						AddGridRow( 1 );
						SetCell( 0, DEFINE.ATOMIC_OUT );
						LoadAttributes( reader.NodeType, DEFINE.ATM );
                        break;
                }
            }
        }

        private bool CheckEndElement( string startElement, string endElement )
        {
            if( endElement == "EndElement" )
                return true;

            return false;
        }

		private void LoadAttributes( XmlNodeType type, int flag )
        {
            switch( type )
            {
                // The node is an element
                case XmlNodeType.Element:
                    while( reader.MoveToNextAttribute() )
                    {
						if( start_flag == false )
						{
							if( CheckRootModel( reader.Value ) )
							{
								start_flag = true;
								RemoveGridRow( GetCurrentRowIndex() );
								return;
							}
						}

                        switch( flag )
                        {
                            case DEFINE.CRD:
                            case DEFINE.SIM:
							case DEFINE.ATM:
                                InsertNode( reader.Name, reader.Value );
                                break;
                        }
                    }
                    break;

                //Display the text in each element
                case XmlNodeType.Text:
                    //TB_ATTB.Text += reader.Value;
                    break;

                //Display the end of the element
                case XmlNodeType.EndElement:
                    //TB_ATTB.Text += Environment.NewLine;
                    break;
            }
        }

		private bool CheckRootModel( string name )
		{
			start_flag = false;

			if( name == DEFINE.EF_A )
			{
				start_flag = false;
				return start_flag;
			}
			return start_flag;
		}

		private void InsertNode( string attr, string value )
        {
            switch( attr )
            {
				//case DEFINE.NAME:
				//    AddModelList( value );
				//    SetCell( 1, value );
				//    break;
				//case DEFINE.MESSAGE:
				//    SetCell( 2, value );
				//    break;
				//case DEFINE.FROM:
				//    SetCell( 3, value );
				//    break;
				//case DEFINE.TIME:
				//    SetCell( 4, value );
				//    break;
				//case DEFINE.CPORT:
				//    SetCell( 5, value );
				//    break;
				//case DEFINE.SAYING:
				//    SetCell( 6, value );
				//    break;
				//case DEFINE.SIGMA:
				//    SetCell( 2, value );
				//    break;
				//case DEFINE.PHASE:
				//    SetCell( 3, value );
				//    break;
				//case DEFINE.APORT:
				//    SetCell( 4, value );
				//    break;
				//case DEFINE.JOB:
				//    SetCell( 5, value );
				//    break;				
            }
        }

		private void AddModelList( string value )
		{
			int flag = 0;

			for( int i = 0; i < mList.Count; i++ )
			{
				if( mList[i].ToString() == value )
					flag++;
			}

			if( flag == 0 )
				mList.Add( value );
		}
    }
}
