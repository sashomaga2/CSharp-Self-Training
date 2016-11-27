using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor.Installer;

namespace CastleIoc
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();

            //container.Install(new ShoppingInstaller());

            container.Install(FromAssembly.This());

            

            // TODO use named


            var shopper = container.Resolve<Shopper>();
            var shopper2 = container.Resolve<Shopper>();
            shopper.Charge();
            shopper2.Charge();

            Console.WriteLine("equals shopper: " + Object.ReferenceEquals(shopper, shopper2)); 
            Console.WriteLine("equals card: " + Object.ReferenceEquals(shopper._creditCard, shopper2._creditCard)); 

            Console.WriteLine(shopper._creditCard.ChargeCount);
            Console.WriteLine(shopper2._creditCard.ChargeCount);

        }
    }

    public class ShoppingInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<Shopper>().LifeStyle.Transient);
            container.Register(Component.For<ICreditCard>().ImplementedBy<Visa>().LifeStyle.Transient);

        }
    }

    public class Visa : ICreditCard
    {
        public int ChargeCount { get; set; }

        public string Charge()
        {
            ChargeCount++;
            return "Charge Visa";
        }
    }

    public class MasterCard : ICreditCard
    {
        public int ChargeCount { get; set; }
        public string Charge()
        {
            ChargeCount++;
            return "Charge Master Card!";
        }
    }

    public class Shopper
    {
        //private readonly ICreditCard _creditCard;

        public ICreditCard _creditCard { get; set; }

        //public Shopper(ICreditCard creditCard)
        //{
        //    _creditCard = creditCard;
        //}

        public void Charge()
        {
            var chargeMsg = _creditCard.Charge();
            Console.WriteLine(chargeMsg);
        }
    }

    public interface ICreditCard
    {
        string Charge();
        int ChargeCount { get; }
    }
}
