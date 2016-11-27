using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid
{
    public class StoreLogger : IStoreWriter, IStoreReader
    {
        private readonly IStoreWriter writer;
        private readonly IStoreReader reader;
        private readonly IStoreLogger log;

        public StoreLogger(IStoreLogger log, IStoreWriter writer, IStoreReader reader)
        {
            this.writer = writer;
            this.reader = reader;
            this.log = log;
        }
        public void Save(int id, string message)
        {
            log.Saving(id, message);
            writer.Save(id, message);
            log.Saved(id, message);
        }

        public Maybe<string> Read(int id)
        {
            log.Reading(id);
            var retVal = reader.Read(id);
            if (retVal.Any())
            {
                log.Reading(id);
            }
            else
            {
                log.DidNotFound(id);
            }

            return retVal;
        }

        public void Reading(int id)
        {
            // Reading
        }

        public void Returning(int id)
        {
            // Returning
        }

        public void DidNotFound(int id)
        {
            // Did not found
        }

        public void Saving(int id, string message)
        {
            // Saving
        }

        public void Saved(int id, string message)
        {
            // Saved
        }
    }
}
