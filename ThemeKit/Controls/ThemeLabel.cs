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
  internal class ThemeLabelElements
  {
    public ExBrush[] NormalText = new ExBrush[0];
  }

  [ThemeKitControl("Label", typeof(ThemeLabelElements))]
  [ToolboxItem(true)]
  public class ThemeLabel : ThemeControl
  {
    ThemeLabelElements elements = new ThemeLabelElements();

    protected override void DoPaint(PaintEventArgs e)
    {
      Image img = null;

      if (this.Image != null)
        img = this.Image;
      else if (this.ImageList != null && this.ImageIndex > -1)
        img = this.ImageList.Images[this.ImageIndex];

      ThemeKit.DrawContent(this.Text, img, TextAlign, ImageAlign, elements.NormalText, e.Graphics, this.ClientRectangle, this.Font);
    }

    void UpdateSize()
    {
      if (!autosize)
        return;

      StringFormat sf = new StringFormat();

      if (TextAlign.ToString().StartsWith("Top"))
        sf.LineAlignment = StringAlignment.Near;
      else if (TextAlign.ToString().StartsWith("Middle"))
        sf.LineAlignment = StringAlignment.Center;
      else
        sf.LineAlignment = StringAlignment.Far;

      if (TextAlign.ToString().EndsWith("Center"))
        sf.Alignment = StringAlignment.Center;
      else if (TextAlign.ToString().EndsWith("Left"))
        sf.Alignment = StringAlignment.Near;
      else
        sf.Alignment = StringAlignment.Far;

      Bitmap bmp = new Bitmap(10, 10);
      using (Graphics g = Graphics.FromImage(bmp))
      {
        SizeF s = g.MeasureString(this.Text, this.Font, Screen.PrimaryScreen.WorkingArea.Width, sf);

        this.Width = (int)s.Width;
        this.Height = (int)s.Height;
      }
      bmp.Dispose();
    }

    protected override void ControlStyleChanged()
    {
      elements = (ThemeLabelElements)GetStyle();
    }

    public override string Text
    {
      get { return base.Text; }
      set
      {
        base.Text = value;
        UpdateSize();
        Invalidate();
      }
    }

    Image img;
    public Image Image
    {
      get { return img; }
      set { img = value; }
    }

    ImageList imglist;
    public ImageList ImageList
    {
      get { return imglist; }
      set { imglist = value; }
    }

    int imgindex;
    public int ImageIndex
    {
      get { return imgindex; }
      set { imgindex = value; }
    }

    System.Drawing.ContentAlignment txtalign = System.Drawing.ContentAlignment.MiddleCenter;
    [DefaultValue(System.Drawing.ContentAlignment.MiddleCenter)]
    public System.Drawing.ContentAlignment TextAlign
    {
      get { return txtalign; }
      set
      { 
        txtalign = value;
        UpdateSize();
      }
    }

    System.Drawing.ContentAlignment imgalign = System.Drawing.ContentAlignment.MiddleCenter;
    [DefaultValue(System.Drawing.ContentAlignment.MiddleCenter)]
    public System.Drawing.ContentAlignment ImageAlign
    {
      get { return imgalign; }
      set { imgalign = value; }
    }

    bool autosize;
    public override bool AutoSize
    {
      get { return autosize; }
      set
      {
        autosize = value;
        UpdateSize();
      }
    }
  }
}
