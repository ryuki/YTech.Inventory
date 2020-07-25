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
using Inventori.Forms;
using Inventori.Data;

namespace Inventori.Cafe.Forms
{
    public partial class FormDeleteTransaction : FormParentForCafe
    {
        DataMasterMgtServices DataMaster = new DataMasterMgtServices();
        public FormDeleteTransaction()
        {
            InitializeComponent();
            //set datetime picker
            ModuleControlSettings.SetDateTimePicker(dt_From, true);
            ModuleControlSettings.SetDateTimePicker(dt_To, true);

            buttonOK.Click += new EventHandler(buttonOK_Click);

            TabText = Text;
        }

        void buttonOK_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Anda yakin menghapus transaksi penjualan?", "Konfirmasi hapus transaksi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;

            //if (dt_To.Value > DateTime.Today.AddDays(-2))
            //{
            //    MessageBox.Show("Transaksi yang boleh dihapus adalah minimal H-2.", "Hapus Transaksi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            DeleteTransaction(dt_From.Value, dt_To.Value);
        }

        private void DeleteTransaction(DateTime from, DateTime to)
        {
            NHibernate.Expression.ICriterion[] expArrays = new NHibernate.Expression.ICriterion[2];
            expArrays[0] = NHibernate.Expression.Expression.Or(NHibernate.Expression.Expression.Eq(TTransaction.ColumnNames.TransactionStatus, ListOfTransaction.Sales.ToString()), NHibernate.Expression.Expression.Eq(TTransaction.ColumnNames.TransactionStatus, ListOfTransaction.SalesVIP.ToString()));
            expArrays[1] = NHibernate.Expression.Expression.Between(TTransaction.ColumnNames.TransactionDate, from, to);

            IList list = DataMaster.GetList(typeof(TTransaction), expArrays, null);
            TTransaction t;
            TTransactionDetail det;

            for (int i = 0; i < list.Count; i++)
            {
                t = (TTransaction)list[i];
                IList listDet = DataMaster.GetListEq(typeof(TTransactionDetail), TTransactionDetail.ColumnNames.TransactionId, t.TransactionId);
                for (int j = 0; j < listDet.Count; j++)
                {
                    det = (TTransactionDetail)listDet[j];
                    DataMaster.Delete(det);
                }
                DataMaster.Delete(t);
            }
            MessageBox.Show("Transaksi Berhasil dihapus", "Hapus Transaksi Berhasil.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            groupBox1.Enabled = false;
        }

        private void FormDeleteTransaction_Load(object sender, EventArgs e)
        {
            DateTime to = ModuleControlSettings.GetMaksDateTransactionClosing();
            dt_From.Value = to.AddDays(-7);
            dt_To.Value = to;
        }
    }
}
