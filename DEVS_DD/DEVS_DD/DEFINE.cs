using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEVS_DD
{
    class DEFINE 
	{
		public	const string EMPTY	= "";
		public	const string BLANK	= " ";

		// ERROR
		public	const int ERR = -9;

        public  const int CRD = 1;
        public  const int SIM = 2;
        public  const int ATM = 3;

		public const int INIT = 0;

		public const string YES = "1";
        public const string ROOT = "root";
		public const string ROOT_COORDINATOR = "CM,root,R:EF_A,0,";

		// Form Position
		public	const int FORM_GAP	= 100;
		public	const int INIT_X	= 100;
		public	const int INIT_Y	= 100;

		// Model Name
		public	const string EF_A	= "EF-A";
		public	const string EF		= "EF";
		public	const string TRANSD	= "TRANSD";
		public	const string GENR	= "GENR";

		// Message Type
		public const string STAR = "*";
		public const string EXT = "Ext";		
		public const string DONE = "DONE";
		

        public  const string COORDINATOR    = "CRD";
        public  const string SIM_FIRST      = "SMF";
		public	const string SIM_LAST		= "SML";
        public  const string ATOMIC_IN      = "ATI";
		public  const string ATOMIC_OUT		= "ATO";

		public const string MESSAGE_STRING = "-message";
		public const string RECEIVED_FROM = "received from: ";
		public const string WITH_TIME = "with time: ";


        public  const string FROM   = "from";
        public  const string TIME   = "time";
        public  const string SAYING = "saying";
        public  const string SIGMA  = "sigma";
        public  const string PHASE  = "phase";
        public  const string JOB    = "job";
		public	const string CPORT	= "cport";
		public	const string APORT	= "aport";
    }
}
