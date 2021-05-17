using System;
using System.Configuration;

namespace Searchfight.Utility.ConfigurationSettings
{
    [ConfigurationCollection(typeof(PairElement))]
    public class PairAppearanceCollection : ConfigurationElementCollection
    {
        internal const string PropertyName = "element";

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMapAlternate;
            }
        }
        protected override string ElementName
        {
            get
            {
                return PropertyName;
            }
        }

        protected override bool IsElementName(string elementName)
        {
            return elementName.Equals(PropertyName, StringComparison.InvariantCultureIgnoreCase);
        }


        public override bool IsReadOnly()
        {
            return false;
        }


        protected override ConfigurationElement CreateNewElement()
        {
            return new PairElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((PairElement)(element)).Key;
        }

        public PairElement this[int idx]
        {
            get
            {
                return (PairElement)BaseGet(idx);
            }
        }
    }
}
