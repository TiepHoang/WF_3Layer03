using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Core
{
    public class Document
    {
        public string SaveText(string contents, string path, string fileName, string extention)
        {
            string myPath = Path.Combine(path, fileName + extention);
            File.WriteAllText(myPath, contents);
            return myPath;
        }

        public void SaveObject<T>(T data, string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(stream, data);
                stream.Close();
            }
        }

        public T GetObject<T>(string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                object o = null;
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                if (xmlSerializer.CanDeserialize(new XmlTextReader(stream)))
                {
                    o = xmlSerializer.Deserialize(stream);
                };
                stream.Close();
                return (T)o;
            }
        }
    }
}
