namespace SkinInstaller.Properties
{
    using System;
    using System.CodeDom.Compiler;
    using System.Configuration;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed class Settings : ApplicationSettingsBase
    {
        private static Settings defaultInstance = ((Settings) SettingsBase.Synchronized(new Settings()));

        public static Settings Default
        {
            get
            {
                return defaultInstance;
            }
        }

        [UserScopedSetting, DebuggerNonUserCode, DefaultSettingValue(@"C:\Riot Games\League of Legends\game\")]
        public string gameDir
        {
            get
            {
                return (string) this["gameDir"];
            }
            set
            {
                this["gameDir"] = value;
            }
        }

        [DefaultSettingValue("data source=\"skins.db\""), ApplicationScopedSetting, DebuggerNonUserCode, SpecialSetting(SpecialSetting.ConnectionString)]
        public string skinsConnectionString
        {
            get
            {
                return (string) this["skinsConnectionString"];
            }
        }
    }
}

