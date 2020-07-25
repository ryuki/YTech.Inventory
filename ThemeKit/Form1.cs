using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BurtonSoftware.ThemeKit;

namespace ThemeKitTest
{
  public partial class Form1 : ThemeForm
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void Form2_Load(object sender, EventArgs e)
    {

    }

    private void themeButton1_Click(object sender, EventArgs e)
    {
      using (OpenFileDialog ofd = new OpenFileDialog())
      {
        ofd.Filter = "Themes|*.thm";

        if (ofd.ShowDialog() == DialogResult.OK)
          this.LoadTheme(ofd.FileName);
      }
    }

    private void themeListBox1_DoubleClick(object sender, EventArgs e)
    {
      MessageBox.Show(themeListBox1.Items[themeListBox1.SelectedIndex].ToString());
    }

    private void themeProgressBar1_MouseClick(object sender, MouseEventArgs e)
    {
      float percent = ((float)e.X / (float)themeProgressBar1.Width) * 100;
      themeLabel2.Text = ((int)percent).ToString() + "%";
      themeProgressBar1.Value = (int)((themeProgressBar1.Maximum - themeProgressBar1.Minimum) * (percent / 100)) + themeProgressBar1.Minimum;
    }
  }
}