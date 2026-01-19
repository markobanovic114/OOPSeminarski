using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OOPSeminar.Model;
using OOPSeminar.Format;


namespace OOPSeminar.Services
{
	public class ProcessService : ProcessInfo
	{
		public List<ProcessInfo> GetProcesses()
		{
			var result = new List<ProcessInfo>();

			foreach (var process in Process.GetProcesses())
			{
				string Path = "Pristup zabranjen.";
				try
				{
					Path = process.MainModule.FileName;
				}
				catch { }
				try
				{
					result.Add(new ProcessInfo
					{
						Name = process.ProcessName,
						PID = process.Id,
						Responding = process.Responding,
						Memory = process.WorkingSet64,
						Path = Path
					});
				}
				catch
				{
                    MessageBox.Show($"Greška u dobavljanju procesa PID-a {PID}\n", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
			}

			return result;
		}

		public bool KillProcess(int pid)
		{
			try
			{
				Process.GetProcessById(pid).Kill();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public void SaveProcessesToFile(List<ProcessInfo> processes, string filePath, bool sort_checked)
		{
			var sb = new StringBuilder();
			sb.AppendLine("Name, PID, Memory, Responding, Path");
			if (sort_checked)
				processes = Formatting.SortProcesses(processes, sort_checked);

			foreach (var p in processes)
			{
				sb.AppendLine($"{p.Name}, {p.PID}, {p.Memory}, {p.Responding}, {p.Path}");
			}
			File.WriteAllText(filePath, sb.ToString());
		}

		public List<ProcessInfo> LoadProcessesFromFile(string filePath)
		{
			var result = new List<ProcessInfo>();
			var lines = File.ReadAllLines(filePath);

			for (int i = 1; i < lines.Length; i++)
			{
				var parts = lines[i].Split(',');

				result.Add(new ProcessInfo
				{
					Name = parts[0],
					PID = int.Parse(parts[1]),
					Memory = long.Parse(parts[2]),
					Responding = bool.Parse(parts[3]),
					Path = parts[4]
				});
			}

			return result;
		}
	}
}