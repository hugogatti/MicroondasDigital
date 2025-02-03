using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MicroondasDigital.Business.Services;
using MicroondasDigital.Business.Interfaces;
using Moq;

namespace MicroondasDigital.Tests.Services
{
    [TestClass]
    public class ProgramaServiceTests
    {
        private ProgramaService _service;
        private Mock<IMicroondasService> _mockMicroondasService;

        [TestInitialize]
        public void Setup()
        {
            _mockMicroondasService = new Mock<IMicroondasService>();
            _mockMicroondasService.Setup(m => m.IniciarAquecimento(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync("Aquecimento concluído");
            _service = new ProgramaService(_mockMicroondasService.Object);
        }

        [TestMethod]
        public void TestObterTodosProgramas()
        {
            var programas = _service.ObterTodosProgramas();
            Assert.AreEqual(5, programas.Count);
        }

        [TestMethod]
        public void TestObterProgramaExistente()
        {
            var programa = _service.ObterPrograma("Pipoca");
            Assert.IsNotNull(programa);
            Assert.AreEqual(60, programa.Tempo);
            Assert.AreEqual(7, programa.Potencia);
        }

        [TestMethod]
        public async Task TestIniciarPrograma()
        {
            var resultado = await _service.IniciarPrograma("Pipoca");
            Assert.AreEqual("Aquecimento concluído", resultado);
        }

        [TestMethod]
        public async Task TestIniciarProgramaInexistente()
        {
            var resultado = await _service.IniciarPrograma("Inexistente");
            Assert.AreEqual("Programa não encontrado.", resultado);
        }
    }
}
