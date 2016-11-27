﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid
{
    public class Maybe<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> values;

        public Maybe()
        {
            values = new T[0];
        }
        public Maybe(T value)
        {
            values = new[] { value };
        }

        public IEnumerator<T> GetEnumerator()
        {
            return values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
