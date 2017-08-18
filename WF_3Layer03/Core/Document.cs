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
        /// <summary>
        /// save string to file with extention
        /// </summary>
        /// <param name="contents"></param>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <param name="extention"></param>
        /// <returns></returns>
        public string SaveText(List<string> contents, string path, string fileName, string extention)
        {
            string myPath = Path.Combine(path, fileName + (string.IsNullOrWhiteSpace(extention) ? "" : extention));
            File.WriteAllLines(myPath, contents);
            return myPath;
        }

        public string SaveAllText(string content, string path, string fileName, string extention)
        {
            string myPath = Path.Combine(path, fileName + (string.IsNullOrWhiteSpace(extention) ? "" : extention));
            File.WriteAllText(myPath, content);
            return myPath;
        }

        public List<string> ReadText(string path)
        {
            if (!File.Exists(path)) return new List<string>();
            return File.ReadAllLines(path).ToList();
        }

        /// <summary>
        /// save object T => xml
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="path"></param>
        public void SaveObject<T>(T data, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StreamWriter writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, data);
            }
        }

        /// <summary>
        /// Read file xml.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public T GetObject<T>(string path)
        {
            object o = null;
            if (File.Exists(path))
            {
                using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    var reader = new XmlTextReader(stream);
                    if (xmlSerializer.CanDeserialize(reader))
                    {
                        o = xmlSerializer.Deserialize(reader);
                    };
                    stream.Close();
                }
            }
            return (T)o;
        }
    }
}
