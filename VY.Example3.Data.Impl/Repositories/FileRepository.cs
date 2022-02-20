using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VY.Example3.Data.Contracts.Repositories;

namespace VY.Example3.Data.Impl.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly string _path;
        private readonly static object locker = new object();
        public FileRepository(string path)
        {
            _path = path;
        }

        public void AddToFile<T>(T entity)
        {
            string jsonString = JsonSerializer.Serialize(entity);

            lock (locker)
            {
                File.AppendAllText(_path,jsonString);
            }
        }
    }
}
