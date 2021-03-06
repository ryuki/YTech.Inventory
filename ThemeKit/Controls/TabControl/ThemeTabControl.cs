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
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using BurtonSoftware.UI;
using System.Collections.Specialized;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using BurtonSoftware.ThemeKit.Design;

namespace BurtonSoftware.ThemeKit
{
  internal class ThemeTabControlElements
  {
    public ExBrush[] NormalBackground = new ExBrush[0];

    public int LeftPadding = 0;
    public int TopPadding = 0;
    public int RightPadding = 0;
    public int BottomPadding = 0;
  }

  public enum TabChangeEffect { None, Fade }

  [DesignerAttribute(typeof(ThemeTabControlDesigner))]
  [ThemeKitControl("TabControl", typeof(ThemeTabControlElements))]
  [ToolboxItem(true)]
  public class ThemeTabControl : ThemeContainerControl
  {
    private ThemeTabCollection tabs;
    private int selectedindex;

    internal ThemeTabBar tabbar;

    public event EventHandler SelectedIndexChanged;
    public event EventHandler NavBtnForwardClicked;
    public event EventHandler NavBtnBackwardClicked;

    public new event EventHandler DoubleClick;

    internal bool customnavbtnenable;
    internal bool enablenavbtnback;
    internal bool enablenavbtnfwd;

    ThemeTabControlElements elements = new ThemeTabControlElements();

    public ThemeTabControl()
    {
      tabs = new ThemeTabCollection(this);

      tabbar = new ThemeTabBar(this);
      tabbar.Parent = this;
      tabbar.Height = 20;
      tabbar.Dock = DockStyle.Top;
      tabbar.Padding = new Padding(0, 0, 0, 0);
      tabbar.Margin = new Padding(0, 0, 0, 0);
      tabbar.Visible = true;

      this.Padding = new Padding(3, 3, 3, 3);
    }

    protected override void ControlStyleChanged()
    {
      elements = (ThemeTabControlElements)GetStyle();

      this.Padding = new Padding(elements.LeftPadding, elements.TopPadding, elements.RightPadding, elements.BottomPadding);
    }

    bool dsgnmode;
    internal new bool DesignMode
    {
      get { return dsgnmode; }
      set
      {
        dsgnmode = value;
        tabbar.DesignMode = value;
      }
    }

    public bool CustomNavButtonEnable
    {
      get { return customnavbtnenable; }
      set
      {
        customnavbtnenable = value;
        tabbar.Invalidate();
      }
    }

    public bool EnableForwardNav
    {
      get { return enablenavbtnfwd; }
      set
      {
        enablenavbtnfwd = value;
        tabbar.Invalidate();
      }
    }

    public bool EnableBackwardNav
    {
      get { return enablenavbtnback; }
      set
      {
        enablenavbtnback = value;
        tabbar.Invalidate();
      }
    }

    private TabChangeEffect tabchangeeffect = TabChangeEffect.None;
    public TabChangeEffect TabChangeEffect
    {
      get { return tabchangeeffect; }
      set { tabchangeeffect = value; }
    }

    protected override void DoPaint(PaintEventArgs e)
    {
      ThemeKit.DrawOrFill(elements.NormalBackground, e.Graphics, this.ClientRectangle);
    }

    public int SelectedIndex
    {
      get { return selectedindex; }
      set
      {
        selectedindex = value;
        ShowSelected();
        TriggerSelectedChanged();

        if (selectedindex < 0)
          return;

        if (selectedindex >= tabs.Count)
          return;

        tabs[selectedindex].overfadeprogress = 0f;
        tabs[selectedindex].state = ThemeTab.State.Normal;
      }
    }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ThemeTab SelectedTab
    {
      get
      {
        if (selectedindex < 0)
          return null;

        if (selectedindex >= tabs.Count)
          return null;

        return tabs[selectedindex];
      }
      set
      {
        SelectedIndex = tabs.IndexOf(value);
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ThemeTabCollection TabPages
    {
      get { return tabs; }
    }

    internal void TabAdded(ThemeTab Tab)
    {
      Tab.Parent = this;
      Tab.Dock = DockStyle.Fill;
      Tab.overfadeprogress = 0f;
      Tab.state = ThemeTab.State.Normal;

      tabbar.SendToBack();

      if (tabs.Count == 1)
      {
        SelectedIndex = 0;
        ShowSelected();
      }
    }

    void ShowSelected()
    {
      if (selectedindex < 0)
        return;

      if (selectedindex >= tabs.Count)
        return;

      ShowTab(tabs[selectedindex]);
    }

    void ShowTab(ThemeTab Tab)
    {
      tabbar.Invalidate();
      Application.DoEvents();

      LoadingTransition lt = null;
      if ((this.selectedindex > -1) && (this.TopLevelControl != null))
      {
        lt = new LoadingTransition();
        lt.Bounds = this.RectangleToScreen(this.SelectedTab.Bounds);
        lt.Show();
      }

      Tab.Dock = DockStyle.Fill;
      Tab.Width--;
      Tab.Visible = true;

      tabbar.SendToBack();

      foreach (ThemeTab tab in tabs)
      {
        tab.Visible = (tab == Tab);
      }

      if (lt != null)
      {
        lt.DisposeOnHide = true;

        if (tabchangeeffect == TabChangeEffect.Fade)
          lt.Fade();
        else if (tabchangeeffect == TabChangeEffect.None)
          lt.Hide();
      }
    }

    protected override void OnVisibleChanged(EventArgs e)
    {
      tabbar.Invalidate();

      base.OnVisibleChanged(e);
    }

    internal void TriggerSelectedChanged()
    {
      if (SelectedIndexChanged != null)
        SelectedIndexChanged(this, EventArgs.Empty);
    }

    internal void TriggerDoubleClick()
    {
      if (this.DoubleClick != null)
        this.DoubleClick(this, EventArgs.Empty);
    }

    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);
    }

    protected override void OnControlAdded(ControlEventArgs e)
    {
      if ((e.Control is ThemeTab || e.Control is ThemeLabelTab) && !tabs.Contains((ThemeTab)e.Control))
        tabs.Add((ThemeTab)e.Control);

      base.OnControlAdded(e);
    }

    protected override void OnControlRemoved(ControlEventArgs e)
    {
      if ((e.Control is ThemeTab || e.Control is ThemeLabelTab) && tabs.Contains((ThemeTab)e.Control))
        tabs.Remove((ThemeTab)e.Control);

      base.OnControlRemoved(e);
    }

    internal bool TriggerNavBtnFwdEvent()
    {
      if (NavBtnForwardClicked != null)
      {
        NavBtnForwardClicked(this, EventArgs.Empty);
        return true;
      }

      return false;
    }

    internal bool TriggerNavBtnBackEvent()
    {
      if (NavBtnBackwardClicked != null)
      {
        NavBtnBackwardClicked(this, EventArgs.Empty);
        return true;
      }

      return false;
    }
  }

  internal class ThemeTabBarElements
  {
    public ExBrush[] NormalBackground = new ExBrush[0];

    public ExBrush[] NavButtonBackDisabled = new ExBrush[0];
    public ExBrush[] NavButtonBackNormal = new ExBrush[0];
    public ExBrush[] NavButtonBackOver = new ExBrush[0];

    public ExBrush[] NavButtonForwardDisabled = new ExBrush[0];
    public ExBrush[] NavButtonForwardNormal = new ExBrush[0];
    public ExBrush[] NavButtonForwardOver = new ExBrush[0];

    public bool AllowFormDrag = false;
    public int TabXOffset = 0;
    public int TabYOffset = 0;
    public int TabSpacing = 0;
    public int TabBarHeight = 20;

    public bool NavButtonBack = false;
    public int NavButtonBackX = -100;
    public int NavButtonBackY = -100;
    public int NavButtonBackW = 10;
    public int NavButtonBackH = 10;

    public bool NavButtonForward = false;
    public int NavButtonForwardX = -100;
    public int NavButtonForwardY = -100;
    public int NavButtonForwardW = 10;
    public int NavButtonForwardH = 10;

    public bool CloseButton = false;
    public int CloseButtonX = -100;
    public int CloseButtonY = -100;
    public int CloseButtonW = 10;
    public int CloseButtonH = 10;

    public bool MaximizeButton = false;
    public int MaximizeButtonX = -100;
    public int MaximizeButtonY = -100;
    public int MaximizeButtonW = 10;
    public int MaximizeButtonH = 10;

    public bool MinimizeButton = false;
    public int MinimizeButtonX = -100;
    public int MinimizeButtonY = -100;
    public int MinimizeButtonW = 10;
    public int MinimizeButtonH = 10;

    public bool NavButtonOverFade = false;
    public float NavButtonOverFadeMin = 0f;
    public float NavButtonOverFadeMax = 0f;
    public int NavButtonOverFadeSteps = 1;

    public Rectangle NavButtonBackRect() { return new Rectangle(NavButtonBackX, NavButtonBackY, NavButtonBackW, NavButtonBackH); }
    public Rectangle NavButtonForwardRect() { return new Rectangle(NavButtonForwardX, NavButtonForwardY, NavButtonForwardW, NavButtonForwardH); }

    public Rectangle CloseButtonRect(Rectangle bounds)
    {
      int x = CloseButtonX;
      int y = CloseButtonY;

      if (x < 0)
        x = bounds.Right + x;
      if (y < 0)
        y = bounds.Bottom + y;

      return new Rectangle(x, y, CloseButtonW, CloseButtonH); 
    }

    public Rectangle MaximizeButtonRect(Rectangle bounds)
    {
      int x = MaximizeButtonX;
      int y = MaximizeButtonY;

      if (x < 0)
        x = bounds.Right + x;
      if (y < 0)
        y = bounds.Bottom + y;

      return new Rectangle(x, y, MaximizeButtonW, MaximizeButtonH);
    }

    public Rectangle MinimizeButtonRect(Rectangle bounds)
    {
      int x = MinimizeButtonX;
      int y = MinimizeButtonY;

      if (x < 0)
        x = bounds.Right + x;
      if (y < 0)
        y = bounds.Bottom + y;

      return new Rectangle(x, y, MinimizeButtonW, MinimizeButtonH);
    }
  }

  [ThemeKitControl("TabBar", typeof(ThemeTabBarElements))]
  internal class ThemeTabBar : ThemeControl
  {
    private ThemeTabControl parent;

    int hoverindex = -1;

    bool mousedown;

    private ThemeCaptionButton btnclose;
    private ThemeCaptionButton btnmin;
    private ThemeCaptionButton btnmax;

    bool navbtnbackenabled;
    bool navbtnfwdenabled;

    float navbtnfwdoverfadeprogress;
    float navbtnbackoverfadeprogress;

    int navbtnbackoverfadeid;
    int navbtnfwdoverfadeid;

    ThemeTabBarElements elements = new ThemeTabBarElements();

    public ThemeTabBar(ThemeTabControl parent)
    {
      this.parent = parent;

      this.Margin = new Padding(0, 0, 0, 0);

      btnclose = new ThemeCaptionButton(ThemeCaptionButton.CapBtnType.Close, this);
      btnclose.Parent = this;
      btnclose.Visible = false;

      btnmax = new ThemeCaptionButton(ThemeCaptionButton.CapBtnType.Maximize, this);
      btnmax.Parent = this;
      btnmax.Visible = false;

      btnmin = new ThemeCaptionButton(ThemeCaptionButton.CapBtnType.Minimize, this);
      btnmin.Parent = this;
      btnmin.Visible = false;


      navbtnbackoverfadeid = FadeScheduler.CreateFade(new EventHandler<FadeEventArgs>(this.FadeChanged), 1f, 0f, 1f);
      navbtnfwdoverfadeid = FadeScheduler.CreateFade(new EventHandler<FadeEventArgs>(this.FadeChanged), 1f, 0f, 1f);
    }

    void FadeChanged(object sender, FadeEventArgs e)
    {
      if (e.FadeID == navbtnbackoverfadeid)
        navbtnbackoverfadeprogress = e.Progress;
      else
        navbtnfwdoverfadeprogress = e.Progress;

      Invalidate();
    }

    protected override void ControlStyleChanged()
    {
      elements = (ThemeTabBarElements)GetStyle();

      if (!elements.NavButtonOverFade)
      {
        elements.NavButtonOverFadeMin = 0f;
        elements.NavButtonOverFadeMax = 1f;
        elements.NavButtonOverFadeSteps = 1;
        navbtnbackoverfadeprogress = 0f;
        navbtnfwdoverfadeprogress = 0f;
      }

      btnclose.Bounds = elements.CloseButtonRect(this.ClientRectangle);
      btnmax.Bounds = elements.MaximizeButtonRect(this.ClientRectangle);
      btnmin.Bounds = elements.MinimizeButtonRect(this.ClientRectangle);

      FadeScheduler.UpdateFade(navbtnbackoverfadeid, ((elements.NavButtonOverFadeMax - elements.NavButtonOverFadeMin) / elements.NavButtonOverFadeSteps), elements.NavButtonOverFadeMin, elements.NavButtonOverFadeMax);
      FadeScheduler.UpdateFade(navbtnfwdoverfadeid, ((elements.NavButtonOverFadeMax - elements.NavButtonOverFadeMin) / elements.NavButtonOverFadeSteps), elements.NavButtonOverFadeMin, elements.NavButtonOverFadeMax);
    }

    protected override void OnResize(EventArgs e)
    {
      btnclose.Bounds = elements.CloseButtonRect(this.ClientRectangle);
      btnmax.Bounds = elements.MaximizeButtonRect(this.ClientRectangle);
      btnmin.Bounds = elements.MinimizeButtonRect(this.ClientRectangle);

      base.OnResize(e);
    }

    bool dsgnmode;
    internal new bool DesignMode
    {
      get { return dsgnmode; }
      set
      {
        dsgnmode = value;
        btnclose.DesignMode = value;
        btnmax.DesignMode = value;
        btnmin.DesignMode = value;
      }
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      mousedown = true;

      if (!DesignMode && elements.AllowFormDrag && (hoverindex == parent.SelectedIndex || hoverindex == -1))
      {
        bool cancel = false;

        if (elements.NavButtonBack && navbtnbackenabled && elements.NavButtonBackRect().Contains(e.Location))
          cancel = true;

        if (elements.NavButtonForward && navbtnfwdenabled && elements.NavButtonForwardRect().Contains(e.Location))
          cancel = true;

        if (!DesignMode && elements.CloseButton && elements.CloseButtonRect(this.ClientRectangle).Contains(e.Location))
          cancel = true;

        if (!DesignMode && elements.MaximizeButton && elements.MaximizeButtonRect(this.ClientRectangle).Contains(e.Location))
          cancel = true;

        if (!DesignMode && elements.MinimizeButton && elements.MinimizeButtonRect(this.ClientRectangle).Contains(e.Location))
          cancel = true;

        if (!cancel)
        {
          Control c = this;

          while (c != null && !(c is Form))
            c = c.Parent;

          if (c != null && c is Form)
          {
            NativeMethods.ReleaseCapture();

            if ((e.Button & MouseButtons.Right) > 0)
              NativeMethods.SendMessage(c.Handle, (int)NativeMethods.WindowMessages.WM_NCRBUTTONDOWN, (IntPtr)NativeMethods.NCHITTEST.HTCAPTION, (IntPtr)0);
            else
              NativeMethods.SendMessage(c.Handle, (int)NativeMethods.WindowMessages.WM_NCLBUTTONDOWN, (IntPtr)NativeMethods.NCHITTEST.HTCAPTION, (IntPtr)0);
          }
        }
      }

      base.OnMouseDown(e);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      mousedown = false;

      base.OnMouseUp(e);
    }

    int mseposx = -10;
    int mseposy = -10;
    protected override void OnMouseMove(MouseEventArgs e)
    {
      mseposx = e.X;
      mseposy = e.Y;

      if (elements.NavButtonBack && elements.NavButtonBackRect().Contains(e.Location))
        FadeScheduler.SetFadeType(navbtnbackoverfadeid, FadeType.In);
      else
        FadeScheduler.SetFadeType(navbtnbackoverfadeid, FadeType.Out);

      if (elements.NavButtonForward && elements.NavButtonForwardRect().Contains(e.Location))
        FadeScheduler.SetFadeType(navbtnfwdoverfadeid, FadeType.In);
      else
        FadeScheduler.SetFadeType(navbtnfwdoverfadeid, FadeType.Out);

      hoverindex = -1;

      bool redraw = false;

      int index = 0;
      foreach (ThemeTab tab in parent.TabPages)
      {
        ThemeTab.State original = tab.state;

        tab.state = ThemeTab.State.Normal;

        Rectangle bounds = tab.bounds;
        if (bounds.Contains(e.Location))
        {
          hoverindex = index;
          tab.state |= ThemeTab.State.Over;

          if (mousedown)
            tab.state |= ThemeTab.State.Down;
        }

        if (index == parent.SelectedIndex)
          tab.state |= ThemeTab.State.Selected;

        redraw = redraw | (original != tab.state);

        if (((original & ThemeTab.State.Over) > 0) && !((tab.state & ThemeTab.State.Over) > 0))
          FadeScheduler.SetFadeType(tab.overfadeid, FadeType.Out);
        else if (!((original & ThemeTab.State.Over) > 0) && ((tab.state & ThemeTab.State.Over) > 0))
          FadeScheduler.SetFadeType(tab.overfadeid, FadeType.In);

        index++;
      }

      if (redraw)
        Invalidate();

      base.OnMouseMove(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
      OnMouseMove(new MouseEventArgs(MouseButtons.None, 0, -1, -1, 0));

      base.OnMouseLeave(e);
    }

    protected override void OnClick(EventArgs e)
    {
      if (hoverindex > -1 && hoverindex != parent.SelectedIndex)
      {
        parent.SelectedIndex = hoverindex;
      }

      if (elements.NavButtonBack && navbtnbackenabled && elements.NavButtonBackRect().Contains(mseposx, mseposy))
      {
        if (!parent.TriggerNavBtnBackEvent())
        {
          parent.SelectedIndex--;
          Invalidate();
        }
      }

      if (elements.NavButtonForward && navbtnfwdenabled && elements.NavButtonForwardRect().Contains(mseposx, mseposy))
      {
        if (!parent.TriggerNavBtnFwdEvent())
        {
          parent.SelectedIndex++;
          Invalidate();
        }
      }

      base.OnClick(e);
    }

    protected override void OnDoubleClick(EventArgs e)
    {
      parent.TriggerDoubleClick();

      if (!DesignMode && elements.MaximizeButton)
      {
        Control c = this;

        while (c != null && !(c is Form))
          c = c.Parent;

        if (c != null && c is Form)
        {
          if (((Form)c).MaximizeBox)
          {
            if (((Form)c).WindowState == FormWindowState.Maximized)
              NativeMethods.SendMessage(c.Handle, (int)NativeMethods.WindowMessages.WM_SYSCOMMAND, (IntPtr)NativeMethods.SystemCommands.SC_RESTORE, IntPtr.Zero);
            else
              NativeMethods.SendMessage(c.Handle, (int)NativeMethods.WindowMessages.WM_SYSCOMMAND, (IntPtr)NativeMethods.SystemCommands.SC_MAXIMIZE, IntPtr.Zero);
          }
        }
      }

      base.OnDoubleClick(e);
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
      base.OnPaintBackground(e);
      //ThemeKit.DrawOrFill(elements.NormalBackground, e.Graphics, this.ClientRectangle);
    }

    protected override void DoPaint(PaintEventArgs e)
    {
      this.Height = elements.TabBarHeight;

      RecalculateTabBounds();

      if (parent.customnavbtnenable)
      {
        navbtnbackenabled = parent.enablenavbtnback;
        navbtnfwdenabled = parent.enablenavbtnfwd;
      }
      else
      {
        navbtnbackenabled = parent.SelectedIndex > 0;
        navbtnfwdenabled = parent.SelectedIndex < (parent.TabPages.Count - 1);
      }

      Rectangle r = e.ClipRectangle;
      r.Offset(-1, -1);
      r.Width++;
      r.Height++;
      ThemeKit.DrawOrFill(elements.NormalBackground, e.Graphics, r);

      if (elements.NavButtonBack)
      {
        if (!navbtnbackenabled)
          ThemeKit.DrawOrFill(elements.NavButtonBackDisabled, e.Graphics, elements.NavButtonBackRect());
        else
        {
          ThemeKit.DrawOrFill(elements.NavButtonBackNormal, e.Graphics, elements.NavButtonBackRect());
          ThemeKit.DrawOrFill(elements.NavButtonBackOver, e.Graphics, elements.NavButtonBackRect(), navbtnbackoverfadeprogress);
        }
      }

      if (elements.NavButtonForward)
      {
        if (!navbtnfwdenabled)
          ThemeKit.DrawOrFill(elements.NavButtonForwardDisabled, e.Graphics, elements.NavButtonForwardRect());
        else
        {
          ThemeKit.DrawOrFill(elements.NavButtonForwardNormal, e.Graphics, elements.NavButtonForwardRect());
          ThemeKit.DrawOrFill(elements.NavButtonForwardOver, e.Graphics, elements.NavButtonForwardRect(), navbtnfwdoverfadeprogress);
        }
      }

      foreach (ThemeTab tab in parent.TabPages)
      {
        if (!tab.ShowTab)
          continue;

        tab.CheckStyle();

        Rectangle tabrect = tab.bounds;

        if (tab is ThemeLabelTab)
        {
          ThemeLabelTab ltab = (ThemeLabelTab)tab;

          object[] atts = ltab.GetType().GetCustomAttributes(typeof(ThemeKitControl), false);

          ThemeKit.DrawOrFill(ltab.theme.NormalTab, e.Graphics, tabrect);
          ThemeKit.DrawOrFill(ltab.theme.OverTab, e.Graphics, tabrect, ltab.overfadeprogress);

          if ((ltab.state & ThemeTab.State.Selected) > 0)
            ThemeKit.DrawOrFill(ltab.theme.SelectedTab, e.Graphics, tabrect);

          ThemeKit.DrawContent(ltab.TabText, null, ContentAlignment.MiddleCenter, ContentAlignment.MiddleCenter, ltab.theme.NormalTabText, e.Graphics, tabrect, ltab.Font);
          ThemeKit.DrawContent(ltab.TabText, null, ContentAlignment.MiddleCenter, ContentAlignment.MiddleCenter, ltab.theme.OverTabText, e.Graphics, tabrect, ltab.Font, ltab.overfadeprogress);

          if ((ltab.state & ThemeTab.State.Selected) > 0)
            ThemeKit.DrawContent(ltab.TabText, null, ContentAlignment.MiddleCenter, ContentAlignment.MiddleCenter, ltab.theme.SelectedTabText, e.Graphics, tabrect, ltab.Font);
        }
        else
        {
          ThemeKit.DrawOrFill(tab.theme.NormalTab, e.Graphics, tabrect);
          ThemeKit.DrawOrFill(tab.theme.OverTab, e.Graphics, tabrect, tab.overfadeprogress);

          if ((tab.state & ThemeTab.State.Selected) > 0)
            ThemeKit.DrawOrFill(tab.theme.SelectedTab, e.Graphics, tabrect);

          ThemeKit.DrawContent(tab.TabText, null, ContentAlignment.MiddleCenter, ContentAlignment.MiddleCenter, tab.theme.NormalTabText, e.Graphics, tabrect, tab.Font);
          ThemeKit.DrawContent(tab.TabText, null, ContentAlignment.MiddleCenter, ContentAlignment.MiddleCenter, tab.theme.OverTabText, e.Graphics, tabrect, tab.Font, tab.overfadeprogress);

          if ((tab.state & ThemeTab.State.Selected) > 0)
            ThemeKit.DrawContent(tab.TabText, null, ContentAlignment.MiddleCenter, ContentAlignment.MiddleCenter, tab.theme.SelectedTabText, e.Graphics, tabrect, tab.Font);
        }
      }

      if (elements.CloseButton)
      {
        bool closebtnenabled = false;

        Control c = this;

        while (c != null && !(c is Form))
          c = c.Parent;

        if (c != null && c is Form && ((Form)c).ControlBox)
          closebtnenabled = true;

        btnclose.Enabled = closebtnenabled;
      }
      btnclose.Visible = elements.CloseButton;

      if (elements.MaximizeButton)
      {
        bool maxbtnenabled = false;

        Control c = this;

        while (c != null && !(c is Form))
          c = c.Parent;

        if (c != null && c is Form && ((Form)c).MaximizeBox)
          maxbtnenabled = true;

        btnmax.Enabled = maxbtnenabled;
      }
      btnmax.Visible = elements.MaximizeButton;

      if (elements.MinimizeButton)
      {
        bool minbtnenabled = false;

        Control c = this;

        while (c != null && !(c is Form))
          c = c.Parent;

        if (c != null && c is Form && ((Form)c).MinimizeBox)
          minbtnenabled = true;

        btnmin.Enabled = minbtnenabled;
      }
      btnmin.Visible = elements.MinimizeButton;
    }

    internal void RecalculateTabBounds()
    {
      int x = elements.TabXOffset;

      foreach (ThemeTab tab in parent.TabPages)
      {
        if (!tab.ShowTab)
        {
          tab.bounds = new Rectangle(-100, -100, 10, 10);
          continue;
        }

        int w = TextRenderer.MeasureText(tab.Text, tab.Font).Width + 15;

        Rectangle newbounds = new Rectangle(x, elements.TabYOffset, w, this.Height - elements.TabYOffset);

        if (tab.bounds != newbounds)
        {
          tab.bounds = newbounds;

          if ((tab.state & ThemeTab.State.Selected) > 0)
            tab.Invalidate();
        }

        x += w + elements.TabSpacing;
      }

      Point mp = this.PointToClient(Cursor.Position);
      OnMouseMove(new MouseEventArgs(MouseButtons.None, 0, mp.X, mp.Y, 0));
    }

    internal bool DisallowDesignerClick(Point p)
    {
      if (elements.CloseButton && elements.CloseButtonRect(this.ClientRectangle).Contains(p))
        return true;
      if (elements.MaximizeButton && elements.MaximizeButtonRect(this.ClientRectangle).Contains(p))
        return true;
      if (elements.MinimizeButton && elements.MinimizeButtonRect(this.ClientRectangle).Contains(p))
        return true;

      return false;
    }
  }
}