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
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms.VisualStyles;

namespace BurtonSoftware.ThemeKit
{
  internal class ThemeButtonElements
  {
    public ExBrush[] NormalBackground = new ExBrush[0];
    public ExBrush[] OverBackground = new ExBrush[0];
    public ExBrush[] DownBackground = new ExBrush[0];

    public ExBrush[] NormalText = new ExBrush[0];
    public ExBrush[] OverText = new ExBrush[0];
    public ExBrush[] DownText = new ExBrush[0];

    public bool OverFade = false;
    public float OverFadeMin = 0f;
    public float OverFadeMax = 1f;
    public int OverFadeSteps = 0;

    public bool DownFade = false;
    public float DownFadeMin = 0f;
    public float DownFadeMax = 1f;
    public int DownFadeSteps = 0;
  }

  [ThemeKitControl("Button", typeof(ThemeButtonElements))]
  [ToolboxItem(true)]
  public class ThemeButton : ThemeControl
  {
    public enum DropDownPosition { Left, Top, Right, Bottom }

    private int overfadeid;
    private int downfadeid;

    private float overfadeprogress;
    private float downfadeprogress;

    private ContextMenuStrip dropdown;
    private DropDownPosition dropdownpos = DropDownPosition.Right;
    private int dropdownsize = 10;

    private ThemeButtonElements elements = new ThemeButtonElements();

    public ThemeButton()
    {
      overfadeid = FadeScheduler.CreateFade(new EventHandler<FadeEventArgs>(this.FadeChanged), 0.2f, 0f, 1f);
      downfadeid = FadeScheduler.CreateFade(new EventHandler<FadeEventArgs>(this.FadeChanged), 0.2f, 0f, 1f);
    }

    protected override Size DefaultSize
    {
      get { return new Size(75, 23); }
    }

    protected override void ControlStyleChanged()
    {
      elements = (ThemeButtonElements)GetStyle();

      if (!elements.OverFade)
      {
        elements.OverFadeMin = 0f;
        elements.OverFadeMax = 1f;
        elements.OverFadeSteps = 1;
        overfadeprogress = 0f;
      }

      if (!elements.DownFade)
      {
        elements.DownFadeMin = 0f;
        elements.DownFadeMax = 1f;
        elements.DownFadeSteps = 1;
        downfadeprogress = 0f;
      }

      FadeScheduler.UpdateFade(overfadeid, ((elements.OverFadeMax - elements.OverFadeMin) / elements.OverFadeSteps), elements.OverFadeMin, elements.OverFadeMax);
      FadeScheduler.UpdateFade(downfadeid, ((elements.DownFadeMax - elements.DownFadeMin) / elements.DownFadeSteps), elements.DownFadeMin, elements.DownFadeMax);
    }

    void FadeChanged(object sender, FadeEventArgs e)
    {
      if (e.FadeID == overfadeid)
        overfadeprogress = e.Progress;
      else
        downfadeprogress = e.Progress;

      Invalidate();
    }

    protected override void DoPaint(PaintEventArgs e)
    {
      Rectangle rect = this.ClientRectangle;

      ThemeKit.DrawOrFill(elements.NormalBackground, e.Graphics, rect);
      ThemeKit.DrawOrFill(elements.OverBackground, e.Graphics, rect, overfadeprogress);
      ThemeKit.DrawOrFill(elements.DownBackground, e.Graphics, rect, downfadeprogress);

      if (dropdown != null)
      {
        switch (dropdownpos)
        {
          case DropDownPosition.Bottom:
            rect.Height -= dropdownsize;
            break;
          case DropDownPosition.Left:
            rect.Offset(dropdownsize, 0);
            rect.Width -= dropdownsize;
            break;
          case DropDownPosition.Right:
            rect.Width -= dropdownsize;
            break;
          case DropDownPosition.Top:
            rect.Offset(0, dropdownsize);
            rect.Height -= dropdownsize;
            break;
        }

        ThemeKit.DrawOrFill(elements.NormalBackground, e.Graphics, rect);
        ThemeKit.DrawOrFill(elements.OverBackground, e.Graphics, rect, overfadeprogress);
        ThemeKit.DrawOrFill(elements.DownBackground, e.Graphics, rect, downfadeprogress);
      }

      Image img = null;

      if (this.Image != null)
        img = this.Image;
      else if (this.ImageList != null && this.ImageIndex > -1)
        img = this.ImageList.Images[this.ImageIndex];

      ThemeKit.DrawContent(this.Text, img, TextAlign, ImageAlign, elements.NormalText, e.Graphics, rect, this.Font);
      ThemeKit.DrawContent(this.Text, img, TextAlign, ImageAlign, elements.OverText, e.Graphics, rect, this.Font, overfadeprogress);
      ThemeKit.DrawContent(this.Text, img, TextAlign, ImageAlign, elements.DownText, e.Graphics, rect, this.Font, downfadeprogress);
    }

    protected override void OnMouseEnter(EventArgs e)
    {
      FadeScheduler.SetFadeType(overfadeid, FadeType.In);

      base.OnMouseEnter(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
      isoverdropdown = false;

      FadeScheduler.SetFadeType(overfadeid, FadeType.Out);

      base.OnMouseLeave(e);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      FadeScheduler.SetFadeType(downfadeid, FadeType.In);

      base.OnMouseDown(e);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      FadeScheduler.SetFadeType(downfadeid, FadeType.Out);

      base.OnMouseUp(e);
    }

    [DefaultValue(ThemeButton.DropDownPosition.Bottom)]
    public DropDownPosition DropDownAlignment
    {
      get { return dropdownpos; }
      set
      {
        dropdownpos = value;
        Invalidate();
      }
    }

    public ContextMenuStrip DropDown
    {
      get { return dropdown; }
      set
      {
        dropdown = value;
        Invalidate();
      }
    }

    [DefaultValue(10)]
    public int DropDownSize
    {
      get { return dropdownsize; }
      set
      {
        dropdownsize = value;
        Invalidate();
      }
    }

    System.Drawing.ContentAlignment txtalign = System.Drawing.ContentAlignment.MiddleCenter;
    [DefaultValue(System.Drawing.ContentAlignment.MiddleCenter)]
    public System.Drawing.ContentAlignment TextAlign
    {
      get { return txtalign; }
      set { txtalign = value; }
    }

    System.Drawing.ContentAlignment imgalign = System.Drawing.ContentAlignment.MiddleCenter;
    [DefaultValue(System.Drawing.ContentAlignment.MiddleCenter)]
    public System.Drawing.ContentAlignment ImageAlign
    {
      get { return imgalign; }
      set { imgalign = value; }
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

    bool isoverdropdown;
    protected override void OnMouseMove(MouseEventArgs e)
    {
      bool prev = isoverdropdown;

      if (dropdown != null)
      {
        switch (dropdownpos)
        {
          case DropDownPosition.Top:
            isoverdropdown = e.Y <= dropdownsize;
            break;
          case DropDownPosition.Bottom:
            isoverdropdown = e.Y >= this.Height - dropdownsize;
            break;
          case DropDownPosition.Left:
            isoverdropdown = e.X <= dropdownsize;
            break;
          case DropDownPosition.Right:
            isoverdropdown = e.X >= this.Width - dropdownsize;
            break;
        }
      }
      else
        isoverdropdown = false;

      base.OnMouseMove(e);

      if (isoverdropdown != prev)
        Invalidate();
    }

    protected override void OnClick(EventArgs e)
    {
      if ((isoverdropdown || this.Click == null) && (dropdown != null))
      {
        dropdown.Show(PointToScreen(new Point(0, this.Height)));
      }
      else
      {
        if (this.Click != null)
          this.Click(this, EventArgs.Empty);
      }
    }

    [DefaultValue(false), Browsable(true)]
    public new bool AutoSize
    {
      get { return base.AutoSize; }
      set { base.AutoSize = value; }
    }

    public new event EventHandler Click;
  }
}
