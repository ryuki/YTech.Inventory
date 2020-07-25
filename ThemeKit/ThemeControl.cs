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
using System.ComponentModel;

namespace BurtonSoftware.ThemeKit
{
  [ToolboxItem(false)]
  public class ThemeControl: Control
  {
    public ThemeControl()
    {
      this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
      base.BackColor = Color.Transparent;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      ThemeKit.SetGraphicsQuality(e.Graphics);
      DoPaint(new PaintEventArgs(e.Graphics, this.ClientRectangle));
    }

    protected virtual void DoPaint(PaintEventArgs e)
    {
    }

    public virtual ThemeForm Form
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

    string style;
    [EditorAttribute(typeof(ThemeStyleEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public string Style
    {
      get { return style; }
      set
      {
        if (Form != null)
        {
          style = Form.CheckStyle(this, value);
          ControlStyleChanged();
          Invalidate();
        }
        else
        {
          style = value;
        }
      }
    }

    protected virtual void ControlStyleChanged()
    {

    }

    protected object GetStyle(string Name)
    {
      if ((!string.IsNullOrEmpty(Name)) && (Form != null))
      {
        if (Form.controlstyledictionaries.ContainsKey(this.GetType()))
        {
          if (Form.controlstyledictionaries[this.GetType()].ContainsKey(Name))
            return Form.controlstyledictionaries[this.GetType()][Name];
        }
      }

      object[] tmp = this.GetType().GetCustomAttributes(typeof(ThemeKitControl), true);

      if (tmp.Length == 1)
      {
        return Activator.CreateInstance(((ThemeKitControl)tmp[0]).ElementsType);
      }

      return null;
    }

    protected object GetStyle()
    {
      return GetStyle(style);
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Color BackColor
    {
      get { return Color.Transparent; }
      set { base.BackColor = Color.Transparent; }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Color ForeColor
    {
      get { return base.ForeColor; }
      set { base.ForeColor = value; }
    }

    protected override void OnParentChanged(EventArgs e)
    {
      base.OnParentChanged(e);

      if (this.Form != null)
      {
        this.Style = style;
      }
    }
  }

  [ToolboxItem(false)]
  public class ThemeContainerControl : Panel
  {
    public ThemeContainerControl()
    {
      this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
      base.BackColor = Color.Transparent;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      ThemeKit.SetGraphicsQuality(e.Graphics);

      DoPaint(new PaintEventArgs(e.Graphics, this.ClientRectangle));
    }

    protected virtual void DoPaint(PaintEventArgs e)
    {
      e.Graphics.FillRectangle(Brushes.Red, e.ClipRectangle);
    }

    public ThemeForm Form
    {
      get
      {
        if (this.Parent is ThemeControl)
          return ((ThemeControl)this.Parent).Form;
        if (this.Parent is ThemeContainerControl)
          return ((ThemeContainerControl)this.Parent).Form;

        Control tmp = this;

        while ((tmp != null) && !(tmp is ThemeForm))
          tmp = tmp.Parent;

        return (ThemeForm)tmp;
      }
    }

    string style;
    [EditorAttribute(typeof(ThemeStyleEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public string Style
    {
      get { return style; }
      set
      {
        if (Form != null)
        {
          style = Form.CheckStyle(this, value);
          ControlStyleChanged();
          Invalidate();
        }
        else
        {
          style = value;
        }
      }
    }

    protected virtual void ControlStyleChanged()
    {

    }

    protected object GetStyle(string Name)
    {
      if (Form != null)
      {
        if (Form.controlstyledictionaries.ContainsKey(this.GetType()))
        {
          if (Form.controlstyledictionaries[this.GetType()].ContainsKey(Name))
            return Form.controlstyledictionaries[this.GetType()][Name];
        }
      }

      object[] tmp = this.GetType().GetCustomAttributes(typeof(ThemeKitControl), true);

      if (tmp.Length == 1)
      {
        return Activator.CreateInstance(((ThemeKitControl)tmp[0]).ElementsType);
      }

      return null;
    }

    protected object GetStyle()
    {
      return GetStyle(style);
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Color BackColor
    {
      get { return Color.Transparent; }
      set { base.BackColor = Color.Transparent; }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Color ForeColor
    {
      get { return base.ForeColor; }
      set { base.ForeColor = value; }
    }

    protected override void OnParentChanged(EventArgs e)
    {
      base.OnParentChanged(e);

      if (this.Form != null)
      {
        this.Style = style;
      }
    }

    public void CheckStyle()
    {
      if (Form == null)
        return;

      string s = Form.CheckStyle(this, this.style);

      if (s != this.style)
        this.Style = s;
    }
  }
}
