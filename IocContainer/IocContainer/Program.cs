using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            var resolver = new Resolver();

            resolver.Register<Shopper, Shopper>();
            resolver.Register<ICreditCard, Visa>();

            var shopper = resolver.Resolve<Shopper>();
            shopper.Charge();
        }
    }

    public class Resolver
    {
        private Dictionary<Type, Type> dependencyMap = new Dictionary<Type, Type>();

        public void Register<TFrom, TTo>()
        {
            dependencyMap.Add(typeof(TFrom), typeof(TTo));
        }
        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        private object Resolve(Type typeToResolve)
        {
            Type resolvedType = null;
            try
            {
                resolvedType = dependencyMap[typeToResolve];
            }
            catch (Exception)
            {

                throw new Exception($"Could not resolve type {typeToResolve.FullName}");
            }

            var firstConstructor = resolvedType.GetConstructors().First();
            var constructorParamethers = firstConstructor.GetParameters();

            if(constructorParamethers.Count() == 0)
            {
                return Activator.CreateInstance(resolvedType);
            }
            
            List<object> paramethers = new List<object>();
            foreach (var paramToResolve in constructorParamethers)
            {
                paramethers.Add(Resolve(paramToResolve.ParameterType));
            }

            return firstConstructor.Invoke(paramethers.ToArray());
            
        }
    }

    public class Visa : ICreditCard
    {
        public string Charge()
        {
            return "Charge Visa";
        }
    }

    public class MasterCard : ICreditCard
    {
        public string Charge()
        {
            return "Charge Master Card!";
        }
    }

    public class Shopper
    {
        private readonly ICreditCard _creditCard;

        public Shopper(ICreditCard creditCard)
        {
            _creditCard = creditCard;
        }

        public void Charge()
        {
            var chargeMsg = _creditCard.Charge();
            Console.WriteLine(chargeMsg);
        }
    }

    public interface ICreditCard
    {
        string Charge();
    }
}
