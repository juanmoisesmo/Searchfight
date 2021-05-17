using System.Text.RegularExpressions;

namespace Searchfight.Utility.Functions
{
    public static class StringFunctions
    {
        public static string ParserDataResultsSearch(string data, string tagStartSplit, string tagEndSplit, int posArrayStartSplit = 1, int posArrayEndSplit = 0)
        {
            //split by start tag
            var arrayResultStarTag = data.Split(tagStartSplit);
            var valueStartTag = arrayResultStarTag.Length == 0 || arrayResultStarTag.Length == 1 ? "" : arrayResultStarTag[posArrayStartSplit];

            //split by end tag
            var arrayResultEndTag = valueStartTag.Split(tagEndSplit);
            var valueEndTag = arrayResultEndTag.Length == 0 || arrayResultEndTag.Length == 1 ? "" : arrayResultEndTag[posArrayEndSplit];

            //cleaning text result of end tag to only numbers result
            var result = Regex.Replace(valueEndTag, @"[^\d]", "");

            return !string.IsNullOrEmpty(result) ? result : "0";
        }

        public static string ParseTagValueToHtmlTag(string value)
        {
            value = value.Replace("*", "<");
            value = value.Replace("#", ">");
            value = value.Replace("@", "\"");

            return value.Trim();
        }
    }
}
