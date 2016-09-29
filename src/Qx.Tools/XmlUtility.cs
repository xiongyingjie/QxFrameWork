using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Qx.Tools
{
    public class XmlUtility
    {
        public static string Serialize<T>(T obj)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof (T));
                StreamWriter streamWriter = new StreamWriter(memoryStream, Encoding.UTF8);
                xmlSerializer.Serialize(streamWriter, obj);

                memoryStream.Position = 0;
                StreamReader streamReader = new StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
        }

        public static T Deserialize<T>(string xmlString)
        {
            using (MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(xmlString)))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof (T));
                return (T) xmlSerializer.Deserialize(memoryStream);
            }
        }
    }
}