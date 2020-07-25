using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Inventori.Forms
{
    public partial class FormSetting : Inventori.Forms.FormParentForToolsForm
    {
        public FormSetting()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.setting1;

            Inventori.Module.ModuleControlSettings.SetDateTimePicker(companyPkpDateDateTimePicker, false);
        }

        private void button_ChangeLogo_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    companyLogoPictureBox.Image = Image.FromFile(openFileDialog1.FileName);
                    label_ImageLogoLocation.Text = openFileDialog1.FileName;
                }
                catch (OutOfMemoryException)
                {
                    MessageBox.Show("Pastikan file yang anda pilih adalah gambar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }
    }
}

