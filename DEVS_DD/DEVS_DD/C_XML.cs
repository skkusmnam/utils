using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections;

namespace DEVS_DD {
    class C_XML : C_UTIL {
        XmlTextReader reader;
		ArrayList mList = new ArrayList();	// Model List

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
                    case C_DEFINE.COORDINATOR:
						AddGridRow( 1 );
                        SetCell( 0, C_DEFINE.COORDINATOR );
                        LoadAttributes( reader.NodeType, C_DEFINE.CRD );
                        break;
                    case C_DEFINE.SIM_FIRST:
						AddGridRow( 1 );
						SetCell( 0, C_DEFINE.SIM_FIRST );
                        LoadAttributes( reader.NodeType, C_DEFINE.SIM );
                        break;
					case C_DEFINE.SIM_LAST:
						AddGridRow( 1 );
						SetCell( 0, C_DEFINE.SIM_LAST );
						LoadAttributes( reader.NodeType, C_DEFINE.SIM );
						break;
                    case C_DEFINE.ATOMIC_IN:
						AddGridRow( 1 );
						SetCell( 0, C_DEFINE.ATOMIC_IN );
						LoadAttributes( reader.NodeType, C_DEFINE.ATM );
						break;
					case C_DEFINE.ATOMIC_OUT:
						AddGridRow( 1 );
						SetCell( 0, C_DEFINE.ATOMIC_OUT );
						LoadAttributes( reader.NodeType, C_DEFINE.ATM );
                        break;
                }
            }
        }

        public bool CheckEndElement( string startElement, string endElement )
        {
            if( endElement == "EndElement" )
                return true;

            return false;
        }

        public void LoadAttributes( XmlNodeType type, int flag )
        {
            switch( type )
            {
                // The node is an element
                case XmlNodeType.Element:
                    while( reader.MoveToNextAttribute() )
                    {
                        switch( flag )
                        {
                            case C_DEFINE.CRD:
                            case C_DEFINE.SIM:
							case C_DEFINE.ATM:
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

        public void InsertNode( string attr, string value )
        {
            switch( attr )
            {
                case C_DEFINE.NAME:
					AddModelList( value );
                    SetCell( 1, value );
                    break;
                case C_DEFINE.MESSAGE:
                    SetCell( 2, value );
                    break;
                case C_DEFINE.FROM:
                    SetCell( 3, value );
                    break;
                case C_DEFINE.TIME:
                    SetCell( 4, value );
                    break;
				case C_DEFINE.CPORT:
					SetCell( 5, value );
					break;
                case C_DEFINE.SAYING:
                    SetCell( 6, value );
                    break;
                case C_DEFINE.SIGMA:
                    SetCell( 2, value );
                    break;
                case C_DEFINE.PHASE:
                    SetCell( 3, value );
                    break;
				case C_DEFINE.APORT:
					SetCell( 4, value );
					break;
                case C_DEFINE.JOB:
                    SetCell( 5, value );
                    break;				
            }
        }

		public void AddModelList( string value )
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
