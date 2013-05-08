using Decal.Adapter;
using Decal.Adapter.Wrappers;
using System;

namespace DamageTracker
{
    public partial class PluginCore
    {
        private static string CRIT = "Critical hit! ";
        private static int SAVEINTERVAL = 30;

        private int unsaved = 0;
        private DateTime lastSave = DateTime.Now;

        private int MessageColor = 5;
        private void initChatEvents()
        {
            // Initialize incoming chat message event handler
            Core.ChatBoxMessage += new EventHandler<ChatTextInterceptEventArgs>(Core_ChatBoxMessage);

            // Initialize the outgoing chat/command message event handler
            Core.CommandLineText += new EventHandler<ChatParserInterceptEventArgs>(Core_CommandLineText);
        }

        void Core_CommandLineText(object sender, ChatParserInterceptEventArgs e)
        {
            if ("/dt reset".Equals(e.Text) && sessionStats != null)
            {
                foreach (HitStatisticGroup s in sessionStats.Values) s.reset();
                e.Eat = true;
                renderStats();
            }
        }

        void Core_ChatBoxMessage(object sender, ChatTextInterceptEventArgs e)
        {
            if (pluginSettings != null)
            {
                if (e.Color == 7 || e.Color == 21)
                {
                    string m = string.Format("{0} {1}: {2}", e.Color, e.Target, e.Text);
                    if (pluginSettings.debug && !pluginSettings.messages.Contains(m))
                    {
                        pluginSettings.messages.Add(m);
                    }
                    handleIncomingDamage(e.Text.StartsWith(CRIT) ? e.Text.Replace(CRIT, string.Empty) : e.Text, e.Color == 7);
                    if (++unsaved > SAVEINTERVAL || DateTime.Now.Subtract(lastSave).TotalSeconds > SAVEINTERVAL)
                    {
                        unsaved = 0;
                        lastSave = DateTime.Now;
                        saveSettings();
                    }
                }
            }
        }

        private void destroyChatEvents()
        {
            Core.ChatBoxMessage -= new EventHandler<ChatTextInterceptEventArgs>(Core_ChatBoxMessage);
            Core.CommandLineText -= new EventHandler<ChatParserInterceptEventArgs>(Core_CommandLineText);
        }

        private void WriteToChat(string message)
        {
            try
            {
                Host.Actions.AddChatText(message, MessageColor);
            }
            catch (Exception ex)
            {
                RantaTools.Logger.fatal(errorLogFile, ex);
            }
        }
    }
}