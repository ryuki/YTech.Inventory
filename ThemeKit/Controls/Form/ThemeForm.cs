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
using BurtonSoftware.UI;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Permissions;
using System.Xml;
using System.ComponentModel;
using System.IO;

namespace BurtonSoftware.ThemeKit
{
  internal class ThemeFormElements
  {
    public ExBrush[] NormalBackground = new ExBrush[0];
    public ExBrush[] ActiveBorder = new ExBrush[0];

    public ExBrush[] NormalTitleText = new ExBrush[0];

    public int LeftBorderSize = 3;
    public int TopBorderSize = 32;
    public int RightBorderSize = 3;
    public int BottomBorderSize = 3;

    public bool ShowIcon = false;
    public int IconLeft = 0;
    public int IconTop = 0;
    public int IconWidth = 24;
    public int IconHeight = 24;

    public bool ShowTitle = false;
    public string TitleLeft = "0";
    public string TitleTop = "0";
    public string TitleWidth = "100";
    public string TitleHeight = "10";
    public string TitleFont = "Arial";
    public int TitleSize = 10;
    public int TitleStyle = 0;

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

    public Rectangle IconRect(Rectangle bounds)
    {
      int x = IconLeft;
      int y = IconTop;

      if (x < 0)
        x = bounds.Right + IconLeft;
      if (y < 0)
        y = bounds.Bottom + IconTop;

      return new Rectangle(x, y, IconWidth, IconHeight); 
    }

    public Rectangle TitleRect(Rectangle bounds)
    {
      int x = 0;
      int y = 0;
      int w = 0;
      int h = 0;

      if (TitleLeft.StartsWith("W-"))
        x = bounds.Width - int.Parse(TitleLeft.Substring(2));
      else
        x = int.Parse(TitleLeft);

      if (TitleTop.StartsWith("H-"))
        y = bounds.Height - int.Parse(TitleTop.Substring(2));
      else
        y = int.Parse(TitleTop);

      if (TitleWidth.StartsWith("W-"))
        w = bounds.Width - int.Parse(TitleWidth.Substring(2)) - x;
      else
        w = int.Parse(TitleWidth);

      if (TitleHeight.StartsWith("H-"))
        h = bounds.Height - int.Parse(TitleHeight.Substring(2)) - y;
      else
        h = int.Parse(TitleHeight);

      return new Rectangle(x, y, w, h);
    }

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

  public enum FormDisplayEffect { None, Fade }

  [ThemeKitControl("Form", typeof(ThemeFormElements))]
  public class ThemeForm : SkinnedForm
  {
    private ThemeCaptionButton btnclose;
    private ThemeCaptionButton btnmin;
    private ThemeCaptionButton btnmax;

    internal Theme theme;
    internal Dictionary<Type, Dictionary<string, object>> controlstyledictionaries;

    ThemeFormElements elements = new ThemeFormElements();

    public ThemeForm()
    {
      this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
      
      controlstyledictionaries = new Dictionary<Type, Dictionary<string, object>>();

      base.TopBorderHeight = 30;

      btnclose = new ThemeCaptionButton(ThemeCaptionButton.CapBtnType.Close, this);
      btnclose.ownerform = this;
      btnclose.Visible = false;

      btnmin = new ThemeCaptionButton(ThemeCaptionButton.CapBtnType.Minimize, this);
      btnmin.ownerform = this;
      btnmin.Visible = false;

      btnmax = new ThemeCaptionButton(ThemeCaptionButton.CapBtnType.Maximize, this);
      btnmax.ownerform = this;
      btnmax.Visible = false;

      ThemeKit.forms.Add(this);
    }

    ~ThemeForm()
    {
      if (ThemeKit.forms.Contains(this))
        ThemeKit.forms.Remove(this);
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
      if (theme == null)
      {
        Rectangle r = this.ClientRectangle;
        r.Width--;
        r.Height--;

        e.Graphics.FillRectangle(Brushes.White, r);
        e.Graphics.DrawRectangle(Pens.Black, r);

        StringFormat sf = new StringFormat();
        sf.LineAlignment = StringAlignment.Center;
        sf.Alignment = StringAlignment.Center;

        e.Graphics.DrawString("No Theme Loaded\r\n\r\nPlease Load One Using the ThemeFile Property", SystemFonts.DefaultFont, Brushes.Black, r, sf);

        sf.Dispose();

        return;
      }

      Rectangle rect = this.ClientRectangle;
      rect.Inflate(1, 1);

      ThemeKit.SetGraphicsQuality(e.Graphics);
      ThemeKit.DrawOrFill(elements.NormalBackground, e.Graphics, rect);
    }

    protected override void OnNonClientAreaPaint(PaintEventArgs e)
    {
      if (theme == null)
      {
        Rectangle r = e.ClipRectangle;
        r.Width--;
        r.Height--;

        e.Graphics.FillRectangle(Brushes.LightGray, r);
        e.Graphics.DrawRectangle(Pens.Black, r);

        return;
      }

      ThemeKit.SetGraphicsQuality(e.Graphics);
      ThemeKit.DrawOrFill(elements.ActiveBorder, e.Graphics, e.ClipRectangle);

      if (elements.ShowIcon && (this.Icon != null))
      {
        e.Graphics.DrawIcon(this.Icon, elements.IconRect(e.ClipRectangle));
      }

      if (elements.ShowTitle)
      {
        Font f = new Font(elements.TitleFont, elements.TitleSize, (FontStyle)elements.TitleStyle);

        ThemeKit.DrawContent(this.Text, null, ContentAlignment.MiddleLeft, ContentAlignment.TopLeft, elements.NormalTitleText, e.Graphics, elements.TitleRect(e.ClipRectangle), f);
      }

      if (elements.CloseButton && this.ControlBox)
        btnclose._Paint(e.Graphics, btnclose.Bounds);
      
      if (elements.MaximizeButton && this.MaximizeBox)
        btnmax._Paint(e.Graphics, btnmax.Bounds);

      if (elements.MinimizeButton && this.MinimizeBox)
        btnmin._Paint(e.Graphics, btnmin.Bounds);
    }

    protected override void OnNonClientMouseMove(MouseEventArgs e)
    {
      if (this.ControlBox && elements.CloseButton)
      {
        if (btnclose.Bounds.Contains(e.Location))
          btnclose.SetFadeType(FadeType.In);
        else
          btnclose.SetFadeType(FadeType.Out);
      }

      if (this.MaximizeBox && elements.MaximizeButton)
      {
        if (btnmax.Bounds.Contains(e.Location))
          btnmax.SetFadeType(FadeType.In);
        else
          btnmax.SetFadeType(FadeType.Out);
      }

      if (this.MinimizeBox && elements.MinimizeButton)
      {
        if (btnmin.Bounds.Contains(e.Location))
          btnmin.SetFadeType(FadeType.In);
        else
          btnmin.SetFadeType(FadeType.Out);
      }

      base.OnNonClientMouseMove(e);
    }

    internal void RedrawButtons()
    {
      IntPtr hwnd = this.Handle;

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

          if (this.ControlBox && elements.CloseButton)
            btnclose._Paint(g, btnclose.Bounds);

          if (this.MaximizeBox && elements.MaximizeButton)
            btnmax._Paint(g, btnmax.Bounds);

          if (this.MinimizeBox && elements.MinimizeButton)
            btnmin._Paint(g, btnmin.Bounds);
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

    protected override void OnNonClientMouseDown(NonClientMouseEventArgs args)
    {
      base.OnNonClientMouseDown(args);

      if (this.ControlBox && elements.CloseButton && btnclose.Bounds.Contains(args.Location))
      {
        if (DepressButton(btnclose.Bounds, btnclose))
          NativeMethods.SendMessage(this.Handle, (int)NativeMethods.WindowMessages.WM_CLOSE, IntPtr.Zero, (IntPtr)0);
      }

      if (this.MaximizeBox && elements.MaximizeButton && btnmax.Bounds.Contains(args.Location))
      {
        if (DepressButton(btnmax.Bounds, btnmax))
        {
          if (this.WindowState == FormWindowState.Maximized)
            NativeMethods.SendMessage(this.Handle, (int)NativeMethods.WindowMessages.WM_SYSCOMMAND, (IntPtr)NativeMethods.SystemCommands.SC_RESTORE, (IntPtr)0);
          else
            NativeMethods.SendMessage(this.Handle, (int)NativeMethods.WindowMessages.WM_SYSCOMMAND, (IntPtr)NativeMethods.SystemCommands.SC_MAXIMIZE, (IntPtr)0);
        }
      }

      if (this.MinimizeBox && elements.MinimizeButton && btnmin.Bounds.Contains(args.Location))
      {
        if (DepressButton(btnmin.Bounds, btnmin))
          NativeMethods.SendMessage(this.Handle, (int)NativeMethods.WindowMessages.WM_SYSCOMMAND, (IntPtr)NativeMethods.SystemCommands.SC_MINIMIZE, (IntPtr)0);
      }
    }

    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
    private bool DepressButton(Rectangle btnrect, ThemeCaptionButton btn)
    {
      bool result = false;
      try
      {
        this.Capture = true;

        btn.SetDownFadeType(FadeType.In);

        bool done = false;
        while (!done)
        {
          Message m = new Message();

          if (NativeMethods.PeekMessage(ref m, IntPtr.Zero, (int)NativeMethods.WindowMessages.WM_MOUSEFIRST, (int)NativeMethods.WindowMessages.WM_MOUSELAST, (int)NativeMethods.PeekMessageOptions.PM_REMOVE))
          {
            switch (m.Msg)
            {
              case (int)NativeMethods.WindowMessages.WM_LBUTTONUP:
                {
                  btn.SetDownFadeType(FadeType.Out);
                  Point pt = PointToWindow(PointToScreen(new Point(m.LParam.ToInt32())));
                  result = btnrect.Contains(pt);
                  done = true;
                  break;
                }
              case (int)NativeMethods.WindowMessages.WM_MOUSEMOVE:
                {
                  Point clientPoint = PointToWindow(PointToScreen(new Point(m.LParam.ToInt32())));
                  
                  if (btnrect.Contains(clientPoint))
                    btn.SetDownFadeType(FadeType.In);
                  else
                    btn.SetDownFadeType(FadeType.Out);

                  break;
                }
            }
          }
        }
      }
      finally
      {
        this.Capture = false;
      }

      return result;
    }

    protected override void OnNonClientMouseLeave(EventArgs eventArgs)
    {
      base.OnNonClientMouseLeave(eventArgs);

      if (elements.CloseButton)
        btnclose.SetFadeType(FadeType.Out);
      if (elements.MinimizeButton)
        btnmin.SetFadeType(FadeType.Out);
      if (elements.MaximizeButton)
        btnmax.SetFadeType(FadeType.Out);
    }

    protected override GraphicsPath GetPath(Rectangle rect)
    {
      if (elements.ActiveBorder.Length > 0)
        return elements.ActiveBorder[0].GetPath(rect);

      GraphicsPath tmp = new GraphicsPath();
      tmp.AddRectangle(rect);
      tmp.CloseFigure();
      return tmp;
    }

    protected override void WndProc(ref Message m)
    {
      base.WndProc(ref m);

      if (m.Msg == (int)NativeMethods.WindowMessages.WM_NCHITTEST)
      {
        Point screenPoint = new Point(m.LParam.ToInt32());
        Point clientPoint = PointToWindow(screenPoint);

        if (elements.CloseButton && btnclose.Bounds.Contains(clientPoint))
        {
          m.Result = new IntPtr((int)NativeMethods.NCHITTEST.HTCLOSE);
          InvalidateNonClientArea();
        }
        else if (elements.MaximizeButton && btnmax.Bounds.Contains(clientPoint))
        {
          m.Result = new IntPtr((int)NativeMethods.NCHITTEST.HTMAXBUTTON);
          InvalidateNonClientArea();
        }
        else if (elements.MinimizeButton && btnmin.Bounds.Contains(clientPoint))
        {
          m.Result = new IntPtr((int)NativeMethods.NCHITTEST.HTMINBUTTON);
          InvalidateNonClientArea();
        }
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Editor(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public string ThemeFile
    {
      get { return ""; }
      set
      {
        if (File.Exists(value))
          Theme = Convert.ToBase64String(File.ReadAllBytes(value));
        else
          UnloadTheme();
      }
    }

    string themestr;
    [Browsable(false)]
    public string Theme
    {
      get { return themestr; }
      set
      {
        themestr = value;

        if (string.IsNullOrEmpty(themestr))
        {
          UnloadTheme();
          return;
        }

        try
        {
          byte[] theme = Convert.FromBase64String(themestr);
          LoadTheme(theme);
        }
        catch (Exception ex)
        {
          MessageBox.Show("Invalid Theme, Please Reload Theme File\r\n\r\n" + ex.Message + "\r\n\r\n" + ex.StackTrace);
        }
      }
    }

    public Theme CurrentTheme
    {
      get { return theme; }
    }

    private FormDisplayEffect displayeffect = FormDisplayEffect.Fade;
    [Browsable(true)]
    public FormDisplayEffect DisplayEffect
    {
      get { return displayeffect; }
      set { displayeffect = value; }
    }

    public void LoadTheme(byte[] themebytes)
    {
      NativeMethods.SetDllDirectory(Path.GetTempPath());
      NativeMethods.LockWindowUpdate(this.Handle);

      Size tmp = this.ClientSize;

      disablecheckstyle = true;
      theme = new Theme(this, themebytes);
      disablecheckstyle = false;

      this.Style = style;

      foreach (Control c in this.Controls)
        RestyleControl(c);

      RestyleControl(btnclose);
      RestyleControl(btnmax);
      RestyleControl(btnmin);

      this.ClientSize = tmp;
      InvalidateWindow();

      NativeMethods.LockWindowUpdate(IntPtr.Zero);
    }

    public void LoadTheme(string filename)
    {
      FileStream stream = File.OpenRead(filename);
      byte[] theme = new byte[stream.Length];
      stream.Read(theme, 0, (int)stream.Length);
      LoadTheme(theme);
    }

    void RestyleControl(Control c)
    {
      if (c is ThemeControl)
        ((ThemeControl)c).Style = ((ThemeControl)c).Style;
      else if (c is ThemeContainerControl)
        ((ThemeContainerControl)c).Style = ((ThemeContainerControl)c).Style;
      else if (c is ThemeContextMenuStrip)
        ((ThemeContextMenuStrip)c).Style = ((ThemeContextMenuStrip)c).Style;
      else if (c is ThemeStatusStrip)
        ((ThemeStatusStrip)c).Style = ((ThemeStatusStrip)c).Style;
      else if (c is ThemeToolStrip)
        ((ThemeToolStrip)c).Style = ((ThemeToolStrip)c).Style;
      else if (c is ThemeMenuStrip)
        ((ThemeMenuStrip)c).Style = ((ThemeMenuStrip)c).Style;

      foreach (Control child in c.Controls)
        RestyleControl(child);
    }

    public void UnloadTheme()
    {
      theme = null;
      disablecheckstyle = true;
      Invalidate();
    }

    internal string CheckStyle(object o, string s)
    {
      if (o == null)
        return "";

      return CheckStyle(o.GetType(), s);
    }

    bool disablecheckstyle = true;
    internal string CheckStyle(Type t, string s)
    {
      if (disablecheckstyle)
        return s;

      if (!controlstyledictionaries.ContainsKey(t))
        return s;

      if (!string.IsNullOrEmpty(s) && controlstyledictionaries[t].ContainsKey(s))
        return s;

      foreach (string st in controlstyledictionaries[t].Keys)
        return st;

      return "";
    }

    string style;
    [EditorAttribute(typeof(ThemeStyleEditor), typeof(System.Drawing.Design.UITypeEditor)), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public string Style
    {
      get { return style; }
      set
      {
        NativeMethods.LockWindowUpdate(this.Handle);

        Size tmp = this.ClientSize;

        style = CheckStyle(this, value);
        ControlStyleChanged();

        this.ClientSize = tmp;
        InvalidateWindow();
        Width++;
        Width--;

        NativeMethods.LockWindowUpdate(IntPtr.Zero);
      }
    }

    void ControlStyleChanged()
    {
      elements = (ThemeFormElements)GetStyle();

      LeftBorderWidth = elements.LeftBorderSize;
      TopBorderHeight = elements.TopBorderSize;
      RightBorderWidth = elements.RightBorderSize;
      BottomBorderHeight = elements.BottomBorderSize;

      btnclose.Bounds = elements.CloseButtonRect(this.ClientRectangle);
      btnmax.Bounds = elements.MaximizeButtonRect(this.ClientRectangle);
      btnmin.Bounds = elements.MinimizeButtonRect(this.ClientRectangle);
    }

    object GetStyle(string Name)
    {
      if (controlstyledictionaries.ContainsKey(typeof(ThemeForm)))
      {
        if (controlstyledictionaries[typeof(ThemeForm)].ContainsKey(Name))
          return controlstyledictionaries[typeof(ThemeForm)][Name];

        foreach (string s in controlstyledictionaries[typeof(ThemeForm)].Keys)
          return controlstyledictionaries[typeof(ThemeForm)][s];
      }

      object[] tmp = typeof(ThemeForm).GetCustomAttributes(typeof(ThemeKitControl), false);

      if (tmp.Length == 1)
        return Activator.CreateInstance(((ThemeKitControl)tmp[0]).ElementsType);

      return null;
    }

    object GetStyle()
    {
      return GetStyle(style);
    }

    protected override Size SizeFromClientSize(int x, int y)
    {
      return new Size(x + elements.LeftBorderSize + elements.RightBorderSize, y + elements.TopBorderSize + elements.BottomBorderSize);
    }

    protected override void OnResize(EventArgs e)
    {
      btnclose.Bounds = elements.CloseButtonRect(this.ClientRectangle);
      btnmax.Bounds = elements.MaximizeButtonRect(this.ClientRectangle);
      btnmin.Bounds = elements.MinimizeButtonRect(this.ClientRectangle);

      base.OnResize(e);
    }

    public Dictionary<Type, Dictionary<string, object>> ControlStyleDictionaries
    {
      get { return controlstyledictionaries; }
    }

    protected override void SetVisibleCore(bool value)
    {
      if (value)
        show();
      else
        base.SetVisibleCore(false);
    }

    void show()
    {
      if (displayeffect == FormDisplayEffect.Fade)
      {
        base.Opacity = 0f;
        base.SetVisibleCore(true);

        Timer t = new Timer();
        t.Interval = fadeintime / fadesteps;
        t.Tick += new EventHandler(t_Tick);
        t.Enabled = true;
      }
      else if (displayeffect == FormDisplayEffect.None)
      {
        base.SetVisibleCore(true);
      }
    }

    void t_Tick(object sender, EventArgs e)
    {
      if ((base.Opacity + (destopacity / (double)fadesteps)) >= 1f)
      {
        ((Timer)sender).Enabled = false;
        base.Opacity = 1f;
        Application.DoEvents();
        return;
      }

      base.Opacity += (double)(destopacity / (double)fadesteps);
      Application.DoEvents();
    }

    int fadeintime = 500;
    double destopacity = 1f;
    int fadesteps = 20;
  }
}
