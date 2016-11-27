using Adds.Web.DataContexts;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Adds.Web.IoCContainer
{
    public class BusinessLogicInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IAddsDb>().ImplementedBy<AddsDb>().LifeStyle.PerWebRequest);
        }
    }
}