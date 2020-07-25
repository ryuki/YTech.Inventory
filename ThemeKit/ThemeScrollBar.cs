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

namespace BurtonSoftware.ThemeKit
{
  internal class ThemeScrollBar: ThemeControl
  {
    public ExBrush[] VerticalNormalBackground = new ExBrush[0];
    public ExBrush[] VerticalOverBackground = new ExBrush[0];
    public ExBrush[] VerticalDownBackground = new ExBrush[0];

    public ExBrush[] VerticalNormalUpButton = new ExBrush[0];
    public ExBrush[] VerticalNormalDownButton = new ExBrush[0];
    public ExBrush[] VerticalDisabledUpButton = new ExBrush[0];
    public ExBrush[] VerticalDisabledDownButton = new ExBrush[0];
    public ExBrush[] VerticalOverUpButton = new ExBrush[0];
    public ExBrush[] VerticalOverDownButton = new ExBrush[0];
    public ExBrush[] VerticalDownUpButton = new ExBrush[0];
    public ExBrush[] VerticalDownDownButton = new ExBrush[0];

    public int VerticalUpButtonSize = 20;
    public int VerticalDownButtonSize = 20;

    public ThemeScrollBarOrientation Orientation = ThemeScrollBarOrientation.Vertical;

    public ThemeScrollBar()
    {
      overfade = FadeScheduler.CreateFade(new EventHandler<FadeEventArgs>(this.FadeChanged), 1f, 0f, 1f);
      downfade = FadeScheduler.CreateFade(new EventHandler<FadeEventArgs>(this.FadeChanged), 1f, 0f, 1f);
    }

    void FadeChanged(object sender, FadeEventArgs e)
    {
      if (e.FadeID == overfade)
        overfadeprogress = e.Progress;
      else if (e.FadeID == downfade)
        downfadeprogress = e.Progress;

      Invalidate();
    }

    protected override void DoPaint(PaintEventArgs e)
    {
      if (Orientation == ThemeScrollBarOrientation.Vertical)
      {
        ThemeKit.DrawOrFill(VerticalNormalBackground, e.Graphics, e.ClipRectangle);
        ThemeKit.DrawOrFill(VerticalOverBackground, e.Graphics, e.ClipRectangle, overfadeprogress);
        ThemeKit.DrawOrFill(VerticalDownBackground, e.Graphics, e.ClipRectangle, downfadeprogress);

        Rectangle upbtnrect = new Rectangle(e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width, VerticalUpButtonSize);
        Rectangle dwnbtnrect = new Rectangle(e.ClipRectangle.Left, e.ClipRectangle.Bottom - VerticalDownButtonSize, e.ClipRectangle.Width, VerticalDownButtonSize);
        Rectangle bararearect = new Rectangle(e.ClipRectangle.Left, e.ClipRectangle.Top + VerticalUpButtonSize, e.ClipRectangle.Width, e.ClipRectangle.Height - VerticalUpButtonSize - VerticalDownButtonSize);

        ThemeKit.DrawOrFill(VerticalNormalUpButton, e.Graphics, upbtnrect);


        ThemeKit.DrawOrFill(VerticalNormalDownButton, e.Graphics, dwnbtnrect);
      }
      else if (Orientation == ThemeScrollBarOrientation.Horizontal)
      {

      }
    }

    bool mouseover;
    bool mousedown;
    int overfade;
    int downfade;
    float overfadeprogress;
    float downfadeprogress;

    protected override void OnMouseMove(MouseEventArgs e)
    {
      mouseover = true;
      FadeScheduler.SetFadeType(overfade, FadeType.In);

      base.OnMouseMove(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
      mouseover = false;
      FadeScheduler.SetFadeType(overfade, FadeType.Out);

      base.OnMouseLeave(e);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      mousedown = true;
      FadeScheduler.SetFadeType(downfade, FadeType.In);

      base.OnMouseDown(e);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      mousedown = false;
      FadeScheduler.SetFadeType(downfade, FadeType.Out);

      base.OnMouseUp(e);
    }
  }

  internal enum ThemeScrollBarOrientation { Horizontal, Vertical }
}
