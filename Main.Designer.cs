using System;
using System.Drawing;
using System.Windows.Forms;

namespace OOPSeminar
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.dataGridViewProcesses = new System.Windows.Forms.DataGridView();
            this.FormatCheckbox = new System.Windows.Forms.CheckBox();
            this.SortCheckbox = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.RefreshProcesses = new System.Windows.Forms.ToolStripMenuItem();
            this.KillProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadFile = new System.Windows.Forms.ToolStripMenuItem();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResponding = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProcesses)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewProcesses
            // 
            this.dataGridViewProcesses.BackgroundColor = System.Drawing.SystemColors.HotTrack;
            this.dataGridViewProcesses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewProcesses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProcesses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colPID,
            this.colMemory,
            this.colResponding,
            this.colPath});
            this.dataGridViewProcesses.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewProcesses.Name = "dataGridViewProcesses";
            this.dataGridViewProcesses.Size = new System.Drawing.Size(699, 389);
            this.dataGridViewProcesses.TabIndex = 7;
            // 
            // FormatCheckbox
            // 
            this.FormatCheckbox.AutoSize = true;
            this.FormatCheckbox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.FormatCheckbox.Location = new System.Drawing.Point(147, 407);
            this.FormatCheckbox.Name = "FormatCheckbox";
            this.FormatCheckbox.Size = new System.Drawing.Size(103, 17);
            this.FormatCheckbox.TabIndex = 2;
            this.FormatCheckbox.Text = "Zamijeni KB/MB";
            this.FormatCheckbox.UseVisualStyleBackColor = true;
            // 
            // SortCheckbox
            // 
            this.SortCheckbox.AutoSize = true;
            this.SortCheckbox.BackColor = System.Drawing.SystemColors.HotTrack;
            this.SortCheckbox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SortCheckbox.Location = new System.Drawing.Point(443, 407);
            this.SortCheckbox.Name = "SortCheckbox";
            this.SortCheckbox.Size = new System.Drawing.Size(113, 17);
            this.SortCheckbox.TabIndex = 6;
            this.SortCheckbox.Text = "Sortirano po PID-u";
            this.SortCheckbox.UseVisualStyleBackColor = false;
            this.SortCheckbox.CheckedChanged += new System.EventHandler(this.SortCheckbox_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RefreshProcesses,
            this.KillProcess,
            this.SaveFile,
            this.LoadFile});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(147, 427);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(409, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // RefreshProcesses
            // 
            this.RefreshProcesses.Name = "RefreshProcesses";
            this.RefreshProcesses.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.RefreshProcesses.Size = new System.Drawing.Size(100, 20);
            this.RefreshProcesses.Text = "Osvježi Procese";
            this.RefreshProcesses.Click += new System.EventHandler(this.RefreshProcesses_Click);
            // 
            // KillProcess
            // 
            this.KillProcess.Name = "KillProcess";
            this.KillProcess.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.KillProcess.Size = new System.Drawing.Size(86, 20);
            this.KillProcess.Text = "Ugasi Proces";
            this.KillProcess.Click += new System.EventHandler(this.KillProcess_Click);
            // 
            // SaveFile
            // 
            this.SaveFile.Name = "SaveFile";
            this.SaveFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveFile.Size = new System.Drawing.Size(116, 20);
            this.SaveFile.Text = "Spremi u datoteku";
            this.SaveFile.Click += new System.EventHandler(this.SaveFile_Click);
            // 
            // LoadFile
            // 
            this.LoadFile.Name = "LoadFile";
            this.LoadFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.LoadFile.Size = new System.Drawing.Size(99, 20);
            this.LoadFile.Text = "Učitaj datoteku";
            this.LoadFile.Click += new System.EventHandler(this.LoadFile_Click);
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Ime Procesa";
            this.colName.Name = "colName";
            // 
            // colPID
            // 
            this.colPID.DataPropertyName = "PID";
            this.colPID.HeaderText = "PID";
            this.colPID.Name = "colPID";
            // 
            // colMemory
            // 
            this.colMemory.DataPropertyName = "MemoryShow";
            this.colMemory.HeaderText = "Korištenje memorije";
            this.colMemory.Name = "colMemory";
            // 
            // colResponding
            // 
            this.colResponding.DataPropertyName = "ResponseShow";
            this.colResponding.HeaderText = "Ispravnost";
            this.colResponding.Name = "colResponding";
            this.colResponding.Width = 140;
            // 
            // colPath
            // 
            this.colPath.DataPropertyName = "Path";
            this.colPath.HeaderText = "Put do datoteke";
            this.colPath.Name = "colPath";
            // 
            // Main
            // 
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(723, 450);
            this.Controls.Add(this.SortCheckbox);
            this.Controls.Add(this.FormatCheckbox);
            this.Controls.Add(this.dataGridViewProcesses);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Upravitelj Zadataka";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProcesses)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewProcesses;
        private System.Windows.Forms.CheckBox FormatCheckbox;
        private System.Windows.Forms.CheckBox SortCheckbox;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem RefreshProcesses;
        private ToolStripMenuItem KillProcess;
        private ToolStripMenuItem SaveFile;
        private ToolStripMenuItem LoadFile;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colPID;
        private DataGridViewTextBoxColumn colMemory;
        private DataGridViewTextBoxColumn colResponding;
        private DataGridViewTextBoxColumn colPath;
    }
}

