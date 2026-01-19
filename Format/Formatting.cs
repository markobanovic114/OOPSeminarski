using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPSeminar.Model;

namespace OOPSeminar.Format
{
	public static class Formatting
	{
		public static string FormatBytes(long bytes, bool showMb)
		{
			if (showMb)
				return Math.Round((bytes / 1024.0 / 1024.0), 2).ToString() + " MB";
			else
				return (bytes / 1024.0).ToString() + " KB";
		}

		public static string FormatResponse(bool response)
		{
			if (response)
				return "Proces radi pravilno.";
			else
				return "Proces ne odgovara.";
		}

		public static string FormatName(string name)
		{
			return name + ".exe";
		}

		public static List<ProcessInfo> SortProcesses(List<ProcessInfo> processes, bool sortbyPID)
		{
			if (sortbyPID)
			{
				processes.Sort((x, y) => Compare(x, y));
				return processes;
			}
			else return processes;
		}

		public static int Compare(ProcessInfo x, ProcessInfo y)
		{
			return x.PID.CompareTo(y.PID);
		}
	}
}
