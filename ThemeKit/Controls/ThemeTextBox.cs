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
using BurtonSoftware.UI;
using System.Drawing.Imaging;
using System.Drawing.Design;
using System.ComponentModel;

namespace BurtonSoftware.ThemeKit
{
  internal class ThemeTextBoxElements
  {
    public ExBrush[] NormalBorder = new ExBrush[0];
    public ExBrush[] OverBorder = new ExBrush[0];
    public ExBrush[] DownBorder = new ExBrush[0];

    public ExBrush[] NormalBackground = new ExBrush[0];
    public ExBrush[] OverBackground = new ExBrush[0];
    public ExBrush[] DownBackground = new ExBrush[0];

    public ExBrush[] NormalText = new ExBrush[0];
    public ExBrush[] OverText = new ExBrush[0];
    public ExBrush[] DownText = new ExBrush[0];

    public int LeftBorder = 1;
    public int TopBorder = 1;
    public int RightBorder = 1;
    public int BottomBorder = 1;
  }

  [ThemeKitControl("TextBox", typeof(ThemeTextBoxElements))]
  [ToolboxItem(true)]
  public class ThemeTextBox : ThemeControl
  {
    ThemeTextBoxElements theme = new ThemeTextBoxElements();

    TextBox tb;

    public ThemeTextBox()
    {
      tb = new TextBox();
      tb.BorderStyle = BorderStyle.None;
      tb.Parent = this;

      this.Width = tb.Width + theme.LeftBorder + theme.RightBorder;
      this.Height = tb.Height + theme.TopBorder + theme.BottomBorder;
    }

    [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
    public override string Text
    {
      get { return tb.Text; }
      set { tb.Text = value; }
    }

    public new Font Font
    {
      get { return tb.Font; }
      set { tb.Font = value; }
    }

    public bool Multiline
    {
      get { return tb.Multiline; }
      set { tb.Multiline = value; }
    }

    public bool WordWrap
    {
      get { return tb.WordWrap; }
      set { tb.WordWrap = value; }
    }

    public ScrollBars ScrollBars
    {
      get { return tb.ScrollBars; }
      set { tb.ScrollBars = value; }
    }

    protected override void ControlStyleChanged()
    {
      theme = (ThemeTextBoxElements)GetStyle();
      OnResize(EventArgs.Empty);
    }

    protected override void DoPaint(PaintEventArgs e)
    {
      if (theme.NormalText.Length > 0 && theme.NormalText[0].Colors.Length > 0)
        tb.ForeColor = theme.NormalText[0].Colors[0];

      if (theme.NormalBackground.Length > 0 && theme.NormalBackground[0].Colors.Length > 0)
        tb.ForeColor = theme.NormalText[0].Colors[0];

      e.Graphics.FillRectangle(new SolidBrush(tb.BackColor), e.ClipRectangle);

      ThemeKit.DrawOrFill(theme.NormalBorder, e.Graphics, e.ClipRectangle);

    }

    protected override void OnResize(EventArgs e)
    {
      NativeMethods.LockWindowUpdate(tb.Handle);

      tb.Left = theme.LeftBorder;
      tb.Top = theme.TopBorder;
      tb.Width = this.Width - theme.LeftBorder - theme.RightBorder;
      tb.Height = this.Height - theme.TopBorder - theme.BottomBorder;

      NativeMethods.LockWindowUpdate(IntPtr.Zero);

      base.OnResize(e);
    }
  }
}
