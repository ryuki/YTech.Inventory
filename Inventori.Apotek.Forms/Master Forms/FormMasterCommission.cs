using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using Inventori.Data;
using Inventori.Facade;
using Inventori.Module;

namespace Inventori.Apotek.Forms
{
    public partial class FormMasterCommission : FormParentForApotek
    {
        private DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        private MCommission comm;

        public FormMasterCommission()
        {
            InitializeComponent();
        }

        void FillCommissionStatus()
        {
            Type comm = typeof(ListOfCommission);

            commissionStatusComboBox.Items.Clear();
            foreach (string s in Enum.GetNames(comm))
            {
                commissionStatusComboBox.Items.Add(Enum.Parse(comm, s).ToString());
            }
            commissionStatusComboBox.Show();
        }

        private void FormMasterCommission_Load(object sender, EventArgs e)
        {
            ModuleControlSettings.SetNumericUpDown(commissionValueNumericUpDown);

            FillCommissionStatus();
            CreateCommissionShareTabPages();
        }

        enum ControlName
        {
            tab_pages_, num_, txt_, lbl_
        }

        private void CreateCommissionShareTabPages()
        {
            tabControl_CommissionShare.TabPages.Clear();
            Type share = typeof(ListOfCommissionShare);
            TabPage tab;
            Label lbl;
            NumericUpDown num;
            TextBox txt;
            string shareNameDisplay, shareName;

            foreach (string s in Enum.GetNames(share))
            {
                shareName = Enum.Parse(share, s).ToString();
                shareNameDisplay = shareName.Replace("_", " ");

                tab = new TabPage();
                tab.Name = ControlName.tab_pages_.ToString() + shareName;
                tab.Text = shareNameDisplay;
                tab.UseVisualStyleBackColor = true;

                //add label share to
                lbl = new Label();
                lbl.Text = "Dibagikan Ke :";
                lbl.AutoSize = true;
                lbl.Location = new Point(12, 17);
                tab.Controls.Add(lbl);

                //add share to
                lbl = new Label();
                lbl.Name = ControlName.lbl_.ToString() + shareName;
                lbl.Text = shareNameDisplay;
                lbl.AutoSize = true;
                lbl.Location = new Point(89, 17);
                tab.Controls.Add(lbl);

                //add label share value
                lbl = new Label();
                lbl.Text = "Nilai (%) :";
                lbl.AutoSize = true;
                lbl.Location = new Point(12, 38);
                tab.Controls.Add(lbl);

                //add numeric share value
                num = new NumericUpDown();
                num.Name = ControlName.num_.ToString() + shareName;
                num.Location = new Point(92, 36);
                //ModuleControlSettings.SetNumericUpDown(num);
                //num.Minimum = decimal.MinValue;
                tab.Controls.Add(num);

                //add label share desc
                lbl = new Label();
                lbl.Text = "Keterangan :";
                lbl.AutoSize = true;
                lbl.Location = new Point(12, 65);
                tab.Controls.Add(lbl);

                //add textboxdesc
                txt = new TextBox();
                txt.Name = ControlName.txt_.ToString() + shareName;
                txt.Multiline = true;
                txt.Location = new Point(92, 62);
                txt.Size = new Size(228, 78);
                tab.Controls.Add(txt);

                //add tab pages to tab control
                tabControl_CommissionShare.TabPages.Add(tab);
            }
        }

        private void commissionStatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MCommission comm = (MCommission)DataMaster.GetObjectByProperty(typeof(MCommission), MCommission.ColumnNames.CommissionStatus, commissionStatusComboBox.SelectedItem.ToString());
            if (comm == null)
                comm = new MCommission();

            commissionValueNumericUpDown.Value = comm.CommissionValue;
            commissionDescTextBox.Text = comm.CommissionDesc;

            FillCommissionShareTabPages(comm.CommissionId, false);
        }

        private void FillCommissionShareTabPages(decimal CommissionId, bool isSavePosition)
        {
            if (isSavePosition && CommissionId == 0)
            {
                MCommission comm = (MCommission)DataMaster.GetObjectByProperty(typeof(MCommission), MCommission.ColumnNames.CommissionStatus, commissionStatusComboBox.SelectedItem.ToString());
                CommissionId = comm.CommissionId;
            }
            Type share = typeof(ListOfCommissionShare);
            TabPage tab;
            NumericUpDown num;
            TextBox txt;
            MCommissionShare commShare;
            string shareName;

            foreach (string s in Enum.GetNames(share))
            {
                shareName = Enum.Parse(share, s).ToString();
                commShare = (MCommissionShare)DataMaster.GetObjectByProperty(typeof(MCommissionShare), MCommissionShare.ColumnNames.CommissionId, CommissionId, MCommissionShare.ColumnNames.ShareTo, shareName);
                if (commShare == null)
                    commShare = new MCommissionShare();

                tab = tabControl_CommissionShare.TabPages[ControlName.tab_pages_.ToString() + shareName];

                //set numeric share value
                num = (NumericUpDown)tab.Controls[ControlName.num_.ToString() + shareName];
                if (isSavePosition)
                    commShare.ShareValue = num.Value;
                else
                    num.Value = commShare.ShareValue;

                //add textboxdesc
                txt = (TextBox)tab.Controls[ControlName.txt_.ToString() + shareName];
                if (isSavePosition)
                    commShare.ShareDesc = txt.Text;
                else
                    txt.Text = commShare.ShareDesc;

                if (isSavePosition)
                {
                    commShare.CommissionId = CommissionId;
                    commShare.ShareTo = shareName;
                    DataMaster.SaveOrUpdate(commShare);

                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (commissionStatusComboBox.SelectedIndex ==-1)
            {
                MessageBox.Show("Pilih kategori tuslah !!!", AppCode.AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Information);
                commissionStatusComboBox.Focus();
                return;
            }

            MCommission comm = (MCommission)DataMaster.GetObjectByProperty(typeof(MCommission), MCommission.ColumnNames.CommissionStatus, commissionStatusComboBox.SelectedItem.ToString());
            if (comm == null)
                comm = new MCommission();

            comm.CommissionValue = commissionValueNumericUpDown.Value;
            comm.CommissionDesc = commissionDescTextBox.Text;
            comm.CommissionStatus = commissionStatusComboBox.SelectedItem.ToString();
            DataMaster.SaveOrUpdate(comm);

            FillCommissionShareTabPages(comm.CommissionId, true);

            MessageBox.Show(this.Text + " berhasil disimpan !!", AppCode.AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}