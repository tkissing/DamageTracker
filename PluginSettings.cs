/* Plugin created by lino 2010 */

using RantaTools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace DamageTracker
{
    public partial class PluginCore
    {
        public PluginSettings pluginSettings;

        private void loadSettings()
        {
            pluginSettings = PluginSettings.load(settingsFile, errorLogFile);
            initSettings();
        }

        private void saveSettings()
        {
            pluginSettings.save(settingsFile, errorLogFile);
        }

        private void initSettings()
        {
            /* INITIALISE THE STATE OF VIEW ELEMENTS HERE */
        }
    }

    public class PluginSettings
    {
        public bool debug;

        /* ADD PUBLIC PROPERTIES FOR PERSISTABLE SETTINGS HERE */
        public List<string> messages;
        public SerializableSortedDictionary<string, HitStatisticGroup> stats;

        public PluginSettings()
        {
            debug = false;

            /* SET DEFAULTS FOR THE PROPERTIES HERE */
            messages = new List<string>();
            stats = new SerializableSortedDictionary<string, HitStatisticGroup>();            
        }

        public static PluginSettings load(string file, string errorLogFile)
        {
            try
            {
                if (File.Exists(file))
                {
                    using (FileStream myFileStream = new FileStream(file, FileMode.Open))
                    {
                        XmlSerializer mySerializer = new XmlSerializer(typeof(PluginSettings));
                        PluginSettings mySettings = (PluginSettings)mySerializer.Deserialize(myFileStream);
                        myFileStream.Close();
                        return mySettings;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.fatal(errorLogFile, ex);
            }
            return new PluginSettings();
        }

        public void save(string file, string errorLogFile)
        {
            try
            {
                using (StreamWriter myWriter = new StreamWriter(file))
                {
                    XmlSerializer mySerializer = new XmlSerializer(typeof(PluginSettings));
                    myWriter.AutoFlush = true;
                    mySerializer.Serialize(myWriter, this);
                    myWriter.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.fatal(errorLogFile, ex);
            }
        }
    }
}