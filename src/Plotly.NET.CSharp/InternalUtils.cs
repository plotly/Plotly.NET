using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class TypeFormatterSourceAttribute : Attribute
    {
        public TypeFormatterSourceAttribute(Type formatterSourceType)
        {
            FormatterSourceType = formatterSourceType;
        }

        public Type FormatterSourceType { get; }

        public string[] PreferredMimeTypes { get; set; }
    }
    internal class MyConventionBasedFormatter
    {
        public string MimeType { get; set; }

        public bool Format(object instance, TextWriter writer)
        {
            if (instance is Plotly.NET.GenericChart myObj)
            {
                writer.Write($"<div>Custom formattering for {myObj}</div>");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    internal class MyConventionBasedFormatterSource
    {
        public IEnumerable<object> CreateTypeFormatters()
        {
            yield return new MyConventionBasedFormatter { MimeType = "text/html" };
        }
    }

}
