using System.Collections.Generic;

namespace Searchfight.Utility.ConfigurationSettings
{
    public interface IConfigSettings
    {
        PairAppearanceSection SettingAppearanceConfiguration
        {
            get;
        }

        PairAppearanceCollection SettingApperances
        {
            get;
        }

        IEnumerable<PairElement> SettingElements
        {
            get;
        }
    }
}