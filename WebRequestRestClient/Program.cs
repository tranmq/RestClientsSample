using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Xml.Serialization;

namespace WebRequestRestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            MakeGetRequest();
            MakePostRequest();

            Console.WriteLine("Press <ENTER> to continue.");
            Console.ReadLine();
        }

        private static void MakePostRequest()
        {
            var request = (HttpWebRequest)WebRequest.Create("http://localhost:8080/Prototype/users");
            request.Method = "POST";
            request.ContentType = @"application/xml; charset=utf-8";
            var user = new user()
                       {
                           email = "code@abc.com",
                           firstname = DateTime.Now.ToLongDateString(),
                           lastname = DateTime.Now.Ticks.ToString()
                       };
            XmlSerializer serializer = new XmlSerializer(typeof(user));
            string requestBody;
            using (var memoryStream = new MemoryStream())
            using (var reader = new StreamReader(memoryStream))
            {
                serializer.Serialize(memoryStream, user);
                memoryStream.Position = 0;
                requestBody = reader.ReadToEnd();
            }

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(requestBody);
            }

            var response = request.GetResponse();
            var responseStream = response.GetResponseStream();
            Debug.Assert(responseStream != null);
            var returnedUser = serializer.Deserialize(responseStream);
        }

        private static void MakeGetRequest()
        {
            var request = (HttpWebRequest) WebRequest.Create("http://10.100.120.133:8080/Prototype/users");
            var response = request.GetResponse() as HttpWebResponse;
            Debug.Assert(response != null);
            var responseStream = response.GetResponseStream();
            Debug.Assert(responseStream != null);

            // Either load to XDocument
            //XDocument doc = XDocument.Load(responseStream);

            // Or deserialize into object
            /*
             *  - Get the XML
             *  - Generate class: Edit > Paste Special
             *      - Note the funny class names
             *  - Deserialize
             */

            users users = null;
            XmlSerializer serializer = new XmlSerializer(typeof(users));
            var streamReader = new StreamReader(responseStream);
            users = (users) serializer.Deserialize(streamReader);
            streamReader.Close();
            responseStream.Close();
        }
    }
}
