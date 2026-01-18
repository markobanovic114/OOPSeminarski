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
        public bool clicked = false;
		public bool sort_checked = false;
        private string _name;
		private int _pid;
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}
		public int PID
		{
			get
			{
				return _pid;
			}
			set
			{
				_pid = (value >= 0) ? value : -1;
			}
		}
		public long Memory { get; set; }
		public bool Responding { get; set; }
		public string Path { get; set; }
		public string MemoryShow { get; set; }
		public string ResponseShow { get; set; }
	}
}
