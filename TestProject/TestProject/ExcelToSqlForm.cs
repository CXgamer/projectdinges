﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MotorozoidDB;
using System.IO;
using System.Data.SqlClient;
using System.Threading;

namespace Motorozoid
{
    /// <summary>
    /// Gui klasse omzetten van excel naar database
    /// </summary>
    /// <author>Brecht Derwael</author>
    public partial class ExcelToSqlForm : Form
    {
        private string fileName;
        private List<Machine> machines;
        private HoofdSchermForm hoofdscherm;

        /// <summary> 
        /// Constructor van de klasse ExcelToSqlForm
        /// </summary>
        /// <param name="hoofdscherm">object van het type HoofdSchermForm</param>         
        /// <author>Wim Baens</author> 
        public ExcelToSqlForm(HoofdSchermForm hoofdscherm)
        {
            InitializeComponent();
            this.hoofdscherm = hoofdscherm;
            hoofdscherm.Enabled = false;
        }

        private void kiesExcelButton_Click(object sender, EventArgs e)
        {
            loadExcel();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fileTextBox_Click(object sender, EventArgs e)
        {
            loadExcel();
        }


        /// <summary> 
        /// mogelijkheid om een excelbestand te kiezen
        /// </summary>        
        /// <author>Wim Baens</author>       
        private void loadExcel()
        {
            excelOpenFileDialog.Filter = "Excelbestanden(*.xlsx)|*.xlsx";

            if (excelOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = excelOpenFileDialog.FileName;
                fileTextBox.Text = fileName;
                if (MessageBox.Show(this, "Bent u zeker dat het bestand mag ingelezen worden?", "Inlezen excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (BestandDB.controleerPad(fileName))
                    {
                        try
                        {
                            machines = ExcelDB.excelToSql(excelOpenFileDialog.FileName);
                            fillGridView(machines);
                            opslaanButton.Enabled = true;
                            opslaanButton.Focus();
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(this, ex.Message, ex.GetType().ToString());
                        }
                        catch (IOException)
                        {
                            MessageBox.Show(this, "Gelieve eerst het excelbestand te sluiten! Probeer daarna opnieuw.", "Excelbestand Sluiten", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show(this, "Corrupt of fout excelbestand!", "Excelbestand foutief", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Excelbestand bestaat al!", "Bestaand Excelbestand", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        /// <summary> 
        /// Vult de gridview met machines objecten die net ingevuld zijn in de database
        /// </summary>        
        /// <param name="m">lijst met Machine objecten</param>        
        /// <author>Brecht Derwael en Wim Baens</author> 
        /// <author>Wim Baens: Exception oproepen als parsen niet lijkt en je alles zelf moet invullen</author>
        /// <author>Wim Baens: Types en ProductieMachines toegevoegd</author>
        private void fillGridView(List<Machine> m)
        {
            string naam;
            List<TypeMachine> types = TypeMachineDB.getTypes();
            List<ProductieMachine> prodMach = ProductieMachineDB.getProductieMachines();
            Type.DataSource = types;
            Type.DisplayMember = "TypeNaam";
            Type.ValueMember = "TypeId";
            ProductieMachine.DataSource = prodMach;
            ProductieMachine.DisplayMember = "ProductieMachineNaam";
            ProductieMachine.ValueMember = "ProductieMachineID";
            foreach (Machine mach in m)
            {
                naam = mach.MachineNaam;
                mach.NominaalToerental = 1500;
                naam.Replace('-', ' ');
                
                try
                {
                    string[] s = naam.Split(' ');
                    mach.Label = s[1];
                    string vermogenString = s[0].Trim(new char[] { 'k', 'W', 'K', 'w' });
                    mach.Vermogen = Convert.ToDouble(vermogenString);
                    mach.NominaalKoppel = Math.Round(Convert.ToDouble(mach.Vermogen * 1000 / (2 * Math.PI * 25)), 2);
                }
                catch (Exception)
                {
                    MessageBox.Show(this,"Geen bruikbare data in de machinenaam. Vul alles zelf in!", "Format fout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                machinesDataGridView.Rows.Add(naam, mach.TypeId, mach.Label, mach.Vermogen, mach.NominaalToerental, mach.NominaalKoppel,mach.ProductieMachineID);
            }
        }

        private void opslaanButton_Click(object sender, EventArgs e)
        {           
            try
            {
                updateMachine('o');
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("U heeft niet alles ingevuld. Vul alles correct in!", "Input fout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (FormatException)
            {
                MessageBox.Show("Vul alles correct in!", "Input fout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void annuleerButton_Click(object sender, EventArgs e)
        {
            updateMachine('c');
            hoofdscherm.refresh();
            this.Close();
        }

        private void ExcelToSqlForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            hoofdscherm.Enabled = true;
        }

        /// <summary> 
        /// de Machine objecten worden geupdated in de database
        /// </summary>
        /// <param name="close">één char</param>         
        /// <author>Wim Baens en Brecht Derwael</author> 
        /// <author>Wim Baens: switch gemaakt om de method te kunnen herbruiken als er op annuleren wordt geklikt</author>
        private void updateMachine(char close)
        {
            int l = machinesDataGridView.RowCount;

            switch (close)
            {
                case 'o':
                    for (int i = 0; i < l; i++)
                    {
                        machines[i].MachineNaam = machinesDataGridView["Naam", i].Value.ToString();
                        machines[i].TypeId = Convert.ToInt32(machinesDataGridView["Type", i].Value);
                        machines[i].Vermogen = Convert.ToDouble(machinesDataGridView["Vermogen", i].Value);
                        machines[i].NominaalToerental = Convert.ToDouble(machinesDataGridView["NominaalToerental", i].Value);
                        machines[i].NominaalKoppel = Convert.ToInt32(machinesDataGridView["NominaalKoppel", i].Value);
                        machines[i].Label = machinesDataGridView["Label", i].Value.ToString();
                        machines[i].ProductieMachineID = Convert.ToInt32(machinesDataGridView["ProductieMachine",i].Value)+1;                       
                    }
                    break;
                case 'c':
                    for (int i = 0; i < l; i++)
                    {
                        machines[i].MachineNaam = machinesDataGridView["Naam", i].Value.ToString();
                        machines[i].TypeId = 0;
                        machines[i].Vermogen = 0;
                        machines[i].NominaalToerental = 0;
                        machines[i].NominaalKoppel = 0;
                        machines[i].Label = "";                       
                    }
                    break;
            } if (l > 0)
            {
                MachineDB.updateMachineData(machines,fileName);
            }
            hoofdscherm.refresh();
            this.Close();
        }       
    }
}

