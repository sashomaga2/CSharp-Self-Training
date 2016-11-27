using AdvancedUnitTests.Controllers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedUnitTests.Tests
{
    [TestFixture]
    public class SecurityControllerTests
    {
        [Test]
        public void SecurityControllerInit()
        {
            var fixture = new SecurityControllerFixture();
            var sut = fixture.CreateSut();

            sut.renderer.Render();
            sut.encriptor.Encript();

            Mock.Get<IRenderer>(sut.renderer).Verify(r => r.Render(), Times.Exactly(1));
            sut.encriptor.AsMock<IEncryption>().Verify(e => e.Encript());
        }
    }
}
