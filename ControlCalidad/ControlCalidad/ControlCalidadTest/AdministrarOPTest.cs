using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ControlCalidad.Presentador;
using ControlCalidad.Modelo;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using ControlCalidadDominio.Modelo;

namespace ControlCalidadTest
{
    [TestClass]
    public class AdministrarOPTest
    {
        [TestMethod]
        public void ValidarLineasDisponibles()
        {
            var AdmOP = new OrdenProduccionP();
            List<LineaTrabajo> ListaLineas;
            var orden = new OrdenProduccion();

            ListaLineas = AdmOP.ConsultaLineasEnOP("Finalizado");

            Assert.IsTrue(ListaLineas.Any());

        }

       


        [TestMethod]
        public void InsertarColoresOP()
        {
            var colores = new Colores();
            string resultadoEsperado;
            var col = new ColoresP();

            resultadoEsperado = col.Insertar(colores);

            Assert.IsNotNull(resultadoEsperado);

        }


        [TestMethod]
        public void ValidarSupervisorSinOPActiva()
        {
            var AdmOP = new OrdenProduccionP();
            string respuesta;
            var orden = new OrdenProduccion();
            var dni = 25458870;

            respuesta = AdmOP.ConsultaEmpleadoEnOP("Finalizado", dni);

            Assert.IsTrue(respuesta.Any());

        }

        [TestMethod]
        public void ValidarHoraDentroTurno()
        {
            var AdmOP = new InspeccionP();
            string respuesta;
            var orden = new OrdenProduccion();
            var hora = "16:05";

            respuesta = AdmOP.BuscarTurno(hora);

            Assert.IsTrue(respuesta.Any());

        }

        [TestMethod]
        public void ValidarAcumularDefectos()
        {
            var AdmOP = new InspeccionP();
            var orden = new ControlCalidad.Modelo.Inspecciones() { Cantidad = 1, Hora = "16:00", Pie= "Derecho", CodOP= 65, Fecha = "11/12/2020", IdDefecto = 10};
            var acumuladorActual = 0;
            int resultado;
            resultado = AdmOP.Acumular(orden.CodOP, orden.IdDefecto, orden.Pie, int.Parse(orden.Hora));

            Assert.AreEqual(acumuladorActual + 1, resultado);

        }
    }
}
