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

namespace BurtonSoftware.ThemeKit
{
  internal static class FadeScheduler
  {
    static List<FadeInfo> fades;

    static FadeScheduler()
    {
      fades = new List<FadeInfo>();

      Timer t = new Timer();
      t.Interval = 50;
      t.Tick += new EventHandler(TimerTick);
      t.Enabled = true;
    }

    public static int CreateFade(EventHandler<FadeEventArgs> changed, float step, float min, float max)
    {
      int i = fades.Count;
      fades.Add(new FadeInfo(i, FadeType.None, 0f, changed, step, min, max));
      return i;
    }

    public static void UpdateFade(int ID, float step, float min, float max)
    {
      fades[ID].step = step;
      fades[ID].min = min;
      fades[ID].max = max;
    }

    public static void SetFadeType(int ID, FadeType Type)
    {
      if (Type == FadeType.In && fades[ID].step == (fades[ID].max - fades[ID].min))
      {
        bool changed = fades[ID].progress != fades[ID].max;

        fades[ID].progress = fades[ID].max;
        fades[ID].type = FadeType.None;

        if (changed)
          fades[ID].TriggerChanged();
      }
      else if (Type == FadeType.Out && fades[ID].step == (fades[ID].max - fades[ID].min))
      {
        bool changed = fades[ID].progress != fades[ID].min;

        fades[ID].progress = fades[ID].min;
        fades[ID].type = FadeType.None;

        if (changed)
          fades[ID].TriggerChanged();
      }

      fades[ID].type = Type;
    }

    public static FadeType GetFadeType(int ID)
    {
      return fades[ID].type;
    }

    static void TimerTick(object sender, EventArgs e)
    {
      ((Timer)sender).Enabled = false;

      for (int i = 0; i < fades.Count; i++)
      {
        FadeInfo fade = fades[i];

        if (fade.type == FadeType.In)
        {
          float tmp = fade.progress;

          fade.progress = Math.Min(fade.max, tmp + fade.step);

          if (fade.progress >= fade.max)
          {
            fade.progress = fade.max;
            fade.type = FadeType.None;
          }

          if (fade.progress != tmp)
            fade.TriggerChanged();
        }
        else if (fade.type == FadeType.Out)
        {
          float tmp = fade.progress;

          fade.progress = Math.Max(fade.min, tmp - fade.step);

          if (fade.progress <= fade.min)
          {
            fade.progress = fade.min;
            fade.type = FadeType.None;
          }

          if (fade.progress != tmp)
            fade.TriggerChanged();
        }
      }

      ((Timer)sender).Enabled = true;
    }
  }

  internal class FadeInfo
  {
    public FadeType type;
    public float progress;
    public EventHandler<FadeEventArgs> changed;
    public float step;
    public float min;
    public float max;
    public int id;

    public FadeInfo(int id, FadeType type, float progress, EventHandler<FadeEventArgs> changed, float step, float min, float max)
    {
      this.id = id;
      this.type = type;
      this.progress = progress;
      this.changed = changed;
      this.step = step;
      this.min = min;
      this.max = max;
    }

    public void TriggerChanged()
    {
      if (changed != null)
        changed(null, new FadeEventArgs(this.id, this.progress));
    }
  }

  internal enum FadeType { None, In, Out }

  internal class FadeEventArgs : EventArgs
  {
    public int FadeID;
    public float Progress;

    public FadeEventArgs(int ID, float Progress)
    {
      this.FadeID = ID;
      this.Progress = Progress;
    }
  }
}
