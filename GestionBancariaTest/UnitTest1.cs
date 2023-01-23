using GestionBancariaAppNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GestionBancariaTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]

        public void validarReintegro()
        {
            double saldoInicial = 1000;
            double reintegro = 250;
            double saldoEsperado = saldoInicial - reintegro;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            miApp.realizarReintegro(reintegro);
            Assert.AreEqual(saldoEsperado, miApp.obtenerSaldo(), 0.001, "Se produjo un error al realizar el reintegro, saldo incorrecto.");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void validarReintegroNeg()
        {

            double saldoInicial = 1000;
            double reintegro = -250;
            double saldofinal = saldoInicial - reintegro;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            miApp.realizarReintegro(reintegro);
            Assert.AreEqual(saldofinal, miApp.obtenerSaldo(), "Se produjo un error al realizar el reintegro, saldo negativo.");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void validarReintegroNeg_Mayorquesaldo()
        {
            double saldoInicial = 0;
            double reintegro = 250;
            double saldofinal = saldoInicial - reintegro;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            miApp.realizarReintegro(reintegro);
            Assert.AreEqual(saldofinal, miApp.obtenerSaldo(), "Se produjo un error al realizar el reintegro, saldo insufuciente?.");
        }

        [TestMethod]
        public void validarIngreso()
        {
            double ingreso = 10;
            double saldo = 0;
            double saldoesperado = ingreso + saldo;
            GestionBancariaApp miApp = new GestionBancariaApp(saldo);
            miApp.realizarIngreso(ingreso);
            Assert.AreEqual(saldoesperado, miApp.obtenerSaldo());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void validarIngreso_al_usar_Neg()
        {

            double ingreso = -50;
            double saldo = 0;
            double saldoesperado = ingreso - saldo;
            GestionBancariaApp miApp = new GestionBancariaApp(saldo);
            miApp.realizarIngreso(ingreso);
            Assert.AreEqual(saldoesperado, miApp.obtenerSaldo(), "Cantidad no valida, soló se admiten cantidades positivas .");
        }
    }
}
