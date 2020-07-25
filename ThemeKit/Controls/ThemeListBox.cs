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
using System.Drawing.Design;

namespace BurtonSoftware.ThemeKit
{
  internal class ThemeListBoxElements
  {
    public ExBrush[] NormalBackground = new ExBrush[0];

    public ExBrush[] NormalItemBackground = new ExBrush[0];
    public ExBrush[] OverItemBackrgound = new ExBrush[0];
    public ExBrush[] SelectedItemBackground = new ExBrush[0];

    public ExBrush[] NormalItemText = new ExBrush[0];

    #region Vertical ScrollBar
    public ExBrush[] VerticalScrollBarNormalBackground = new ExBrush[0];
    public ExBrush[] VerticalScrollBarOverBackground = new ExBrush[0];
    public ExBrush[] VerticalScrollBarDownBackground = new ExBrush[0];

    public ExBrush[] VerticalScrollBarNormalUpButton = new ExBrush[0];
    public ExBrush[] VerticalScrollBarNormalDownButton = new ExBrush[0];
    public ExBrush[] VerticalScrollBarDisabledUpButton = new ExBrush[0];
    public ExBrush[] VerticalScrollBarDisabledDownButton = new ExBrush[0];
    public ExBrush[] VerticalScrollBarOverUpButton = new ExBrush[0];
    public ExBrush[] VerticalScrollBarOverDownButton = new ExBrush[0];
    public ExBrush[] VerticalScrollBarDownUpButton = new ExBrush[0];
    public ExBrush[] VerticalScrollBarDownDownButton = new ExBrush[0];

    public int VerticalScrollBarSize = 20;
    public int VerticalScrollBarUpButtonSize = 20;
    public int VerticalScrollBarDownButtonSize = 20;
    #endregion
  }

  [ToolboxItem(true)]
  [ThemeKitControl("ListBox", typeof(ThemeListBoxElements))]
  public class ThemeListBox: ThemeControl
  {
    ThemeListBoxElements theme = new ThemeListBoxElements();

    int firstdisplayeditem = 0;
    int overindex = 0;

    List<Rectangle> itemboundrects = new List<Rectangle>();

    public event EventHandler SelectedIndexChanged;

    ThemeScrollBar vscroll;

    public ThemeListBox()
    {
      items = new ThemeListBoxItemCollection(this);

      vscroll = new ThemeScrollBar();
      vscroll.Parent = this;
    }

    protected override void ControlStyleChanged()
    {
      theme = (ThemeListBoxElements)GetStyle();

      vscroll.VerticalNormalBackground = theme.VerticalScrollBarNormalBackground;
      vscroll.VerticalOverBackground = theme.VerticalScrollBarOverBackground;
      vscroll.VerticalDownBackground = theme.VerticalScrollBarDownBackground;

      vscroll.VerticalNormalUpButton = theme.VerticalScrollBarNormalUpButton;
      vscroll.VerticalNormalDownButton = theme.VerticalScrollBarNormalDownButton;
      vscroll.VerticalDisabledUpButton = theme.VerticalScrollBarDisabledUpButton;
      vscroll.VerticalDisabledDownButton = theme.VerticalScrollBarDisabledDownButton;
      vscroll.VerticalOverUpButton = theme.VerticalScrollBarOverUpButton;
      vscroll.VerticalOverDownButton = theme.VerticalScrollBarOverDownButton;
      vscroll.VerticalDownUpButton = theme.VerticalScrollBarDownUpButton;
      vscroll.VerticalDownDownButton = theme.VerticalScrollBarDownDownButton;

      vscroll.VerticalUpButtonSize = theme.VerticalScrollBarUpButtonSize;
      vscroll.VerticalDownButtonSize = theme.VerticalScrollBarDownButtonSize;
    }

    protected override void DoPaint(PaintEventArgs e)
    {
      ThemeKit.DrawOrFill(theme.NormalBackground, e.Graphics, e.ClipRectangle);

      if (firstdisplayeditem < 0)
        firstdisplayeditem = 0;
      if (firstdisplayeditem > (items.Count - 1))
        firstdisplayeditem = items.Count - 1;

      int y = e.ClipRectangle.Y + 2;

      vscroll.Width = theme.VerticalScrollBarSize;
      vscroll.Left = this.Width - vscroll.Width;
      vscroll.Top = 0;
      vscroll.Height = this.Height;

      int i = 0;
      foreach (object obj in items)
      {
        Rectangle rect = new Rectangle(e.ClipRectangle.X + 2, y, e.ClipRectangle.Width - 4 - vscroll.Width, itemheight);
        itemboundrects.Add(rect);

        if (rect.Y >= e.ClipRectangle.Height)
          continue;

        PaintItem(i, obj, rect, e.Graphics);
        y += itemheight;
        i++;
      }
    }

    void PaintItem(int i, object item, Rectangle bounds, Graphics g)
    {
      if (i == selectedindex)
        ThemeKit.DrawOrFill(theme.SelectedItemBackground, g, bounds);
      else if (i == overindex)
        ThemeKit.DrawOrFill(theme.OverItemBackrgound, g, bounds);
      else
        ThemeKit.DrawOrFill(theme.NormalItemBackground, g, bounds);

      ThemeKit.DrawContent(item.ToString(), null, ContentAlignment.MiddleLeft, ContentAlignment.TopLeft, theme.NormalItemText, g, bounds, font);
    }

    protected override void OnMouseClick(MouseEventArgs e)
    {
      for (int i = 0; i < items.Count; i++)
      {
        if (itemboundrects[i].Contains(e.Location))
        {
          if (selectedindex != i)
          {
            selectedindex = i;
            Invalidate();

            if (SelectedIndexChanged != null)
              SelectedIndexChanged(this, EventArgs.Empty);
          }

          break;
        }
      }

      base.OnMouseClick(e);
    }

    ThemeListBoxItemCollection items;
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
    public ThemeListBoxItemCollection Items
    {
      get { return items; }
    }

    int itemheight = 20;
    public int ItemHeight
    {
      get { return itemheight; }
      set { itemheight = value; }
    }

    Font font = SystemFonts.DefaultFont;
    public override Font Font
    {
      get { return font; }
      set { font = value; }
    }

    int selectedindex = -1;
    [DefaultValue(-1)]
    public int SelectedIndex
    {
      get { return selectedindex; }
      set
      { 
        selectedindex = value;
        Invalidate();
      }
    }
  }

  public class ThemeListBoxItemCollection : List<object>
  {
    ThemeListBox listbox;

    public ThemeListBoxItemCollection(ThemeListBox listbox)
    {
      this.listbox = listbox;
    }

    public new void Add(object item)
    {
      base.Add(item);
      listbox.Invalidate();
    }

    public new void AddRange(IEnumerable<object> collection)
    {
      base.AddRange(collection);
      listbox.Invalidate();
    }

    public new void Remove(object item)
    {
      base.Remove(item);
      listbox.Invalidate();
    }

    public new void RemoveAt(int index)
    {
      base.RemoveAt(index);
      listbox.Invalidate();
    }
  }
}
