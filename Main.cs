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
				dataGridViewProcesses.AutoGenerateColumns = false;
				dataGridViewProcesses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
				dataGridViewProcesses.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridViewProcesses.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                var processes = processService.GetProcesses();
				bool showMb = FormatCheckbox.Checked;

				foreach (var p in processes)
				{
					p.Name = Formatting.FormatName(p.Name);
					p.MemoryShow = Formatting.FormatBytes(p.Memory, showMb);
					p.ResponseShow = Formatting.FormatResponse(p.Responding);
				}

				if(processService.sort_checked == true)
				{
					processes = Formatting.SortProcesses(processes);
                }
				dataGridViewProcesses.DataSource = processes;
			}
			catch
			{
				MessageBox.Show("Neuspješno učitavanje procesa.\n", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
        private void SortCheckbox_CheckedChanged(object sender, EventArgs e)
        {
			if (SortCheckbox.Checked == false)
			{
				processService.sort_checked = false;
			}
			else if (SortCheckbox.Checked == true)
			{
				processService.sort_checked = true;
			}
        }
        private void RefreshProcesses_Click(object sender, EventArgs e)
        {
            processService.clicked = false;
            LoadProcesses();
        }

        private void KillProcess_Click(object sender, EventArgs e)
        {
            if (processService.clicked == true)
            {
                MessageBox.Show("Trenutno pregledavate procese. Kliknite osvježi za ovu opciju.\n", "Greška", MessageBoxButtons.OK);
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
                processService.SaveProcessesToFile(procesi, dialog.FileName);

                MessageBox.Show("Procesi uspješno spremljeni.\n");
            }
        }

        private void LoadFile_Click(object sender, EventArgs e)
        {
            processService.clicked = true;
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
            }
        }
    }
}