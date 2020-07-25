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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using BurtonSoftware.UI;

namespace BurtonSoftware.ThemeKit
{
  public partial class LoadingTransition : Form, IDisposable
  {
    public LoadingTransition()
    {
      this.FormBorderStyle = FormBorderStyle.None;
      this.ControlBox = false;
      this.MinimizeBox = false;
      this.MaximizeBox = false;
      this.StartPosition = FormStartPosition.Manual;
      this.ShowInTaskbar = false;

      singleframeduration = 50;

      fadetimer.Interval = singleframeduration;
      fadetimer.Tick += new EventHandler(timer_Tick);

      SetStyle(ControlStyles.Selectable, false);
      this.TopMost = true;

      this.Opacity = 0.00;

      FadeDuration = 250;
      ClickThrough = true;
    }

    public int FrameDuration
    {
      get { return singleframeduration; }
      set
      {
        if (value <= 0)
        {
          value = 1;
        }

        singleframeduration = value;
        fadetimer.Interval = value;

        FadeDuration = FadeDuration;
      }
    }

    public int FadeDuration
    {
      get { return fadeduration; }
      set
      {
        if (value < singleframeduration)
          value = singleframeduration;

        opacitydecrement = 1.0 / (value / (double)singleframeduration);
      }
    }

    public bool DisposeOnHide
    {
      get { return disposeonhide; }
      set { disposeonhide = value; }
    }

    public bool ClickThrough
    {
      get { return clickthrough; }
      set { clickthrough = value; }
    }

    public new void Show()
    {
      UnBind();
      Appear(null);
    }

    public new void Show(IWin32Window owner)
    {
      UnBind();

      Control control = Control.FromHandle(owner.Handle);
      if (control != null)
        BindTo(control);

      Appear(owner);
    }

    public void Fade()
    {
      isfading = true;
      fadetimer.Start();
    }

    public new void Hide()
    {
      this.Opacity = 0.00;
      fadetimer.Stop();
      isfading = false;
      base.Hide();
      Application.DoEvents();

      if (disposeonhide)
        Dispose();
    }

    private void BindTo(Control control)
    {
      if (bindedcontrol != null)
        UnBind();

      Rectangle bounds = ComputeControlScreenBounds(control);

      if (Bounds != bounds)
        Bounds = bounds;

      control.TopLevelControl.LocationChanged += new EventHandler(bindedControl_LocationChanged);

      bindedcontrol = control;
    }

    private Rectangle ComputeControlScreenBounds(Control control)
    {
      if (control.TopLevelControl == control)
        return control.Bounds;

      Rectangle rect = new Rectangle(0, 0, control.Width, control.Height);
      return control.RectangleToScreen(rect);
    }

    private void UnBind()
    {
      if (bindedcontrol == null)
        return;

      bindedcontrol.TopLevelControl.LocationChanged -= new EventHandler(bindedControl_LocationChanged);
      bindedcontrol = null;
    }

    private void bindedControl_LocationChanged(object sender, EventArgs e)
    {
      Rectangle bounds = ComputeControlScreenBounds(bindedcontrol);
      Left = bounds.X;
      Top = bounds.Y;
      Refresh();
    }

    protected override void OnResize(EventArgs e)
    {
      Hide();
      Clear();

      Graphics g = this.CreateGraphics();

      screenbmp = new Bitmap(Bounds.Width, Bounds.Height, g);
      screengraphics = Graphics.FromImage(screenbmp);

      g.Dispose();

      base.OnResize(e);
    }

    private void Appear(IWin32Window owner)
    {
      Hide();

      Graphics g = this.CreateGraphics();

      screengraphics.CopyFromScreen(Bounds.Left, Bounds.Top, 0, 0, Bounds.Size);
      this.BackgroundImage = screenbmp;

      this.Opacity = 0;

      g.Dispose();

      NativeMethods.ShowWindow(this.Handle, (int)NativeMethods.ShowWindowOptions.SW_SHOWNOACTIVATE);

      this.Refresh();
    }

    private void timer_Tick(object sender, EventArgs e)
    {
      if (this.Opacity < opacitydecrement)
      {
        Hide();
        return;
      }

      this.Opacity -= opacitydecrement;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      if (screenbmp != null)
      {
        if (this.Opacity == 0)
          this.Opacity = 0.999;

        base.OnPaint(e);
      }
    }

    protected override void WndProc(ref Message m)
    {
      switch (m.Msg)
      {
        case (int)NativeMethods.WindowMessages.WM_ACTIVATE:
          {
            if (((int)m.WParam & 0xFFFF) != WA_INACTIVE)
            {
              if (m.LParam != IntPtr.Zero)
              {
                // re-focus the deactivated control!
                Control control = Control.FromHandle(m.LParam);
                if (control != null)
                {
                  control.Focus();
                }
              }
            }
          }
          break;

        // when fading, the window may be click-through...
        case (int)NativeMethods.WindowMessages.WM_NCHITTEST:
          {
            if (clickthrough && isfading)
            {
              m.Result = (IntPtr)NativeMethods.NCHITTEST.HTTRANSPARENT;
              return;
            }
          }
          break;
      }

      base.WndProc(ref m);
    }

    private void Clear()
    {
      if (screengraphics != null) { screengraphics.Dispose(); }
      if (screenbmp != null) { screenbmp.Dispose(); }

      screengraphics = null;
      screenbmp = null;
    }

    void IDisposable.Dispose()
    {
      Clear();
    }

    private System.Windows.Forms.Timer fadetimer = new System.Windows.Forms.Timer();

    private Bitmap screenbmp = null;

    private Graphics screengraphics = null;

    private double opacitydecrement = 0;
    private int fadeduration = 0;
    private int singleframeduration = 60;

    private bool clickthrough = false;
    private bool isfading = false;

    private Control bindedcontrol = null;

    private const int WA_INACTIVE = 0;

    private bool disposeonhide;
  }
}