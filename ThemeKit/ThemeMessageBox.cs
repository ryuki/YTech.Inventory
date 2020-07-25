// ThemeKit
// Copyright (C) 2006 Paul Burton
//
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
//
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA
//
// E-Mail Contact: admin@burtonsoftware.co.uk

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BurtonSoftware.ThemeKit
{
  public static class ThemeMessageBox
  {
    public static DialogResult Show(string text)
    {
      if (ThemeKit.forms.Count == 0)
      {
        return MessageBox.Show(text);
      }

      ThemeForm form = new ThemeForm();
      form.Text = "Message";
      form.Theme = ThemeKit.forms[0].Theme;
      form.Style = "MessageBox";
      form.FormBorderStyle = FormBorderStyle.FixedSingle;
      form.StartPosition = FormStartPosition.CenterParent;
      form.MinimizeBox = false;
      form.MaximizeBox = false;

      ThemeLabel lbl = new ThemeLabel();
      lbl.Text = text;
      lbl.Left = 10;
      lbl.Top = 10;
      lbl.Visible = true;
      lbl.AutoSize = true;
      form.Controls.Add(lbl);
      lbl.Style = "MessageBox";

      ThemeButton btn = new ThemeButton();
      btn.Text = "OK";
      btn.Tag = DialogResult.OK;
      btn.Click += new EventHandler(btn_Click);
      btn.Visible = true;
      form.Controls.Add(btn);
      btn.Style = "MessageBox";

      form.ClientSize = new Size(lbl.Width + 20, lbl.Height + 20 + btn.Height + 10);

      btn.Top = form.ClientSize.Height - btn.Height - 10;
      btn.Left = form.ClientSize.Width - btn.Width - 10;

      form.ShowDialog();

      return DialogResult.OK;
    }

    static void btn_Click(object sender, EventArgs e)
    {
      ((ThemeForm)((ThemeButton)sender).Parent).Close();

    }
  }
}
