using Adds.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adds.Web.Tests
{
    class TestAddDbSet : TestDbSet<Add>
    {
        public override Add Find(params object[] keyValues)
        {
            return this.FirstOrDefault(a => a.Id == (int)keyValues.Single());
        }
    }
}
