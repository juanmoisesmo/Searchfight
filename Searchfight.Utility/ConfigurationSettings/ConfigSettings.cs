using System.Collections.Generic;
using System.Configuration;

namespace Searchfight.Utility.ConfigurationSettings
{
    public class ConfigSettings : IConfigSettings
    {
        private readonly string _sectionName;
        public string SectionName { get; set; }

        public ConfigSettings(string sectionName)
        {
            _sectionName = sectionName;
            SectionName = sectionName;
        }

        public PairAppearanceSection SettingAppearanceConfiguration
        {
            get
            {
                return (PairAppearanceSection)ConfigurationManager.GetSection(_sectionName);
            }
        }

        public PairAppearanceCollection SettingApperances
        {
            get
            {
                return this.SettingAppearanceConfiguration.ServerElement;
            }
        }

        public IEnumerable<PairElement> SettingElements
        {
            get
            {
                foreach (PairElement selement in this.SettingApperances)
                {
                    if (selement != null)
                    {
                        yield return selement;
                    }
                }
            }
        }
    }
}