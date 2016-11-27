using Calculator;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Tests
{
    [TestFixture]
    public class Advanced
    {

        [Test]
        public void EmployeeShouldBeSaved()
        {
            var mockRepository = new Mock<IRepository>();

            mockRepository.Setup(x => x.Save(It.IsAny<Customer>()));


            var employeeService = new EmployeeService(mockRepository.Object);

            employeeService.Create("Pesho", "Slunchaka");

            mockRepository.Verify();
        }
    }
}
