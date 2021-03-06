﻿namespace Cilesta.Configuration.Katarina.Implimentation
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using System.Web.Hosting;
    using Cilesta.Configuration.Interfaces;
    using Cilesta.Configuration.Models;
    using Cilesta.Utils.Common;
    using Cilesta.Utils.Json;

    public class AppConfiguration : IAppConfiguration
    {
        private IConfigurationSectionCollection Configuration { get; set; }

        public IConfigurationSection this[string key]
        {
            get
            {
                foreach (var item in this.Configuration)
                {
                    if ((item as IConfigurationSection).Key == key)
                    {
                        return item as IConfigurationSection;
                    }
                }

                return null;
            }
        }

        public AppConfiguration()
        {
            this.Configuration = new ConfigurationSectionCollection();

            this.Load();
        }

        private void Load()
        {
            var configText = string.Empty;

            if (HostingHelper.GetAppDirectory() == null)
            {
                using (var reader = new StreamReader("..\\..\\cilesta.config.json"))
                {
                    configText = reader.ReadToEnd();
                }
            }
            else
            {
                var path = HostingHelper.GetAppDirectory() + "\\" + Constants.AppConfigurationFileName;

                using (var reader = new StreamReader(path))
                {
                    configText = reader.ReadToEnd();
                }
            }
            
            this.Configuration = JsonHelper.Deserialize<ConfigurationSectionCollection>(configText);
        }

        public void SetParameterValue(string key, string parameter, string newValue)
        {
            
        }

        private async void WriteToFile(string cfg)
        {
            var path = HostingHelper.GetAppDirectory() + "\\" + Constants.AppConfigurationFileName;

            using (StreamWriter writer = File.CreateText(path))
            {
                await writer.WriteLineAsync(cfg);
            }
        }
    }
}
