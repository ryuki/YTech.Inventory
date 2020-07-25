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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;
using System.Globalization;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace BurtonSoftware.ThemeKit
{
  public class ExBrush
  {
    public enum PathType { Rectangle, Ellipse, RoundedRectangle, TopRoundedRectangle, Text, Line }
    public enum BrushType { Fill, Outline }
    public enum FillType { Stretch, Repeat, RepeatVertical }

    private BrushType type;

    private List<Color> colors;
    private List<float> positions;

    private LinearGradientMode mode;

    private int penwidth;

    private PathType pathtype;
    private int roundrectsizetl;
    private int roundrectsizetr;
    private int roundrectsizebl;
    private int roundrectsizebr;

    private int pathfntsize;
    private int pathfntstyle;
    private string pathtxt;
    private StringFormat pathstrfmt;

    private string left;
    private string top;
    private string width;
    private string height;

    private string clipl;
    private string clipt;
    private string clipw;
    private string cliph;

    private string x1;
    private string x2;
    private string y1;
    private string y2;

    private int? inflatex;
    private int? inflatey;

    private Dictionary<string, Stream> files;

    private string imgname;
    private Image image;
    private Color imgtranscolor;

    private FillType filltype;

    private bool halo;
    private int halosize;
    private int haloxoffset;
    private int haloyoffset;
    private Color halocolor;

    public ExBrush(XmlNode node, Dictionary<string, Stream> files)
    {
      this.files = files;

      colors = new List<Color>();
      positions = new List<float>();

      colors.Add(Color.Black);
      positions.Add(0f);

      mode = LinearGradientMode.Vertical;

      secondalpha = 255;

      if (node != null)
        LoadXml(node);
    }

    public ExBrush() : this(null, new Dictionary<string, Stream>()) { }

    public Brush GetBrush(Rectangle rect)
    {
      rect = GetRect(rect);
      rect.Width++;
      rect.Height++;

      ColorBlend blend = new ColorBlend();
      blend.Colors = Colors;
      blend.Positions = Positions;

      LinearGradientBrush tmp = new LinearGradientBrush(rect, Color.Transparent, Color.Transparent, mode);
      tmp.InterpolationColors = blend;

      return tmp;
    }

    public Brush GetBrush(Size size)
    {
      return GetBrush(new Rectangle(0, 0, size.Width, size.Height));
    }

    public Brush GetBrush(int width, int height)
    {
      return GetBrush(new Rectangle(0, 0, width, height));
    }

    public Pen GetPen(Rectangle rect)
    {
      return new Pen(GetBrush(rect), penwidth);
    }

    public Pen GetPen(Size size)
    {
      return GetPen(new Rectangle(0, 0, size.Width, size.Height));
    }

    public Pen GetPen(int width, int height)
    {
      return GetPen(new Rectangle(0, 0, width, height));
    }

    public Color[] Colors
    {
      get
      {
        if (colors.Count == 1)
        {
          int newalpha = (int)(((float)secondalpha / (float)255) * (float)colors[0].A);
          return new Color[] { Color.FromArgb(newalpha, colors[0]), Color.FromArgb(newalpha, colors[0]) };
        }

        Color[] tmpcolors = new Color[colors.Count];

        for (int i = 0; i < tmpcolors.Length; i++)
        {
          int newalpha = (int)(((float)secondalpha / (float)255) * (float)colors[i].A);
          tmpcolors[i] = Color.FromArgb(newalpha, colors[i]);
        }

        return tmpcolors;
      }
      set
      {
        colors.Clear();
        colors.AddRange(value);
      }
    }

    public float[] Positions
    {
      get
      {
        if (positions.Count == 1)
        {
          return new float[] { 0f, 1f };
        }

        float[] tmppositions = new float[positions.Count];
        positions.CopyTo(tmppositions);
        return tmppositions;
      }
      set
      {
        positions.Clear();
        positions.AddRange(value);
      }
    }

    public string ImageFile
    {
      get { return imgname; }
      set
      {
        imgname = value;

        if (!files.ContainsKey(value))
        {
          image = null;
          return;
        }

        image = Image.FromStream(files[value]);
      }
    }

    public Dictionary<string, Stream> Files
    {
      get { return files; }
      set
      {
        files = value;
        ImageFile = imgname;
      }
    }

    public LinearGradientMode GradientMode
    {
      get { return mode; }
      set { mode = value; }
    }

    public BrushType Type
    {
      get { return type; }
      set { type = value; }
    }

    public void LoadXml(XmlNode node)
    {
      colors.Clear();
      positions.Clear();

      mode = LinearGradientMode.Vertical;

      penwidth = 1;

      pathtype = PathType.Rectangle;

      type = BrushType.Fill;

      left = "";
      top = "";
      width = "";
      height = "";

      clipl = "";
      clipt = "";
      clipw = "";
      cliph = "";

      inflatex = null;
      inflatey = null;

      imgname = "";
      image = null;
      imgtranscolor = Color.Transparent;

      filltype = FillType.Stretch;

      if (node.Attributes["Type"] != null)
        type = (BrushType)Enum.Parse(typeof(BrushType), node.Attributes["Type"].Value);

      if (type == BrushType.Outline && node.Attributes["Size"] != null)
        penwidth = int.Parse(node.Attributes["Size"].Value);

      if (node["Location"] != null)
      {
        if (node["Location"].Attributes["Left"] != null)
          left = node["Location"].Attributes["Left"].Value;

        if (node["Location"].Attributes["Top"] != null)
          top = node["Location"].Attributes["Top"].Value;
      }

      if (node["Size"] != null)
      {
        if (node["Size"].Attributes["Width"] != null)
          width = node["Size"].Attributes["Width"].Value;

        if (node["Size"].Attributes["Height"] != null)
          height = node["Size"].Attributes["Height"].Value;

        if (node["Size"].Attributes["Inflate"] != null)
        {
          inflatex = int.Parse(node["Size"].Attributes["Inflate"].Value);
          inflatey = int.Parse(node["Size"].Attributes["Inflate"].Value);
        }

        if (node["Size"].Attributes["InflateX"] != null)
          inflatex = int.Parse(node["Size"].Attributes["InflateX"].Value);

        if (node["Size"].Attributes["InflateY"] != null)
          inflatey = int.Parse(node["Size"].Attributes["InflateY"].Value);

        if (node["Size"].Attributes["FillMode"] != null)
          filltype = (FillType)Enum.Parse(typeof(FillType), node["Size"].Attributes["FillMode"].Value);
      }

      if (node["Clip"] != null)
      {
        if (node["Clip"].Attributes["Left"] != null)
          clipl = node["Clip"].Attributes["Left"].Value;

        if (node["Clip"].Attributes["Top"] != null)
          clipt = node["Clip"].Attributes["Top"].Value;

        if (node["Clip"].Attributes["Width"] != null)
          clipw = node["Clip"].Attributes["Width"].Value;

        if (node["Clip"].Attributes["Height"] != null)
          cliph = node["Clip"].Attributes["Height"].Value;
      }

      if (node["Path"] != null)
      {
        XmlElement pathnode = node["Path"];

        if (pathnode.Attributes["Type"] == null)
          return;

        pathtype = (PathType)Enum.Parse(typeof(PathType), pathnode.Attributes["Type"].Value);

        if (pathtype == PathType.RoundedRectangle || pathtype == PathType.TopRoundedRectangle)
        {
          if (pathnode.Attributes["Size"] != null)
          {
            roundrectsizetl = int.Parse(pathnode.Attributes["Size"].Value);
            roundrectsizetr = roundrectsizetl;
            roundrectsizebl = roundrectsizetl;
            roundrectsizebr = roundrectsizetl;
          }

          if (pathnode.Attributes["SizeTL"] != null)
            roundrectsizetl = int.Parse(pathnode.Attributes["SizeTL"].Value);
          if (pathnode.Attributes["SizeTR"] != null)
            roundrectsizetl = int.Parse(pathnode.Attributes["SizeTR"].Value);
          if (pathnode.Attributes["SizeBL"] != null)
            roundrectsizetl = int.Parse(pathnode.Attributes["SizeBL"].Value);
          if (pathnode.Attributes["SizeBR"] != null)
            roundrectsizetl = int.Parse(pathnode.Attributes["SizeBR"].Value);
        }
        else if (pathtype == PathType.Text)
        {
          pathfntsize = 10;
          pathfntstyle = (int)FontStyle.Regular;
          pathtxt = "";
          pathstrfmt = new StringFormat();

          if (pathnode.Attributes["Size"] != null)
            pathfntsize = int.Parse(pathnode.Attributes["Size"].Value);

          if (pathnode.Attributes["Style"] != null)
            pathfntstyle = int.Parse(pathnode.Attributes["Style"].Value);

          if (pathnode.Attributes["Text"] != null)
            pathtxt = pathnode.Attributes["Text"].Value;

          if (pathnode.Attributes["Align"] != null)
            pathstrfmt.Alignment = (StringAlignment)Enum.Parse(typeof(StringAlignment), pathnode.Attributes["Align"].Value);

          if (pathnode.Attributes["LineAlign"] != null)
            pathstrfmt.LineAlignment = (StringAlignment)Enum.Parse(typeof(StringAlignment), pathnode.Attributes["LineAlign"].Value);
        }
        else if (pathtype == PathType.Line)
        {
          x1 = "";
          x2 = "";
          y1 = "";
          y2 = "";

          if (pathnode.Attributes["X1"] != null)
            x1 = pathnode.Attributes["X1"].Value;

          if (pathnode.Attributes["X2"] != null)
            x2 = pathnode.Attributes["X2"].Value;

          if (pathnode.Attributes["Y1"] != null)
            y1 = pathnode.Attributes["Y1"].Value;

          if (pathnode.Attributes["Y2"] != null)
            y2 = pathnode.Attributes["Y2"].Value;
        }
      }

      XmlElement halonode = node["Halo"];

      if (halonode != null)
      {
        halo = true;

        if (halonode.Attributes["Color"] != null)
          halocolor = ReadColor(halonode.Attributes["Color"].Value);

        if (halonode.Attributes["Size"] != null)
          halosize = int.Parse(halonode.Attributes["Size"].Value);

        if (halonode.Attributes["XOffset"] != null)
          haloxoffset = int.Parse(halonode.Attributes["XOffset"].Value);

        if (halonode.Attributes["YOffset"] != null)
          haloyoffset = int.Parse(halonode.Attributes["YOffset"].Value);
      }

      if (node["Colors"] == null)
      {
        if (node.Attributes["Image"] != null)
        {
          imgname = node.Attributes["Image"].Value;

          if (files != null && files.ContainsKey(imgname) && (files[imgname] != null))
            image = Image.FromStream(files[imgname]);

          if (node.Attributes["Transparent"] != null)
          {
            imgtranscolor = ReadColor(node.Attributes["Transparent"].Value);

            if (image is Bitmap)
              ((Bitmap)image).MakeTransparent(imgtranscolor);
          }
        }

        if (node.Attributes["Color"] == null)
          return;

        colors.Add(ReadColor(node.Attributes["Color"].Value));
        colors.Add(colors[0]);

        positions.Add(0f);
        positions.Add(1f);

        return;
      }

      XmlNode colorsnode = node["Colors"];

      if (colorsnode.Attributes["Mode"] != null)
        mode = (LinearGradientMode)Enum.Parse(typeof(LinearGradientMode), colorsnode.Attributes["Mode"].Value);

      foreach (XmlNode color in colorsnode)
      {
        if (color.Attributes["Position"] == null)
          continue;

        colors.Add(ReadColor(color.InnerText));
        positions.Add(ReadPosition(color.Attributes["Position"].Value));
      }
    }

    public void SaveXml(XmlNode node)
    {
      XmlDocument xml = node.OwnerDocument;

      XmlAttribute att = xml.CreateAttribute("Type");
      att.Value = this.type.ToString();
      node.Attributes.Append(att);

      if (!string.IsNullOrEmpty(this.imgname))
      {
        att = xml.CreateAttribute("Image");
        att.Value = imgname;
        node.Attributes.Append(att);
      }
      else if (this.colors.Count == 2 && (this.colors[0] == this.colors[1]))
      {
        att = xml.CreateAttribute("Color");
        att.Value = ColorToString(colors[0]);
        node.Attributes.Append(att);
      }
      else
      {
        XmlElement colors = xml.CreateElement("Colors");

        if (this.mode != LinearGradientMode.Vertical)
        {
          att = xml.CreateAttribute("Mode");
          att.Value = this.mode.ToString();
          colors.Attributes.Append(att);
        }

        int i = 0;
        foreach (Color c in this.colors)
        {
          XmlElement color = xml.CreateElement("Color");

          att = xml.CreateAttribute("Position");
          att.Value = this.positions[i].ToString();
          color.Attributes.Append(att);

          color.InnerText = ColorToString(c);
          colors.AppendChild(color);

          i++;
        }

        node.AppendChild(colors);
      }

      if (!string.IsNullOrEmpty(this.left) || !string.IsNullOrEmpty(this.top))
      {
        XmlElement location = xml.CreateElement("Location");

        if (!string.IsNullOrEmpty(this.left))
        {
          att = xml.CreateAttribute("Left");
          att.Value = this.left;
          location.Attributes.Append(att);
        }
        if (!string.IsNullOrEmpty(this.top))
        {
          att = xml.CreateAttribute("Top");
          att.Value = this.top;
          location.Attributes.Append(att);
        }

        node.AppendChild(location);
      }

      if (!string.IsNullOrEmpty(this.width) || !string.IsNullOrEmpty(this.height) || (this.inflatex != null) || (this.inflatey != null))
      {
        XmlElement size = xml.CreateElement("Size");

        if (!string.IsNullOrEmpty(this.width))
        {
          att = xml.CreateAttribute("Width");
          att.Value = this.width;
          size.Attributes.Append(att);
        }
        if (!string.IsNullOrEmpty(this.height))
        {
          att = xml.CreateAttribute("Height");
          att.Value = this.height;
          size.Attributes.Append(att);
        }
        if (this.inflatex != null)
        {
          if (this.inflatey != null && this.inflatey.Value == this.inflatex.Value)
          {
            att = xml.CreateAttribute("Inflate");
            att.Value = this.inflatex.Value.ToString();
            size.Attributes.Append(att);
          }
          else
          {
            att = xml.CreateAttribute("InflateX");
            att.Value = this.inflatex.Value.ToString();
            size.Attributes.Append(att);
          }
        }
        else if (this.inflatey != null)
        {
          att = xml.CreateAttribute("InflateY");
          att.Value = this.inflatey.Value.ToString();
          size.Attributes.Append(att);
        }

        node.AppendChild(size);
      }

      if (this.pathtype != PathType.Rectangle)
      {
        XmlElement path = xml.CreateElement("Path");

        att = xml.CreateAttribute("Type");
        att.Value = this.pathtype.ToString();
        path.Attributes.Append(att);

        switch (pathtype)
        {
          case PathType.Ellipse:

            break;

          case PathType.Line:

            att = xml.CreateAttribute("X1");
            att.Value = this.x1.ToString();
            path.Attributes.Append(att);

            att = xml.CreateAttribute("X2");
            att.Value = this.x2.ToString();
            path.Attributes.Append(att);

            att = xml.CreateAttribute("Y1");
            att.Value = this.y1.ToString();
            path.Attributes.Append(att);

            att = xml.CreateAttribute("Y2");
            att.Value = this.y2.ToString();
            path.Attributes.Append(att);

            break;

          case PathType.RoundedRectangle:

            if (roundrectsizetl == roundrectsizetr && roundrectsizetl  == roundrectsizebl  && roundrectsizetl == roundrectsizebr)
            {
              att = xml.CreateAttribute("Size");
              att.Value = this.roundrectsizetl.ToString();
              path.Attributes.Append(att);
            }
            else
            {
              att = xml.CreateAttribute("SizeTL");
              att.Value = this.roundrectsizetl.ToString();
              path.Attributes.Append(att);

              att = xml.CreateAttribute("SizeTR");
              att.Value = this.roundrectsizetr.ToString();
              path.Attributes.Append(att);

              att = xml.CreateAttribute("SizeBL");
              att.Value = this.roundrectsizebl.ToString();
              path.Attributes.Append(att);

              att = xml.CreateAttribute("SizeBR");
              att.Value = this.roundrectsizebr.ToString();
              path.Attributes.Append(att);
            }

            break;

          case PathType.Text:

            att = xml.CreateAttribute("Size");
            att.Value = this.pathfntsize.ToString();
            path.Attributes.Append(att);

            att = xml.CreateAttribute("Style");
            att.Value = this.pathfntstyle.ToString();
            path.Attributes.Append(att);

            att = xml.CreateAttribute("Text");
            att.Value = this.pathtxt;
            path.Attributes.Append(att);

            att = xml.CreateAttribute("Align");
            att.Value = this.pathstrfmt.Alignment.ToString();
            path.Attributes.Append(att);

            att = xml.CreateAttribute("LineAlign");
            att.Value = this.pathstrfmt.LineAlignment.ToString();
            path.Attributes.Append(att);

            break;

          case PathType.TopRoundedRectangle:

            if (roundrectsizetl == roundrectsizetr)
            {
              att = xml.CreateAttribute("Size");
              att.Value = this.roundrectsizetl.ToString();
              path.Attributes.Append(att);
            }
            else
            {
              att = xml.CreateAttribute("SizeTL");
              att.Value = this.roundrectsizetl.ToString();
              path.Attributes.Append(att);

              att = xml.CreateAttribute("SizeTR");
              att.Value = this.roundrectsizetr.ToString();
              path.Attributes.Append(att);
            }

            break;
        }

        node.AppendChild(path);
      }
    }

    private string ColorToString(Color c)
    {
      return IntToString(c.A) + IntToString(c.R) + IntToString(c.G) + IntToString(c.B);
    }

    private string IntToString(int i)
    {
      string s = i.ToString();

      while (s.Length < 3)
        s = "0" + s;

      return s;
    }

    private Color ReadColor(string str)
    {
      if (typeof(Color).GetProperty(str) != null)
        return Color.FromName(str);

      if (str.Length == 8)
      {
        int a = int.Parse(str.Substring(0, 2), NumberStyles.HexNumber);
        int r = int.Parse(str.Substring(2, 2), NumberStyles.HexNumber);
        int g = int.Parse(str.Substring(4, 2), NumberStyles.HexNumber);
        int b = int.Parse(str.Substring(8, 2), NumberStyles.HexNumber);

        return Color.FromArgb(a, r, g, b);
      }
      else if (str.Length == 12)
      {
        int a = int.Parse(str.Substring(0, 3));
        int r = int.Parse(str.Substring(3, 3));
        int g = int.Parse(str.Substring(6, 3));
        int b = int.Parse(str.Substring(9, 3));

        return Color.FromArgb(a, r, g, b);
      }

      return Color.Black;
    }

    private float ReadPosition(string str)
    {
      return float.Parse(str);
    }

    public Rectangle GetRect(Rectangle rect)
    {
      if (!string.IsNullOrEmpty(left))
      {
        if (left.StartsWith("L+"))
          rect.Location = new Point(rect.Left + int.Parse(left.Substring(2, left.Length - 2)), rect.Top);
        else if (left.StartsWith("W-"))
          rect.Location = new Point(rect.Width - int.Parse(left.Substring(2, left.Length - 2)), rect.Top);
        else
          rect.Location = new Point(int.Parse(left), rect.Top);
      }
      if (!string.IsNullOrEmpty(top))
      {
        if (top.StartsWith("T+"))
          rect.Location = new Point(rect.Left, rect.Top + int.Parse(top.Substring(2, top.Length - 2)));
        else if (top.StartsWith("H-"))
          rect.Location = new Point(rect.Left, rect.Height - int.Parse(top.Substring(2, top.Length - 2)));
        else
          rect.Location = new Point(rect.Left, int.Parse(top));
      }
      if (!string.IsNullOrEmpty(width))
      {
        if (width.EndsWith("%"))
        {
          int percent = int.Parse(width.Substring(0, width.Length - 1));
          float multiplier = (float)percent / (float)100f;

          rect.Width = (int)((float)rect.Width * multiplier);
        }
        else if (width.StartsWith("W+"))
        {
          rect.Width = rect.Width + int.Parse(width.Substring(2));
        }
        else if (width.StartsWith("W-"))
        {
          rect.Width = rect.Width - int.Parse(width.Substring(2));
        }
        else
        {
          rect.Width = int.Parse(width);
        }
      }
      if (!string.IsNullOrEmpty(height))
      {
        if (height.EndsWith("%"))
        {
          int percent = int.Parse(height.Substring(0, height.Length - 1));
          float multiplier = (float)percent / (float)100f;

          rect.Height = (int)((float)rect.Height * multiplier);
        }
        else if (height.StartsWith("H+"))
        {
          rect.Height = rect.Height + int.Parse(height.Substring(2));
        }
        else if (height.StartsWith("H-"))
        {
          rect.Height = rect.Height - int.Parse(height.Substring(2));
        }
        else
        {
          rect.Height = int.Parse(height);
        }
      }

      if (inflatex != null)
        rect.Inflate(inflatex.Value, 0);
      if (inflatey != null)
        rect.Inflate(0, inflatey.Value);

      if (rect.Width <= 0)
        rect.Width = 1;
      if (rect.Height <= 0)
        rect.Height = 1;

      return rect;
    }

    public GraphicsPath GetPath(Rectangle r)
    {
      Rectangle rect = GetRect(r);

      GraphicsPath tmp = new GraphicsPath();

      if (pathtype == PathType.Rectangle)
        tmp.AddRectangle(rect);
      else if (pathtype == PathType.Ellipse)
        tmp.AddEllipse(rect);
      else if (pathtype == PathType.RoundedRectangle)
      {
        tmp.AddArc(rect.X, rect.Y, roundrectsizetl, roundrectsizetl, 180, 90);
        tmp.AddArc(rect.X + rect.Width - roundrectsizetr, rect.Y, roundrectsizetr, roundrectsizetr, 270, 90);
        tmp.AddArc(rect.X + rect.Width - roundrectsizebr, rect.Y + rect.Height - roundrectsizebr, roundrectsizebr, roundrectsizebr, 0, 90);
        tmp.AddArc(rect.X, rect.Y + rect.Height - roundrectsizebl, roundrectsizebl, roundrectsizebl, 90, 90);
      }
      else if (pathtype == PathType.TopRoundedRectangle)
      {
        tmp.AddArc(rect.X, rect.Y, roundrectsizetl, roundrectsizetl, 180, 90);
        tmp.AddArc(rect.X + rect.Width - roundrectsizetr, rect.Y, roundrectsizetr, roundrectsizetr, 270, 90);
        tmp.AddLine(rect.X + rect.Width, rect.Y + rect.Height, rect.X, rect.Y + rect.Height);
      }
      else if (pathtype == PathType.Text)
      {
        tmp.AddString(pathtxt, FontFamily.GenericSansSerif, pathfntstyle, pathfntsize, rect, pathstrfmt);
      }
      else if (pathtype == PathType.Line)
      {
        tmp.AddLine(GetPoint(x1, y1, rect), GetPoint(x2, y2, rect));
      }

      tmp.CloseFigure();

      return tmp;
    }

    public GraphicsPath GetPath(Size size)
    {
      return GetPath(new Rectangle(0, 0, size.Width, size.Height));
    }

    public GraphicsPath GetPath(int x, int y, int w, int h)
    {
      return GetPath(new Rectangle(x, y, w, h));
    }

    public GraphicsPath GetPath(int w, int h)
    {
      return GetPath(0, 0, w, h);
    }

    private Point GetPoint(string xstr, string ystr, Rectangle rect)
    {
      int x = 0;
      int y = 0;

      if (!string.IsNullOrEmpty(xstr))
      {
        if (xstr.StartsWith("W-"))
        {
          x = rect.Left + rect.Width - int.Parse(xstr.Substring(2));
        }
        else if (xstr.StartsWith("W+"))
        {
          x = rect.Left + rect.Width + int.Parse(xstr.Substring(2));
        }
        else if (xstr.EndsWith("%"))
        {
          int percent = int.Parse(xstr.Substring(0, xstr.Length - 1));
          float multiplier = (float)percent / (float)100f;
          x = rect.Left + (int)((float)rect.Width * multiplier);
        }
        else
          x = int.Parse(xstr);
      }
      if (!string.IsNullOrEmpty(ystr))
      {
        if (ystr.StartsWith("H-"))
        {
          y = rect.Top + rect.Height - int.Parse(ystr.Substring(2));
        }
        else if (ystr.StartsWith("H+"))
        {
          y = rect.Top + rect.Height + int.Parse(ystr.Substring(2));
        }
        else if (ystr.EndsWith("%"))
        {
          int percent = int.Parse(ystr.Substring(0, ystr.Length - 1));
          float multiplier = (float)percent / (float)100f;
          y = rect.Top + (int)((float)rect.Height * multiplier);
        }
        else
          y = int.Parse(ystr);
      }

      return new Point(x, y);
    }

    public void SetClip(Graphics g, Rectangle r)
    {
      if (string.IsNullOrEmpty(clipw) || string.IsNullOrEmpty(cliph))
        return;

      int l = 0;
      int t = 0;
      int w = 0;
      int h = 0;

      if (!string.IsNullOrEmpty(clipl))
      {
        l = int.Parse(clipl);
      }
      if (!string.IsNullOrEmpty(clipt))
      {
        t = int.Parse(clipt);
      }

      w = int.Parse(clipw);
      h = int.Parse(cliph);

      Region rgn = g.Clip;

      if (rgn != null)
        rgn.Intersect(new Region(new Rectangle(l, t, w, h)));
      else
        rgn = new Region(new Rectangle(l, t, w, h));

      g.Clip = rgn;
    }

    public void Draw(Graphics g, Rectangle r)
    {
      r.Width--;
      r.Height--;

      Region tmp = g.Clip;
      SetClip(g, r);

      if (!string.IsNullOrEmpty(imgname))
      {
        if (image != null)
        {
          g.Clip = new Region(GetPath(r));
          r = GetRect(r);
          g.DrawImage(image, r);
        }
      }
      else
        g.DrawPath(GetPen(r), GetPath(r));

      g.Clip = tmp;
    }

    public void Fill(Graphics g, Rectangle r)
    {
      //r.Offset(-1, -1);
      //r.Width++;
      //r.Height++;

      Region tmp = g.Clip;
      SetClip(g, r);

      if (!string.IsNullOrEmpty(imgname))
      {
        if (image != null)
        {
          if (filltype == FillType.Stretch)
          {
            Region rgn = g.Clip;

            if (rgn != null)
              rgn.Intersect(new Region(GetPath(r)));
            else
              rgn = new Region(GetPath(r));

            g.Clip = rgn;

            r = GetRect(r);

            if (secondalpha != 255)
            {
              ColorMatrix cm = new ColorMatrix();
              cm.Matrix33 = ((float)secondalpha / (float)255);

              ImageAttributes ia = new ImageAttributes();
              ia.SetColorMatrix(cm);

              g.DrawImage(image, r, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, ia);

              ia.Dispose();
            }
            else
              g.DrawImage(image, r);
          }
          else if (filltype == FillType.Repeat)
          {
            Region rgn = g.Clip;

            if (rgn != null)
              rgn.Intersect(new Region(GetPath(r)));
            else
              rgn = new Region(GetPath(r));

            g.Clip = rgn;

            r = GetRect(r);

            int x = r.Right - image.Width;

            while (x > r.Left)
            {
              if (secondalpha != 255)
              {
                ColorMatrix cm = new ColorMatrix();
                cm.Matrix33 = ((float)secondalpha / (float)255);

                ImageAttributes ia = new ImageAttributes();
                ia.SetColorMatrix(cm);

                g.DrawImage(image, new Rectangle(x, r.Top, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, ia);

                ia.Dispose();
              }
              else
                g.DrawImage(image, x, r.Top, image.Width, r.Height);

              x -= image.Width;
            }

            if (secondalpha != 255)
            {
              ColorMatrix cm = new ColorMatrix();
              cm.Matrix33 = ((float)secondalpha / (float)255);

              ImageAttributes ia = new ImageAttributes();
              ia.SetColorMatrix(cm);

              g.DrawImage(image, new Rectangle(r.Left, r.Top, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, ia);

              ia.Dispose();
            }
            else
              g.DrawImage(image, r.Left, r.Top, image.Width, r.Height);
          }
          else if (filltype == FillType.RepeatVertical)
          {
            Region rgn = g.Clip;

            if (rgn != null)
              rgn.Intersect(new Region(GetPath(r)));
            else
              rgn = new Region(GetPath(r));

            g.Clip = rgn;

            r = GetRect(r);

            int y = r.Bottom - image.Height;

            while (y > r.Top)
            {
              if (secondalpha != 255)
              {
                ColorMatrix cm = new ColorMatrix();
                cm.Matrix33 = ((float)secondalpha / (float)255);

                ImageAttributes ia = new ImageAttributes();
                ia.SetColorMatrix(cm);

                g.DrawImage(image, new Rectangle(r.Left, y, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, ia);

                ia.Dispose();
              }
              else
                g.DrawImage(image, r.Left, y, r.Width, image.Height);

              y -= image.Height;
            }

            if (secondalpha != 255)
            {
              ColorMatrix cm = new ColorMatrix();
              cm.Matrix33 = ((float)secondalpha / (float)255);

              ImageAttributes ia = new ImageAttributes();
              ia.SetColorMatrix(cm);

              g.DrawImage(image, new Rectangle(r.Left, r.Top, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, ia);

              ia.Dispose();
            }
            else
              g.DrawImage(image, r.Left, r.Top, r.Width, image.Height);
          }
        }
      }
      else
        g.FillPath(GetBrush(r), GetPath(r));

      g.Clip = tmp;
    }

    public void DrawOrFill(Graphics g, Rectangle r)
    {
      if (this.type == BrushType.Outline)
        Draw(g, r);
      else
        Fill(g, r);
    }

    public void DrawText(Graphics g, Rectangle r, string Text, Font f, StringFormat sf)
    {
      if (!string.IsNullOrEmpty(imgname))
      {
        if (image != null)
        {
          GraphicsPath p = new GraphicsPath();
          p.AddString(Text, f.FontFamily, (int)f.Style, (int)((float)f.Size * 1.33f), r, sf);
          g.Clip = new Region(p);
          r = GetRect(r);
          g.DrawImage(image, r);
        }
      }
      else
      {
        if (halo)
        {
          DrawHaloText(g, Text, f, colors[0], halocolor, halosize, r);
        }
        else
          g.DrawString(Text, f, GetBrush(r), r, sf);
      }
    }

    public void DrawText(Graphics g, Rectangle r, string Text, Font f)
    {
      StringFormat sf = new StringFormat();
      sf.Alignment = StringAlignment.Center;
      sf.LineAlignment = StringAlignment.Center;

      DrawText(g, r, Text, f, sf);
    }

    public static void DrawHaloText(Graphics g, string strText, Font fnt, Color clrFore, Color clrBack, int blurAmount, Rectangle rect)
    {
      SizeF sz = g.MeasureString(strText, fnt);

      using (SolidBrush brBack = new SolidBrush(clrBack))
      using (SolidBrush brFore = new SolidBrush(clrFore))
      {
        for (int x = rect.Left; x <= rect.Left + blurAmount; x++)
          for (int y = rect.Top; y <= rect.Top + blurAmount; y++)
            g.DrawString(strText, fnt, brBack, x, y);

        g.DrawString(strText, fnt, brFore, rect.Left + (blurAmount / 2), rect.Top + (blurAmount / 2));
      }
    }

    int secondalpha = 255;
    public void SetAlpha(int a)
    {
      if (a > 255 || a < 0)
        return;

      secondalpha = a;
    }

    public string Left
    {
      get { return left; }
      set { left = value; }
    }

    public string Top
    {
      get { return top; }
      set { top = value; }
    }

    public string Width
    {
      get { return width; }
      set { width = value; }
    }

    public string Height
    {
      get { return height; }
      set { height = value; }
    }
  }
}