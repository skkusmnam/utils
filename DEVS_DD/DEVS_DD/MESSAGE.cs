using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DEVS_DD
{
	class MESSAGE 
	{
		// Error (E)
		public const string ERR001 = "해당 모델이 없습니다.";
		public const string ERR010 = "모델 생성 과정에서 불필요한 정보를 받았습니다.";

		// Message (M)
		public const string M010 = "모델을 끝까지 실행했습니다.";

		public void ShowMessage( string message )
		{
			MessageBox.Show( message );
		}
		
    }
}
