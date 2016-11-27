using AdvancedUnitTests.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedUnitTests.Tests
{
    internal class SecurityControllerFixture
    {
        internal IRenderer renderer;
        internal IEncryption encryption;

        internal SecurityControllerFixture()
        {
            renderer = new Mock<IRenderer>().Object;
            encryption = new Mock<IEncryption>().Object;
        }

        internal SecurityController CreateSut()
        {
            return new SecurityController(renderer, encryption);
        }

    }
}
