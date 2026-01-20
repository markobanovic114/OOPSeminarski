using OOPSeminar.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

		public static void FormatCellsMemory(object sender, DataGridViewCellFormattingEventArgs e, ProcessInfo process)
		{
            long memoryMb = process.Memory / (1024 * 1024);

            if (memoryMb < 100)
            {
                e.CellStyle.BackColor = Color.LightGreen;
            }
            else if (memoryMb < 500)
            {
                e.CellStyle.BackColor = Color.Khaki;
            }
            else
            {
                e.CellStyle.BackColor = Color.LightCoral;
            }
        }

        public static void FormatCellsResponse(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value?.ToString() == "Proces radi pravilno.")
            {
                e.CellStyle.BackColor = Color.LightGreen;
            }
            else
            {
                e.CellStyle.BackColor = Color.LightCoral;
            }
        }
    }
}
