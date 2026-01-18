using System;
using System.Collections.Generic;
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
                return "Proces je neispravan.";
        }

        public static string FormatName(string name)
        {
            return name + ".exe";
        }

        public static List<ProcessInfo> SortProcesses(List<ProcessInfo> processes)
        {
            processes.Sort((x, y) => x.PID.CompareTo(y.PID));
            return processes;
        }
    }
}
