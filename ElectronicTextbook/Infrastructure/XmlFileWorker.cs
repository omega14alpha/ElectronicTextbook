using ElectronicTextbook.Infrastructure.Interfaces;
using System;
using System.IO;
using System.Xml.Serialization;

namespace ElectronicTextbook.Infrastructure
{
    internal class XmlFileWorker<T> : IConfigurationFileWorker<T>
    {
        private string _configurationFilePath;

        public XmlFileWorker()
        {
            _configurationFilePath = Path.Combine(Environment.CurrentDirectory, "configuration.xml");
        }

        public void WriteData(T model)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using FileStream stream = new FileStream(_configurationFilePath, FileMode.OpenOrCreate);
            try
            {
                serializer.Serialize(stream, model);
            }
            catch (Exception)
            {
                throw new FileLoadException("Error writing the configuration file!");
            }
        }

        public T ReadData()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using FileStream stream = new FileStream(_configurationFilePath, FileMode.Open);
            try
            {
                return (T)serializer.Deserialize(stream);
            }
            catch (Exception)
            {
                throw new FileLoadException("Error reading the configuration file!");
            }
        }
    }
}
