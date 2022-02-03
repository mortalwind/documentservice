using System.Text.RegularExpressions;

namespace DocumentMono.Common
{
    public static class HtmlHelper
    {

        const string HTML_TAG_PATTERN = "<.*?>";
        /// <summary>
        /// Clean HTML tags from comment area content
        /// <para>Yorumlardan alanlarından gelen içerikten HTML taglarını temizler</para>
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static string StripHTML(string inputString)
        {
            return Regex.Replace
              (inputString, HTML_TAG_PATTERN, string.Empty);
        }
    }
}
