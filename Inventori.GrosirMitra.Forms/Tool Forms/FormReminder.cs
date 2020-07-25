using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Inventori.Data;
using Inventori.Facade;
using Inventori.Module;
using System.Collections;

namespace Inventori.GrosirMitra.Forms
{
    public partial class FormReminder : FormParentForGrosirMitra
    {
        Inventori.Facade.DataMasterMgtServices DataMaster = new Inventori.Facade.DataMasterMgtServices();

        public FormReminder()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.reminder_ico;
        }

        private void FormReminder_Load(object sender, EventArgs e)
        {
            CollectReminderData();
            timer1.Start();
        }

        private void CollectReminderData()
        {
            listView_Reminder.Items.Clear();

            MGudang gud;
            ItemGudangStok stok;
            MItem item;
            ListViewItem viewItem;

            IList listStok = DataMaster.GetAll(typeof(ItemGudangStok));
            string gudangName = "";
            for (int i = 0; i < listStok.Count; i++)
            {
                stok = (ItemGudangStok)listStok[i];
                gud = (MGudang)DataMaster.GetObjectByProperty(typeof(MGudang), MGudang.ColumnNames.GudangId, stok.GudangId);
                if (gud != null)
                    gudangName = gud.GudangName;

                //kurang dari batas minimum
                if (stok.ItemStok < stok.ItemMinStok)
                {
                    viewItem = new ListViewItem();
                    item = (MItem)DataMaster.GetObjectByProperty(typeof(MItem), MItem.ColumnNames.ItemId, stok.ItemId);
                    if (item != null)
                        viewItem.Text = item.ItemName + " (" + gudangName + ")";
                    else
                        viewItem.Text = stok.ItemId + " (" + gudangName + ")";

                    viewItem.SubItems.Add(ModuleControlSettings.NumericFormat(stok.ItemStok));
                    viewItem.Group = listView_Reminder.Groups[0];
                    listView_Reminder.Items.Add(viewItem);
                }
            }

            IList listSupp = DataMaster.GetAll(typeof(MSupplier));
            IList listPiHutang;
            MSupplier supp;
            TPiHutang pihut;
            decimal totPiHut;

            //get hutang
            for (int i = 0; i < listSupp.Count; i++)
            {
                supp = (MSupplier)listSupp[i];
                listPiHutang = DataMaster.GetListEqNotEqLessThan(typeof(TPiHutang), TPiHutang.ColumnNames.PiHutangPic, supp.SupplierId, TPiHutang.ColumnNames.PiHutangStatus, ListOfPiHutangStatus.Hutang.ToString(), TPiHutang.ColumnNames.PiHutangSisa, decimal.Zero, TPiHutang.ColumnNames.PiHutangJatuhTempo, DateTime.Now);

                totPiHut = 0;
                for (int j = 0; j < listPiHutang.Count; j++)
                {
                    pihut = (TPiHutang)listPiHutang[j];
                    totPiHut += pihut.PiHutangSisa;
                }

                if (totPiHut != 0)
                {
                    viewItem = new ListViewItem();
                    viewItem.Text = supp.SupplierName;
                    viewItem.SubItems.Add(ModuleControlSettings.NumericFormat(totPiHut));
                    viewItem.Group = listView_Reminder.Groups[1];
                    listView_Reminder.Items.Add(viewItem);
                }
            }

            IList listCust = DataMaster.GetAll(typeof(MCustomer));
            MCustomer cust;

            //get piutang
            for (int i = 0; i < listCust.Count; i++)
            {
                cust = (MCustomer)listCust[i];
                listPiHutang = DataMaster.GetListEqNotEqLessThan(typeof(TPiHutang), TPiHutang.ColumnNames.PiHutangPic, cust.CustomerId, TPiHutang.ColumnNames.PiHutangStatus, ListOfPiHutangStatus.Piutang.ToString(), TPiHutang.ColumnNames.PiHutangSisa, decimal.Zero, TPiHutang.ColumnNames.PiHutangJatuhTempo, DateTime.Now);

                totPiHut = 0;
                for (int j = 0; j < listPiHutang.Count; j++)
                {
                    pihut = (TPiHutang)listPiHutang[j];
                    totPiHut += pihut.PiHutangSisa;
                }

                if (totPiHut != 0)
                {
                    viewItem = new ListViewItem();
                    viewItem.Text = cust.CustomerName;
                    viewItem.SubItems.Add(ModuleControlSettings.NumericFormat(totPiHut));
                    viewItem.Group = listView_Reminder.Groups[2];
                    listView_Reminder.Items.Add(viewItem);
                }
            }
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            CollectReminderData();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CollectReminderData();
        }
    }
}