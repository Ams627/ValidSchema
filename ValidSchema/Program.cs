using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ValidSchema
{
    class Program
    {
        private static void Main(string[] args)
        {
            try
            {

                _ = args.Any() ? 1 : throw new Exception("specify a filename");
                XmlSchemaSet schemas = new XmlSchemaSet();
                schemas.ValidationEventHandler += (s, e) =>
                {
                    Console.WriteLine($"{e.Message} at line {e.Exception.LineNumber}");
                };

                Console.WriteLine($"{args[0]}");
                schemas.Add("xs", args[0]);
            }
            catch (Exception ex)
            {
                var fullname = System.Reflection.Assembly.GetEntryAssembly().Location;
                var progname = Path.GetFileNameWithoutExtension(fullname);
                Console.Error.WriteLine(progname + ": Error: " + ex.Message);
            }

        }
    }
}
