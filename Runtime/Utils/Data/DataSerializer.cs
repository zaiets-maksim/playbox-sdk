using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Utils.Data
{
    public static class DataSerializer
    {
        public static byte[] Serialize(object obj)
        {
            using var memoryStream = new MemoryStream();
            
            new BinaryFormatter().Serialize(memoryStream,obj);
            
            return memoryStream.ToArray();
        }

        public static T Deserialize<T>(byte[] bytes)
        {
            using var memoryStream = new MemoryStream(bytes);
            return (T)new BinaryFormatter().Deserialize(memoryStream);
        }
    }
}