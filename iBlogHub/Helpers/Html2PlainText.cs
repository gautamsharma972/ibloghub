using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace iBlogHub.Helpers
{
    public static class Html2PlainText
    {
        private static readonly Regex NonExplicitLines = new Regex("\r|\n", RegexOptions.Multiline | RegexOptions.Compiled);
        private static readonly Regex DivEndings = new Regex("</div>", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static readonly Regex LineBreaks = new Regex(@"</br\s*>", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static readonly Regex Tags = new Regex("<[^>]*>", RegexOptions.Compiled);
        public static string Decode(string html)
        {
            if (string.IsNullOrEmpty(html))
                return html;
            var decoded = html.Trim();
            if (!HasTags(decoded))
                return html;
            decoded = NonExplicitLines.Replace(decoded, string.Empty);
            decoded = DivEndings.Replace(decoded, Environment.NewLine);
            decoded = LineBreaks.Replace(decoded, Environment.NewLine);
            decoded = Tags.Replace(decoded, string.Empty).Trim();
            return WebUtility.HtmlDecode(decoded);
        }
        private static bool HasTags(string str)
        {
            return str.StartsWith("<") && str.EndsWith(">");
        }
    }
}
