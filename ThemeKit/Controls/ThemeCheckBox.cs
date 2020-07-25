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
using System.Drawing.Design;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace BurtonSoftware.ThemeKit
{
  internal class ThemeCheckBoxElements
  {
    public ExBrush[] NormalUncheckedBackground = new ExBrush[0];
    public ExBrush[] NormalUncheckedBox = new ExBrush[0];
    public ExBrush[] NormalUncheckedText = new ExBrush[0];

    public ExBrush[] NormalCheckedBackground = new ExBrush[0];
    public ExBrush[] NormalCheckedBox = new ExBrush[0];
    public ExBrush[] NormalCheckedText = new ExBrush[0];

    public ExBrush[] OverUncheckedBackground = new ExBrush[0];
    public ExBrush[] OverUncheckedBox = new ExBrush[0];
    public ExBrush[] OverUncheckedText = new ExBrush[0];

    public ExBrush[] OverCheckedBackground = new ExBrush[0];
    public ExBrush[] OverCheckedBox = new ExBrush[0];
    public ExBrush[] OverCheckedText = new ExBrush[0];

    public ExBrush[] DisabledUncheckedBackground = new ExBrush[0];
    public ExBrush[] DisabledUncheckedBox = new ExBrush[0];
    public ExBrush[] DisabledUncheckedText = new ExBrush[0];

    public ExBrush[] DisabledCheckedBackground = new ExBrush[0];
    public ExBrush[] DisabledCheckedBox = new ExBrush[0];
    public ExBrush[] DisabledCheckedText = new ExBrush[0];

    public int BoxWidth = 15;
    public int BoxHeight = 15;
  }

  [ToolboxItem(true)]
  [ThemeKitControl("CheckBox", typeof(ThemeCheckBoxElements))]
  public class ThemeCheckBox: ThemeControl
  {
    private ThemeCheckBoxElements theme = new ThemeCheckBoxElements();

    bool mouseover;
    bool check;
    string text;

    public ThemeCheckBox()
    {

    }

    protected override Size DefaultSize
    {
      get { return new Size(150, 17); }
    }

    protected override void ControlStyleChanged()
    {
      theme = (ThemeCheckBoxElements)GetStyle();
    }

    protected override void DoPaint(PaintEventArgs e)
    {
      Rectangle rect = e.ClipRectangle;
      Rectangle boxrect = new Rectangle(rect.Left, rect.Top + ((rect.Height - theme.BoxHeight) / 2), theme.BoxWidth, theme.BoxHeight);
      Rectangle textrect = new Rectangle(boxrect.Right, rect.Top, rect.Width - boxrect.Width, rect.Height);

      Font fnt = SystemFonts.DefaultFont;

      if (!this.Enabled)
      {
        if (check)
        {
          ThemeKit.DrawOrFill(theme.DisabledCheckedBackground, e.Graphics, rect);
          ThemeKit.DrawOrFill(theme.DisabledCheckedBox, e.Graphics, boxrect);
          ThemeKit.DrawContent(text, null, ContentAlignment.MiddleLeft, ContentAlignment.TopLeft, theme.DisabledCheckedText, e.Graphics, textrect, fnt);
        }
        else
        {
          ThemeKit.DrawOrFill(theme.DisabledUncheckedBackground, e.Graphics, rect);
          ThemeKit.DrawOrFill(theme.DisabledUncheckedBox, e.Graphics, boxrect);
          ThemeKit.DrawContent(text, null, ContentAlignment.MiddleLeft, ContentAlignment.TopLeft, theme.DisabledUncheckedText, e.Graphics, textrect, fnt);
        }
      }
      else
      {
        if (mouseover)
        {
          if (check)
          {
            ThemeKit.DrawOrFill(theme.OverCheckedBackground, e.Graphics, rect);
            ThemeKit.DrawOrFill(theme.OverCheckedBox, e.Graphics, boxrect);
            ThemeKit.DrawContent(text, null, ContentAlignment.MiddleLeft, ContentAlignment.TopLeft, theme.OverCheckedText, e.Graphics, textrect, fnt);
          }
          else
          {
            ThemeKit.DrawOrFill(theme.OverUncheckedBackground, e.Graphics, rect);
            ThemeKit.DrawOrFill(theme.OverUncheckedBox, e.Graphics, boxrect);
            ThemeKit.DrawContent(text, null, ContentAlignment.MiddleLeft, ContentAlignment.TopLeft, theme.OverUncheckedText, e.Graphics, textrect, fnt);
          }
        }
        else
        {
          if (check)
          {
            ThemeKit.DrawOrFill(theme.NormalCheckedBackground, e.Graphics, rect);
            ThemeKit.DrawOrFill(theme.NormalCheckedBox, e.Graphics, boxrect);
            ThemeKit.DrawContent(text, null, ContentAlignment.MiddleLeft, ContentAlignment.TopLeft, theme.NormalCheckedText, e.Graphics, textrect, fnt);
          }
          else
          {
            ThemeKit.DrawOrFill(theme.NormalUncheckedBackground, e.Graphics, rect);
            ThemeKit.DrawOrFill(theme.NormalUncheckedBox, e.Graphics, boxrect);
            ThemeKit.DrawContent(text, null, ContentAlignment.MiddleLeft, ContentAlignment.TopLeft, theme.NormalUncheckedText, e.Graphics, textrect, fnt);
          }
        }
      }

    }

    protected override void OnMouseEnter(EventArgs e)
    {
      mouseover = true;
      Invalidate();

      base.OnMouseEnter(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
      mouseover = false;
      Invalidate();

      base.OnMouseLeave(e);
    }

    protected override void OnClick(EventArgs e)
    {
      check = !check;
      Invalidate();

      base.OnClick(e);
    }

    public bool Checked
    {
      get { return check; }
      set
      {
        check = value;
        Invalidate();
      }
    }

    public override string Text
    {
      get { return text; }
      set
      {
        text = value;
        Invalidate();
      }
    }
  }
}
