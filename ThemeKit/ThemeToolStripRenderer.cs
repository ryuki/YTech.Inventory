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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;

namespace BurtonSoftware.ThemeKit
{
  internal class ThemeToolStripRenderer : ToolStripRenderer
  {
    private EventHandler _locationChangedEnventHandler;

    ThemeContextMenuStrip cms = null;
    ThemeStatusStrip ss = null;
    ThemeToolStrip ts = null;
    ThemeMenuStrip ms = null;

    public ThemeToolStripRenderer(Control c)
    {
      if (c is ThemeContextMenuStrip)
        cms = (ThemeContextMenuStrip)c;
      if (c is ThemeStatusStrip)
        ss = (ThemeStatusStrip)c;
      if (c is ThemeToolStrip)
        ts = (ThemeToolStrip)c;
      if (c is ThemeMenuStrip)
        ms = (ThemeMenuStrip)c;

      this._locationChangedEnventHandler = new EventHandler(this.ChildControlLocationChanged);
    }

    protected override void InitializePanel(ToolStripPanel toolStripPanel)
    {
      toolStripPanel.SizeChanged += new EventHandler(this.PanelSizeChanged);

      // Because many of the themes use gradients and so on, we need to refresh all toolbars event they simply moved.
      foreach (ToolStripPanelRow row in toolStripPanel.Rows)
      {
        foreach (ToolStrip toolStrip in row.Controls)
        {
          if (toolStrip != null)
          {
            this.ConnectToolStrip(toolStrip);
          }
        }
      }

      // This need to workaroud issue the Initalize does not invoked when using ToolStripManager.Renderer.
      toolStripPanel.ControlAdded += new ControlEventHandler(PanelControlAdded);
      toolStripPanel.ControlRemoved += new ControlEventHandler(PanelControlRemoved);

      base.InitializePanel(toolStripPanel);
    }

    private void DisconnectToolStrip(ToolStrip toolStrip)
    {
      if (toolStrip != null)
      {
        toolStrip.LocationChanged -= this._locationChangedEnventHandler;
      }
    }

    private void ConnectToolStrip(ToolStrip toolStrip)
    {
      if (toolStrip != null)
      {
        toolStrip.LocationChanged += this._locationChangedEnventHandler;
      }
    }

    private void PanelControlRemoved(object sender, ControlEventArgs e)
    {
      this.DisconnectToolStrip(e.Control as ToolStrip);
    }

    private void PanelControlAdded(object sender, ControlEventArgs e)
    {
      this.ConnectToolStrip(e.Control as ToolStrip);
    }

    private void ChildControlLocationChanged(object sender, EventArgs e)
    {
      Control control = sender as Control;
      if (control != null)
      {
        control.Parent.Invalidate(true);
      }
    }

    private void PanelSizeChanged(object sender, EventArgs e)
    {
      ToolStripPanel toolStripPanel = sender as ToolStripPanel;
      if (toolStripPanel != null)
      {
        toolStripPanel.Invalidate(true);
      }
    }

    protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
    {
      if (cms != null)
      {
        ThemeKit.DrawOrFill(cms.theme.NormalBackground, e.Graphics, e.AffectedBounds);
      }
      else if (ss != null)
      {
        if (e.ToolStrip is ToolStripDropDownMenu)
          ThemeKit.DrawOrFill(ss.theme.MenuNormalBackground, e.Graphics, e.AffectedBounds);
        else
          ThemeKit.DrawOrFill(ss.theme.NormalBackground, e.Graphics, e.AffectedBounds);
      }
      else if (ts != null)
      {
        if (e.ToolStrip is ToolStripDropDownMenu)
          ThemeKit.DrawOrFill(ts.theme.MenuNormalBackground, e.Graphics, e.AffectedBounds);
        else
          ThemeKit.DrawOrFill(ts.theme.NormalBackground, e.Graphics, e.AffectedBounds);
      }
      else if (ms != null)
      {
        if (e.ToolStrip is ToolStripDropDownMenu)
          ThemeKit.DrawOrFill(ms.theme.MenuNormalBackground, e.Graphics, e.AffectedBounds);
        else
          ThemeKit.DrawOrFill(ms.theme.NormalBackground, e.Graphics, e.AffectedBounds);
      }
    }

    protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
    {
      Rectangle rect = new Rectangle(0, 0, e.Item.Width, e.Item.Height);

      if (cms != null)
      {
        if (!e.Item.Enabled)
          ThemeKit.DrawOrFill(cms.theme.DisabledItemBackground, e.Graphics, rect);
        else if (e.Item.Selected)
          ThemeKit.DrawOrFill(cms.theme.OverItemBackground, e.Graphics, rect);
        else
          ThemeKit.DrawOrFill(cms.theme.NormalItemBackground, e.Graphics, rect);
      }
      else if (ts != null)
      {
        if (!e.Item.Enabled)
          ThemeKit.DrawOrFill(ts.theme.MenuDisabledItemBackground, e.Graphics, rect);
        else if (e.Item.Selected)
          ThemeKit.DrawOrFill(ts.theme.MenuOverItemBackground, e.Graphics, rect);
        else
          ThemeKit.DrawOrFill(ts.theme.MenuNormalItemBackground, e.Graphics, rect);
      }
      else if (ss != null)
      {
        if (!e.Item.Enabled)
          ThemeKit.DrawOrFill(ss.theme.MenuDisabledItemBackground, e.Graphics, rect);
        else if (e.Item.Selected)
          ThemeKit.DrawOrFill(ss.theme.MenuOverItemBackground, e.Graphics, rect);
        else
          ThemeKit.DrawOrFill(ss.theme.MenuNormalItemBackground, e.Graphics, rect);
      }
      else if (ms != null)
      {
        if (e.ToolStrip is ToolStripDropDownMenu)
        {
          if (!e.Item.Enabled)
            ThemeKit.DrawOrFill(ms.theme.MenuDisabledItemBackground, e.Graphics, rect);
          else if (e.Item.Selected)
            ThemeKit.DrawOrFill(ms.theme.MenuOverItemBackground, e.Graphics, rect);
          else
            ThemeKit.DrawOrFill(ms.theme.MenuNormalItemBackground, e.Graphics, rect);
        }
        else
        {
          if (!e.Item.Enabled)
            ThemeKit.DrawOrFill(ms.theme.DisabledItemBackground, e.Graphics, rect);
          else if (e.Item.Pressed)
            ThemeKit.DrawOrFill(ms.theme.DownItemBackground, e.Graphics, rect);
          else if (e.Item.Selected)
            ThemeKit.DrawOrFill(ms.theme.OverItemBackground, e.Graphics, rect);
          else
            ThemeKit.DrawOrFill(ms.theme.NormalItemBackground, e.Graphics, rect);
        }
      }
    }

    protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
    {
      if (cms != null)
      {
        if (!e.Item.Enabled)
        {
          if (cms.theme.DisabledItemText.Length > 0)
            e.TextColor = cms.theme.DisabledItemText[0].Colors[0];
        }
        else if (e.Item.Selected)
        {
          if (cms.theme.OverItemText.Length > 0)
            e.TextColor = cms.theme.OverItemText[0].Colors[0];
        }
        else
        {
          if (cms.theme.NormalItemText.Length > 0)
            e.TextColor = cms.theme.NormalItemText[0].Colors[0];
        }
      }
      else if (ss != null)
      {
        if (e.Item is ToolStripMenuItem)
        {
          if (!e.Item.Enabled)
          {
            if (ss.theme.MenuDisabledItemText.Length > 0)
              e.TextColor = ss.theme.MenuDisabledItemText[0].Colors[0];
          }
          else if (e.Item.Selected)
          {
            if (ss.theme.MenuOverItemText.Length > 0)
              e.TextColor = ss.theme.MenuOverItemText[0].Colors[0];
          }
          else
          {
            if (ss.theme.MenuNormalItemText.Length > 0)
              e.TextColor = ss.theme.MenuNormalItemText[0].Colors[0];
          }
        }
        else
        {
          if (ss.theme.NormalLabelText.Length > 0)
            e.TextColor = ss.theme.NormalLabelText[0].Colors[0];
        }
      }
      else if (ts != null)
      {
        if (e.Item is ToolStripMenuItem)
        {
          if (!e.Item.Enabled)
          {
            if (ts.theme.MenuDisabledItemText.Length > 0)
              e.TextColor = ts.theme.MenuDisabledItemText[0].Colors[0];
          }
          else if (e.Item.Selected)
          {
            if (ts.theme.MenuOverItemText.Length > 0)
              e.TextColor = ts.theme.MenuOverItemText[0].Colors[0];
          }
          else
          {
            if (ts.theme.MenuNormalItemText.Length > 0)
              e.TextColor = ts.theme.MenuNormalItemText[0].Colors[0];
          }
        }
        else
        {
          if (ts.theme.NormalLabelText.Length > 0)
            e.TextColor = ts.theme.NormalLabelText[0].Colors[0];
        }
      }
      else if (ms != null)
      {
        if (e.ToolStrip is ToolStripDropDownMenu)
        {
          if (!e.Item.Enabled)
          {
            if (ms.theme.MenuDisabledItemText.Length > 0)
              e.TextColor = ms.theme.MenuDisabledItemText[0].Colors[0];
          }
          else if (e.Item.Selected)
          {
            if (ms.theme.MenuOverItemText.Length > 0)
              e.TextColor = ms.theme.MenuOverItemText[0].Colors[0];
          }
          else
          {
            if (ms.theme.MenuNormalItemText.Length > 0)
              e.TextColor = ms.theme.MenuNormalItemText[0].Colors[0];
          }
        }
        else
        {
          if (!e.Item.Enabled)
          {
            if (ms.theme.DisabledItemText.Length > 0)
              e.TextColor = ms.theme.DisabledItemText[0].Colors[0];
          }
          else if (e.Item.Selected)
          {
            if (ms.theme.OverItemText.Length > 0)
              e.TextColor = ms.theme.OverItemText[0].Colors[0];
          }
          else
          {
            if (ms.theme.NormalItemText.Length > 0)
              e.TextColor = ms.theme.NormalItemText[0].Colors[0];
          }
        }
      }

      base.OnRenderItemText(e);
    }

    protected override void OnRenderItemBackground(ToolStripItemRenderEventArgs e)
    {
      Rectangle rect = new Rectangle(0, 0, e.Item.Width, e.Item.Height);

      e.Graphics.FillRectangle(Brushes.Yellow, rect);
    }

    protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
    {
      Rectangle rect = new Rectangle(0, 0, e.Item.Width, e.Item.Height);

      if (ts != null)
      {
        if (!e.Item.Enabled)
          ThemeKit.DrawOrFill(ts.theme.ButtonDisabledBackground, e.Graphics, rect);
        else if (e.Item.Pressed)
          ThemeKit.DrawOrFill(ts.theme.ButtonDownBackground, e.Graphics, rect);
        else if (e.Item.Selected)
          ThemeKit.DrawOrFill(ts.theme.ButtonOverBackground, e.Graphics, rect);
        else
          ThemeKit.DrawOrFill(ts.theme.ButtonNormalBackground, e.Graphics, rect);
      }
    }

    protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
    {
      Rectangle rect = new Rectangle(0, 0, e.Item.Width, e.Item.Height);

      if (ts != null)
      {
        if (!e.Item.Enabled)
          ThemeKit.DrawOrFill(ts.theme.DropDownButtonDisabledBackground, e.Graphics, rect);
        else if (e.Item.Pressed)
          ThemeKit.DrawOrFill(ts.theme.DropDownButtonDownBackground, e.Graphics, rect);
        else if (e.Item.Selected)
          ThemeKit.DrawOrFill(ts.theme.DropDownButtonOverBackground, e.Graphics, rect);
        else
          ThemeKit.DrawOrFill(ts.theme.DropDownButtonNormalBackground, e.Graphics, rect);
      }
    }

    protected override void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e)
    {
      Rectangle rect = new Rectangle(0, 0, e.Item.Width, e.Item.Height);

      if (ts != null)
      {
        if (!e.Item.Enabled)
          ThemeKit.DrawOrFill(ts.theme.SplitButtonDisabledBackground, e.Graphics, rect);
        else if (e.Item.Pressed)
          ThemeKit.DrawOrFill(ts.theme.SplitButtonDownBackground, e.Graphics, rect);
        else if (e.Item.Selected)
          ThemeKit.DrawOrFill(ts.theme.SplitButtonOverBackground, e.Graphics, rect);
        else
          ThemeKit.DrawOrFill(ts.theme.SplitButtonNormalBackground, e.Graphics, rect);
      }
    }

    protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
    {
      Rectangle rect = new Rectangle(0, 0, e.Item.Width, e.Item.Height);

      if (cms != null)
      {
        ThemeKit.DrawOrFill(cms.theme.Seperator, e.Graphics, rect);
      }
      else if (ts != null)
      {
        if (e.Item is ToolStripMenuItem)
          ThemeKit.DrawOrFill(ts.theme.MenuSeperator, e.Graphics, rect);
      }
      else if (ss != null)
      {
        if (e.Item is ToolStripMenuItem)
          ThemeKit.DrawOrFill(ss.theme.MenuSeperator, e.Graphics, rect);
      }
      else if (ms != null)
      {
        if (e.Item is ToolStripMenuItem)
          ThemeKit.DrawOrFill(ms.theme.MenuSeperator, e.Graphics, rect);
      }
    }
  }
}
