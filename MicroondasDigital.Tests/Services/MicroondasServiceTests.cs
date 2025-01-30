using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MicroondasDigital.Business.Services;
using System.Threading.Tasks;

namespace MicroondasDigital.Tests.Services
{
    [TestClass]
    public class MicroondasServiceTests
    {
        private MicroondasService _service;

        [TestInitialize]
        public void Setup()
        {
            _service = new MicroondasService();
        }

        [TestMethod]
        public async Task TestIniciarAquecimento()
        {
            var resultado = await _service.IniciarAquecimento(2, 50);
            Assert.AreEqual("Aquecimento finalizado!", resultado);
        }

        [TestMethod]
        public async Task TestPausarAquecimento()
        {
            await _service.IniciarAquecimento(2, 50);
            var resultado = await _service.PausarAquecimento();
            Assert.AreEqual("Aquecimento pausado.", resultado);
        }

        [TestMethod]
        public async Task TestCancelarAquecimento()
        {
            await _service.IniciarAquecimento(2, 50);
            var resultado = await _service.CancelarAquecimento();
            Assert.AreEqual("Aquecimento cancelado.", resultado);
        }
    }
}
