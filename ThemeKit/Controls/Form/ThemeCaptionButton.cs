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
using BurtonSoftware.UI;

namespace BurtonSoftware.ThemeKit
{
  internal class ThemeCaptionButtonElements
  {
    public ExBrush[] CloseButtonDisabled = new ExBrush[0];
    public ExBrush[] CloseButtonNormal = new ExBrush[0];
    public ExBrush[] CloseButtonOver = new ExBrush[0];

    public ExBrush[] MinimizeButtonDisabled = new ExBrush[0];
    public ExBrush[] MinimizeButtonNormal = new ExBrush[0];
    public ExBrush[] MinimizeButtonOver = new ExBrush[0];

    public ExBrush[] MaximizeButtonDisabled = new ExBrush[0];
    public ExBrush[] MaximizeButtonNormal = new ExBrush[0];
    public ExBrush[] MaximizeButtonOver = new ExBrush[0];

    public bool OverFade = false;
    public float OverFadeMin = 0f;
    public float OverFadeMax = 1f;
    public int OverFadeSteps = 0;

    public bool DownFade = false;
    public float DownFadeMin = 0f;
    public float DownFadeMax = 1f;
    public int DownFadeSteps = 0;
  }

  [ToolboxItem(false)]
  [ThemeKitControl("CaptionButton", typeof(ThemeCaptionButtonElements))]
  internal class ThemeCaptionButton : ThemeControl
  {
    public enum CapBtnType { Close, Minimize, Maximize }

    protected int overfadeid;
    protected int downfadeid;

    private float overfadeprogress = 0f;
    private float downfadeprogress = 0f;

    private CapBtnType type;

    internal ThemeCaptionButtonElements elements = new ThemeCaptionButtonElements();

    new object Parent;

    internal ThemeForm ownerform;

    public ThemeCaptionButton(CapBtnType type, object Parent)
    {
      this.type = type;
      this.Parent = Parent;

      overfadeid = FadeScheduler.CreateFade(new EventHandler<FadeEventArgs>(this.FadeChanged), 0.2f, 0f, 1f);
      downfadeid = FadeScheduler.CreateFade(new EventHandler<FadeEventArgs>(this.FadeChanged), 0.2f, 0f, 1f);
    }

    public override ThemeForm Form
    {
      get
      {
        if (this.Parent is ThemeControl)
          return ((ThemeControl)this.Parent).Form;
        if (this.Parent is ThemeContainerControl)
          return ((ThemeContainerControl)this.Parent).Form;
        if (this.Parent is ThemeForm)
          return (ThemeForm)this.Parent;

        Control tmp = this;

        while ((tmp != null) && !(tmp is ThemeForm))
          tmp = tmp.Parent;

        return (ThemeForm)tmp;
      }
    }

    protected override void ControlStyleChanged()
    {
      elements = (ThemeCaptionButtonElements)GetStyle();

      if (!elements.OverFade)
      {
        elements.OverFadeMin = 0f;
        elements.OverFadeMax = 1f;
        elements.OverFadeSteps = 1;
        overfadeprogress = 0f;
      }

      if (!elements.DownFade)
      {
        elements.DownFadeMin = 0f;
        elements.DownFadeMax = 1f;
        elements.DownFadeSteps = 1;
        downfadeprogress = 0f;
      }

      FadeScheduler.UpdateFade(overfadeid, ((elements.OverFadeMax - elements.OverFadeMin) / elements.OverFadeSteps), elements.OverFadeMin, elements.OverFadeMax);
      FadeScheduler.UpdateFade(downfadeid, ((elements.DownFadeMax - elements.DownFadeMin) / elements.DownFadeSteps), elements.DownFadeMin, elements.DownFadeMax);
    }

    void FadeChanged(object sender, FadeEventArgs e)
    {
      if (e.FadeID == overfadeid)
        overfadeprogress = e.Progress;
      else
        downfadeprogress = e.Progress;

      if (ownerform != null)
      {
        ownerform.RedrawButtons();
      }
      else
        Invalidate();
    }

    public void SetFadeType(FadeType ft)
    {
      FadeScheduler.SetFadeType(overfadeid, ft);
    }

    public void SetDownFadeType(FadeType ft)
    {
      FadeScheduler.SetFadeType(downfadeid, ft);
    }

    public void _Paint(Graphics g, Rectangle rect)
    {
      DoPaint(new PaintEventArgs(g, rect));
    }

    protected override void DoPaint(PaintEventArgs e)
    {
      if (!this.Enabled)
      {
        if (type == CapBtnType.Close)
          ThemeKit.DrawOrFill(elements.CloseButtonDisabled, e.Graphics, e.ClipRectangle);
        else if (type == CapBtnType.Maximize)
          ThemeKit.DrawOrFill(elements.MaximizeButtonDisabled, e.Graphics, e.ClipRectangle);
        else
          ThemeKit.DrawOrFill(elements.MinimizeButtonDisabled, e.Graphics, e.ClipRectangle);
      }
      else
      {
        if (type == CapBtnType.Close)
          ThemeKit.DrawOrFill(elements.CloseButtonNormal, e.Graphics, e.ClipRectangle);
        else if (type == CapBtnType.Maximize)
          ThemeKit.DrawOrFill(elements.MaximizeButtonNormal, e.Graphics, e.ClipRectangle);
        else
          ThemeKit.DrawOrFill(elements.MinimizeButtonNormal, e.Graphics, e.ClipRectangle);

        if (type == CapBtnType.Close)
          ThemeKit.DrawOrFill(elements.CloseButtonOver, e.Graphics, e.ClipRectangle, overfadeprogress);
        else if (type == CapBtnType.Maximize)
          ThemeKit.DrawOrFill(elements.MaximizeButtonOver, e.Graphics, e.ClipRectangle, overfadeprogress);
        else
          ThemeKit.DrawOrFill(elements.MinimizeButtonOver, e.Graphics, e.ClipRectangle, overfadeprogress);
      }
    }

    protected override void OnClick(EventArgs e)
    {
      if (this.DesignMode)
        return;

      Control c = this;

      while (c != null && !(c is Form))
        c = c.Parent;

      if (!(c is Form))
        return;

      Form frm = (Form)c;

      if (type == CapBtnType.Close)
        NativeMethods.SendMessage(frm.Handle, (int)NativeMethods.WindowMessages.WM_CLOSE, IntPtr.Zero, (IntPtr)0);
      else if (type == CapBtnType.Maximize)
      {
        if (frm.WindowState == FormWindowState.Maximized)
          NativeMethods.SendMessage(frm.Handle, (int)NativeMethods.WindowMessages.WM_SYSCOMMAND, (IntPtr)NativeMethods.SystemCommands.SC_RESTORE, (IntPtr)0);
        else
          NativeMethods.SendMessage(frm.Handle, (int)NativeMethods.WindowMessages.WM_SYSCOMMAND, (IntPtr)NativeMethods.SystemCommands.SC_MAXIMIZE, (IntPtr)0);
      }
      else if (type == CapBtnType.Minimize)
        NativeMethods.SendMessage(frm.Handle, (int)NativeMethods.WindowMessages.WM_SYSCOMMAND, (IntPtr)NativeMethods.SystemCommands.SC_MINIMIZE, (IntPtr)0);
    }

    protected override void OnMouseEnter(EventArgs e)
    {
      FadeScheduler.SetFadeType(overfadeid, FadeType.In);

      base.OnMouseEnter(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
      FadeScheduler.SetFadeType(overfadeid, FadeType.Out);

      base.OnMouseLeave(e);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      FadeScheduler.SetFadeType(downfadeid, FadeType.In);

      base.OnMouseDown(e);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      FadeScheduler.SetFadeType(downfadeid, FadeType.Out);

      base.OnMouseUp(e);
    }

    bool dsgnmode;
    internal new bool DesignMode
    {
      get { return dsgnmode; }
      set { dsgnmode = value; }
    }
  }
}
