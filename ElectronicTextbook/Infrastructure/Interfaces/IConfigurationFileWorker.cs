namespace ElectronicTextbook.Infrastructure.Interfaces
{
    internal interface IConfigurationFileWorker<T>
    {
        void WriteData(T model);

        T ReadData();
    }
}
