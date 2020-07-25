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
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace BurtonSoftware.ThemeKit
{
  internal class ThemeLabelPanelElements
  {
    public ExBrush[] NormalBackground = new ExBrush[0];

    public ExBrush[] NormalLabel = new ExBrush[0];
    public ExBrush[] NormalLabelBackground = new ExBrush[0];
  }

  [ThemeKitControl("LabelPanel", typeof(ThemeLabelPanelElements))]
  [ToolboxItem(true)]
  public class ThemeLabelPanel : ThemeContainerControl
  {
    public enum LabelPosition { Top, Left, Right, Bottom }

    private int labelsize = 15;
    private int labelpadding = 5;
    private LabelPosition labelpos = LabelPosition.Bottom;

    private ContentAlignment textalign = ContentAlignment.MiddleLeft;

    ThemeLabelPanelElements theme = new ThemeLabelPanelElements();

    public ThemeLabelPanel()
    {
      base.Font = new Font("Arial", 10);
    }

    protected override void ControlStyleChanged()
    {
      theme = (ThemeLabelPanelElements)GetStyle();
    }

    protected override void DoPaint(PaintEventArgs e)
    {
      if (Width * Height <= 0)
        return;

      Rectangle labelrect = new Rectangle();
      Rectangle rect = new Rectangle();

      switch (labelpos)
      {
        case LabelPosition.Top:
          labelrect = new Rectangle(0, 0, this.Width, labelsize);
          rect = new Rectangle(0, labelsize, this.Width, this.Height - labelsize);
          break;
        case LabelPosition.Bottom:
          labelrect = new Rectangle(0, this.Height - labelsize, this.Width, labelsize);
          rect = new Rectangle(0, 0, this.Width, this.Height - labelsize);
          break;
        case LabelPosition.Left:
          labelrect = new Rectangle(0, 0, labelsize, this.Height);
          rect = new Rectangle(labelsize, 0, this.Width - labelsize, this.Height);
          break;
        case LabelPosition.Right:
          labelrect = new Rectangle(this.Width - labelsize, 0, labelsize, this.Height);
          rect = new Rectangle(0, 0, this.Width - labelsize, this.Height);
          break;
      }

      ThemeKit.DrawOrFill(theme.NormalBackground, e.Graphics, rect);
      ThemeKit.DrawOrFill(theme.NormalLabelBackground, e.Graphics, labelrect);

      labelrect.Inflate(-labelpadding, -labelpadding);

      ThemeKit.DrawContent(this.Text, null, textalign, ContentAlignment.MiddleCenter, theme.NormalLabel, e.Graphics, labelrect, this.Font);
    }

    [Browsable(true)]
    public string LabelText
    {
      get
      {
        return base.Text;
      }
      set
      {
        base.Text = value;
        Invalidate();
      }
    }

    [Browsable(false)]
    public override string Text
    {
      get { return base.Text; }
      set { base.Text = value; }
    }

    [DefaultValue(15)]
    public int LabelSize
    {
      get { return labelsize; }
      set
      {
        labelsize = value;
        Invalidate();
      }
    }

    [DefaultValue(5)]
    public int LabelPadding
    {
      get { return labelpadding; }
      set
      {
        labelpadding = value;
        Invalidate();
      }
    }

    [DefaultValue(ThemeLabelPanel.LabelPosition.Bottom)]
    public LabelPosition LabelAlignment
    {
      get { return labelpos; }
      set
      {
        labelpos = value;
        Invalidate();
      }
    }

    public ContentAlignment TextAlign
    {
      get { return textalign; }
      set
      {
        textalign = value;
        Invalidate();
      }
    }
  }
}
