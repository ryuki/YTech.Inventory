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
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace BurtonSoftware.ThemeKit
{
  internal class ThemeTabElements
  {
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
  [ThemeKitControl("Tab", typeof(ThemeTabElements))]
  public class ThemeTab : ThemeContainerControl
  {
    public enum State { Normal = 0, Over = 1, Down = 2, Selected = 4 }

    private string text;

    internal Rectangle bounds;
    internal State state;

    internal int overfadeid;
    internal float overfadeprogress = 0f;

    internal int selectfadeid;
    internal float selectfadeprogress = 0f;

    internal ThemeTabElements theme = new ThemeTabElements();

    public ThemeTab(string Text)
    {
      this.text = Text;

      overfadeid = FadeScheduler.CreateFade(new EventHandler<FadeEventArgs>(this.FadeChanged), 0.2f, 0f, 1f);
      selectfadeid = FadeScheduler.CreateFade(new EventHandler<FadeEventArgs>(this.FadeChanged), 0.2f, 0f, 1f);
    }

    public ThemeTab() : this("") { }

    protected override void ControlStyleChanged()
    {
      theme = (ThemeTabElements)GetStyle();

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

    void FadeChanged(object sender, FadeEventArgs e)
    {
      if (e.FadeID == overfadeid)
        overfadeprogress = e.Progress;
      else
        selectfadeprogress = e.Progress;

      if (this.Parent is ThemeTabControl)
        ((ThemeTabControl)this.Parent).tabbar.Invalidate();
    }

    [Browsable(true)]
    public new string Text
    {
      get { return text; }
      set
      {
        text = value;

        if (this.Parent is ThemeTabControl)
        {
          ((ThemeTabControl)this.Parent).tabbar.Invalidate();
        }
      }
    }

    [Browsable(false)]
    public string TabText
    {
      get { return Text; }
      set { Text = value; }
    }

    protected override void DoPaint(PaintEventArgs e)
    {
      if (Width * Height <= 0)
        return;

      Rectangle r = this.ClientRectangle;
      r.Inflate(1, 1);
      ThemeKit.DrawOrFill(theme.NormalBackground, e.Graphics, r);

      if (bounds.Width > 0)
      {
        Rectangle linerect = new Rectangle(bounds.Left, -1, bounds.Width, 1);        
        ThemeKit.DrawOrFill(theme.NormalSelectedTabBorder, e.Graphics, linerect);
      }
    }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override DockStyle Dock
    {
      get
      {
        return base.Dock;
      }
      set
      {
        base.Dock = value;
      }
    }

    bool show = true;
    [DefaultValue(true)]
    public bool ShowTab
    {
      get { return show; }
      set
      { 
        show = value;

        if (this.Parent is ThemeTabControl)
        {
          ((ThemeTabControl)this.Parent).tabbar.Invalidate();
        }
      }
    }
  }

  public class ThemeTabCollection : List<ThemeTab>
  {
    private ThemeTabControl parent;

    public ThemeTabCollection(ThemeTabControl parent)
    {
      this.parent = parent;
    }

    public new void Add(ThemeTab Tab)
    {
      base.Add(Tab);
      parent.TabAdded(Tab);
    }

    public void Add(string Text)
    {
      this.Add(new ThemeTab(Text));
    }

    public new void Remove(ThemeTab Tab)
    {
      if (Tab == parent.SelectedTab)
      {
        if (parent.TabPages.Count > 1)
          parent.SelectedIndex = 0;
        else
          parent.SelectedIndex = -1;
      }

      base.Remove(Tab);

      parent.tabbar.Invalidate();
    }
  }
}