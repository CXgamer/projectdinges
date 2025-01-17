﻿namespace Motorozoid
{
    partial class ExcelToSqlForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.excelOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.kiesExcelButton = new System.Windows.Forms.Button();
            this.fileTextBox = new System.Windows.Forms.TextBox();
            this.opslaanButton = new System.Windows.Forms.Button();
            this.annuleerButton = new System.Windows.Forms.Button();
            this.machinesDataGridView = new System.Windows.Forms.DataGridView();
            this.Naam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Label = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vermogen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NominaalToerental = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NominaalKoppel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductieMachine = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.machinesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // excelOpenFileDialog
            // 
            this.excelOpenFileDialog.FileName = "excelOpenFileDialog";
            // 
            // kiesExcelButton
            // 
            this.kiesExcelButton.Location = new System.Drawing.Point(691, 11);
            this.kiesExcelButton.Name = "kiesExcelButton";
            this.kiesExcelButton.Size = new System.Drawing.Size(75, 23);
            this.kiesExcelButton.TabIndex = 1;
            this.kiesExcelButton.Text = "Bladeren...";
            this.kiesExcelButton.UseVisualStyleBackColor = true;
            this.kiesExcelButton.Click += new System.EventHandler(this.kiesExcelButton_Click);
            // 
            // fileTextBox
            // 
            this.fileTextBox.Location = new System.Drawing.Point(12, 13);
            this.fileTextBox.Name = "fileTextBox";
            this.fileTextBox.ReadOnly = true;
            this.fileTextBox.Size = new System.Drawing.Size(673, 20);
            this.fileTextBox.TabIndex = 0;
            this.fileTextBox.TabStop = false;
            this.fileTextBox.Click += new System.EventHandler(this.fileTextBox_Click);
            // 
            // opslaanButton
            // 
            this.opslaanButton.Enabled = false;
            this.opslaanButton.Location = new System.Drawing.Point(610, 353);
            this.opslaanButton.Name = "opslaanButton";
            this.opslaanButton.Size = new System.Drawing.Size(75, 23);
            this.opslaanButton.TabIndex = 3;
            this.opslaanButton.Text = "Opslaan";
            this.opslaanButton.UseVisualStyleBackColor = true;
            this.opslaanButton.Click += new System.EventHandler(this.opslaanButton_Click);
            // 
            // annuleerButton
            // 
            this.annuleerButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.annuleerButton.Location = new System.Drawing.Point(691, 353);
            this.annuleerButton.Name = "annuleerButton";
            this.annuleerButton.Size = new System.Drawing.Size(75, 23);
            this.annuleerButton.TabIndex = 4;
            this.annuleerButton.Text = "Annuleren";
            this.annuleerButton.UseVisualStyleBackColor = true;
            this.annuleerButton.Click += new System.EventHandler(this.annuleerButton_Click);
            // 
            // machinesDataGridView
            // 
            this.machinesDataGridView.AllowUserToAddRows = false;
            this.machinesDataGridView.AllowUserToDeleteRows = false;
            this.machinesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.machinesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Naam,
            this.Type,
            this.Label,
            this.Vermogen,
            this.NominaalToerental,
            this.NominaalKoppel,
            this.ProductieMachine});
            this.machinesDataGridView.Location = new System.Drawing.Point(13, 39);
            this.machinesDataGridView.Name = "machinesDataGridView";
            this.machinesDataGridView.Size = new System.Drawing.Size(753, 308);
            this.machinesDataGridView.TabIndex = 5;
            // 
            // Naam
            // 
            this.Naam.HeaderText = "Naam";
            this.Naam.MaxInputLength = 15;
            this.Naam.Name = "Naam";
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            // 
            // Label
            // 
            this.Label.HeaderText = "Label";
            this.Label.MaxInputLength = 10;
            this.Label.Name = "Label";
            // 
            // Vermogen
            // 
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = "0";
            this.Vermogen.DefaultCellStyle = dataGridViewCellStyle1;
            this.Vermogen.HeaderText = "Vermogen(kW)";
            this.Vermogen.Name = "Vermogen";
            // 
            // NominaalToerental
            // 
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0";
            this.NominaalToerental.DefaultCellStyle = dataGridViewCellStyle2;
            this.NominaalToerental.HeaderText = "Nominaal-Toerental";
            this.NominaalToerental.MaxInputLength = 18;
            this.NominaalToerental.Name = "NominaalToerental";
            // 
            // NominaalKoppel
            // 
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.NominaalKoppel.DefaultCellStyle = dataGridViewCellStyle3;
            this.NominaalKoppel.HeaderText = "Nominaal-Koppel";
            this.NominaalKoppel.MaxInputLength = 18;
            this.NominaalKoppel.Name = "NominaalKoppel";
            // 
            // ProductieMachine
            // 
            this.ProductieMachine.HeaderText = "ProductieMachine";
            this.ProductieMachine.Name = "ProductieMachine";
            // 
            // ExcelToSqlForm
            // 
            this.AcceptButton = this.opslaanButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.annuleerButton;
            this.ClientSize = new System.Drawing.Size(778, 387);
            this.Controls.Add(this.machinesDataGridView);
            this.Controls.Add(this.annuleerButton);
            this.Controls.Add(this.opslaanButton);
            this.Controls.Add(this.fileTextBox);
            this.Controls.Add(this.kiesExcelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MinimizeBox = false;
            this.Name = "ExcelToSqlForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excel naar database";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ExcelToSqlForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.machinesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog excelOpenFileDialog;
        private System.Windows.Forms.Button kiesExcelButton;
        private System.Windows.Forms.TextBox fileTextBox;
        private System.Windows.Forms.Button opslaanButton;
        private System.Windows.Forms.Button annuleerButton;
        private System.Windows.Forms.DataGridView machinesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naam;
        private System.Windows.Forms.DataGridViewComboBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Label;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vermogen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NominaalToerental;
        private System.Windows.Forms.DataGridViewTextBoxColumn NominaalKoppel;
        private System.Windows.Forms.DataGridViewComboBoxColumn ProductieMachine;
       
    }
}