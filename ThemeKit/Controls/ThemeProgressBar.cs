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
using System.Drawing.Design;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace BurtonSoftware.ThemeKit
{
  internal class ThemeProgressBarElements
  {
    public ExBrush[] NormalBackground = new ExBrush[0];
    public ExBrush[] NormalProgress = new ExBrush[0];
  }

  [ToolboxItem(true)]
  [ThemeKitControl("ProgressBar", typeof(ThemeProgressBarElements))]
  public class ThemeProgressBar: ThemeControl
  {
    ThemeProgressBarElements theme = new ThemeProgressBarElements();

    public ThemeProgressBar()
    {

    }

    protected override void ControlStyleChanged()
    {
      theme = (ThemeProgressBarElements)GetStyle();
    }

    protected override void DoPaint(PaintEventArgs e)
    {
      ThemeKit.DrawOrFill(theme.NormalBackground, e.Graphics, e.ClipRectangle);

      int pw = (int)((float)((float)val / (float)(max - min)) * (float)e.ClipRectangle.Width);
      Rectangle prect = new Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y, pw, e.ClipRectangle.Height);
      ThemeKit.DrawOrFill(theme.NormalProgress, e.Graphics, prect);
    }

    int min = 0;
    [DefaultValue(0)]
    public int Minimum
    {
      get { return min; }
      set
      { 
        min = value;
        Invalidate();
      }
    }

    int max = 100;
    [DefaultValue(100)]
    public int Maximum
    {
      get { return max; }
      set 
      { 
        max = value; 
        Invalidate(); 
      }
    }

    int val = 50;
    [DefaultValue(50)]
    public int Value
    {
      get { return val; }
      set 
      { 
        val = value; 
        Invalidate(); 
      }
    }
  }
}
