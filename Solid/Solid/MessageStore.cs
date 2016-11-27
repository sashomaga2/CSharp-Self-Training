using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid
{
    public class MessageStore
    {
        // assure not set null from outside
        public DirectoryInfo WorkingDirectory { get; private set; }

        //private readonly StoreCache cache;
        //private readonly IStore store;
        //private readonly StoreLogger log;
        private readonly IStoreWriter writer;
        private readonly IStoreReader reader;

        public MessageStore(IStoreWriter writer, IStoreReader reader)
        {
            if(writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            //var s = new FileStore(new DirectoryInfo("someDirectory"));
            //var c = new StoreCache(s, s);
            //cache = c;
            //store = s;
            //var l = new StoreLogger(c, c);
            //log = l;
            this.writer = writer;
            this.reader = reader;

            //WorkingDirectory = workingDirectory;
        }

        #region Query must not return null // whether operation is legal or not

        // Tester/Doer ....1
        // First check if(Exists(id) Read(id)
        // not tread save
        // first check but after other thread can delete the file
        //public bool Exists(int id)
        //{
        //    var file = fileStore.GetFileInfo(id, WorkingDirectory.FullName);
        //    return file.Exists;
        //}

        // TryRead ....2
        // thread save
        //public bool TryRead(int id, out string message)
        //{
        //    message = null;
        //    var file = fileStore.GetFileInfo(id, WorkingDirectory.FullName);
        //    if (!file.Exists)
        //    {
        //        return false;
        //    }

        //    message = fileStore.ReadAllText(file.FullName);
        //    return true;
        //}

        // Maybe ....3
        // return empty or one element maybe
        // var message = fileStore.Read(49).DefaultIfEmpty("").Single();
        public Maybe<string> Read(int id)
        {
            //log.Reading(id);
            //var message = cache.Read(id);
            //if (message.Any())
            //{
            //    log.Returning(id);
            //}
            //else
            //{
            //    message = store.Read(id);
            //    if (message.Any())
            //    {
            //        cache.Save(id, message.Single());
            //        log.Returning(id);
            //    }
            //    else
            //    {
            //        log.DidNotFound(id);
            //    }
            //}
            // return message;

            
            return reader.Read(id);
        }

        #endregion

        // command => must be void / must mutate state
        //public void Save_old(int id, string message)
        //{
        //    // command can invoke query but query can't invoke command / mutate state
        //    new LogSavingStoreWriter().Save(id, message);
        //    store.Save(id, message);
        //    cache.Save(id, message);
        //    new LogSavedStoreWriter().Save(id, message);
        //}

        public void Save(int id, string message)
        {
            writer.Save(id, message);
        }



        // query => must not change state / must return
        //public string Read_old(int id)
        //{
        //    var file = fileStore.GetFileInfo(id, WorkingDirectory.FullName);
        //    if (!File.Exists(file.FullName))
        //    {
        //        throw new ArgumentException("Not file associated with given id", "id");
        //    }
        //    var msg = fileStore.ReadAllText(file.FullName);
        //    return msg;
        //}

        // query => will always return string
        //public FileInfo GetFileInfo(int id)
        //{
        //    return new FileInfo(Path.Combine(WorkingDirectory.FullName, id + ".txt"));
        //}


    }
}
