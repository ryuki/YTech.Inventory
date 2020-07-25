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
using System.Drawing.Design;
using System.ComponentModel;
using System.Drawing;

namespace BurtonSoftware.ThemeKit
{
  internal class ThemeToolStripElements
  {
    public ExBrush[] NormalBackground = new ExBrush[0];
    public ExBrush[] NormalLabelText = new ExBrush[0];

    public ExBrush[] MenuNormalBackground = new ExBrush[0];

    public ExBrush[] MenuNormalItemBackground = new ExBrush[0];
    public ExBrush[] MenuOverItemBackground = new ExBrush[0];
    public ExBrush[] MenuDisabledItemBackground = new ExBrush[0];

    public ExBrush[] MenuNormalItemText = new ExBrush[0];
    public ExBrush[] MenuOverItemText = new ExBrush[0];
    public ExBrush[] MenuDisabledItemText = new ExBrush[0];

    public ExBrush[] MenuSeperator = new ExBrush[0];

    public ExBrush[] ButtonNormalBackground = new ExBrush[0];
    public ExBrush[] ButtonOverBackground = new ExBrush[0];
    public ExBrush[] ButtonDownBackground = new ExBrush[0];
    public ExBrush[] ButtonDisabledBackground = new ExBrush[0];

    public ExBrush[] DropDownButtonNormalBackground = new ExBrush[0];
    public ExBrush[] DropDownButtonOverBackground = new ExBrush[0];
    public ExBrush[] DropDownButtonDownBackground = new ExBrush[0];
    public ExBrush[] DropDownButtonDisabledBackground = new ExBrush[0];

    public ExBrush[] SplitButtonNormalBackground = new ExBrush[0];
    public ExBrush[] SplitButtonOverBackground = new ExBrush[0];
    public ExBrush[] SplitButtonDownBackground = new ExBrush[0];
    public ExBrush[] SplitButtonDisabledBackground = new ExBrush[0];
  }

  [ThemeKitControl("ToolStrip", typeof(ThemeToolStripElements))]
  [ToolboxItem(true)]
  public class ThemeToolStrip: ToolStrip
  {
    string style;

    internal ThemeToolStripElements theme = new ThemeToolStripElements();

    public ThemeToolStrip()
    {
      ThemeToolStripRenderer rndr = new ThemeToolStripRenderer(this);

      base.Renderer = rndr;

      base.BackColor = Color.Transparent;
    }

    public ThemeToolStrip(IContainer container) : this()
    {
      container.Add(this);
    }

    protected virtual void ControlStyleChanged()
    {
      theme = (ThemeToolStripElements)GetStyle();
    }

    protected override void OnParentChanged(EventArgs e)
    {
      base.OnParentChanged(e);

      if (this.Form != null)
      {
        this.Style = style;
      }
    }

    public new ToolStripRenderer Renderer
    {
      get { return base.Renderer; }
      set { }
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

        Control tmp = this.Parent;

        while ((tmp != null) && !(tmp is ThemeForm))
          tmp = tmp.Parent;

        return (ThemeForm)tmp;
      }
    }

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
        }
        else
        {
          style = value;
        }
      }
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
  }
}
