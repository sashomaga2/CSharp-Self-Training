using System.IO;

namespace Solid
{
    public interface IStore
    {
        Maybe<string> Read(int id);
        void Save(int id, string message);
    }
}