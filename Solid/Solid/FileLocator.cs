using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid
{
    public class FileLocator : IFileLocator
    {
        private readonly DirectoryInfo workingDirectory;

        public FileLocator(DirectoryInfo workingDirectory)
        {
            // validate input that can break program null
            if (workingDirectory == null)
            {
                throw new ArgumentNullException("Working directory can't be null!");
            }
            // validate logic
            else if (!workingDirectory.Exists)
            {
                throw new ArgumentException("Working directory must exist!", "workingDirectory");
            }
            this.workingDirectory = workingDirectory;
        }
        public FileInfo GetFileInfo(int id)
        {
            return new FileInfo(Path.Combine(workingDirectory.FullName, id + ".txt"));
        }
    }
}
