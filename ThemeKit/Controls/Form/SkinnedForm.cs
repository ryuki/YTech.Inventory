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
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Drawing.Drawing2D;

namespace BurtonSoftware.UI
{
  public class SkinnedForm : Form
  {
    protected int TopBorderHeight = 20;
    protected int BottomBorderHeight = 3;
    protected int LeftBorderWidth = 3;
    protected int RightBorderWidth = 3;

    private Size tmpclientsize;

    public SkinnedForm()
    {
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
      this.SetStyle(ControlStyles.ResizeRedraw, true);
    }

    protected override void WndProc(ref Message m)
    {
      switch (m.Msg)
      {
        case (int)NativeMethods.WindowMessages.WM_NCPAINT:
          PaintNonClientArea(m.HWnd, m.WParam);
          m.Result = NativeMethods.TRUE;

          return;

        case (int)NativeMethods.WindowMessages.WM_NCCALCSIZE:
          if (m.WParam == NativeMethods.FALSE)
          {
            //NativeMethods.RECT ncRect = (NativeMethods.RECT)Marshal.PtrToStructure(m.LParam, typeof(NativeMethods.RECT));
            NativeMethods.RECT ncRect = (NativeMethods.RECT)m.GetLParam(typeof(NativeMethods.RECT));
            Rectangle proposed = ncRect.Rect;
            OnNonClientAreaCalcSize(ref proposed);
            ncRect = NativeMethods.RECT.FromRectangle(proposed);
            Marshal.StructureToPtr(ncRect, m.LParam, false);
          }
          else if (m.WParam == NativeMethods.TRUE)
          {
            //NativeMethods.NCCALCSIZE_PARAMS ncParams = (NativeMethods.NCCALCSIZE_PARAMS)Marshal.PtrToStructure(m.LParam, typeof(NativeMethods.NCCALCSIZE_PARAMS));
            NativeMethods.NCCALCSIZE_PARAMS ncParams = (NativeMethods.NCCALCSIZE_PARAMS)m.GetLParam(typeof(NativeMethods.NCCALCSIZE_PARAMS));
            Rectangle proposed = ncParams.rectProposed.Rect;
            OnNonClientAreaCalcSize(ref proposed);
            ncParams.rectProposed = NativeMethods.RECT.FromRectangle(proposed);
            Marshal.StructureToPtr(ncParams, m.LParam, false);
          }

          //m.Result = IntPtr.Zero;

          return;

        case (int)NativeMethods.WindowMessages.WM_NCHITTEST:
          Point screenPoint = new Point(m.LParam.ToInt32());
          Point clientPoint = PointToWindow(screenPoint);

          int dragsize = 3;

          m.Result = IntPtr.Zero;

          if (this.FormBorderStyle == FormBorderStyle.Sizable || this.FormBorderStyle == FormBorderStyle.SizableToolWindow)
          {
            if (clientPoint.X <= dragsize)
            {
              if (clientPoint.Y <= dragsize)
                m.Result = new IntPtr((int)NativeMethods.NCHITTEST.HTTOPLEFT);
              else if (clientPoint.Y >= this.Height - dragsize)
                m.Result = new IntPtr((int)NativeMethods.NCHITTEST.HTBOTTOMLEFT);
              else
                m.Result = new IntPtr((int)NativeMethods.NCHITTEST.HTLEFT);
            }
            else if (clientPoint.X >= this.Width - dragsize)
            {
              if (clientPoint.Y <= dragsize)
                m.Result = new IntPtr((int)NativeMethods.NCHITTEST.HTTOPRIGHT);
              else if (clientPoint.Y >= this.Height - dragsize)
                m.Result = new IntPtr((int)NativeMethods.NCHITTEST.HTBOTTOMRIGHT);
              else
                m.Result = new IntPtr((int)NativeMethods.NCHITTEST.HTRIGHT);
            }
            else if (clientPoint.Y <= dragsize)
              m.Result = new IntPtr((int)NativeMethods.NCHITTEST.HTTOP);
            else if (clientPoint.Y >= this.Height - dragsize)
              m.Result = new IntPtr((int)NativeMethods.NCHITTEST.HTBOTTOM);
          }
          else
          {
            if ((clientPoint.X <= dragsize || clientPoint.X >= this.Width - dragsize) && (clientPoint.Y <= dragsize || clientPoint.Y >= this.Height - dragsize))
              m.Result = new IntPtr((int)NativeMethods.NCHITTEST.HTBORDER);
          }

          if (m.Result == IntPtr.Zero && clientPoint.Y <= TopBorderHeight)
            m.Result = new IntPtr((int)NativeMethods.NCHITTEST.HTCAPTION);

          if (m.Result == IntPtr.Zero)
            m.Result = new IntPtr((int)NativeMethods.NCHITTEST.HTCLIENT);

          return;

        case (int)NativeMethods.WindowMessages.WM_NCACTIVATE:
          bool active = (m.WParam == NativeMethods.TRUE);

          if (WindowState == FormWindowState.Minimized)
            DefWndProc(ref m);
          else
          {
            PaintNonClientArea(m.HWnd, (IntPtr)1);
            m.Result = NativeMethods.TRUE;
          }

          return;

        case (int)NativeMethods.WindowMessages.WM_SETTEXT:
          DefWndProc(ref m);
          PaintNonClientArea(m.HWnd, (IntPtr)1);
          return;

        case (int)NativeMethods.WindowMessages.WM_NCMOUSEMOVE:
          clientPoint = this.PointToWindow(new Point(m.LParam.ToInt32()));
          OnNonClientMouseMove(new MouseEventArgs(MouseButtons.None, 0, clientPoint.X, clientPoint.Y, 0));
          m.Result = IntPtr.Zero;
          return;

        case (int)NativeMethods.WindowMessages.WM_NCMOUSELEAVE:
          OnNonClientMouseLeave(EventArgs.Empty);
          return;

        case (int)NativeMethods.WindowMessages.WM_NCLBUTTONDOWN:
          Point pt = this.PointToWindow(new Point(m.LParam.ToInt32()));
          NonClientMouseEventArgs args = new NonClientMouseEventArgs(MouseButtons.Left, 1, pt.X, pt.Y, 0, m.WParam.ToInt32());

          OnNonClientMouseDown(args);

          if (!args.Handled)
            DefWndProc(ref m);

          m.Result = NativeMethods.TRUE;
          return;

        case (int)NativeMethods.WindowMessages.WM_SYSCOMMAND:

          int sc = m.WParam.ToInt32();

          if (sc == (int)NativeMethods.SystemCommands.SC_MAXIMIZE || sc == (int)NativeMethods.SystemCommands.SC_MAXIMIZE2)
            tmpclientsize = this.ClientSize;
          else if (sc == (int)NativeMethods.SystemCommands.SC_MINIMIZE)
            tmpclientsize = this.ClientSize;
          else if (sc == (int)NativeMethods.SystemCommands.SC_RESTORE || sc == (int)NativeMethods.SystemCommands.SC_RESTORE2)
            this.ClientSize = tmpclientsize;

          DefWndProc(ref m);

          return;

        case 174:
          return;
      }

      base.WndProc(ref m);
    }

    public Point PointToWindow(Point screenPoint)
    {
      if (this.IsMdiChild)
      {
        Point pt = PointToClient(screenPoint);
        pt.Offset(LeftBorderWidth, TopBorderHeight);
        return pt;
      }

      return new Point(screenPoint.X - Location.X, screenPoint.Y - Location.Y);
    }

    private void PaintNonClientArea(IntPtr hwnd, IntPtr hrgn)
    {
      NativeMethods.RECT windowRect = new NativeMethods.RECT();
      if (NativeMethods.GetWindowRect(hwnd, ref windowRect) == 0)
        return;

      Rectangle bounds = new Rectangle(0, 0, windowRect.right - windowRect.left, windowRect.bottom - windowRect.top);

      if (bounds.Width * bounds.Height == 0)
        return;

      IntPtr hDC = NativeMethods.GetWindowDC(hwnd);

      if (hDC == IntPtr.Zero)
        return;

      IntPtr CompatiblehDC = NativeMethods.CreateCompatibleDC(hDC);
      IntPtr CompatibleBitmap = NativeMethods.CreateCompatibleBitmap(hDC, bounds.Width, bounds.Height);

      try
      {
        Region r = new Region(bounds);
        r.Exclude(new Rectangle(LeftBorderWidth, TopBorderHeight, this.ClientRectangle.Width, this.ClientRectangle.Height));

        NativeMethods.SelectObject(CompatiblehDC, CompatibleBitmap);

        NativeMethods.BitBlt(CompatiblehDC, 0, 0, bounds.Width, bounds.Height, hDC, 0, 0, NativeMethods.TernaryRasterOperations.SRCCOPY);

        using (Graphics g = Graphics.FromHdc(CompatiblehDC))
        {
          g.Clip = r;
          OnNonClientAreaPaint(new PaintEventArgs(g, bounds));
        }

        NativeMethods.BitBlt(hDC, 0, 0, bounds.Width, bounds.Height, CompatiblehDC, 0, 0, NativeMethods.TernaryRasterOperations.SRCCOPY);
      }
      finally
      {
        NativeMethods.DeleteObject(CompatibleBitmap);
        NativeMethods.DeleteDC(CompatiblehDC);
        NativeMethods.ReleaseDC(hwnd, hDC);
      }
    }

    protected virtual void OnNonClientMouseDown(NonClientMouseEventArgs args)
    {

    }

    protected virtual void OnNonClientMouseLeave(EventArgs eventArgs)
    {

    }

    protected virtual void OnNonClientMouseMove(MouseEventArgs e)
    {

    }

    protected virtual void OnNonClientAreaCalcSize(ref Rectangle r)
    {
      r.Offset(LeftBorderWidth, TopBorderHeight);
      r.Width -= LeftBorderWidth + RightBorderWidth;
      r.Height -= TopBorderHeight + BottomBorderHeight;
    }

    protected virtual void OnNonClientAreaPaint(PaintEventArgs e)
    {
      Rectangle rect = e.ClipRectangle;
      rect.Width--;
      rect.Height--;

      e.Graphics.Clip = new Region(GetPath(new Rectangle(0, 0, this.Width, this.Height)));

      e.Graphics.FillRectangle(Brushes.Red, rect);
      e.Graphics.DrawRectangle(Pens.Black, rect);
    }

    protected virtual GraphicsPath GetPath(Rectangle rect)
    {
      return new GraphicsPath();
    }

    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);
      this.Region = new Region(GetPath(new Rectangle(0, 0, this.Width, this.Height)));
    }

    protected override void OnHandleCreated(EventArgs e)
    {
      NativeMethods.SetWindowTheme(this.Handle, "", "");
      base.OnHandleCreated(e);
    }

    protected override CreateParams CreateParams
    {
      [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
      get
      {
        CreateParams cp = base.CreateParams;
        cp.Style = cp.Style | (int)NativeMethods.WindowStyle.WS_SYSMENU;
        return cp;
      }
    }

    protected override void SetClientSizeCore(int x, int y)
    {
      this.Size = SizeFromClientSize(x, y);
      UpdateBounds(Location.X, Location.Y, Size.Width, Size.Height, x, y);
    }

    protected virtual Size SizeFromClientSize(int x, int y)
    {
      return new Size(x + LeftBorderWidth + RightBorderWidth, y + TopBorderHeight + BottomBorderHeight);
    }

    protected override Size SizeFromClientSize(Size clientSize)
    {
      return SizeFromClientSize(clientSize.Width, clientSize.Height);
    }

    public void InvalidateWindow()
    {
      PaintNonClientArea(this.Handle, (IntPtr)1);
      Invalidate(true);
    }

    public void InvalidateNonClientArea()
    {
      PaintNonClientArea(this.Handle, (IntPtr)1);
    }
  }

  public class NonClientMouseEventArgs : MouseEventArgs
  {
    private int _hitTest;
    private bool _handled;

    public NonClientMouseEventArgs(MouseButtons button, int clicks, int x, int y, int delta, int hitTest)
      : base(button, clicks, x, y, delta)
    {
      _hitTest = hitTest;
    }

    public int HitTest
    {
      get { return _hitTest; }
      set { _hitTest = value; }
    }

    public bool Handled
    {
      get { return _handled; }
      set { _handled = value; }
    }

  }
}
