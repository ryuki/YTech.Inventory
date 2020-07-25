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

namespace BurtonSoftware.ThemeKit
{
  internal class ThemeContextMenuStripElements
  {
    public ExBrush[] NormalBackground = new ExBrush[0];

    public ExBrush[] NormalItemBackground = new ExBrush[0];
    public ExBrush[] OverItemBackground = new ExBrush[0];
    public ExBrush[] DisabledItemBackground = new ExBrush[0];

    public ExBrush[] NormalItemText = new ExBrush[0];
    public ExBrush[] OverItemText = new ExBrush[0];
    public ExBrush[] DisabledItemText = new ExBrush[0];

    public ExBrush[] Seperator = new ExBrush[0];
  }

  [ThemeKitControl("ContextMenuStrip", typeof(ThemeContextMenuStripElements))]
  [ToolboxItem(true)]
  public class ThemeContextMenuStrip: ContextMenuStrip
  {
    string style;

    internal ThemeContextMenuStripElements theme = new ThemeContextMenuStripElements();

    public ThemeContextMenuStrip()
    {
      this.Opening += new CancelEventHandler(ThemeContextMenuStrip_Opening);

      ThemeToolStripRenderer rndr = new ThemeToolStripRenderer(this);

      

      base.Renderer = rndr;
    }

    public ThemeContextMenuStrip(IContainer container) : this()
    {
      container.Add(this);
    }

    void ThemeContextMenuStrip_Opening(object sender, CancelEventArgs e)
    {
      if (this.Form != null)
        this.Style = style;
    }

    protected virtual void ControlStyleChanged()
    {
      theme = (ThemeContextMenuStripElements)GetStyle();
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
        if (this.SourceControl is ThemeControl)
          return ((ThemeControl)this.SourceControl).Form;
        if (this.SourceControl is ThemeContainerControl)
          return ((ThemeContainerControl)this.SourceControl).Form;
        if (this.SourceControl is ThemeForm)
          return (ThemeForm)this.SourceControl;

        Control tmp = this.SourceControl;

        while ((tmp != null) && !(tmp is ThemeForm))
          tmp = tmp.Parent;

        if (tmp == null)
        {
          foreach (ThemeForm frm in ThemeKit.forms)
          {
            if (frm.Contains(this))
              return frm;

            if (ThisIsContextMenuStrip(frm))
              return frm;
          }
        }

        return (ThemeForm)tmp;
      }
    }

    bool ThisIsContextMenuStrip(Control c)
    {
      if (c.ContextMenuStrip == this)
        return true;

      foreach (Control child in c.Controls)
      {
        bool stop = ThisIsContextMenuStrip(child);

        if (stop)
          return true;
      }

      return false;
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
