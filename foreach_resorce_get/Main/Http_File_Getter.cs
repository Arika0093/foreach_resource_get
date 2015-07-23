using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace foreach_resorce_get
{
	class Http_File_Getter
	{
		public Http_File_Getter(string BsUri)
		{
			BaseUri = BsUri;
		}
		public bool Get(int St, int Ed)
		{
			bool Rst = true;
			for(int i = St; i <= Ed; i++) {
				Rst = Rst && GetOfPart(i);
			}
			return Rst;
		}
		public bool GetOfPart(int Pt)
		{
			if(SaveDir == null || BaseUri == null) {
				return false;
			}
			WebClient Wc = new WebClient();
			string Dlname = String.Format(BaseUri, Pt);
			Wc.DownloadFile(Dlname, SaveDir + "\\" + Path.GetFileName(Dlname));
			return true;
		}

		public string SaveDir = null;
		private string BaseUri = null;
	}
}
