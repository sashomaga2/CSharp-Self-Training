using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdvancedUnitTests.Controllers
{
    public interface IRenderer
    {
        void Render();
    }

    public interface IEncryption
    {
        void Encript();
    }

    public class SecurityController
    {
        public IRenderer renderer;
        public IEncryption encriptor;
        public SecurityController(IRenderer renderer, IEncryption encriptor)
        {
            this.renderer = renderer;
            this.encriptor = encriptor;
        }
    }
}