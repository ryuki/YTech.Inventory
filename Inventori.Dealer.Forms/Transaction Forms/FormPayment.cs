using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Inventori.Data;
using System.Collections;

namespace Inventori.Dealer.Forms
{
    public partial class FormPayment : Inventori.Dealer.Forms.FormParentForDealer
    {
        public FormPayment()
        {
            InitializeComponent();

            this.Load += new EventHandler(FormPayment_Load);
            financeIdComboBox.SelectedIndexChanged += new EventHandler(financeIdComboBox_SelectedIndexChanged);
            tTransactionBindingSource.CurrentChanged += new EventHandler(tTransactionBindingSource_CurrentChanged);
            SaveButton.Click += new EventHandler(SaveButton_Click);
        }

        void SaveButton_Click(object sender, EventArgs e)
        {
            SavePayment();
            UpdateTransaction();
            financeIdComboBox_SelectedIndexChanged(null, null);
            MessageBox.Show("Pembayaran piutang finance berhasil disimpan.", AppCode.AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetPayment();
        }

        private void ResetPayment()
        {
            paymentDescTextBox.ResetText();
            paymentDateDateTimePicker.Value = DateTime.Today;
            paymentAmmountNumericUpDown.Value = decimal.Zero;
        }

        private void SavePayment()
        {
            TPayment p = new TPayment();
            p.FinanceId = financeIdComboBox.SelectedValue.ToString();
            p.ModifiedBy = lbl_UserName.Text;
            p.ModifiedDate = DateTime.Now;
            p.PaymentAmmount = paymentAmmountNumericUpDown.Value;
            p.PaymentDate = paymentDateDateTimePicker.Value;
            p.PaymentDesc = paymentDescTextBox.Text;
            p.PaymentId = Guid.NewGuid().ToString();
            p.TransactionId = transactionIdTextBox.Text;
            DataMaster.SavePersistence(p);
        }

        private void UpdateTransaction()
        {
            if (tTransactionBindingSource.Current != null)
            {
                TTransaction t = (tTransactionBindingSource.Current as TTransaction);
                t.TransactionPpn = t.TransactionSisa - paymentAmmountNumericUpDown.Value;
                DataMaster.UpdatePersistence(t);
            }
        }

        void tTransactionBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (tTransactionBindingSource.Current != null)
            {
                transactionIdTextBox.Text = (tTransactionBindingSource.Current as TTransaction).TransactionId.ToString();
                transactionPpnLabel1.Text = (tTransactionBindingSource.Current as TTransaction).TransactionPpn.ToString("N");
                SaveButton.Enabled = true;
            }
            else
            {
                ResetPayment();
                SaveButton.Enabled = false;
            }
        }

        void financeIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            IList list = new List<TTransaction>();
            if (financeIdComboBox.SelectedIndex != 0)
            {
                NHibernate.Expression.ICriterion[] expArrays = new NHibernate.Expression.ICriterion[3];
                expArrays[0] = NHibernate.Expression.Expression.Eq(TTransaction.ColumnNames.TransactionDesc2, financeIdComboBox.SelectedValue.ToString());

                expArrays[1] = NHibernate.Expression.Expression.Eq(TTransaction.ColumnNames.TransactionStatus, ListOfTransaction.Sales.ToString());

                //sisa utang tidak nol
                expArrays[2] = NHibernate.Expression.Expression.Not(NHibernate.Expression.Expression.Eq(TTransaction.ColumnNames.TransactionPpn, decimal.Zero));

                NHibernate.Expression.Order[] orderArrays = new NHibernate.Expression.Order[1];
                orderArrays[0] = NHibernate.Expression.Order.Asc(TTransaction.ColumnNames.TransactionDate);

                list = DataMaster.GetList(typeof(TTransaction), expArrays, orderArrays);
                for (int i = 0; i < list.Count; i++)
                {
                    TTransaction t = list[i] as TTransaction;
                    t.TransactionByName = AppCode.GetCustomerName(t.TransactionBy, true);
                }

            }
            tTransactionBindingSource.DataSource = list;
        }

        void FormPayment_Load(object sender, EventArgs e)
        {
            //finance
            AppCode.FillFinanceComboBox(financeIdComboBox);
            Module.ModuleControlSettings.SetDateTimePicker(paymentDateDateTimePicker, false);
            paymentDateDateTimePicker.Value = DateTime.Today;
            Module.ModuleControlSettings.SetNumericUpDown(paymentAmmountNumericUpDown, false, 0);
            Module.ModuleControlSettings.SetGridDataView(tTransactionDataGridView);

        }
    }
}