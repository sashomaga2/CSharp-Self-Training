using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid
{
    public class SqlStore : IStoreWriter, IStoreReader
    {
        public Maybe<string> Read(int id)
        {
            // read from Db
            return new Maybe<string>();
        }

        public void Save(int id, string message)
        {
            // Write to Db
        }
    }
}
