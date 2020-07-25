using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Inventori.Data;
using Inventori.Facade;

namespace Inventori.GrosirMitra.Forms
{
    public partial class Form1 : Form
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("transaction id");
            dt.Columns.Add("faktur");
            dt.Columns.Add("trans status");
            dt.Columns.Add("item id");
            dt.Columns.Add("status add");
            dt.Columns.Add("jumlah");
            dt.Columns.Add("saldo");
            dt.Columns.Add("saldo 2");

            DataRow dr;

            IList listItem = DataMaster.GetAll(typeof(MItem));
            MItem item;

            IList listStok;
            TStokCard stok;

            TTransaction trans;

            decimal t = 0;

            for (int i = 0; i < listItem.Count; i++)
            {
                item = (MItem)listItem[i];
                listStok = DataMaster.GetListEq(typeof(TStokCard), TStokCard.ColumnNames.ItemId, item.ItemId);

                t = 0;
                for (int j = 0; j < listStok.Count; j++)
                {
                    stok = (TStokCard)listStok[j];

                    trans = (TTransaction)DataMaster.GetObjectByProperty(typeof(TTransaction), TTransaction.ColumnNames.TransactionId, stok.TransactionId);

                    if (j == 0)
                    {
                        if (trans.TransactionStatus == ListOfTransaction.SalesVIP.ToString())
                        {
                            t = stok.StokCardSaldo - (stok.StokCardQuantity * 2);
                        }
                        else
                        {
                            t = stok.StokCardSaldo + (stok.StokCardQuantity * 2);
                        }

                    }
                    else
                    {
                        if (trans.TransactionStatus == ListOfTransaction.SalesVIP.ToString())
                        {
                            t = t - stok.StokCardQuantity;
                        }
                        else
                        {
                            t = t + stok.StokCardQuantity;
                        }
                    }

                    dr = dt.NewRow();
                    dr[0] = trans.TransactionId;
                    dr[1] = trans.TransactionFactur;
                    dr[2] = trans.TransactionStatus;
                    dr[3] = item.ItemId;
                    dr[4] = stok.StokCardStatus;
                    dr[5] = stok.StokCardQuantity;
                    dr[6] = stok.StokCardSaldo;
                    dr[7] = t;
                    dt.Rows.Add(dr);
                }
            }

            dataGridView1.DataSource = dt;
            dataGridView1.Show();
        }
    }
}