using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CFS.Common.Extensions
{
    public static class StringBuilderExtension
    {
        public static string ConvertExceptionMessage(this IEnumerable<string> source)
        {
            var builder = new StringBuilder();
            foreach (var s in source)
            {
                builder.Append(s);
                builder.AppendLine();
            }
            return builder.ToString();
        }

        public static string Standardizing(this string text)
        {
            return text.RemoveAccents().ToLower();
        }

        public static string RemoveAccents(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            text = text.Normalize(NormalizationForm.FormD);
            var chars = text.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray();
            return new string(chars).Normalize(NormalizationForm.FormC);
        }


    }
}
