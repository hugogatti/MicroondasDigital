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
        public async Task TestAcrescentarTempo()
        {
            await _service.IniciarAquecimento(2, 5);
            var resultado = await _service.AcrescentarTempo();
            Assert.AreEqual("Tempo acrescido. Novo tempo: 32 segundos.", resultado);
        }

        [TestMethod]
        public void TestStringInformativaDeAquecimento()
        {
            string esperado = "*****";
            var resultado = _service.GerarStringAquecimento(5); // Passa diretamente a potência correta
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void TestConverterTempoEmSegundos()
        {
            var service = new MicroondasService();

            // Teste com tempo no formato MMSS
            int segundos1 = service.ConverterTempoEmSegundos("0130");
            Assert.AreEqual(90, segundos1);

            // Teste com tempo no formato MM:SS
            int segundos2 = service.ConverterTempoEmSegundos("01:30");
            Assert.AreEqual(90, segundos2);

            // Teste com tempo inválido
            Assert.ThrowsException<FormatException>(() => service.ConverterTempoEmSegundos("130"));
        }

        //TESTES DE INICIAR
        [TestMethod]
        public async Task TestIniciarAquecimentoComValoresInvalidos()
        {
            await Assert.ThrowsExceptionAsync<ArgumentException>(() => _service.IniciarAquecimento(0, 5));
            await Assert.ThrowsExceptionAsync<ArgumentException>(() => _service.IniciarAquecimento(2, 11));
        }

        [TestMethod]
        public async Task TestIniciarAquecimento()
        {
            var resultado = await _service.IniciarAquecimento(2, 5);
            Assert.AreEqual("Aquecimento iniciado", resultado);
        }

        //TESTES DE PAUSAR
        [TestMethod]
        public async Task TestPausarAquecimentoDuranteDelay()
        {
            var task = _service.IniciarAquecimento(10, 5);
            await Task.Delay(1000); // Espera 1 segundo antes de pausar
            var resultadoPausa = await _service.PausarAquecimento();
            var resultadoAquecimento = await task;

            Assert.AreEqual("Aquecimento pausado.", resultadoPausa);
            Assert.AreEqual("Aquecimento finalizado!", resultadoAquecimento);
        }

        [TestMethod]
        public async Task TestPausarAquecimento()
        {
            await _service.IniciarAquecimento(2, 5);
            var resultado = await _service.PausarAquecimento();
            Assert.AreEqual("Aquecimento pausado.", resultado);
        }

        [TestMethod]
        public async Task TestPausarAquecimentoSemIniciar()
        {
            var resultado = await _service.PausarAquecimento();
            Assert.AreEqual("Nenhum aquecimento em andamento.", resultado);
        }

        //TESTES DE CANCELAR
        [TestMethod]
        public async Task TestCancelarAquecimentoDuranteDelay()
        {
            var task = _service.IniciarAquecimento(10, 5);
            await Task.Delay(1000); // Espera 1 segundo antes de cancelar
            var resultadoCancelamento = await _service.CancelarAquecimento();
            var resultadoAquecimento = await task;

            Assert.AreEqual("Aquecimento cancelado.", resultadoCancelamento);
            Assert.AreEqual("Aquecimento cancelado.", resultadoAquecimento);
        }

        [TestMethod]
        public async Task TestCancelarAquecimento()
        {
            await _service.IniciarAquecimento(2, 5);
            var resultado = await _service.CancelarAquecimento();
            Assert.AreEqual("Aquecimento cancelado.", resultado);
        }

        [TestMethod]
        public async Task TestCancelarAquecimentoSemIniciar()
        {
            var resultado = await _service.CancelarAquecimento();
            Assert.AreEqual("Nenhum aquecimento em andamento.", resultado);
        }
    }
}
