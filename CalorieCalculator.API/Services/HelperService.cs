using System;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace CalorieCalculator.API.Services
{
    public class HelperService
    {
        public static string GetAssemblyDirectory()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }

        private static string GetFileFullPath(string fileName)
        {
            return GetAssemblyDirectory() + @"\" + fileName;
        }

        public static T GetDataFromFile<T>(string fileName)
        {
            T data = default;
            XmlSerializer reader = new XmlSerializer(typeof(T));

            try
            {
                using (StreamReader file = new StreamReader(GetFileFullPath(fileName)))
                {
                    data = (T)reader.Deserialize(file);
                    file.Close();
                }

            }
            catch (FileNotFoundException ee)
            {
                //TODO: review what action needs to be done in this case.
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return data;
        }

        public static void UpdateDataOnFile<T>(T data, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            var settings = new XmlWriterSettings
            {

                Indent = true,
                OmitXmlDeclaration = true
            };

            using (StreamWriter stream = new StreamWriter(GetFileFullPath(fileName)))
            using (XmlWriter writer = XmlWriter.Create(stream, settings))
            {
                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add(string.Empty, string.Empty);
                serializer.Serialize(writer, data, namespaces);
                writer.Close();
            }
        }

        public static string GetFileContent(string fileName)
        {
            return File.ReadAllText(GetFileFullPath(fileName));
        }
    }
}
