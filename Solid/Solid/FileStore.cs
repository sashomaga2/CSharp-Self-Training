using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid
{
    public class FileStore : IStoreWriter, IStoreReader, IFileLocator
    {
        IFileLocator fileLocator;

        public FileStore(IFileLocator fileLocator)
        {
            this.fileLocator = fileLocator; 
        }
        public void Save(int id, string message)
        {
            var path = fileLocator.GetFileInfo(id);
            File.WriteAllText(path.FullName, message);
        }

        public Maybe<string> Read(int id)
        {
            var file = fileLocator.GetFileInfo(id);
            if (!file.Exists)
            {
                return new Maybe<string>();
            }
            
            return new Maybe<string>(File.ReadAllText(file.FullName));
        }

        public FileInfo GetFileInfo(int id)
        {
            return fileLocator.GetFileInfo(id);
        }
    }
}
