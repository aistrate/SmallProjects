using System;
using System.Text;

namespace Eniuq
{
    class Program
    {
        private static void eniuq(string template)
        {
            StringBuilder placeholder = new StringBuilder();
            placeholder.Append((char)35);
            placeholder.Append((char)35);
            placeholder.Append((char)35);

            StringBuilder quotedTemplate = new StringBuilder();
            quotedTemplate.Append((char)34);
            quotedTemplate.Append(template);
            quotedTemplate.Append((char)34);

            Console.WriteLine(template.Replace(placeholder.ToString(), quotedTemplate.ToString()));
        }

        static void Main(string[] args)
        {
            eniuq(@"using System;
using System.Text;

namespace Eniuq
{
    class Program
    {
        private static void eniuq(string template)
        {
            StringBuilder placeholder = new StringBuilder();
            placeholder.Append((char)35);
            placeholder.Append((char)35);
            placeholder.Append((char)35);

            StringBuilder quotedTemplate = new StringBuilder();
            quotedTemplate.Append((char)34);
            quotedTemplate.Append(template);
            quotedTemplate.Append((char)34);

            Console.WriteLine(template.Replace(placeholder.ToString(), quotedTemplate.ToString()));
        }

        static void Main(string[] args)
        {
            eniuq(@###);
        }
    }
}");
        }
    }
}