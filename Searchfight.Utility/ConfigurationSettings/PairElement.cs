using System.Configuration;

namespace Searchfight.Utility.ConfigurationSettings
{
    public class PairElement : ConfigurationElement
    {
        [ConfigurationProperty("key", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string Key
        {
            get { return (string)base["key"]; }
            set { base["key"] = value; }
        }

        [ConfigurationProperty("value", DefaultValue = "", IsKey = false, IsRequired = false)]
        public string Value
        {
            get { return (string)base["value"]; }
            set { base["value"] = value; }
        }
    }
}