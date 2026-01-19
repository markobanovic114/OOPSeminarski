using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPSeminar.Model
{
	public class ProcessInfo
	{
		public bool loaded_file = false;

		private int pid;

		public string Name{ get; set; }
		public int PID
		{
			get{return pid;}
			set{pid = (value >= 0) ? value : -1;}
		}
		public long Memory { get; set; }
		public bool Responding { get; set; }
		public string Path { get; set; }

		public string MemoryShow { get; set; }
		public string ResponseShow { get; set; }
	}
}
