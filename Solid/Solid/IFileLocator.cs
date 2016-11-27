using System.IO;

namespace Solid
{
    public interface IFileLocator
    {
        FileInfo GetFileInfo(int id);
    }
}