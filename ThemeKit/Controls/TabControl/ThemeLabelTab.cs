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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BurtonSoftware.ThemeKit
{
  internal class ThemeLabelTabElements
  {
    public ExBrush[] NormalLabelBackground = new ExBrush[0];

    public ExBrush[] NormalLabelText = new ExBrush[0];

    public ExBrush[] NormalBackground = new ExBrush[0];
    public ExBrush[] NormalSelectedTabBorder = new ExBrush[0];

    public ExBrush[] NormalTab = new ExBrush[0];
    public ExBrush[] OverTab = new ExBrush[0];
    public ExBrush[] SelectedTab = new ExBrush[0];

    public ExBrush[] NormalTabText = new ExBrush[0];
    public ExBrush[] OverTabText = new ExBrush[0];
    public ExBrush[] SelectedTabText = new ExBrush[0];

    public bool OverFade = false;
    public float OverFadeMin = 0f;
    public float OverFadeMax = 1f;
    public int OverFadeSteps = 0;

    public bool SelectFade = false;
    public float SelectFadeMin = 0f;
    public float SelectFadeMax = 1f;
    public int SelectFadeSteps = 0;
  }

  [ToolboxItem(false)]
  [ThemeKitControl("LabelTab", typeof(ThemeLabelTabElements))]
  public class ThemeLabelTab: ThemeTab
  {
    public enum LabelPosition { Top, Left, Right, Bottom }

    private int labelsize = 15;
    private int labelpadding = 5;
    private LabelPosition labelpos = LabelPosition.Bottom;

    private ContentAlignment textalign = ContentAlignment.MiddleLeft;

    internal new ThemeLabelTabElements theme = new ThemeLabelTabElements();

    protected override void ControlStyleChanged()
    {
      theme = (ThemeLabelTabElements)GetStyle();

      if (!theme.OverFade)
      {
        theme.OverFadeMin = 0f;
        theme.OverFadeMax = 1f;
        theme.OverFadeSteps = 1;
        overfadeprogress = 0f;
      }

      if (!theme.SelectFade)
      {
        theme.SelectFadeMin = 0f;
        theme.SelectFadeMax = 1f;
        theme.SelectFadeSteps = 1;
        selectfadeprogress = 0f;
      }

      FadeScheduler.UpdateFade(overfadeid, ((theme.OverFadeMax - theme.OverFadeMin) / theme.OverFadeSteps), theme.OverFadeMin, theme.OverFadeMax);
      FadeScheduler.UpdateFade(selectfadeid, ((theme.SelectFadeMax - theme.SelectFadeMin) / theme.SelectFadeSteps), theme.SelectFadeMin, theme.SelectFadeMax);

      if (this.Parent is ThemeTabControl)
        ((ThemeTabControl)this.Parent).tabbar.Invalidate();
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

      ThemeKit.DrawContent(this.Text, null, textalign, ContentAlignment.MiddleCenter, theme.NormalLabelText, e.Graphics, labelrect, this.Font);
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

    public ContentAlignment LabelTextAlign
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
