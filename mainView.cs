using Decal.Adapter;
using Decal.Adapter.Wrappers;
using MyClasses.MetaViewWrappers;
using RantaTools;
using System;
using System.Collections.Generic;

namespace DamageTracker
{
    public partial class PluginCore : PluginBase
    {
        static int COL_AREA = 0;
        static int COL_HITS = 1;
        static int COL_MAX = 2;
        static int COL_AVG = 3;

        static string ALL = "(All)";

        #region Auto-generated view code
        static MyClasses.MetaViewWrappers.IView View;
        static MyClasses.MetaViewWrappers.IStaticText lblDamage;
        static MyClasses.MetaViewWrappers.ICombo choDamage;
        static MyClasses.MetaViewWrappers.IStaticText Label01;
        static MyClasses.MetaViewWrappers.IStaticText Label02;
        static MyClasses.MetaViewWrappers.IStaticText Label03;
        static MyClasses.MetaViewWrappers.IStaticText Label04;
        static MyClasses.MetaViewWrappers.IList lstMeleeSession;
        static MyClasses.MetaViewWrappers.IStaticText Label05;
        static MyClasses.MetaViewWrappers.IStaticText Label06;
        static MyClasses.MetaViewWrappers.IStaticText Label07;
        static MyClasses.MetaViewWrappers.IStaticText Label08;
        static MyClasses.MetaViewWrappers.IList lstMeleeOverall;
        static MyClasses.MetaViewWrappers.INotebook nbkMelee;
        static MyClasses.MetaViewWrappers.IStaticText Label11;
        static MyClasses.MetaViewWrappers.IStaticText Label12;
        static MyClasses.MetaViewWrappers.IStaticText Label13;
        static MyClasses.MetaViewWrappers.IStaticText Label14;
        static MyClasses.MetaViewWrappers.IList lstMagicSession;
        static MyClasses.MetaViewWrappers.IStaticText Label15;
        static MyClasses.MetaViewWrappers.IStaticText Label16;
        static MyClasses.MetaViewWrappers.IStaticText Label17;
        static MyClasses.MetaViewWrappers.IStaticText Label18;
        static MyClasses.MetaViewWrappers.IList lstMagicOverall;
        static MyClasses.MetaViewWrappers.INotebook nbkMagic;
        static MyClasses.MetaViewWrappers.IStaticText AboutText1;
        static MyClasses.MetaViewWrappers.IStaticText UseAtOwnRisk;
        static MyClasses.MetaViewWrappers.INotebook nbkMain;

        void ViewInit()
        {
            //Create view here
            View = MyClasses.MetaViewWrappers.ViewSystemSelector.CreateViewResource(Host, "DamageTracker.ViewXML.mainView.xml");
            lblDamage = (MyClasses.MetaViewWrappers.IStaticText)View["lblDamage"];
            choDamage = (MyClasses.MetaViewWrappers.ICombo)View["choDamage"];
            Label01 = (MyClasses.MetaViewWrappers.IStaticText)View["Label01"];
            Label02 = (MyClasses.MetaViewWrappers.IStaticText)View["Label02"];
            Label03 = (MyClasses.MetaViewWrappers.IStaticText)View["Label03"];
            Label04 = (MyClasses.MetaViewWrappers.IStaticText)View["Label04"];
            lstMeleeSession = (MyClasses.MetaViewWrappers.IList)View["lstMeleeSession"];
            Label05 = (MyClasses.MetaViewWrappers.IStaticText)View["Label05"];
            Label06 = (MyClasses.MetaViewWrappers.IStaticText)View["Label06"];
            Label07 = (MyClasses.MetaViewWrappers.IStaticText)View["Label07"];
            Label08 = (MyClasses.MetaViewWrappers.IStaticText)View["Label08"];
            lstMeleeOverall = (MyClasses.MetaViewWrappers.IList)View["lstMeleeOverall"];
            nbkMelee = (MyClasses.MetaViewWrappers.INotebook)View["nbkMelee"];
            Label11 = (MyClasses.MetaViewWrappers.IStaticText)View["Label11"];
            Label12 = (MyClasses.MetaViewWrappers.IStaticText)View["Label12"];
            Label13 = (MyClasses.MetaViewWrappers.IStaticText)View["Label13"];
            Label14 = (MyClasses.MetaViewWrappers.IStaticText)View["Label14"];
            lstMagicSession = (MyClasses.MetaViewWrappers.IList)View["lstMagicSession"];
            Label15 = (MyClasses.MetaViewWrappers.IStaticText)View["Label15"];
            Label16 = (MyClasses.MetaViewWrappers.IStaticText)View["Label16"];
            Label17 = (MyClasses.MetaViewWrappers.IStaticText)View["Label17"];
            Label18 = (MyClasses.MetaViewWrappers.IStaticText)View["Label18"];
            lstMagicOverall = (MyClasses.MetaViewWrappers.IList)View["lstMagicOverall"];
            nbkMagic = (MyClasses.MetaViewWrappers.INotebook)View["nbkMagic"];
            AboutText1 = (MyClasses.MetaViewWrappers.IStaticText)View["AboutText1"];
            UseAtOwnRisk = (MyClasses.MetaViewWrappers.IStaticText)View["UseAtOwnRisk"];
            nbkMain = (MyClasses.MetaViewWrappers.INotebook)View["nbkMain"];
        }

        void ViewDestroy()
        {
            lblDamage = null;
            choDamage = null;
            Label01 = null;
            Label02 = null;
            Label03 = null;
            Label04 = null;
            lstMeleeSession = null;
            Label05 = null;
            Label06 = null;
            Label07 = null;
            Label08 = null;
            lstMeleeOverall = null;
            nbkMelee = null;
            Label11 = null;
            Label12 = null;
            Label13 = null;
            Label14 = null;
            lstMagicSession = null;
            Label15 = null;
            Label16 = null;
            Label17 = null;
            Label18 = null;
            lstMagicOverall = null;
            nbkMagic = null;
            AboutText1 = null;
            UseAtOwnRisk = null;
            nbkMain = null;
            View.Dispose();
        }
        #endregion Auto-generated view code

        void ViewPostInit()
        {
            choDamage.Add(ALL);
            choDamage.Add(DamageTypes.B);
            choDamage.Add(DamageTypes.P);
            choDamage.Add(DamageTypes.S);

            choDamage.Add(DamageTypes.A);
            choDamage.Add(DamageTypes.C);
            choDamage.Add(DamageTypes.F);
            choDamage.Add(DamageTypes.L);

            choDamage.Add(DamageTypes.H);
            choDamage.Add(DamageTypes.D);
            choDamage.Add(DamageTypes.N);
            choDamage.Add(DamageTypes.U);

            choDamage.Selected = 0;

            choDamage.Change += new EventHandler<MVIndexChangeEventArgs>(choDamage_Change);

            nbkMagic.Change += new EventHandler<MVIndexChangeEventArgs>(nbkChange);
            nbkMelee.Change += new EventHandler<MVIndexChangeEventArgs>(nbkChange);
            nbkMain.Change += new EventHandler<MVIndexChangeEventArgs>(nbkChange);
        }

        void choDamage_Change(object sender, MVIndexChangeEventArgs e)
        {
            renderStats();
        }

        void nbkChange(object sender, MVIndexChangeEventArgs e)
        {
            renderStats();
        }

        void renderStats()
        {
            if (nbkMain != null && View.Visible)
            {
                if (sessionStats != null)
                {
                    doRenderStats(sessionStats, lstMagicSession, lstMeleeSession);
                }
                if (pluginSettings != null)
                {
                    doRenderStats(pluginSettings.stats, lstMagicOverall, lstMeleeOverall);
                }
            }
        }

        private void doRenderStats(SortedDictionary<string, HitStatisticGroup> dict, IList magic, IList melee)
        {
            if (melee.Visible)
            {
                melee.Clear();
                foreach (KeyValuePair<string, HitStatisticGroup> kv in dict)
                {
                    if (!kv.Key.Equals(MAGIC))
                    {
                        string f = choDamage.Text[choDamage.Selected];
                        doRenderStatGroup(melee, kv.Value.Filtered(f));
                    }
                }
            }
            if (magic.Visible)
            {
                magic.Clear();
                HitStatisticGroup g = dict.ContainsKey(MAGIC) ? dict[MAGIC] : null;
                if (g != null) foreach (KeyValuePair<string, HitStatistic> st in g) doRenderStatGroup(magic, st.Value);
            }
        }

        private void doRenderStatGroup(IList l, IStatistic g)
        {
            int r = l.RowCount;
            l.AddRow();
            l[r][COL_AREA][0] = g.Name;
            l[r][COL_AVG][0] = StringUtils.Formatted(g.Average);
            l[r][COL_HITS][0] = StringUtils.Formatted((double)g.Count);
            l[r][COL_MAX][0] = StringUtils.Formatted(g.Max);
        }

    }
}