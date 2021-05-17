using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Searchfight.Utility.ConfigurationSettings
{
    public class ConfigurationApplication
    {
        private readonly Configuration _config;

        public ConfigurationApplication(Configuration config)
        {
            _config = config;
        }

        public List<string> ListSearchEnginesConfiguration(string sectiongroup)
        {
            try
            {
                var lstenginesconfig = new List<string>();

                var searchengines = _config.SectionGroups[sectiongroup];

                foreach (ConfigurationSection item in searchengines.Sections)
                    lstenginesconfig.Add(item.SectionInformation.Name);

                return lstenginesconfig;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetValueConfigSettings(string sectiongroup, string section, string key)
        {
            try
            {
                var value = string.Empty;

                var seccionsetting = (PairAppearanceSection)_config.GetSection($"{sectiongroup}/{section}");
                var elements = seccionsetting.ServerElement;

                for (int i = 0; i < elements.Count; i++)
                {
                    var element = elements[i];

                    if (element.Key == key)
                        value = element.Value;
                }

                return value;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
