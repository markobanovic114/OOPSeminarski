using OOPSeminar.Format;
using OOPSeminar.Model;
using OOPSeminar.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPSeminar
{
	public partial class Main : Form
	{
		private ProcessService processService;
		public Main()
		{
			processService = new ProcessService();
			InitializeComponent();
			LoadProcesses();
		}
		private void LoadProcesses()
		{
			try
			{
				var processes = processService.GetProcesses();
				bool showMb = FormatCheckbox.Checked;
				bool sortbyPID = SortCheckbox.Checked;

				foreach (var p in processes)
				{
					p.Name = Formatting.FormatName(p.Name);
					p.MemoryShow = Formatting.FormatBytes(p.Memory, showMb);
					p.ResponseShow = Formatting.FormatResponse(p.Responding);
				}
				if(sortbyPID)
					processes = Formatting.SortProcesses(processes, sortbyPID);
				dataGridViewProcesses.DataSource = processes;
			}
			catch
			{
				MessageBox.Show("Neuspješno učitavanje procesa.\n", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void RefreshProcesses_Click(object sender, EventArgs e)
		{
			processService.loaded_file = false;
			LoadProcesses();
		}

		private void KillProcess_Click(object sender, EventArgs e)
		{
			if (processService.loaded_file == true)
			{
				MessageBox.Show("Trenutno pregledavate procese iz datoteke. Kliknite osvježi za korištenje ove opcije.\n", "Greška", MessageBoxButtons.OK);
				return;
			}
			if (dataGridViewProcesses.SelectedRows.Count == 0)
			{
				MessageBox.Show("Prvo izaberite proces klikom na lijevu stranu.\n");
				return;
			}

			var selected = (ProcessInfo)dataGridViewProcesses.SelectedRows[0].DataBoundItem;

			var confirm = MessageBox.Show($"Želite li ugasiti {selected.Name} (PID {selected.PID})?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

			if (confirm != DialogResult.Yes)
				return;

			bool success = processService.KillProcess(selected.PID);

			if (!success)
				MessageBox.Show("Greška u zatvaranju procesa.");

			LoadProcesses();
		}

		private void SaveFile_Click(object sender, EventArgs e)
		{
			var dialog = new SaveFileDialog();
			dialog.Filter = "TXT datoteke (*.txt)|*.txt";
			dialog.Title = "Spremanje u datoteku";

			if (dialog.ShowDialog() == DialogResult.OK)
			{
				var procesi = processService.GetProcesses();
				processService.SaveProcessesToFile(procesi, dialog.FileName, SortCheckbox.Checked);

				MessageBox.Show("Procesi uspješno spremljeni.\n");
			}
		}

		private void LoadFile_Click(object sender, EventArgs e)
		{
			processService.loaded_file = true;
			var dialog = new OpenFileDialog();
			dialog.Filter = "TXT datoteke (*.txt)|*.txt";
			dialog.Title = "Učitaj datoteku";

			if (dialog.ShowDialog() == DialogResult.OK)
			{
				var processes = processService.LoadProcessesFromFile(dialog.FileName);

				foreach (var p in processes)
				{
					p.Name = Formatting.FormatName(p.Name);
					p.MemoryShow = Formatting.FormatBytes(p.Memory, FormatCheckbox.Checked);
					p.ResponseShow = p.Responding ? "Proces radi pravilno." : "Proces je neispravan";
				}

				dataGridViewProcesses.DataSource = processes;
				MessageBox.Show("Procesi uspješno učitani.\n");
			}
		}

		private void dataGridViewProcesses_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (dataGridViewProcesses.Columns[e.ColumnIndex].Name == "colResponding")
			{
				Formatting.FormatCellsResponse(sender, e);
			}

			if (dataGridViewProcesses.Columns[e.ColumnIndex].Name == "colMemory")
			{
				var row = dataGridViewProcesses.Rows[e.RowIndex];
				ProcessInfo process = row.DataBoundItem as ProcessInfo;

				Formatting.FormatCellsMemory(sender, e, process);
			}
		}
	}
}