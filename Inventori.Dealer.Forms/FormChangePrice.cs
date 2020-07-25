using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Inventori.Data;
using System.Collections;
using Inventori.Module;
namespace Inventori.Dealer.Forms
{
    public partial class FormChangePrice : FormParentForDealer
    {
        public FormChangePrice()
        {
            InitializeComponent();

            ModuleControlSettings.SetNumericUpDown(itemPricePurchaseNumericUpDown, false);
            ModuleControlSettings.SetNumericUpDown(itemPriceMaxNumericUpDown, false);
            ModuleControlSettings.SetDateTimePicker(transactionDateFromDateTimePicker, false);
            ModuleControlSettings.SetDateTimePicker(transactionDateToDateTimePicker, false);
            transactionDateFromDateTimePicker.Value = DateTime.Today.AddDays(-30);
            transactionDateToDateTimePicker.Value = DateTime.Today.AddDays(-30);

            itemIdComboBox.SelectedIndexChanged += new EventHandler(itemIdComboBox_SelectedIndexChanged);
            button1.Click += new EventHandler(button1_Click);
        }

        void button1_Click(object sender, EventArgs e)
        {
            MItem i = itemIdComboBox.SelectedItem as MItem;
            if (i != null)
            {
                UpdatePrice(i.ItemId);
                BindData(i.ItemId);
            }

        }

        private void UpdatePrice(string ItemId)
        {
            NHibernate.Expression.ICriterion[] expArrays = new NHibernate.Expression.ICriterion[2];
            expArrays[0] = NHibernate.Expression.Expression.Between(TTransaction.ColumnNames.TransactionDate, transactionDateFromDateTimePicker.Value, transactionDateToDateTimePicker.Value.AddDays(1));
            expArrays[1] = NHibernate.Expression.Expression.Or(NHibernate.Expression.Expression.Eq(TTransaction.ColumnNames.TransactionStatus, ListOfTransaction.Sales.ToString()), NHibernate.Expression.Expression.Eq(TTransaction.ColumnNames.TransactionStatus, ListOfTransaction.Purchase.ToString()));

            IList listTrans = DataMaster.GetList(typeof(TTransaction), expArrays, null);
            IList listDet;
            IList listStock;
            TTransaction t;
            TTransactionDetail det;
            TStock stok;
            decimal total = decimal.Zero;
            for (int i = 0; i < listTrans.Count; i++)
            {
                t = listTrans[i] as TTransaction;
                total = decimal.Zero;

                listDet = DataMaster.GetListEq(typeof(TTransactionDetail), TTransactionDetail.ColumnNames.TransactionId, t.TransactionId, TTransactionDetail.ColumnNames.ItemId, ItemId);

                for (int j = 0; j < listDet.Count; j++)
                {
                    det = listDet[j] as TTransactionDetail;

                    if (t.TransactionStatus == ListOfTransaction.Sales.ToString())
                    {
                        det.Price = itemPriceMaxNumericUpDown.Value;
                        DataMaster.UpdatePersistence(det);
                        total += det.Price;
                    }
                    else if (true)
                    {
                        det.Price = itemPricePurchaseNumericUpDown.Value;
                        DataMaster.UpdatePersistence(det);
                        total += det.Price;
                    }

                    listStock = DataMaster.GetListEq(typeof(TStock), TStock.ColumnNames.StockId, det.StockId, TStock.ColumnNames.ItemId, ItemId);

                    for (int k = 0; k < listStock.Count; k++)
                    {
                        stok = listStock[k] as TStock;
                        if (t.TransactionStatus == ListOfTransaction.Sales.ToString())
                        {
                            stok.StockPriceIn = itemPriceMaxNumericUpDown.Value;
                        }
                        else if (true)
                        {
                            stok.StockPriceOut = itemPricePurchaseNumericUpDown.Value;
                        }
                    }
                }

                if (listDet.Count > 0)
                {
                    t.TransactionSubTotal = total;
                    t.TransactionGrandTotal = total;
                    if (t.TransactionPayment == ListOfPayment.Credit.ToString())
                    {
                        t.TransactionSisa = t.TransactionGrandTotal - t.TransactionPaid + t.TransactionPotongan;
                        t.TransactionPpn = t.TransactionGrandTotal - t.TransactionPaid + t.TransactionPotongan;
                    }
                }
            }

        }

        void itemIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemIdComboBox.SelectedIndex != 0)
            {
                MItem i = itemIdComboBox.SelectedItem as MItem;
                if (i != null)
                {
                    itemPriceMaxNumericUpDown.Value = i.ItemPriceMax;
                    itemPricePurchaseNumericUpDown.Value = i.ItemPricePurchase;
                    BindData(i.ItemId);
                }

            }
        }

        private void BindData(string ItemId)
        {
            IList list = DataMaster.GetListEq(typeof(TStock), TStock.ColumnNames.ItemId, ItemId);
            if (list.Count == 0)
            {
                tStockBindingSource.Clear();
            }
            else
                tStockBindingSource.DataSource = list;

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            AppCode.FillItemComboBox(itemIdComboBox);
        }
    }
}