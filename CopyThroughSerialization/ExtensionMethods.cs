
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace CopyThroughSerialization
{
    public static class ExtenionMethods
    {
        //public static T DeepCopy<T>(this T self) //extension Methode on any type
        //{
        //    MemoryStream stream = new MemoryStream();
        //    BinaryFormatter formatter = new BinaryFormatter();
        //    formatter.Serialize(stream, self);
        //    stream.Seek(0, SeekOrigin.Begin);
        //    object copy = formatter.Deserialize(stream);
        //    stream.Close();
        //    return (T)copy;
        //}

        public static T? DeepCopyXml<T>(this T self)
        {
            using var stream = new MemoryStream();
            var s = new XmlSerializer(typeof(T));
            s.Serialize(stream, self);
            stream.Position = 0;
            return (T)s.Deserialize(stream);
        }

        public static T? DeepCopyJson<T>(this T self)
        {
            if (ReferenceEquals(self, null)) return default;
            var deserializeSettings = new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Replace };
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(self), deserializeSettings);
        }
    }
}
