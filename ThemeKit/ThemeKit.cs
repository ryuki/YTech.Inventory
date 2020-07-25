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
using System.Xml;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using BurtonSoftware.UI;
using System.Drawing.Imaging;
using System.Reflection;
using System.IO;
using System.Threading;
using ionic.utils.zip;

namespace BurtonSoftware.ThemeKit
{
  public static class ThemeKit
  {
    internal static List<ThemeForm> forms;

    static ThemeKit()
    {
      forms = new List<ThemeForm>();
    }

    internal static void SetGraphicsQuality(Graphics g)
    {
      g.CompositingMode = CompositingMode.SourceOver;
      g.CompositingQuality = CompositingQuality.HighQuality;
      g.InterpolationMode = InterpolationMode.High;
      g.PixelOffsetMode = PixelOffsetMode.None;
      g.SmoothingMode = SmoothingMode.HighQuality;
      g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
    }

    internal static void DrawOrFill(ExBrush[] brushes, Graphics g, Rectangle rect)
    {
      foreach (ExBrush brush in brushes)
      {
        brush.DrawOrFill(g, rect);
      }
    }

    internal static void DrawOrFill(ExBrush[] brushes, Graphics g, Rectangle rect, int alpha)
    {
      foreach (ExBrush brush in brushes)
      {
        brush.SetAlpha(alpha);
        brush.DrawOrFill(g, rect);
      }
    }

    internal static void DrawOrFill(ExBrush[] brushes, Graphics g, Rectangle rect, float f)
    {
      DrawOrFill(brushes, g, rect, (int)((float)f * (float)255));
    }

    internal static void DrawContent(string Text, Image Image, ContentAlignment TextAlign, ContentAlignment ImageAlign, ExBrush[] brushes, Graphics g, Rectangle r, Font f)
    {
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

      foreach (ExBrush brush in brushes)
        brush.DrawText(g, r, Text, f, sf);

      if (Image != null && (Image.Width * Image.Height > 0))
      {
        Rectangle imgrect = r;
        imgrect = HAlignWithin(Image.Size, imgrect, ImageAlign);
        imgrect = VAlignWithin(Image.Size, imgrect, ImageAlign);

        g.DrawImage(Image, imgrect);
      }


    }

    internal static void DrawContent(string Text, Image Image, ContentAlignment TextAlign, ContentAlignment ImageAlign, ExBrush[] brushes, Graphics g, Rectangle r, Font f, int alpha)
    {
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

      foreach (ExBrush brush in brushes)
      {
        brush.SetAlpha(alpha);
        brush.DrawText(g, r, Text, f, sf);
      }

      if (Image != null && (Image.Width * Image.Height > 0))
      {
        Rectangle imgrect = r;
        imgrect = HAlignWithin(Image.Size, imgrect, ImageAlign);
        imgrect = VAlignWithin(Image.Size, imgrect, ImageAlign);

        ColorMatrix cm = new ColorMatrix();
        cm.Matrix33 = ((float)alpha / 255);
        ImageAttributes ia = new ImageAttributes();
        ia.SetColorMatrix(cm);

        g.DrawImage(Image, imgrect, 0, 0, Image.Width, Image.Height, GraphicsUnit.Pixel, ia);
      }
    }

    internal static Rectangle HAlignWithin(Size alignThis, Rectangle withinThis, ContentAlignment align)
    {
      if (align == ContentAlignment.BottomRight || align == ContentAlignment.MiddleRight || align == ContentAlignment.TopRight)
      {
        withinThis.X += (withinThis.Width - alignThis.Width);
      }
      else if (align == ContentAlignment.BottomCenter || align == ContentAlignment.MiddleCenter || align == ContentAlignment.TopCenter)
      {
        withinThis.X += ((withinThis.Width - alignThis.Width + 1) / 2);
      }
      withinThis.Width = alignThis.Width;
      return withinThis;
    }

    internal static Rectangle VAlignWithin(Size alignThis, Rectangle withinThis, ContentAlignment align)
    {
      if (align == ContentAlignment.BottomCenter || align == ContentAlignment.BottomLeft || align == ContentAlignment.BottomRight)
      {
        withinThis.Y += (withinThis.Height - alignThis.Height);
      }
      else if (align == ContentAlignment.MiddleCenter || align == ContentAlignment.MiddleLeft || align == ContentAlignment.MiddleRight)
      {
        withinThis.Y += ((withinThis.Height - alignThis.Height + 1) / 2);
      }
      withinThis.Height = alignThis.Height;
      return withinThis;
    }


    internal static void DrawContent(string Text, Image Image, ContentAlignment TextAlign, ContentAlignment ImageAlign, ExBrush[] brushes, Graphics g, Rectangle r, Font f, float fl)
    {
      DrawContent(Text, Image, TextAlign, ImageAlign, brushes, g, r, f, (int)((float)fl * (float)255));
    }
  }

  /// <summary>
  /// An attribute which all ThemeKit controls use to define the type of their elements class and the name of the XML element used to define them
  /// </summary>
  public class ThemeKitControl : Attribute
  {
    public string XmlName;
    public Type ElementsType;

    public ThemeKitControl(string XmlName, Type ElementsType)
    {
      this.XmlName = XmlName;
      this.ElementsType = ElementsType;
    }
  }

  /// <summary>
  /// Represents a Theme in Memory
  /// </summary>
  public class Theme
  {
    private ThemeForm form;

    private Dictionary<string, Stream> files;

    /// <param name="form">The form the Theme will act upon</param>
    /// <param name="Theme">The theme file as a byte array</param>
    public Theme(ThemeForm form, byte[] Theme)
    {
      files = new Dictionary<string, Stream>();

      if (form.controlstyledictionaries == null || form.controlstyledictionaries.Count > 0)
        form.controlstyledictionaries = new Dictionary<Type, Dictionary<string, object>>();

      Type[] types = Assembly.GetExecutingAssembly().GetTypes();

      foreach (Type type in types)
      {
        object[] atts = type.GetCustomAttributes(typeof(ThemeKitControl), false);

        if (atts.Length == 1)
        {
          ThemeKitControl att = (ThemeKitControl)atts[0];
          Dictionary<string, object> d = new Dictionary<string, object>();

          if (Theme.Length == 0)
          {
            object o = Activator.CreateInstance(att.ElementsType);

            FieldInfo[] fields = att.ElementsType.GetFields();

            foreach (FieldInfo field in fields)
              if (field.FieldType == typeof(ExBrush[]))
                field.SetValue(o, new ExBrush[] { new ExBrush() });

            d.Add("Default", o);
          }

          form.controlstyledictionaries.Add(type, d);
        }
      }

      if (Theme.Length == 0)
        return;

      MemoryStream themexml = null;

      if ((char)Theme[0] == '<')
        themexml = new MemoryStream(Theme);
      else
      {
        MemoryStream themestream = new MemoryStream();
        themestream.Write(Theme, 0, Theme.Length);
        themestream.Position = 0;

        ZipFile zipreader = ZipFile.Read(themestream);

        foreach (ZipEntry e in zipreader)
        {
          MemoryStream stream = new MemoryStream();
          e.Extract(stream);

          if (e.FileName.ToLower() == "theme.xml")
            themexml = stream;
          else
            files.Add(e.FileName, stream);
        }

        zipreader.Dispose();
        themestream.Dispose();
      }

      if (themexml == null)
        throw new Exception("Invalid Theme");

      themexml.Position = 0;

      XmlDocument xml = new XmlDocument();
      xml.Load(themexml);

      themexml.Dispose();

      this.form = form;

      if (xml["Theme"] == null)
        throw new Exception("Invalid Theme XML");

      XmlElement root = xml["Theme"];

      foreach (Type type in types)
      {
        object[] tmp = type.GetCustomAttributes(typeof(ThemeKitControl), false);

        if (tmp.Length == 1)
          LoadStyles(root[((ThemeKitControl)tmp[0]).XmlName], type, ((ThemeKitControl)tmp[0]).ElementsType);
      }
    }

    private void LoadElementsObject(ref object o, XmlElement e)
    {
      XmlElement brushes = e["Brushes"];
      XmlElement settings = e["Settings"];

      Type t = o.GetType();

      FieldInfo[] fields = t.GetFields();

      foreach (FieldInfo f in fields)
      {
        try
        {
          if (f.IsStatic)
            continue;

          if (f.FieldType == typeof(ExBrush[]))
          {
            // Brush

            List<ExBrush> value = new List<ExBrush>();

            if (brushes != null)
            {
              foreach (XmlElement elem in brushes)
              {
                if (elem.Name == f.Name || (elem.Name.StartsWith(f.Name) && IsNumber(elem.Name.Substring(f.Name.Length))))
                {
                  ExBrush b = new ExBrush(elem, files);
                  value.Add(b);
                }
              }
            }

            ExBrush[] result = new ExBrush[value.Count];
            value.CopyTo(result);

            f.SetValue(o, result);
          }
          else
          {
            // Setting

            if (settings != null && settings[f.Name] != null)
              f.SetValue(o, ReadSetting(settings[f.Name].InnerText, f.FieldType));
          }
        }
        catch (Exception ex)
        {
          if (o is ThemeCaptionButtonElements)
            MessageBox.Show(ex.Message);

          continue;
        }
      }
    }

    private void LoadStyles(XmlElement e, Type ot, Type t)
    {
      try
      {
        Dictionary<string, object>  d = new Dictionary<string, object>();

        foreach (XmlElement styleelem in e)
        {
          try
          {
            object elemobj = Activator.CreateInstance(t);
            LoadElementsObject(ref elemobj, styleelem);
            d.Add(styleelem.Name, elemobj);
          }
          catch (Exception) { }
        }

        if (form.controlstyledictionaries.ContainsKey(ot))
          form.controlstyledictionaries[ot] = d;
        else
          form.controlstyledictionaries.Add(ot, d);
      }
      catch (Exception) { }
    }

    private object ReadSetting(string s, Type t)
    {
      try
      {
        if (t == typeof(bool))
        {
          try
          {
            return bool.Parse(s);
          }
          catch (Exception)
          {
            return int.Parse(s) == 1;
          }
        }

        if (t == typeof(int))
          return int.Parse(s);

        if (t == typeof(float))
          return float.Parse(s);

        return Convert.ChangeType(s, t);
      }
      catch (Exception)
      {
        return null;
      }
    }

    private bool IsNumber(string s)
    {
      try
      {
        int.Parse(s);
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    /// <summary>
    /// Gets a dictionary containing a list of files embedded within the theme, the key being the filename
    /// </summary>
    public Dictionary<string, Stream> Files
    {
      get { return files; }
    }
  }
}
