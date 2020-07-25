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
using System.Windows.Forms.Design;
using System.ComponentModel.Design;
using System.ComponentModel;
using System.Drawing.Design;
using System.Collections;
using System.Drawing;
using BurtonSoftware.UI;

namespace BurtonSoftware.ThemeKit.Design
{
  internal class ThemeTabControlDesigner : ParentControlDesigner
  {
    ISelectionService iselservice;
    bool selected;

    protected override void WndProc(ref Message m)
    {
      base.WndProc(ref m);

      if (m.Msg == (int)NativeMethods.WindowMessages.WM_NCHITTEST && selected)
      {
        Point screenPoint = new Point(m.LParam.ToInt32());
        Point clientPoint = new Point(screenPoint.X - this.Control.PointToScreen(new Point(0, 0)).X, screenPoint.Y - this.Control.PointToScreen(new Point(0, 0)).Y);

        if (clientPoint.X <= ((ThemeTabControl)this.Control).tabbar.Height && !((ThemeTabControl)this.Control).tabbar.DisallowDesignerClick(clientPoint))
          m.Result = new IntPtr((int)NativeMethods.NCHITTEST.HTCLIENT);

        //return;
      }


    }

    protected override bool GetHitTest(Point point)
    {
      return selected;
    }

    public override void Initialize(IComponent component)
    {
      base.Initialize(component);
      iselservice = (ISelectionService)this.GetService(typeof(ISelectionService));
      if (iselservice != null)
        iselservice.SelectionChanged += new EventHandler(this.OnSelectionChanged);

      ((ThemeTabControl)this.Control).DesignMode = true;
    }

    private void OnSelectionChanged(object sender, EventArgs e)
    {
      System.ComponentModel.Design.ISelectionService iSelectionService;
      System.Collections.ICollection selectedComponents;

      this.selected = false;
      iSelectionService = (ISelectionService)this.GetService(typeof(ISelectionService));

      if (iSelectionService != null)
      {
        selectedComponents = iSelectionService.GetSelectedComponents();
        foreach (object selectedComponent in selectedComponents)
        {
          if (selectedComponent == this.Component)
            this.selected = true;
        }
      }
    }

    public override bool CanParent(Control control)
    {
      return false;
    }

    DesignerVerbCollection verbs;
    public override DesignerVerbCollection Verbs
    {
      get
      {
        verbs = new DesignerVerbCollection();
        verbs.Add(new DesignerVerb("Add Tab", new EventHandler(this.AddTabHandler)));
        verbs.Add(new DesignerVerb("Add LabelTab", new EventHandler(this.AddLabelTabHandler)));
        verbs.Add(new DesignerVerb("Remove Tab", new EventHandler(this.RemoveTabHandler)));

        return verbs;
      }
    }

    public void AddTabHandler(object sender, EventArgs e)
    {
      ThemeTabControl tabcontrol = (ThemeTabControl)this.Control;
      IDesignerHost host = (IDesignerHost)this.GetService(typeof(IDesignerHost));

      if (host == null)
        return;

      DesignerTransaction transaction = null;

      try
      {
        try
        {
          transaction = host.CreateTransaction("Add Tab");
        }
        catch (CheckoutException ex)
        {
          if (ex != CheckoutException.Canceled)
            throw ex;

          return;
        }

        MemberDescriptor controlsdescriptor = TypeDescriptor.GetProperties(tabcontrol)["Controls"];
        ThemeTab tab = (ThemeTab)host.CreateComponent(typeof(ThemeTab));
        base.RaiseComponentChanging(controlsdescriptor);

        string tabtext = null;
        PropertyDescriptor namedescriptor = TypeDescriptor.GetProperties(tab)["Name"];
        if ((namedescriptor != null) && (namedescriptor.PropertyType == typeof(string)))
        {
          tabtext = (string)namedescriptor.GetValue(tab);
        }
        if (tabtext != null)
        {
          PropertyDescriptor textdescriptor = TypeDescriptor.GetProperties(tab)["Text"];
          if (textdescriptor != null)
          {
            textdescriptor.SetValue(tab, tabtext);
          }
        }

        tabcontrol.Controls.Add(tab);
        tabcontrol.SelectedIndex = tabcontrol.TabPages.Count - 1;
        base.RaiseComponentChanged(controlsdescriptor, null, null);

        tabcontrol.tabbar.Invalidate();
      }
      finally
      {
        if (transaction != null)
          transaction.Commit();
      }
    }

    public void AddLabelTabHandler(object sender, EventArgs e)
    {
      ThemeTabControl tabcontrol = (ThemeTabControl)this.Control;
      IDesignerHost host = (IDesignerHost)this.GetService(typeof(IDesignerHost));

      if (host == null)
        return;

      DesignerTransaction transaction = null;

      try
      {
        try
        {
          transaction = host.CreateTransaction("Add Tab");
        }
        catch (CheckoutException ex)
        {
          if (ex != CheckoutException.Canceled)
            throw ex;

          return;
        }

        MemberDescriptor controlsdescriptor = TypeDescriptor.GetProperties(tabcontrol)["Controls"];
        ThemeLabelTab tab = (ThemeLabelTab)host.CreateComponent(typeof(ThemeLabelTab));
        base.RaiseComponentChanging(controlsdescriptor);

        string tabtext = null;
        PropertyDescriptor namedescriptor = TypeDescriptor.GetProperties(tab)["Name"];
        if ((namedescriptor != null) && (namedescriptor.PropertyType == typeof(string)))
        {
          tabtext = (string)namedescriptor.GetValue(tab);
        }
        if (tabtext != null)
        {
          PropertyDescriptor textdescriptor = TypeDescriptor.GetProperties(tab)["Text"];
          if (textdescriptor != null)
          {
            textdescriptor.SetValue(tab, tabtext);
          }
        }

        tabcontrol.Controls.Add(tab);
        tabcontrol.SelectedIndex = tabcontrol.TabPages.Count - 1;
        base.RaiseComponentChanged(controlsdescriptor, null, null);

        tabcontrol.tabbar.Invalidate();
      }
      finally
      {
        if (transaction != null)
          transaction.Commit();
      }
    }

    public void RemoveTabHandler(object sender, EventArgs e)
    {
      ThemeTabControl tabcontrol = (ThemeTabControl)base.Component;

      if (tabcontrol == null || tabcontrol.TabPages.Count == 0)
        return;

      MemberDescriptor controlsdescriptor = TypeDescriptor.GetProperties(base.Component)["Controls"];
      ThemeTab tab = tabcontrol.SelectedTab;
      IDesignerHost host = (IDesignerHost)this.GetService(typeof(IDesignerHost));

      if (host == null)
        return;

      DesignerTransaction transaction = null;
      try
      {
        try
        {
          transaction = host.CreateTransaction("Remove Tab");
          base.RaiseComponentChanging(controlsdescriptor);
        }
        catch (CheckoutException ex)
        {
          if (ex != CheckoutException.Canceled)
            throw ex;

          return;
        }
        host.DestroyComponent(tab);
        base.RaiseComponentChanged(controlsdescriptor, null, null);
      }
      finally
      {
        if (transaction != null)
          transaction.Commit();
      }
    }
  }
}