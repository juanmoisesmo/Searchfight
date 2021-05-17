using System.Configuration;

namespace Searchfight.Utility.ConfigurationSettings
{
    public class PairAppearanceSection : ConfigurationSection
    {
        [ConfigurationProperty("settings")]
        public PairAppearanceCollection ServerElement
        {
            get { return ((PairAppearanceCollection)(base["settings"])); }
            set { base["settings"] = value; }
        }
    }
}
