using System;
using System.Xml.Linq;
using System.Xml.XPath;

namespace LinqToXmlRestClient
{
    class Program
    {
        static void Main()
        {
            // Can only do GET
            var root = XDocument.Load("http://10.100.120.133:8080/Prototype/users");
            var reader = root.CreateReader();
            reader.MoveToContent();
            Console.WriteLine("Result:");
            Console.WriteLine(reader.ReadOuterXml());

            var fn = root.XPathSelectElement("users/user/firstname").Value;
            Console.WriteLine();
            Console.WriteLine("Firstname: {0}", fn);
            Console.WriteLine("Press <ENTER> continue.");
            Console.ReadLine();
        }
    }
}
