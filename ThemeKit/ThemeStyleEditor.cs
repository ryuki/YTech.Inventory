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
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.Windows.Forms;

namespace BurtonSoftware.ThemeKit
{
  internal class ThemeStyleEditor : UITypeEditor
  {
    public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
    {
      return UITypeEditorEditStyle.DropDown;
    }

    public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
    {
      IWindowsFormsEditorService editorService = null;

      if (provider != null)
        editorService = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;

      if (editorService != null)
      {
        ThemeStyleSelector s = new ThemeStyleSelector((Control)context.Instance, (string)value, editorService);
        editorService.DropDownControl(s);
        value = s.Value;
      }

      return value;
    }
  }

  [ToolboxItem(false)]
  public class ThemeStyleSelector : ListBox
  {
    IWindowsFormsEditorService editorService;

    public ThemeStyleSelector(Control Control, string Value, IWindowsFormsEditorService Editor)
    {
      editorService = Editor;

      Dictionary<string, object> d = null;

      ThemeForm frm = null;

      if (Control is ThemeForm)
        frm = (ThemeForm)Control;
      else if (Control is ThemeControl)
        frm = ((ThemeControl)Control).Form;
      else if (Control is ThemeContainerControl)
        frm = ((ThemeContainerControl)Control).Form;

      if (frm == null)
      {
        this.Items.Add("Unable to Find ThemeForm");
        return;
      }

      if (frm.controlstyledictionaries.ContainsKey(Control.GetType()))
        d = frm.controlstyledictionaries[Control.GetType()];

      if (d != null)
      {
        foreach (string s in d.Keys)
          this.Items.Add(s);
      }

      this.Value = Value;
    }

    public string Value
    {
      get
      {
        if (this.SelectedItem != null)
          return (string)this.SelectedItem;
        else
          return "";
      }
      set
      {
        int i = this.Items.IndexOf(value);
        this.SelectedIndex = i;
      }
    }

    protected override void OnClick(EventArgs e)
    {
      base.OnClick(e);

      editorService.CloseDropDown();
    }
  }
}
