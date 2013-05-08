/* Plugin template by Timo 'lino' Kissing <http://ac.ranta.info/DecalDev> */
/* Original template by Lonewolf <http://www.the-lonewolf.com> */

using Decal.Adapter;
using System;
using System.IO;

namespace DamageTracker
{
    public partial class PluginCore : PluginBase
    {

        private static string DIR_SEP = "\\";
        private static string PLUGIN = "DamageTracker";

        private static string FILENAME_ERRORLOG = "errorlog.txt";
        private string FILENAME_SETTINGS { get { return Core.CharacterFilter.Id != 0 ? string.Format("{0}.xml", Core.CharacterFilter.Name) : "settings.xml"; } }

        public string settingsBaseFolder
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + DIR_SEP + "Decal Plugins" + DIR_SEP + PLUGIN;
            }
        }
        public string settingsFolder { get { return settingsBaseFolder + DIR_SEP + Core.CharacterFilter.Server; } }

        public string settingsFile { get { return settingsFolder + DIR_SEP + FILENAME_SETTINGS; } }
        public string errorLogFile { get { return settingsFolder + DIR_SEP + FILENAME_ERRORLOG; } }

        protected override void Startup()
        {
            try
            {
                initCharStats();
                initWorldFilter();
                initChatEvents();

                ViewInit();
                ViewPostInit();

                //TODO: Code for startup events
            }
            catch (Exception ex)
            {
                RantaTools.Logger.fatal(errorLogFile, ex);
            }
        }

        protected override void Shutdown()
        {
            try
            {
                destroyChatEvents();
                destroyCharStats();
                destroyWorldFilter();

                ViewDestroy();
                //TODO: Code for shutdown events
            }
            catch (Exception ex)
            {
                RantaTools.Logger.error(errorLogFile, ex);
            }
        }

        protected void initPath()
        {
            if (!Directory.Exists(settingsFolder))
            {
                try
                {
                    Directory.CreateDirectory(settingsFolder);
                }
                catch (Exception ex)
                {
                    RantaTools.Logger.fatal("c:\\DamageTracker-errorlog.txt", ex);
                }
            }
        }
    }
}