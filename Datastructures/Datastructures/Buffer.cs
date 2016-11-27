using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastructures
{
    public interface IBuffer<T> : IEnumerable<T>
    {
        bool IsEmpty();
        void Write(T value);
        T Read();
    }

    public class Buffer<T> : IBuffer<T>
    {
        protected Queue<T> _queue = new Queue<T>();
        public virtual bool IsEmpty()
        {
            return _queue.Count == 0;
        }

        public virtual void Write(T value)
        {
            _queue.Enqueue(value);
        }

        public virtual T Read()
        {
            return _queue.Dequeue();
        }

        

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _queue.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            //return _queue.GetEnumerator();
            foreach (var item in _queue)
            {
                // filter do something ...
                yield return item;
            }
        }
    }

    public class CircularBuffer<T> : Buffer<T>
    {
        private readonly int _capacity;
        public CircularBuffer(int capacity = 10)
        {
            _capacity = capacity;
        }

        public override void Write(T value)
        {
            base.Write(value);
            if(_queue.Count > _capacity)
            {
                var discarded = _queue.Dequeue();
                OnItemDiscarded(discarded, value);
                //ItemDiscarded(this, new ItemDiscardedEventArgs<T>(, value));
            }
        }

        private void OnItemDiscarded(T discarded, T value)
        {
            if(ItemDiscarded != null) // There are subscribers
            {
                ItemDiscarded(this, new ItemDiscardedEventArgs<T>(discarded, value));
            }
        }

        public bool IsFull()
        {
            return _queue.Count() == _capacity;
        }

        public event EventHandler<ItemDiscardedEventArgs<T>> ItemDiscarded;

    }

    public class ItemDiscardedEventArgs<T> : EventArgs
    {
        public ItemDiscardedEventArgs(T discarded, T newItem)
        {
            ItemDiscarded = discarded;
            NewItem = newItem;
        }
        public T ItemDiscarded { get; set; }
        public T NewItem { get; set; }
    }
}
